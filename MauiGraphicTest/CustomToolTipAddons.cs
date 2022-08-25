using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting.Effects;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using LiveChartsCore.Defaults;
using System.Collections.ObjectModel;

namespace MauiGraphicTest
{
    public class CustomToolTipAddons
    {
        public static RectangularSection CreateDashLine(double index)
        {
            return new RectangularSection()
            {
                Xi = index,
                Xj = index,
                Stroke = new SolidColorPaint
                {
                    Color = SKColors.Gray,
                    StrokeThickness = 2,
                    PathEffect = new DashEffect(new float[] { 5, 9 })
                }
            };
        }

        public static ScatterSeries<ObservablePoint> CreateIntersectionPoints(ObservableCollection<ObservablePoint> pointsList)
        {
            return new ScatterSeries<ObservablePoint>()
            { 
                Values = pointsList, 
                Name = "Points",
                Stroke = new SolidColorPaint
                {
                    Color = SKColors.Gray,
                    StrokeThickness = 2,
                },
                Fill = new SolidColorPaint
                {
                    Color = SKColors.Gray
                },
                GeometrySize = 10,
                
            };
        }


    }

}
