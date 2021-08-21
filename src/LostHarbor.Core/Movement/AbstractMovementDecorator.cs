namespace LostHarbor.Core.Movement
{
    /// <summary>
    /// Movement behaviours that can be wrapped around other movement behaviours to add additional
    /// movement desires.
    /// </summary>
    internal abstract class AbstractMovementDecorator : AbstractMovementBehaviour
    {
        protected IMovementBehaviour movementBehaviour;
        protected IMovementController movementController;
        protected IMovementData movementData;

        public AbstractMovementDecorator(IMovementBehaviour movementBehaviour, IMovementData movementData)
        {
            this.movementBehaviour = movementBehaviour;
            this.movementData = movementData;
            this.movementController = movementData.Agent.Controller;
        }
    }
}
