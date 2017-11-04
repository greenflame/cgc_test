using Simulation.Implementation.Components;
using Simulation.Implementation.Components.Behaviours;
using Simulation.Implementation.Geometry;

namespace Simulation.Implementation.Factories
{
    public class Factory
    {
        public static GameObject MakeQuickMonster(World world)
        {
            GameObject gameObject = new GameObject(world);

            gameObject.Components.Add(new Transform
            {
                Position = new Vector2(0, 0),
                Radius = 1
            });

            gameObject.Components.Add(new MotionController
            {
                RotationSpeed = 0.2f,
                StraightSpeed = 5,
                SideSpeed = 3
            });

            gameObject.Components.Add(new QuickMonster());

            gameObject.Initialize();

            return gameObject;
        }
    }
}