using Spider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider
{
    public interface IAnalyseUri
    {
        SummaryResult AnalyseUri(string uri);
    }
}
