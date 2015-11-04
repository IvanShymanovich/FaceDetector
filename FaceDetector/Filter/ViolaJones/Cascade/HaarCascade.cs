using System;

namespace FaceDetector.ViolaJones.Cascade
{
    /// <summary>
    ///   Cascade of Haar-like features' weak classification stages.
    /// </summary>
    public class HaarCascade : ICloneable
    {
        /// <summary>
        ///   Gets the stages' base width.
        /// </summary>
        /// 
        public int Width { get; protected set; }

        /// <summary>
        ///   Gets the stages' base height.
        /// </summary>
        /// 
        public int Height { get; protected set; }

        /// <summary>
        ///   Gets the classification stages.
        /// </summary>
        /// 
        public HaarCascadeStage[] Stages { get; protected set; }

        /// <summary>
        ///   Gets a value indicating whether this cascade has tilted features.
        /// </summary>
        /// 
        /// <value>
        /// 	<c>true</c> if this cascade has tilted features; otherwise, <c>false</c>.
        /// </value>
        /// 
        public bool HasTiltedFeatures { get; protected set; }

        /// <summary>
        ///   Constructs a new Haar Cascade.
        /// </summary>
        /// 
        /// <param name="baseWidth">Base feature width.</param>
        /// <param name="baseHeight">Base feature height.</param>
        /// <param name="stages">Haar-like features classification stages.</param>
        /// 
        public HaarCascade(int baseWidth, int baseHeight, HaarCascadeStage[] stages)
        {
            Width = baseWidth;
            Height = baseHeight;
            Stages = stages;

            // check if the classifier has tilted features
            HasTiltedFeatures = checkTiltedFeatures(stages);
        }

        /// <summary>
        ///   Constructs a new Haar Cascade.
        /// </summary>
        /// 
        /// <param name="baseWidth">Base feature width.</param>
        /// <param name="baseHeight">Base feature height.</param>
        /// 
        protected HaarCascade(int baseWidth, int baseHeight)
        {
            Width = baseWidth;
            Height = baseHeight;
        }

        /// <summary>
        ///   Checks if the classifier contains tilted (rotated) features
        /// </summary>
        /// 
        private static bool checkTiltedFeatures(HaarCascadeStage[] stages)
        {
            foreach (var stage in stages)
                foreach (var tree in stage.Trees)
                    foreach (var node in tree)
                        if (node.Feature.Tilted == true)
                            return true;
            return false;
        }

        /// <summary>
        ///   Creates a new object that is a copy of the current instance.
        /// </summary>
        /// 
        /// <returns>
        ///   A new object that is a copy of this instance.
        /// </returns>
        /// 
        public object Clone()
        {
            HaarCascadeStage[] newStages = new HaarCascadeStage[Stages.Length];
            for (int i = 0; i < newStages.Length; i++)
                newStages[i] = (HaarCascadeStage)Stages[i].Clone();

            HaarCascade r = new HaarCascade(Width, Height);
            r.HasTiltedFeatures = this.HasTiltedFeatures;
            r.Stages = newStages;

            return r;
        }
    }
}
