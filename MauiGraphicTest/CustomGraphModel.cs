using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveChartsCore;

namespace MauiGraphicTest
{
    public class CustomGraphModel
    {
        public CustomGraph GraphicChart { get; set; }
        public string Name { get; set; }
        public IEnumerable<double>  Values { get; set; }
        public ISeries[] Series { get; set; }
        public Func<double, string> Labeler { get; set; }


    }
}
