using JetBrains.Annotations;
using Sirenix.OdinInspector;

namespace Generators
{
    using UnityEngine;

    public abstract class GeneratorNodeWithPreview<T> : GeneratorNode<T>
    {
        [ShowInInspector, ReadOnly, UsedImplicitly, TextArea(4, 4),PropertyOrder(int.MaxValue)]
        private string preview;

        protected override void UpdatePreview(T result)
        {
            this.preview = result.ToString();
        }
    }
}