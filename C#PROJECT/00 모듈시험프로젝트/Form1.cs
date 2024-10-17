using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MODULE_PROJECT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void connection_btn_Click(object sender, EventArgs e)
        {
            Console.Write(this.comboBox1.Items[this.comboBox1.SelectedIndex].ToString() + " CONN\r\n");
            this.textBox1.Text = this.comboBox1.Items[this.comboBox1.SelectedIndex].ToString() + " CONN";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.Write("LED_01 ON CLICKED\r\n");
            this.textBox1.Text = "LED_01 ON SUCCESS";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Console.Write("LED_01 OFF CLICKED\r\n");
            this.textBox1.Text = "LED_01 OFF SUCCESS";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Console.Write("LED_02 ON CLICKED\r\n");
            this.textBox1.Text = "LED_02 ON SUCCESS";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Console.Write("LED_02 OFF CLICKED\r\n");
            this.textBox1.Text = "LED_02 OFF SUCCESS";
        }

     

  
    }
}
