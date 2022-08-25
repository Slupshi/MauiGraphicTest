using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveChartsCore.Kernel;
using LiveChartsCore.SkiaSharpView.Drawing;
using LiveChartsCore.SkiaSharpView.Maui;

namespace MauiGraphicTest
{
    public class CustomGraphCanvas : GraphicsView ,IDrawable
    {
        public static readonly BindableProperty PaintColorProperty = BindableProperty.Create(nameof(PaintColor), typeof(Color), typeof(CustomGraphCanvas), new Color(0,0,255), BindingMode.OneWay, propertyChanged: OnPaintColorChanged);
        public Color PaintColor
        {
            get
            {
                return (Color)GetValue(PaintColorProperty);
            }
            set
            {
                SetValue(PaintColorProperty, value);
            }
        }

        private static void OnPaintColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var canvas = bindable as CustomGraphCanvas;
            canvas.PaintColor = (Color)newValue;
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.StrokeColor = PaintColor;
            canvas.StrokeSize = 2;
            canvas.DrawLine(0, 5, 30, 5);
        }
    }
}
