using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Part1WindowsFormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string str = textBox1.Text;
            string revStr = proxy.reverse(str);
            int vowelCount = proxy.analyzeStr(str).VowelCount;
            int upperCount = proxy.analyzeStr(str).UppercaseCount;

            vowelLabel.Text = vowelCount.ToString();
            upperLabel.Text = upperCount.ToString();
            reverseLabel.Text = revStr;
        }
    }
}
