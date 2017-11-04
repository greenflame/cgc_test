using Simulation.Implementation.Components;
using System.Collections.Generic;
using System.Linq;
using Simulation.Implementation.Components.Exceptions;

namespace Simulation.Implementation
{
    public class GameObject
    {
        public World World { get; set; }

        public List<Component> Components { get; set; }

        public GameObject(World world)
        {
            World = world;
            Components = new List<Component>();
        }

        public void Initialize()
        {
            Components.ForEach(c => c.Initialize(this));
        }

        public void DoStep()
        {
            Components.ForEach(c => c.DoStep());
        }

        public T GetComponent<T>()
        {
            return Components.OfType<T>().FirstOrDefault();
        }

        public T GetComponentUnsafe<T>()
        {
            T component = GetComponent<T>();

            if (component == null)
            {
                throw new ComponentNotFoundException();
            }

            return component;
        }

        public List<T> GetComponents<T>() where T : Component
        {
            return Components.OfType<T>().ToList();
        }

        public bool HasComponent<T>() where T : Component
        {
            return Components.OfType<T>().Any();
        }
    }
}