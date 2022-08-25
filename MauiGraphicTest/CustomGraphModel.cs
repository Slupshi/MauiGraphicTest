using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.Kernel.Sketches;
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
        public string?[] Labels { get; set; }
        public ICartesianAxis YAxis { get; set; }
        public ICartesianAxis XAxis { get; set; }


        public CustomGraphModel()
        {

        }

        public CustomGraphModel(string name, bool isCurrency, bool isWeekly)
        {
            Name = name;
            Series = new ObservableCollection<ISeries>();
            Labeler = isCurrency ? Labelers.Currency : Labelers.Default;
            Sections = new ObservableCollection<RectangularSection>();
            Labels = isWeekly ? new string[] { "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi", "Dimanche" } : new string[] { "X1", "X2", "X3", "X4", "X5", "X6", "X7" };
        }

        public void ChangeGraphicType()
        {
            YAxis.Labeler = YAxis.Labeler == Labelers.Currency ? Labelers.Default : Labelers.Currency;
        }

    }
}
