using Assesment_Agile_NET_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assesment_Agile_NET_MVC.Controllers
{
	public class SalesController : Controller
	{
		public IActionResult Index()
		{
			var categorias = CategoryRepository.GetAll();
			var produtos = ProductRepository.GetAll();
            var brands = BrandRepository.GetAll();

            if (categorias == null || !categorias.Any())
            {
                ViewBag.Categorias = new SelectList(Enumerable.Empty<SelectListItem>());

                ViewBag.Produtos = new SelectList(Enumerable.Empty<SelectListItem>());

                ViewBag.Brands = new SelectList(Enumerable.Empty<SelectListItem>());
            }
			else
			{
                ViewBag.Categorias = new SelectList(categorias, "Id", "Name");

                ViewBag.Produtos = new SelectList(Enumerable.Empty<SelectListItem>());

                ViewBag.Brands = new SelectList(Enumerable.Empty<SelectListItem>());

            }
       
			return View();
		}

        [HttpGet]
        public JsonResult GetProductsByCategory(int id)
        {
            var products = ProductRepository.GetByCategoryId(id).Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToList();

            return Json(products);
        }

        [HttpGet]
        public JsonResult GetBrandsByProduct(int id)
        {
            var brands = BrandRepository.GetByProductId(id).Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToList();

            return Json(brands);
        }


        [HttpGet]
        public JsonResult GetSalesData(int brandId)
        {
            var data = SaleRepository.GetAllSalesInYearByBrandId(brandId);
            return Json(data);
        }
    }
}
