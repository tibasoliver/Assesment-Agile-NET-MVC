using MySql.Data.MySqlClient;

namespace Assesment_Agile_NET_MVC.Utils
{
    public static class Database
    {
        public static MySqlConnection GetConnection()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");
            return new MySqlConnection(connectionString);
        }
    }
}
