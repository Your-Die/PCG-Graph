using JetBrains.Annotations;
using Sirenix.OdinInspector;

namespace Generators
{
    public abstract class GeneratorNodeWithPreview<T> : GeneratorNode<T>
    {
        [ShowInInspector, ReadOnly, UsedImplicitly]
        private string preview;
        
        protected override void UpdatePreview(T result)
        {
            this.preview = result.ToString();
        }
    }
}