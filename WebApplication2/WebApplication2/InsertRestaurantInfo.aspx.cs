using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.Service;
using System.IO;
namespace WebApplication2
{
    public partial class InsertRestaurantInfo : System.Web.UI.Page
    {
        private LineChatService _LineChatService;
        protected void Page_Load(object sender, EventArgs e)
        {
            _LineChatService = new LineChatService();
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
            if(!IsPostBack)
            {
               List<county> countyCol = _LineChatService.CountySearch();
               
                ddCounty.DataSource = countyCol;
                ddCounty.DataTextField = "countyName";
                ddCounty.DataValueField = "countyId";
                ddCounty.DataBind();

                if(countyCol.Any())
                {
                    county countyObj = countyCol.FirstOrDefault();
                    ddCity.DataSource = _LineChatService.CitySearch(countyObj.countyId);
                    ddCity.DataTextField = "cityName";
                    ddCity.DataValueField = "cityId";
                    ddCity.DataBind();
                    
                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddCounty.SelectedValue!="-1")
            {
                CityBinding();
            }
        }
        
        
        private void CityBinding()
        {
         
            int countyId = Int32.Parse(ddCounty.SelectedValue);


            ddCity.DataSource = _LineChatService.CitySearch(countyId);
            ddCity.DataTextField = "cityName";
            ddCity.DataValueField = "cityId";
            ddCity.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            #region 輸入框檢核
            string msg = "";
            if (string.IsNullOrWhiteSpace(txtRestName.Text))
            {
                msg += "未輸入餐廳名稱\\n";
            }

            if (string.IsNullOrWhiteSpace(txtrestAddress.Text))
            {
                msg += "未輸入餐廳地址\\n";
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                msg += "未輸入餐廳電話\\n";
            }

            if (string.IsNullOrWhiteSpace(txtUrl.Text))
            {
                msg += "未輸入餐廳網址\\n";
            }
            if (string.IsNullOrWhiteSpace(txtNote.Text))
            {
                msg += "未輸入說明\\n";
            }
            if (!FileUpload1.HasFile)
            {
                msg += "未選擇餐廳圖片\\n";
            }

            if (!string.IsNullOrWhiteSpace(msg))
            {
                Response.Write("<Script language='Javascript'>");
                Response.Write("alert('" + msg + "')");
                Response.Write("</" + "Script>");
                return;
            }
            #endregion



            String fileName = txtPhone.Text + Path.GetExtension(FileUpload1.FileName);

            String savePath = Server.MapPath("~/Image/");

            String saveResult = savePath + fileName;
            //-- 重點！！必須包含 Server端的「目錄」與「檔名」，才能使用 .SaveAs()方法！
            FileUpload1.SaveAs(saveResult);

            restaurant obj = new restaurant()
            {
                cityId = int.Parse( ddCity.SelectedValue),
                providerId = Utility.provider.providerId,
                restaurantAddress = txtrestAddress.Text,
                restaurantName = txtRestName.Text,
                restaurantNote = txtNote.Text,
                restaurantPhone = txtPhone.Text,
                restaurantPicture = fileName,
                restaurantURL = txtUrl.Text
            };
            if(_LineChatService.InsertRestaurant(obj))
            {

                txtRestName.Text = "";
                txtrestAddress.Text = "";
                txtPhone.Text = "";
                txtUrl.Text = "";
                txtNote.Text = "";
                
                Response.Write("<Script language='Javascript'>");
                Response.Write("alert('新增成功')");
                Response.Write("</" + "Script>");
            }
            else
            {
                Response.Write("<Script language='Javascript'>");
                Response.Write("alert('新增失敗')");
                Response.Write("</" + "Script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            txtRestName.Text = "";
            txtrestAddress.Text = "";
            txtPhone.Text = "";
            txtUrl.Text = "";
            txtNote.Text = "";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
            Utility.provider = new provider();
        }
    }
}