using System.Drawing;

namespace LotteryGame
{
    public class LuckyStar
    {
        private string v1;
        private int v2;

        public Rectangle Bounds { get; set; }
        public int Number { get; set; }
        public bool IsHit { get; set; } = false;
        public Brush Color { get; set; }

        public LuckyStar(int number, int x, int y)
        {
            Number = number;
            Bounds = new Rectangle(x, y, 50, 50);
            Color = Brushes.Gold;
        }

        public LuckyStar(string v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public void Draw(Graphics g)
        {
            g.FillEllipse(Color, Bounds);
            g.DrawString(Number.ToString(), new Font("Segoe UI", 12, FontStyle.Bold), Brushes.Black, Bounds.X + 15, Bounds.Y + 15);
        }
    }
}
