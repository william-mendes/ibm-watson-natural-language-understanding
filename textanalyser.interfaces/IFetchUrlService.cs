using System;
using System.Threading.Tasks;
using textanalyser.domain.core;

namespace textanalyser.interfaces
{
    public interface IFetchService
    {
        Task<FetchAnalysis> FetchFromUrl(string url);

        Task<FetchAnalysis> FetchFromText(string text);
    }
}