﻿using Contracts.BindingModels;
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
    public class Group : IGroup
    {
        public int ID { get; private set; }

        [Required]
        public GroupType Code { get; private set; }

        [Required]
        public string Description { get; private set; } = string.Empty;

        [ForeignKey("GroupID")]
        public virtual List<User> Users { get; private set; } = new();

        public static Group? Create(GroupViewModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new Group()
            {
                ID = model.ID,
                Code = model.Code,
                Description = model.Description,
            };
        }

        public GroupViewModel GetViewModel => new()
        {
            ID = ID,
            Code = Code,
            Description = Description
        };
    }
}
