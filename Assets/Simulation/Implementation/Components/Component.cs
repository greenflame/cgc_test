namespace Simulation.Implementation.Components
{
    public abstract class Component
    {
        public GameObject GameObject { get; set; }

        public bool IsInitialized { get; set; }

        protected Component()
        {
            IsInitialized = false;
        }

        public void InitializeInternal(GameObject gameObject)
        {
            GameObject = gameObject;

            Initialize();
        }

        public virtual void Initialize()
        {

        }

        public virtual void DoStep()
        {
            
        }
    }
}