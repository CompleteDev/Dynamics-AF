using DynamicsInfo.Models;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.Identity.Client;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System;

namespace DynamicsInfo.Services
{
    public class AccountDynamics : IAccountDynamics
    {
        public AccountDynamics()
        {

        }

        public async Task<string> GetAccountsFromDynamics(string methodUri)
        {
            string dynamicSettingJson = Environment.GetEnvironmentVariable("DynamicSettingJson");
            var dynamicSettings = JsonSerializer.Deserialize<DynamicSettingsMdl>(dynamicSettingJson);

            string requestUri = $"{dynamicSettings.BaseUri}/{dynamicSettings.ApiVersion}/{methodUri}";

            string accessToken = GetAccessToken(dynamicSettings);

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(requestUri),
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = response.Content.ReadAsStringAsync();

                //var resp = JsonSerializer.Deserialize(body.Result);

                return body.Result;
            }
        }

        public string GetAccessToken(DynamicSettingsMdl dynamicSettings)
        {
            var scopes = new List<string> { dynamicSettings.BaseUri + "/.default" };

            var confidentialClient = ConfidentialClientApplicationBuilder
                  .Create(dynamicSettings.ClientId)
                  .WithClientSecret(dynamicSettings.ClientSecret)
                  .WithAuthority(new Uri(dynamicSettings.AuthorityUri))
                  .WithRedirectUri(dynamicSettings.RedirectUri)
                  .Build();

            var accessTokenRequest = confidentialClient.AcquireTokenForClient(scopes);

            var accessToken = accessTokenRequest.ExecuteAsync().Result.AccessToken;

            return accessToken;
        }

    }
}
