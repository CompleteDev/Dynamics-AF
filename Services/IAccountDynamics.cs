using DynamicsInfo.Models;
using System.Threading.Tasks;

namespace DynamicsInfo.Services
{
    public interface IAccountDynamics
    {
        string GetAccessToken(DynamicSettingsMdl dynamicSettings);
        Task<string> GetAccountsFromDynamics(string methodUri);
    }
}