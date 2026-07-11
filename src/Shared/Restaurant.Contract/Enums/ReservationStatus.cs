using System.Text.Json.Serialization;

namespace Restaurant.Contract.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ReservationStatus
    {
        Pending,
        Confirmed,
        Completed,
        Cancelled,
        NoShow
    }
}
