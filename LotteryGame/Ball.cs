using System;
using System.Drawing;

namespace LotoGame
{
    public class Ball
    {
        public int Number { get; set; }        // Бројот што го има топката
        public Rectangle Bounds { get; set; }  // Позицијата и големината на топката
        public Brush Color { get; set; }       // Боја на топката

        public Ball(int number, Rectangle bounds, Brush color)
        {
            Number = number;
            Bounds = bounds;
            Color = color;
        }

        public void Draw(Graphics g)
        {
            
            g.FillEllipse(Color, Bounds);

            
            using (Font font = new Font("Arial", 12, FontStyle.Bold))
            using (StringFormat sf = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            })
            {
                g.DrawString(Number.ToString(), font, Brushes.White, Bounds, sf);
            }
        }
    }
}
