using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


public partial class subAdmin_UpdateModerator : System.Web.UI.Page
{
    string connStr, current_user = "", sub_email = "", complaint_level = "",mode_email="";
    string changetooffduty = "", changefromoffduty = "", selectyesmoderator = "", updatemoderatorquery = "", updatetoyesmoderator="",selectonlymode="";
    string loadavailablemoderatorquery = "", loadremovedmoderatorquery = "";
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
        try
        {
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
                    loadavailablemoderatorquery = "select first_name,last_name,university_mode_email from university_mode where university_subadmin_email=@sub_email and status<>'Off Duty'";
                    loadremovedmoderatorquery = "select first_name,last_name,university_mode_email from university_mode where university_subadmin_email=@sub_email and status='Off Duty'";

                    selectonlymode = "select * from university_mode where status<>'Off Duty' and university_subadmin_email=@sub_email";
                    selectyesmoderator = "select * from university_mode where university_subadmin_email=@sub_email";
                    updatemoderatorquery="update university_mode set status='Yes' where university_mode_email=@update_moderator_email and university_subadmin_email=@sub_email";
                    changetooffduty = "update university_mode set status='Off Duty' where university_mode_email=@mode_email and university_subadmin_email=@sub_email";
                    changefromoffduty = "update university_mode set status=@status where university_mode_email=@mode_email and university_subadmin_email=@sub_email";
                }
                if (complaint_level.Equals("institute"))
                {
                    loadavailablemoderatorquery = "select first_name,last_name,institute_mode_email from institute_mode where institute_subadmin_email=@sub_email and status<>'Off Duty'";
                    loadremovedmoderatorquery = "select first_name,last_name,institute_mode_email from institute_mode where institute_subadmin_email=@sub_email and status='Off Duty'";

                    selectonlymode = "select * from institute_mode where status<>'Off Duty' and institute_subadmin_email=@sub_email";
                    selectyesmoderator = "select * from institute_mode where institute_subadmin_email=@sub_email";
                    updatemoderatorquery = "update institute_mode set status='Yes' where institute_mode_email=@update_moderator_email and institute_subadmin_email=@sub_email";
                    changetooffduty = "update institute_mode set status='Off Duty' where institute_mode_email=@mode_email and institute_subadmin_email=@sub_email";
                    changefromoffduty = "update institute_mode set status=@status where institute_mode_email=@mode_email and institute_subadmin_email=@sub_email";
                }
                if (complaint_level.Equals("department"))
                {
                    loadavailablemoderatorquery = "select first_name,last_name,department_mode_email from department_mode where department_subadmin_email=@sub_email and status<>'Off Duty'";
                    loadremovedmoderatorquery = "select first_name,last_name,department_mode_email from department_mode where department_subadmin_email=@sub_email and status='Off Duty'";

                    selectonlymode = "select * from department_mode where status<>'Off Duty' and department_subadmin_email=@sub_email";
                    selectyesmoderator = "select * from department_mode where department_subadmin_email=@sub_email";
                    updatemoderatorquery = "update department_mode set status='Yes' where department_mode_email=@update_moderator_email and department_subadmin_email=@sub_email";
                    changetooffduty = "update department_mode set status='Off Duty' where department_mode_email=@mode_email and department_subadmin_email=@sub_email";
                    changefromoffduty = "update department_mode set status=@status where department_mode_email=@mode_email and department_subadmin_email=@sub_email";
                }
            }
            if (IsPostBack == false)
            {
                LoadDropdown();
            }
        }
        catch (Exception e1)
        {
            System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
        }
    }
    protected void LoadDropdown()
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand(loadavailablemoderatorquery, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@sub_email", sub_email);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            AvailableModerator.Items.Clear();
                            AvailableModerator.ClearSelection();
                            AvailableModerator.Items.Add(new ListItem("Select Moderator", "Select Moderator"));
                            while (reader.Read())
                            {
                                string first_name = reader.GetString(0);
                                string last_name = reader.GetString(1);
                                string mode_email = reader.GetString(2);
                                if (!string.IsNullOrEmpty(first_name) && !string.IsNullOrEmpty(last_name))
                                {
                                    AvailableModerator.Items.Add(new ListItem(first_name + " " + last_name, mode_email));
                                }
                            }
                        }
                        else
                        {
                            AvailableModerator.Items.Clear();
                            AvailableModerator.ClearSelection();
                            AvailableModerator.Items.Add(new ListItem("Select Moderator", "Select Moderator"));
                        }
                    }
                }
            }

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand(loadremovedmoderatorquery, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@sub_email", sub_email);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            OffDutyModerator.Items.Clear();
                            OffDutyModerator.ClearSelection();
                            OffDutyModerator.Items.Add(new ListItem("Select Moderator", "Select Moderator"));
                            while (reader.Read())
                            {
                                string first_name = reader.GetString(0);
                                string last_name = reader.GetString(1);
                                string mode_email = reader.GetString(2);
                                if (!string.IsNullOrEmpty(first_name) && !string.IsNullOrEmpty(last_name))
                                {
                                    OffDutyModerator.Items.Add(new ListItem(first_name + " " + last_name, mode_email));
                                }
                            }
                        }
                        else
                        {
                            OffDutyModerator.Items.Clear();
                            OffDutyModerator.ClearSelection();
                            OffDutyModerator.Items.Add(new ListItem("Select Moderator", "Select Moderator"));
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
    protected void Add_Click(object sender, EventArgs e)
    {
        try
        {
            int countmode = 0;
            mode_email = OffDutyModerator.SelectedValue;
            if (mode_email.Equals("Select Moderator") == false)
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(selectonlymode, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@sub_email", sub_email);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                countmode++;
                            }
                        }
                    }
                }


                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(changefromoffduty, connection))
                    {
                        connection.Open();
                        if (countmode == 0)
                        {
                            command.Parameters.AddWithValue("@status", "Yes");
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@status", "No");
                        }
                        command.Parameters.AddWithValue("@mode_email", mode_email);
                        command.Parameters.AddWithValue("@sub_email", sub_email);

                        command.ExecuteNonQuery();
                    }
                }
                LoadDropdown();
                string message = "Moderator Added Successfully";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("');");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", sb.ToString(), true);
            }
            else
            {
                string message = "Please select value from dropdown";
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
    protected void Remove_Click(object sender, EventArgs e)
    {
        try
        {
            string update_moderator_email = "";
            string assign_moderator_email = "";
            string first_moderator = "",firststatus="";
            bool removeit = true;
            mode_email = AvailableModerator.SelectedValue;
            if (mode_email.Equals("Select Moderator") == false)
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(selectyesmoderator, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@sub_email", sub_email);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                bool firsttry = true;
                                while (reader.Read())
                                {
                                    //totalcount++;
                                    if (firsttry == true)
                                    {
                                        first_moderator = reader.GetString(2);
                                        firsttry = false;
                                        if (first_moderator.Equals(mode_email))
                                        {
                                            firststatus = reader.GetString(7);
                                            if (firststatus.Equals("Yes"))
                                            {
                                                removeit = false;
                                                while (reader.Read())
                                                {
                                                    update_moderator_email = reader.GetString(2);
                                                    break;
                                                }
                                                break;
                                            }
                                            else
                                            {
                                                removeit = true;
                                            }
                                        }
                                    }
                                    string status = reader.GetString(7);
                                    if (status.Equals("Yes"))
                                    {
                                        //statusyescount++;
                                        assign_moderator_email = reader.GetString(2);
                                        if (assign_moderator_email.Equals(mode_email))
                                        {
                                            removeit = false;
                                            while (reader.Read())
                                            {
                                                update_moderator_email = reader.GetString(2);
                                                break;
                                            }
                                            if (update_moderator_email.Equals("") == true)
                                            {
                                                if (first_moderator.Equals(assign_moderator_email) == false)
                                                {
                                                    update_moderator_email = first_moderator;
                                                }
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if (removeit == true)
                {

                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(changetooffduty, connection))
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@mode_email", mode_email);
                            command.Parameters.AddWithValue("@sub_email", sub_email);

                            command.ExecuteNonQuery();
                        }
                    }
                }
                else if (removeit == false)
                {
                    if (update_moderator_email.Equals(""))
                    {
                        //Only remove
                        using (SqlConnection connection = new SqlConnection(connStr))
                        {
                            using (SqlCommand command = new SqlCommand(changetooffduty, connection))
                            {
                                connection.Open();
                                command.Parameters.AddWithValue("@mode_email", mode_email);
                                command.Parameters.AddWithValue("@sub_email", sub_email);

                                command.ExecuteNonQuery();
                            }
                        }
                    }
                    else
                    {
                        //update status yes for updatemoderator
                        using (SqlConnection connection = new SqlConnection(connStr))
                        {
                            using (SqlCommand command = new SqlCommand(updatemoderatorquery, connection))
                            {
                                connection.Open();
                                command.Parameters.AddWithValue("@update_moderator_email", update_moderator_email);
                                command.Parameters.AddWithValue("@sub_email", sub_email);

                                command.ExecuteNonQuery();
                            }
                        }

                        //update status off duty for updatemoderator
                        using (SqlConnection connection = new SqlConnection(connStr))
                        {
                            using (SqlCommand command = new SqlCommand(changetooffduty, connection))
                            {
                                connection.Open();
                                command.Parameters.AddWithValue("@mode_email", mode_email);
                                command.Parameters.AddWithValue("@sub_email", sub_email);

                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }
                LoadDropdown();
                string message = "Moderator Removed Successfully";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("');");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", sb.ToString(), true);

            }
            else
            {
                string message = "Please select value from dropdown";
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