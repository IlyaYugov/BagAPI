using System.Collections.Generic;
using YandexAPIWorker.Emun;

namespace YandexAPIWorker
{
    public static class ApiOptions
    {
        internal static Dictionary<MethodType, string> Methods = new Dictionary<MethodType, string>
        {
            {MethodType.Stations,@"/stations_list/?"},
            {MethodType.Shedule,@"/search/?"}
        };
        public const string Url = "https://api.rasp.yandex.net/v3.0";
        public const string ParamDateFormat = "yyyy-MM-dd";
        public const string ResponseDateFormat = "yyyy-MM-ddTHH:mm:sszzz";
    }
}
