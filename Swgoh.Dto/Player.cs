using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Swgoh.Dto
{
    public class Player
    {
        [JsonProperty("allyCode")]
        public int AllyCode { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        //[JsonProperty("titles")]
        //public Titles Titles { get; set; }

        [JsonProperty("guildRefId")]
        public string GuildRefId { get; set; }

        [JsonProperty("guildName")]
        public string GuildName { get; set; }

        [JsonProperty("guildBannerColor")]
        public string GuildBannerColor { get; set; }

        [JsonProperty("guildBannerLogo")]
        public string GuildBannerLogo { get; set; }

        [JsonProperty("guildTypeId")]
        public string GuildTypeId { get; set; }

        //[JsonProperty("stats")]
        //public IList<Stat> Stats { get; set; }

        //[JsonProperty("roster")]
        //public IList<Roster> Roster { get; set; }

        //[JsonProperty("arena")]
        //public Arena Arena { get; set; }

        [JsonProperty("updated")]
        public long Updated { get; set; }
    }
}
