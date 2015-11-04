using System;


namespace FaceDetector.ViolaJones.Cascade
{

    /// <summary>
    ///   Haar Cascade Feature Tree Node.
    /// </summary>
    public class HaarFeatureNode : ICloneable
    {
        private int rightNodeIndex = -1;
        private int leftNodeIndex = -1;

        /// <summary>
        ///   Gets the threshold for this feature.
        /// </summary>
        public double Threshold { get; set; }

        /// <summary>
        ///   Gets the left value for this feature.
        /// </summary>
        public double LeftValue { get; set; }

        /// <summary>
        ///   Gets the right value for this feature.
        /// </summary>
        public double RightValue { get; set; }

        /// <summary>
        ///   Gets the left node index for this feature.
        /// </summary>
        public int LeftNodeIndex
        {
            get { return leftNodeIndex; }
            set { leftNodeIndex = value; }
        }

        /// <summary>
        ///   Gets the right node index for this feature.
        /// </summary>
        public int RightNodeIndex
        {
            get { return rightNodeIndex; }
            set { rightNodeIndex = value; }
        }

        /// <summary>
        ///   Gets the feature associated with this node.
        /// </summary>
        public HaarFeature Feature { get; set; }

        /// <summary>
        ///   Constructs a new feature tree node.
        /// </summary>
        public HaarFeatureNode() { }

        /// <summary>
        ///   Constructs a new feature tree node.
        /// </summary>
        public HaarFeatureNode(double threshold, double leftValue, double rightValue, params int[][] rectangles)
            : this(threshold, leftValue, rightValue, false, rectangles) { }

        /// <summary>
        ///   Constructs a new feature tree node.
        /// </summary>
        /// 
        public HaarFeatureNode(double threshold, double leftValue, double rightValue, bool tilted, params int[][] rectangles)
        {
            this.Feature = new HaarFeature(tilted, rectangles);
            this.Threshold = threshold;
            this.LeftValue = leftValue;
            this.RightValue = rightValue;
        }


        /// <summary>
        ///   Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        ///   A new object that is a copy of this instance.
        /// </returns>
        /// 
        public object Clone()
        {
            HaarFeatureNode r = new HaarFeatureNode();

            r.Feature = (HaarFeature)Feature.Clone();
            r.Threshold = Threshold;

            r.RightValue = RightValue;
            r.LeftValue = LeftValue;

            r.LeftNodeIndex = leftNodeIndex;
            r.RightNodeIndex = rightNodeIndex;

            return r;
        }
    }
}
