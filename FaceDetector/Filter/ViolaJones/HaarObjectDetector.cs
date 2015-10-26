using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using AForge.Imaging;
using System.Collections.Concurrent;
using FaceDetector.ViolaJones.Cascade;


namespace FaceDetector.ViolaJones
{
    /// <summary>
    ///   Object detector options for window scaling.
    /// </summary>
    /// 
    public enum ObjectDetectorScalingMode
    {
        /// <summary>
        ///   Will start with a big search window and
        ///   gradually scale into smaller ones.
        /// </summary>
        /// 
        GreaterToSmaller,

        /// <summary>
        ///   Will start with small search windows and
        ///   gradually scale into greater ones.
        /// </summary>
        /// 
        SmallerToGreater,
    }

    /// <summary>
    ///   Viola-Jones Object Detector based on Haar-like features.
    ///   If a object has already been detected inside an area,
    ///   it will not be scanned twice for inner/overlapping objects.
    /// </summary>
    public class HaarObjectDetector 
    {

        private List<Rectangle> detectedObjects;
        private HaarClassifier classifier;

        private ObjectDetectorScalingMode scalingMode = ObjectDetectorScalingMode.GreaterToSmaller;

        private Size minSize = new Size(15, 15);
        private Size maxSize = new Size(500, 500);
        private float factor = 1.2f;
        private int channel = RGB.R;

        private Rectangle[] lastObjects;
        private int steadyThreshold = 2;

        private int baseWidth;
        private int baseHeight;

        private int lastWidth;
        private int lastHeight;
        private float[] steps;


        /// <summary>
        ///   Constructs a new Haar object detector.
        /// </summary>
        /// <param name="cascade">
        ///   The <see cref="HaarCascade"/> to use in the detector's classifier.
        ///   For the default face cascade, please take a look on
        ///   <see cref="Cascades.FaceHaarCascade"/>.
        /// </param>
        /// 
        public HaarObjectDetector(HaarCascade cascade) {
            this.classifier = new HaarClassifier(cascade);
            this.detectedObjects = new List<Rectangle>();
            this.baseWidth = cascade.Width;
            this.baseHeight = cascade.Height;
        }

        /// <summary>
        ///   Minimum window size to consider when searching objects.
        /// </summary>
        public Size MinSize
        {
            get { return minSize; }
            set { minSize = value; }
        }

        /// <summary>
        ///   Maximum window size to consider when searching objects.
        /// </summary>
        public Size MaxSize
        {
            get { return maxSize; }
            set { maxSize = value; }
        }

        /// <summary>
        ///   Gets or sets the color channel to use when processing color images. 
        /// </summary>
        public int Channel
        {
            get { return channel; }
            set { channel = value; }
        }

        /// <summary>
        ///   Gets or sets the scaling factor to rescale the window during search.
        /// </summary>
        public float ScalingFactor
        {
            get { return factor; }
            set
            {
                if (value != factor)
                {
                    factor = value;
                    steps = null;
                }
            }
        }

        /// <summary>
        ///   Gets or sets the desired scaling method.
        /// </summary>
        public ObjectDetectorScalingMode ScalingMode
        {
            get { return scalingMode; }
            set
            {
                if (value != scalingMode)
                {
                    scalingMode = value;
                    steps = null;
                }
            }
        }

        /// <summary>
        ///   Gets the detected objects bounding boxes.
        /// </summary>
        public Rectangle[] DetectedObjects
        {
            get { return detectedObjects.ToArray(); }
        }

        /// <summary>
        ///   Gets the internal Cascade Classifier used by this detector.
        /// </summary>
        public HaarClassifier Classifier
        {
            get { return classifier; }
        }

        /// <summary>
        ///   Gets how many frames the object has
        ///   been detected in a steady position.
        /// </summary>
        public int Steady { get; private set; }


        /// <summary>
        ///   Performs object detection on the given frame.
        /// </summary>
        public Rectangle[] ProcessFrame(Bitmap image)
        {
            // Creates an integral image representation of the frame
            IntegralImage2 integralImage = IntegralImage2.FromBitmap(
                UnmanagedImage.FromManagedImage(image), channel, classifier.Cascade.HasTiltedFeatures);

            // Creates a new list of detected objects.
            this.detectedObjects.Clear();

            int width = integralImage.Width;
            int height = integralImage.Height;

            // Update parameters only if different size
            if (steps == null || width != lastWidth || height != lastHeight)
                update(width, height);


            Rectangle window = Rectangle.Empty;

            // For each scaling step
            for (int i = 0; i < steps.Length; i++)
            {
                float scaling = steps[i];

                // Set the classifier window scale
                classifier.Scale = scaling;

                // Get the scaled window size
                window.Width = (int)(baseWidth * scaling);
                window.Height = (int)(baseHeight * scaling);

                // Check if the window is lesser than the minimum size
                if (window.Width < minSize.Width && window.Height < minSize.Height &&
                    window.Width > maxSize.Width && window.Height > maxSize.Height)
                {
                    // If we are searching in greater to smaller mode,
                    if (scalingMode == ObjectDetectorScalingMode.GreaterToSmaller)
                    {
                        goto EXIT; // it won't get bigger, so we should stop.
                    }
                    else
                    {
                        continue; // continue until it gets greater.
                    }
                }


                // Grab some scan loop parameters
                int xStep = window.Width >> 3;
                int yStep = window.Height >> 3;

                int xEnd = width - window.Width;
                int yEnd = height - window.Height;

                // Parallel mode. Scan the integral image searching
                // for objects in the window with parallelization.
                ConcurrentBag<Rectangle> bag = new ConcurrentBag<Rectangle>();

                int numSteps = (int)Math.Ceiling((double)yEnd / yStep);


                // For each pixel in the window column
                Parallel.For(0, numSteps, (j, options) =>
                {
                    int y = j * yStep;

                    // Create a local window reference
                    Rectangle localWindow = window;

                    localWindow.Y = y;

                    // For each pixel in the window row
                    for (int x = 0; x < xEnd; x += xStep)
                    {
                        if (options.ShouldExitCurrentIteration) return;

                        localWindow.X = x;

                        // Try to detect and object inside the window
                        if (classifier.Compute(integralImage, localWindow))
                        {
                            // an object has been detected
                            bag.Add(localWindow);
                        }
                    }
                });

                foreach (Rectangle obj in bag)
                {
                    if (!overlaps(obj))
                        detectedObjects.Add(obj);
                }
            }


        EXIT:

            Rectangle[] objects = detectedObjects.ToArray();

            checkSteadiness(objects);
            lastObjects = objects;

            return objects; // Returns the array of detected objects.
        }

        private void update(int width, int height)
        {
            List<float> listSteps = new List<float>();

            // Set initial parameters according to scaling mode
            if (scalingMode == ObjectDetectorScalingMode.SmallerToGreater)
            {
                float start = 1f;
                float stop = Math.Min(width / (float)baseWidth, height / (float)baseHeight);
                float step = factor;

                for (float f = start; f < stop; f *= step)
                    listSteps.Add(f);
            }
            else
            {
                float start = Math.Min(width / (float)baseWidth, height / (float)baseHeight);
                float stop = 1f;
                float step = 1f / factor;

                for (float f = start; f > stop; f *= step)
                    listSteps.Add(f);
            }

            steps = listSteps.ToArray();

            lastWidth = width;
            lastHeight = height;
        }

        private void checkSteadiness(Rectangle[] rectangles)
        {
            if (lastObjects == null ||
                rectangles == null ||
                rectangles.Length == 0)
            {
                Steady = 0;
                return;
            }

            bool equals = true;
            foreach (Rectangle current in rectangles)
            {
                bool found = false;
                foreach (Rectangle last in lastObjects)
                {
                    if (IsEqual(current, last, steadyThreshold))
                    {
                        found = true;
                        continue;
                    }
                }

                if (!found)
                {
                    equals = false;
                    break;
                }
            }

            if (equals)
                Steady++;

            else
                Steady = 0;
        }

        private bool overlaps(Rectangle rect)
        {
            foreach (Rectangle r in detectedObjects)
            {
                if (rect.IntersectsWith(r))
                    return true;
            }
            return false;
        }


        /// <summary>
        ///   Compares two rectangles for equality, considering an acceptance threshold.
        /// </summary>
        public static bool IsEqual(Rectangle objA, Rectangle objB, int threshold)
        {
            return (Math.Abs(objA.X - objB.X) < threshold) &&
                   (Math.Abs(objA.Y - objB.Y) < threshold) &&
                   (Math.Abs(objA.Width - objB.Width) < threshold) &&
                   (Math.Abs(objA.Height - objB.Height) < threshold);
        }
    }
}
