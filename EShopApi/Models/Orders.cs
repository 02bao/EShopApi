using NuGet.Packaging.Signing;

namespace EShopApi.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrdersItems  = new HashSet<OrdersItems>();
        }

        public int OrderId { get; set; }
        public DateTime?  Date { get; set; }
        public double? Total { get; set; }
        public string Status { get; set; }
        public int CustomerId { get; set; }
        public int SalesPersonId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual SalesPersons SalesPersons { get; set; }
        public virtual ICollection<OrdersItems> OrdersItems { get; set; }
    }
}
