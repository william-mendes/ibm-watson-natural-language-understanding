using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using textanalyser.api.data.resposes;
using textanalyser.interfaces;

namespace textanalyser.api.Controllers
{
    [Route("api/fetch")]
    [ApiController]
    public class FetchAnalysisController : ControllerBase
    {
        private IFetchService _fetchService;

        public FetchAnalysisController(IFetchService fetchUrlService)
        {
            _fetchService = fetchUrlService;
        }

        // GET api/fetch/url
        [HttpGet("url/{url}")]
        public async Task<ActionResult<FetchAnalysisResponse>> LoadFromUrl(string url)
        {
            var fetchAnalysis = await _fetchService.FetchFromUrl(url);

            return Ok(new FetchAnalysisResponse()
            {
                WatsonReponse = fetchAnalysis.WatsonResponse,
                Images = fetchAnalysis.Images
            });
        }

        // GET api/fetch/text
        [HttpGet("text/{text}")]
        public async Task<ActionResult<FetchAnalysisResponse>> LoadFromText(string text)
        {
            var fetchAnalysis = await _fetchService.FetchFromText(text);

            return Ok(new FetchAnalysisResponse()
            {
                WatsonReponse = fetchAnalysis.WatsonResponse,
                Images = fetchAnalysis.Images
            });
        }
    }
}