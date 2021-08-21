namespace LostHarbor.Core.Movement
{
    internal class PursueMovementBehaviour : SeekMovementBehaviour, IMovementBehaviour
    {
        public PursueMovementBehaviour(IMovementBehaviour movementBehaviour, IMovementData movementData)
            : base(movementBehaviour, movementData) { }

        public override IMovementResult GetDesiredMovement()
        {
            return new MovementResult();
        }
    }
}
