using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoSocialAPI.Hypermedia.Filters
{
    public class HyperMediaFilter : ResultFilterAttribute
    {
        private readonly HyperMediaFilterOptions _hyperMediaFilterOptions;
        
        public HyperMediaFilter(HyperMediaFilterOptions hyperMediaFilterOptions)
        {
            _hyperMediaFilterOptions = hyperMediaFilterOptions;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            TryEnhanceResult(context);
            base.OnResultExecuting(context);
        }

        private void TryEnhanceResult(ResultExecutingContext context)
        {
            if (context.Result is OkObjectResult objectResult)
            {
                var enhancer = _hyperMediaFilterOptions
                    .ContentResponseEnhancerList
                    .FirstOrDefault(x => x.CanEnhance(context));

                if (enhancer is not null) Task.FromResult(enhancer.Enhance(context));
            };
        }
    }
}
