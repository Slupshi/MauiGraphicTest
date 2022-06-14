using System.Runtime.CompilerServices;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace MauiGraphicTest
{
    public class CustomGraphLine : LineSeries<double>
    {
        public CustomGraphLine(string name, IEnumerable<double> values)
        {            
            Values = values;
            Fill = null;
            LineSmoothness = 0;
            GeometrySize = 0;
            Name = name;
            TooltipLabelFormatter = delegate (LiveChartsCore.Kernel.ChartPoint<double, LiveChartsCore.SkiaSharpView.Drawing.BezierPoint<LiveChartsCore.SkiaSharpView.Drawing.Geometries.CircleGeometry>, LiveChartsCore.SkiaSharpView.Drawing.Geometries.LabelGeometry> point) 
            {
                DefaultInterpolatedStringHandler defaultInterpolatedStringHandler2 = new DefaultInterpolatedStringHandler(1, 2);
                defaultInterpolatedStringHandler2.AppendLiteral(" ");
                defaultInterpolatedStringHandler2.AppendFormatted($"{point.PrimaryValue} €");
                return defaultInterpolatedStringHandler2.ToStringAndClear();
            };
        }
    }
}
