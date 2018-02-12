using System;

namespace RecordAndPlayMouse
{
    partial class FormUI
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
            this.BtnRecord = new System.Windows.Forms.Button();
            this.lblInfo1 = new System.Windows.Forms.Label();
            this.lblInfo2 = new System.Windows.Forms.Label();
            this.lblInfo3 = new System.Windows.Forms.Label();
            this.nudSecondsRepeat = new System.Windows.Forms.NumericUpDown();
            this.lblRepeatInfo1 = new System.Windows.Forms.Label();
            this.lblRepeatInfo2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudSecondsRepeat)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnRecord
            // 
            this.BtnRecord.Location = new System.Drawing.Point(263, 42);
            this.BtnRecord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnRecord.Name = "BtnRecord";
            this.BtnRecord.Size = new System.Drawing.Size(100, 35);
            this.BtnRecord.TabIndex = 1;
            this.BtnRecord.Text = "Record";
            this.BtnRecord.UseVisualStyleBackColor = true;
            this.BtnRecord.Click += new System.EventHandler(this.BtnRecord_Click);
            // 
            // lblInfo1
            // 
            this.lblInfo1.Location = new System.Drawing.Point(3, 9);
            this.lblInfo1.Name = "lblInfo1";
            this.lblInfo1.Size = new System.Drawing.Size(125, 25);
            this.lblInfo1.TabIndex = 2;
            this.lblInfo1.Text = "1. Record";
            // 
            // lblInfo2
            // 
            this.lblInfo2.Location = new System.Drawing.Point(3, 34);
            this.lblInfo2.Name = "lblInfo2";
            this.lblInfo2.Size = new System.Drawing.Size(154, 25);
            this.lblInfo2.TabIndex = 3;
            this.lblInfo2.Text = "2. Press F10 to start playback";
            // 
            // lblInfo3
            // 
            this.lblInfo3.Location = new System.Drawing.Point(3, 59);
            this.lblInfo3.Name = "lblInfo3";
            this.lblInfo3.Size = new System.Drawing.Size(137, 25);
            this.lblInfo3.TabIndex = 4;
            this.lblInfo3.Text = "3. Press F10 to stop playback";
            // 
            // nudSecondsRepeat
            // 
            this.nudSecondsRepeat.DecimalPlaces = 2;
            this.nudSecondsRepeat.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudSecondsRepeat.Location = new System.Drawing.Point(273, 7);
            this.nudSecondsRepeat.Name = "nudSecondsRepeat";
            this.nudSecondsRepeat.Size = new System.Drawing.Size(81, 27);
            this.nudSecondsRepeat.TabIndex = 2;
            this.nudSecondsRepeat.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblRepeatInfo1
            // 
            this.lblRepeatInfo1.AutoSize = true;
            this.lblRepeatInfo1.Location = new System.Drawing.Point(169, 9);
            this.lblRepeatInfo1.Name = "lblRepeatInfo1";
            this.lblRepeatInfo1.Size = new System.Drawing.Size(98, 20);
            this.lblRepeatInfo1.TabIndex = 6;
            this.lblRepeatInfo1.Text = "Repeat every:";
            // 
            // lblRepeatInfo2
            // 
            this.lblRepeatInfo2.AutoSize = true;
            this.lblRepeatInfo2.Location = new System.Drawing.Point(360, 9);
            this.lblRepeatInfo2.Name = "lblRepeatInfo2";
            this.lblRepeatInfo2.Size = new System.Drawing.Size(62, 20);
            this.lblRepeatInfo2.TabIndex = 7;
            this.lblRepeatInfo2.Text = "seconds";
            // 
            // FormUI
            // 
            this.AcceptButton = this.BtnRecord;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 86);
            this.Controls.Add(this.lblRepeatInfo2);
            this.Controls.Add(this.lblRepeatInfo1);
            this.Controls.Add(this.nudSecondsRepeat);
            this.Controls.Add(this.lblInfo3);
            this.Controls.Add(this.lblInfo2);
            this.Controls.Add(this.lblInfo1);
            this.Controls.Add(this.BtnRecord);
            this.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FormUI";
            this.ShowIcon = false;
            this.Text = "MouseClicker";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.nudSecondsRepeat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnRecord;
        private System.Windows.Forms.Label lblInfo1;
        private System.Windows.Forms.Label lblInfo2;
        private System.Windows.Forms.Label lblInfo3;
        private System.Windows.Forms.NumericUpDown nudSecondsRepeat;
        private System.Windows.Forms.Label lblRepeatInfo1;
        private System.Windows.Forms.Label lblRepeatInfo2;
    }
}

