using e_Biblioteka.ModulEmailKorisnik.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;

namespace e_Biblioteka.ModulEmailKorisnik.Service
{
    public class APIMailService : IAPIMailService
    {
        private readonly MailSettings _mailSettings;
        private readonly HttpClient _httpClient;

        public APIMailService(IOptions<MailSettings> mailSettingsOptions, IHttpClientFactory httpClientFactory)
        {
            _mailSettings = mailSettingsOptions.Value;
            _httpClient = httpClientFactory.CreateClient("MailTrapApiClient");
        }


        public async Task<bool> SendMailAsync(MailData mailData)
        {
            var apiEmail = new
            {
                From = new { Email = _mailSettings.SenderEmail, Name = _mailSettings.SenderEmail },
                To = new[] { new { Email = mailData.EmailToId, Name = mailData.EmailToName } },
                Subject = mailData.EmailSubject,
                Text = mailData.EmailBody
            };

            var httpResponse = await _httpClient.PostAsJsonAsync("send", apiEmail);

            var responseJson = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson);

            if (response != null && response.TryGetValue("success", out object? success) && success is bool boolSuccess && boolSuccess)
            {
                return true;
            }

            return false;
        }

    }
}
