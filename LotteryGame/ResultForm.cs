using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LotteryGame
{
    public partial class ResultsForm : Form
    {
        private readonly List<int> chosen;
        private readonly List<int> drawn;
        private readonly List<int> hits;
        private readonly string prize;

        public ResultsForm(List<int> chosenNumbers, List<int> drawnNumbers, List<int> hits, string prize)
        {
            this.chosen = new List<int>(chosenNumbers);
            this.drawn = new List<int>(drawnNumbers);
            this.hits = new List<int>(hits);
            this.prize = prize;

            Initialize();
            ShowData();
        }

        private void Initialize()
        {
            Text = "Резултати";
            Width = 520;
            Height = 360;
            StartPosition = FormStartPosition.CenterParent;

            var lblChosen = new Label() { Left = 20, Top = 20, Width = 460, Font = new Font("Segoe UI", 10) };
            lblChosen.Name = "lblChosen";
            Controls.Add(lblChosen);

            var lblDrawn = new Label() { Left = 20, Top = 60, Width = 460, Font = new Font("Segoe UI", 10) };
            Controls.Add(lblDrawn);

            var lblHits = new Label() { Left = 20, Top = 100, Width = 460, Font = new Font("Segoe UI", 12, FontStyle.Bold) };
            Controls.Add(lblHits);

            var lblPrize = new Label() { Left = 20, Top = 140, Width = 460, Height = 60, Font = new Font("Segoe UI", 11, FontStyle.Italic) };
            Controls.Add(lblPrize);

            var btnClose = new Button() { Text = "Затвори", Left = 200, Top = 220, Width = 120 };
            btnClose.Click += (s, e) => Close();
            Controls.Add(btnClose);

            // assign to fields via Tag for quick access
            lblChosen.Tag = "lblChosen";
            lblDrawn.Tag = "lblDrawn";
            lblHits.Tag = "lblHits";
            lblPrize.Tag = "lblPrize";

            // store references
            this.Controls["lblChosen"].Name = "lblChosen";
        }

        private void ShowData()
        {
            var lblChosen = Controls.OfType<Label>().First(l => l.Top == 20);
            var lblDrawn = Controls.OfType<Label>().First(l => l.Top == 60);
            var lblHits = Controls.OfType<Label>().First(l => l.Top == 100);
            var lblPrize = Controls.OfType<Label>().First(l => l.Top == 140);

            lblChosen.Text = "Твои броеви: " + string.Join(", ", chosen.OrderBy(x => x));
            lblDrawn.Text = "Извлечени броеви: " + string.Join(", ", drawn.OrderBy(x => x));
            lblHits.Text = $"Погодени броеви: {hits.Count} -> {string.Join(", ", hits)}";
            lblPrize.Text = $"Награда: {prize}";
        }
    }
}
