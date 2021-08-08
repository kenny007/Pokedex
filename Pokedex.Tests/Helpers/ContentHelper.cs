using Newtonsoft.Json;

namespace Pokedex.Tests.Helpers
{
    public static class ContentHelper
    {
        public static T GetRequestResult<T>(string content)
        {
            var settings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            return JsonConvert.DeserializeObject<T>(content, settings);
        }
    }
}
