using UnityEngine;

namespace Generators
{
    public class Vector2IntGeneratorNode : GeneratorNodeWithPreview<Vector2Int>
    {
        [SerializeField] [Input] private int x;
        [SerializeField] [Input] private int y;
        
        protected override Vector2Int GenerateInternal() => new Vector2Int(this.x, this.y);

        protected override void UpdateInputs()
        {
            this.UpdateInput(ref this.x, nameof(this.x));
            this.UpdateInput(ref this.y, nameof(this.y));
        }
    }
}