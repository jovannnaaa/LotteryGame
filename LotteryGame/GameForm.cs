using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LotteryGame
{
    public partial class GameForm : Form
    {
        private readonly GameMode mode;
        private readonly List<int> selectedNumbers = new List<int>();
        private readonly List<int> drawnNumbers = new List<int>();
        private readonly Random rng = new Random();

        private Panel pnlBalls;
        private Button btnDraw;
        private Button btnReset;
        private Label lblStatus;
        private List<Button> ballButtons = new List<Button>();
        private List<Player> visualDrawn = new List<Player>();
        private AIHost host;
        private List<LuckyStar> jockerCards = new List<LuckyStar>();
        private LuckyStar selectedJocker;


        public GameForm(GameMode mode)
        {
            this.mode = mode;
            InitializeForm();
            BuildUI();
            host = new AIHost("Играч");
            lblStatus.Text = host.SaySomething();

        }

        public GameForm()
        {
        }

        private void InitializeForm()
        {
            Text = $"Лото 7 — {mode}";
            Width = 820;
            Height = 520;
            StartPosition = FormStartPosition.CenterScreen;
            DoubleBuffered = true;
        }

        private void BuildUI()
        {
            pnlBalls = new Panel
            {
                Left = 20,
                Top = 20,
                Width = 760,
                Height = 140,
                BorderStyle = BorderStyle.None
            };
            Controls.Add(pnlBalls);

            
            ballButtons.Clear();
            for (int i = 1; i <= 10; i++)
            {
                var b = new Button
                {
                    Text = i.ToString(),
                    Width = 60,
                    Height = 60,
                    Tag = i,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    BackColor = SystemColors.Control,
                    Left = 20 + (i - 1) * 72,
                    Top = 20
                };
                b.Click += BallButton_Click;
                pnlBalls.Controls.Add(b);
                ballButtons.Add(b);
            }

            btnDraw = new Button
            {
                Text = "Извлечи (Draw)",
                Left = 20,
                Top = pnlBalls.Bottom + 20,
                Width = 160,
                Height = 40,
                Enabled = true
            };
            btnDraw.Click += BtnDraw_Click;
            Controls.Add(btnDraw);

            btnReset = new Button
            {
                Text = "Нова игра (Reset)",
                Left = btnDraw.Right + 12,
                Top = btnDraw.Top,
                Width = 160,
                Height = 40
            };
            btnReset.Click += BtnReset_Click;
            Controls.Add(btnReset);

            lblStatus = new Label
            {
                Text = "Избери 7 броја (1..10).",
                Left = btnReset.Right + 12,
                Top = btnDraw.Top + 8,
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Italic)
            };
            Controls.Add(lblStatus);

            // Листа каде ќе ги прикажеме исцртани (визуелно)
            // visualDrawn се Player објекти кои ќе се цртаат во OnPaint
            visualDrawn.Clear();

            // за да се може да се цртаат, регистрираме Paint event
            this.Paint += GameForm_Paint;
           
            jockerCards.Clear();
            jockerCards.Add(new LuckyStar("Sunshine", rng.Next(1, 11)));
            jockerCards.Add(new LuckyStar("Lucky Star", rng.Next(1, 11)));
            jockerCards.Add(new LuckyStar("Golden Coin", rng.Next(1, 11)));
            jockerCards.Add(new LuckyStar("Fortune Wheel", rng.Next(1, 11)));
        
        }

        private void BallButton_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            int num = (int)btn.Tag;

            if (selectedNumbers.Contains(num))
            {
                selectedNumbers.Remove(num);
                btn.BackColor = SystemColors.Control;
            }
            else
            {
                if (selectedNumbers.Count >= 7)
                {
                    MessageBox.Show("Веќе избра 7 броја. Можете да де-селектирате некој ако сакате да смените.");
                    return;
                }

                selectedNumbers.Add(num);
                btn.BackColor = Color.LightGreen;
            }

            lblStatus.Text = $"Избрани: {string.Join(", ", selectedNumbers)} ({selectedNumbers.Count}/7)";
        }

        private async void BtnDraw_Click(object sender, EventArgs e)
        {
            if (selectedNumbers.Count != 7)
            {
                MessageBox.Show("Мора да избереш точно 7 броеви пред извлекувањето.");
                return;
            }

            btnDraw.Enabled = false;
            lblStatus.Text = "Извлекување...";

            // анимација - step reveal: испаѓаат едно по едно со ефект
            drawnNumbers.Clear();
            visualDrawn.Clear();
            var pool = Enumerable.Range(1, 10).ToList();

            
            await AnimateShuffle(pool);

            for (int i = 0; i < 7; i++)
            {
                await Task.Delay(600); // пауза помеѓу откривањата
                int idx = rng.Next(0, pool.Count);
                int num = pool[idx];
                pool.RemoveAt(idx);
                drawnNumbers.Add(num);

                // додади визуелен Player топка на позиција (исцртување по ред)
                int size = 60;
                int startX = 20;
                int y = 220;
                int x = startX + i * (size + 12);
                var color = new SolidBrush(Color.FromArgb(rng.Next(80, 230), rng.Next(80, 230), rng.Next(80, 230)));
                visualDrawn.Add(new Player(num, x, y, size, color));

                lblStatus.Text = $"Извлечен број: {num} ({i + 1}/7)";
                Invalidate();
                lblStatus.Text = host.AnnounceDraw(num, i);

            }

            // резултати
            //await Task.Delay(400);
            ShowResults();
            btnDraw.Enabled = true;
        }

        // кратка "шема" на измамен shuffle анимација
        private async Task AnimateShuffle(List<int> pool)
        {
            // визуелно заменувај бројки на првата позиција неколку пати
            int flashes = 12;
            int size = 60;
            int y = 220;
            int x = 20;
            for (int k = 0; k < flashes; k++)
            {
                int temp = pool[rng.Next(pool.Count)];
                visualDrawn.Clear();
                visualDrawn.Add(new Player(temp, x, y, size, Brushes.Gray));
                Invalidate();
                await Task.Delay(60 + k * 5);
            }
            visualDrawn.Clear();
            Invalidate();
        }

        private void ShowResults()
        {
            // спореди избрани vs извлечени броеви
            var hits = selectedNumbers.Intersect(drawnNumbers).OrderBy(x => x).ToList();
            int matches = hits.Count;

            string prize = " ";

            if (matches >= 3)
            {
                prize = "Bingo!";
            }
          
          

            // отвори ResultsForm
            var results = new ResultForm(selectedNumbers, drawnNumbers, hits, prize);
            results.FormClosed += (s, e) =>
            {
                // ако е Advanced и Jackpot -> отвори BingoForm
                if (mode == GameMode.Advanced)
                {
                    using (var bingo = new BingoForm())
                    {
                        bingo.ShowDialog();
                    }
                }
            };
            lblStatus.Text = host.AnnounceResult(selectedNumbers, drawnNumbers, matches);
            if (mode == GameMode.Advanced)
            {

                var h = selectedNumbers.Intersect(drawnNumbers).OrderBy(x => x).ToList();
                int m = h.Count;

                string prizeBonus;
                if (m >= 3)
                    prizeBonus = "Bingo!";
                else
                    prizeBonus = "Пробај повторно!";

                var result = new ResultsForm(selectedNumbers, drawnNumbers, h, prize);

                results.FormClosed += (s, e) =>
                {
                    // Ако сме во Advanced 
                    if (mode == GameMode.Advanced )
                    {
                        // Отвори BonusForm со 7 извлечени броја како stars
                        using (var bonus = new BonusForm(drawnNumbers))
                        {
                            bonus.ShowDialog();
                        }
                    }
                };

                results.ShowDialog();
            }



            results.ShowDialog();
        }

        private void InitializeJockerCards()
        {
            throw new NotImplementedException();
        }

        private bool HasConsecutive(List<int> hits)
        {
            if (hits.Count < 3) return false;
            int streak = 1;
            for (int i = 1; i < hits.Count; i++)
            {
                if (hits[i] == hits[i - 1] + 1) streak++;
                else streak = 1;
                if (streak >= 3) return true;
            }
            return false;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            selectedNumbers.Clear();
            drawnNumbers.Clear();
            visualDrawn.Clear();
            foreach (var b in ballButtons) b.BackColor = SystemColors.Control;
            lblStatus.Text = "Избери 7 броја (1..10).";
            Invalidate();
        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            
            foreach (var ball in visualDrawn)
            {
                ball.Draw(e.Graphics);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // GameForm
            // 
            this.BackgroundImage = global::LotteryGame.Properties.Resources.loto2;
            this.ClientSize = new System.Drawing.Size(1017, 506);
            this.Font = new System.Drawing.Font("Stencil", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "GameForm";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.ResumeLayout(false);

        }


        private void GameForm_Load(object sender, EventArgs e)
        {

        }
    }
}
