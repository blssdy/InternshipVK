using ClientApp.Models;
using Contracts.BindingModels;
using Contracts.ViewModels;
using DataModels.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace ClientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string? ex)
        {
            if (APIClient.User == null) { return Redirect("~/Home/Enter"); }
            if(ex is not null)
            {
                ViewBag.Message = new string(ex);
            }
            return View(APIClient.GetRequest<UserViewModel>($"api/main/getuser?userID={APIClient.User.ID}"));
        }

        [HttpGet]
        public IActionResult Enter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Enter(string login, string password)
        {           
            try
            {
                if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password)) { throw new Exception("Enter login and password"); }

                APIClient.User = APIClient.GetRequest<UserViewModel>($"api/user/login?login={login}&password={password}").Result;
                
                if (APIClient.User == null) { throw new Exception("Incorrect login/password"); }
            }
            catch(Exception ex)
            {
                ViewBag.Message = new string(ex.Message.ToString());
                return View();
            }
           
            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult Users()
        {
            if (APIClient.User == null) { return Redirect("~/Home/Enter"); }
            try
            {
                if (APIClient.GetRequest<bool>($"api/main/checkgroup?login={APIClient.User.Login}").Result == false)
                {
                    throw new Exception("You must have admin priviliges to use this page.");
                }
            }
            catch(Exception ex)
            {                
                return Redirect($"Index?ex={ex.Message.ToString()}");
            }
           
            ViewBag.Users = APIClient.GetRequest<List<UserViewModel>>($"api/main/getactiveuserslist");
            return View(APIClient.GetRequest<List<UserViewModel>>($"api/main/getuserslist"));
        }

        [HttpPost]
        public void Users(int user)
        {
            Task.Run(() => APIClient.PatchRequest("api/main/disableuser", new UserBindingModel { ID = user }));
            
            if(user == APIClient.User.ID)
            {
                APIClient.User = null;
            }

            Response.Redirect("Index");
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Roles = APIClient.GetRequest<List<GroupViewModel>>($"api/main/getgroupslist");
            return View();
        }

        [HttpPost]
        public IActionResult Register(string login, string password, int role)
        {
            try
            {
                if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                {
                    throw new Exception("Enter login and password.");
                }

                Task.Run(() => APIClient.PostRequest("api/user/register", new UserBindingModel
                {
                    Login = login,
                    Password = password,
                    GroupID = role
                }));
            }
            catch(Exception ex)
            {
                ViewBag.Message = new string(ex.Message.ToString());
                return View();
            }
            
            return Redirect("Enter");           
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