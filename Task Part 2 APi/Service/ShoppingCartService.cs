using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using Task_Part_2_APi.Models;
using Task_Part_2_APi.Service;
namespace Task_Part_2_APi.Service
{
    public class ShoppingCartService
    {

        /* static List<ShoppingCart> GetCart()
         {
             WebClient client = new WebClient();
             string CartData = client.DownloadString("https://fakestoreapi.com/carts");
             var list = JsonConvert.DeserializeObject<List<ShoppingCart>>(CartData);

             return list.ToList();
         }
         static List<Products> GetData()
         {
             WebClient client = new WebClient();
             string PageData = client.DownloadString("https://fakestoreapi.com/products");
             var list = JsonConvert.DeserializeObject<List<Products>>(PageData);

             return list.ToList();
         }
         public  static List<ShoppingCart> ShoppingCartsList { get; }
         public static List <Products> productList { get; }

          static ShoppingCartService() {

             ShoppingCartsList = GetCart();
             productList = GetData();
             ShoppingCartsList.ToList();


         }

         public static List<ShoppingCart> GetCarts() {

             return ShoppingCartsList;
         }*/
        private readonly HttpClient _httpClient;
        private static List<ShoppingCart> ShoppingCartsList ;

        public ShoppingCartService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ShoppingCart>> GetData()
        {
            var response = await _httpClient.GetStringAsync("https://fakestoreapi.com/carts");
            return JsonConvert.DeserializeObject<List<ShoppingCart>>(response);
        }

        public async Task ShoppingCartAsync()
        {
            ShoppingCartsList = await GetData();
        }
        public static List<ShoppingCart> GetCarts() => ShoppingCartsList;
      /*  public static void Add(Products product)
        {
            var rat = ProductService.GetProducts();
            ShoppingCartsList.Add(product);
        }
        public static void Update(Products product)
        {
            var index = ShoppingCartsList.FindIndex(p => p.Id == product.Id);
            if (index == -1)
                return;
            ShoppingCartsList[index] = product;

        }
      */
        public static ShoppingCart Get(int id)
        {
            return ShoppingCartsList.FirstOrDefault(p => p.Id == id);
        }

        public static void Delete(int id)
        {
            var product = Get(id);
            if (product != null) return;
            ShoppingCartsList.Remove(product);
        }




    }
}
