using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Security.Principal;
using System.Web.Security;

namespace e_Watch
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

        }
            protected void Button2_Click(object sender, EventArgs e)
        {
            FileUpload FileUpload2 = (FileUpload)DetailsView1.FindControl("FileUpload2");
            Image Image3 = (Image)DetailsView1.FindControl("Image3");
            if (FileUpload2.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload2.FileName);
                FileUpload2.SaveAs(Server.MapPath("~/assets/images" + FileUpload2.FileName));
                Image3.ImageUrl = "~/assets/images" + FileUpload2.FileName;
                Image3.Visible = true;
            }
        }
    }
}