using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace GrapUri
{
    class Program
    {
        static void Main(string[] args)
        {
       //     string Uri = "http://news.cnblogs.com/n/512264/";
        //    string Uri = "http://dev.indexer.im/";
            string title;
            string mainContent;
            string picUri;

          Uri uri = new System.Uri("http://qq.baidu.com/555/6666/777");
       
          Match mch=m.Match("http://news.tower.im");
          string s = mch.Value;
          

         //   Uri = Console.ReadLine();
            Spider spider = new Spider("");
            spider.threadStart();
        }

        
    }

    public class Spider
    {
        private string url="";

        public Spider(string uri){
            this.url=uri;
        }

        public void threadStart()
        {
            ThreadStart ts = new ThreadStart(Start);
            Thread th = new Thread(ts);
            th.Start();
        }

        private void Start()
        {
            this.getContent(url);
        }

        private void getContent(string url)
        {
            string titleRegex = "<div id=\"news_title\"><a.*?>(?<title>.*?)</a>";
            string bodyRegex = "<div id=\"news_body\">(?<body>.*?)</div>";
            string imgRegex = @"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>";
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
                 //   Regex timer = new Regex(this.timeRegex, RegexOptions.Singleline);
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("异常:{0},{1}", ex.Source, ex.Message);
                return;
            }
        }
}
}
