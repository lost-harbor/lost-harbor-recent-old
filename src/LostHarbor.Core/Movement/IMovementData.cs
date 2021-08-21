namespace LostHarbor.Core.Movement
{
    internal interface IMovementData
    {
        IMovementAgent Agent { get; }
        IMovementTarget Target { get; }
    }
}
