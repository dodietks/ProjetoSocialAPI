using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace ProjetoSocialAPI.Hypermedia.Abstract
{
    public interface IResponseEnhancer
    {
        bool CanEnhance(ResultExecutingContext context);
        Task Enhance(ResultExecutingContext context);
    }
}
