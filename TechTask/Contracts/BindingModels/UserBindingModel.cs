using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.BindingModels
{
    public class UserBindingModel : IUser
    {
        public int ID { get; set; }
        public string Login { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public DateTime DateCreate { get; set; } = DateTime.Now;

        public int GroupID { get; set; }

        public int StateID { get; set; }

    }
}
