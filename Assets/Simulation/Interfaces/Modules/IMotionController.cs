namespace Simulation.Interfaces.Modules
{
    public interface IMotionController
    {
        float LeftSpeed { get; }
        float RightSpeed { get; }
        float ForwardSpeed { get; }
        float BackSpeed { get; }

        float RotationSpeed { get; }
    }
}