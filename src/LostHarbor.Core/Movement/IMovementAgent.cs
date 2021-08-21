namespace LostHarbor.Core.Movement
{
    public interface IMovementAgent
    {
        IMovementController Controller { get; }
        IMovementProperties Properties { get; }
    }
}
