﻿using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Enums
{
    public enum StateType
    {
        [PgName("blocked")]
        Blocked = 0,
        [PgName("active")]
        Active = 1      
    }
}
