using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.Service;
namespace WebApplication2
{
    public partial class LogUp : System.Web.UI.Page
    {
        private LineChatService _LineChatService;
        protected void Page_Load(object sender, EventArgs e)
        {
            _LineChatService = new LineChatService();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtLineID.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            #region 輸入框檢核
            string msg = "";
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                msg += "未輸入分享者姓名\\n";
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                msg += "未輸入分享者電話\\n";
            }

            if (string.IsNullOrWhiteSpace(txtLineID.Text))
            {
                msg += "未輸入Line ID\\n";
            }

            if (!string.IsNullOrWhiteSpace(msg))
            {
                Response.Write("<Script language='Javascript'>");
                Response.Write("alert('" + msg + "')");
                Response.Write("</" + "Script>");
                return;
            }
            #endregion

            #region 檢核是否註冊
            if(!_LineChatService.CheckProvider(txtPhone.Text, null, false))
            {
                provider obj = new provider()
                {
                    providerLineId = txtLineID.Text,
                    providerName = txtName.Text,
                    providerPhone = txtPhone.Text
                };

                if(_LineChatService.InsertProvder(obj))
                {
                    txtLineID.Text = "";
                    txtName.Text = "";
                    txtPhone.Text = "";
                   
                    Response.Write("<Script language='Javascript'>");
                    Response.Write("alert('註冊成功')");
                    Response.Write("</" + "Script>");
                }
                else
                {
                    Response.Write("<Script language='Javascript'>");
                    Response.Write("alert('註冊失敗')");
                    Response.Write("</" + "Script>");
                }
            }
            else
            {
                Response.Write("<Script language='Javascript'>");
                Response.Write("alert('此分享者電話已註冊')");
                Response.Write("</" + "Script>");
            }
            #endregion
        }

        protected void btnBackLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}