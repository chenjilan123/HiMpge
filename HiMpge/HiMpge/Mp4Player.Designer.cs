namespace HiMpge
{
    partial class Mp4Player
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
            this.DecodeFrame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DecodeFrame
            // 
            this.DecodeFrame.Location = new System.Drawing.Point(102, 29);
            this.DecodeFrame.Name = "DecodeFrame";
            this.DecodeFrame.Size = new System.Drawing.Size(75, 23);
            this.DecodeFrame.TabIndex = 0;
            this.DecodeFrame.Text = "Decode";
            this.DecodeFrame.UseVisualStyleBackColor = true;
            this.DecodeFrame.Click += new System.EventHandler(this.DecodeFrame_Click);
            // 
            // Mp4Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DecodeFrame);
            this.Name = "Mp4Player";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Mp4Player_FormClosing);
            this.Load += new System.EventHandler(this.Mp4Player_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DecodeFrame;
    }
}

