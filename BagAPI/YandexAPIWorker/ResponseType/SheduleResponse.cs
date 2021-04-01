using System;
using System.Collections.Generic;

namespace YandexAPIWorker.ResponseType
{
    /// <summary>
    /// Genetare from http://json2csharp.com/
    /// </summary>
    public class SheduleResponse
    {
        public class Pagination
        {
            public int total { get; set; }
            public int limit { get; set; }
            public int offset { get; set; }
        }

        public class From
        {
            public string code { get; set; }
            public string title { get; set; }
            public string station_type { get; set; }
            public string popular_title { get; set; }
            public string short_title { get; set; }
            public string transport_type { get; set; }
            public string station_type_name { get; set; }
            public string type { get; set; }
        }

        public class Codes
        {
            public string icao { get; set; }
            public string sirena { get; set; }
            public string iata { get; set; }
        }

        public class Carrier
        {
            public int code { get; set; }
            public string contacts { get; set; }
            public string url { get; set; }
            public string logo_svg { get; set; }
            public string title { get; set; }
            public string phone { get; set; }
            public Codes codes { get; set; }
            public string address { get; set; }
            public string logo { get; set; }
            public string email { get; set; }
        }

        public class TransportSubtype
        {
            public object color { get; set; }
            public object code { get; set; }
            public object title { get; set; }
        }

        public class Thread
        {
            /*public string uid { get; set; }
            public string title { get; set; }*/
            public string number { get; set; }
           /* public string short_title { get; set; }
            public string thread_method_link { get; set; }
            public Carrier carrier { get; set; }
            public string transport_type { get; set; }
            public string vehicle { get; set; }
            public TransportSubtype transport_subtype { get; set; }
            public object express_type { get; set; }*/
        }

        public class To
        {
            public string code { get; set; }
            public string title { get; set; }
            public string station_type { get; set; }
            public string popular_title { get; set; }
            public string short_title { get; set; }
            public string transport_type { get; set; }
            public string station_type_name { get; set; }
            public string type { get; set; }
        }

        public class TicketsInfo
        {
            public bool et_marker { get; set; }
            public List<object> places { get; set; }
        }

        public class Segment
        {
            public DateTime arrival { get; set; }

            public From from { get; set; }

            public Thread thread { get; set; }
            //public string departure_platform { get; set; }
            public DateTime departure { get; set; }

            //public string stops { get; set; }
            //public object departure_terminal { get; set; }
            public To to { get; set; }
            //public bool has_transfers { get; set; }
            //public TicketsInfo tickets_info { get; set; }
            //public double duration { get; set; }
            //public object arrival_terminal { get; set; }
            //public string start_date { get; set; }
            //public string arrival_platform { get; set; }
        }

        public class To2
        {
            public string code { get; set; }
            public string type { get; set; }
            public string popular_title { get; set; }
            public string short_title { get; set; }
            public string title { get; set; }
        }

        public class From2
        {
            public string code { get; set; }
            public string type { get; set; }
            public string popular_title { get; set; }
            public string short_title { get; set; }
            public string title { get; set; }
        }

        public class Search
        {
            public string date { get; set; }
            public To2 to { get; set; }
            public From2 from { get; set; }
        }

        public class Schedule
        {
            //public List<object> interval_segments { get; set; }
            public Pagination pagination { get; set; }
            public List<Segment> segments { get; set; }
            //public Search search { get; set; }
        }
    }
}
