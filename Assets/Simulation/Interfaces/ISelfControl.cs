namespace Simulation.Interfaces
{
    public interface ISelfControl : IPlayer
    {
        void SetName(string name);

        void Shot();

        void StepBack();
        void StepForward();
        void StepLeft();
        void StepRight();

        void Turn(double angle);
        void TurnTo(double x, double y);
        void TurnTo(IUnit obj);
    }
}