using System;
using JsonNetConverters.UnixTime;
using Newtonsoft.Json;

namespace GitHubHook.Models
{
    public class PushRepository : Repository
    {
        public new PushRepositoryOwner Owner { get; set; }
        [JsonConverter(typeof(UnixTimeConverter))]
        public new DateTime CreatedAt { get; set; }
        [JsonConverter(typeof(UnixTimeConverter))]
        public new DateTime PushedAt { get; set; }
        public int Stargazers { get; set; }
        public string MasterBranch { get; set; }
    }
}
