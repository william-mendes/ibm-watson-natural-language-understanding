using System.Collections.Generic;

namespace textanalyser.domain.core
{
    public class FetchAnalysis
    {
        public WatsonReponse WatsonResponse { get; set; }

        public List<Image> Images { get; set; }
    }
}