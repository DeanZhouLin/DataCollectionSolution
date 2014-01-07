using Newtonsoft.Json;

namespace JsonUtilNS
{
    public static class JsonUtil
    {
        public static string ConvertToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T ConvertToObject<T>(string strJson)
        {
            return JsonConvert.DeserializeObject<T>(strJson);
        }
    }
}
