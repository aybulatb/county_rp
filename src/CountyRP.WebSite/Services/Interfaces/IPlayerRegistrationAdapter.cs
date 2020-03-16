using System.Threading.Tasks;

namespace CountyRP.WebSite.Services.Interfaces
{
    public interface IPlayerRegistrationAdapter
    {
        Task Register(string login, string password);
    }
}
