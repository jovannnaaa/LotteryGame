using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LotteryGame
{
    public partial class ModeSelectionForm: Form
    {
        public ModeSelectionForm()
        {
            InitializeComponent();
        }

        private void btnStandard_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameForm gameForm = new GameForm(GameMode.Standard);
            gameForm.FormClosed += (s, args) => this.Close();
            gameForm.Show();
        }

        private void btnAdvanced_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameForm gameForm = new GameForm(GameMode.Advanced);
            gameForm.FormClosed += (s, args) => this.Close();
            gameForm.Show();
        }

        private void ModeSelectionForm_Load(object sender, EventArgs e)
        {

        }
    }
}
