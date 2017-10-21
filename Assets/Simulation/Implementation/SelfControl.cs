using System.Collections.Generic;
using Assets.Simulation.Implementation;
using Simulation.Interfaces;
using Simulation.Interfaces.Enums;

namespace Simulation.Implementation
{
    public class SelfControl : ISelfControl
    {
        public MotionType MotionAction { get; set; }
        public float RotationAction { get; set; }

        public SelfControl(PlayerType playerType)
        {
            PlayerType = playerType;
        }

        public void InitTurn()
        {
            MotionAction = MotionType.Idle;
            RotationAction = 0;
        }

        public void ProcessTurn()
        {
            switch (MotionAction)
            {
                case MotionType.Forvard:
                    Y += 10;
                    break;
            }
        }

        public float Angle { get; set; }
        public float Radius { get; set; }
        public float X { get; set; }
        public float Y { get; set; }

        public float AngleTo(float x, float y)
        {
            throw new System.NotImplementedException();
        }

        public float AngleTo(IUnit obj)
        {
            throw new System.NotImplementedException();
        }

        public float DistanceTo(float x, float y)
        {
            throw new System.NotImplementedException();
        }

        public float DistanceTo(IUnit obj)
        {
            throw new System.NotImplementedException();
        }

        public float Speed { get; private set; }

        public string Name { get; private set; }
        public PlayerType PlayerType { get; private set; }
        public IList<IEffect> Effects { get; private set; }

        public bool HasEffectOfType(IEffect effectType)
        {
            throw new System.NotImplementedException();
        }

        public int Score { get; private set; }
        public void SetName(string name)
        {
            throw new System.NotImplementedException();
        }

        public void Shot()
        {
            throw new System.NotImplementedException();
        }

        public void StepBack()
        {
            MotionAction = MotionType.Back;
        }

        public void StepForward()
        {
            MotionAction = MotionType.Forvard;
        }

        public void StepLeft()
        {
            MotionAction = MotionType.Left;
        }

        public void StepRight()
        {
            MotionAction = MotionType.Right;
        }

        public void Turn(float angle)
        {
            throw new System.NotImplementedException();
        }

        public void TurnTo(float x, float y)
        {
            throw new System.NotImplementedException();
        }

        public void TurnTo(IUnit obj)
        {
            throw new System.NotImplementedException();
        }
    }
}