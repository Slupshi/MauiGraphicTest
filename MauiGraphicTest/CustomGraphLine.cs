using System.Runtime.CompilerServices;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;

namespace MauiGraphicTest
{
    public class CustomGraphLine : LineSeries<ObservableValue>
    {
        public CustomGraphLine(string name, IEnumerable<ObservableValue> values, bool isCurrency)
        {            
            Values = values;
            Fill = null;
            LineSmoothness = 0;
            GeometrySize = 0;
            Name = name;
            TooltipLabelFormatter = delegate (LiveChartsCore.Kernel.ChartPoint<ObservableValue, LiveChartsCore.SkiaSharpView.Drawing.BezierPoint<LiveChartsCore.SkiaSharpView.Drawing.Geometries.CircleGeometry>, LiveChartsCore.SkiaSharpView.Drawing.Geometries.LabelGeometry> point) 
            {
                DefaultInterpolatedStringHandler defaultInterpolatedStringHandler2 = new DefaultInterpolatedStringHandler(1, 2);
                defaultInterpolatedStringHandler2.AppendLiteral(" ");
                defaultInterpolatedStringHandler2.AppendFormatted($"{point.PrimaryValue} {(isCurrency ? "€" : string.Empty)}");
                return defaultInterpolatedStringHandler2.ToStringAndClear();
            };
        }
    }
}
