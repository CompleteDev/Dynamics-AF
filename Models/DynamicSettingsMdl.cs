using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DynamicsInfo.Models
{
    public class DynamicSettingsMdl
    {
        [JsonPropertyName("BaseUri")]
        public string BaseUri { get; set; }

        [JsonPropertyName("ApiVersion")]
        public string ApiVersion { get; set; }

        [JsonPropertyName("ClientId")]
        public string ClientId { get; set; }

        [JsonPropertyName("ClientSecret")]
        public string ClientSecret { get; set; }

        [JsonPropertyName("TenantId")]
        public string TenantId { get; set; }

        [JsonPropertyName("RedirectUri")]
        public string RedirectUri { get; set; }

        [JsonPropertyName("AuthorityUri")]
        public string AuthorityUri { get; set; }
    }
}
