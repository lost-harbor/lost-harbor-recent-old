namespace LostHarbor.Core.Movement
{
    public interface IMovementProperties
    {
        float SlowRadius { get; }
        float ArriveRadius { get; }
        float SlowAngle { get; }
        float ArriveAngle { get; }
    }
}
