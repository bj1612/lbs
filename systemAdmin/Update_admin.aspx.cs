using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class systemAdmin_Update_admin : System.Web.UI.Page
{
    string connStr;
    string complaint_level = "", insertadminquery = "";
    string selectadminquery = "", updatesubadminquery = "", selectadmin = "", deleteadminquery = "";
    int university_id = 0, institute_id = 0, department_id = 0;
    string selectedadmin = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        if (Session["email"] == null)
        {
            Response.Redirect(@"/lbs/index.aspx");
        }
        if (Session["typeofuser"] == null)
        {
            string current_user = Session["typeofuser"].ToString();
            if (current_user.Equals("system_admin") == false)
            {
                Response.Redirect(@"/lbs/index.aspx");
            }
        }
        try
        {
            
            if (!IsPostBack)
            {
                UniversityDiv.Style.Add("display", "none");
                InstituteDiv.Style.Add("display", "none");
                DepartmentDiv.Style.Add("display", "none");

                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand("SELECT university_id,university_name FROM university order by university_name", connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                University.Items.Clear();
                                University.Items.Add(new ListItem("Select University", "0"));
                                while (reader.Read())
                                {
                                    string university_id = reader.GetInt32(0).ToString();
                                    string university_name = reader.GetString(1);
                                    if (!string.IsNullOrEmpty(university_name))
                                    {
                                        University.Items.Add(new ListItem(university_name, university_id));
                                    }
                                }
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
        catch (Exception e1)
        {
            System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
        }
    }
    protected void LoadData()
    {
        try
        {
            complaint_level = AdminType.SelectedValue;
            university_id=Convert.ToInt32(University.SelectedValue);
            institute_id = Convert.ToInt32(Institute.SelectedValue);
            department_id = Convert.ToInt32(Department.SelectedValue);
            bool nodata = true;
            if (complaint_level.Equals("Type") == false)
            {
                if (complaint_level.Equals("University"))
                {
                    selectadminquery="select * from university_admin where university_id=@id";
                }
                if (complaint_level.Equals("Institute"))
                {
                    selectadminquery="select * from institute_admin where institute_id=@id";
                }
                if (complaint_level.Equals("Department"))
                {
                    selectadminquery = "select * from department_admin where department_id=@id";
                }

                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(selectadminquery, connection))
                    {
                        connection.Open();
                        if (complaint_level.Equals("University"))
                        {
                            command.Parameters.AddWithValue("@id", university_id);
                        }
                        if (complaint_level.Equals("Institute"))
                        {
                            command.Parameters.AddWithValue("@id", institute_id);
                        }
                        if (complaint_level.Equals("Department"))
                        {
                            command.Parameters.AddWithValue("@id", department_id);
                        }

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
                                    First.Text = firstn;
                                    Last.Text = lastn;
                                    Email.Text = emailn;
                                    Session["selectedadmin1"] = ""+emailn;
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
            complaint_level = AdminType.SelectedValue;
            university_id = Convert.ToInt32(University.SelectedValue);
            institute_id = Convert.ToInt32(Institute.SelectedValue);
            department_id = Convert.ToInt32(Department.SelectedValue);
            if (Session["selectedadmin1"] != null)
            {
                selectedadmin = Session["selectedadmin1"].ToString();
            }
            if (complaint_level.Equals("Type") == false)
            {
                if (complaint_level.Equals("University"))
                {
                    insertadminquery = "insert into university_admin values(@first,@last,@email,@pass,@id)";
                    updatesubadminquery = "update university_subadmin set university_admin_email=@email where university_admin_email=@admin_email";
                    deleteadminquery = "delete from university_admin where university_admin_email=@admin_email";
                }
                if (complaint_level.Equals("Institute"))
                {
                    insertadminquery = "insert into institute_admin values(@first,@last,@email,@pass,@id)";
                    updatesubadminquery = "update institute_subadmin set institute_admin_email=@email where institute_admin_email=@admin_email";
                    deleteadminquery = "delete from institute_admin where institute_admin_email=@admin_email";
                }
                if (complaint_level.Equals("Department"))
                {
                    insertadminquery = "insert into department_admin values(@first,@last,@email,@pass,@id)";
                    updatesubadminquery = "update department_subadmin set department_admin_email=@email where department_admin_email=@admin_email";
                    deleteadminquery = "delete from department_admin where department_admin_email=@admin_email";
                }
                if (email.Equals(selectedadmin) == false)
                {
                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(insertadminquery, connection))
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@first", first);
                            command.Parameters.AddWithValue("@last", last);
                            command.Parameters.AddWithValue("@email", email);
                            command.Parameters.AddWithValue("@pass", pass);
                            if (complaint_level.Equals("University"))
                            {
                                command.Parameters.AddWithValue("@id", university_id);
                            }
                            if (complaint_level.Equals("Institute"))
                            {
                                command.Parameters.AddWithValue("@id", institute_id);
                            }
                            if (complaint_level.Equals("Department"))
                            {
                                command.Parameters.AddWithValue("@id", department_id);
                            }

                            command.ExecuteNonQuery();
                        }
                    }

                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(updatesubadminquery, connection))
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@email", email);
                            command.Parameters.AddWithValue("@admin_email", selectedadmin);

                            command.ExecuteNonQuery();
                        }
                    }

                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(deleteadminquery, connection))
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@admin_email", selectedadmin);

                            command.ExecuteNonQuery();
                        }
                    }


                    string message = "Updated Admin Successfully";
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("alert('");
                    sb.Append(message);
                    sb.Append("');");
                    sb.Append("window.location ='/lbs/systemAdmin/Update_admin.aspx';");
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", sb.ToString(), true);
                }
                else
                {
                    string message = "Admin Already Exist";
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("alert('");
                    sb.Append(message);
                    sb.Append("');");
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", sb.ToString(), true);
                }
            }
            else
            {
                string message = "Select Type";
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
    protected void University_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string uni_id = University.SelectedValue;
            if (uni_id.Equals("0") == false)
            {
                if (AdminType.SelectedValue.Equals("Institute") || AdminType.SelectedValue.Equals("Department"))
                {
                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand("SELECT institute_id,institute_name FROM institute where university_id=@id order by institute_name", connection))
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@id", Convert.ToInt32(University.SelectedValue));

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    Institute.Items.Clear();
                                    Institute.Items.Add(new ListItem("Select Institute", "0"));
                                    while (reader.Read())
                                    {
                                        string institute_id = reader.GetInt32(0).ToString();
                                        string institute_name = reader.GetString(1);
                                        if (!string.IsNullOrEmpty(institute_name))
                                        {
                                            Institute.Items.Add(new ListItem(institute_name, institute_id));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    LoadData();
                }
            }
            else
            {
                Institute.ClearSelection();
                Institute.Items.Clear();
                Institute.Items.Add(new ListItem("Select Institute", "0"));
                Department.ClearSelection();
                Department.Items.Clear();
                Department.Items.Add(new ListItem("Select Department", "0"));

                First.Text = "";
                Last.Text = "";
                Email.Text = "";
                Password.Text = "";
                Confirm.Text = "";
                First.Enabled = false;
                Last.Enabled = false;
                Email.Enabled = false;
                Password.Enabled = false;
                Confirm.Enabled = false;
                UpdateButton.Enabled = false;
            }
        }
        catch (Exception e1)
        {
            Console.WriteLine("Error Message: " + e1.StackTrace);
            System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
        }
    }
    protected void Institute_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string uni_id = Institute.SelectedValue;
            if (uni_id.Equals("0") == false)
            {
                if (AdminType.SelectedValue.Equals("Department"))
                {
                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand("SELECT department_id,department_name FROM department where institute_id=@id order by department_name", connection))
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@id", Convert.ToInt32(Institute.SelectedValue));

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    Department.Items.Clear();
                                    Department.Items.Add(new ListItem("Department", "0"));
                                    while (reader.Read())
                                    {
                                        string department_id = reader.GetInt32(0).ToString();
                                        string department_name = reader.GetString(1);
                                        if (!string.IsNullOrEmpty(department_name))
                                        {
                                            Department.Items.Add(new ListItem(department_name, department_id));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    LoadData();
                }
            }
            else
            {
                Department.ClearSelection();
                Department.Items.Clear();
                Department.Items.Add(new ListItem("Select Department", "0"));

                First.Text = "";
                Last.Text = "";
                Email.Text = "";
                Password.Text = "";
                Confirm.Text = "";
                First.Enabled = false;
                Last.Enabled = false;
                Email.Enabled = false;
                Password.Enabled = false;
                Confirm.Enabled = false;
                UpdateButton.Enabled = false;
            }
        }
        catch (Exception e1)
        {
            Console.WriteLine("Error Message: " + e1.StackTrace);
            System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
        }
    }
    protected void Department_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string uni_id = Department.SelectedValue;
            if (uni_id.Equals("0") == false)
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
                First.Enabled = false;
                Last.Enabled = false;
                Email.Enabled = false;
                Password.Enabled = false;
                Confirm.Enabled = false;
                UpdateButton.Enabled = false;
            }
        }
        catch (Exception e1)
        {
            Console.WriteLine("Error Message: " + e1.StackTrace);
            System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
        }
    }
    protected void AdminType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (AdminType.SelectedItem.Value == "University")
        {
            UniversityDiv.Style.Add("display", "true");
            InstituteDiv.Style.Add("display", "none");
            DepartmentDiv.Style.Add("display", "none");
            University.ClearSelection();
            Institute.ClearSelection();
            Institute.Items.Clear();
            Institute.Items.Add(new ListItem("Select Institute", "0"));
            Department.ClearSelection();
            Department.Items.Clear();
            Department.Items.Add(new ListItem("Select Department", "0"));

            First.Text = "";
            Last.Text = "";
            Email.Text = "";
            Password.Text = "";
            Confirm.Text = "";
            First.Enabled = false;
            Last.Enabled = false;
            Email.Enabled = false;
            Password.Enabled = false;
            Confirm.Enabled = false;
            UpdateButton.Enabled = false;
        }
        else if (AdminType.SelectedItem.Value == "Institute")
        {
            UniversityDiv.Style.Add("display", "true");
            InstituteDiv.Style.Add("display", "true");
            DepartmentDiv.Style.Add("display", "none");
            University.ClearSelection();
            Institute.ClearSelection();
            Institute.Items.Clear();
            Institute.Items.Add(new ListItem("Select Institute", "0"));
            Department.ClearSelection();
            Department.Items.Clear();
            Department.Items.Add(new ListItem("Select Department", "0"));

            First.Text = "";
            Last.Text = "";
            Email.Text = "";
            Password.Text = "";
            Confirm.Text = "";
            First.Enabled = false;
            Last.Enabled = false;
            Email.Enabled = false;
            Password.Enabled = false;
            Confirm.Enabled = false;
            UpdateButton.Enabled = false;
        }
        else if (AdminType.SelectedItem.Value == "Department")
        {
            UniversityDiv.Style.Add("display", "true");
            InstituteDiv.Style.Add("display", "true");
            DepartmentDiv.Style.Add("display", "true");
            University.ClearSelection();
            Institute.ClearSelection();
            Institute.Items.Clear();
            Institute.Items.Add(new ListItem("Select Institute", "0"));
            Department.ClearSelection();
            Department.Items.Clear();
            Department.Items.Add(new ListItem("Select Department", "0"));

            First.Text = "";
            Last.Text = "";
            Email.Text = "";
            Password.Text = "";
            Confirm.Text = "";
            First.Enabled = false;
            Last.Enabled = false;
            Email.Enabled = false;
            Password.Enabled = false;
            Confirm.Enabled = false;
            UpdateButton.Enabled = false;
        }
        else
        {
            UniversityDiv.Style.Add("display", "none");
            InstituteDiv.Style.Add("display", "none");
            DepartmentDiv.Style.Add("display", "none");
            University.ClearSelection();
            Institute.ClearSelection();
            Department.ClearSelection();

            First.Text = "";
            Last.Text = "";
            Email.Text = "";
            Password.Text = "";
            Confirm.Text = "";
            First.Enabled = false;
            Last.Enabled = false;
            Email.Enabled = false;
            Password.Enabled = false;
            Confirm.Enabled = false;
            UpdateButton.Enabled = false;
        }
    }
}