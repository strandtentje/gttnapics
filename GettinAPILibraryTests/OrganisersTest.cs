using GettinAPILibrary;
using NUnit.Framework;
using System;
namespace GettinAPILibraryTests
{
    [TestFixture()]
    public class OrganiserFactoryTest
    {
        private Organisers SUT = new Organisers(APIConnector.ForCredentialFile("credentials.txt"));

        [Test()]
        public void CheckPost()
        {
            Organiser newOrganiser = MakeOrganiser();
            var storedOrganiser = SUT.StoreNew(newOrganiser);
            Assert.Greater(storedOrganiser.ID.Length, -1);
            Assert.True(storedOrganiser.Email == newOrganiser.Email);
            Assert.True(storedOrganiser.Logo == newOrganiser.Logo);
            Assert.True(storedOrganiser.Name == newOrganiser.Name);
            Assert.True(storedOrganiser.Phone == newOrganiser.Phone);
            Assert.True(storedOrganiser.TicketeerRef == newOrganiser.TicketeerRef);
            Assert.True(storedOrganiser.Website == newOrganiser.Website);
        }

        public static Organiser MakeOrganiser()
        {
            return new Organiser()
            {
                Email = "test@example.com",
                Logo = "https://gettin.nl/wp-content/uploads/2020/04/Gettin-website-logo.png",
                Name = "Test van Exampelaar",
                Phone = "090642069",
                TicketeerRef = "Organiser-" + Guid.NewGuid().ToString(),
                Website = "http://www.example.com/"
            };
        }

        [Test()]
        public void CheckPut()
        {
            var newOrganiser = new Organiser()
            {
                Email = "test@example.com",
                Logo = "https://gettin.nl/wp-content/uploads/2020/04/Gettin-website-logo.png",
                Name = "Test van Exampelaar",
                Phone = "090642069",
                TicketeerRef = "Organiser-" + Guid.NewGuid().ToString(),
                Website = "http://www.example.com/"
            };
            var organiserToChange = SUT.StoreNew(newOrganiser);
            organiserToChange.Email = "othertest@example.com";
            var updatedOrganiser = SUT.Update(organiserToChange);
            Assert.True(organiserToChange.Email == updatedOrganiser.Email);
        }

        [Test()]
        public void CheckGet()
        {
            var newOrganiser = new Organiser()
            {
                Email = "test@example.com",
                Logo = "https://gettin.nl/wp-content/uploads/2020/04/Gettin-website-logo.png",
                Name = "Test van Exampelaar",
                Phone = "+3190642069",
                TicketeerRef = "Organiser-" + Guid.NewGuid().ToString(),
                Website = "example.com"
            };
            var organiserToFind = SUT.StoreNew(newOrganiser);
            var foundOrganiser = SUT.GetByID(organiserToFind.ID);

            Assert.True(organiserToFind.ID == foundOrganiser.ID);
            Assert.True(organiserToFind.Email == foundOrganiser.Email);
            Assert.True(organiserToFind.Logo == foundOrganiser.Logo);
            Assert.True(organiserToFind.Name == foundOrganiser.Name);
            Assert.True(organiserToFind.Phone == foundOrganiser.Phone);
            Assert.True(organiserToFind.TicketeerRef == foundOrganiser.TicketeerRef);
            Assert.True(organiserToFind.Website == foundOrganiser.Website);
        }
    }
}
