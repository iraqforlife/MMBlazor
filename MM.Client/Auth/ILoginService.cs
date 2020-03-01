using System.Threading.Tasks;

namespace MM.Client
{
    public  interface ILoginService
    {
        Task Login(string token);
        Task Logout();
    }
}