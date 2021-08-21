namespace LostHarbor.Core.Movement
{
    /// <summary>
    /// When an agent has this movement behaviour it will actively desire to avoid obstacles and
    /// other characters.
    /// </summary>
    internal class AvoidMovementBehaviour : AbstractMovementDecorator, IMovementBehaviour
    {
        public AvoidMovementBehaviour(IMovementBehaviour movementBehaviour, IMovementData movementData)
            : base(movementBehaviour, movementData) { }

        public override IMovementResult GetDesiredMovement()
        {
            return new MovementResult();
        }
    }
}
