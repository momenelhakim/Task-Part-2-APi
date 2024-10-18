using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_Part_2_APi.Models;
using Task_Part_2_APi.Service;

namespace Task_Part_2_APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Category>> GetAlL() => CategoryService.GetCategories();
    }
}
