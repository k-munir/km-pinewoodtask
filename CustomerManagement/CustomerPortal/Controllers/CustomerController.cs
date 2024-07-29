using Microsoft.AspNetCore.Mvc;
using RestSharp;
using CustomerPortal.Models;
using Newtonsoft.Json;

namespace CustomerPortal.Controllers
{
    public class CustomerController : Controller
    {
        private readonly string apiBaseUrl = "https://localhost:7081/api/customer/";
        private readonly RestClient _client;

        public CustomerController()
        {
            _client = new RestClient(apiBaseUrl);
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<CustomerViewModel> customers;
            var request = new RestRequest("get");
            var response = _client.GetAsync(request);
            if (!response.Result.IsSuccessStatusCode) return NotFound();
            var data = response.Result.Content;
            customers = JsonConvert.DeserializeObject<List<CustomerViewModel>>(data);
            return View(customers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                var request = new RestRequest(data, Method.Post);
                var response = _client.PostAsync(request);
                if (response.Result.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = response.Result.Content;
                    RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
            }
            return View();
        }
    }
}
