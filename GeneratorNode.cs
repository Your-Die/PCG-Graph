using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Assertions;
using XNode;

namespace Generators
{
    using Chinchillada;
    using Chinchillada.Foundation;
    using Interfaces;
    using Sirenix.Serialization;

    public abstract class GeneratorNode<T> : Node, IGenerator<T>
    {
        [SerializeField] [Output] private T result;

        [SerializeField] private bool regenerate = true;

        [SerializeField]
        [OnValueChanged(nameof(UpdateRandomOverride))]
        private bool overrideRandom;

        [OdinSerialize]
        [ShowIf(nameof(overrideRandom))]
        private SourceWrapper<IRNG> rng;

        [SerializeField] [HideInInspector] private ISource<IRNG> randomSource;

        protected IRNG Random => this.randomSource.GetValue();

        public T Result => this.result;

        public event Action<T> Generated;

        public override object GetValue(NodePort port)
        {
            Assert.IsTrue(port.fieldName == nameof(this.result));

            return this.regenerate || this.result == null
                ? this.Generate()
                : this.result;
        }

        public T Generate()
        {
            this.UpdateInputs();

            this.result = this.GenerateInternal();

            this.RenderPreview(this.result);
            this.Generated?.Invoke(this.result);

            return this.result;
        }

        protected abstract T GenerateInternal();

        protected virtual void UpdateInputs() { }

        protected abstract void RenderPreview(T result);

        protected override void Init()
        {
            base.Init();
            this.UpdateRandomOverride();
        }

        protected virtual void OnValidate() => this.UpdateRandomOverride();

        [ContextMenu("Update Random Override")]
        private void UpdateRandomOverride()
        {
            if (!this.overrideRandom)
                this.randomSource = this.graph as ISource<IRNG>;

            if (this.randomSource != null)
                return;

            this.overrideRandom = true;
            this.randomSource   = this.rng;
        }
    }
}