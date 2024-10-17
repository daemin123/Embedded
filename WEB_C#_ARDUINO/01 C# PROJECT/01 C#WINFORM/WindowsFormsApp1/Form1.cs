using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//추가
using System.Net.Http;
using System.Net;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void conn_btn_Click(object sender, EventArgs e)
        {
            
            
            String port =  this.comboBox1.Items[  this.comboBox1.SelectedIndex  ].ToString();
            Console.WriteLine("PORT : " + port);
            HttpWebRequest request=null;
            HttpWebResponse response = null;
            try
            {   
                request =  (HttpWebRequest)HttpWebRequest.Create("http://localhost:8080/arduino/connection/" + port);
                request.Method = "GET";
                request.ContentType = "application/json";
                //request.Timeout = 30 * 1000;

                response = (HttpWebResponse)request.GetResponse();
           
                if(response.StatusCode == HttpStatusCode.OK)
                {
                    Console.WriteLine("RESPONSE CODE : " + response.StatusCode);

                }
               
            }catch(Exception ex)
            {
                Console.WriteLine("Ex : " + ex);
            }


        }

        private void led_on_btn_Click(object sender, EventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://localhost:8080/arduino/led/1");
            request.Method = "GET";
            request.ContentType = "application/json";
            //request.Timeout = 30 * 1000;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        }

        private void led_off_btn_Click(object sender, EventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://localhost:8080/arduino/led/0");
            request.Method = "GET";
            request.ContentType = "application/json";
            //request.Timeout = 30 * 1000;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        }
    }
}
