using System.Numerics;

namespace LostHarbor.Core.Movement
{
    public interface IMovementController
    {
        Vector<float> LinearVelocity { get; }
        float AngularVelocity { get; }

        Vector<float> Position { get; }
        Quaternion Rotation { get; }

        float MaximumLinearAcceleration { get; }
        float MaximumLinearSpeed { get; }
        float MaximumAngularAcceleration { get; }
        float MaximumAngularSpeed { get; }
    }
}
