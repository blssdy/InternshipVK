using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.StorageContracts
{
    public interface IUserStorage
    {
        List<UserViewModel> GetUsers();
        UserViewModel? GetUser(UserSearchModel model);
        UserViewModel? Insert(UserBindingModel model);
        UserViewModel? Delete(UserBindingModel model);
    }
}
