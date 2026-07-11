namespace Restaurant.Contract.DTOs.Authentication;

public class VerifyEmailRequest
{
    public string Code { get; set; } = string.Empty;
}
