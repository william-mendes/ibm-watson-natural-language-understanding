using textanalyser.domain.core;

namespace textanalyser.providers
{
    public interface IWatsonIBMProvider
    {
        WatsonReponse LoadWatsonFromUrl(string url);

        WatsonReponse LoadWatsonFromText(string text);
    }
}