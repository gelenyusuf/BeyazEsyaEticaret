
using Project.ENTITIES.Entities;
using X.PagedList;

namespace Project.UI.Models.PageVms
{
    public class ShoppingPageVM
    {
        public IPagedList<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
    }
}
