using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class admin_Update_subadmin : System.Web.UI.Page
{
    string connStr, current_user = "", user_name = "";
    string admin_email = "", complaint_level = "", insertsubadminquery = "", selectcategoryquery = "", sub_email = "";
    string selectsubadminquery = "",updatemoderatorquery="",selectsubadmin="",deletesubadminquery="";
    int category_id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        if (Session["email"] == null)
        {
            Response.Redirect(@"/lbs/index.aspx");
        }
        if (Session["email"] != null)
        {
            admin_email = Session["email"].ToString();
        }
        if (Session["typeofuser"] != null)
        {
            current_user = Session["typeofuser"].ToString();
            if (current_user.Equals("university_admin") == false)
            {
                if (current_user.Equals("institute_admin") == false)
                {
                    if (current_user.Equals("department_admin") == false)
                    {
                        Response.Redirect("/lbs/logout.aspx");
                    }
                }
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
                    selectsubadmin = "select * from university_subadmin where university_admin_email=@admin_email";
                    selectsubadminquery = "select * from university_subadmin where university_subadmin_email=@sub_email and university_admin_email=@admin_email";
                    selectcategoryquery = "select * from university_category where university_category_id = (select university_category_id from university_subadmin where university_subadmin_email=@sub_email)";

                    updatemoderatorquery = "update university_mode set university_subadmin_email=@email where university_subadmin_email=@sub_email";
                    insertsubadminquery = "insert into university_subadmin values(@first,@last,@email,@pass,@admin_email,@category_id)";
                    deletesubadminquery = "delete from university_subadmin where university_subadmin_email=@sub_email and university_admin_email=@admin_email";
                }
                if (complaint_level.Equals("institute"))
                {
                    selectsubadmin = "select * from institute_subadmin where institute_admin_email=@admin_email";
                    selectsubadminquery = "select * from institute_subadmin where institute_subadmin_email=@sub_email and institute_admin_email=@admin_email";
                    selectcategoryquery = "select * from institute_category where institute_category_id = (select institute_category_id from institute_subadmin where institute_subadmin_email=@sub_email)";

                    updatemoderatorquery = "update institute_mode set institute_subadmin_email=@email where institute_subadmin_email=@sub_email";
                    insertsubadminquery = "insert into institute_subadmin values(@first,@last,@email,@pass,@admin_email,@category_id)";
                    deletesubadminquery = "delete from institute_subadmin where institute_subadmin_email=@sub_email and institute_admin_email=@admin_email";
                }
                if (complaint_level.Equals("department"))
                {
                    selectsubadmin = "select * from department_subadmin where department_admin_email=@admin_email";
                    selectsubadminquery = "select * from department_subadmin where department_subadmin_email=@sub_email and department_admin_email=@admin_email";
                    selectcategoryquery = "select * from department_category where department_category_id = (select department_category_id from department_subadmin where department_subadmin_email=@sub_email)";

                    updatemoderatorquery = "update department_mode set department_subadmin_email=@email where department_subadmin_email=@sub_email";
                    insertsubadminquery = "insert into department_subadmin values(@first,@last,@email,@pass,@admin_email,@category_id)";
                    deletesubadminquery = "delete from department_subadmin where department_subadmin_email=@sub_email and department_admin_email=@admin_email";
                }
                if (!IsPostBack)
                {
                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(selectsubadmin, connection))
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@admin_email", admin_email);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        string subb_name = reader.GetString(0) + " " + reader.GetString(1);
                                        string subb_email = reader.GetString(2);
                                        if (!string.IsNullOrEmpty(subb_name) && !string.IsNullOrEmpty(subb_email))
                                        {
                                            AvailableSubadmin.Items.Add(new ListItem(subb_name, subb_email));
                                        }
                                    }
                                }
                                else
                                {
                                    //Response.Redirect(@"/lbs/admin/Admin_View.aspx");
                                }
                            }
                        }
                    }
                }
                if (this.IsPostBack)
                {
                    if (Password.Text.Equals(Confirm.Text))
                    {
                        Password.Attributes["value"] = Password.Text;
                        Confirm.Attributes["value"] = Confirm.Text;
                    }
                }
            }
        }
        catch (Exception e1)
        {
            System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
        }
    }
    protected void LoadData()
    {
        try
        {
            sub_email = AvailableSubadmin.SelectedValue;
            bool nodata = true;

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand(selectsubadminquery, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@sub_email", sub_email);
                    command.Parameters.AddWithValue("@admin_email", admin_email);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            nodata = false;
                            while (reader.Read())
                            {
                                string firstn = reader.GetString(0);
                                string lastn = reader.GetString(1);
                                string emailn = reader.GetString(2);
                                category_id = reader.GetInt32(5);
                                Session["category"] = ""+category_id;
                                First.Text = firstn;
                                Last.Text = lastn;
                                Email.Text = emailn;
                            }
                        }
                        else
                        {
                            //Response.Redirect(@"/lbs/admin/Admin_View.aspx");
                        }
                    }
                }
            }

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand(selectcategoryquery, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@sub_email", sub_email);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                category_id = reader.GetInt32(0);
                                string category_name = reader.GetString(1);
                                if (!string.IsNullOrEmpty(category_name))
                                {
                                    CategoryText.Text = category_name;
                                }
                            }
                        }
                        else
                        {
                            //Response.Redirect(@"/lbs/admin/Admin_View.aspx");
                        }
                    }
                }
            }
            if (nodata == false)
            {
                First.Enabled = true;
                Last.Enabled = true;
                Email.Enabled = true;
                Password.Enabled = true;
                Confirm.Enabled = true;
                UpdateButton.Enabled = true;
            }
        }
        catch (Exception e1)
        {
            System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
        }
    }
    protected void Change_Click(object sender, EventArgs e)
    {
        try
        {
            string first = First.Text;
            string last = Last.Text;
            string email = Email.Text;
            string pass = Password.Text;
            sub_email = AvailableSubadmin.SelectedValue;
            category_id=Convert.ToInt32(Session["category"]);
            if (sub_email.Equals("Select Subadmin")==false)
            {
                if (email.Equals(sub_email) == false)
                {
                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(insertsubadminquery, connection))
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@first", first);
                            command.Parameters.AddWithValue("@last", last);
                            command.Parameters.AddWithValue("@email", email);
                            command.Parameters.AddWithValue("@pass", pass);
                            command.Parameters.AddWithValue("@admin_email", admin_email);
                            command.Parameters.AddWithValue("@category_id", category_id);

                            command.ExecuteNonQuery();
                        }
                    }

                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(updatemoderatorquery, connection))
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@email", email);
                            command.Parameters.AddWithValue("@sub_email", sub_email);

                            command.ExecuteNonQuery();
                        }
                    }

                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(deletesubadminquery, connection))
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@sub_email", sub_email);
                            command.Parameters.AddWithValue("@admin_email", admin_email);

                            command.ExecuteNonQuery();
                        }
                    }


                    string message = "Updated Subadmin Successfully";
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("alert('");
                    sb.Append(message);
                    sb.Append("');");
                    sb.Append("window.location ='/lbs/admin/Update_subadmin.aspx';");
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", sb.ToString(), true);
                }
                else
                {
                    string message = "Subadmin Already Exist";
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("alert('");
                    sb.Append(message);
                    sb.Append("');");
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", sb.ToString(), true);
                }
            }
        }
        catch (Exception e1)
        {
            System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
        }
    }
    protected void AvailableSubadmin_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (AvailableSubadmin.SelectedValue.Equals("Select Subadmin") == false)
        {
            LoadData();
        }
        else
        {
            First.Text = "";
            Last.Text = "";
            Email.Text = "";
            Password.Text = "";
            Confirm.Text = "";
            CategoryText.Text = "";
            First.Enabled = false;
            Last.Enabled = false;
            Email.Enabled = false;
            Password.Enabled = false;
            Confirm.Enabled = false;
            UpdateButton.Enabled = false;
        }
    }
}