using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public interface IUser : IID
    {
        string Login { get; }
        string Password { get; }
        DateTime DateCreate { get; }
        int GroupID { get; }
        int StateID { get; }
    }
}
