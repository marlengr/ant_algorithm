namespace ant_algh
{
    partial class MainForm
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
            this.pictureBoxWorld = new System.Windows.Forms.PictureBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.AddAntButton = new System.Windows.Forms.Button();
            this.moveButton = new System.Windows.Forms.Button();
            this.AntCountLabel = new System.Windows.Forms.Label();
            this.bzduraLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWorld)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxWorld
            // 
            this.pictureBoxWorld.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxWorld.Name = "pictureBoxWorld";
            this.pictureBoxWorld.Size = new System.Drawing.Size(760, 406);
            this.pictureBoxWorld.TabIndex = 0;
            this.pictureBoxWorld.TabStop = false;
            this.pictureBoxWorld.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_Paint);
            // 
            // StartButton
            // 
            this.StartButton.Enabled = false;
            this.StartButton.Location = new System.Drawing.Point(12, 424);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(90, 25);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.ButtonStart_click);
            // 
            // StopButton
            // 
            this.StopButton.Enabled = false;
            this.StopButton.Location = new System.Drawing.Point(108, 424);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(90, 25);
            this.StopButton.TabIndex = 3;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.ButtonStop_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Enabled = false;
            this.RefreshButton.Location = new System.Drawing.Point(204, 424);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(90, 25);
            this.RefreshButton.TabIndex = 4;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.ButtonRefresh_Click);
            // 
            // AddAntButton
            // 
            this.AddAntButton.Location = new System.Drawing.Point(682, 424);
            this.AddAntButton.Name = "AddAntButton";
            this.AddAntButton.Size = new System.Drawing.Size(90, 25);
            this.AddAntButton.TabIndex = 6;
            this.AddAntButton.Text = "Add ant";
            this.AddAntButton.UseVisualStyleBackColor = true;
            this.AddAntButton.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // moveButton
            // 
            this.moveButton.Location = new System.Drawing.Point(300, 424);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(90, 25);
            this.moveButton.TabIndex = 7;
            this.moveButton.Text = "Move";
            this.moveButton.UseVisualStyleBackColor = true;
            this.moveButton.Click += new System.EventHandler(this.ButtonMove_Click);
            // 
            // AntCountLabel
            // 
            this.AntCountLabel.AutoSize = true;
            this.AntCountLabel.Location = new System.Drawing.Point(598, 430);
            this.AntCountLabel.Name = "AntCountLabel";
            this.AntCountLabel.Size = new System.Drawing.Size(78, 13);
            this.AntCountLabel.TabIndex = 8;
            this.AntCountLabel.Text = "Liczba mrowek";
            // 
            // bzduraLabel
            // 
            this.bzduraLabel.AutoSize = true;
            this.bzduraLabel.Location = new System.Drawing.Point(396, 430);
            this.bzduraLabel.Name = "bzduraLabel";
            this.bzduraLabel.Size = new System.Drawing.Size(39, 13);
            this.bzduraLabel.TabIndex = 9;
            this.bzduraLabel.Text = "bzdura";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.bzduraLabel);
            this.Controls.Add(this.AntCountLabel);
            this.Controls.Add(this.moveButton);
            this.Controls.Add(this.AddAntButton);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.pictureBoxWorld);
            this.Name = "MainForm";
            this.Text = "AntAlgorithm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWorld)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button RefreshButton;
        public System.Windows.Forms.PictureBox pictureBoxWorld;
        private System.Windows.Forms.Button AddAntButton;
        private System.Windows.Forms.Button moveButton;
        private System.Windows.Forms.Label AntCountLabel;
        private System.Windows.Forms.Label bzduraLabel;
    }
}

