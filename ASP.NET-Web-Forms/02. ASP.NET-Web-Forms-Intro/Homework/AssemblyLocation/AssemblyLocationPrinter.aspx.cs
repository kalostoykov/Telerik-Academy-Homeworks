using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AssemblyLocation
{
    public partial class AssemblyLocationPrinter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LabelHello.InnerText = "Hello, ASP.NET";
            this.LabelAsseblyLocation.InnerText += "Assembly location: " + Assembly.GetExecutingAssembly().Location;
        }
    }
}