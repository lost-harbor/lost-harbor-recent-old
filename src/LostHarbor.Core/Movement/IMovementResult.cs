using System.Numerics;

namespace LostHarbor.Core.Movement
{
    public interface IMovementResult
    {
        float AngularVelocity { get; }
        Vector<float> LinearVelocity { get; }
    }
}
