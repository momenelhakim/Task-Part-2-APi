using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Runtime;
using System.Text.Json.Serialization;
using Task_Part_2_APi.Controllers;
using static System.Net.WebRequestMethods;
using Task_Part_2_APi.Models;
using System.Reflection;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

namespace Task_Part_2_APi.Service
{
    public class ProductService
    {
        /* static List<Products> GetData()
         {
             WebClient client = new WebClient();
             string PageData = client.DownloadString("https://fakestoreapi.com/products");
             var list = JsonConvert.DeserializeObject<List<Products>>(PageData).ToList();

             return list;
         }
          */
       
        private readonly HttpClient _httpClient;



        public List<Products> productsList;

        public ProductService(HttpClient httpClient)
        {

            _httpClient = httpClient;


        }
        public async Task<List<Products>> GetData()
        {
            var response = await _httpClient.GetStringAsync("https://fakestoreapi.com/products");
            var rat = JsonConvert.DeserializeObject<List<Products>>(response);
            return rat.ToList();
        }

        public async Task ProductsListAsync()
        {

            productsList = await GetData();
        }



            public List<Products> GetProducts() => productsList;

            /*
            private readonly HttpClient _httpClient;
            private static List<Products> productsList = new List<Products>();

            public ProductService(HttpClient httpClient)
            {
                _httpClient = httpClient;
            }

            public async Task<List<Products>> GetData()
            {
                try
                {
                    var response = await _httpClient.GetStringAsync("https://fakestoreapi.com/products");
                    var productList = JsonConvert.DeserializeObject<List<Products>>(response);
                    return productList ?? new List<Products>(); // Return empty list if null
                }
                catch (Exception ex)
                {
                    // Handle exceptions (log it, rethrow it, etc.)
                    Console.WriteLine($"Error fetching data: {ex.Message}");
                    return new List<Products>(); // Return empty list on error
                }
            }

            public async Task ProductsListAsync()
            {
                productsList = await GetData();
            }

            public static List<Products> GetProducts() => productsList;
            */
            public Products Get(int id)
            {
                return productsList.FirstOrDefault(p => p.Id == id);
            }

            public void Add(Products product)
            {
                productsList.Add(product);
            }
            public void Update(Products product)
            {
                var index = productsList.FindIndex(p => p.Id == product.Id);
                if (index == -1)
                    return;
                productsList[index] = product;

            }
            public void Delete(int id)
            {
                var product = Get(id);
                if (product != null) return;
                productsList.Remove(product);
            }

        }

    }





