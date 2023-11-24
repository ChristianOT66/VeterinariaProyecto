using Veterinaria.Models.DataModels;


namespace Veterinaria.Website.Application.Contracts
{
    public interface IEmailSenderService
    {
        bool SendEmail(Email email);
    }
}
