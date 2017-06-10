using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.Service;
namespace WebApplication2
{
    public partial class Login : System.Web.UI.Page
    {
        private LineChatService _lineChatService;
        protected void Page_Load(object sender, EventArgs e)
        {
            _lineChatService = new LineChatService();
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogUp.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (_lineChatService.CheckProvider(txtID.Text, txtPwd.Text,true))
            {
                Response.Redirect("InsertRestaurantInfo.aspx");
            }
            else
            {
                txtID.Text = "";
                txtPwd.Text = "";
                Response.Write("<Script language='Javascript'>");
                Response.Write("alert('帳號密碼錯誤')");
                Response.Write("</" + "Script>");
            }
        }
    }
}