using Restaurant.Domain.Entities.Misc;

namespace Restaurant.Contract.DTOs.Misc.TempContacts
{
    public class TemporaryContactResponse
    {
        public Guid Id { get; set; }
        public string GuestName { get; set; } = string.Empty;
        public string GuestEmail { get; set; } = string.Empty;
        public string GuestPhone { get; set; } = string.Empty;

        public TemporaryContactResponse(TemporaryContact temporaryContact)
        {
            Id = temporaryContact.Id;
            GuestEmail = temporaryContact.GuestEmail;
            GuestName = temporaryContact.GuestName;
            GuestPhone = temporaryContact.GuestPhone;
        }
    }
}
