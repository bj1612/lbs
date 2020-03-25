using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class viewModeratorProfile : System.Web.UI.Page
{
    string connStr;
    string check_email="",mode_email = "", current_user = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

        if (Session["email"] != null)
        {
            check_email = Session["email"].ToString();
        }
        else
        {
            Response.Redirect(@"/lbs/index.aspx");
        }
        if (Session["typeofuser"] != null)
        {
            current_user = Session["typeofuser"].ToString();
            if (current_user.Equals("student"))
            {
                Response.Redirect(@"/lbs/index.aspx");
            }
        }
        if (Request.QueryString["ID"] != null)
        {
            mode_email = Request.QueryString["ID"].ToString();
            if (check_email.Equals(mode_email)==false)
            {
                if (current_user.Contains("moderator"))
                {
                    Response.Redirect(@"/lbs/index.aspx");
                }
            }
        }
        else
        {
            Response.Redirect(@"/lbs/index.aspx");
        }
        try
        {
            string fetchmoderatorinfoquery="";
            if(current_user.Contains("university"))
            {
                fetchmoderatorinfoquery="select * from university_mode where university_mode_email=@mode_email";
            }
            if (current_user.Contains("institute"))
            {
                fetchmoderatorinfoquery = "select * from institute_mode where institute_mode_email=@mode_email";
            }
            if (current_user.Contains("department"))
            {
                fetchmoderatorinfoquery = "select * from department_mode where department_mode_email=@mode_email";
            }
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand(fetchmoderatorinfoquery, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@mode_email", mode_email);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string first_name = reader.GetString(0);
                                string last_name = reader.GetString(1);
                                string completeno = reader.GetInt32(5).ToString();
                                string totalno = reader.GetInt32(6).ToString();
                                string status = reader.GetString(7);
                                First.Text = first_name;
                                Last.Text = last_name;
                                Email.Text = mode_email;
                                CompleteNo.Text = completeno;
                                TotalNo.Text = totalno;
                                if (status.Equals("Off Duty"))
                                {
                                    Status.Text = status;
                                }
                                else
                                {
                                    Status.Text = "Available";
                                }
                            }
                        }
                        else
                        {
                            Response.Redirect(@"/lbs/index.aspx");
                        }
                    }
                }
            }
        }
        catch (Exception e1)
        {
            System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
        }
    }
}