using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace GettinAPILibrary
{
    public class Organisers : IApiSource<Organiser>
    {
        private APIConnector connector;

        public Organisers(APIConnector connector)
        {
            this.connector = connector;
        }

        public Organiser StoreNew(Organiser organiser)
        {
            return connector.Call<Organiser>(HttpMethod.Post, "/api/organiser/", organiser);
        }

        public Organiser Update(Organiser storedOrganiser)
        {
            return connector.Call<Organiser>(HttpMethod.Put, "/api/organiser/", storedOrganiser);
        }

        public Organiser GetByID(string iD)
        {
            return connector.Call<Organiser>(HttpMethod.Get, "/api/organiser/" + iD);
        }
    }
}
