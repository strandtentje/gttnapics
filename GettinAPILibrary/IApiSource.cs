namespace GettinAPILibrary
{
    public interface IApiSource<T>
    {
        T GetByID(string iD);
        T StoreNew(T organiser);
        T Update(T storedOrganiser);
    }
}