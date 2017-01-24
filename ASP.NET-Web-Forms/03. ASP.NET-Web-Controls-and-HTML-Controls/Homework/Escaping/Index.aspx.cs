using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Escaping
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            string enteredText = this.TextBoxInput.Text;

            this.TextBoxResult.Text = this.Server.HtmlEncode(enteredText);
            this.LabelResult.Text = this.Server.HtmlEncode(enteredText);
        }
    }
}