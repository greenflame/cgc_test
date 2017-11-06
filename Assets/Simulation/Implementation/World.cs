using System.Collections.Generic;
using System.Linq;
using Simulation.Implementation.Components;
using Simulation.Implementation.Exceptions;
using Simulation.Implementation.Factories;

namespace Simulation.Implementation
{
    public class World
    {
        public List<GameObject> GameObjects { get; set; }
        public List<GameObject> CapturedGameObjects { get; set; }

        public World()
        {
            GameObjects = new List<GameObject>();

            CreateObject(Factory.MakeServiceObject(this));
        }

        public void CreateObject(GameObject o)
        {
            GameObjects.Add(o);
        }

        public void DestroyObject(GameObject o)
        {
            GameObjects.Remove(o);
        }

        private void CaptureGameObjects()
        {
            CapturedGameObjects = GameObjects.ToList();
        }

        public void DoStep()
        {
            CaptureGameObjects();

            CapturedGameObjects.ForEach(o => o.CaptureComponents());

            CapturedGameObjects.ForEach(o => o.InitializeNewComponents());

            CapturedGameObjects.Where(o => !o.Name.StartsWith("Service"))
                .ToList()
                .ForEach(o => o.DoStep());

            CapturedGameObjects.Where(o => o.Name.StartsWith("Service"))
                .ToList()
                .ForEach(o => o.DoStep());
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