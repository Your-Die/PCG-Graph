﻿using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Generators
{
    using Chinchillada;

    public abstract class SequenceGeneratorNode<T> : GeneratorNode<List<T>>
    {
        [SerializeField] private int sequenceLength;

        [SerializeField] private IGenerator<T> itemGenerator;

        [ShowInInspector, ReadOnly, UsedImplicitly] private List<T> preview;
        
        protected override List<T> GenerateInternal()
        {
            return this.itemGenerator.Generate(this.sequenceLength).ToList();
        }

        protected override void UpdateInputs()
        {
            this.sequenceLength = this.GetInputValue(nameof(this.sequenceLength), this.sequenceLength);
        }

        protected override void UpdatePreview(List<T> result) => this.preview = result.ToList();
    }
}