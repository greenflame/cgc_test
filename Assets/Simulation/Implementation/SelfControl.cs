using System;
using System.Collections.Generic;
using System.Security.Policy;
using Assets.Simulation.Implementation;
using Simulation.Interfaces;
using Simulation.Interfaces.Enums;

namespace Simulation.Implementation
{
    public class SelfControl : ISelfControl
    {
        // Unit
        public float Angle { get; set; }
        public float Radius { get; set; }
        public float X { get; set; }
        public float Y { get; set; }

        // Movable Unit
        public float LeftSpeed { get; set; }
        public float RightSpeed { get; set; }
        public float ForwardSpeed { get; set; }
        public float BackSpeed { get; set; }

        public float RotationSpeed { get; set; }

        // Enemy
        public string Name { get; set; }
        public PlayerType PlayerType { get; set; }
        public IList<IEffect> Effects { get; set; }

        // Self Control
        public int Score { get; set; }

        // Internal
        public Vector2 Position
        {
            get { return new Vector2(X, Y); }
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        public Vector2 Forward
        {
            get { return Vector2.FromAngle(Angle); }
        }

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
            TurnInternal();
        }

        public void MoveInternal()
        {
            switch (MotionAction)
            {
                case MotionType.Idle:
                    break;
                case MotionType.Forvard:
                    Position += Vector2.FromAngle(Angle) * ForwardSpeed;
                    break;
                case MotionType.Back:
                    Position += Vector2.FromAngle(Angle) * BackSpeed;
                    break;
                case MotionType.Left:
                    Position += Vector2.FromAngle(Angle) * LeftSpeed;
                    break;
                case MotionType.Right:
                    Position += Vector2.FromAngle(Angle) * RightSpeed;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void TurnInternal()
        {
            RotationAction = Math.Min(RotationAction, RotationSpeed);
            RotationAction = Math.Max(RotationAction, -RotationSpeed);

            Angle += RotationAction;
            NormalizeAngle();
        }

        public void NormalizeAngle()
        {
            const float twoPi = (float)Math.PI * 2;

            while (Angle <= -Math.PI)
            {
                Angle += twoPi;
            }

            while (Angle > Math.PI)
            {
                Angle -= twoPi;
            }
        }

        public float AngleTo(float x, float y)
        {
            return Forward.AngleTo(new Vector2(x, y) - Position);
        }

        public float AngleTo(IUnit obj)
        {
            return AngleTo(obj.X, obj.Y);
        }

        public float DistanceTo(float x, float y)
        {
            return Position.DistanceTo(new Vector2(x, y));
        }

        public float DistanceTo(IUnit obj)
        {
            return Position.DistanceTo(Vector2.FromUnit(obj));
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