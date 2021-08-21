namespace LostHarbor.Core.Movement
{
    public interface IMovementBuilder
    {
        bool AddBehaviour(MovementType type, IMovementTarget target);

        IMovementResult GetDesiredMovement();
    }
}
