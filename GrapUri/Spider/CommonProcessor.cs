﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider
{
    /// <summary>
    /// 通用处理
    /// </summary>
    public class CommonProcessor:IAnalyseUri,IUriSummary
    {
        public SummaryResult GetSummary(Uri uri)
        {
            throw new NotImplementedException();
        }

        public SummaryResult GetUriSummary(Uri uri)
        {
            throw new NotImplementedException();
        }
    }
}
