using System.Numerics;

namespace LostHarbor.Core.Movement
{
    public interface IMovementTarget
    {
        Vector<float> NextPosition { get; }

        Quaternion NextRotation { get; }

        Vector<float> Position { get; }

        Quaternion Rotation { get; }
    }
}
