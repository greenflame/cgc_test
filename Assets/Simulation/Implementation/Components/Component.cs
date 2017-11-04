namespace Simulation.Implementation.Components
{
    public abstract class Component
    {
        public GameObject GameObject { get; set; }

        public virtual void Initialize(GameObject gameObject)
        {
            GameObject = gameObject;
        }

        public virtual void DoStep()
        {
            
        }
    }
}