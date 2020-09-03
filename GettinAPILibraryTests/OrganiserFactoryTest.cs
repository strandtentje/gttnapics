using GettinAPILibrary;
using NUnit.Framework;
using System;
namespace GettinAPILibraryTests
{
    [TestFixture()]
    public class OrganiserFactoryTest
    {
        private APIConnector connector = ;
        private OrganiserFactory SUT = new OrganiserFactory(APIConnector.ForCredentialFile("credentials.txt"))

        [Test()]
        public void TestCase()
        {

        }
    }
}
