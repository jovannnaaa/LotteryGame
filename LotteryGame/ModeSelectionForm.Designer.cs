namespace LotteryGame
{
    partial class ModeSelectionForm
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
            this.btnStandard = new System.Windows.Forms.Button();
            this.btnAdvanced = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStandard
            // 
            this.btnStandard.BackColor = System.Drawing.Color.Gold;
            this.btnStandard.FlatAppearance.BorderSize = 4;
            this.btnStandard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStandard.Font = new System.Drawing.Font("Snap ITC", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStandard.ForeColor = System.Drawing.Color.Red;
            this.btnStandard.Location = new System.Drawing.Point(385, 168);
            this.btnStandard.Name = "btnStandard";
            this.btnStandard.Size = new System.Drawing.Size(268, 58);
            this.btnStandard.TabIndex = 0;
            this.btnStandard.Text = "Standard";
            this.btnStandard.UseVisualStyleBackColor = false;
            this.btnStandard.Click += new System.EventHandler(this.btnStandard_Click);
            // 
            // btnAdvanced
            // 
            this.btnAdvanced.BackColor = System.Drawing.Color.Gold;
            this.btnAdvanced.FlatAppearance.BorderSize = 4;
            this.btnAdvanced.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdvanced.Font = new System.Drawing.Font("Snap ITC", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdvanced.ForeColor = System.Drawing.Color.Red;
            this.btnAdvanced.Location = new System.Drawing.Point(385, 244);
            this.btnAdvanced.Name = "btnAdvanced";
            this.btnAdvanced.Size = new System.Drawing.Size(267, 60);
            this.btnAdvanced.TabIndex = 1;
            this.btnAdvanced.Text = "Advanced";
            this.btnAdvanced.UseVisualStyleBackColor = false;
            this.btnAdvanced.Click += new System.EventHandler(this.btnAdvanced_Click);
            // 
            // ModeSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LotteryGame.Properties.Resources.loto2;
            this.ClientSize = new System.Drawing.Size(1003, 503);
            this.Controls.Add(this.btnAdvanced);
            this.Controls.Add(this.btnStandard);
            this.Name = "ModeSelectionForm";
            this.Text = "ModeSelectionForm";
            this.Load += new System.EventHandler(this.ModeSelectionForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStandard;
        private System.Windows.Forms.Button btnAdvanced;
    }
}