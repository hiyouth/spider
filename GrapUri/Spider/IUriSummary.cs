using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiders
{
    public  interface IUriSummary
    {
        SummaryResult GetUriSummary(Uri uri);
    }
}
