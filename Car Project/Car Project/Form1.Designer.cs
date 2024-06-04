
namespace Car_Project
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btnAlarm = new System.Windows.Forms.Button();
            this.tbHeadlights = new System.Windows.Forms.TextBox();
            this.lblHeadlights = new System.Windows.Forms.Label();
            this.timerDataReceived = new System.Windows.Forms.Timer(this.components);
            this.tbTemperature = new System.Windows.Forms.TextBox();
            this.lblTemperature = new System.Windows.Forms.Label();
            this.lbBlackBox = new System.Windows.Forms.ListBox();
            this.btnClearBlackBox = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM5";
            // 
            // btnAlarm
            // 
            this.btnAlarm.BackColor = System.Drawing.Color.Green;
            this.btnAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlarm.Location = new System.Drawing.Point(0, 0);
            this.btnAlarm.Name = "btnAlarm";
            this.btnAlarm.Size = new System.Drawing.Size(233, 212);
            this.btnAlarm.TabIndex = 0;
            this.btnAlarm.Text = "Alarm";
            this.btnAlarm.UseVisualStyleBackColor = false;
            this.btnAlarm.Click += new System.EventHandler(this.btnAlarm_Click);
            // 
            // tbHeadlights
            // 
            this.tbHeadlights.Location = new System.Drawing.Point(438, 50);
            this.tbHeadlights.Name = "tbHeadlights";
            this.tbHeadlights.Size = new System.Drawing.Size(100, 22);
            this.tbHeadlights.TabIndex = 1;
            // 
            // lblHeadlights
            // 
            this.lblHeadlights.AutoSize = true;
            this.lblHeadlights.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeadlights.Location = new System.Drawing.Point(283, 43);
            this.lblHeadlights.Name = "lblHeadlights";
            this.lblHeadlights.Size = new System.Drawing.Size(128, 29);
            this.lblHeadlights.TabIndex = 2;
            this.lblHeadlights.Text = "Headlights";
            // 
            // timerDataReceived
            // 
            this.timerDataReceived.Tick += new System.EventHandler(this.timerDataReceived_Tick);
            // 
            // tbTemperature
            // 
            this.tbTemperature.Location = new System.Drawing.Point(438, 104);
            this.tbTemperature.Name = "tbTemperature";
            this.tbTemperature.Size = new System.Drawing.Size(100, 22);
            this.tbTemperature.TabIndex = 3;
            // 
            // lblTemperature
            // 
            this.lblTemperature.AutoSize = true;
            this.lblTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemperature.Location = new System.Drawing.Point(258, 104);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(153, 29);
            this.lblTemperature.TabIndex = 4;
            this.lblTemperature.Text = "Temperature";
            // 
            // lbBlackBox
            // 
            this.lbBlackBox.FormattingEnabled = true;
            this.lbBlackBox.ItemHeight = 16;
            this.lbBlackBox.Location = new System.Drawing.Point(560, 0);
            this.lbBlackBox.Name = "lbBlackBox";
            this.lbBlackBox.Size = new System.Drawing.Size(240, 452);
            this.lbBlackBox.TabIndex = 5;
            // 
            // btnClearBlackBox
            // 
            this.btnClearBlackBox.Location = new System.Drawing.Point(463, 225);
            this.btnClearBlackBox.Name = "btnClearBlackBox";
            this.btnClearBlackBox.Size = new System.Drawing.Size(75, 95);
            this.btnClearBlackBox.TabIndex = 6;
            this.btnClearBlackBox.Text = "Clear";
            this.btnClearBlackBox.UseVisualStyleBackColor = true;
            this.btnClearBlackBox.Click += new System.EventHandler(this.btnClearBlackBox_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClearBlackBox);
            this.Controls.Add(this.lbBlackBox);
            this.Controls.Add(this.lblTemperature);
            this.Controls.Add(this.tbTemperature);
            this.Controls.Add(this.lblHeadlights);
            this.Controls.Add(this.tbHeadlights);
            this.Controls.Add(this.btnAlarm);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btnAlarm;
        private System.Windows.Forms.TextBox tbHeadlights;
        private System.Windows.Forms.Label lblHeadlights;
        private System.Windows.Forms.Timer timerDataReceived;
        private System.Windows.Forms.TextBox tbTemperature;
        private System.Windows.Forms.Label lblTemperature;
        private System.Windows.Forms.ListBox lbBlackBox;
        private System.Windows.Forms.Button btnClearBlackBox;
    }
}

