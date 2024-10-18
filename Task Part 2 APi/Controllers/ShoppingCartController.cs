using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_Part_2_APi.Models;
using Task_Part_2_APi.Service;

namespace Task_Part_2_APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {

        private readonly List<ShoppingCart> _shoppingCart;

        public ShoppingCartController()
        {
            _shoppingCart = new List<ShoppingCart>();
        }

        [HttpGet]
        public ActionResult<List<ShoppingCart>> GetAlLCarts()
        {
            return ShoppingCartService.GetCarts();  
        }
        [HttpPost]
        public ActionResult<List<ShoppingCart>> AddProduct([FromBody] ShoppingCart item)
        {
            _shoppingCart.Add(item);
            return Ok();
            //return CreatedAtAction(nameof(AddProduct), new { id = product.Id }, product);
        }
       [HttpPut("{id}")]
        public IActionResult UpdateCart(int id, [FromBody] ShoppingCart item)
        {
            var existingItem = _shoppingCart.Find(i => i.Id == id);
            if (existingItem != null)
            {
                existingItem.Quantity = item.Quantity;
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public ActionResult<List<ShoppingCart>>Delete(int Id)
        {
            var product= ShoppingCartService.Get(Id);
            if (product != null) return NotFound();
            ShoppingCartService.Delete(Id);
            return NoContent();


        }
       /* [HttpGet]
        public ActionResult<List<ShoppingCart>> Details()
        {
            var totalQuantity = _shoppingCart.Sum(i => i.Quantity);
            var totalPrice = _shoppingCart.Sum(i => i.Product.Price * i.Quantity);
            return Ok(new { TotalQuantity = totalQuantity, TotalPrice = totalPrice });

        }*/
    }
}
