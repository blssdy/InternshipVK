using Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.StorageContracts
{
    public interface IAuxilaryStorage
    {
        List<StateViewModel> GetStates();
        List<GroupViewModel> GetGroups();       
    }
}
