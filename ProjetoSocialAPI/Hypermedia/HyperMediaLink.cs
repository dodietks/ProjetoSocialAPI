using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSocialAPI.Hypermedia
{
    public class HyperMediaLink
    {
        public string Rel { get; set; }

        public string href;
        public string Href
        { 
            get
            {
                object _lock = new object();
                lock (_lock)
                {
                    StringBuilder stringBuilder = new StringBuilder(href);
                    return stringBuilder.Replace("%2f", "/").ToString();
                }
            }

            set
            {
                href = value;
            } 
        }
        public string Type { get; set; }
        public string Action { get; set; }
    }
}
