using System.Text.Json.Serialization;

namespace Restaurant.Contract.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TableStatus
    {
        Available,
        Maintenance,
        Reserved,
        Occupied
    }
}
