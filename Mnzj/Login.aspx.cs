using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mnzj.Entity;
using Mnzj.DataAccess.Business;
using System.Security.Cryptography;
using Mnzj.Util;

namespace Mnzj
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var result = Request["result"];
            if (!string.IsNullOrEmpty(result))
            {
                if (result == "fail")
                    Response.Write("Wrong UserName or Password!");
                else if (result == "success")
                {
                    Response.Write("Welcome!");
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = this.txtUserName.Text;
            string password = this.txtPasswrod.Text;
            password = CryptoHelper.GetMD5Hash(password);
            var users = UserDAO.GetInstance().Query(userName, password);
            if (users == null)
            {
                Response.Redirect("Login.aspx?result=fail");
            }
            else
            {
                Response.Cookies["user"].Value = userName;
                Response.Cookies["pwd"].Value = password;
                Response.Redirect("Login.aspx?result=success");
            }
        }

    }
}