namespace LostHarbor.Core.Movement
{
    /// <summary>
    /// A movement behaviour describes the steering necessary to accomplish a desire. This
    /// AbstractMovementBehaviour is the root of the decorator pattern used for this movement system.
    /// </summary>
    internal abstract class AbstractMovementBehaviour
    {
        public abstract IMovementResult GetDesiredMovement();
    }
}
