using System.Net.Http;

namespace GettinAPILibrary
{
    public class GettinEvents : IApiSource<GettinEvent>
    {
        private APIConnector connector;

        public GettinEvents(APIConnector connector)
        {
            this.connector = connector;
        }

        public GettinEvent GetByID(string iD)
        {
            return connector.Call<GettinEvent>(HttpMethod.Get, "/api/event/" + iD);
        }

        public GettinEvent StoreNew(GettinEvent eventToStore)
        {
            return connector.Call<GettinEvent>(HttpMethod.Post, "/api/event/", eventToStore);
        }

        public GettinEvent Update(GettinEvent eventToUpdate)
        {
            return connector.Call<GettinEvent>(HttpMethod.Put, "/api/event/", eventToUpdate);
        }
    }
}