using System;
using System.Drawing;
using FaceDetector.ViolaJones.Cascade;


namespace FaceDetector.ViolaJones
{
    /// <summary>
    ///   Strong classifier based on a weaker cascade of
    ///   classifiers using Haar-like rectangular features.
    /// </summary> 
    public class HaarClassifier 
    {
        private HaarCascade cascade;
        private float invArea;
        private float scale;

        /// <summary>
        ///   Constructs a new classifier.
        /// </summary>
        public HaarClassifier(HaarCascade cascade)
        {
            this.cascade = cascade;
        }

        /// <summary>
        ///   Gets the cascade of weak-classifiers
        ///   used by this strong classifier.
        /// </summary>
        public HaarCascade Cascade
        {
            get { return cascade; }
        }

        /// <summary>
        ///   Gets or sets the scale of the search window
        ///   being currently used by the classifier.
        /// </summary>
        /// 
        public float Scale
        {
            get { return this.scale; }
            set
            {
                if (this.scale == value)
                    return;

                this.scale = value;
                this.invArea = 1f / (cascade.Width * cascade.Height * scale * scale);

                // For each stage in the cascade 
                foreach (HaarCascadeStage stage in cascade.Stages)
                {
                    // For each tree in the cascade
                    foreach (HaarFeatureNode[] tree in stage.Trees)
                    {
                        // For each feature node in the tree
                        foreach (HaarFeatureNode node in tree)
                        {
                            // Set the scale and weight for the node feature
                            node.Feature.SetScaleAndWeight(value, invArea);
                        }
                    }
                }
            }
        }


        /// <summary>
        ///   Detects the presence of an object in a given window.
        /// </summary>
        /// 
        public bool Compute(IntegralImage2 image, Rectangle rectangle)
        {
            int x = rectangle.X;
            int y = rectangle.Y;
            int w = rectangle.Width;
            int h = rectangle.Height;

            double mean = image.GetSum(x, y, w, h) * invArea;
            double factor = image.GetSum2(x, y, w, h) * invArea - (mean * mean);

            factor = (factor >= 0) ? Math.Sqrt(factor) : 1;


            // For each classification stage in the cascade
            foreach (HaarCascadeStage stage in cascade.Stages)
            {
                // Check if the stage has rejected the image
                if (stage.Classify(image, x, y, factor) == false)
                {
                    return false; // The image has been rejected.
                }
            }

            // If the object has gone all stages and has not
            //  been rejected, the object has been detected.

            return true; // The image has been detected.
        }
    }
}
