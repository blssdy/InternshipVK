using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.BusinessLogicContracts
{
    public interface IUserLogic
    {
        UserViewModel? ReadUser(UserSearchModel model);
        List<UserViewModel>? ReadUsers();
        bool Create(UserBindingModel model);
        bool Delete(UserBindingModel model);
    }
}
