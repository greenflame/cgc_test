namespace Simulation.Interfaces
{
    public interface IUnit
    {
        double Angle { get; }
        double Radius { get; }

        double X { get; }
        double Y { get; }

        double AngleTo(double x, double y);
        double AngleTo(IUnit obj);

        double DistanceTo(double x, double y);
        double DistanceTo(IUnit obj);
    }
}