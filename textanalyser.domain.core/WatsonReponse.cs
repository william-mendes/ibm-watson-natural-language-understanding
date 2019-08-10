using System.Collections.Generic;

namespace textanalyser.domain.core
{
    public class WatsonReponse
    {
        public string AnalyzedText { get; set; }

        public List<string> Categories { get; set; }

        public Dictionary<string, double> Keywords { get; set; }

        public Dictionary<string, double> Emotions { get; set; }

        public Dictionary<string, double> Sentiment { get; set; }

        public string ErrorMessage { get; set; }
    }
}