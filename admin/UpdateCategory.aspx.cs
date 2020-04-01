using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class admin_UpdateCategory : System.Web.UI.Page
{
    string connStr, current_user = "", complaint_level = "",admin_email="";
    string loadavailablecategoryquery = "", loadremovedcategoryquery = "";
    string changefromavailable = "", changetoavailable="";
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
                    loadavailablecategoryquery = "select * from university_category where status='Available' and university_id in (select university_id from university_admin where university_admin_email=@admin_email)";
                    loadremovedcategoryquery = "select * from university_category where status='Unavailable' and university_id in (select university_id from university_admin where university_admin_email=@admin_email)";

                    changefromavailable = "update university_category set status='Unavailable' where university_category_id=@category_id";
                    changetoavailable = "update university_category set status='Available' where university_category_id=@category_id";
                }
                if (complaint_level.Equals("institute"))
                {
                    loadavailablecategoryquery = "select * from institute_category where status='Available' and institute_id in (select institute_id from institute_admin where institute_admin_email=@admin_email)";
                    loadremovedcategoryquery = "select * from institute_category where status='Unavailable' and institute_id in (select institute_id from institute_admin where institute_admin_email=@admin_email)";

                    changefromavailable = "update institute_category set status='Unavailable' where institute_category_id=@category_id";
                    changetoavailable = "update institute_category set status='Available' where institute_category_id=@category_id";
                }
                if (complaint_level.Equals("department"))
                {
                    loadavailablecategoryquery = "select * from department_category where status='Available' and department_id in (select department_id from department_admin where department_admin_email=@admin_email)";
                    loadremovedcategoryquery = "select * from department_category where status='Unavailable' and department_id in (select department_id from department_admin where department_admin_email=@admin_email)";

                    changefromavailable = "update department_category set status='Unavailable' where department_category_id=@category_id";
                    changetoavailable = "update department_category set status='Available' where department_category_id=@category_id";
                }
                if (!IsPostBack)
                {
                    LoadDropdown();
                }
            }
            else
            {
                Response.Redirect(@"/lbs/admin/Admin_View.aspx");
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
                using (SqlCommand command = new SqlCommand(loadavailablecategoryquery, connection))
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
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand(loadremovedcategoryquery, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@admin_email", admin_email);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            UnavailableCategory.ClearSelection();
                            UnavailableCategory.Items.Clear();
                            UnavailableCategory.Items.Add(new ListItem("Select Category", "Select Category"));
                            while (reader.Read())
                            {
                                string category_id = reader.GetInt32(0).ToString();
                                string category_name = reader.GetString(1);
                                if (!string.IsNullOrEmpty(category_name))
                                {
                                    UnavailableCategory.Items.Add(new ListItem(category_name, category_id));
                                }
                            }
                        }
                        else
                        {
                            UnavailableCategory.ClearSelection();
                            UnavailableCategory.Items.Clear();
                            UnavailableCategory.Items.Add(new ListItem("Select Category", "Select Category"));
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
            string unavail_cat = UnavailableCategory.SelectedValue;
            if (UnavailableCategory.SelectedValue.Equals("Select Category") == false)
            {
                int category_id = Convert.ToInt32(unavail_cat);
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(changetoavailable, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@category_id", category_id);

                        command.ExecuteNonQuery();
                    }
                }
                LoadDropdown();
                string message = "Category Added Successfully";
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
    protected void Remove_Click(object sender, EventArgs e)
    {
        try
        {
            string avail_cat = AvailableCategory.SelectedValue;
            if (AvailableCategory.SelectedValue.Equals("Select Category") == false)
            {
                int category_id = Convert.ToInt32(avail_cat);
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(changefromavailable, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@category_id", category_id);

                        command.ExecuteNonQuery();
                    }
                }
                LoadDropdown();
                string message = "Category Removed Successfully";
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
}