
namespace CasinoWinforms
{
    partial class CasinoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CasinoForm));
            this.LblTitle = new System.Windows.Forms.Label();
            this.BtnPlayer1 = new System.Windows.Forms.Button();
            this.BtnPlayer2 = new System.Windows.Forms.Button();
            this.BtnPlayer3 = new System.Windows.Forms.Button();
            this.BtnPlayer4 = new System.Windows.Forms.Button();
            this.BtnPlayer5 = new System.Windows.Forms.Button();
            this.BtnPlayer6 = new System.Windows.Forms.Button();
            this.BtnPlayer7 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LblTitle
            // 
            this.LblTitle.AutoSize = true;
            this.LblTitle.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitle.Location = new System.Drawing.Point(453, 9);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(123, 27);
            this.LblTitle.TabIndex = 0;
            this.LblTitle.Text = "LBH Casino";
            // 
            // BtnPlayer1
            // 
            this.BtnPlayer1.Location = new System.Drawing.Point(64, 301);
            this.BtnPlayer1.Name = "BtnPlayer1";
            this.BtnPlayer1.Size = new System.Drawing.Size(75, 58);
            this.BtnPlayer1.TabIndex = 1;
            this.BtnPlayer1.Text = "Player1";
            this.BtnPlayer1.UseVisualStyleBackColor = true;
            // 
            // BtnPlayer2
            // 
            this.BtnPlayer2.Location = new System.Drawing.Point(135, 413);
            this.BtnPlayer2.Name = "BtnPlayer2";
            this.BtnPlayer2.Size = new System.Drawing.Size(75, 58);
            this.BtnPlayer2.TabIndex = 2;
            this.BtnPlayer2.Text = "Player2";
            this.BtnPlayer2.UseVisualStyleBackColor = true;
            // 
            // BtnPlayer3
            // 
            this.BtnPlayer3.Location = new System.Drawing.Point(252, 556);
            this.BtnPlayer3.Name = "BtnPlayer3";
            this.BtnPlayer3.Size = new System.Drawing.Size(75, 58);
            this.BtnPlayer3.TabIndex = 3;
            this.BtnPlayer3.Text = "Player3";
            this.BtnPlayer3.UseVisualStyleBackColor = true;
            // 
            // BtnPlayer4
            // 
            this.BtnPlayer4.Location = new System.Drawing.Point(482, 556);
            this.BtnPlayer4.Name = "BtnPlayer4";
            this.BtnPlayer4.Size = new System.Drawing.Size(75, 58);
            this.BtnPlayer4.TabIndex = 4;
            this.BtnPlayer4.Text = "Player4";
            this.BtnPlayer4.UseVisualStyleBackColor = true;
            // 
            // BtnPlayer5
            // 
            this.BtnPlayer5.Location = new System.Drawing.Point(714, 556);
            this.BtnPlayer5.Name = "BtnPlayer5";
            this.BtnPlayer5.Size = new System.Drawing.Size(75, 58);
            this.BtnPlayer5.TabIndex = 5;
            this.BtnPlayer5.Text = "Player5";
            this.BtnPlayer5.UseVisualStyleBackColor = true;
            // 
            // BtnPlayer6
            // 
            this.BtnPlayer6.Location = new System.Drawing.Point(821, 413);
            this.BtnPlayer6.Name = "BtnPlayer6";
            this.BtnPlayer6.Size = new System.Drawing.Size(75, 58);
            this.BtnPlayer6.TabIndex = 6;
            this.BtnPlayer6.Text = "Player6";
            this.BtnPlayer6.UseVisualStyleBackColor = true;
            // 
            // BtnPlayer7
            // 
            this.BtnPlayer7.Location = new System.Drawing.Point(899, 301);
            this.BtnPlayer7.Name = "BtnPlayer7";
            this.BtnPlayer7.Size = new System.Drawing.Size(75, 58);
            this.BtnPlayer7.TabIndex = 7;
            this.BtnPlayer7.Text = "Player7";
            this.BtnPlayer7.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(482, 69);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 8;
            this.button7.Text = "Dealer";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(179, 123);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(688, 318);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // CasinoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 652);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.BtnPlayer7);
            this.Controls.Add(this.BtnPlayer6);
            this.Controls.Add(this.BtnPlayer5);
            this.Controls.Add(this.BtnPlayer4);
            this.Controls.Add(this.BtnPlayer3);
            this.Controls.Add(this.BtnPlayer2);
            this.Controls.Add(this.BtnPlayer1);
            this.Controls.Add(this.LblTitle);
            this.Name = "CasinoForm";
            this.Text = "Casino";
            this.Load += new System.EventHandler(this.CasinoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.Button BtnPlayer1;
        private System.Windows.Forms.Button BtnPlayer2;
        private System.Windows.Forms.Button BtnPlayer3;
        private System.Windows.Forms.Button BtnPlayer4;
        private System.Windows.Forms.Button BtnPlayer5;
        private System.Windows.Forms.Button BtnPlayer6;
        private System.Windows.Forms.Button BtnPlayer7;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

