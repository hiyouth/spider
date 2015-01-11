using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiders
{
    public class CommonUri:IAnalyseUri
    {
        public SummaryResult GetSummary(Uri uri)
        {
            IUriSummary uriSummary = new CommonUriProcessor();
            return uriSummary.GetUriSummary(uri);
        }
    }
}
