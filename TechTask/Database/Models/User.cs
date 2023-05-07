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

        

    }
}
