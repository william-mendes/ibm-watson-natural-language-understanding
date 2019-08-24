using System.Collections.Generic;
using textanalyser.domain.core;

namespace textanalyser.api.data.resposes
{
    public class FetchAnalysisResponse
    {
        public WatsonReponse WatsonReponse { get; set; }

        public List<Image> Images { get; set; }
    }
}