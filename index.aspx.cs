using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
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
                if (Session["username"] != null)
                {
                    string current_user = Session["typeofuser"].ToString();
                    if (current_user.Equals("system_admin"))
                    {
                        Response.Redirect(@"/lbs/systemAdmin/Register_admin.aspx");
                    }
                    if (current_user.Equals("university_moderator") || current_user.Equals("institute_moderator") || current_user.Equals("department_moderator"))
                    {
                        Response.Redirect(@"/lbs/moderator/track_complaint.aspx");
                    }
                    if (current_user.Equals("university_sub_admin") || current_user.Equals("institute_sub_admin") || current_user.Equals("department_sub_admin"))
                    {
                        Response.Redirect(@"/lbs/subAdmin/subadmin_index.aspx");
                    }
                    if (current_user.Equals("university_admin") || current_user.Equals("institute_admin") || current_user.Equals("department_admin"))
                    {
                        Response.Redirect(@"/lbs/admin/Admin_View.aspx");
                    }
                }
            }
        }
    }
}