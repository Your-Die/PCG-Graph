namespace Generators
{
    using UnityEngine;

    public abstract class MemoryNode<T> : GeneratorNode<T>, IInitializableNode
    {
        [SerializeField] [Input] private T memory;

        [SerializeField][Input] private bool shouldGenerate = true;
        
        protected override T GenerateInternal()
        {
            this.shouldGenerate = false;
            return this.Copy(this.memory);
        }

        public void Initialize() => this.Regenerate = true;

        protected abstract T Copy(T item);

        protected override void UpdateInputs()
        {
            base.UpdateInputs();
            
            this.UpdateInput(ref this.memory, nameof(this.memory));
            this.UpdateInput(ref this.shouldGenerate, nameof(this.shouldGenerate));
        }
    }
}