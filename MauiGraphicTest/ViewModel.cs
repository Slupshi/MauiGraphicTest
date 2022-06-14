using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace MauiGraphicTest
{
    public class ViewModel
    {
        public CustomGraphModel GraphModel { get; set; }

        public ViewModel()
        {

            GraphModel = new CustomGraphModel()
            {
                Name = "CA HT",
                Series = new ISeries[]
            {
                new CustomGraphLine("N", RandomizeValues()),
                new CustomGraphLine("N-1", RandomizeValues()),
            },
                Labeler = Labelers.Currency,

            };
        }

        private IEnumerable<double> RandomizeValues()
        {
            Random random = new Random();
            List<double> values = new List<double>();
            for (int i = 0; i < 7; i++)
            {
                int numberToAdd = random.Next(1000);
                values.Add(numberToAdd);
            }
            return values;
        }
        //public DrawMarginFrame DrawMarginFrame => new()
        //{
        //    Fill = new SolidColorPaint(SKColors.Empty),
        //    Stroke = new SolidColorPaint(SKColors.Black, 3)
        //};
    }
}
