using System;
using Simulation.Implementation.Factories;

namespace Simulation.Implementation.Components.Guns
{
    public class SimpleGun : Gun
    {
        public int Cooldown { get; set; }
        public int CooldownRemain { get; set; }

        private Transform Transform { get; set; }

        public override void Initialize()
        {
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

            var shell = Factory.MakeSimpleShell(GameObject.World);

            shell.GetComponent<Transform>().Position = Transform.Position + Transform.Forward * 50;
            shell.GetComponent<Transform>().Angle = Transform.Angle;

            GameObject.World.CreateObject(shell);
        }
    }
}