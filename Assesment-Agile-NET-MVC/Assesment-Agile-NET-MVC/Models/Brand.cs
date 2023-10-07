using Assesment_Agile_NET_MVC.Utils;
using Dapper;

namespace Assesment_Agile_NET_MVC.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public static class BrandRepository
    {
        public static IEnumerable<Brand> GetAll()
        {
            using (var connection = Database.GetConnection())
            {
                try
                {
                    return connection.Query<Brand>("SELECT idBrand as Id, name FROM brand");
                }
                catch (Exception ex)
                {
                    return Enumerable.Empty<Brand>();
                }
            }
        }

        public static IEnumerable<Product> GetByProductId(int id)
        {
            using (var connection = Database.GetConnection())
            {
                try
                {
                    return connection.Query<Product>("SELECT idBrand as Id, name FROM brand " + "where idProduct = " + id.ToString());
                }
                catch (Exception ex)
                {
                    return Enumerable.Empty<Product>();
                }
            }
        }
    }
}
