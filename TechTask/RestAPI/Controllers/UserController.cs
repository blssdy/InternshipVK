using Contracts.BindingModels;
using Contracts.BusinessLogicContracts;
using Contracts.SearchModels;
using Contracts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {

        private readonly IUserLogic _logic;
        public UserController(IUserLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        public async Task<UserViewModel?> Login(string login, string password)
        {
            try
            {
                return await Task.Run(() => _logic.ReadUser(new UserSearchModel { Login = login, Password = password }));
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }
       
        [HttpPost]
        public async Task Register(UserBindingModel model)
        {
            try
            {
                await Task.Run(() => _logic.Create(model));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
       
    }
}
