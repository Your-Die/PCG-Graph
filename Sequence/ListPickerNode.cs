namespace Generators
{
    using System.Collections.Generic;
    using Chinchillada.Foundation;
    using UnityEngine;

    public abstract class ListPickerNode<T> : GeneratorNode<T>
    {
        [SerializeField] [Input(dynamicPortList = true)]
        private List<T> input;

        protected override T GenerateInternal()
        {
            return this.input.ChooseRandom(this.Random);
        }

        protected override void UpdateInputs()
        {
            base.UpdateInputs();
            this.UpdateDynamicInputList(this.input, nameof(this.input));
        }
    }
}