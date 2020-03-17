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
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
        Response.Cache.SetNoStore();
        if (Session["email"] != null)
        {
            if (Session["typeofuser"] != null)
            {
                string username = "";
                if (Session["username"] != null)
                {
                    string current_user = Session["typeofuser"].ToString();
                    if (current_user.Equals("student"))
                    {
                        username = Session["username"].ToString();
                        menudiv.InnerHtml = "";
                        menudiv.InnerHtml = @"<nav>";
                        menudiv.InnerHtml += @"<ul id='navigation'>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/index.aspx' style='text-decoration:none;'>Home</a></li>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/student/register_complaint.aspx' style='text-decoration:none;'>Register Complaint</a></li>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/student/track_complaint.aspx' style='text-decoration:none;'>Track Complaint</a></li>";
                        menudiv.InnerHtml += @"<li><a href='#' style='text-decoration:none;'>Welcome " + username + " <i class='ti-angle-down'></i></a>";
                        menudiv.InnerHtml += @"<ul class='submenu'>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/logout.aspx' style='text-decoration:none;'>Logout</a></li>";
                        menudiv.InnerHtml += @"</ul>";
                        menudiv.InnerHtml += @"</li>";
                        menudiv.InnerHtml += @"</ul>";
                        menudiv.InnerHtml += @"</nav>";
                    }
                    if (current_user.Equals("university_moderator") || current_user.Equals("institute_moderator") || current_user.Equals("department_moderator"))
                    {
                        username = Session["username"].ToString();
                        menudiv.InnerHtml = "";
                        menudiv.InnerHtml = @"<nav>";
                        menudiv.InnerHtml += @"<ul id='navigation'>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/moderator/track_complaint.aspx' style='text-decoration:none;'>Home</a></li>";
                        menudiv.InnerHtml += @"<li><a href='#' style='text-decoration:none;'>Welcome " + username + " <i class='ti-angle-down'></i></a>";
                        menudiv.InnerHtml += @"<ul class='submenu'>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/logout.aspx' style='text-decoration:none;'>Logout</a></li>";
                        menudiv.InnerHtml += @"</ul>";
                        menudiv.InnerHtml += @"</li>";
                        menudiv.InnerHtml += @"</ul>";
                        menudiv.InnerHtml += @"</nav>";
                    }
                    if (current_user.Equals("university_sub_admin") || current_user.Equals("institute_sub_admin") || current_user.Equals("department_sub_admin"))
                    {
                        username = Session["username"].ToString();
                        menudiv.InnerHtml = "";
                        menudiv.InnerHtml = @"<nav>";
                        menudiv.InnerHtml += @"<ul id='navigation'>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/moderator/track_complaint.aspx' style='text-decoration:none;'>Home</a></li>";
                        menudiv.InnerHtml += @"<li><a href='#' style='text-decoration:none;'>Welcome " + username + " <i class='ti-angle-down'></i></a>";
                        menudiv.InnerHtml += @"<ul class='submenu'>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/logout.aspx' style='text-decoration:none;'>Logout</a></li>";
                        menudiv.InnerHtml += @"</ul>";
                        menudiv.InnerHtml += @"</li>";
                        menudiv.InnerHtml += @"</ul>";
                        menudiv.InnerHtml += @"</nav>";
                    }
                    if (current_user.Equals("university_admin") || current_user.Equals("institute_admin") || current_user.Equals("department_admin"))
                    {
                        username = Session["username"].ToString();
                        menudiv.InnerHtml = "";
                        menudiv.InnerHtml = @"<nav>";
                        menudiv.InnerHtml += @"<ul id='navigation'>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/moderator/track_complaint.aspx' style='text-decoration:none;'>Home</a></li>";
                        menudiv.InnerHtml += @"<li><a href='#' style='text-decoration:none;'>Welcome " + username + " <i class='ti-angle-down'></i></a>";
                        menudiv.InnerHtml += @"<ul class='submenu'>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/logout.aspx' style='text-decoration:none;'>Logout</a></li>";
                        menudiv.InnerHtml += @"</ul>";
                        menudiv.InnerHtml += @"</li>";
                        menudiv.InnerHtml += @"</ul>";
                        menudiv.InnerHtml += @"</nav>";
                    }
                }
            }
        }
    }
}
