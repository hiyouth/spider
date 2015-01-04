using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider
{
    public abstract class BaseUriProcessor
    {
        public string TitleRegex { get; set; }

        public string BodyRegex { get; set; }

        public string ImgRegex {get;set;}

        public string TimeRegex { get; set; }
    }
}
