using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LotteryGame
{
    public class BonusForm : Form
    {
        private List<LuckyStar> stars = new List<LuckyStar>();
        private List<Star> projectiles = new List<Star>();
        private Timer gameTimer;
        private Random rng = new Random();
        private int score = 0;

        private int playerX;

        public BonusForm(List<int> luckyNumbers)
        {
            this.Width = 600;
            this.Height = 500;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.DoubleBuffered = true;
            this.Text = "Bonus Game: Shoot Lucky Numbers";

            // позиционирање на stars (ѕвезди)
            int y = 50;
            for (int i = 0; i < luckyNumbers.Count; i++)
            {
                int x = 50 + i * 80;
                stars.Add(new LuckyStar(luckyNumbers[i], x, y));
            }

            gameTimer = new Timer();
            gameTimer.Interval = 30;
            gameTimer.Tick += GameLoop;
            gameTimer.Start();

            this.Paint += BonusForm_Paint;

            this.MouseMove += (s, e) => { playerX = e.X; };
            this.MouseClick += (s, e) => { projectiles.Add(new Star(playerX, this.Height - 50)); };
        }

        public BonusForm()
        {
        }

        private void GameLoop(object sender, EventArgs e)
        {
            foreach (var p in projectiles.ToList())
            {
                p.Move();

                foreach (var star in stars.Where(s => !s.IsHit))
                {
                    if (p.Bounds.IntersectsWith(star.Bounds))
                    {
                        star.IsHit = true;
                        score += 10;
                        projectiles.Remove(p);
                        break;
                    }
                }

                if (p.Bounds.Top < 0)
                    projectiles.Remove(p);
            }

            this.Invalidate();
        }

        private void BonusForm_Paint(object sender, PaintEventArgs e)
        {
            // цртај stars
            foreach (var s in stars)
                if (!s.IsHit)
                    s.Draw(e.Graphics);

            // цртај projectiles
            foreach (var p in projectiles)
                p.Draw(e.Graphics);

            // цртај играч (shooter)
            e.Graphics.FillRectangle(Brushes.Green, playerX - 20, this.Height - 40, 40, 20);

            e.Graphics.DrawString($"Score: {score}", new Font("Segoe UI", 14, FontStyle.Bold), Brushes.Black, 10, 10);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BonusForm
            // 
            this.BackgroundImage = global::LotteryGame.Properties.Resources.loto2;
            this.ClientSize = new System.Drawing.Size(1027, 500);
            this.Name = "BonusForm";
            this.ResumeLayout(false);

        }
    }
}
