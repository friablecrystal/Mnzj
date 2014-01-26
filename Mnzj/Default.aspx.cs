using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mnzj.DataAccess.Business;
using Mnzj.Entity;

namespace Mnzj
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var userName = Request.Cookies.Get("user").Value;
            var password = Request.Cookies.Get("pwd").Value;
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                var user = CheckUser(userName, password);
                if (user == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Response.Write("Welcome back! " + userName);
                }
            }
        }

        private User CheckUser(string userName, string password)
        {
            var user = UserDAO.GetInstance().Query(userName, password);
            return user;
        }
    }
}