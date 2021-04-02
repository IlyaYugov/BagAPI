using System;
using System.Collections.Generic;
using YandexAPIWorker.Emun;
using static YandexAPIWorker.ResponseType.SheduleResponse;
using static YandexAPIWorker.ResponseType.CityResponse;
using System.Threading.Tasks;

namespace YandexAPIWorker
{
    public class HttpRequestFactory
    {
        public async static Task<Schedule> GetSchedule(string from, string to, DateTime? date = null,
            string offset = null, string limit = null, string lang = null, string transport_types = null)
        {
            var dict = new Dictionary<string, string>
            {
                {ApiOptions.ApiKeyString, ApiOptions.ApiKey},
                {nameof(from), from },
                {nameof(to), to},
                {nameof(lang), lang},
                {nameof(date), date?.ToString(ApiOptions.ParamDateFormat)},
                {nameof(offset), offset },
                {nameof(limit), limit },
                {nameof(transport_types), transport_types }
            };

            var builder = new HttpRequestBuilder<Schedule>(MethodType.Shedule);
            builder.UrlBuilderForParams(dict);
            return await builder.SendAsync();
        }

        public async static Task<Stations> GetCountres(string lang = null)
        {
            var dict = new Dictionary<string, string>
            {
                {ApiOptions.ApiKeyString, ApiOptions.ApiKey},
                {nameof(lang), lang}
            };

            var builder = new HttpRequestBuilder<Stations>(MethodType.Stations);
            builder.UrlBuilderForParams(dict);
            return await builder.SendAsync();
        }
    }
}
