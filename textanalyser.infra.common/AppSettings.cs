using Microsoft.Extensions.Configuration;

namespace textanalyser.infra.common
{
    public class AppSettings
    {
        private IConfiguration _configuration;

        public AppSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string DefaultUrl() => _configuration.GetSection("DefaultUrl").Value;

        public string DefaultText() => _configuration.GetSection("DefaultText").Value;

        public string WatsonUrl() => _configuration.GetSection("IBMCredentials:WatsonUrl").Value;

        public string WatsonApiKey() => _configuration.GetSection("IBMCredentials:WatsonApiKey").Value;

        public string WatsonVersionDate() => _configuration.GetSection("IBMCredentials:WatsonVersionDate").Value;

        public string GoogleApiKey() => _configuration.GetSection("GoogleCredentials:ApiKey").Value;

        public string GoogleCustomSearchCx() => _configuration.GetSection("GoogleCredentials:SearchEngineId").Value;

    }
}