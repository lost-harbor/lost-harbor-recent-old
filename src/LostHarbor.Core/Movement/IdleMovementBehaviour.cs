namespace LostHarbor.Core.Movement
{
    /// <summary>
    /// The root behaviour of all movement behaviours.
    /// </summary>
    internal class IdleMovementBehaviour : AbstractMovementBehaviour, IMovementBehaviour
    {
        public override IMovementResult GetDesiredMovement()
        {
            return new MovementResult();
        }
    }
}
