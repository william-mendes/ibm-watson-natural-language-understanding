using System;
using System.Threading.Tasks;
using textanalyser.domain.core;

namespace textanalyser.interfaces
{
    public interface IFetchUrlService
    {
        WatsonReponse FetchFromUrl(string url);

        WatsonReponse FetchFromText(string text);
    }
}