using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyJSON_formatter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static string FormatJson(string json)
        {
            try
            {
                dynamic parsedJson = JsonConvert.DeserializeObject(json);
                return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
                }
            catch
            {
                MessageBox.Show("error");
                return null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string untxted = unformatted_txt.Text;
            //string formattedtxt = FormatJson(untxted);
            // formatted_txt.Text = formattedtxt;
            string unformattedtxt = unformatted_txt.Text;
            string[] splitedtxt = unformattedtxt.Split((char)10);
            int count = unformattedtxt.Split((char)10).Length;
            countlbl.Text = "count: " + count;
            //label3.Text = splitedtxt[1];
            List<string> formattedList = new List<string>();
            
            for (int i=0; i< count;i++)
            {
                formattedList.Add(FormatToJson(splitedtxt[i]));
            }

            label4.Text = formattedList[0];
          
            string FormatToJson(string inputtxt)
            {
                string Formated_JSON = "";
                Formated_JSON = FormatJson(inputtxt);
                return Formated_JSON;
            }

            int pointX = 30;
            int pointY = 40;
            int NewHeight = 200;

            for (int i = 0; i < count; i++)
            {

                RichTextBox a = new RichTextBox();
                a.Width = 400;
                a.Location = new Point(pointX, pointY);
                a.Multiline = true;
                a.Text = (formattedList[i]).ToString();                             
                panel1.Controls.Add(a);
                panel1.Show();
                panel1.MaximumSize = new Size(panel1.Width, NewHeight);
                panel1.Size = new Size(panel1.Height, NewHeight);
                NewHeight += 200;
                pointY += 100;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int NewHeight = 200;
            panel1.MaximumSize = new Size(panel1.Width, NewHeight);
            panel1.Size = new Size(panel1.Height, NewHeight);
        }
    }
}
