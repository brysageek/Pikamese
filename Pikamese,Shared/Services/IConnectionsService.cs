using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Pikamese.Models;

namespace Pikamese.Services
{
    public interface IConnectionService
    {
        Task<Connection> GetConnectionById(int id);
        Task<List<Connection>> GetConnections();
        Task<int> SaveConnection(Connection connection);
        Task<int> DeleteConnection(Connection connection);
    }
}
    