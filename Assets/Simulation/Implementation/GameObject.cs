using Simulation.Implementation.Components;
using System.Collections.Generic;
using System.Linq;
using Simulation.Implementation.Exceptions;

namespace Simulation.Implementation
{
    public sealed class GameObject
    {
        public World World { get; set; }

        public string Name { get; set; }

        public List<Component> Components { get; set; }
        public List<Component> CapturedComponents { get; set; }

        public GameObject(World world, string name)
        {
            World = world;
            Name = name;

            Components = new List<Component>();
            CapturedComponents = new List<Component>();
        }

        public void CreateComponent(Component o)
        {
            Components.Add(o);
        }

        public void DestroyComponent(Component o)
        {
            Components.Remove(o);
        }

        public void CaptureComponents()
        {
            CapturedComponents = Components.ToList();
        }

        public void InitializeNewComponents()
        {
            CapturedComponents.Where(c => !c.IsInitialized)
                .ToList()
                .ForEach(c =>
                {
                    c.InitializeInternal(this);
                    c.IsInitialized = true;
                });
        }

        public void DoStep()
        {
            CapturedComponents.ForEach(c => c.DoStep());
        }

        public T GetComponentSafe<T>()
        {
            return Components.OfType<T>().FirstOrDefault();
        }

        public T GetComponent<T>()
        {
            T component = GetComponentSafe<T>();

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

        public void RequireComponent<T>()
        {
            GetComponent<T>();
        }
    }
}