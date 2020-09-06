using System;
using Newtonsoft.Json;

namespace GettinAPILibrary
{
    public class GettinEvent
    {
        [JsonProperty("description")];
        public string Description { get; set; } 

        [JsonProperty("end_time")]
        public DateTime EndTime { get; set; }

        [JsonProperty("start_time")]
        public DateTime StartTime { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("organiser_id")]
        public string OrganiserID { get; set; }

        [JsonProperty("ticketeer_ref")]
        public string TicketeerRef { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("id"), JsonIgnore]
        public string ID { get; set; }
    }
}