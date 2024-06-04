using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Project
{
    public partial class Form1 : Form
    {
        int count;
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.Green;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort1.Open();
            timerDataReceived.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerDataReceived.Stop();
            serialPort1.Close();

        }

        private void btnAlarm_Click(object sender, EventArgs e)
        {
            count = count + 1;

            if (count == 1)
            {
             serialPort1.WriteLine("AlarmOn");
                this.BackColor = Color.Red;
                btnAlarm.BackColor = Color.Red;
                lbBlackBox.Items.Add("AlarmOn");

            }
            else if (count == 2)
            {
                serialPort1.WriteLine("AlarmOff");
                count = 0;
                this.BackColor = Color.Green;
                btnAlarm.BackColor = Color.Green;
                lbBlackBox.Items.Add("AlarmOff");
            }
        }

        private void timerDataReceived_Tick(object sender, EventArgs e)
        {
            if (serialPort1.BytesToRead > 0)
            {
                string data = serialPort1.ReadLine();
                if (data == "OFF\r")
                {
                    tbHeadlights.Text = "OFF";
                    lbBlackBox.Items.Add("Headlights Off");
                }
                if (data == "ON\r")
                {
                    tbHeadlights.Text = "ON";
                    lbBlackBox.Items.Add("Headlights On");
                }
                /*we create an array with 2 elements to receive the data in them
                 * in index 0 is saved the string used what kind of value is sent
                 * while in index 1 is saved the value from the sensor
                 * in this case the data from the DHT11 sensor
                 * I use the split function to use ":" as a separator between index 0 and index 1
                 */
                if (data.Split(':')[0] == "degrees")
                {
                    tbTemperature.Text = data.Split(':')[1];
                    lbBlackBox.Items.Add(data.Split(':')[1]);
                }
            }
        }

        private void btnClearBlackBox_Click(object sender, EventArgs e)
        {
            lbBlackBox.Items.Clear();
        }
    }
}
