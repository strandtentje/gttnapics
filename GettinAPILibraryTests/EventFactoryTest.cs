using System;
using GettinAPILibrary;
using NUnit.Framework;

namespace GettinAPILibraryTests
{
    [TestFixture()]
    public class EventFactoryTest
    {
        private static readonly APIConnector connector = APIConnector.ForCredentialFile("credentials.txt");
        private Organisers oFactory = new Organisers(connector);
        private GettinEvents SUT = new GettinEvents(connector);

        [Test()]
        public void CheckPost()
        {
            var organiser = oFactory.StoreNew(OrganiserFactoryTest.MakeOrganiser());
            GettinEvent eventToStore = MakeEvent(organiser);
            var storedEvent = SUT.StoreNew(eventToStore);
            Assert.Greater(storedEvent.ID.Length, 0);
            Assert.True(storedEvent.Name == eventToStore.ID);
            // we could test all the properties here but if we're getting an ID,
            // we ASSUME the tests on the actual api cover the completeness
            // of the rest
        }

        [Test()]
        public void CheckUpdate()
        {
            var organiser = oFactory.StoreNew(OrganiserFactoryTest.MakeOrganiser());
            GettinEvent eventToStore = MakeEvent(organiser);
            var storedEvent = SUT.StoreNew(eventToStore);
            storedEvent.Description = "Take me back to wonderland";
            var updatedEvent = SUT.Update(storedEvent);
            Assert.True(updatedEvent.Description == storedEvent.Description);
        }

        public void CheckGet()
        {
            var organiser = oFactory.StoreNew(OrganiserFactoryTest.MakeOrganiser());
            GettinEvent eventToStore = MakeEvent(organiser);
            var storedEvent = SUT.StoreNew(eventToStore);

            var gottenEvent = SUT.GetByID(storedEvent.ID);
            Assert.Greater(gottenEvent.ID.Length, 0);
            Assert.True(gottenEvent.Name == eventToStore.ID);
            // same test for brevity here.
        }

        private static GettinEvent MakeEvent(Organiser organiser)
        {
            return new GettinEvent()
            {
                Description = "A fancy event, show up in your nicest underpants.",
                EndTime = DateTime.Now.AddDays(30),
                StartTime = DateTime.Now.AddDays(29),
                Location = "Bjorp Grog hoofdkantoor",
                Logo = "https://gettin.nl/wp-content/uploads/2020/04/Gettin-website-logo.png",
                Name = "Billen",
                OrganiserID = organiser.ID,
                TicketeerRef = "Organiser-" + Guid.NewGuid().ToString(),
                Website = "dorpinator.nl"
            };
        }
    }
}
