using System;
using System.Collections.Generic;

namespace OGameEmptyPlanetFinder.HTTP.JsonEntities
{
    namespace GameAccount
    {
        public class Server
        {
            public string language { get; set; }
            public int number { get; set; }
        }

        public class Detail
        {
            public string type { get; set; }
            public string title { get; set; }
            public string value { get; set; }
        }

        public class Sitting
        {
            public bool shared { get; set; }
            public object endTime { get; set; }
            public object cooldownTime { get; set; }
        }

        public class Trading
        {
            public bool trading { get; set; }
            public object cooldownTime { get; set; }
        }

        public class GameAccountEntity
        {
            public Server server { get; set; }
            public int id { get; set; }
            public int gameAccountId { get; set; }
            public string name { get; set; }
            public DateTime lastPlayed { get; set; }
            public DateTime lastLogin { get; set; }
            public bool blocked { get; set; }
            public object bannedUntil { get; set; }
            public object bannedReason { get; set; }
            public List<Detail> details { get; set; }
            public Sitting sitting { get; set; }
            public Trading trading { get; set; }
        }
    }
}
