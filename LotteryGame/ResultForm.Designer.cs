using System;

namespace LotteryGame
{
    partial class ResultsForm
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
            this.lblResult = new System.Windows.Forms.Label();
            this.lblChosen = new System.Windows.Forms.Label();
            this.lblDrawn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(396, 156);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(44, 16);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "label1";
            // 
            // lblChosen
            // 
            this.lblChosen.AutoSize = true;
            this.lblChosen.Location = new System.Drawing.Point(277, 156);
            this.lblChosen.Name = "lblChosen";
            this.lblChosen.Size = new System.Drawing.Size(44, 16);
            this.lblChosen.TabIndex = 1;
            this.lblChosen.Text = "label1";
            // 
            // lblDrawn
            // 
            this.lblDrawn.AutoSize = true;
            this.lblDrawn.Location = new System.Drawing.Point(145, 156);
            this.lblDrawn.Name = "lblDrawn";
            this.lblDrawn.Size = new System.Drawing.Size(44, 16);
            this.lblDrawn.TabIndex = 2;
            this.lblDrawn.Text = "label1";
            // 
            // ResultsForm
            // 
            this.ClientSize = new System.Drawing.Size(624, 409);
            this.Controls.Add(this.lblDrawn);
            this.Controls.Add(this.lblChosen);
            this.Controls.Add(this.lblResult);
            this.Name = "ResultsForm";
            this.Load += new System.EventHandler(this.ResultsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ResultsForm_Load(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblChosen;
        private System.Windows.Forms.Label lblDrawn;
    }
}