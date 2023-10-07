using Assesment_Agile_NET_MVC.Utils;
using Dapper;

namespace Assesment_Agile_NET_MVC.Models
{
	public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

	public static class CategoryRepository
	{
		public static IEnumerable<Category> GetAll()
		{
			using (var connection = Database.GetConnection())
			{
				try
				{
					return connection.Query<Category>("SELECT idCategory as Id, name FROM category").
						OrderBy(c => c.Id).ToList();
                }
				catch (Exception ex)
				{
                    return Enumerable.Empty<Category>();
                }
            }
		}
	}
}
