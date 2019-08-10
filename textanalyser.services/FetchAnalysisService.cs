using textanalyser.domain.core;
using textanalyser.infra.common;
using textanalyser.interfaces;
using textanalyser.providers;

namespace textanalyser.services
{
    public class FetchAnalysisService : IFetchUrlService
    {
        private readonly AppSettings _appSettings;
        private readonly IWatsonIBMProvider _watsonProvider;

        public FetchAnalysisService(AppSettings appSettings, IWatsonIBMProvider watsonProvider)
        {
            _appSettings = appSettings;
            _watsonProvider = watsonProvider;
        }

        public WatsonReponse FetchFromUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                url = _appSettings.DefaultUrl();
            else
                url = System.Uri.UnescapeDataString(url);

            return _watsonProvider.LoadWatsonFromUrl(url);
        }

        public WatsonReponse FetchFromText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                text = _appSettings.DefaultText();

            return _watsonProvider.LoadWatsonFromText(text);
        }
    }
}