using JetBrains.Annotations;
using Sirenix.OdinInspector;

namespace Chinchillada.GeneratorGraph
{
    public abstract class GeneratorNodeWithPreview<T> : GeneratorNode<T>
    {
        [ShowInInspector, ReadOnly, UsedImplicitly]
        private string preview;
        
        protected override void RenderPreview(T result)
        {
            this.preview = result.ToString();
        }
    }
}