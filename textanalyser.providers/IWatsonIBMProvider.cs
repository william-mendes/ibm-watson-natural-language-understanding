using System.Threading.Tasks;
using textanalyser.domain.core;

namespace textanalyser.providers
{
    public interface IWatsonIBMProvider
    {
        Task<WatsonReponse> LoadWatsonFromUrl(string url);

        Task<WatsonReponse> LoadWatsonFromText(string text);
    }
}