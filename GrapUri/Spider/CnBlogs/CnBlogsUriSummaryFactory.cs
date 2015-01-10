using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.Spider.CnBlogs
{
    public static class CnBlogsUriSummaryFactory
    {
        public static IUriSummary GetUriSummaryProcessor(Uri uri)
        {
            string uriHost = uri.Host;
            switch (uriHost)
            {
                case "http://news.cnblogs.com":
                    return new CnBlogsNewsProcessor();
                default:
                    return new CommonProcessor();
            }
        }
    }
}
