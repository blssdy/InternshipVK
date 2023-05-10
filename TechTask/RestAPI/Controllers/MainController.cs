using Contracts.BindingModels;
using Contracts.BusinessLogicContracts;
using Contracts.SearchModels;
using Contracts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RestAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : Controller
    {
        private readonly IUserLogic _user;
        private readonly IAuxilaryLogic _auxilary;

        public MainController(IUserLogic user, IAuxilaryLogic auxilary)
        {
            _user = user;
            _auxilary = auxilary;
        }

        [HttpGet]
        public async Task<List<UserViewModel>?> GetUsersList()
        {
            try
            {
                return await Task.Run(() => _user.ReadUsers());
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<List<UserViewModel>?> GetActiveUsersList()
        {
            try
            {
                return await Task.Run(() => _user.ReadActiveUsers());
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<UserViewModel?> GetUser(int userID)
        {
            try
            {
                return await Task.Run(() =>_user.ReadUser(new UserSearchModel
                {
                    ID = userID,
                }));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<List<GroupViewModel>?> GetGroupsList()
        {
            try
            {
                return await Task.Run(() => _auxilary.GetGroupsList());
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<bool> CheckGroup(string login)
        {
            try
            {
                return await Task.Run(() => _user.CheckGroup(new UserSearchModel { Login = login }));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPatch]
        public async Task<bool> DisableUser(UserBindingModel model)
        {
            try
            {

                return await Task.Run(() => _user.Disable(new UserBindingModel { ID = model.ID }));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
