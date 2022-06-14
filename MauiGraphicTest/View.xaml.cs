using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

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
                NamePadding = new LiveChartsCore.Drawing.Padding(20),
                NameTextSize = 25,
                MinStep = 1,
                ShowSeparatorLines = false,
                Labels = new string[] { "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi", "Dimanche" },

            };
            GraphicChart.YAxes = new List<Axis> { yAxis };
            GraphicChart.XAxes = new List<Axis> { xAxis };
            //GraphicChart.DataPointerDown += GraphicChart_DataPointerDown;

            
        }

        private void GraphicChart_DataPointerDown(LiveChartsCore.Kernel.Sketches.IChartView chart, IEnumerable<LiveChartsCore.Kernel.ChartPoint> points)
        {
            double index = points.First().SecondaryValue;
        }
    }
}