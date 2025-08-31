using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LotteryGame
{
    public partial class ResultForm : Form
    {
        private List<int> selectedNumbers;
        private List<int> drawnNumbers;
        private List<int> hits;
        private string prize;
        private readonly GameMode mode;

        public ResultForm(List<int> selectedNumbers, List<int> drawnNumbers, List<int> hits, string prize)
        {
            this.selectedNumbers = selectedNumbers;
            this.drawnNumbers = drawnNumbers;
            this.hits = hits;
            this.prize = prize;
            this.mode = mode;

            InitializeComponent();
            BuildUI();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ResultForm
            // 
            this.BackgroundImage = global::LotteryGame.Properties.Resources.loto2;
            this.ClientSize = new System.Drawing.Size(1017, 503);
            this.Name = "ResultForm";
            this.Load += new System.EventHandler(this.ResultForm_Load);
            this.ResumeLayout(false);

        }

        private void BuildUI()
        {

            this.Text = "Резултати";
            this.Width = 500;
            this.Height = 300;
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblSelected = new Label()
            {
                Text = "Избрани броеви: " + string.Join(", ", selectedNumbers),
                AutoSize = true,
                Top = 20,
                Left = 20,
                Font = new Font("Segoe UI", 12, FontStyle.Regular)
            };
            this.Controls.Add(lblSelected);

            Label lblDrawn = new Label()
            {
                Text = "Извлечени броеви: " + string.Join(", ", drawnNumbers),
                AutoSize = true,
                Top = 60,
                Left = 20,
                Font = new Font("Segoe UI", 12, FontStyle.Regular)
            };
            this.Controls.Add(lblDrawn);

            Label lblHits = new Label()
            {
                Text = "Погодоци: " + (hits.Count > 0 ? string.Join(", ", hits) : "Нема"),
                AutoSize = true,
                Top = 100,
                Left = 20,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            this.Controls.Add(lblHits);

            if (mode == GameMode.Advanced)
            {
                Label lblPrize = new Label()
                {

                    Text = "Награда: " + prize,
                    AutoSize = true,
                    Top = 140,
                    Left = 20,
                    Font = new Font("Segoe UI", 12, FontStyle.Italic),
                    ForeColor = Color.DarkGreen
                };
                this.Controls.Add(lblPrize);
                Button btnClose = new Button()
                {

                    Text = "Продолжи на наградни игри",
                    Width = 100,
                    Height = 40,
                    Top = 200,
                    Left = 20
                };
                btnClose.Click += (s, e) => this.Close();
                this.Controls.Add(btnClose);

            }
            else if(mode == GameMode.Standard)
            {
                Label lblPrize = new Label()
                {
                    AutoSize = true,
                    Top = 140,
                    Left = 20,
                    Font = new Font("Segoe UI", 12, FontStyle.Italic),
                    ForeColor = Color.DarkGreen
                };
                this.Controls.Add(lblPrize);
                Button btnClose = new Button()
                {
                    Text = "Продолжи",
                    Width = 100,
                    Height = 40,
                    Top = 200,
                    Left = 20
                };
                btnClose.Click += (s, e) => this.Close();
                Controls.Add(btnClose);

            }
        }
           
        

        private void ResultForm_Load(object sender, EventArgs e)
        {

        }
    }
}
