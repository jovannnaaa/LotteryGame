namespace LotteryGame
{
    partial class GameOverForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbResult = new System.Windows.Forms.TextBox();
            this.tbDrawn = new System.Windows.Forms.TextBox();
            this.tbChosen = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbResult
            // 
            this.tbResult.Location = new System.Drawing.Point(484, 65);
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(100, 22);
            this.tbResult.TabIndex = 0;
            // 
            // tbDrawn
            // 
            this.tbDrawn.Location = new System.Drawing.Point(484, 142);
            this.tbDrawn.Name = "tbDrawn";
            this.tbDrawn.Size = new System.Drawing.Size(100, 22);
            this.tbDrawn.TabIndex = 1;
            // 
            // tbChosen
            // 
            this.tbChosen.Location = new System.Drawing.Point(484, 207);
            this.tbChosen.Name = "tbChosen";
            this.tbChosen.Size = new System.Drawing.Size(100, 22);
            this.tbChosen.TabIndex = 2;
            // 
            // GameOverForm
            // 
            this.ClientSize = new System.Drawing.Size(899, 460);
            this.Controls.Add(this.tbChosen);
            this.Controls.Add(this.tbDrawn);
            this.Controls.Add(this.tbResult);
            this.Name = "GameOverForm";
            this.Load += new System.EventHandler(this.GameOverForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbScore;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.TextBox tbDrawn;
        private System.Windows.Forms.TextBox tbChosen;
    }
}