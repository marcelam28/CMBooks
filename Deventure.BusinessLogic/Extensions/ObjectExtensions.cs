using Newtonsoft.Json;

namespace Deventure.BusinessLogic.Extensions
{
    public static class ObjectExtensions
    {
        public static T CloneObject<T>(this T source) where T : class
        {
            var serialized = JsonConvert.SerializeObject(source);
            return JsonConvert.DeserializeObject<T>(serialized);
        }
    }
}
