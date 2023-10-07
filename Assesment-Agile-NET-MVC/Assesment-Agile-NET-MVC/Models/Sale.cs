using Assesment_Agile_NET_MVC.Utils;
using Dapper;

namespace Assesment_Agile_NET_MVC.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public string Month { get; set; }
        public decimal Amount { get; set; }
    }

    public static class SaleRepository
    {
        private static int MonthNumber(string month)
        {
            return Array.IndexOf(new string[]
            {
                "January", "February", "March", "April", "May", "June",
                "July", "August", "September", "October", "November", "December"
            }, month) + 1;
        }

        public static IEnumerable<Sale> GetAllSalesInYearByBrandId(int brand)
        {
            using (var connection = Database.GetConnection())
            {
                try
                {
                    return connection.Query<Sale>("SELECT idSales as Id, month as Month, amount as Amount FROM sales where idBrand = " + brand.ToString()).
                        OrderBy(s => MonthNumber(s.Month));
                }
                catch (Exception ex)
                {
                    return Enumerable.Empty<Sale>();
                }
            }
        }
    }


}
