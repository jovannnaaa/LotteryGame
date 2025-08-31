using System.Drawing;

namespace LotteryGame
{
    public class Star
    {
        public Rectangle Bounds { get; set; }
        public int Speed { get; set; } = 10;
        public Brush Color { get; set; }

        public Star(int x, int y)
        {
            Bounds = new Rectangle(x - 10, y - 10, 20, 20);
            Color = Brushes.Blue;
        }

        public void Move()
        {
            Bounds = new Rectangle(Bounds.X, Bounds.Y - Speed, Bounds.Width, Bounds.Height);
        }

        public void Draw(Graphics g)
        {
            g.FillEllipse(Color, Bounds);
        }
    }
}
