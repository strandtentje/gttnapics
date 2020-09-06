using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace GettinAPILibrary
{
    public class Orders
    {
        private APIConnector aPIConnector;

        public Orders(APIConnector aPIConnector)
        {
            this.aPIConnector = aPIConnector;
        }

        public OrderResponse StoreNew(OrderRequest order)
        {
            return aPIConnector.Call<OrderRequest, OrderResponse>(HttpMethod.Post, "/api/order/", order);
        }

        public PublicTicket GetTicketByPublicID(string pid)
        {
            return aPIConnector.Call<PublicTicket>(HttpMethod.Get, "/api/ticket/" + pid);
        }

    }

    public class PublicTicket
    {
        [JsonProperty("claimed")]
        public bool Claimed { get; set; }

        [JsonProperty("currently_claimed")]
        public string CurrentlyClaimed { get; set; }

        [JsonProperty("num_sharelinks")]
        public string NumSharelinks { get; set; }

        [JsonProperty("share_id")]
        public string ShareId { get; set; }
    }


    public class OrderResponse
    {
        [JsonProperty("order_share_id")]
        public string OrderShareId { get; set; }

        [JsonProperty("ticket_public_ids")]
        public List<string> TicketPublicIds { get; set; }
    }



    public class OrderRequestTicket
    {
        [JsonProperty("barcode")]
        public string Barcode { get; set; }

        [JsonProperty("entry_type")]
        public string EntryType { get; set; }

        [JsonProperty("ticket_type")]
        public string TicketType { get; set; }

        [JsonProperty("ticketeer_ref")]
        public string TicketeerRef { get; set; }
    }

    public class OrderRequest
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("event_id")]
        public string EventId { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("send_email")]
        public string SendEmail { get; set; }

        [JsonProperty("ticketeer_ref")]
        public string TicketeerRef { get; set; }

        [JsonProperty("tickets")]
        public List<OrderRequestTicket> Tickets { get; set; }
    }
}