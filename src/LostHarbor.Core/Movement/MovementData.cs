namespace LostHarbor.Core.Movement
{
    internal class MovementData : IMovementData
    {
        public IMovementAgent Agent { get; init; }
        public IMovementTarget Target { get; init; }

        public MovementData(IMovementAgent agent, IMovementTarget target)
        {
            this.Agent = agent;
            this.Target = target;
        }
    }
}
