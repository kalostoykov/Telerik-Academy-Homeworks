using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RandomGeneratorHtmlControls
{
    public partial class Generator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonGenerateClick(object sender, EventArgs e)
        {
            try
            {
                int minNumber = int.Parse(this.InputMin.Value);
                int maxNumber = int.Parse(this.InputMax.Value);

                this.result.InnerText = new Random()
                    .Next(minNumber, maxNumber)
                    .ToString();
            }
            catch (Exception)
            {
                this.result.InnerText = "Something went wrong hihi xD";
            }
        }
    }
}