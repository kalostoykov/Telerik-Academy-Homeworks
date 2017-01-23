using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RandomGeneratorWebControls
{
    public partial class Generator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                int min = int.Parse(this.TextBoxMin.Text);
                int max = int.Parse(this.TextBoxMax.Text);

                this.LabelResult.Text = new Random()
                    .Next(min, max)
                    .ToString();
            }
            catch (Exception)
            {
                this.LabelResult.Text = "Something went wrong hihi xD";
            }
        }
    }
}