using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Pikamese.Models;
using Pikamese.Data;
namespace Pikamese.Services
{
    public class ConnectionService : IConnectionService
    {
        public ConnectionService()
        {
            Database.Default.CreateTableAsync<Connection>().Wait();
        }    

        public Task<Connection> GetConnectionById(int id)
        {
            return Database.Default.Table<Connection>().Where(c=> c.Id == id).FirstOrDefaultAsync();
        }

        public Task<List<Connection>> GetConnections()
        {
            return Database.Default.Table<Connection>().ToListAsync();
        }

        public Task<int> SaveConnection(Connection connection)
        {
            if (connection.Id!=0)
            {
                return Database.Default.UpdateAsync(connection);
            }
            else
            {
                return Database.Default.InsertAsync(connection);
            }

            //return connection.Id != 0 
            //    ? Database.Default.UpdateAsync(connection) 
            //    : Database.Default.InsertAsync(connection);
        }
        public Task<int> DeleteConnection(Connection connection)
        {
            return Database.Default.DeleteAsync(connection);
        }
    }
}
