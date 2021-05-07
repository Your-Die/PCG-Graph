using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Generators
{
    using Chinchillada;
    using Chinchillada.NodeGraph;
    using Interfaces;
    using Sirenix.Serialization;

    public abstract class GeneratorNode<T> : OutputNode<T>, IGenerator<T>
    {
        [SerializeField] private bool regenerate = true;

        [SerializeField]
        [OnValueChanged(nameof(UpdateRandomOverride))]
        private bool overrideRandom;

        [OdinSerialize]
        [ShowIf(nameof(overrideRandom))]
        private Constant<IRNG> rng;

        [OdinSerialize] [HideInInspector] private ISource<IRNG> randomSource;

        protected IRNG Random => this.randomSource.Get();

        public T Result => this.Output;

        protected bool Regenerate
        {
            get => this.regenerate;
            set => this.regenerate = value;
        }

        public event Action<T> Generated;

        public T Generate()
        {
            this.UpdateInputs();
            var result = this.GenerateInternal();

            this.Generated?.Invoke(result);
            return result;
        }
        
        protected override T UpdateOutput() => this.Generate();

        protected abstract T GenerateInternal();

        protected virtual void UpdateInputs() { }

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

        T ISource<T>.Get() => this.Generate();
    }
}