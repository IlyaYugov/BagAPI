using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using YandexAPIWorker.Emun;

namespace YandexAPIWorker
{
    internal class HttpRequestBuilder<TMetod> where TMetod : class
    {
        private TimeSpan _timeout = new TimeSpan(0, 3, 0);
        private readonly StringBuilder _builder;

        internal HttpRequestBuilder(MethodType methodType)
        {
            _builder = new StringBuilder(ApiOptions.Url);
            _builder.Append(ApiOptions.Methods[methodType]);
        }

        internal void UrlBuilderForParams(Dictionary<string,string> parameters)
        {
            foreach (var parameter in parameters)
            {
                UrlBuilder(parameter.Key, parameter.Value);
            }
        }

        internal void UrlBuilder(string key, string value)
        {
            if(value == null)
                return;

            _builder.Append($"&{key}={value}");
        }

        internal async Task<TMetod> SendAsync()
        {
            var client = new HttpClient {Timeout = _timeout,MaxResponseContentBufferSize = 21474836};

            var streamTask = client.GetStreamAsync(_builder.ToString());

            var serializer = new DataContractJsonSerializer(typeof(TMetod),
                new DataContractJsonSerializerSettings
                {
                    DateTimeFormat = new DateTimeFormat(ApiOptions.ResponseDateFormat)
                });

            return serializer.ReadObject(await streamTask) as TMetod;
        }
    }
}
