using System;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Generators
{
    [Serializable]
    public abstract class TexturePreview<T>
    {
        [SerializeField, ReadOnly, UsedImplicitly, HideLabel, PropertyOrder(int.MaxValue),
         PreviewField(100, ObjectFieldAlignment.Center)]
        private Texture2D previewTexture;
        
        [SerializeField]
        private FilterMode filterMode = FilterMode.Point;
        
        public Texture2D RenderPreview(T content)
        {
            this.previewTexture = this.RenderTexture(content);
            
            this.previewTexture.filterMode = this.filterMode;
            this.previewTexture.Apply();
            
            return this.previewTexture;
        }

        protected abstract Texture2D RenderTexture(T content);
    }
}