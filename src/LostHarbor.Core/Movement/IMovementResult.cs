using System.Numerics;

namespace LostHarbor.Core.Movement
{
    public interface IMovementResult
    {
        Quaternion AngularVelocity { get; }
        Vector3 LinearVelocity { get; }
    }
}
