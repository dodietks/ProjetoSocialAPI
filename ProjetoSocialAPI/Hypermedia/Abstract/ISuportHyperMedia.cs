using System.Collections.Generic;

namespace ProjetoSocialAPI.Hypermedia.Abstract
{
    public interface ISuportHyperMedia
    {
        List<HyperMediaLink> Links { get; set; }
    }
}
