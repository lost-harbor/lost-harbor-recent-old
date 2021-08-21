namespace LostHarbor.Core.Movement
{
    internal class EvadeMovementBehaviour : FleeMovementBehaviour, IMovementBehaviour
    {
        public EvadeMovementBehaviour(IMovementBehaviour movementBehaviour, IMovementData movementData)
            : base(movementBehaviour, movementData) { }

        public override IMovementResult GetDesiredMovement()
        {
            return new MovementResult();
        }
    }
}
