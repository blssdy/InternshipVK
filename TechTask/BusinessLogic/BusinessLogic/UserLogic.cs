using Contracts.BindingModels;
using Contracts.BusinessLogicContracts;
using Contracts.SearchModels;
using Contracts.StorageContracts;
using Contracts.ViewModels;
using DataModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BusinessLogic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserStorage _userStorage;

        public UserLogic(IUserStorage userStorage)
        {
            _userStorage = userStorage;
        }

        public bool Create(UserBindingModel model)
        {
            CheckUser(model);
            
            model.StateID = (int)StateType.Active;

            if(_userStorage.Insert(model) == null)
            {
                return false;
            }
            Thread.Sleep(5000);
            return true;
        }

        public bool Disable(UserBindingModel model)
        {
            CheckUser(model,false);

            model.StateID = (int)StateType.Blocked;

            if(_userStorage.Disable(model) == null)
            {
                return false;
            }
            return true;
        }

        public UserViewModel? ReadUser(UserSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var user = _userStorage.GetUser(model);

            if (user == null) { return null; }

            if(user.StateID == (int)StateType.Blocked)
            {
                throw new InvalidOperationException("Current user is disabled.");
            }

            return user;
        }

        public List<UserViewModel>? ReadUsers()
        {
            var users  = _userStorage.GetUsers();

            if(users == null)
            {
                return null;
            }
            return users;
        }

        public List<UserViewModel>? ReadActiveUsers()
        {
            var users = _userStorage.GetActiveUsers();

            if (users == null)
            {
                return null;
            }
            return users;
        }

        public void CheckUser(UserBindingModel model, bool extraCheck = true)
        {
            if(model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if(!extraCheck)
            {
                return;
            }

            if(string.IsNullOrEmpty(model.Login))
            {
                throw new ArgumentNullException("Invalid user's login", nameof(model.Login));                
            }
            if (string.IsNullOrEmpty(model.Password))
            {
                throw new ArgumentNullException("Invalid user's password", nameof(model.Password));
            }

            var user = _userStorage.GetUser(new UserSearchModel
            {
                Login = model.Login
            });

            if(user != null && model.ID != user.ID && user.StateID != (int)StateType.Blocked)
            {
                throw new InvalidOperationException("User with such login already exists.");
            }

            if(model.GroupID != (int)GroupType.Admin)
            {
                return;
            }

            var users = _userStorage.GetUsers();

            if(users.FirstOrDefault(user => user.GroupID == (int)GroupType.Admin) != null)
            {
                throw new InvalidOperationException("User with admin priviliges already exists.");
            }

        }

        public bool CheckGroup(UserSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var user = _userStorage.GetUser(model);

            if (user == null) { return false; }

            if (user.GroupID == (int)GroupType.Admin)
            {
                return true;
            }
            return false;
        }
        
    }
}
