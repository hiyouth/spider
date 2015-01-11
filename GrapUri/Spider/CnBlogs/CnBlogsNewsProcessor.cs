using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Util;

namespace Spiders
{
    public class CnBlogsNewsProcessor : BaseUriProcessor,IUriSummary
    {
        
        public CnBlogsNewsProcessor()
        {
            this._titleRegexStr = "<div id=\"news_title\"><a.*?>(?<title>.*?)</a>";
            this._bodyRegexStr = "<div id=\"news_body\">(?<body>.*?)</div>";
            this._imgRegexStr = @"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>";
        }
        public SummaryResult GetUriSummary(Uri uri)
        {
            SummaryResult rlt = new SummaryResult();
            //this.TitleRegex = "<div id=\"news_title\"><a.*?>(?<title>.*?)</a>";
            //this.BodyRegex = "<div id=\"news_body\">(?<body>.*?)</div>";
            //this.ImgRegex = @"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>";
            try
            {
                //HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(this.Uri);

                //req.Method = "get";
                //req.ContentType = "	text/html;charset=utf-8";
                //string encoding = "utf-8";
                HttpUtil httpUtil = new HttpUtil();
                string str= httpUtil.SendGet(uri.ToString());

                //req.
                //req.AllowAutoRedirect = false;
                // req.Timeout = 50;
                //req.CookieContainer = cc;
                //StringBuilder sb = new StringBuilder("");
                //StringBuilder cont = new StringBuilder("");
                //using (HttpWebResponse wr = req.GetResponse() as HttpWebResponse)
                //{
                //    System.IO.Stream respStream = wr.GetResponseStream();
                //    System.IO.StreamReader reader = new System.IO.StreamReader(respStream, 
                //        System.Text.Encoding.GetEncoding(encoding));
                //    Regex titler = new Regex(this.TitleRegex, RegexOptions.Singleline);
                //    //   Regex timer = new Regex(this.timeRegex, RegexOptions.Singleline);
                //    Regex bodyr = new Regex(this.BodyRegex, RegexOptions.Singleline);
                //    Regex pic = new Regex(this.ImgRegex, RegexOptions.Singleline);
                //    do
                //    {
                //        sb.Append(reader.ReadLine());

                //    } while (!reader.EndOfStream);

                //    string str = sb.ToString();
                    //Console.WriteLine(sb);
                    Match m = this.TitleRegex.Match(str);
                    if (m.Success)
                    {
                        Console.WriteLine("title:{0}", m.Groups["title"].Value);
                        //streamWriter.WriteLine(m.Groups["title"].Value);
                        rlt.Title=m.Groups["title"].Value;
                  //      cont.AppendLine(m.Groups["title"].Value);

                    }
                    m = this.BodyRegex.Match(str);
                    if (m.Success)
                    {
                        string body = m.Groups["body"].Value;
                        string bodyFull = body;
                        deleteTag(ref body);
                        Console.WriteLine("获取正文");
                        rlt.ContentSummary=body;
                        //cont.AppendLine(body);

                        m = this.ImgRegex.Match(bodyFull);
                        if (m.Success)
                        {
                           rlt.PicUri = m.Groups["imgUrl"].Value;
                        }
                    }
                    return rlt;
                }
            catch (Exception ex)
            {
                Console.WriteLine("异常:{0},{1}", ex.Source, ex.Message);
                return null;
            }
        }
    }
}
