using Antialiasing_app.Tools;
using Editor2D.Interfaces;
using System;
using System.Drawing;

namespace Antialiasing_app.Graphic_classes
{
    public class Point2D : IDrawable2DObject
    {
        private PointF startPosition;
        private PointF location;

        public bool Antialiased;
        public Color Color; 

        public Point2D(PointF pointPosition)
        {
            startPosition = pointPosition;
        }

        public void Draw(Graphics g)
        {
            if (Antialiased)
            {
                using (var b = new SolidBrush(Color))
                {
                    float dotX = Math.Abs(location.X % 1);
                    float dotY = Math.Abs(location.Y % 1);

                    if (location.X < 0)
                        dotX = 1 - dotX;

                    if (location.Y > 0)
                        dotY = 1 - dotY;

                    Point p = Math2DCalculations.WorldCoordToWindowCoord(location);

                    // prostredna pozicia bodu
                    g.FillRectangle(b, p.X, p.Y, 1, 1);

                    // lavy horny pixel
                    GetBrushByAlpha(b, (1.0f - dotX) * (1.0f - dotY), Color);
                    g.FillRectangle(b, p.X - 1, p.Y - 1, 1, 1);

                    // stredny horny pixel
                    GetBrushByAlpha(b, 1.0f - dotY, Color);
                    g.FillRectangle(b, p.X, p.Y - 1, 1, 1);

                    // pravy horny pixel
                    GetBrushByAlpha(b, dotX * (1.0f - dotY), Color);
                    g.FillRectangle(b, p.X + 1, p.Y - 1, 1, 1);

                    // lavy stredny pixel
                    GetBrushByAlpha(b, 1.0f - dotX, Color);
                    g.FillRectangle(b, p.X - 1, p.Y, 1, 1);

                    // pravy stredny pixel
                    GetBrushByAlpha(b, dotX, Color);
                    g.FillRectangle(b, p.X + 1, p.Y, 1, 1);

                    // lavy dolny pixel
                    GetBrushByAlpha(b, (1.0f - dotX) * dotY, Color);
                    g.FillRectangle(b, p.X - 1, p.Y + 1, 1, 1);

                    // stredny dolny pixel
                    GetBrushByAlpha(b, dotY, Color);
                    g.FillRectangle(b, p.X, p.Y + 1, 1, 1);

                    // pravy dolny pixel
                    GetBrushByAlpha(b, dotX * dotY, Color);
                    g.FillRectangle(b, p.X + 1, p.Y + 1, 1, 1);
                }
            }
            else
            {
                Point p = Math2DCalculations.WorldCoordToWindowCoord(location);

                using (var b = new SolidBrush(Color))
                {
                    g.FillRectangle(b, p.X, p.Y, 1, 1);
                    g.FillRectangle(b, p.X + 1, p.Y, 1, 1);
                    g.FillRectangle(b, p.X, p.Y + 1, 1, 1);
                    g.FillRectangle(b, p.X + 1, p.Y + 1, 1, 1);
                }
            }
        }

        /// <summary>
        /// Calculate aphla channel for anti aliasing
        /// </summary>
        /// <param name="b"></param>
        /// <param name="alpha"></param>
        /// <param name="baseColor"></param>
        private void GetBrushByAlpha(SolidBrush b, float alpha, Color baseColor)
        {
            int colorAlpha = (int)(alpha * 255);
            b.Color = Color.FromArgb(colorAlpha, baseColor);
        }

        /// <summary>
        /// Rotacia bodov
        /// </summary>
        /// <param name="elapsedTime"></param>
        /// <param name="rotationSpeed"></param>
        public void Rotate(long elapsedTime, int rotationSpeed)
        {
            double alpha = rotationSpeed * Math.PI / 180 * elapsedTime / 1000;

            location = new PointF(
                (float)(startPosition.X * Math.Cos(alpha) - startPosition.Y * Math.Sin(alpha)),
                (float)(startPosition.X * Math.Sin(alpha) + startPosition.Y * Math.Cos(alpha)));
        }
    }
}
