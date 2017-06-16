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
            this.AddAntButton = new System.Windows.Forms.Button();
            this.AntCountLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWorld)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxWorld
            // 
            this.pictureBoxWorld.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxWorld.Name = "pictureBoxWorld";
            this.pictureBoxWorld.Size = new System.Drawing.Size(760, 406);
            this.pictureBoxWorld.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxWorld.TabIndex = 0;
            this.pictureBoxWorld.TabStop = false;
            this.pictureBoxWorld.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_Paint);
            // 
            // StartButton
            // 
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
            this.StopButton.Location = new System.Drawing.Point(108, 424);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(90, 25);
            this.StopButton.TabIndex = 3;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.ButtonStop_Click);
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
            // AntCountLabel
            // 
            this.AntCountLabel.AutoSize = true;
            this.AntCountLabel.Location = new System.Drawing.Point(598, 430);
            this.AntCountLabel.Name = "AntCountLabel";
            this.AntCountLabel.Size = new System.Drawing.Size(78, 13);
            this.AntCountLabel.TabIndex = 8;
            this.AntCountLabel.Text = "Liczba mrowek";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(479, 427);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(367, 430);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Wpisz liczbę mrówek";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.AntCountLabel);
            this.Controls.Add(this.AddAntButton);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.pictureBoxWorld);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.Text = "AntAlgorithm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWorld)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
        public System.Windows.Forms.PictureBox pictureBoxWorld;
        private System.Windows.Forms.Button AddAntButton;
        private System.Windows.Forms.Label AntCountLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}

