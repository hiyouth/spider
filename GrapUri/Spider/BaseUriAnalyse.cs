using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider
{
    public class BaseUriAnalyse:IAnalyseUri
    {
        public string titleRegex { get; set; }
        public string bodyRegex { get; set; }
        public string imgRegex {get;set;}

        public SummaryResult AnalyseUri(string uri)
        {
            throw new NotImplementedException();
        }
    }
}
