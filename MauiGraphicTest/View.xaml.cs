using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting.Effects;
using LiveChartsCore.SkiaSharpView.Painting;
using Microsoft.Maui.Graphics;
using SkiaSharp;
using LiveChartsCore.Defaults;
using System.Collections.ObjectModel;

namespace MauiGraphicTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class View : ContentPage
    {
        private readonly ViewModel _viewModel;
        private CustomGraphModel _graphModel;

        public View(ViewModel viewModel)
        {
            _viewModel = viewModel;
            _graphModel = _viewModel.GraphModel;

            BindingContext = _viewModel;

            InitializeComponent();

            _viewModel.GraphModel.GraphicChart = GraphicChart;

            var yAxis = new Axis
            {
                MinLimit = 0,
                MinStep = 1,
                Labeler = _graphModel.Labeler,
            };
            var xAxis = new Axis
            {
                Name = _graphModel.Name,
                NamePadding = new LiveChartsCore.Drawing.Padding(15),
                NameTextSize = 20,
                MinStep = 1,
                ShowSeparatorLines = true,                
                Labels = _graphModel.Labels,

            };
            GraphicChart.YAxes = new List<Axis> { yAxis };
            GraphicChart.XAxes = new List<Axis> { xAxis };

            _viewModel.YAxis = yAxis;
            _viewModel.XAxis = xAxis;
            GraphicChart.DataPointerDown += GraphicChart_DataPointerDown;
        
        }

        private async void GraphicChart_DataPointerDown(LiveChartsCore.Kernel.Sketches.IChartView chart, IEnumerable<LiveChartsCore.Kernel.ChartPoint> points)
        {
            double index = points.First().SecondaryValue;
            _graphModel.Sections.Clear();
            _graphModel.Sections.Add(
                new RectangularSection()
                {
                    Xi = index,
                    Xj = index,
                    Stroke = new SolidColorPaint
                    {
                        Color = SKColors.Gray,
                        StrokeThickness = 3,
                        PathEffect = new DashEffect(new float[] { 5, 9})
                    }
                });
            //var pointsList = new ObservableCollection<ObservablePoint>();
            //foreach(var point in points)
            //{
            //    pointsList.Add(new ObservablePoint(x: point.SecondaryValue, y: point.PrimaryValue));
            //}
            //_graphModel.Series.Add(new ScatterSeries<ObservablePoint>() { Values = pointsList});
            await Task.Delay(3000);
            if( !_graphModel.Sections.Any() || index == _graphModel.Sections.First().Xi)
            {
                _graphModel.Sections.Clear();
                //_graphModel.Series.RemoveAt(_graphModel.Series.Count-1);
            }        
            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            _viewModel.UpdateValues();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            _viewModel.AddSeries();
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            _viewModel.RemoveSeries();
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            _viewModel.ChangeGraphicType();
        }

        private void Button_Clicked_4(object sender, EventArgs e)
        {
            _viewModel.ResetSeries();
        }
    }
}