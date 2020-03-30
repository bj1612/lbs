using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Register_subadmin : System.Web.UI.Page
{
    string connStr, current_user = "", user_name = "";
    string admin_email = "", complaint_level = "", insertquery = "", selectquery = "";

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
                    selectquery = "select * from university_category where university_category_id not in (select university_category_id from university_subadmin where university_admin_email=@admin_email) and university_id in (select university_id from university_admin where university_admin_email=@admin_email)";
                    insertquery = "insert into university_subadmin values(@first,@last,@email,@pass,@admin_email,@category_id)";
                }
                if (complaint_level.Equals("institute"))
                {
                    selectquery = "select * from institute_category where institute_category_id not in (select institute_category_id from institute_subadmin where institute_admin_email=@admin_email) and institute_id in (select institute_id from university_admin where institute_admin_email=@admin_email)";
                    insertquery = "insert into institute_subadmin values(@first,@last,@email,@pass,@admin_email,@category_id)";
                }
                if (complaint_level.Equals("department"))
                {
                    selectquery = "select * from department_category where department_category_id not in (select department_category_id from department_subadmin where department_admin_email=@admin_email) and department_id in (select department_id from department_admin where department_admin_email=@admin_email)";
                    insertquery = "insert into department_subadmin values(@first,@last,@email,@pass,@admin_email,@category_id)";
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
    protected void RegisterSubadmin_Click(object sender, EventArgs e)
    {
        bool checkdrop = true;
        string alertclassname = "alert-danger";
        string first = First.Text;
        string last = Last.Text;
        string emailid = Email.Text;
        string password = Password.Text;
        string confirmpassword = Confirm.Text;
        int category_id=Convert.ToInt32(Category.SelectedValue);
        if (category_id != 0)
        {
            //Remove a Class
            Category.Attributes.Add("class", String.Join(" ", Category
                      .Attributes["class"]
                      .Split(' ')
                      .Except(new string[] { "", alertclassname })
                      .ToArray()
              ));
        }
        else
        {
            Category.Attributes.Add("class", String.Join(" ", Category
                       .Attributes["class"]
                       .Split(' ')
                       .Except(new string[] { "", alertclassname })
                       .Concat(new string[] { alertclassname })
                       .ToArray()
               ));
            checkdrop = false;
        }
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
                        command.Parameters.AddWithValue("@admin_email", admin_email);
                        command.Parameters.AddWithValue("@category_id", category_id);

                        command.ExecuteNonQuery();
                        Response.Redirect(@"/lbs/Admin/Admin_View.aspx");
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