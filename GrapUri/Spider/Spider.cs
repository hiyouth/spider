using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Spider
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

        private SummaryResult Start(string url)
        {
            SummaryResult rlt = new SummaryResult();
            Uri uri = this.FiliterUrl(url);
            if(uri==null)
            {
                 rlt.ErrorCode = 0;
                 rlt.ErrorMessage = "需要分析的Uri不正确";
            }
            rlt= this.GetContent(uri);
            return rlt;
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

        private SummaryResult GetContent(Uri url)
        {
            string titleRegex = "<div id=\"news_title\"><a.*?>(?<title>.*?)</a>";
            string bodyRegex = "<div id=\"news_body\">(?<body>.*?)</div>";
            string imgRegex = @"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>";
            string timeRegex = "<span class=\"time\">(?<time>.*?)</span>";
            try
            {
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);

                req.Method = "get";
                req.ContentType = "	text/html;charset=utf-8";
                string encoding = "utf-8";

                //req.
                //req.AllowAutoRedirect = false;
                // req.Timeout = 50;
                //req.CookieContainer = cc;
                StringBuilder sb = new StringBuilder("");
                StringBuilder cont = new StringBuilder("");
                using (HttpWebResponse wr = req.GetResponse() as HttpWebResponse)
                {
                    System.IO.Stream respStream = wr.GetResponseStream();
                    System.IO.StreamReader reader = new System.IO.StreamReader(respStream, System.Text.Encoding.GetEncoding(encoding));
                    Regex titler = new Regex(titleRegex, RegexOptions.Singleline);
                    Regex timer = new Regex(timeRegex, RegexOptions.Singleline);
                    Regex bodyr = new Regex(bodyRegex, RegexOptions.Singleline);
                    Regex pic = new Regex(imgRegex, RegexOptions.Singleline);
                    do
                    {
                        sb.Append(reader.ReadLine());

                    } while (!reader.EndOfStream);

                    string str = sb.ToString();
                    //Console.WriteLine(sb);
                    Match m = titler.Match(str);
                    if (m.Success)
                    {
                        Console.WriteLine("title:{0}", m.Groups["title"].Value);
                        //streamWriter.WriteLine(m.Groups["title"].Value);
                        cont.AppendLine(m.Groups["title"].Value);

                    }

                    m = timer.Match(str);
                    if (m.Success)
                    {
                        Console.WriteLine("time:{0}", m.Groups["time"].Value);
                        cont.AppendLine(m.Groups["time"].Value);
                    }

                    m = bodyr.Match(str);
                    if (m.Success)
                    {
                        string body = m.Groups["body"].Value;
                        string bodyFull = body;
                        deleteTag(ref body);
                        Console.WriteLine("获取正文");
                        cont.AppendLine(body);

                        m = pic.Match(bodyFull);
                        if (m.Success)
                        {
                            string img = m.Groups["imgUrl"].Value;
                        }
                    }
                    cont.AppendLine("--------------------------------------------------------------");
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("异常:{0},{1}", ex.Source, ex.Message);
                return null;
            }
        }

        private String GetHtml(Uri uri)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
                req.Method = "get";
                req.ContentType = "	text/html;charset=utf-8";
                string encoding = "utf-8";

                //req.
                //req.AllowAutoRedirect = false;
                // req.Timeout = 50;
                //req.CookieContainer = cc;
                StringBuilder sb = new StringBuilder("");
                StringBuilder cont = new StringBuilder("");
                using (HttpWebResponse wr = req.GetResponse() as HttpWebResponse)
                {
                    System.IO.Stream respStream = wr.GetResponseStream();
                    System.IO.StreamReader reader = new System.IO.StreamReader(respStream, System.Text.Encoding.GetEncoding(encoding));
                    do
                    {
                        sb.Append(reader.ReadLine());

                    } while (!reader.EndOfStream);

                    string str = sb.ToString();
                    return str;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void deleteTag(ref string str)
        {

            str = Regex.Replace(str, "<[\\s]*p[^>]*>?>", "");
            str = Regex.Replace(str, "</[\\s]*p[\\s]*?>", "\r\n");
            str = Regex.Replace(str, "<[\\s]*br[\\s]*/[\\s]*[^>]*>?>", "\r\n");
            str = Regex.Replace(str, "<[\\s]*br[^>]*>?>", "");
            str = Regex.Replace(str, "</[\\s]*br[^>]*>?>", "\r\n");

            str = Regex.Replace(str, "<[\\s]*a[\\s]*[^>]*>?>", "");
            str = Regex.Replace(str, "</[\\s]*a[\\s]*[^>]*>?>", "");
            str = Regex.Replace(str, "<[\\s]*img[\\s]*[^>]*>?>", "");
            str = Regex.Replace(str, "</[\\s]*img[\\s]*[^>]*>?>", "");
            str = Regex.Replace(str, "<[\\s]*strong[\\s]*[^>]*>?>", "");
            str = Regex.Replace(str, "</[\\s]*strong[\\s]*[^>]*>?>", "");
            str = Regex.Replace(str, "<[\\s]*div[\\s]*[^>]*>?>", "");
            str = Regex.Replace(str, "</[\\s]*div[\\s]*[^>]*>?>", "");
            str = Regex.Replace(str, "<[\\s]*b[\\s]*[^>]*>?>", "");
            str = Regex.Replace(str, "</[\\s]*b[\\s]*[^>]*>?>", "");
            str = Regex.Replace(str, "<[\\s]*span[\\s]*[^>]*>?>", "");
            str = Regex.Replace(str, "</[\\s]*span[\\s]*[^>]*>?>", "");
            str = Regex.Replace(str, "<[\\s]*script[\\s]*[^>]*>?>", "");
            str = Regex.Replace(str, "</[\\s]*script[\\s]*[^>]*>?>", "");
            str = Regex.Replace(str, "<[\\s]*li[\\s]*[^>]*>?>", "");
            str = Regex.Replace(str, "</[\\s]*li[\\s]*[^>]*>?>", "");
            str = Regex.Replace(str, "<[\\s]*img[\\s]*[^>]*>?>", "");
            str = Regex.Replace(str, "</[\\s]*img[\\s]*[^>]*>?>", "");
            str = Regex.Replace(str, "<[\\s]*style[\\s]*[^>]*>?>", "");
            str = Regex.Replace(str, "</[\\s]*style[\\s]*[^>]*>?>", "");
            str = Regex.Replace(str, "<[\\s]*i[\\s]*[^>]*>?>", "");
            str = Regex.Replace(str, "</[\\s]*i[\\s]*[^>]*>?>", "");
            str = Regex.Replace(str, "<[\\s]*h3[\\s]*[^>]*>?>", "");
            str = Regex.Replace(str, "<[\\s]*h2[\\s]*[^>]*>?>", "");
            str = Regex.Replace(str, "</[\\s]*h3[\\s]*[^>]*>?>", "");
            str = Regex.Replace(str, "</[\\s]*h2[\\s]*[^>]*>?>", "");
            str = Regex.Replace(str, "<[\\s]*font[\\s]*[^>]*>?>", "");
            str = Regex.Replace(str, "</[\\s]*font[\\s]*[^>]*>?>", "");
            str = Regex.Replace(str, "<[\\s]*q[\\s]*[^>]*>?>", "");
            str = Regex.Replace(str, "</[\\s]*q[\\s]*[^>]*>?>", "");
            str = str.Replace("&rdquo;", "\"");
            str = str.Replace("&ldquo;", "\"");
            str = str.Replace("&lsquo;", "'");
            str = str.Replace("&rsquo;", "'");
            str = str.Replace("&nbsp;", " ");
            str = str.Replace("&hellip;", "…");
            str = str.Replace("&ndash;", "-");
            str = str.Replace("&mdash;", "—");
        }
    }
}
