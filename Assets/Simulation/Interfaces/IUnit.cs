namespace Simulation.Interfaces
{
    public interface IUnit
    {
        float Angle { get; }
        float Radius { get; }

        float X { get; }
        float Y { get; }

        float AngleTo(float x, float y);
        float AngleTo(IUnit obj);

        float DistanceTo(float x, float y);
        float DistanceTo(IUnit obj);
    }
}