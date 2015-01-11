using Spiders;
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
            string uriStr=Console.ReadLine();
            Spider spider = new Spider(uriStr);
            SummaryResult summary = spider.Start();
        }
    }
}
