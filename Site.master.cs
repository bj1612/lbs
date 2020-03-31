using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Site : System.Web.UI.MasterPage
{
    string connStr;
    protected void Page_Load(object sender, EventArgs e)
    {
        connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
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
                        menudiv.InnerHtml += @"<li><a href='/lbs/ChangePassword.aspx' style='text-decoration:none;'>Change Password</a></li>";
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
                        menudiv.InnerHtml += @"<li><a href='/lbs/ChangePassword.aspx' style='text-decoration:none;'>Change Password</a></li>";
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
                        menudiv.InnerHtml += @"<li><a href='#' style='text-decoration:none;'>Moderator<i class='ti-angle-down'></i></a>";
                        menudiv.InnerHtml += @"<ul class='submenu'>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/subAdmin/Register_moderator.aspx' style='text-decoration:none;'>Register Moderator</a></li>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/subAdmin/UpdateModerator.aspx' style='text-decoration:none;'>Update Moderator</a></li>";
                        menudiv.InnerHtml += @"</ul>";
                        menudiv.InnerHtml += @"</li>";
                        menudiv.InnerHtml += @"<li><a href='#' style='text-decoration:none;'>Welcome " + username + " <i class='ti-angle-down'></i></a>";
                        menudiv.InnerHtml += @"<ul class='submenu'>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/ChangePassword.aspx' style='text-decoration:none;'>Change Password</a></li>";
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
                        menudiv.InnerHtml += @"<li><a href='#' style='text-decoration:none;'>Subadmin<i class='ti-angle-down'></i></a>";
                        menudiv.InnerHtml += @"<ul class='submenu'>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/admin/Register_subadmin.aspx' style='text-decoration:none;'>Register Subadmin</a></li>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/admin/Update_subadmin.aspx' style='text-decoration:none;'>Update Subadmin</a></li>";
                        menudiv.InnerHtml += @"</ul>";
                        menudiv.InnerHtml += @"</li>";
                        menudiv.InnerHtml += @"<li><a href='#' style='text-decoration:none;'>Category<i class='ti-angle-down'></i></a>";
                        menudiv.InnerHtml += @"<ul class='submenu'>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/admin/AddCategory.aspx' style='text-decoration:none;'>Add Category</a></li>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/admin/UpdateCategory.aspx' style='text-decoration:none;'>Update Category</a></li>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/admin/ChangeCategory.aspx' style='text-decoration:none;'>Change Category</a></li>";
                        menudiv.InnerHtml += @"</ul>";
                        menudiv.InnerHtml += @"</li>";
                        menudiv.InnerHtml += @"<li><a href='#' style='text-decoration:none;'>Welcome " + username + " <i class='ti-angle-down'></i></a>";
                        menudiv.InnerHtml += @"<ul class='submenu'>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/ChangePassword.aspx' style='text-decoration:none;'>Change Password</a></li>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/logout.aspx' style='text-decoration:none;'>Logout</a></li>";
                        menudiv.InnerHtml += @"</ul>";
                        menudiv.InnerHtml += @"</li>";
                        menudiv.InnerHtml += @"</ul>";
                        menudiv.InnerHtml += @"</nav>";
                    }
                    if (current_user.Equals("system_admin"))
                    {
                        username = Session["username"].ToString();
                        menudiv.InnerHtml = "";
                        menudiv.InnerHtml = @"<nav>";
                        menudiv.InnerHtml += @"<ul id='navigation'>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/systemAdmin/Register_systemAdmin.aspx' style='text-decoration:none;'>Home</a></li>";
                        menudiv.InnerHtml += @"<li><a href='#' style='text-decoration:none;'>Admin<i class='ti-angle-down'></i></a>";
                        menudiv.InnerHtml += @"<ul class='submenu'>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/systemAdmin/Register_admin.aspx' style='text-decoration:none;'>Register Admin</a></li>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/systemAdmin/Update_admin.aspx' style='text-decoration:none;'>Update Admin</a></li>";
                        menudiv.InnerHtml += @"</ul>";
                        menudiv.InnerHtml += @"</li>";
                        menudiv.InnerHtml += @"<li><a href='#' style='text-decoration:none;'>Add Details<i class='ti-angle-down'></i></a>";
                        menudiv.InnerHtml += @"<ul class='submenu'>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/systemAdmin/Add_university.aspx' style='text-decoration:none;'>Add University</a></li>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/systemAdmin/Add_institute.aspx' style='text-decoration:none;'>Add Institute</a></li>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/systemAdmin/Add_department.aspx' style='text-decoration:none;'>Add Department</a></li>";
                        menudiv.InnerHtml += @"</ul>";
                        menudiv.InnerHtml += @"</li>";
                        menudiv.InnerHtml += @"<li><a href='#' style='text-decoration:none;'>Welcome " + username + " <i class='ti-angle-down'></i></a>";
                        menudiv.InnerHtml += @"<ul class='submenu'>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/ChangePassword.aspx' style='text-decoration:none;'>Change Password</a></li>";
                        menudiv.InnerHtml += @"<li><a href='/lbs/logout.aspx' style='text-decoration:none;'>Logout</a></li>";
                        menudiv.InnerHtml += @"</ul>";
                        menudiv.InnerHtml += @"</li>";
                        menudiv.InnerHtml += @"</ul>";
                        menudiv.InnerHtml += @"</nav>";
                    }
                }
            }
        }

        try
        {
            int pendingcount = 0,completecount=0;
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand("select count(complaint_progress) as countcomplaint,complaint_level from university_complaint where complaint_progress='Pending' group by complaint_level UNION select count(complaint_progress) as countcomplaint,complaint_level from institute_complaint where complaint_progress='Pending' group by complaint_level UNION select count(complaint_progress) as countcomplaint,complaint_level from department_complaint where complaint_progress='Pending' group by complaint_level", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        pendingcount += reader.GetInt32(0);
                    }
                }
            }

            pendingspan.InnerHtml = "Pending [" + pendingcount + "]";

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand("select count(complaint_progress) as countcomplaint,complaint_level from university_complaint where complaint_progress='Completed' group by complaint_level UNION select count(complaint_progress) as countcomplaint,complaint_level from institute_complaint where complaint_progress='Completed' group by complaint_level UNION select count(complaint_progress) as countcomplaint,complaint_level from department_complaint where complaint_progress='Completed' group by complaint_level", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        completecount += reader.GetInt32(0);
                    }
                }
            }

            completedspan.InnerHtml = "Completed [" + completecount + "]";
            //Another Page hit code, to fetch value from xml
            /*DataSet tmpDs = new DataSet();
            tmpDs.ReadXml(Server.MapPath("/lbs/hitcounter.xml"));
            CountPageHit.InnerHtml = tmpDs.Tables[0].Rows[0]["hits"].ToString();*/
            CountPageHit.InnerHtml = Application["SiteVisitedCounter"].ToString();
            CountOnlineUser.InnerHtml = Application["OnlineUserCounter"].ToString();
        }
        catch (Exception e1)
        {
            System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
        }
    }
}
