namespace LostHarbor.Core.Movement
{
    public class MovementProperties : IMovementProperties
    {
        public float SlowRadius { get; init; }
        public float ArriveRadius { get; init; }
        public float SlowAngle { get; init; }
        public float ArriveAngle { get; init; }

        public MovementProperties(float slowRadius, float arriveRadius, float slowAngle, float arriveAngle)
        {
            this.SlowRadius = slowRadius;
            this.ArriveRadius = arriveRadius;
            this.SlowAngle = slowAngle;
            this.ArriveAngle = arriveAngle;
        }
    }
}
