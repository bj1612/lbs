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
    string connStr;
    protected void Page_Load(object sender, EventArgs e)
    {
        connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        
        if (Session["email"] != null)
        {
            if (Session["typeofuser"] != null)
            {
                //
            }
        }
        else
        {
            Response.Redirect(@"/lbs/index.aspx");
        }
        university_choose.Style.Add("display", "true");

        institute_choose.Style.Add("display", "none");
        department_choose.Style.Add("display", "none");

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
    protected void register_admin(object sender, EventArgs e) 
    {
        connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        SqlConnection sqlconn = new SqlConnection(connStr);

        string university = university_choose.SelectedItem.Value;
        string institute = institute_choose.SelectedItem.Value;
        string department = department_choose.SelectedItem.Value;

        /*if (university != "University Name" && institute==null && department==null)
        {
            string query = "insert into university_admin";
        }*/

        /*string query = "select * from department";
        SqlCommand sqlcomm = new SqlCommand(query, sqlconn);
        sqlconn.Open();
        //SqlDataReader dr = sqlcomm.ExecuteNonQuery();
        SqlDataReader reader = sqlcomm.ExecuteReader();
        if (reader.HasRows)
        { 
            while(reader.Read())
            {
                show.Text = reader.GetString(2);
            }
        }*/    
    }
    protected void choose_level_SelectedIndexChanged(object sender, EventArgs e)
    {
        connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        
        if (choose_level.SelectedItem.Value == "University")
        {
            university_choose.Style.Add("display", "true");

        }
        if (choose_level.SelectedItem.Value == "Institute")
        {
           university_choose.Style.Add("display", "true");
           institute_choose.Style.Add("display", "true");
            
        }
        if (choose_level.SelectedItem.Value == "Department")
        {
            university_choose.Style.Add("display", "true");
            institute_choose.Style.Add("display", "true");
            department_choose.Style.Add("display", "true");
        }
    }
    protected void institute_choose_SelectedIndexChanged1(object sender, EventArgs e)
    {

        connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        string institute_name = institute_choose.SelectedItem.Value;
        
    }
    protected void university_choose_SelectedIndexChanged(object sender, EventArgs e)
    {
        //institute_choose.Style.Add("display", "true");
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
                            string item = reader.GetString(1);
                            if (!string.IsNullOrEmpty(item))
                            {
                                institute_choose.Items.Add(new ListItem(item, institute_id));
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
}