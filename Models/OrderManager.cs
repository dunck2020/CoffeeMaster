using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeMaster.Models
{
    public class OrderManager
    {
        [Key]
        public int Id { get; set; }

        public List<Product> OrderedProduct { get; set; }

        // Foreign Key
        public int CustomerId { get; set; }

        // Navigation property
        public Customer Customer { get; set; }
        public bool IsPaid { get; set; }
        public bool IsServed { get; set; }


        private decimal _grandTotal;
        public decimal GrandTotal
        {
            get
            {  
                _grandTotal = 0;
                foreach (var item in OrderedProduct)
                {
                    _grandTotal += item.Price;
                };
                return _grandTotal;
            }
        }

        private int _rewardValue;
        public int RewardValue
        {        
            get 
            {
                _rewardValue = (int)Math.Ceiling(GrandTotal); 
                return _rewardValue;
            }
        }
        

    }
}