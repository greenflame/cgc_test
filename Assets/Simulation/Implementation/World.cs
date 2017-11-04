using System.Collections.Generic;
using System.Linq;
using Simulation.Implementation.Components;
using Simulation.Implementation.Exceptions;
using Simulation.Implementation.Factories;
using Simulation.Implementation.Geometry;
using Simulation.Interfaces;
using Simulation.Interfaces.Enums;
using Simulation.Strategies;

namespace Simulation.Implementation
{
    public class World
    {
        public List<GameObject> GameObjects { get; set; }

        public List<GameObject> CreateRequests { get; set; }
        public List<GameObject> DestroyRequests { get; set; }

        public int Tick { get; private set; }

        public World()
        {
            GameObjects = new List<GameObject>();

            CreateRequests = new List<GameObject>();
            DestroyRequests = new List<GameObject>();

            Tick = 0;

            GameObjects.Add(Factory.MakeServiceObject(this));
        }

        public void CreateObject(GameObject o)
        {
            CreateRequests.Add(o);
        }

        public void DestroyObject(GameObject o)
        {
            DestroyRequests.Add(o);
        }

        public void InitializeNewComponents()
        {
            GameObjects.ForEach(o =>
            {
                o.Components
                    .Where(c => !c.IsInitialized)
                    .ToList()
                    .ForEach(c =>
                    {
                        c.InitializeExternal(o);
                        c.IsInitialized = true;
                    });
            });
        }

        private void ProcessDestroyRequests()
        {
            GameObjects = GameObjects.Where(o => !DestroyRequests.Contains(o)).ToList();
        }

        private void ProcessCreateRequests()
        {
            GameObjects.AddRange(CreateRequests);
            CreateRequests.Clear();
        }

        public void DoStep()
        {
            ProcessDestroyRequests();

            ProcessCreateRequests();

            InitializeNewComponents();

            GameObjects.SelectMany(o => o.Components)
                .ToList()
                .ForEach(c => c.DoStep());

            Tick++;
        }

        public GameObject GetObjectSafe<T>() where T : Component
        {
            return GameObjects.FirstOrDefault(o => o.HasComponent<T>());
        }

        public GameObject GetObject<T>() where T : Component
        {
            var obj = GetObjectSafe<T>();

            if (obj == null)
            {
                throw new GameObjectNotFoundException();
            }

            return obj;
        }

        public List<GameObject> GetObjects<T>() where T : Component
        {
            return GameObjects.Where(o => o.HasComponent<T>()).ToList();
        }

        public bool HasObjects<T>() where T : Component
        {
            return GameObjects.Any(o => o.HasComponent<T>());
        }
    }
}