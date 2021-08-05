namespace LostHarbor.Core.Pooling
{
    /// <summary>
    /// Implemented by any object that will be pooled using <see cref="ObjectPool{T}"/>.
    /// </summary>
    public interface IPoolableObject
    {
        /// <summary>
        /// Sets up the object when it is first created.
        /// </summary>
        void New();

        /// <summary>
        /// Sets up the object when it is drawn from the pool.
        /// </summary>
        void Respawn();
    }
}
