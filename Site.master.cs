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
                        string stud_email = Session["email"].ToString();
                        username = Session["username"].ToString();
                        menudiv.InnerHtml = "";
                        menudiv.InnerHtml = @"<nav>";
                        menudiv.InnerHtml += @"<ul id='navigation'>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/index.aspx' style='text-decoration:none;'>Home</a></li>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/student/register_complaint.aspx' style='text-decoration:none;'>Register Complaint</a></li>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/student/track_complaint.aspx' style='text-decoration:none;'>Track Complaint</a></li>";
                        menudiv.InnerHtml += @"<li><a href='#' style='text-decoration:none;'>Welcome " + username + " <i class='ti-angle-down'></i></a>";
                        menudiv.InnerHtml += @"<ul class='submenu'>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/viewProfile.aspx?ID="+stud_email+"' style='text-decoration:none;'>Profile</a></li>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/logout.aspx' style='text-decoration:none;'>Logout</a></li>";
                        menudiv.InnerHtml += @"</ul>";
                        menudiv.InnerHtml += @"</li>";
                        menudiv.InnerHtml += @"</ul>";
                        menudiv.InnerHtml += @"</nav>";
                    }
                    if (current_user.Equals("university_moderator") || current_user.Equals("institute_moderator") || current_user.Equals("department_moderator"))
                    {
                        string mode_email = Session["email"].ToString();
                        username = Session["username"].ToString();
                        menudiv.InnerHtml = "";
                        menudiv.InnerHtml = @"<nav>";
                        menudiv.InnerHtml += @"<ul id='navigation'>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/moderator/track_complaint.aspx' style='text-decoration:none;'>Home</a></li>";
                        menudiv.InnerHtml += @"<li><a href='#' style='text-decoration:none;'>Welcome " + username + " <i class='ti-angle-down'></i></a>";
                        menudiv.InnerHtml += @"<ul class='submenu'>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/moderator/viewModeratorProfile.aspx?ID=" + mode_email + "' style='text-decoration:none;'>Profile</a></li>";
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
                        menudiv.InnerHtml += @"<li><a href='/lbs/subAdmin/subadmin_index.aspx' style='text-decoration:none;'>Home</a></li>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/subAdmin/SubAdmin_View.aspx' style='text-decoration:none;'>Quick View</a></li>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/subAdmin/Register_moderator.aspx' style='text-decoration:none;'>Register Moderator</a></li>";
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
                        menudiv.InnerHtml += @"<li><a href='/lbs/admin/Admin_View.aspx' style='text-decoration:none;'>Home</a></li>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/admin/Register_subadmin.aspx' style='text-decoration:none;'>Register Sub Admin</a></li>";
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
