using DapperCRUD_MVC.Models;
using DapperCRUD_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUD_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; 
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Ekle(string i, int j, int p)
        {
            if (!string.IsNullOrEmpty(i) && j > 0 && p > 0)
            {
                await _productService.Insert(new GelenData() { Name = i, Quantity = j, Price = p });
            }
            return View();
        }

        public async Task<IActionResult> Sil(int i)
        {
            if (i > 0)
            {
                await _productService.Delete(i);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Goruntule()
        {
            var a = await _productService.Show();
            //ViewBag.Deneme = a;
            // return RedirectToAction("Index",a);
            return Json(a);
        }

        //public async Task<IActionResult> Sil(int i)
        //{
        //    HttpClient client = new HttpClient();
        //    //var result = new { /*ProductId = 8,*/ Name = "denemeeee2", Quantity = 77, Price=5888 };
        //    var result = new { ProductId = i };
        //    var json = JsonConvert.SerializeObject(result);
        //    var request = new HttpRequestMessage
        //    {

        //        Method = HttpMethod.Delete,
        //        RequestUri = new Uri("https://localhost:44376/Product"),
        //        Content = new StringContent(json, Encoding.UTF8, "application/json")
        //    };

        //    var response = await client.SendAsync(request).ConfigureAwait(false);

        //    var resp = await response.Content.ReadAsStringAsync();

        //    Console.WriteLine(response);

        //    return RedirectToAction("IndexAsync");
        //}

        //public async Task<IActionResult> Goruntule()
        //{
        //    HttpClient client = new HttpClient();
        //    HttpResponseMessage response = await client.GetAsync("https://localhost:44376/Product/GetAll");
        //    string responseBody = await response.Content.ReadAsStringAsync();
        //    Console.WriteLine(responseBody);
        //    var result = JsonConvert.DeserializeObject<List<GelenData>>(responseBody);
        //   // result.Where(x => x.Name == "asdasd").FirstOrDefault();
        //    return Json(result);
        //}

        //public async Task<IActionResult> Index()
        //{
        //    HttpClient client = new HttpClient();
        //    //var result = new { /*ProductId = 8,*/ Name = "denemeeee2", Quantity = 77, Price=5888 };
        //    var result = new { Name = i, Quantity = j, Price = p };
        //    var json = JsonConvert.SerializeObject(result);
        //    var request = new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Post,
        //        //RequestUri = new Uri("https://localhost:44392/api/home"),
        //        RequestUri = new Uri("https://localhost:44376/Product"),
        //        Content = new StringContent(json, Encoding.UTF8, "application/json")
        //    };

        //    var response = await client.SendAsync(request).ConfigureAwait(false);

        //    var resp = await response.Content.ReadAsStringAsync();

        //    Console.WriteLine(response);
        //    return View();
        //}
    }
}
