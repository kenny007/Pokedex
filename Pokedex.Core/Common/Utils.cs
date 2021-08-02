using Newtonsoft.Json;
using System;

namespace Pokedex.Core.Common {
    public static class Utils
    {
        public static bool TryDeserializeObject<T>(this string obj, out T result)
        {
            try
            {
                result = JsonConvert.DeserializeObject<T>(obj);
                return true;
            }
            catch (Exception)
            {
                result = default;
                return false;
            }

        }

        public static string FormatString(this string value)
        {
            return value
                .Replace("\n", " ")
                .Replace("\r", " ")
                .Replace("\f", " ");
        }
    }
}
