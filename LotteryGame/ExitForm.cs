using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LotteryGame
{
    public partial class GameOverForm : Form
    {
        private readonly List<int> chosenNumbers;   
        private readonly List<int> drawnNumbers;   
        private readonly int matches;               

        public GameOverForm(List<int> chosenNumbers, List<int> drawnNumbers, int matches)
        {
            InitializeComponent();
            this.chosenNumbers = chosenNumbers;
            this.drawnNumbers = drawnNumbers;
            this.matches = matches;

            this.StartPosition = FormStartPosition.CenterScreen;
            ShowResults();
            this.ActiveControl = null;
        }

        private void ShowResults()
        {
          
            tbChosen.Text = "ИЗбрани броеви: " + string.Join(", ", chosenNumbers);

            
            tbDrawn.Text = "Извлечени броеви: " + string.Join(", ", drawnNumbers);

          
            tbResult.Text = $"Погодоци: {matches}";
        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameForm lotoForm = new GameForm();
            lotoForm.FormClosed += (s, args) => this.Close();
            lotoForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

     
        private void pictureBox1_Click(object sender, EventArgs e) { }

        private void GameOverForm_Load(object sender, EventArgs e)
        {

        }
    }
}
