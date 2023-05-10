using System.Text.Json.Serialization;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StateType
    {
        [PgName("blocked")]
        Blocked = 1,
        [PgName("active")]
        Active = 2      
    }
}
