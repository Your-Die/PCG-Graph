﻿using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Generators
{
    public abstract class GeneratorNodeWithTexture<T> : GeneratorNode<T>
    {
        [SerializeField, ReadOnly, UsedImplicitly, HideLabel, PropertyOrder(int.MaxValue),
         PreviewField(100, ObjectFieldAlignment.Center)]
        private Texture2D previewTexture;

        
        [SerializeField, FoldoutGroup(PreviewGroup)]
        private FilterMode previewFilterMode = FilterMode.Point;

        protected const string PreviewGroup = "Preview Settings";
        
        protected override void UpdatePreview(T result)
        {
            this.previewTexture = this.RenderPreviewTexture(result);
            
            this.previewTexture.filterMode = this.previewFilterMode;
            this.previewTexture.Apply();
        }

        protected abstract Texture2D RenderPreviewTexture(T result);
    }
}