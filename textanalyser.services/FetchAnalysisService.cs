using System.Linq;
using System.Threading.Tasks;
using textanalyser.domain.core;
using textanalyser.infra.common;
using textanalyser.interfaces;
using textanalyser.providers;

namespace textanalyser.services
{
    public class FetchAnalysisService : IFetchService
    {
        private readonly AppSettings _appSettings;
        private readonly IWatsonIBMProvider _watsonProvider;
        private readonly IGoogleCustomSearch _googleCustomSearch;

        public FetchAnalysisService(AppSettings appSettings, IWatsonIBMProvider watsonProvider, IGoogleCustomSearch googleCustomSearch)
        {
            _appSettings = appSettings;
            _watsonProvider = watsonProvider;
            _googleCustomSearch = googleCustomSearch;
        }

        public async Task<FetchAnalysis> FetchFromUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                url = _appSettings.DefaultUrl();
            else
                url = System.Uri.UnescapeDataString(url);

            var watsonResponse = await _watsonProvider.LoadWatsonFromUrl(url);
            var images = await _googleCustomSearch.LoadGoogleImages(watsonResponse.Keywords.Keys.ToList());

            return new FetchAnalysis()
            {
                WatsonResponse = watsonResponse,
                Images = images
            };
        }

        public async Task<FetchAnalysis> FetchFromText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                text = _appSettings.DefaultText();

            var watsonResponse = await _watsonProvider.LoadWatsonFromText(text);
            var images = await _googleCustomSearch.LoadGoogleImages(watsonResponse.Keywords.Keys.ToList());

            return new FetchAnalysis()
            {
                WatsonResponse = watsonResponse,
                Images = images
            };
        }
    }
}