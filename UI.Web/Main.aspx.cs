using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnABMClientes_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("~/ABMClientes.aspx");
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["usuario"] = null;
            Page.Response.Redirect("~/Default.aspx");
        }
    }
}