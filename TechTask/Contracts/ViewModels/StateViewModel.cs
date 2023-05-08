using DataModels.Enums;
using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ViewModels
{
    public class StateViewModel : IState
    {
        public StateType Code { get; set; }

        public string Description { get; set; } = string.Empty;

        public int ID { get; set; }
    }
}
