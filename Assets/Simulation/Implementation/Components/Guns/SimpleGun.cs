using System;
using Simulation.Implementation.Factories;
using Simulation.Implementation.Geometry;

namespace Simulation.Implementation.Components.Guns
{
    public class SimpleGun : Gun
    {
        public int Cooldown { get; set; }
        public int CooldownRemain { get; set; }

        private Transform Transform { get; set; }

        public override void Initialize()
        {
            GameObject.RequireComponent<Transform>();

            Transform = GameObject.GetComponent<Transform>();

            CooldownRemain = Cooldown;
        }

        public override void DoStep()
        {
            CooldownRemain = Math.Max(0, CooldownRemain - 1);
        }

        public bool CanShoot()
        {
            return CooldownRemain == 0;
        }

        public void Shoot()
        {
            if (!CanShoot())
            {
                return;
            }

            CooldownRemain = Cooldown;

            InstantiateShell();
        }

        private void InstantiateShell()
        {
            var shell = Factory.MakeSimpleShell(GameObject.World, Transform.Position, Transform.Angle);

            double dist = Transform.Radius + shell.GetComponent<Transform>().Radius + 5;
            shell.GetComponent<Transform>().Translate(Transform.Forward * dist);

            GameObject.World.CreateObject(shell);
        }
    }
}