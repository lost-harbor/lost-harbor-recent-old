namespace LostHarbor.Core.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsNotNull(this object source)
        {
            return source != null;
        }

        public static bool IsNull(this object source)
        {
            return source == null;
        }
    }
}
