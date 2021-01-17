using Chinchillada.Distributions;
using Sirenix.Serialization;

namespace Generators
{
    public class FloatDistributionNode : GeneratorNodeWithPreview<float>
    {
        [OdinSerialize] private IDistribution<float> distribution;

        protected override float GenerateInternal() => this.distribution.Sample(this.Random);

        protected override void UpdateInputs() { }
    }
}