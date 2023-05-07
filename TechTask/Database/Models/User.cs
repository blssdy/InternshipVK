using Contracts.BindingModels;
using Contracts.ViewModels;
using DataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Database.Models
{
    public class User : IUser
    {
        public int ID { get; private set; }

        [Required]
        public string Login { get; private set; } = string.Empty;

        [Required]
        public string Password { get; private set; } = string.Empty;

        [Required]
        public DateTime DateCreate { get; private set; } = DateTime.Now;

        [Required]
        public int GroupID { get; private set; }
       
        public virtual Group Group { get; set; }

        [Required]
        public int StateID { get; private set; }

        public virtual State State { get; set; }

        public static User? Create(UserBindingModel? model)
        {
            if(model == null)
            {
                return null;
            }
            return new User()
            {
                ID = model.ID,
                Login = model.Login,
                Password = model.Password,
                DateCreate = model.DateCreate,
                GroupID = model.GroupID,
                StateID = model.StateID,
            };
        }

        public void Update(UserBindingModel model)
        {
            if(model == null)
            {
                return;
            }
            StateID = model.StateID;
        }

        public UserViewModel GetViewModel => new()
        {
            ID = ID,
            Login = Login,
            Password = Password,
            DateCreate = DateCreate,
            GroupID = GroupID,
            StateID = StateID,
            GroupStatus = Group.Code,
            StateStatus = State.Code
        };

    }
}
