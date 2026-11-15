using Project.ENTITIES.Entities;

namespace Project.UI.Areas.Admin.Models.Products.PageVMs
{
    public class CreateProductPageVM
    {
        public List<Category> Categories { get; set; }
        public Product Product { get; set; }

    }
}
