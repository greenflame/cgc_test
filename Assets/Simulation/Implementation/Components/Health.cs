using System;

namespace Simulation.Implementation.Components
{
    public class Health : Component
    {
        public int Max { get; set; }
        public int Current { get; set; }

        public void TakeDamage(int val)
        {
            Current = Math.Max(0, Current - val);
        }

        public bool IsDead()
        {
            return Current == 0;
        }
    }
}