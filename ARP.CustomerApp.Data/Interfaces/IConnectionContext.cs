using System.Data;

namespace ARP.CustomerApp.Data.Interfaces
{
    public interface IConnectionContext
    {
        IDbConnection Connect();
    }
}