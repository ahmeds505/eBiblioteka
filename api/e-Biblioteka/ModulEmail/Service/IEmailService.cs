using e_Biblioteka.ModulEmail.Models;
using Microsoft.AspNetCore.Mvc;

namespace e_Biblioteka.ModulEmail.Service
{
    public interface IEmailService
    {
        public ActionResult<bool> SendEmail(EmailModel request);
    }
}
