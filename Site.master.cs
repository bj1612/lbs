using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Site : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["email"] != null)
        {
            if (Session["typeofuser"] != null)
            {
                string username = "";
                if (Session["username"] != null)
                {
                    username = Session["username"].ToString();
                    if (IsPostBack == false)
                    {
                        menudiv.InnerHtml = @"<nav>";
                        menudiv.InnerHtml += @"<ul id='navigation'>";
                        menudiv.InnerHtml += @"<li><a  href='/lbs/index.aspx'>Home</a></li>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/student/register_complaint.aspx'>Register Complaint</a></li>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/student/track_complaint.aspx'>Track Complaint</a></li>";
                        menudiv.InnerHtml += @"<li>Welcome "+username+" <i class='ti-angle-down'></i>";
                        menudiv.InnerHtml += @"<ul class='submenu'>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/logout.aspx'>Logout</a></li>";
                        menudiv.InnerHtml += @"</ul>";
                        menudiv.InnerHtml += @"</li>";
                        menudiv.InnerHtml += @"</ul>";
                        menudiv.InnerHtml += @"</nav>";
                    }
                }
            }
        }
        else
        {
            if (IsPostBack == false)
            {
                menudiv.InnerHtml = @"<nav>";
                    menudiv.InnerHtml += @"<ul>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/index.aspx'>Home</a></li>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/about.aspx'>About Us</a></li>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/about.aspx'>GuideLines</a></li>";
                        menudiv.InnerHtml += @"<li>Register | Login <i class='ti-angle-down'></i>";
                            menudiv.InnerHtml += @"<ul class='submenu'>";
                                menudiv.InnerHtml += @"<li><a href='/lbs/register.aspx'>Register</a></li>";
                                menudiv.InnerHtml += @"<li><a href='/lbs/login.aspx'>Login</a></li>";
                            menudiv.InnerHtml += @"</ul>";
                        menudiv.InnerHtml += @"</li>";
                    menudiv.InnerHtml += @"</ul>";
                menudiv.InnerHtml += @"</nav>";
            }
        }
    }
}
