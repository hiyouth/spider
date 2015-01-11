
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Spiders
{
    /// <summary>
    /// 根据Uri决定初始化哪一个Uri抓取程序
    /// </summary>
    public static class UriFactory
    {
        //获取Uri的Host，如http://news.cnblogs.com ,将截取cnblogs.com
        private static Regex reg= new Regex(@"([a-z0-9][a-z0-9\-]*?\.(?:com|cn|net|org|gov|info|la|im|fm|cc|co)(?:\.(?:cn|jp))?)$");
        public static IAnalyseUri GetAnalyseUri(Uri uri)
        {
            Match m =reg.Match(uri.Host);
            string host = m.Value;
            if (String.IsNullOrEmpty(host))
            {
                return null;
            }
            switch (host)
            {
                case "cnblogs.com":
                    //来自博客园的Uri
                    return new CnBlogs();
                default:
                    return new CommonUri();
            }
        }
    }
}
