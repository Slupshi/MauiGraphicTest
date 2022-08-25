using System.Runtime.CompilerServices;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace MauiGraphicTest
{
    public class CustomGraphLine : LineSeries<ObservableValue>
    {
        private readonly Random _random = new Random();
        public Color Color { get; set; }

        public CustomGraphLine(string name, IEnumerable<ObservableValue> values, bool isCurrency, SKColor color)
        {            
            Values = values;
            Fill = null;
            LineSmoothness = 0;
            Stroke = new SolidColorPaint
            {
                Color = new SKColor((byte)color.Red, (byte)color.Green, (byte)color.Blue),/*new SKColor((byte)_random.Next(255), (byte)_random.Next(255), (byte)_random.Next(255)),*/
                StrokeThickness = 2,
            };
            GeometrySize = 0;
            Name = name;
            TooltipLabelFormatter = delegate (LiveChartsCore.Kernel.ChartPoint<ObservableValue, LiveChartsCore.SkiaSharpView.Drawing.BezierPoint<LiveChartsCore.SkiaSharpView.Drawing.Geometries.CircleGeometry>, LiveChartsCore.SkiaSharpView.Drawing.Geometries.LabelGeometry> point) 
            {
                DefaultInterpolatedStringHandler defaultInterpolatedStringHandler2 = new DefaultInterpolatedStringHandler(1, 2);
                defaultInterpolatedStringHandler2.AppendLiteral(" ");
                defaultInterpolatedStringHandler2.AppendFormatted($"{point.PrimaryValue} {(isCurrency ? "€" : string.Empty)}");
                return defaultInterpolatedStringHandler2.ToStringAndClear();
            };
            Color = new Color(
                red: ((SolidColorPaint)Stroke).Color.Red, 
                green: ((SolidColorPaint)Stroke).Color.Green, 
                blue: ((SolidColorPaint)Stroke).Color.Blue);

        }
    }
}
