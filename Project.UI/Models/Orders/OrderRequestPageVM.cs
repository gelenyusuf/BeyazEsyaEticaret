using Project.ENTITIES.Entities;
using Project.UI.Models.OuterRequestModels;

namespace Project.UI.Models.Orders
{
    public class OrderRequestPageVM
    {
        public Order Order { get; set; }

        public PaymentRequestModel PaymentRequestModel { get; set; }
    }
}
