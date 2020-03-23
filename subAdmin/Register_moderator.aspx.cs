using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Register_moderator : System.Web.UI.Page
{
    string connStr, current_user = "", sub_email = "";
    string complaint_level = "",insertquery="",selectquery="",status="";
    protected void Page_Load(object sender, EventArgs e)
    {
        connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        if (Session["email"] == null)
        {
            Response.Redirect(@"/lbs/index.aspx");
        }
        if (Session["email"] != null)
        {
            sub_email = Session["email"].ToString();
        }
        if (Session["typeofuser"] != null)
        {
            current_user = Session["typeofuser"].ToString();
            if (current_user.Contains("sub_admin") == false)
            {
                Response.Redirect("/lbs/logout.aspx");
            }
        }
        if (current_user.Contains("university"))
        {
            complaint_level = "university";
        }
        if (current_user.Contains("institute"))
        {
            complaint_level = "institute";
        }
        if (current_user.Contains("department"))
        {
            complaint_level = "department";
        }
        if (complaint_level.Equals("") == false)
        {
            if (complaint_level.Equals("university"))
            {
                selectquery = "select * from university_mode where university_subadmin_email=@sub_email";
                insertquery = "insert into university_mode values(@first,@last,@email,@pass,@sub_email,0,0,@status)";
            } 
            if (complaint_level.Equals("institute"))
            {
                selectquery = "select * from institute_mode where institute_subadmin_email=@sub_email";
                insertquery = "insert into institute_mode values(@first,@last,@email,@pass,@sub_email,0,0,@status)";
            }
            if (complaint_level.Equals("department"))
            {
                selectquery = "select * from department_mode where department_subadmin_email=@sub_email";
                insertquery = "insert into department_mode values(@first,@last,@email,@pass,@sub_email,0,0,@status)";
            }
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand(selectquery, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@sub_email", sub_email);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            status = "No";
                        }
                        else
                        {
                            status = "Yes";
                        }
                    }
                }
            }
        }
    }
    protected void RegisterModerator_Click(object sender, EventArgs e)
    {
        bool checkdrop = true;
        string alertclassname = "alert-danger";
        string first = First.Text;
        string last = Last.Text;
        string emailid = Email.Text;
        string password = Password.Text;
        string confirmpassword = Confirm.Text;
        if (password.Equals(confirmpassword))
        {
            //Remove a Class
            Password.Attributes.Add("class", String.Join(" ", Password
                      .Attributes["class"]
                      .Split(' ')
                      .Except(new string[] { "", alertclassname })
                      .ToArray()
              ));
            Confirm.Attributes.Add("class", String.Join(" ", Confirm
                      .Attributes["class"]
                      .Split(' ')
                      .Except(new string[] { "", alertclassname })
                      .ToArray()
              ));
        }
        else
        {

            // Add a class
            Password.Attributes.Add("class", String.Join(" ", Password
                       .Attributes["class"]
                       .Split(' ')
                       .Except(new string[] { "", alertclassname })
                       .Concat(new string[] { alertclassname })
                       .ToArray()
               ));
            Confirm.Attributes.Add("class", String.Join(" ", Confirm
                       .Attributes["class"]
                       .Split(' ')
                       .Except(new string[] { "", alertclassname })
                       .Concat(new string[] { alertclassname })
                       .ToArray()
               ));
            checkdrop = false;
        }
        if (checkdrop == true)
        {
            try
            {
                
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(insertquery, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@first", first);
                        command.Parameters.AddWithValue("@last", last);
                        command.Parameters.AddWithValue("@email", emailid);
                        command.Parameters.AddWithValue("@pass", password);
                        command.Parameters.AddWithValue("@sub_email", sub_email);
                        command.Parameters.AddWithValue("@status", status);

                        command.ExecuteNonQuery();
                        Response.Redirect(@"/lbs/subAdmin/subadmin_index.aspx");
                    }
                }
            }
            catch (Exception e1)
            {
                System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
            }
        }
    }
}