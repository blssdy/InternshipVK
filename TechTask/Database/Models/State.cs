using Contracts.ViewModels;
using DataModels.Enums;
using DataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class State : IState
    {
        public int ID { get; private set; }

        [Required]
        public StateType Code { get; private set; }
        [Required]
        public string Description { get; private set; } = string.Empty;

        [ForeignKey("StateID")]
        public virtual List<User> Users { get; private set; } = new();

        public static State? Create(StateViewModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new State()
            {
                ID = model.ID,
                Code = model.Code,
                Description = model.Description,
            };
        }

        public StateViewModel GetViewModel => new() { ID = ID, Code = Code, Description = Description };

        
    }
}
