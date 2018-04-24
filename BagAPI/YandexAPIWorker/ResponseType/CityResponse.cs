using System;
using System.Collections.Generic;
using System.Text;

namespace YandexAPIWorker.ResponseType
{
    public class CityResponse
    {
        public class Codes
        {
            public string yandex_code { get; set; }
        }

        public class Codes2
        {
            public string yandex_code { get; set; }
            public string esr_code { get; set; }
        }

        public class Station
        {
            public string direction { get; set; }
            public Codes2 codes { get; set; }
            public string station_type { get; set; }
            public string title { get; set; }
            //public double longitude { get; set; }
            public string transport_type { get; set; }
            //public double latitude { get; set; }
        }

        public class Settlement
        {
            public string title { get; set; }
            public Codes codes { get; set; }
            public List<Station> stations { get; set; }
        }

        public class Codes3
        {
            public string yandex_code { get; set; }
        }

        public class Region
        {
            public List<Settlement> settlements { get; set; }
            public Codes3 codes { get; set; }
            public string title { get; set; }
        }

        public class Codes4
        {
            public string yandex_code { get; set; }
        }

        public class Country
        {
            public List<Region> regions { get; set; }
            public Codes4 codes { get; set; }
            public string title { get; set; }
        }

        public class Stations
        {
            public List<Country> countries { get; set; }
        }
    }
}
