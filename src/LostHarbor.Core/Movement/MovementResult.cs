using System.Numerics;

namespace LostHarbor.Core.Movement
{
    public class MovementResult : IMovementResult
    {
        public float AngularVelocity { get; init; }
        public Vector<float> LinearVelocity { get; init; }

        public MovementResult(Vector<float> linearVelocity, float angularVelocity)
        {
            this.LinearVelocity = linearVelocity;
            this.AngularVelocity = angularVelocity;
        }

        public MovementResult()
        {
            this.LinearVelocity = Vector<float>.Zero;
            this.AngularVelocity = 0.0f;
        }
    }
}
