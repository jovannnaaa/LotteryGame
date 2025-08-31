using System;
using System.Windows.Forms;

namespace LotteryGame
{
    partial class GameForm
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
        private void Initialize()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 467);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(871, 24);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // GameForm
            // 
            this.ClientSize = new System.Drawing.Size(871, 491);
            this.Controls.Add(this.statusStrip1);
            this.Name = "GameForm";
            this.Load += new System.EventHandler(this.GameForm_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void GameForm_Load_1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private Label labelStatus;
        private FlowLayoutPanel flowLayoutPanel1;
        private ListBox listBoxDrawn;
    }
}