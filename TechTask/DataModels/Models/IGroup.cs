using DataModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public interface IGroup : IID
    {
        GroupType Code { get; }
        string Description { get; }
    }
}
