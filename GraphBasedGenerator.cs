using System;
using Chinchillada.Generation;
using UnityEngine;

namespace Generators
{
    using Chinchillada.NodeGraph;

    [Serializable]
    public class GraphBasedGenerator<T> : GeneratorBase<T>
    {
        [SerializeField] private OutputGraph outputGraph;

        protected override T GenerateInternal()
        {
            return this.outputGraph.TryGetOutput<T>(out var result) ? result : default;
        }
    }
}