using System.Collections.Generic;

namespace CoffeeMaster.Models
{
    public class OrderViewModel
    {
        public IEnumerable<Product> Product { get; set; }
        public IEnumerable<OrderManager> OrderManager { get; set; }
    }
}
