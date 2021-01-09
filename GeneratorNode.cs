﻿using System;
using Chinchillada.Generation;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Assertions;
using XNode;

namespace Generators
{
    using Chinchillada;

    public abstract class GeneratorNode<T> : Node, IGenerator<T>
    {
        [SerializeField, Output] private T result;

        [SerializeField] private bool regenerate = true;

        protected string ResultFieldName => nameof(this.result);

        public T Result => this.result;
        public event Action<T> Generated;

        [Button]
        public T Generate()
        {
            this.UpdateInputs();

            this.result = this.GenerateInternal();

            this.RenderPreview(this.result);
            this.Generated?.Invoke(this.result);

            return this.result;
        }

        public override object GetValue(NodePort port)
        {
            Assert.IsTrue(port.fieldName == this.ResultFieldName);

            return this.regenerate || this.result == null
                ? this.Generate()
                : this.result;
        }

        protected abstract T GenerateInternal();

        protected virtual void UpdateInputs()
        {
        }

        protected abstract void RenderPreview(T result);
    }
}