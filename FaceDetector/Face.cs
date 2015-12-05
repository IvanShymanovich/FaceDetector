using FaceDetector.ViolaJones;
using FaceDetector.ViolaJones.Cascade;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceDetector
{
    class Face
    {
        
        private static HaarObjectDetector eyeDetector = new HaarObjectDetector(new EyeHaarCascade());
        private static HaarObjectDetector noseDetector = new HaarObjectDetector(new NoseHaarCascade());
        private static HaarObjectDetector mouthDetector = new HaarObjectDetector(new MouthHaarCascade());
        public Bitmap image { get; set; }
        public Rectangle[] eyeRects { get; private set; }
        public Rectangle[] noseRects { get; private set; }
        public Rectangle[] mouthRects { get; private set; }

        public Face(Bitmap image)
        {
            this.image = image;
        }

        public bool detectAll()
        {
            eyeRects = detectEyes();
            noseRects = detectNose();
            mouthRects = detectMouth();
            return eyeRects.Length > 1 && noseRects.Length > 0 && mouthRects.Length > 0;
        }

        public Bitmap markRects()
        {
            if (eyeRects.Length > 0)
            {
                RectanglesMarker marker = new RectanglesMarker(eyeRects, Color.Red);
                image = MainForm.ConvertToFormat(image, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                image = marker.Apply(image);
            }
            if (noseRects.Length > 0)
            {
                RectanglesMarker marker = new RectanglesMarker(noseRects, Color.Blue);
                image = MainForm.ConvertToFormat(image, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                image = marker.Apply(image);
            }
            if (mouthRects.Length > 0)
            {
                RectanglesMarker marker = new RectanglesMarker(mouthRects, Color.Purple);
                image = MainForm.ConvertToFormat(image, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                image = marker.Apply(image);
            }
            return image;
        }

        public Rectangle[] detectEyes() 
        {
            eyeDetector.ScalingMode = ObjectDetectorScalingMode.SmallerToGreater;
            eyeDetector.ScalingFactor = 1.5f;

            Rectangle[] objects = eyeDetector.ProcessFrame(image);
            return objects;
        }

        public Rectangle[] detectNose()
        {
            noseDetector.ScalingMode = ObjectDetectorScalingMode.SmallerToGreater;
            noseDetector.ScalingFactor = 1.5f;

            Rectangle[] objects = noseDetector.ProcessFrame(image);
            return objects;
        }

        public Rectangle[] detectMouth()
        {
            mouthDetector.ScalingMode = ObjectDetectorScalingMode.SmallerToGreater;
            mouthDetector.ScalingFactor = 1.5f;

            Rectangle[] objects = mouthDetector.ProcessFrame(image);
            return objects;
        }
    }
}
