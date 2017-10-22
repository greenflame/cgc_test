using System;
using System.Collections.Generic;
using System.Security.Policy;
using Assets.Simulation.Implementation;
using Simulation.Implementation.Geometry;
using Simulation.Interfaces;
using Simulation.Interfaces.Enums;

namespace Simulation.Implementation
{
    public class SelfControl : MovableUnit, ISelfControl
    {
        // Player
        public string Name { get; set; }
        public PlayerType PlayerType { get; set; }
        public IList<IEffect> Effects { get; set; }

        // Self Control
        public int Score { get; set; }

        // Internal
        public MotionType MotionAction { get; set; }
        public float RotationAction { get; set; }


        public SelfControl()
        {
            Effects = new List<IEffect>();
            Position = new Vector2();

            RotationSpeed = 0.1f;

            ForwardSpeed = 2;
            BackSpeed = 2;
            LeftSpeed = 1;
            RightSpeed = 1;
        }

        public void ResetActions()
        {
            MotionAction = MotionType.Idle;
            RotationAction = 0;
        }

        public void ProcessActions()
        {
            MoveInternal();
            RotateConsiderSpeed(RotationAction);
        }

        public void MoveInternal()
        {
            switch (MotionAction)
            {
                case MotionType.Idle:
                    break;
                case MotionType.Forvard:
                    (this as MovableUnit).StepForward();
                    break;
                case MotionType.Back:
                    (this as MovableUnit).StepBack();
                    break;
                case MotionType.Left:
                    (this as MovableUnit).StepLeft();
                    break;
                case MotionType.Right:
                    (this as MovableUnit).StepForward();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public bool HasEffectOfType(IEffect effectType)
        {
            throw new System.NotImplementedException();
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void Shot()
        {
            throw new NotImplementedException();
        }

        public new void StepBack()
        {
            MotionAction = MotionType.Back;
        }

        public new void StepForward()
        {
            MotionAction = MotionType.Forvard;
        }

        public new void StepLeft()
        {
            MotionAction = MotionType.Left;
        }

        public new void StepRight()
        {
            MotionAction = MotionType.Right;
        }

        public void Turn(float angle)
        {
            RotationAction = angle;
        }

        public void TurnTo(float x, float y)
        {
            RotationAction = Forward.AngleTo(new Vector2(x, y) - Position);
        }

        public void TurnTo(IUnit obj)
        {
            TurnTo(obj.X, obj.Y);
        }
    }
}