using textanalyser.domain.core;
using Google.Apis.Customsearch.v1;
using System.Collections.Generic;
using static Google.Apis.Services.BaseClientService;
using Google.Apis.Services;
using System.Linq;
using System.Threading.Tasks;
using textanalyser.infra.common;

namespace textanalyser.providers
{
    public class GoogleCustomSearch : IGoogleCustomSearch
    {
        private const string Fields = "items/pagemap";
        private readonly string _googleApiKey;
        private readonly string _googleCx;

        public GoogleCustomSearch(AppSettings appSettings)
        {
            _googleApiKey = appSettings.GoogleApiKey();
            _googleCx = appSettings.GoogleCustomSearchCx();
        }

        public async Task<List<Image>> LoadGoogleImages(List<string> keywords)
        {
            var result = new List<Image>();

            var initializer = new BaseClientService.Initializer();
            initializer.ApiKey = _googleApiKey;

            var svc = new CustomsearchService(initializer);

            foreach (var keyword in keywords)
            {
                var listRequest = svc.Cse.List(keyword);

                listRequest.Cx = _googleCx;
                listRequest.Fields = Fields;

                var search = await listRequest.ExecuteAsync();
                var firstResultItem = search.Items?.FirstOrDefault();
                var firstPageMapOfItem = firstResultItem?.Pagemap?.Values?.FirstOrDefault();
                var firstImageOfPageMap = firstPageMapOfItem?.FirstOrDefault();
                var imageUrl = string.Empty;

                if (firstImageOfPageMap.ContainsKey("src"))
                    imageUrl = firstImageOfPageMap["src"].ToString();
                
                result.Add(new Image()
                {
                    Keyword = keyword,
                    ImageUrl = imageUrl
                });
            }

            return result;
        }
    }
}