using NpgsqlTypes;
using System.Text.Json.Serialization;

namespace DataModels.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GroupType
    {
        [PgName("admin")]
        Admin = 1,
        [PgName("user")]
        User = 2
    }
}
