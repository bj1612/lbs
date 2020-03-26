using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class systemAdmin_Add_institute : System.Web.UI.Page
{
    string connStr, query;
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
            if (IsPostBack == false)
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand("SELECT state_name FROM states order by state_name", connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                State.Items.Clear();
                                State.Items.Add(new ListItem("Select State", "Select State"));
                                while (reader.Read())
                                {
                                    string state_name = reader.GetString(0);
                                    if (!string.IsNullOrEmpty(state_name))
                                    {
                                        State.Items.Add(new ListItem(state_name, state_name));
                                    }
                                }
                            }
                        }
                    }
                }

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
                                AvailableUniversity.Items.Clear();
                                AvailableUniversity.Items.Add(new ListItem("Available University", "0"));
                                University.Items.Add(new ListItem("Select University", "0"));
                                while (reader.Read())
                                {
                                    string university_id = reader.GetInt32(0).ToString();
                                    string university_name = reader.GetString(1);
                                    if (!string.IsNullOrEmpty(university_name))
                                    {
                                        University.Items.Add(new ListItem(university_name, university_id));
                                        AvailableUniversity.Items.Add(new ListItem(university_name, university_id));
                                    }
                                }
                            }
                        }
                    }
                }
                AvailableInstitute.Items.Add(new ListItem("Available Institute", "0"));
            }
        }
        catch (Exception e1)
        {
            Console.WriteLine("Error Message: " + e1.StackTrace);
            System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
        }
    }
    protected void State_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string state_name = State.SelectedValue;
            if (state_name.Equals("Select State") == false)
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand("SELECT city_name FROM city where state_name=@state order by state_name", connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("state", state_name);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                City.Items.Clear();
                                City.Items.Add(new ListItem("Select City", "Select City"));
                                while (reader.Read())
                                {
                                    string city_name = reader.GetString(0);
                                    if (!string.IsNullOrEmpty(city_name))
                                    {
                                        City.Items.Add(new ListItem(city_name, city_name));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                City.ClearSelection();
                City.Items.Clear();
                City.Items.Add(new ListItem("Select City", "Select City"));
            }
        }
        catch (Exception e1)
        {
            Console.WriteLine("Error Message: " + e1.StackTrace);
            System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
        }
    }
    protected void Add_Click(object sender, EventArgs e)
    {
        if (State.SelectedValue.Equals("Select State") == false && City.SelectedValue.Equals("Select City") == false && University.SelectedValue.Equals("0") == false)
        {
            bool ins_exist = false;
            query = "select * from institute where institute_name=@name and university_id=@id";
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@name", InstituteName.Text);
                    command.Parameters.AddWithValue("@id", Convert.ToInt32(University.SelectedValue));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            ins_exist = true;
                        }
                    }
                }
            }

            if (ins_exist == false)
            {
                query = "insert into institute (institute_name,institute_state,institute_city,institute_address,institute_contact,university_id) values(@name,@state,@city,@address,@contact,@id)";
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@name", InstituteName.Text);
                        command.Parameters.AddWithValue("@state", State.SelectedValue);
                        command.Parameters.AddWithValue("@city", City.SelectedValue);
                        command.Parameters.AddWithValue("@address", Address.Text);
                        command.Parameters.AddWithValue("@contact", Convert.ToDecimal(Contact.Text));
                        command.Parameters.AddWithValue("@id", Convert.ToInt32(University.SelectedValue));

                        command.ExecuteNonQuery();
                        string message = "Added Institute Successfully";
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append("alert('");
                        sb.Append(message);
                        sb.Append("');");
                        sb.Append("window.location ='/lbs/systemAdmin/Register_admin.aspx';");
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", sb.ToString(), true);
                    }
                }
            }
            else
            {
                string message = "Institute Already Exist";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("');");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", sb.ToString(), true);
            }
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
    protected void AvailableUniversity_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string uni_id = AvailableUniversity.SelectedValue;
            if (uni_id.Equals("0") == false)
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand("SELECT institute_id,institute_name FROM institute where university_id=@id order by institute_name", connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@id", Convert.ToInt32(AvailableUniversity.SelectedValue));

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                AvailableInstitute.Items.Clear();
                                AvailableInstitute.Items.Add(new ListItem("Available Institute", "0"));
                                while (reader.Read())
                                {
                                    string institute_id = reader.GetInt32(0).ToString();
                                    string institute_name = reader.GetString(1);
                                    if (!string.IsNullOrEmpty(institute_name))
                                    {
                                        AvailableInstitute.Items.Add(new ListItem(institute_name, institute_id));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                AvailableInstitute.ClearSelection();
                AvailableInstitute.Items.Clear();
                AvailableInstitute.Items.Add(new ListItem("Available Institute", "0"));
            }
        }
        catch (Exception e1)
        {
            Console.WriteLine("Error Message: " + e1.StackTrace);
            System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
        }
    }
}