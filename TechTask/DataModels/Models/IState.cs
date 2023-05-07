using DataModels.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public interface IState : IID
    {
        StateType Code { get; }
        string Description { get; }
    }
}
