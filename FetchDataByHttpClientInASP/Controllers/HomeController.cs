using FetchDataByHttpClientInASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;


namespace FetchDataByHttpClientInASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }
        //[HttpGet]
        public async Task<IActionResult> Index()
        {
            string apiUrl = "https://jsonplaceholder.typicode.com/todos/1";
            var response = await _httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var todoItem = JsonConvert.DeserializeObject<TodoItem>(jsonData);
                return View(todoItem);
            }
            return View(null);
        }
        [HttpGet]
        public async Task<IActionResult> LoadUsers() 
        {
            string apiUrl = "https://jsonplaceholder.typicode.com";
            var response = await _httpClient.GetAsync($"{apiUrl}/users");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<List<User>>(jsonData);
                return Json(users);
                //var users = JsonConvert.DeserializeObject<List<User>>(jsonData);
                //return Json(users); // Return data as JSON
            }
            return StatusCode(500, "Error fetching data");
            //return View(null);
        }

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
