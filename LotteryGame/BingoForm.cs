using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LotteryGame
{
    public partial class BingoForm : Form
    {
        private List<TextBox> inputs = new List<TextBox>();
        private Button btnCheck;
        private Label lblStatus;
        private string[] winningPattern = new string[] { "+", "-", "|", "+", "-", "|", "+" };

        public BingoForm()
        {
            InitializeForm();
            BuildUI();
        }

        private void InitializeForm()
        {
            this.Text = "Bingo - Bonus игра";
            this.Width = 600;
            this.Height = 300;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void BuildUI()
        {
            Label lbl = new Label()
            {
                Text = "Внеси комбинација (+, -, |) во 7 полиња:",
                Top = 20,
                Left = 20,
                AutoSize = true,
                Font = new Font("Segoe UI", 12, FontStyle.Regular)
            };
            this.Controls.Add(lbl);

            int startX = 20;
            int startY = 60;
            int width = 60;

            inputs.Clear();
            for (int i = 0; i < 7; i++)
            {
                var tb = new TextBox()
                {
                    Width = width,
                    Height = 30,
                    Left = startX + i * (width + 10),
                    Top = startY,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    TextAlign = HorizontalAlignment.Center
                };
                this.Controls.Add(tb);
                inputs.Add(tb);
            }

            btnCheck = new Button()
            {
                Text = "Проверка",
                Width = 120,
                Height = 40,
                Left = startX,
                Top = startY + 60
            };
            btnCheck.Click += BtnCheck_Click;
            this.Controls.Add(btnCheck);

            lblStatus = new Label()
            {
                Text = "",
                Top = startY + 120,
                Left = startX,
                AutoSize = true,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            this.Controls.Add(lblStatus);
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            var userInput = inputs.Select(tb => tb.Text.Trim()).ToArray();
            if (userInput.SequenceEqual(winningPattern))
            {
                lblStatus.Text = "Честитки! Bingo! Победивте!";
                lblStatus.ForeColor = Color.Green;
            }
            else
            {
                lblStatus.Text = "Невалидна комбинација. Пробај повторно.";
                lblStatus.ForeColor = Color.Red;
            }
        }

        private void BingoForm_Load(object sender, EventArgs e)
        {

        }
    }
}
