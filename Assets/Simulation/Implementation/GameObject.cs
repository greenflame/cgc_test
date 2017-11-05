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

        public List<Component> CreateRequests { get; set; }
        public List<Component> DestroyRequests { get; set; }

        public GameObject(World world, string name)
        {
            World = world;
            Name = name;

            Components = new List<Component>();

            CreateRequests = new List<Component>();
            DestroyRequests = new List<Component>();
        }

        public void CreateComponent(Component o)
        {
            CreateRequests.Add(o);
        }

        public void DestroyComponent(Component o)
        {
            DestroyRequests.Add(o);
        }

        public void ProcessComponentDestroyRequests()
        {
            Components = Components.Where(c => !DestroyRequests.Contains(c)).ToList();
        }

        public void ProcessComponentCreateRequests()
        {
            Components.AddRange(CreateRequests);
            CreateRequests.Clear();
        }

        public void InitializeNewComponents()
        {
            Components.Where(c => !c.IsInitialized)
                .ToList()
                .ForEach(c =>
                {
                    c.InitializeInternal(this);
                    c.IsInitialized = true;
                });
        }

        public void DoStep()
        {
            Components.ForEach(c => c.DoStep());
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
    }
}