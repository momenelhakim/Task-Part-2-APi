using Newtonsoft.Json;
using Task_Part_2_APi.Models;

namespace Task_Part_2_APi.Service
{
    public class CategoryService
    {
        private readonly HttpClient _httpClient;
        private static List<Category> CategoriesList;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Category>> GetData()
        {
            var response = await _httpClient.GetStringAsync("https://fakestoreapi.com/products/categories");
            return JsonConvert.DeserializeObject<List<Category>>(response).ToList();
        }

        public async Task ProductsListAsync()
        {
            CategoriesList = await GetData();
        }

        public static List<Category> GetCategories() => CategoriesList;
    }
}
