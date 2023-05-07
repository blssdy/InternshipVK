using DataModels.Enums;
using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ViewModels
{
    public class UserViewModel : IUser
    {
        public int ID { get; set; }
        public string Login { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public DateTime DateCreate { get; set; } = DateTime.Now;

        public GroupType GroupStatus { get; set; }

        public StateType StateStatus { get; set; }

        public int GroupID { get; set; }

        public int StateID { get; set; }
    }
}
