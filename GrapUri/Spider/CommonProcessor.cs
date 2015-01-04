using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider
{
    /// <summary>
    /// 通用处理
    /// </summary>
    public class CommonProcessor:BaseUriAnalyse,IAnalyseUri
    {
        public SummaryResult GetSummary(Uri uri)
        {
            throw new NotImplementedException();
        }
    }
}
