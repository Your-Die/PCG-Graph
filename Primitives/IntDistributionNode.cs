namespace Generators
{
    using Chinchillada.Distributions;
    using Distributions.Components;
    using UnityEngine;

    public class IntDistributionNode : GeneratorNodeWithPreview<int>
    {
        [SerializeField] private IDistribution<int> distribution = new IntRange();
        
        protected override int GenerateInternal()
        {
            return this.distribution.Sample();
        }
    }
}