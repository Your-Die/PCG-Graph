using NUnit.Framework;

namespace Generators
{
    using UnityEngine;

    [TestFixture]
    public class Vector2GeneratorNode : GeneratorNode<Vector2>
    {
        [SerializeField] [Input] private float x;
        [SerializeField] [Input] private float y;

        protected override Vector2 GenerateInternal()
        {
            return new Vector2(this.x, this.y);
        }

        protected override void UpdateInputs()
        {
            base.UpdateInputs();
            this.UpdateInput(ref this.x, nameof(this.x));
            this.UpdateInput(ref this.y, nameof(this.y));
        }
    }
}