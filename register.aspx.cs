using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient; 

public partial class Register : System.Web.UI.Page
{
    string connStr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            try
            {
                SqlConnection connection = new SqlConnection(connStr);
                using (connection)
                {
                    SqlCommand command = new SqlCommand("SELECT university_id,university_name FROM university", connection);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string university_id = reader.GetInt32(0).ToString();
                            string item = reader.GetString(1);
                            if (!string.IsNullOrEmpty(item))
                            {
                                university.Items.Add(new ListItem(item,university_id));
                            }
                        }
                        reader.NextResult();
                    }
                }
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.Message);
            }
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void inputState_SelectedIndexChanged(object sender, EventArgs e)
    {
        string university_selected = university.SelectedValue;
        string institute_selected = inputState.SelectedValue ;
        if (university_selected.Equals("University Name")==false)
        {
            if (institute_selected.Equals("Institute Name")==false)
            {
                try
                {
                    SqlConnection connection = new SqlConnection(connStr);
                    using (connection)
                    {
                        /*SqlParameter institute_id_param = new SqlParameter();
                        institute_id_param.ParameterName = "@ins_id";
                        institute_id_param.SqlDbType = SqlDbType.Int;
                        institute_id_param.Direction = ParameterDirection.Input;
                        institute_id_param.Value = Convert.ToInt32(institute_selected);*/

                        SqlCommand command = new SqlCommand("SELECT department_id,department_name FROM department where institute_id=@ins_id", connection);
                        command.Parameters.Add("@ins_id", SqlDbType.Int).Value = Convert.ToInt32(institute_selected);
                        connection.Open();

                        //command.Parameters.Add(institute_id_param);

                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string department_id = reader.GetInt32(0).ToString();
                                string item = reader.GetString(1);
                                if (!string.IsNullOrEmpty(item))
                                {
                                    DropDownList1.Items.Add(new ListItem(item,department_id));
                                }
                            }
                            reader.NextResult();
                        }
                    }
                }
                catch (Exception e1)
                {
                    Console.WriteLine(e1.Message);
                }
            }
        }
        else
        {
            university.Items.FindByValue("University Name").Selected = true;
            inputState.Items.FindByValue("Institute Name").Selected = true;
            DropDownList1.Items.FindByValue("Department Name").Selected = true;
        }
    }
    protected void university_SelectedIndexChanged(object sender, EventArgs e)
    {
        string university_selected = university.SelectedValue;
        if (university_selected.Equals("")==false)
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
                    //command.Parameters.Add("@uni_id", SqlDbType.Int).Value = Convert.ToInt32(university_selected);
                    connection.Open();

                    command.Parameters.Add(university_id_param);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string institute_id = reader.GetInt32(0).ToString();
                            string item = reader.GetString(1);
                            if (!string.IsNullOrEmpty(item))
                            {
                                inputState.Items.Add(new ListItem(item,institute_id));
                            }
                        }
                        reader.NextResult();
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
            university.Items.FindByValue("University Name").Selected = true;
            inputState.Items.FindByValue("Institute Name").Selected = true;
            DropDownList1.Items.FindByValue("Department Name").Selected = true;
        }
    }
}