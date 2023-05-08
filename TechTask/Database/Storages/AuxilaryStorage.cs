using Contracts.StorageContracts;
using Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Storages
{
    public class AuxilaryStorage : IAuxilaryStorage
    {
        public List<GroupViewModel> GetGroups()
        {
            using var context = new DatabaseContext();
            return context.Groups.Select(group => group.GetViewModel).ToList();
        }

        public List<StateViewModel> GetStates()
        {
            using var context = new DatabaseContext();
            return context.States.Select(state => state.GetViewModel).ToList();
        }
    }
}
