﻿using System;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Assertions;
using xNode;

namespace Generators
{
    public interface IInputNode : INamedNode
    {        
        IInputSetter BuildSetter();
    }

    public interface IInputSetter : INodeWrapper
    {
        IInputNode InputNode { get; }
    }

    public abstract class InputNode<T> : Node, IInputNode
    {
        [SerializeField] private T field;

        [SerializeField, Output] private T value;

        public T Value
        {
            get => this.field;
            set => this.field = value;
        }

        public override object GetValue(NodePort port)
        {
            Assert.IsTrue(port.fieldName == nameof(this.value));
            return this.value = this.field;
        }

        public IInputSetter BuildSetter() => new Setter(this);

        [Serializable]
        public class Setter : IInputSetter
        {
            [SerializeField, ReadOnly, UsedImplicitly] private string name;

            [SerializeField, OnValueChanged(nameof(Write))]
            private T value;

            [SerializeField, ReadOnly] private InputNode<T> node;

            public IInputNode InputNode => this.node;
            INamedNode INodeWrapper.Node => this.node;
            
            public Setter()
            {
            }

            public Setter(InputNode<T> node)
            {
                this.node = node;
                this.Read();
            }

            [Button]
            public void Read()
            {
                this.value = this.node.Value;
            }

            private void Write() => this.node.Value = this.value;
        }
    }
}