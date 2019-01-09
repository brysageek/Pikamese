using SQLite;
namespace Pikamese.Models
{
    public class Connection
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string HostName { get; set; }
        public int Port { get; set; }
        public string VirtualHost { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public Connection()
        {
            //Id = 0;
            Name = "";
            HostName = "";
            Port = 5671;
            VirtualHost = "/";
            UserName = "";
            Password = "";
        }
    }
}