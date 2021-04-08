using ProjetoSocialAPI.Hypermedia.Abstract;
using System.Collections.Generic;

namespace ProjetoSocialAPI.Hypermedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnhancer> ContentResponseEnhancerList { get; set; } = new List<IResponseEnhancer>();
    }
}
