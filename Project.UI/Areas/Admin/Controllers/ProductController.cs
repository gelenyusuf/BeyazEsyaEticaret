using Microsoft.AspNetCore.Mvc;
using Project.BLL.Manager.Abstracts;
using Project.ENTITIES.Entities;
using Project.UI.Areas.Admin.Models.Products.PageVMs;

namespace Project.UI.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ProductController : Controller
    {
        IProductManager _productManager;
        ICategoryManager _categoryManager;

        public ProductController(ICategoryManager categoryManager, IProductManager productManager)
        {
            _categoryManager = categoryManager;
            _productManager = productManager;
        }

        public IActionResult Index()
        {
            return View(_productManager.GetActives());
        }

        public IActionResult CreateProduct()
        {
            CreateProductPageVM cpVm = new CreateProductPageVM()
            {
                Categories = _categoryManager.GetActives()
            };
            return View(cpVm);
        }


        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
           

            _productManager.Add(product);

            return RedirectToAction("Index");

        }
    }
}
