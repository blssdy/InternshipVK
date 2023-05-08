using Contracts.BindingModels;
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
        private readonly IAuxilaryLogic _auxilary;

        public MainController(IUserLogic user, IAuxilaryLogic auxilary)
        {
            _user = user;
            _auxilary = auxilary;
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
        public List<UserViewModel>? GetActiveUsersList()
        {
            try
            {
                return _user.ReadActiveUsers();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public UserViewModel? GetUser(int userID)
        {
            try
            {
                return _user.ReadUser(new UserSearchModel
                {
                    ID = userID,
                });
            }
            catch (Exception ex) 
            {
                throw;
            }
        }

        [HttpGet]
        public List<GroupViewModel>? GetGroupsList()
        {
            try
            {
                return _auxilary.GetGroupsList();
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public bool CheckGroup(string login)
        {
            try
            {
                return _user.CheckGroup(new UserSearchModel { Login = login });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPatch]
        public bool DisableUser(int userID)
        {
            try
            {

                return _user.Disable(new UserBindingModel { ID = userID });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
