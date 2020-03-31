using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class admin_AddCategory : System.Web.UI.Page
{
    string connStr, current_user = "";
    string admin_email = "", complaint_level = "", insertquery = "", selectquery = "",selectidquery="";
    int id = 0;
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
                    selectquery = "select * from university_category where university_id in (select university_id from university_admin where university_admin_email=@admin_email)";
                    selectidquery = "select university_id from university_admin where university_admin_email=@admin_email";
                    insertquery = "insert into university_category(university_category_name,university_id,status) values(@category_name,@id,'Available')";
                }
                if (complaint_level.Equals("institute"))
                {
                    selectquery = "select * from institute_category where institute_id in (select institute_id from university_admin where institute_admin_email=@admin_email)";
                    selectidquery = "select institute_id from uinstitute_admin where institute_admin_email=@admin_email";
                    insertquery = "insert into institute_category(institute_category_name,institute_id,status) values(@category_name,@id,'Available')";
                }
                if (complaint_level.Equals("department"))
                {
                    selectquery = "select * from department_category where department_id in (select department_id from department_admin where department_admin_email=@admin_email)";
                    selectidquery = "select department_id from department_admin where department_admin_email=@admin_email";
                    insertquery = "insert into department_category(department_category,status) values(@category_name,@id,'Available')";
                }
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(selectidquery, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@admin_email", admin_email);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    id = Convert.ToInt32(reader.GetInt32(0));
                                }
                            }
                            else
                            {
                                //Response.Redirect(@"/lbs/admin/Admin_View.aspx");
                            }
                        }
                    }
                }
                if (!IsPostBack)
                {
                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(selectquery, connection))
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@admin_email", admin_email);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        string category_id = reader.GetInt32(0).ToString();
                                        string category_name = reader.GetString(1);
                                        if (!string.IsNullOrEmpty(category_name))
                                        {
                                            Category.Items.Add(new ListItem(category_name, category_id));
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
    protected void Add_Click(object sender, EventArgs e)
    {
        try
        {
            string category_name = CategoryName.Text;
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand(insertquery, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@category_name", category_name);
                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteNonQuery();
                }
            }
            string message = "Added Category Successfully";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("');");
            sb.Append("window.location ='/lbs/admin/AddCategory.aspx';");
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", sb.ToString(), true);
        }
        catch (Exception e1)
        {
            System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
        }
    }
}