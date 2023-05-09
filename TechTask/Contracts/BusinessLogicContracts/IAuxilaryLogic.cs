using Contracts.BindingModels;
using Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.BusinessLogicContracts
{
    public interface IAuxilaryLogic
    {
        List<StateViewModel>? GetStatesList();
        List<GroupViewModel>? GetGroupsList();
       
    }
}
