using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SumatorAndHttpHandler
{
    public partial class Sumator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonCalculateSum_Click(object sender, EventArgs e)
        {
            try
            {
                double firstNum = double.Parse(this.TextBoxFirstNum.Text);
                double secondNum = double.Parse(this.TextBoxSecondNum.Text);
                double sum = firstNum + secondNum;

                this.TextBoxSum.Text = sum.ToString();
            }
            catch (Exception)
            {
                this.TextBoxSum.Text = "Enter valid numbers!";
            }
        }
    }
}