using Contracts.BusinessLogicContracts;
using Contracts.SearchModels;
using Contracts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : Controller
    {
        private readonly IUserLogic _user;

        public MainController(IUserLogic user)
        {
            _user = user;
        }

        [HttpGet]
        public List<UserViewModel>? GetUsersList()
        {
            try
            {
                return _user.ReadUsers();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public UserViewModel? GetUser(int userID,string login)
        {
            try
            {
                return _user.ReadUser(new UserSearchModel
                {
                    ID = userID,
                    Login = login
                });
            }
            catch (Exception ex) 
            {
                throw;
            }
        }
    }
}
