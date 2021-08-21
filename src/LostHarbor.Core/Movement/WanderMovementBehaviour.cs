namespace LostHarbor.Core.Movement
{
    /// <summary>
    /// When an agent has this movement behaviour it will actively desire to wander around the stage.
    /// </summary>
    internal class WanderMovementBehaviour : AbstractMovementDecorator, IMovementBehaviour
    {
        public WanderMovementBehaviour(IMovementBehaviour movementBehaviour, IMovementData movementData)
            : base(movementBehaviour, movementData) { }

        public override IMovementResult GetDesiredMovement()
        {
            return new MovementResult();
        }
    }
}
