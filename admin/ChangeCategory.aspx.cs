using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class admin_ChangeCategory : System.Web.UI.Page
{
    string connStr, current_user = "", user_name = "";
    string admin_email = "", complaint_level = "", updatecategoryquery = "", selectavailablecategoryquery = "";
    string selectsubadminquery = "";
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
                    selectavailablecategoryquery = "select * from university_category where status='Available' and university_id in (select university_id from university_admin where university_admin_email=@admin_email)";

                    selectsubadminquery = "select * from university_subadmin where university_category_id=@category_id and university_admin_email=@admin_email";

                    updatecategoryquery = "update university_category set university_category_name=@category_name where university_category_id=@category_id";
                }
                if (complaint_level.Equals("institute"))
                {
                    selectavailablecategoryquery = "select * from institute_category where status='Available' and institute_id in (select institute_id from institute_admin where institute_admin_email=@admin_email)";

                    selectsubadminquery = "select * from institute_subadmin where institute_category_id=@category_id and institute_admin_email=@admin_email";

                    updatecategoryquery = "update institute_category set institute_category_name=@category_name where institute_category_id=@category_id";
                }
                if (complaint_level.Equals("department"))
                {
                    selectavailablecategoryquery = "select * from department_category where status='Available' and department_id in (select department_id from department_admin where department_admin_email=@admin_email)";

                    selectsubadminquery = "select * from department_subadmin where department_category_id=@category_id and department_admin_email=@admin_email";

                    updatecategoryquery = "update department_category set department_category_name=@category_name where department_category_id=@category_id";
                }
                if (!IsPostBack)
                {
                    LoadDropdown();
                }
            }
        }
        catch (Exception e1)
        {
            System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
        }
    }
    protected void LoadDropdown()
    {
        using (SqlConnection connection = new SqlConnection(connStr))
        {
            using (SqlCommand command = new SqlCommand(selectavailablecategoryquery, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@admin_email", admin_email);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        AvailableCategory.ClearSelection();
                        AvailableCategory.Items.Clear();
                        AvailableCategory.Items.Add(new ListItem("Select Category", "Select Category"));
                        while (reader.Read())
                        {
                            string category_id = reader.GetInt32(0).ToString();
                            string category_name = reader.GetString(1);
                            if (!string.IsNullOrEmpty(category_name))
                            {
                                AvailableCategory.Items.Add(new ListItem(category_name, category_id));
                            }
                        }
                    }
                    else
                    {
                        AvailableCategory.ClearSelection();
                        AvailableCategory.Items.Clear();
                        AvailableCategory.Items.Add(new ListItem("Select Category", "Select Category"));
                    }
                }
            }
        }
        First.Text = "";
        Last.Text = "";
        Email.Text = "";
        CategoryText.Text = "";
        CategoryText.Enabled = false;
        UpdateButton1.Enabled = false;
    }
    protected void LoadData()
    {
        try
        {
            string availcat = AvailableCategory.SelectedValue;
            CategoryText.Text = AvailableCategory.SelectedItem.Text;
            category_id = Convert.ToInt32(availcat);
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand(selectsubadminquery, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@category_id", category_id);
                    command.Parameters.AddWithValue("@admin_email", admin_email);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string firstn = reader.GetString(0);
                                string lastn = reader.GetString(1);
                                string emailn = reader.GetString(2);
                                First.Text = firstn;
                                Last.Text = lastn;
                                Email.Text = emailn;
                            }
                        }
                        else
                        {
                            First.Text = "No Subadmin Assigned";
                            Last.Text = "No Subadmin Assigned";
                            Email.Text = "No Subadmin Assigned";
                            //Response.Redirect(@"/lbs/admin/Admin_View.aspx");
                        }
                    }
                }
            }
            CategoryText.Enabled = true;
            UpdateButton1.Enabled = true;
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
            string category_name = CategoryText.Text;
            string availcat = AvailableCategory.SelectedValue;

            if (AvailableCategory.SelectedValue.Equals("Select Category") == false)
            {
                category_id = Convert.ToInt32(availcat);
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(updatecategoryquery, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@category_name", category_name);
                        command.Parameters.AddWithValue("@category_id", category_id);

                        command.ExecuteNonQuery();
                    }
                }

                LoadDropdown();

                string message = "Changed Category Successfully";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("');");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", sb.ToString(), true);
            }
            else
            {
                string message = "Please Select Category";
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
    protected void AvailableCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (AvailableCategory.SelectedValue.Equals("Select Category") == false)
        {
            LoadData();
        }
        else
        {
            First.Text = "";
            Last.Text = "";
            Email.Text = "";
            CategoryText.Text = "";
            CategoryText.Enabled = false;
            UpdateButton1.Enabled = false;
        }
    }
}