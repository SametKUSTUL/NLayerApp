using Microsoft.AspNetCore.Mvc;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Web.Models;
using NLayer.Web.Service;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.Json;

namespace NLayer.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductApiService _productApiService;


        public HomeController(ILogger<HomeController> logger, ProductApiService productApiService)
        {
            _logger = logger;
            _productApiService = productApiService;
        }

        public async Task<IActionResult> Index()
        {
            
            return View(await _productApiService.GetProductsWithCategoryAsync());
            //https://localhost:7068/api/Products


        }


        /*private CustomResponseDTO<List<ProductDTO>> GetAllProduct()
        {
            *//* string apiUrl = "https://localhost:7068/api/Products";
             string inputJson = string.Empty;
             WebClient client = new WebClient();
             client.Headers["Content-type"] = "application/json";
             client.Encoding = Encoding.UTF8;
             string json = client.DownloadString(apiUrl);

             // return JsonConvert.DeserializeObject<List<ProductDTO>>(json);
             //CustomResponseDTO<List<ProductDTO>>
             var result =JsonSerializer.Deserialize<CustomResponseDTO<List<ProductDTO>>>(json);
             return result;*//*
           




        }*/

       

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}