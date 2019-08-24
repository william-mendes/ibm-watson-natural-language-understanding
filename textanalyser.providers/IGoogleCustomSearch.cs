using System.Collections.Generic;
using System.Threading.Tasks;
using textanalyser.domain.core;

namespace textanalyser.providers
{
    public interface IGoogleCustomSearch
    {
        Task<List<Image>> LoadGoogleImages(List<string> keywords);
    }
}


