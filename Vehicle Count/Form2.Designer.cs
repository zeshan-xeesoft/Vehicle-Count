﻿namespace Vehicle_Count
{
    partial class Form2
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
            this.buttonRtspPlay = new System.Windows.Forms.Button();
            this.buttonMP4Play = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxx1 = new System.Windows.Forms.TextBox();
            this.textBoxy1 = new System.Windows.Forms.TextBox();
            this.textBoxx2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxy2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonSetLine = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonRecStart = new System.Windows.Forms.Button();
            this.buttonRecStop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRtspPlay
            // 
            this.buttonRtspPlay.Location = new System.Drawing.Point(27, 800);
            this.buttonRtspPlay.Name = "buttonRtspPlay";
            this.buttonRtspPlay.Size = new System.Drawing.Size(122, 50);
            this.buttonRtspPlay.TabIndex = 1;
            this.buttonRtspPlay.Text = "Rtsp Capture";
            this.buttonRtspPlay.UseVisualStyleBackColor = true;
            this.buttonRtspPlay.Click += new System.EventHandler(this.buttonRtspPlay_Click);
            // 
            // buttonMP4Play
            // 
            this.buttonMP4Play.Location = new System.Drawing.Point(155, 800);
            this.buttonMP4Play.Name = "buttonMP4Play";
            this.buttonMP4Play.Size = new System.Drawing.Size(122, 50);
            this.buttonMP4Play.TabIndex = 3;
            this.buttonMP4Play.Text = "MP4 Play";
            this.buttonMP4Play.UseVisualStyleBackColor = true;
            this.buttonMP4Play.Click += new System.EventHandler(this.buttonMP4Play_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(283, 800);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(122, 50);
            this.buttonStop.TabIndex = 4;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1043, 609);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.textBox1.Location = new System.Drawing.Point(27, 678);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1028, 28);
            this.textBox1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 646);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Rtsp Url:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1090, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Point 1 (X):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1090, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Point 2 (X):";
            // 
            // textBoxx1
            // 
            this.textBoxx1.Location = new System.Drawing.Point(1093, 55);
            this.textBoxx1.Name = "textBoxx1";
            this.textBoxx1.Size = new System.Drawing.Size(154, 22);
            this.textBoxx1.TabIndex = 12;
            // 
            // textBoxy1
            // 
            this.textBoxy1.Location = new System.Drawing.Point(1093, 140);
            this.textBoxy1.Name = "textBoxy1";
            this.textBoxy1.Size = new System.Drawing.Size(154, 22);
            this.textBoxy1.TabIndex = 13;
            // 
            // textBoxx2
            // 
            this.textBoxx2.Location = new System.Drawing.Point(1281, 55);
            this.textBoxx2.Name = "textBoxx2";
            this.textBoxx2.Size = new System.Drawing.Size(154, 22);
            this.textBoxx2.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1278, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Point 1 (Y) :";
            // 
            // textBoxy2
            // 
            this.textBoxy2.Location = new System.Drawing.Point(1281, 140);
            this.textBoxy2.Name = "textBoxy2";
            this.textBoxy2.Size = new System.Drawing.Size(154, 22);
            this.textBoxy2.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1278, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Point 2 (Y) :";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.textBox2.Location = new System.Drawing.Point(27, 754);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(1028, 28);
            this.textBox2.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 725);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "MP4 File Directory";
            // 
            // buttonSetLine
            // 
            this.buttonSetLine.Location = new System.Drawing.Point(1093, 181);
            this.buttonSetLine.Name = "buttonSetLine";
            this.buttonSetLine.Size = new System.Drawing.Size(154, 32);
            this.buttonSetLine.TabIndex = 20;
            this.buttonSetLine.Text = "Set the Line";
            this.buttonSetLine.UseVisualStyleBackColor = true;
            this.buttonSetLine.Click += new System.EventHandler(this.buttonSetLine_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(411, 800);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(122, 50);
            this.buttonReset.TabIndex = 21;
            this.buttonReset.Text = " Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonRecStart
            // 
            this.buttonRecStart.Location = new System.Drawing.Point(793, 800);
            this.buttonRecStart.Name = "buttonRecStart";
            this.buttonRecStart.Size = new System.Drawing.Size(122, 50);
            this.buttonRecStart.TabIndex = 22;
            this.buttonRecStart.Text = "Start Rec";
            this.buttonRecStart.UseVisualStyleBackColor = true;
            this.buttonRecStart.Click += new System.EventHandler(this.buttonRecStart_Click);
            // 
            // buttonRecStop
            // 
            this.buttonRecStop.Location = new System.Drawing.Point(932, 800);
            this.buttonRecStop.Name = "buttonRecStop";
            this.buttonRecStop.Size = new System.Drawing.Size(122, 50);
            this.buttonRecStop.TabIndex = 23;
            this.buttonRecStop.Text = "Stop Rec";
            this.buttonRecStop.UseVisualStyleBackColor = true;
            this.buttonRecStop.Click += new System.EventHandler(this.buttonRecStop_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1454, 892);
            this.Controls.Add(this.buttonRecStop);
            this.Controls.Add(this.buttonRecStart);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonSetLine);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBoxy2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxx2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxy1);
            this.Controls.Add(this.textBoxx1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonMP4Play);
            this.Controls.Add(this.buttonRtspPlay);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonRtspPlay;
        private System.Windows.Forms.Button buttonMP4Play;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxx1;
        private System.Windows.Forms.TextBox textBoxy1;
        private System.Windows.Forms.TextBox textBoxx2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxy2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonSetLine;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonRecStart;
        private System.Windows.Forms.Button buttonRecStop;
    }
}