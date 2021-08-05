using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LostHarbor.Core.Extensions
{
    public static class EventHandlerExtensions
    {
        public static bool Raise(this EventHandler eventHandler, object sender, EventArgs e)
        {
            if (eventHandler != null)
            {
                eventHandler.Invoke(sender, e);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Raise<T>(this EventHandler<T> eventHandler, object sender, T e) where T : EventArgs
        {
            if (eventHandler != null)
            {
                eventHandler.Invoke(sender, e);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
