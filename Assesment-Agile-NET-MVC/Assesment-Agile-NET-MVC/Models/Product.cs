using Assesment_Agile_NET_MVC.Utils;
using Dapper;

namespace Assesment_Agile_NET_MVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public static class ProductRepository
    {
        public static IEnumerable<Product> GetAll()
        {
            using (var connection = Database.GetConnection())
            {
                try
                {
                    return connection.Query<Product>("SELECT idProduct as Id, name FROM product");
                }
                catch (Exception ex)
                {
                    return Enumerable.Empty<Product>();
                }
            }
        }

        public static IEnumerable<Product> GetByCategoryId(int id)
        {
            using (var connection = Database.GetConnection())
            {
                try
                {
                    return connection.Query<Product>("SELECT idProduct as Id, name FROM product "+"where idCategory = " +id.ToString());
                }
                catch (Exception ex)
                {
                    return Enumerable.Empty<Product>();
                }
            }
        }
    }
}
