namespace Generators
{
    using UnityEngine;

    public class FloatRangeNode : GeneratorNode<float>
    {
        [SerializeField] [Input] private float min;
        [SerializeField] [Input] private float max;

        protected override float GenerateInternal()
        {
            return this.Random.Range(this.min, this.max);
        }

        protected override void UpdateInputs()
        {
            base.UpdateInputs();
            this.UpdateInput(ref this.min, nameof(this.min));
            this.UpdateInput(ref this.max,    nameof(this.max));
        }
    }
}