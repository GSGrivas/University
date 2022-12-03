using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsStore.Data;
using SportsStore.Models;
using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Pages
{
    public class OrdersModel : PageModel
    {
        private readonly IRepositoryWrapper _repository;
        public OrdersModel(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public List<Order> ShippedOrders = new List<Order>();
        public List<Order> UnshippedOrders = new List<Order>();

        public void OnGet(string returnUrl)
        {
            populateProperties(_repository.Order.GetOrders());
        }

        public IActionResult OnPost(int orderID, string returnUrl)
        {
            var order = _repository.Order.GetById(orderID);
            order.Shipped = true;
            _repository.Order.Update(order);
            _repository.Order.Save();
            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public void populateProperties(IQueryable<Order> Orders)
        {          
            foreach (var order in Orders)
            {
                if (order.Shipped)
                {
                    ShippedOrders.Add(order);
                }
                else
                {
                    UnshippedOrders.Add(order);
                }      
            }
        }
    }
}
