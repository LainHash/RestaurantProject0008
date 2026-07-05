using Restaurant.Contract.DTOs.Authentication;

namespace Restaurant.API.Controllers.Authentication
{
    internal class VerifyEmailCommand
    {
        private VerifyEmailRequest request;

        public VerifyEmailCommand(VerifyEmailRequest request)
        {
            this.request = request;
        }
    }
}