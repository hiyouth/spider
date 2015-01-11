using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Spiders
{
    public class Spider
    {
        private string url = "";

        public Spider(string uri)
        {
            this.url = uri;
        }

        //public void threadStart()
        //{
        //    ThreadStart ts = new ThreadStart(() => Start(this.url));
        //    Thread th = new Thread(ts);
        //    th.Start();
        //}

        public SummaryResult Start()
        {
            SummaryResult rlt = new SummaryResult();
            Uri uri = this.FiliterUrl(this.url);
            if(uri==null)
            {
                 rlt.ErrorCode = 0;
                 rlt.ErrorMessage = "需要分析的Uri不正确";
            }
            rlt = this.GetSummary(uri);
            return rlt;
        }

        private SummaryResult GetSummary(Uri uri)
        {
            IAnalyseUri analyseUri = UriFactory.GetAnalyseUri(uri);
            return analyseUri.GetSummary(uri);
        }

        //处理发送的Uri
        private Uri FiliterUrl(string url)
        {
            Uri uri=null;
            if (String.IsNullOrEmpty(url))
            {
                return null;
            }
            if (url.StartsWith("www"))
            {
                url = "http://" + url;
            }
            try
            {
               uri = new Uri(url);
            }
            catch (Exception ex)
            {
                return null;
            }
             return uri;
        }
    }
}
