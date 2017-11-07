using System;

namespace Simulation.Implementation.Components.Behaviours.Players
{
    public class PlayerBehaviour : Behaviour
    {
        public enum PlayerType
        {
            Red,
            Green,
            Blue,
            Yellow
        }

        public PlayerType Type { get; set; }
    }
}