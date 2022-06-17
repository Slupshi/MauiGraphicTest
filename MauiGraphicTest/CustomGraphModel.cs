using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;

namespace MauiGraphicTest
{
    public class CustomGraphModel
    {
        public CustomGraph GraphicChart { get; set; }
        public string Name { get; set; }
        public ObservableCollection<ISeries> Series { get; set; }
        public Func<double, string> Labeler { get; set; }
        public ObservableCollection<RectangularSection> Sections { get; set; }

    }
}
