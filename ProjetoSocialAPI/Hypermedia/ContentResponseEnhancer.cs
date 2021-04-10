using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using ProjetoSocialAPI.Hypermedia.Abstract;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoSocialAPI.Hypermedia
{
    public abstract class ContentResponseEnhancer<T> : IResponseEnhancer where T : ISuportsHyperMedia
    {
        public ContentResponseEnhancer()
        {

        }
        public bool CanEnhance(Type contentType)
        {
            return contentType == typeof(T) || contentType == typeof(List<T>);
        }

        protected abstract Task EnhanceModel(T content, IUrlHelper urlHelper);

        bool IResponseEnhancer.CanEnhance(ResultExecutingContext response)
        {
            if (response.Result is OkObjectResult okObjectResult)
            {
                return CanEnhance(okObjectResult.Value.GetType());
            }
            return false;
        }

        public async Task Enhance(ResultExecutingContext response)
        {
            var urlHelper = new UrlHelperFactory().GetUrlHelper(response);
            if (response.Result is OkObjectResult okObjectResult)
            {
                if (okObjectResult.Value is T model)
                {
                    await EnhanceModel(model, urlHelper);
                }

                else if (okObjectResult.Value is List<T> collection)
                {
                    ConcurrentBag<T> bag = new ConcurrentBag<T>(collection);
                    Parallel.ForEach(bag, (element) =>
                    {
                        EnhanceModel(element, urlHelper);
                    });
                }
            }
            await Task.FromResult<object>(null);
        }
    }
}
