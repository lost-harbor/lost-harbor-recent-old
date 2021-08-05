using System;
using System.Collections.Generic;

namespace LostHarbor.Core.Pooling
{
    /// <summary>
    /// Allows object pooling of any C# object that implements the <see cref="IPoolableObject"/> interface.
    /// </summary>
    /// <typeparam name="T"> The type of object to pool. </typeparam>
    public class ObjectPool<T> where T : IPoolableObject, new()
    {
        private int currentIndex = 0;
        private Stack<T> objectPool;

        /// <summary>
        /// Gets an object that already exists in the pool.
        /// </summary>
        /// <returns> The object from the pool. </returns>
        private T SpawnExisting()
        {
            // Get existing object from pool.
            var objectFromPool = objectPool.Pop();
            currentIndex++;

            // Call respawn functionality on object.
            var pooledObject = objectFromPool as IPoolableObject;
            pooledObject.Respawn();

            return objectFromPool;
        }

        /// <summary>
        /// Gets a new object and add it to the pool.
        /// </summary>
        /// <returns> The newly created object. </returns>
        private T SpawnNew()
        {
            // Create new object and add to pool.
            var objectForPool = new T();
            objectPool.Push(objectForPool);
            currentIndex++;

            // Call initialization on new object.
            var pooledObject = objectForPool as IPoolableObject;
            pooledObject.New();

            return objectForPool;
        }

        /// <summary>
        /// Constructs the object pool and instantiates its initial content.
        /// </summary>
        /// <param name="initialCapacity"> The number of objects to initially fill the pool. </param>
        public ObjectPool(Int32 initialCapacity)
        {
            // Prepare the object pool to receive objects.
            objectPool = new Stack<T>(initialCapacity);

            // Spawn new objects to fill pool.
            for (Int32 i = 0; i < initialCapacity; i++)
            {
                Spawn();
            }

            // Reset to first object in pool.
            Reset();
        }

        /// <summary>
        /// Gets the number of objects currently contained in the pool.
        /// </summary>
        public Int32 Count { get { return objectPool.Count; } }

        /// <summary>
        /// Resets the pool to the first object.
        /// </summary>
        public void Reset() { currentIndex = 0; }

        /// <summary>
        /// Gets an object from the pool is one is available, otherwise it creates a new instance of
        /// the object and stores it in the pool.
        /// </summary>
        /// <returns> The object from the pool. </returns>
        public T Spawn()
        {
            if (currentIndex < Count)
            {
                // We have an existing object; return it.
                return SpawnExisting();
            }
            else
            {
                // We do not have an existing object; return a new one.
                return SpawnNew();
            }
        }
    }
}
