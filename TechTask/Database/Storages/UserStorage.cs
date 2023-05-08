using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.StorageContracts;
using Contracts.ViewModels;
using Database.Models;
using DataModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Storages
{
    public class UserStorage : IUserStorage
    {       
        public UserViewModel? GetUser(UserSearchModel model)
        {
            if(string.IsNullOrEmpty(model.Login) && !model.ID.HasValue)
            {
                return null;
            }
            using var context = new DatabaseContext();

            if(!string.IsNullOrEmpty(model.Password))
            {
                return context.Users.FirstOrDefault(user => model.Login.Equals(user.Login) && model.Password.Equals(user.Password))?.GetViewModel;
            }

            return context.Users.FirstOrDefault(user => (!string.IsNullOrEmpty(model.Login) && model.Login.Equals(user.Login)) || (model.ID.HasValue && model.ID == user.ID))?.GetViewModel;
        }

        public List<UserViewModel> GetUsers()
        {
            using var context = new DatabaseContext();
            return context.Users.Select(user => user.GetViewModel).ToList();
        }

        public List<UserViewModel> GetActiveUsers()
        {
            using var context = new DatabaseContext();
            return context.Users.Where(user => user.StateID == (int)StateType.Active).Select(user => user.GetViewModel).ToList();
        }

        public UserViewModel? Insert(UserBindingModel model)
        {
            using var context = new DatabaseContext();
            var newUser = User.Create(model);
            if(newUser == null)
            {
                return null;
            }
            context.Users.Add(newUser);
            context.SaveChanges();
            return newUser.GetViewModel;
        }
        public UserViewModel? Disable(UserBindingModel model)
        {
            using var context = new DatabaseContext();
            var user = context.Users.FirstOrDefault(user => user.ID == model.ID);
            if(user == null)
            {
                return null;
            }
            user.Update(model);
            context.SaveChanges();
            return user.GetViewModel;
        }
    }
}
