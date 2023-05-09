using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Enums
{
    public enum GroupType
    {
        [PgName("admin")]
        Admin = 1,
        [PgName("user")]
        User = 2
    }
}
