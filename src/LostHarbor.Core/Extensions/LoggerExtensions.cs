using System.Text.Json;

namespace LostHarbor.Core.Extensions
{
    public static class LoggerExtensions
    {
        public static string ToJsonLog(this object @this)
        {
            return JsonSerializer.Serialize(@this, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
