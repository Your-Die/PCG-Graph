using Chinchillada.Distributions;
using Sirenix.Serialization;

namespace Chinchillada.GeneratorGraph
{
    public class FloatDistributionNode : GeneratorNodeWithPreview<float>
    {
        [OdinSerialize] private IDistribution<float> distribution;
        
        protected override float GenerateInternal()
        {
            return this.distribution.Sample();
        }

        protected override void UpdateInputs()
        {
        }
    }
}