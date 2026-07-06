namespace Restaurant.Contract.DTOs.Misc.TempContacts
{
    public class CreateTemporaryContactRequest
    {
        public string GuestName { get; set; } = string.Empty;
        public string GuestEmail { get; set; } = string.Empty;
        public string GuestPhone { get; set; } = string.Empty;
    }
}
