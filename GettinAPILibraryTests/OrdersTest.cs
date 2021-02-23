using GettinAPILibrary;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace GettinAPILibraryTests
{
    [TestFixture()]
    public class OrdersTest
    {
        private static readonly APIConnector aPIConnector = APIConnector.ForCredentialFile("credentials.txt");
        private Orders SUT = new Orders(aPIConnector);
        private Organisers orgs = new Organisers(aPIConnector);
        private GettinEvents events = new GettinEvents(aPIConnector);

        [Test()]
        public void SeeIfOrdersAndTicketsWork()
        {
            var org = orgs.StoreNew(OrganisersTest.MakeOrganiser());
            var evnt = events.StoreNew(EventsTest.MakeEvent(org));
            var tix = new List<OrderRequestTicket>(new OrderRequestTicket[] {
                new OrderRequestTicket() {
                    Barcode = "0xDEADBEEF",
                    EntryType = "Op schoot bij ome willem",
                    TicketType = "QR",
                    TicketeerRef = "Ticket-" + Guid.NewGuid().ToString(),
                }
            });
            var order = new OrderRequest()
            {
                Email = "customer@example.com",
                EventId = evnt.TicketeerRef,
                FirstName = "Flabbert",
                LastName = "Ruigfluit",
                SendEmail = "false",
                TicketeerRef = "Order-" + Guid.NewGuid().ToString(),
                Tickets = tix
            };
            var resp = SUT.StoreNew(order);
            Assert.True(resp.OrderShareId.Length > 0);
            Assert.True(resp.TicketPublicIds.Count > 0);

            var ticket = SUT.GetTicketByPublicID(resp.TicketPublicIds[0]);
            // to whomever it may concern: i'm not sure how the /ticket/ response
            // works. please discuss this out with the actual API developer and
            // do a pull request or something when you've figured it out.
        }
    }
}