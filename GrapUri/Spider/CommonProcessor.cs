using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Util;

namespace Spiders
{
    /// <summary>
    /// 通用处理
    /// </summary>
    public class CommonUriProcessor:BaseUriProcessor,IUriSummary
    {
        public CommonUriProcessor ()
        {
            this._headTitleRegexStr= @"<title>.+</title>";
            this._headDescripRegexStr = "<meta" + @"\s+" + "name=\"description\""
                + @"\s+" + "content=\"(?<content>[^\"" + @"\<\>" + "]*)\"";
        }
        public SummaryResult GetUriSummary(Uri uri)
        {
            SummaryResult rlt = new SummaryResult();
            HttpUtil httpUtil = new HttpUtil();
            string str = httpUtil.SendGet(uri.ToString());
            string title = this.HeadTitleRegex.Match(str).ToString();
            string description = this.HeadDescripRegex.Match(str).ToString();
            rlt.Title = title;
            rlt.ContentSummary = description;
            return rlt;
        }
    }
}
