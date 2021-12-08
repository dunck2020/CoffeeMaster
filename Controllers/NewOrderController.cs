using CoffeeMaster.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeMaster.Controllers
{
    public class NewOrderController : Controller
    {
        private readonly CoffeeMasterContext _context;

        public NewOrderController(CoffeeMasterContext context)
        {
            _context = context;
        }

        // GET: Product
        public IActionResult Index()
        {
            OrderViewModel orderViewModel = new OrderViewModel();
            orderViewModel.Product = _context.Products.ToList();
            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult Order(int id)
        {
            
            //List<Product> listOfProducts = _context.Products.ToList();
            //var product = listOfProducts.FirstOrDefault(p => p.Id == id);

            OrderViewModel orderViewModel = new OrderViewModel();
            orderViewModel.Product = _context.Products.ToList();
            Product product = orderViewModel.Product.FirstOrDefault(p => p.Id == id);

            OrderManager orderManager = new OrderManager();
            orderManager.OrderedProduct.Add(product);
            orderViewModel.OrderManager = (IEnumerable<OrderManager>)orderManager.OrderedProduct.ToList();

            return View(orderViewModel);
        }
    }
}
