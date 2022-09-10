using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mathSOAPServiceWebClient
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference3.CalculatorSoapClient myClient = new ServiceReference3.CalculatorSoapClient("CalculatorSoap");
            int x = Int32.Parse(TextBox1.Text);
            int y = Int32.Parse(TextBox2.Text);

            int mul = myClient.Multiply(x, y);
            TextBox3.Text = mul.ToString();
        }
    }
}