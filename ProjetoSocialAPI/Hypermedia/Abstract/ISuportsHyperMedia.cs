using System.Collections.Generic;

namespace ProjetoSocialAPI.Hypermedia.Abstract
{
    public interface ISuportsHyperMedia
    {
        List<HyperMediaLink> Links { get; set; }
    }
}
