using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Part1WebApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Image1.ImageUrl = "~/imageProcess.aspx";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Encrypt Now
            ServiceReference2.ServiceClient proxy2 = new ServiceReference2.ServiceClient();
            string str2 = TextBox1.Text;
            if(str2 == "")
            {
                str2 = "No String Entered.";
            }
            string enc = proxy2.Encrypt(str2);
            hiddenEncryptedLabel.Text = enc;
            hiddenEncryptedLabel.Visible = true;
            resultLabel2.Text = enc;
            resultLabel2.Visible = true;
        }
        protected void Button6_Click(object sender, EventArgs e)
        {
            //Decrypt Now
            ServiceReference2.ServiceClient proxy2 = new ServiceReference2.ServiceClient();
            string str3 = resultLabel2.Text;
            if (str3 == "")
            {
                str3 = "ebZSlZ4Fzq7Hso3lsHOf39KPZtO0pPTt";
            }
            else if (str3 == "Enter String Here")
            {
                str3 = "Y4zUv6ZkJx1f2TSSi4eB58GdswQf/a04";
            }
            string enc = proxy2.Decrypt(str3);
            hiddenEncryptedLabel2.Text = enc;
            hiddenEncryptedLabel2.Visible = true;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //Show Me Another String Image!
            ServiceReference3.ServiceClient proxy3 = new ServiceReference3.ServiceClient();
            string userLength = TextBox3.Text;
            Session["userLength"] = userLength;
            string myStr = proxy3.GetVerifierString(userLength);
            Session["generatedString"] = myStr;
            if(Int32.Parse(userLength) > 10)
            {
                Image1.Width = 600;
            }
            if (Int32.Parse(userLength) < 10)
            {
                Image1.Width = 300;
            }
            Image1.Visible = true;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            //Submit 
            if(Session["generatedString"].Equals(TextBox4.Text))
            {
                resultLabel.Text = "Congratulations. The code you entered is correct!";
            }
            else
            {
                resultLabel.Text = "I am sorry, the string you entered does not match the image. Please try again!";
            }
            resultLabel.Visible = true;
        }
    }
}