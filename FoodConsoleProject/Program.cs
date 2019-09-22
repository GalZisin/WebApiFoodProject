using FoodProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FoodConsoleProject
{
    class Program
    {
        
        private const string URL = "http://localhost:53926/api/Food";

       

        //static async Task<Uri> CreateFoodAsync(Food f, HttpClient client)
        //{
        //    HttpResponseMessage response = await client.PostAsJsonAsync(
        //        "api/Food", f);
        //    response.EnsureSuccessStatusCode();
        //    return response.Headers.Location;
        //}

        static void Main(string[] args)
        {
            // POST REQUEST
            HttpClient client_post = new HttpClient();

            client_post.BaseAddress = new Uri(URL);
            client_post.DefaultRequestHeaders.Accept.Clear();
            client_post.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            Food food = new Food
            {
                Name = "Tomato sup",
                Calories = 500,
                Grade = 5,
                Ingridients = "tomatos, onion, garlic and Hot pepper",

            };

            var response_post = client_post.PostAsJsonAsync(
                 URL, food).Result;

            Console.WriteLine(response_post);


            // GET REQUEST
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync("").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var dataObjects = response.Content.ReadAsAsync<IEnumerable<Food>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                foreach (var f in dataObjects)
                {
                    Console.Write("{0} ", f.ID);
                    Console.Write("{0} ", f.Name);
                    Console.Write("{0} ", f.Calories);
                    Console.Write("{0} ", f.Grade);
                    Console.Write("{0} ", f.Ingridients);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            Console.ReadLine();
        }
    }
}
