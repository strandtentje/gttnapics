using Newtonsoft.Json;

namespace GettinAPILibrary
{
    public class Organiser
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("logo")]
        public string Logo { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("ticketeer_ref")]
        public string TicketeerRef { get; set; }
        [JsonProperty("website")]
        public string Website { get; set; }
        [JsonProperty("id"), JsonIgnore()]
        public string ID { get; set; }
    }
}