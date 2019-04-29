using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Cliente user = new Cliente();
            user.EMail = this.txtEmail.Text;
            user.Password = this.txtPassword.Text;
            if (new ClienteLogic().Existe(user.EMail))
            {
                Cliente u = new ClienteLogic().GetOne(user.EMail);
                if (u.Password == user.Password)
                {
                    Session.Add("usuario", u);
                    Page.Response.Redirect("~/Main.aspx");
                }
                else
                {
                    this.lblIncorrecto.Text = "Password incorrecto";
                    this.lblIncorrecto.Visible = true;
                }
            }
            else
            {
                this.lblIncorrecto.Text = "El usuario no existe";
                this.lblIncorrecto.Visible = true;
            }
        }
    }
}