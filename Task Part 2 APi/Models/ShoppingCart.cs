using System.ComponentModel.DataAnnotations.Schema;
using Task_Part_2_APi.Models;
using Task_Part_2_APi.Service;
namespace Task_Part_2_APi.Models
    
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public Products Product { get; set; }
        public int Quantity { get; set; }

    }
}
