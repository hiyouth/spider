using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Spiders
{
    public abstract class BaseUriProcessor
    {
        public BaseUriProcessor()
        {

        }
        public BaseUriProcessor (string titleRegex,string bodyRegex,string imgRegex)
        {
            this._titleRegexStr = titleRegex;
            this._bodyRegexStr = bodyRegex;
            this._imgRegexStr = imgRegex;
        }

        public BaseUriProcessor(string headTitleRegexStr,string headdescripRegexStr)
        {
            this._headTitleRegexStr = headTitleRegexStr;
            this._headDescripRegexStr = headdescripRegexStr;
        }

        protected string _titleRegexStr;
        protected string _bodyRegexStr;
        protected string _imgRegexStr;
        protected string _timeRegexStr;
        protected string _headDescripRegexStr;
        protected string _headTitleRegexStr;


       

        public Uri Uri { get; set; }

        public  Regex HeadTitleRegex
        {
            get {
                return new Regex(this._headTitleRegexStr);
            }
        }


        public  Regex HeadDescripRegex
        {
            get
            {
                return new Regex(this._headDescripRegexStr);
            }
        }

        public  Regex TitleRegex
        {
            get
            {
                return new Regex(this._titleRegexStr);
            }
        }

        public  Regex BodyRegex
        {
            get
            {
                return new Regex(this._bodyRegexStr);
            }
        }

        public  Regex ImgRegex
        {
            get
            {
                return new Regex(this._imgRegexStr);
            }
        }

        public Regex TimeRegex { get; set; }

        public void deleteTag(ref string str)
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
