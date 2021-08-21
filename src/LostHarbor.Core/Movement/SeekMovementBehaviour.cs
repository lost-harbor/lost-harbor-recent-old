namespace LostHarbor.Core.Movement
{
    /// <summary>
    /// When an agent has this movement behaviour it will actively desire to move to the location of
    /// the target.
    /// </summary>
    internal class SeekMovementBehaviour : AbstractMovementDecorator, IMovementBehaviour
    {
        public SeekMovementBehaviour(IMovementBehaviour movementBehaviour, IMovementData movementData)
            : base(movementBehaviour, movementData) { }

        public override IMovementResult GetDesiredMovement()
        {
            return new MovementResult();
        }
    }
}
