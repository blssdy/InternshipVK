using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.SearchModels
{
    public class UserSearchModel
    {
        public int? ID { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
    }
}
