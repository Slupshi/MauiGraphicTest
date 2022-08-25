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

        SKColor _darkGreen = new SKColor().WithRed(4).WithGreen(51).WithBlue(51);
        SKColor _darkOrange = new SKColor().WithRed(225).WithGreen(110).WithBlue(9);


        public ViewModel()
        {
            GraphModel = new CustomGraphModel(
                name: "Toto",
                isCurrency: true,
                isWeekly: true);
            //GraphModel.Series.Add(new CustomGraphLine("Ligne", RandomizeSeries(), true));

        }

        private ObservableCollection<ObservableValue> RandomizeSeries()
        {
            //int max = GraphModel.YAxis.Labeler == Labelers.Currency ? 1000 : 200;
            int max = 1000;
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
                new CustomGraphLine(name:$"N{(GraphModel.Series.Count >= 1 ? $"-{GraphModel.Series.Count}" : string.Empty)}",values: RandomizeSeries(), isCurrency: GraphModel.YAxis.Labeler == Labelers.Currency ? true : false, color: (GraphModel.Series.Count >= 1 ? _darkGreen : _darkOrange)));
        }

        public void RemoveSeries()
        {
            //if (GraphModel.Series.Count == 1) return;

            GraphModel.Series.RemoveAt(GraphModel.Series.Count - 1);
        }

        public void ChangeGraphicType()
        {
            //if(GraphModel.YAxis.Labeler == Labelers.Currency)
            //{
            //    GraphModel.YAxis.Labeler = Labelers.Default;
            //    GraphModel.XAxis.Name = "Clients";
            //}
            //else
            //{
            //    GraphModel.YAxis.Labeler = Labelers.Currency;
            //    GraphModel.XAxis.Name = "CA HT hors rétro";
            //}
            //int seriesCount = GraphModel.Series.Count;
            //if(seriesCount > 0)
            //{
            //    GraphModel.Series.Clear();
            //    for (int i = 0; i < seriesCount; i++)
            //    {
            //        AddSeries();
            //    }
            //}
            GraphModel.ChangeGraphicType();
        }

        public void ResetSeries()
        {
            GraphModel.Series.Clear();
            GraphModel.YAxis.Labeler = Labelers.Default;
        }



        //public DrawMarginFrame DrawMarginFrame => new()
        //{
        //    Fill = new SolidColorPaint(SKColors.Empty),
        //    Stroke = new SolidColorPaint(SKColors.Black, 3)
        //};
    }
}
