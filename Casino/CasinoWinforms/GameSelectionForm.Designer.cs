
namespace CasinoWinforms
{
    partial class GameSelectionForm
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
            this.LtbAvailableGames = new System.Windows.Forms.ListBox();
            this.BtnConfirm = new System.Windows.Forms.Button();
            this.BtnRestart = new System.Windows.Forms.Button();
            this.GpbChooseGame = new System.Windows.Forms.GroupBox();
            this.GpbRestart = new System.Windows.Forms.GroupBox();
            this.GpbChooseGame.SuspendLayout();
            this.GpbRestart.SuspendLayout();
            this.SuspendLayout();
            // 
            // LtbAvailableGames
            // 
            this.LtbAvailableGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LtbAvailableGames.FormattingEnabled = true;
            this.LtbAvailableGames.ItemHeight = 20;
            this.LtbAvailableGames.Location = new System.Drawing.Point(6, 19);
            this.LtbAvailableGames.Name = "LtbAvailableGames";
            this.LtbAvailableGames.Size = new System.Drawing.Size(242, 24);
            this.LtbAvailableGames.TabIndex = 1;
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConfirm.Location = new System.Drawing.Point(6, 49);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(102, 24);
            this.BtnConfirm.TabIndex = 2;
            this.BtnConfirm.Text = "Confirm";
            this.BtnConfirm.UseVisualStyleBackColor = true;
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // BtnRestart
            // 
            this.BtnRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRestart.Location = new System.Drawing.Point(6, 19);
            this.BtnRestart.Name = "BtnRestart";
            this.BtnRestart.Size = new System.Drawing.Size(102, 24);
            this.BtnRestart.TabIndex = 4;
            this.BtnRestart.Text = "Confirm";
            this.BtnRestart.UseVisualStyleBackColor = true;
            // 
            // GpbChooseGame
            // 
            this.GpbChooseGame.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.GpbChooseGame.Controls.Add(this.LtbAvailableGames);
            this.GpbChooseGame.Controls.Add(this.BtnConfirm);
            this.GpbChooseGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GpbChooseGame.Location = new System.Drawing.Point(12, 12);
            this.GpbChooseGame.Name = "GpbChooseGame";
            this.GpbChooseGame.Size = new System.Drawing.Size(258, 87);
            this.GpbChooseGame.TabIndex = 5;
            this.GpbChooseGame.TabStop = false;
            this.GpbChooseGame.Text = "choose game";
            // 
            // GpbRestart
            // 
            this.GpbRestart.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.GpbRestart.Controls.Add(this.BtnRestart);
            this.GpbRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GpbRestart.Location = new System.Drawing.Point(12, 105);
            this.GpbRestart.Name = "GpbRestart";
            this.GpbRestart.Size = new System.Drawing.Size(258, 62);
            this.GpbRestart.TabIndex = 6;
            this.GpbRestart.TabStop = false;
            this.GpbRestart.Text = "restart current game";
            // 
            // GameSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 181);
            this.Controls.Add(this.GpbRestart);
            this.Controls.Add(this.GpbChooseGame);
            this.Name = "GameSelectionForm";
            this.Text = "GameSelectionForm";
            this.GpbChooseGame.ResumeLayout(false);
            this.GpbRestart.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox LtbAvailableGames;
        private System.Windows.Forms.Button BtnConfirm;
        private System.Windows.Forms.Button BtnRestart;
        private System.Windows.Forms.GroupBox GpbChooseGame;
        private System.Windows.Forms.GroupBox GpbRestart;
    }
}