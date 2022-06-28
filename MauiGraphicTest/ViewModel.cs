using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView.Painting.Effects;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using SkiaSharp;

namespace MauiGraphicTest
{
    [ObservableObject]
    public partial class ViewModel
    {
        private readonly Random _random = new Random();
        public CustomGraphModel GraphModel { get; set; }
        public  ICartesianAxis YAxis { get; set; }
        public ICartesianAxis XAxis { get; set; }

        public ViewModel()
        {
            GraphModel = new CustomGraphModel(
                name: "Toto",
                isCurrency: true,
                isWeekly: true);
            
        }

        private ObservableCollection<ObservableValue> RandomizeSeries()
        {
            int max = YAxis.Labeler == Labelers.Currency ? 1000 : 200;
            return new ObservableCollection<ObservableValue>
                {
                        new ObservableValue(RandomizeValue(max)),
                        new(RandomizeValue(max)),
                        new(RandomizeValue(max)),
                        new(RandomizeValue(max)),
                        new(RandomizeValue(max)),
                        new(RandomizeValue(max)),
                        new(RandomizeValue(max)),
                };
        }
        private double RandomizeValue(int max)
        {            
            return _random.Next(max);
        }

        public void UpdateValues()
        {
            foreach(var series in GraphModel.Series)
            {
                series.Values = RandomizeSeries();
            }
        }

        public void AddSeries()
        {
            //if (GraphModel.Series.Count == 5) return;

            GraphModel.Series.Add(
                new CustomGraphLine($"N{(GraphModel.Series.Count > 1 ? $"-{GraphModel.Series.Count}" : string.Empty)}", RandomizeSeries(), YAxis.Labeler == Labelers.Currency ? true : false));
        }

        public void RemoveSeries()
        {
            //if (GraphModel.Series.Count == 1) return;

            GraphModel.Series.RemoveAt(GraphModel.Series.Count - 1);
        }

        public void ChangeGraphicType()
        {
            if(YAxis.Labeler == Labelers.Currency)
            {
                YAxis.Labeler = Labelers.Default;
                XAxis.Name = "Clients";
            }
            else
            {
                YAxis.Labeler = Labelers.Currency;
                XAxis.Name = "CA HT hors rétro";
            }
            int seriesCount = GraphModel.Series.Count;
            if(seriesCount > 0)
            {
                GraphModel.Series.Clear();
                for (int i = 0; i < seriesCount; i++)
                {
                    AddSeries();
                }
            }
        }

        public void ResetSeries()
        {
            GraphModel.Series.Clear();
            YAxis.Labeler = Labelers.Default;
        }



        //public DrawMarginFrame DrawMarginFrame => new()
        //{
        //    Fill = new SolidColorPaint(SKColors.Empty),
        //    Stroke = new SolidColorPaint(SKColors.Black, 3)
        //};
    }
}
