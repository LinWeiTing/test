using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.Service;

namespace WebApplication2
{
    public partial class twst : System.Web.UI.Page
    {
        private LineChatService _lineChatService;
        protected void Page_Load(object sender, EventArgs e)
        {
            _lineChatService = new LineChatService();
            if (_lineChatService.CheckProvider("0952259389", "sp036239", true))
            {
            }
            else 
            { 
            }
        }
    }
}