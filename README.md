LotteryGame
Јована Мечева(231124)
1. Објаснување на играта
   
Lottery Game е игра во која играчот погодува 7 среќни броеви(лото броеви), при што за најдобрата комбинација од погодени броеви следуваат наградни Бонус игри.
Оваа игра е инспирирана од популарните Лото игри достапни на различни платформи каде што играчот игра за да постигне што е можно поголем резултат.

2. Функционалности и упатство

Два режими на играта:
Standard Mode:
Во Standard режим, играчот едноставно ги избира бројките и гледа резултати на извлекувањето, со можност за визуелно прикажување на погодените броеви.
Advanced Mode:
Во Advanced режим, ако играчот ја погоди целата комбинација, се активираaт бонус игри (Бинго игри), каде што играчот може да погодува комбинација од знаци или „пука“ визуелни топчиња кон среќните броеви за дополнителни поени.

3. Опис на решението
Форми
StartForm:
Оваа форма е почетниот екран на играта. На корисникот му овозможува да започне нова игра или да излезе од апликацијата. Служи како вовед и почетна точка за сите корисници.

ModeSelectionForm:
Оваа форма се прикажува веднаш по StartForm и овозможува избор на режим на игра Standard или Advanced. Со клик на едно од копчињата, корисникот го избира саканиот режим и продолжува кон главната игра.

GameForm:
Ова е главната форма каде што се главниот дел од играта.Овде играчот ги бира своите 7 среќни броеви и во зависност од изборот на режим продолжува напред или се ги добива своите резултати.

ResultForm:
Оваа форма се прикажува по завршување на главната лотарија односно пред играчот да заврши ја целосно играта или да продолжи кон бонус игрите. 
На неа се прикажува резултатот на играчот (поените), и се нудат опции за повторно започнување на играта, продолжување на бонус иргите или евентуално излез.

Bingo/BonusForm:
Bonus игра која се појавува ако играчот избере Advanced mode.Прикажува бонус игра за погодок на скриена шема.Исто така се пукаат броеви кои му се додаваат на вкупниот резултат на играчот.Дава дополнителни поени или награда.

Класи
Player:
Класата Player ги чува податоците за тековниот играч.Содржи: Name – името на играчот, ChosenNumbers – листа на избрани броеви,Points – поени од играта. Исто така вклучува и метод за проверка колку броеви се погодени и метод за зголемување на поени.

Ball:
Претставува една топка во играта, со свој број, боја и позиција. Се користи за графичко прикажување на извлечените броеви.

GameMode:
Enum што ги дефинира можните режими на играта односно Standard и Advanced. Се користи за да ги оддели двата режими на игра.

AIHost:
Класата има улога да симулира водител кој коментира при извлекувањето на броевите, резултатите и слично

LuckyStar:
Оваа класа ја моделира специјална "бинго/бонус ѕвезда" која може да се појави како бонус елемент во играта. Таа има свој број, позиција на формата и изглед (цртана со златна боја).

4. Опис на функција од изворниот код
   namespace LotteryGame
{
    public partial class GameForm : Form
    {
        // == ПОЛИЊА (Fields) ==
        private readonly GameMode mode;                 // Режим на игра: Standard или Advanced
        private readonly List<int> selectedNumbers = new List<int>(); // Избрани броеви од играчот
        private readonly List<int> drawnNumbers = new List<int>();    // Извлечени броеви
        private readonly Random rng = new Random();    // Random генератор за броевите

        // UI елементи
        private Panel pnlBalls;         // Панел каде се ставаат копчињата со броеви
        private Button btnDraw;         // Копче за "Извлечи"
        private Button btnReset;        // Копче за "Нова игра"
        private Label lblStatus;        // Label за статусни пораки

        private List<Button> ballButtons = new List<Button>(); // Сите копчиња за броеви
        private List<Player> visualDrawn = new List<Player>(); // Визуелни објекти за извлечените топчиња
        private AIHost host;            // "водител" кој дава пораки
        private List<LuckyStar> jockerCards = new List<LuckyStar>(); // Бонус карти (ѕвезди)
        private LuckyStar selectedJocker; // Селектирана џокер картичка (ако има)

        // == КОНСТРУКТОРИ ==
        public GameForm(GameMode mode)
        {
            this.mode = mode;
            InitializeForm();   // иницијализација на прозорецот
            BuildUI();          // градба на интерфејсот
            host = new AIHost("Играч");
            lblStatus.Text = host.SaySomething(); // Порака од водителот
        }

        public GameForm() { } // празен конструктор ако не е даден режим

        // == ИНИЦИЈАЛИЗАЦИЈА НА ФОРМАТА ==
        private void InitializeForm()
        {
            Text = $"Лото 7 — {mode}";
            Width = 820;
            Height = 520;
            StartPosition = FormStartPosition.CenterScreen;
            DoubleBuffered = true; // за да нема "трепкање" при цртање
        }

        // == UI ГРАДБА ==
        private void BuildUI()
        {
            // Панел за броеви
            pnlBalls = new Panel
            {
                Left = 20, Top = 20,
                Width = 760, Height = 140,
                BorderStyle = BorderStyle.None
            };
            Controls.Add(pnlBalls);

            // Копчиња со броеви 1–10
            ballButtons.Clear();
            for (int i = 1; i <= 10; i++)
            {
                var b = new Button
                {
                    Text = i.ToString(),
                    Width = 60, Height = 60,
                    Tag = i, // го користиме како број
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    BackColor = SystemColors.Control,
                    Left = 20 + (i - 1) * 72,
                    Top = 20
                };
                b.Click += BallButton_Click; // настан при клик
                pnlBalls.Controls.Add(b);
                ballButtons.Add(b);
            }

            // Копче за извлекување
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

            // Копче за ресетирање
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

            // Label за статусни пораки
            lblStatus = new Label
            {
                Text = "Избери 7 броја (1..10).",
                Left = btnReset.Right + 12,
                Top = btnDraw.Top + 8,
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Italic)
            };
            Controls.Add(lblStatus);

            // Listener за Paint -> црта извлечени топчиња
            this.Paint += GameForm_Paint;

            // Иницијализација на џокер картички
            jockerCards.Clear();
            jockerCards.Add(new LuckyStar("Sunshine", rng.Next(1, 11)));
            jockerCards.Add(new LuckyStar("Lucky Star", rng.Next(1, 11)));
            jockerCards.Add(new LuckyStar("Golden Coin", rng.Next(1, 11)));
            jockerCards.Add(new LuckyStar("Fortune Wheel", rng.Next(1, 11)));
        }

        // == СЕЛЕКТИРАЊЕ БРОЕВИ ==
        private void BallButton_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            int num = (int)btn.Tag;

            if (selectedNumbers.Contains(num))
            {
                // ако бројот е веќе избран -> отстрани
                selectedNumbers.Remove(num);
                btn.BackColor = SystemColors.Control;
            }
            else
            {
                // дозволени се само 7 броеви
                if (selectedNumbers.Count >= 7)
                {
                    MessageBox.Show("Веќе избра 7 броја. Де-селектирај некој за промена.");
                    return;
                }
                selectedNumbers.Add(num);
                btn.BackColor = Color.LightGreen;
            }

            lblStatus.Text = $"Избрани: {string.Join(", ", selectedNumbers)} ({selectedNumbers.Count}/7)";
        }

        // == ИЗВЛЕКУВАЊЕ БРОЕВИ ==
        private async void BtnDraw_Click(object sender, EventArgs e)
        {
            if (selectedNumbers.Count != 7)
            {
                MessageBox.Show("Мора да избереш точно 7 броеви!");
                return;
            }

            btnDraw.Enabled = false;
            lblStatus.Text = "Извлекување...";

            drawnNumbers.Clear();
            visualDrawn.Clear();
            var pool = Enumerable.Range(1, 10).ToList(); // сите броеви 1–10

            // мала анимација shuffle
            await AnimateShuffle(pool);

            // извлечи 7 броеви
            for (int i = 0; i < 7; i++)
            {
                await Task.Delay(600);
                int idx = rng.Next(0, pool.Count);
                int num = pool[idx];
                pool.RemoveAt(idx);
                drawnNumbers.Add(num);

                // додај визуелна топка
                int size = 60;
                int x = 20 + i * (size + 12);
                int y = 220;
                var color = new SolidBrush(Color.FromArgb(
                    rng.Next(80, 230),
                    rng.Next(80, 230),
                    rng.Next(80, 230)));
                visualDrawn.Add(new Player(num, x, y, size, color));

                lblStatus.Text = host.AnnounceDraw(num, i); // порака од водителот
                Invalidate(); // прецртај
            }

            ShowResults(); // прикажи резултати
            btnDraw.Enabled = true;
        }

        // == Shuffle анимација ==
        private async Task AnimateShuffle(List<int> pool)
        {
            int flashes = 12;
            int size = 60;
            int x = 20, y = 220;
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

        // == Приказ на резултати ==
        private void ShowResults()
        {
            var hits = selectedNumbers.Intersect(drawnNumbers).OrderBy(x => x).ToList();
            int matches = hits.Count;
            string prize = matches >= 3 ? "Bingo!" : " ";

            // Отворање форма за резултати
            var results = new ResultForm(selectedNumbers, drawnNumbers, hits, prize);

            // ако е Advanced -> може бонус игра
            results.FormClosed += (s, e) =>
            {
                if (mode == GameMode.Advanced)
                {
                    using (var bonus = new BonusForm(drawnNumbers))
                        bonus.ShowDialog();
                }
            };

            lblStatus.Text = host.AnnounceResult(selectedNumbers, drawnNumbers, matches);
            results.ShowDialog();
        }

        // == Reset ==
        private void BtnReset_Click(object sender, EventArgs e)
        {
            selectedNumbers.Clear();
            drawnNumbers.Clear();
            visualDrawn.Clear();
            foreach (var b in ballButtons) b.BackColor = SystemColors.Control;
            lblStatus.Text = "Избери 7 броја (1..10).";
            Invalidate();
        }

        // == Цртање извлечени топчиња ==
        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            foreach (var ball in visualDrawn)
                ball.Draw(e.Graphics);
        }
    }
}
5.Слики
<img width="963" height="542" alt="image" src="https://github.com/user-attachments/assets/bd13cbe9-6131-4d2e-83a7-868e9a248be2" />
<img width="937" height="552" alt="image" src="https://github.com/user-attachments/assets/57508ce7-bf16-497f-934c-aa86746e032b" />
<img width="989" height="629" alt="image" src="https://github.com/user-attachments/assets/91bca113-1520-4f04-b1b2-2b51b5b36cc5" />
<img width="608" height="364" alt="image" src="https://github.com/user-attachments/assets/1b6492a6-dd55-4a27-8436-2baa8e4e5048" />
<img width="725" height="490" alt="image" src="https://github.com/user-attachments/assets/709a2487-ac7e-46d0-b74b-24ce3bf2acc8" />









