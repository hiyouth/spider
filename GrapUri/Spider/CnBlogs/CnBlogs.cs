using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiders
{
    //处理来自博客园的Uri分析
    public class CnBlogs:IAnalyseUri
    {
        /// <summary>
        /// 通过Uri抓取网页概要信息
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public SummaryResult GetSummary(Uri uri)
        {
            throw new NotImplementedException();
        }
    }
}
