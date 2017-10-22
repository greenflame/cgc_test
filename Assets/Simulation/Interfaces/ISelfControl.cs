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

        void Turn(float angle);
        void TurnTo(float x, float y);
        void TurnTo(IUnit obj);
    }
}