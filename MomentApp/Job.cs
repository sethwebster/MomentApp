using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MomentApp
{
    public class Job
    {
        public string id { get; set; }
        public DateTime at { get; set; }
        public string method { get; set; }
        public Uri uri { get; set; }
    }
}
