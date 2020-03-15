namespace CountyRP.WebSite.Services.Interfaces
{
    public interface IPlayerAuthorizationAdapter
    {
        void TryAuthorize(string login, string password);
    }
}
