using System;
using System.Drawing;

namespace LotteryGame
{
    public class Player
    {
        private int v1;
        private int v2;
        private int v3;
        private Brush blue;

        public int Number { get; set; }
        public Rectangle Bounds { get; set; }
        public Brush Color { get; set; }

        public Player(int number, int x, int y, int size, Brush color)
        {
            Number = number;
            Bounds = new Rectangle(x, y, size, size);
            Color = color ?? Brushes.Blue;
        }

        public Player(int v1, int v2, int v3, Brush blue)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.blue = blue;
        }

        public void Draw(Graphics g)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.FillEllipse(Color, Bounds);
            using (var pen = new Pen(Color, 2))
                g.DrawEllipse(pen, Bounds);

            using (var font = new Font("Segoe UI", 12, FontStyle.Bold))
            using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                // бројот бели буквички - ако бојата е светла ќе биде црн број
                g.DrawString(Number.ToString(), font, Brushes.White, Bounds, sf);
            }
        }

        internal void MoveTo(int x)
        {
            throw new NotImplementedException();
        }
    }
}
