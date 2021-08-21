namespace LostHarbor.Core.Movement
{
    public class MovementBuilder : IMovementBuilder
    {
        private readonly IMovementAgent agent;
        private IMovementBehaviour behaviour;

        public MovementBuilder(IMovementAgent agent)
        {
            this.agent = agent;
            this.behaviour = new IdleMovementBehaviour();
        }

        public bool AddBehaviour(MovementType type, IMovementTarget target)
        {
            var movementData = new MovementData(agent, target);

            // Decorate existing movement behaviours.
            switch (type)
            {
                case MovementType.Seek:
                    this.behaviour = new SeekMovementBehaviour(this.behaviour, movementData);
                    break;

                case MovementType.Flee:
                    this.behaviour = new FleeMovementBehaviour(this.behaviour, movementData);
                    break;

                case MovementType.Pursue:
                    this.behaviour = new PursueMovementBehaviour(this.behaviour, movementData);
                    break;

                case MovementType.Evade:
                    this.behaviour = new EvadeMovementBehaviour(this.behaviour, movementData);
                    break;

                case MovementType.Wander:
                    this.behaviour = new WanderMovementBehaviour(this.behaviour, movementData);
                    break;

                case MovementType.Avoid:
                    this.behaviour = new AvoidMovementBehaviour(this.behaviour, movementData);
                    break;

                default:
                    break;
            }

            return this.behaviour != null;
        }

        public IMovementResult GetDesiredMovement()
        {
            return this.behaviour.GetDesiredMovement();
        }
    }
}
