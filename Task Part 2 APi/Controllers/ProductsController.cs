using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;
using Task_Part_2_APi.Service;
using Task_Part_2_APi.Models;

namespace Task_Part_2_APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {


     private readonly ProductService _productService;   
            [HttpGet]
            public ActionResult<List<Products>> GetAlL() => _productService.GetProducts();


            [HttpGet("{id}")]
            public ActionResult<Products> Get(int id)
            {
                var product = _productService.Get(id);
                if (product == null) return NotFound();
                return Ok(product);
            }
        }
    }

 