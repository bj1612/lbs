using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


public partial class Register_admin : System.Web.UI.Page
{
    string connStr,query;
    protected void Page_Load(object sender, EventArgs e)
    {
        connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        if (!IsPostBack)
        {
            if (Session["email"] != null)
            {
                if (Session["typeofuser"] != null)
                {
                    Response.Redirect(@"../lbs/index.aspx");
                }
            }
            
            university_choose.Style.Add("display", "none");
            institute_choose.Style.Add("display", "none");
            department_choose.Style.Add("display", "none");

            //University
            try
            {
                SqlConnection connection = new SqlConnection(connStr);
                using (connection)
                {
                    SqlCommand command = new SqlCommand("SELECT university_id,university_name FROM university", connection);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        university_choose.Items.Clear();
                        university_choose.Items.Add(new ListItem("Universiy Name", "University Name"));

                        while (reader.Read())
                        {
                            string university_id = reader.GetInt32(0).ToString();
                            string university_name = reader.GetString(1);
                            if (!string.IsNullOrEmpty(university_name))
                            {
                                university_choose.Items.Add(new ListItem(university_name, university_id));
                            }
                        }
                    }
                }
            }
            catch (Exception e1)
            {
                Console.WriteLine("Error Message: " + e1.StackTrace);
                System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
            }
        }
    }

    protected void register_admin(object sender, EventArgs e)
    {
        connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connStr);
        int uni_id = 0;
        int ins_id = 0;
        int dept_id = 0;

        string university = university_choose.SelectedItem.Value;
        string institute = institute_choose.SelectedItem.Value;
        string department = department_choose.SelectedItem.Value;
        try
        {
            if (university_choose.SelectedValue != "University Name" && institute_choose.SelectedValue == "Institute Name" && department_choose.SelectedValue == "Department Name")
            {
                uni_id = Convert.ToInt32(university);

                query = "insert into university_admin values(@first,@last,@email,@pass,@uid_id)";
                using (connection)
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@first", First.Text);
                        command.Parameters.AddWithValue("@last", Last.Text);
                        command.Parameters.AddWithValue("@email", Email.Text);
                        command.Parameters.AddWithValue("@pass", Password.Text);
                        command.Parameters.AddWithValue("@uid_id", uni_id);

                        command.ExecuteNonQuery();
                        Response.Redirect(@"/lbs/systemAdmin/Register_admin.aspx");                        
                    }
                }
            }
            else if (university_choose.SelectedValue != "University Name" && institute_choose.SelectedValue != "Institute Name" && department_choose.SelectedValue == "Department Name")
            {

                ins_id = Convert.ToInt32(institute);

                query = "insert into institute_admin values(@first,@last,@email,@pass,@ins_id)";
                using (connection)
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@first", First.Text);
                        command.Parameters.AddWithValue("@last", Last.Text);
                        command.Parameters.AddWithValue("@email", Email.Text);
                        command.Parameters.AddWithValue("@pass", Password.Text);
                        command.Parameters.AddWithValue("@ins_id", ins_id);

                        command.ExecuteNonQuery();
                        Response.Redirect(@"/lbs/systemAdmin/Register_admin.aspx");
                    }
                }
            }
            else if (university_choose.SelectedValue != "University Name" && institute_choose.SelectedValue != "Institute Name" && university_choose.SelectedValue != "University Name")
            {

                dept_id = Convert.ToInt32(department);

                query = "insert into department_admin values(@first,@last,@email,@pass,@dept_id)";
                using (connection)
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@first", First.Text);
                        command.Parameters.AddWithValue("@last", Last.Text);
                        command.Parameters.AddWithValue("@email", Email.Text);
                        command.Parameters.AddWithValue("@pass", Password.Text);
                        command.Parameters.AddWithValue("@dept_id", dept_id);

                        command.ExecuteNonQuery();
                        Response.Redirect(@"/lbs/systemAdmin/Register_admin.aspx");
                    }
                }
            }
            else { }
        }
        catch (Exception e1)
        {
            System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
        }
        
    }
    protected void choose_level_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (choose_level.SelectedItem.Value == "University")
        {
            university_choose.Style.Add("display", "true");
            institute_choose.Style.Add("display", "none");
            department_choose.Style.Add("display", "none");


        }
        else if (choose_level.SelectedItem.Value == "Institute")
        {
            university_choose.Style.Add("display", "true");
            institute_choose.Style.Add("display", "true");
            department_choose.Style.Add("display", "none");

        }
        else if (choose_level.SelectedItem.Value == "Department")
        {
            university_choose.Style.Add("display", "true");
            institute_choose.Style.Add("display", "true");
            department_choose.Style.Add("display", "true");
        }
        else 
        {
            university_choose.Style.Add("display", "none");
            institute_choose.Style.Add("display", "none");
            department_choose.Style.Add("display", "none");

        }
    }

    protected void university_choose_SelectedIndexChanged(object sender, EventArgs e)
    {
        connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        string university_selected = university_choose.SelectedValue;
        if (university_selected.Equals("University Name") == false)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connStr);
                using (connection)
                {
                    SqlParameter university_id_param = new SqlParameter();
                    university_id_param.ParameterName = "@uni_id";
                    university_id_param.SqlDbType = SqlDbType.Int;
                    university_id_param.Value = Convert.ToInt32(university_selected);

                    SqlCommand command = new SqlCommand("SELECT institute_id,institute_name FROM institute where university_id=@uni_id", connection);
                    connection.Open();
                    command.Parameters.Add(university_id_param);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        institute_choose.Items.Clear();
                        institute_choose.Items.Add(new ListItem("Institute Name", "Institute Name"));
                        while (reader.Read())
                        {
                            string institute_id = reader.GetInt32(0).ToString();
                            string institute_name = reader.GetString(1);
                            if (!string.IsNullOrEmpty(institute_name))
                            {
                                institute_choose.Items.Add(new ListItem(institute_name, institute_id));
                            }
                        }
                    }
                }
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.Message);
            }
        }
        else
        {
            institute_choose.Items.Clear();
            institute_choose.Items.Add(new ListItem("Institute Name", "Institute Name"));
            department_choose.Items.Clear();
            department_choose.Items.Add(new ListItem("Department Name", "Department Name"));
            university_choose.Items.FindByValue("University Name").Selected = true;
            institute_choose.Items.FindByValue("Institute Name").Selected = true;
            department_choose.Items.FindByValue("Department Name").Selected = true;
        }

    }
    protected void institute_choose_SelectedIndexChanged1(object sender, EventArgs e)
    {
        connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        string university_selected = university_choose.SelectedValue;
        string institute_selected = institute_choose.SelectedValue;
        if (university_selected.Equals("University Name") == false)
        {
            if (institute_selected.Equals("Institute Name") == false)
            {
                try
                {
                    SqlConnection connection = new SqlConnection(connStr);
                    using (connection)
                    {
                        SqlParameter institute_id_param = new SqlParameter();
                        institute_id_param.ParameterName = "@ins_id";
                        institute_id_param.SqlDbType = SqlDbType.Int;
                        institute_id_param.Direction = ParameterDirection.Input;
                        institute_id_param.Value = Convert.ToInt32(institute_selected);

                        SqlCommand command = new SqlCommand("SELECT department_id,department_name FROM department where institute_id=@ins_id", connection);
                        connection.Open();

                        command.Parameters.Add(institute_id_param);

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            department_choose.Items.Clear();
                            department_choose.Items.Add(new ListItem("Department Name", "Department Name"));
                            while (reader.Read())
                            {
                                string department_id = reader.GetInt32(0).ToString();
                                string department_name = reader.GetString(1);
                                if (!string.IsNullOrEmpty(department_name))
                                {
                                    department_choose.Items.Add(new ListItem(department_name, department_id));
                                }
                            }
                        }
                    }
                }
                catch (Exception e1)
                {
                    Console.WriteLine(e1.Message);
                }
            }
            else
            {
                department_choose.Items.Clear();
                department_choose.Items.Add(new ListItem("Department Name", "Department Name"));
                institute_choose.Items.FindByValue("Institute Name").Selected = true;
                department_choose.Items.FindByValue("Department Name").Selected = true;
            }
        }
        else
        {
            institute_choose.Items.Clear();
            institute_choose.Items.Add(new ListItem("Institute Name", "Institute Name"));
            department_choose.Items.Clear();
            department_choose.Items.Add(new ListItem("Department Name", "Department Name"));
            university_choose.Items.FindByValue("University Name").Selected = true;
            institute_choose.Items.FindByValue("Institute Name").Selected = true;
            department_choose.Items.FindByValue("Department Name").Selected = true;
        }
    }
}