using DapperCRUD_MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUD_MVC.Services
{
    public interface IProductService
    {
        Task Insert(GelenData data);
        Task Delete(int i);
        Task<List<GelenData>> Show();
    }
    public class ProductService : IProductService
    {
        public async Task Insert(GelenData data)
        {
            HttpClient client = new HttpClient();
            var result = new { Name = data.Name, Quantity = data.Quantity, Price = data.Price };
            var json = JsonConvert.SerializeObject(result);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:44376/Product"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            var response = await client.SendAsync(request).ConfigureAwait(false);
        }

        public async Task Delete(int i)
        {
            HttpClient client = new HttpClient();
            //var result = new { /*ProductId = 8,*/ Name = "denemeeee2", Quantity = 77, Price=5888 };
            var result = new { ProductId = i };
            var json = JsonConvert.SerializeObject(result);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri("https://localhost:44376/Product"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            var response = await client.SendAsync(request).ConfigureAwait(false);
        }

        public async Task<List<GelenData>> Show()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:44376/Product/GetAll");
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
            GelenData gelen = new GelenData();
            var result = JsonConvert.DeserializeObject<List<GelenData>>(responseBody);
            Console.WriteLine(result + "xxxxxxxxxxxxx");
            return result;
        }
    }
}
