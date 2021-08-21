namespace LostHarbor.Core.Movement
{
    internal interface IMovementBehaviour
    {
        IMovementResult GetDesiredMovement();
    }
}
