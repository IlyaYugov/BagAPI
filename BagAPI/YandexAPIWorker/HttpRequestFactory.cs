using System;
using System.Collections.Generic;
using System.Text;
using YandexAPIWorker.Emun;
using static YandexAPIWorker.ResponseType.SheduleResponse;
using static YandexAPIWorker.ResponseType.CityResponse;

namespace YandexAPIWorker
{
    public static class HttpRequestFactory
    {
        public static Schedule GetSchedule(string apikey, string from, string to, DateTime? date = null
            , string lang = null, string transport_types = null, string offset = null, string limit = null)
        {
            var dict = new Dictionary<string, string>
            {
                {nameof(apikey), apikey},
                {nameof(from), from },
                {nameof(to), to},
                {nameof(lang), lang},
                {nameof(date), date?.ToString(ApiOptions.ParamDateFormat)}
            };

            var builder = new HttpRequestBuilder<Schedule>(MethodType.Shedule);
            builder.UrlBuilderForParams(dict);
            return builder.SendAsync().Result;
        }

        public static Stations GetCountres(string apikey, string lang = null)
        {
            var dict = new Dictionary<string, string>
            {
                {nameof(apikey), apikey},
                {nameof(lang), lang}
            };

            var builder = new HttpRequestBuilder<Stations>(MethodType.Stations);
            builder.UrlBuilderForParams(dict);
            return builder.SendAsync().Result;
        }
    }
}
