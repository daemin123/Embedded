using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INIT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void 버튼1_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Btn1 Clicked.. sender : " + sender);
            Console.WriteLine("Btn1 Clicked.. e : " + e);
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Btn2 Clicked.. sender : " + sender);
            Console.WriteLine("Btn2 Clicked.. e : " + e);
        }

    }
}
