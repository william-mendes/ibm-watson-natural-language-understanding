using Microsoft.AspNetCore.Mvc;
using textanalyser.api.data.resposes;
using textanalyser.interfaces;

namespace textanalyser.api.Controllers
{
    [Route("api/fetch")]
    [ApiController]
    public class FetchAnalysisController : ControllerBase
    {
        private IFetchUrlService _fetchUrlService;

        public FetchAnalysisController(IFetchUrlService fetchUrlService)
        {
            _fetchUrlService = fetchUrlService;
        }

        // GET api/fetch/url
        [HttpGet("url/{url}")]
        public ActionResult<FetchAnalysisResponse> LoadFromUrl(string url)
        {
            var watsonResponse = _fetchUrlService.FetchFromUrl(url);

            var response = new FetchAnalysisResponse()
            {
                WatsonReponse = watsonResponse,
            };

            return Ok(response);
        }

        // GET api/fetch/text
        [HttpGet("text/{text}")]
        public ActionResult<FetchAnalysisResponse> LoadFromText(string text)
        {
            var watsonResponse = _fetchUrlService.FetchFromText(text);

            var response = new FetchAnalysisResponse()
            {
                WatsonReponse = watsonResponse,
            };

            return Ok(response);
        }
    }
}