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
                var request = new RestRequest("post");
                request.AddBody(model);
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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            CustomerViewModel customer = new CustomerViewModel();
            var request = new RestRequest($"post/{id}");
            var response = _client.GetAsync(request);
            if (response.Result.IsSuccessStatusCode)
            {
                string data = response.Result.Content;
                customer = JsonConvert.DeserializeObject<CustomerViewModel>(data);
                return View(customer);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(CustomerViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                var request = new RestRequest("put");
                request.AddBody(model);
                var response = _client.PutAsync(request);
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

        //[HttpDelete]
        //public IActionResult Delete(int id)
        //{
        //    var request = new RestRequest($"delete/{id}");
        //    var response = _client.DeleteAsync(request);
        //    if (response.Result.IsSuccessStatusCode)
        //    {
        //        TempData["successMessage"] = response.Result.Content;
        //        RedirectToAction("Index");
        //    }
        //    TempData["errorMessage"] = response.Result.Content;
        //    RedirectToAction("Read");
        //}
    }
}
