using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Chinchillada.GeneratorGraph
{
    public class FloatRangeGeneratorNode : GeneratorNode<float>
    {
        [SerializeField][Input] private float min;
        [SerializeField][Input] private float max;

        [ShowInInspector, ReadOnly, UsedImplicitly]
        private float preview;
        
        protected override float GenerateInternal()
        {
            return Random.Range(this.min, this.max);
        }

        protected override void UpdateInputs()
        {
            this.UpdateInput(ref this.min, nameof(this.min));
            this.UpdateInput(ref this.max, nameof(this.max));
        }

        protected override void RenderPreview(float result)
        {
            this.preview = result;
        }
    }
}