using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebUserRegistration.Models;

namespace WebUserRegistration.Controllers
{
    public class UserController : Controller
    {
        IConfiguration configuration;
        public UserController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        static HttpClient _client = new HttpClient();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {            
            return View();
        }

        private async Task<List<User>> GetUsers()
        {
            try
            {
                List<User> users = new List<User>();
                HttpRequestMessage getMessage = new HttpRequestMessage(HttpMethod.Get, configuration.GetValue<string>("UserApi"));
                var getResponse = await _client.SendAsync(getMessage);
                var resultString = await getResponse.Content.ReadAsStringAsync();
                if (CheckStatusCode(getResponse))
                {
                    users = JsonConvert.DeserializeObject<List<User>>(resultString);                  
                }
                else
                {
                    //logger.Info($"Get Status error response {getResponse}.");
                }

                return users;
            }
            catch (Exception ex)
            {
                return null;
                //logger.Error(ex, $"{Name} has GetStatus error.");
            }
        }

        private async Task<bool> SaveUser(User user)
        {
            try
            {
                HttpRequestMessage postMessage = new HttpRequestMessage(HttpMethod.Post, configuration.GetValue<string>("UserApi"));
                var reqString = JsonConvert.SerializeObject(user);
                postMessage.Content = new StringContent(reqString);
                postMessage.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var response = await _client.SendAsync(postMessage);

                if (CheckStatusCode(response))
                {
                    return true;
                }
                else
                {
                    //logger.Info($"Get Status error response {getResponse}.");
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
                //logger.Error(ex, $"{Name} has GetStatus error.");
            }
        }

        public async Task<IActionResult> List()
        {
            var _models = await GetUsers();
            //string data = Newtonsoft.Json.JsonConvert.SerializeObject(_models).Trim();
            return View(_models);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
    [Bind("Name,Email,Gender,RegisteredDate,Day1,Day2,Day3,AddationalRequest")] UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                { 
                    Name = viewModel.Name,
                    Email = viewModel.Email,
                    Gender = viewModel.Gender,
                     AddationalRequest = viewModel.AddationalRequest,
                     RegisteredDate = viewModel.RegisteredDate.ToString("dd/MM/yyyy")
                };

                user.EventDays = viewModel.Day1 ? "Day 1" : string.Empty;
                user.EventDays += viewModel.Day2 ? ", Day 2" : string.Empty;
                user.EventDays += viewModel.Day3 ? ", Day 3" : string.Empty;

                await SaveUser(user);
            }

            return RedirectToAction("List");
        }

        private bool CheckStatusCode(HttpResponseMessage message)
        {
            var _result = message.EnsureSuccessStatusCode();
            return _result.IsSuccessStatusCode;
        }
    }

    public class ValuesController : Controller
    {
        private readonly string _myConfiguration;

        public ValuesController(string myConfiguration)
        {
            _myConfiguration = myConfiguration;
        }
    }
}