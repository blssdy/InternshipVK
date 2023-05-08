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
        List<UserViewModel>? ReadActiveUsers();
        bool Create(UserBindingModel model);
        bool Disable(UserBindingModel model);
        bool CheckGroup(UserSearchModel model);
    }
}
