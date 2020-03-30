using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


public partial class ChangePassword : System.Web.UI.Page
{
    string connStr, current_user = "";
    string useremail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        if (Session["email"] != null)
        {
            useremail = Session["email"].ToString();
            if (Session["typeofuser"] != null)
            {
                current_user = Session["typeofuser"].ToString();
            }
            else
            {
                Response.Redirect(@"/lbs/index.aspx");
            }
        }
        else
        {
            Response.Redirect(@"/lbs/index.aspx");
        }
    }
    protected void Change_Click(object sender, EventArgs e)
    {
        string alertclassname = "alert-danger";

        string curpass = CurrentPassword.Text;
        string newpass = NewPassword.Text;
        string confirmnewpass = ConfirmNewPassword.Text;
        string selectquery = "", updatequery = "";
        try
        {
            if (newpass.Equals(confirmnewpass))
            {
                //Remove a Class
                NewPassword.Attributes.Add("class", String.Join(" ", NewPassword
                          .Attributes["class"]
                          .Split(' ')
                          .Except(new string[] { "", alertclassname })
                          .ToArray()
                  ));
                ConfirmNewPassword.Attributes.Add("class", String.Join(" ", ConfirmNewPassword
                          .Attributes["class"]
                          .Split(' ')
                          .Except(new string[] { "", alertclassname })
                          .ToArray()
                  ));

                //Change Password
                if (current_user.Equals("") == false)
                {
                    if (current_user.Equals("system_admin"))
                    {
                        selectquery = "select * from system_admin where system_admin_email=@email and password=@curpass";
                        updatequery = "update system_admin set password=@newpass where system_admin_email=@email";
                    }
                    if (current_user.Equals("university_admin"))
                    {
                        selectquery = "select * from university_admin where university_admin_email=@email and password=@curpass";
                        updatequery = "update university_admin set password=@newpass where university_admin_email=@email";
                    }
                    if (current_user.Equals("institute_admin"))
                    {
                        selectquery = "select * from institute_admin where institute_admin_email=@email and password=@curpass";
                        updatequery = "update institute_admin set password=@newpass where institute_admin_email=@email";
                    }
                    if (current_user.Equals("department_admin"))
                    {
                        selectquery = "select * from department_admin where department_admin_email=@email and password=@curpass";
                        updatequery = "update department_admin set password=@newpass where department_admin_email=@email";
                    }
                    if (current_user.Equals("university_sub_admin"))
                    {
                        selectquery = "select * from university_subadmin where university_subadmin_email=@email and password=@curpass";
                        updatequery = "update university_subadmin set password=@newpass where university_subadmin_email=@email";
                    }
                    if (current_user.Equals("institute_sub_admin"))
                    {
                        selectquery = "select * from institute_subadmin where institute_subadmin_email=@email and password=@curpass";
                        updatequery = "update institute_subadmin set password=@newpass where institute_subadmin_email=@email";
                    }
                    if (current_user.Equals("department_sub_admin"))
                    {
                        selectquery = "select * from department_subadmin where department_subadmin_email=@email and password=@curpass";
                        updatequery = "update department_subadmin set password=@newpass where department_subadmin_email=@email";
                    }
                    if (current_user.Equals("university_moderator"))
                    {
                        selectquery = "select * from university_mode where university_mode_email=@email and password=@curpass";
                        updatequery = "update university_mode set password=@newpass where university_mode_email=@email";
                    }
                    if (current_user.Equals("institute_moderator"))
                    {
                        selectquery = "select * from institute_mode where institute_mode_email=@email and password=@curpass";
                        updatequery = "update institute_mode set password=@newpass where institute_mode_email=@email";
                    }
                    if (current_user.Equals("department_moderator"))
                    {
                        selectquery = "select * from department_mode where department_mode_email=@email and password=@curpass";
                        updatequery = "update department_mode set password=@newpass where department_mode_email=@email";
                    }
                    if (current_user.Equals("student"))
                    {
                        selectquery = "select * from student where student_email=@email and password=@curpass";
                        updatequery = "update student set password=@newpass where student_email=@email";
                    }
                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        SqlCommand command = new SqlCommand(selectquery, connection);
                        connection.Open();

                        command.Parameters.AddWithValue("@email", useremail);
                        command.Parameters.AddWithValue("@curpass", curpass);

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            using (SqlConnection connection1 = new SqlConnection(connStr))
                            {
                                SqlCommand command1 = new SqlCommand(updatequery, connection1);
                                connection1.Open();

                                command1.Parameters.AddWithValue("@newpass", newpass);
                                command1.Parameters.AddWithValue("@email", useremail);

                                command1.ExecuteNonQuery();

                            }
                            string message = "Password changed successfully";
                            System.Text.StringBuilder sb = new System.Text.StringBuilder();
                            sb.Append("alert('");
                            sb.Append(message);
                            sb.Append("');");
                            sb.Append("window.location ='/lbs/index.aspx';");
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", sb.ToString(), true);
                        }
                        else
                        {
                            string message = "Please enter correct current password";
                            System.Text.StringBuilder sb = new System.Text.StringBuilder();
                            sb.Append("alert('");
                            sb.Append(message);
                            sb.Append("');");
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", sb.ToString(), true);
                        }
                    }

                }
            }
            else
            {

                // Add a class
                NewPassword.Attributes.Add("class", String.Join(" ", NewPassword
                           .Attributes["class"]
                           .Split(' ')
                           .Except(new string[] { "", alertclassname })
                           .Concat(new string[] { alertclassname })
                           .ToArray()
                   ));
                ConfirmNewPassword.Attributes.Add("class", String.Join(" ", ConfirmNewPassword
                           .Attributes["class"]
                           .Split(' ')
                           .Except(new string[] { "", alertclassname })
                           .Concat(new string[] { alertclassname })
                           .ToArray()
                   ));
                string message = "Password Doesnt Match Confirm Password";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("');");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", sb.ToString(), true);
            }
        }
        catch (Exception e1)
        {
            System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
        }
    }
}