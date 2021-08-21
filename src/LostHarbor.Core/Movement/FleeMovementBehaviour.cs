namespace LostHarbor.Core.Movement
{
    /// <summary>
    /// When an agent has this movement behaviour it will actively desire to move directly away from
    /// the location of the target.
    /// </summary>
    internal class FleeMovementBehaviour : AbstractMovementDecorator, IMovementBehaviour
    {
        public FleeMovementBehaviour(IMovementBehaviour movementBehaviour, IMovementData movementData)
            : base(movementBehaviour, movementData) { }

        public override IMovementResult GetDesiredMovement()
        {
            return new MovementResult();
        }
    }
}
