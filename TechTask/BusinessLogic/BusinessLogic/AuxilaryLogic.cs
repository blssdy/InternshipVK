using Contracts.BusinessLogicContracts;
using Contracts.StorageContracts;
using Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BusinessLogic
{
    public class AuxilaryLogic : IAuxilaryLogic
    {
        private readonly IAuxilaryStorage _auxilaryStorage;

        public AuxilaryLogic(IAuxilaryStorage auxilaryStorage)
        {
            _auxilaryStorage = auxilaryStorage;
        }       

        public List<GroupViewModel>? GetGroupsList()
        {
            var groups = _auxilaryStorage.GetGroups();
            if(groups == null)
            {
                return new();
            }
            return groups;
        }

        public List<StateViewModel>? GetStatesList()
        {
            var states = _auxilaryStorage.GetStates();
            if(states == null)
            {
                return new();
            }
            return states;
        }
    }
}
