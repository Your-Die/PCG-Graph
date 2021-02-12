namespace Generators
{
    using Chinchillada;
    using Chinchillada.Foundation;
    using Chinchillada.NodeGraph;
    using UnityEngine;

    public class GeneratorGraph : OutputGraph, ISource<IRNG>
    {
        [SerializeField] private IRNG random = new UnityRandom();
        
        public IRNG Get() => this.random;
    }
}