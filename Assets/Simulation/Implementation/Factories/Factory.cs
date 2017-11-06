using Simulation.Implementation.Components;
using Simulation.Implementation.Components.Behaviours.Monsters;
using Simulation.Implementation.Components.Behaviours.Shells;
using Simulation.Implementation.Components.Guns;
using Simulation.Implementation.Components.Services;
using Simulation.Implementation.Geometry;

namespace Simulation.Implementation.Factories
{
    public class Factory
    {
        public static GameObject MakeServiceObject(World world)
        {
            GameObject gameObject = new GameObject(world, "ServiceObject");

            gameObject.CreateComponent(new SizeService
            {
                Size = new Vector2(1000, 750)
            });

            gameObject.CreateComponent(new DeadCollector());

            gameObject.CreateComponent(new PhysicService());

            gameObject.CreateComponent(new TimeService());
            
            return gameObject;
        }

        public static GameObject MakeQuickMonster(World world, Vector2 pos, double angle = 0)
        {
            GameObject gameObject = new GameObject(world, "QuickMonster");

            gameObject.CreateComponent(new Transform
            {
                Position = pos,
                Angle = angle,
                Radius = 30
            });

            gameObject.CreateComponent(new MotionController
            {
                RotationSpeed = 0.1f,
                StraightSpeed = 1,
                SideSpeed = 3
            });

            gameObject.CreateComponent(new Health
            {
                Max = 30,
                Current = 30
            });

            gameObject.CreateComponent(new SimpleGun
            {
                Cooldown = 10
            });

            gameObject.CreateComponent(new QuickMonster());

            return gameObject;
        }

        public static GameObject MakeSimpleShell(World world, Vector2 pos, double angle = 0)
        {
            GameObject gameObject = new GameObject(world, "SimpleBullet");

            gameObject.CreateComponent(new Transform
            {
                Position = pos,
                Angle = angle,
                Radius = 5
            });

            gameObject.CreateComponent(new MotionController
            {
                RotationSpeed = 0,
                StraightSpeed = 10,
                SideSpeed = 0
            });

            gameObject.CreateComponent(new SimpleShell
            {
                Damage = 10
            });

            return gameObject;
        }
    }
}