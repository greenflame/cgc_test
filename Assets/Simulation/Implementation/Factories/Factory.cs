using NUnit.Framework.Interfaces;
using Simulation.Implementation.Components;
using Simulation.Implementation.Components.Behaviours;
using Simulation.Implementation.Components.Behaviours.Monsters;
using Simulation.Implementation.Components.Behaviours.Shells;
using Simulation.Implementation.Components.Guns;
using Simulation.Implementation.Components.Services;
using Simulation.Implementation.Geometry;
using UnityEngine.Networking;

namespace Simulation.Implementation.Factories
{
    public class Factory
    {
        public static GameObject MakeServiceObject(World world)
        {
            GameObject gameObject = new GameObject(world, "ServiceObject");

            gameObject.Components.Add(new SizeService
            {
                Size = new Vector2(1000, 750)
            });

            gameObject.Components.Add(new DeadCollector());

            gameObject.Components.Add(new PhysicService());
            
            return gameObject;
        }

        public static GameObject MakeQuickMonster(World world)
        {
            GameObject gameObject = new GameObject(world, "QuickMonster");

            gameObject.Components.Add(new Transform
            {
                Position = new Vector2(0, 0),
                Radius = 30
            });

            gameObject.Components.Add(new MotionController
            {
                RotationSpeed = 0.1f,
                StraightSpeed = 1,
                SideSpeed = 3
            });

            gameObject.Components.Add(new Health
            {
                Max = 30,
                Current = 30
            });

            gameObject.Components.Add(new SimpleGun
            {
                Cooldown = 10
            });

            gameObject.Components.Add(new QuickMonster());

            return gameObject;
        }

        public static GameObject MakeSimpleShell(World world)
        {
            GameObject gameObject = new GameObject(world, "SimpleBullet");

            gameObject.Components.Add(new Transform
            {
                Position = new Vector2(0, 0),
                Radius = 5
            });

            gameObject.Components.Add(new MotionController
            {
                RotationSpeed = 0,
                StraightSpeed = 10,
                SideSpeed = 0
            });

            gameObject.Components.Add(new SimpleShell
            {
                Damage = 10
            });

            return gameObject;
        }
    }
}