﻿using System;
using System.Collections.Generic;

namespace LostHarbor.Core.Collections
{
    /// <summary>
    /// Represents a list that objects can register to and unregister from.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RegisterList<T>
    {
        protected List<T> list;

        public RegisterList()
        {
            RemoveAll();
        }

        /// <summary>
        /// Get all the registers items.
        /// </summary>
        /// <returns>List of registered items.</returns>
        public virtual List<T> GetAll()
        {
            return list;
        }

        /// <summary>
        /// Removes all of the regitered items.
        /// </summary>
        /// <param name="destroy">Whether or not to destroy the items.</param>
        public virtual void RemoveAll(bool destroy = false)
        {
            list = new List<T>();
        }

        /// <summary>
        /// Registers an item with the list.
        /// </summary>
        /// <param name="item">The item to register.</param>
        public virtual bool Register(T item)
        {
            if (!list.Contains(item))
            {
                list.Add(item);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Unregisters an item from the list.
        /// </summary>
        /// <param name="item">The item to unregister.</param>
        public virtual void Unregister(T item)
        {
            if (list.Contains(item)) list.Remove(item);
        }

        /// <summary>
        /// Adds all registered items to the provided list.
        /// </summary>
        /// <param name="addToList">List to add registered items to.</param>
        public virtual void AddAllToList(ref List<T> addToList)
        {
            if (list.Count > 0) addToList.AddRange(list);
        }

        /// <summary>
        /// Whether or not the manager has any registered entities.
        /// </summary>
        public virtual bool HasRegisteredEntities
        {
            get
            {
                return list.Count != 0;
            }
        }
    }
}
