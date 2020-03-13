using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class login : System.Web.UI.Page
{
    string connStr;
    protected void Page_Load(object sender, EventArgs e)
    {
        connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        if (Session["email"] != null)
        {
            if (Session["typeofuser"] != null)
            {
                Response.Redirect("index.aspx");
            }
        }
    }
    protected void Login_Click(object sender, EventArgs e)
    {
        string email = Email.Text;
        string pass = Password.Text;
        string systemadminquery = "select * from system_admin where system_admin_email=@email and password=@pass";
        bool systemadmin = false;

        string uniadminquery = "select * from university_admin where university_admin_email=@email and password=@pass";
        string insadminquery = "select * from institute_admin where institute_admin_email=@email and password=@pass";
        string depadminquery = "select * from department_admin where department_admin_email=@email and password=@pass";
        bool uniadmin = false, insadmin = false, depadmin=false;

        string unisubadminquery = "select * from university_subadmin where university_subadmin_email=@email and password=@pass";
        string inssubadminquery = "select * from institute_subadmin where institute_subadmin_email=@email and password=@pass";
        string depsubadminquery = "select * from department_subadmin where department_subadmin_email=@email and password=@pass";
        bool unisub = false, inssub = false, depsub = false;

        string unimodequery = "select * from university_mode where university_mode_email=@email and password=@pass";
        string insmodequery = "select * from institute_mode where institute_mode_email=@email and password=@pass";
        string depmodequery = "select * from department_mode where department_mode_email=@email and password=@pass";
        bool unimode = false, insmode = false, depmode = false;

        string studentquery = "select * from student where student_email=@email and password=@pass";
        bool student = false;

        try
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand(systemadminquery, connection);
                connection.Open();

                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@pass", pass);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    systemadmin = true;
                }
            }
            if (systemadmin == false)
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    SqlCommand command = new SqlCommand(uniadminquery, connection);
                    connection.Open();

                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@pass", pass);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        uniadmin = true;
                    }
                }
            }
            if ((systemadmin == false) && (uniadmin==false))
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    SqlCommand command = new SqlCommand(insadminquery, connection);
                    connection.Open();

                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@pass", pass);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        insadmin = true;
                    }
                }
            }
            if ((systemadmin == false) && (uniadmin == false) && (insadmin == false))
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    SqlCommand command = new SqlCommand(depadminquery, connection);
                    connection.Open();

                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@pass", pass);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        depadmin = true;
                    }
                }
            }
            if ((systemadmin == false) && (uniadmin == false) && (insadmin == false) && (depadmin == false))
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    SqlCommand command = new SqlCommand(unisubadminquery, connection);
                    connection.Open();

                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@pass", pass);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        unisub = true;
                    }
                }
            }
            if ((systemadmin == false) && (uniadmin == false) && (insadmin == false) && (depadmin == false) && (unisub == false))
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    SqlCommand command = new SqlCommand(inssubadminquery, connection);
                    connection.Open();

                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@pass", pass);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        inssub = true;
                    }
                }
            }
            if ((systemadmin == false) && (uniadmin == false) && (insadmin == false) && (depadmin == false) && (unisub == false) && (inssub == false))
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    SqlCommand command = new SqlCommand(depsubadminquery, connection);
                    connection.Open();

                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@pass", pass);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        depsub = true;
                    }
                }
            }
            if ((systemadmin == false) && (uniadmin == false) && (insadmin == false) && (depadmin == false) && (unisub == false) && (inssub == false) && (depsub == false))
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    SqlCommand command = new SqlCommand(unimodequery, connection);
                    connection.Open();

                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@pass", pass);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        unimode = true;
                    }
                }
            }
            if ((systemadmin == false) && (uniadmin == false) && (insadmin == false) && (depadmin == false) && (unisub == false) && (inssub == false) && (depsub == false) && (unimode== false))
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    SqlCommand command = new SqlCommand(insmodequery, connection);
                    connection.Open();

                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@pass", pass);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        insmode = true;
                    }
                }
            }
            if ((systemadmin == false) && (uniadmin == false) && (insadmin == false) && (depadmin == false) && (unisub == false) && (inssub == false) && (depsub == false) && (unimode == false) && (insmode == false))
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    SqlCommand command = new SqlCommand(depmodequery, connection);
                    connection.Open();

                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@pass", pass);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        depmode = true;
                    }
                }
            }
            if ((systemadmin == false) && (uniadmin == false) && (insadmin == false) && (depadmin == false) && (unisub == false) && (inssub == false) && (depsub == false) && (unimode == false) && (insmode == false) && (depmode == false))
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    SqlCommand command = new SqlCommand(studentquery, connection);
                    connection.Open();

                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@pass", pass);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        student = true;
                    }
                }
            }
            if ((systemadmin == false) && (uniadmin == false) && (insadmin == false) && (depadmin == false) && (unisub == false) && (inssub == false) && (depsub == false) && (unimode == false) && (insmode == false) && (depmode == false) && (student == false))
            {
                //Login Unsuccessful
            }
            if (systemadmin == true)
            {

            }
            if (uniadmin == true)
            {

            }
            if (insadmin == true)
            {

            }
            if (depadmin == true)
            {

            }
            if (unisub == true)
            {

            } 
            if (inssub == true)
            {

            }
            if (depsub == true)
            {

            }
            if (unimode == true)
            {

            }
            if (insmode == true)
            {

            }
            if (depmode == true)
            {

            }
            if (student == true)
            {
                Session["email"] = email;
                Session["typeofuser"] = "student";
                Response.Redirect("index.aspx");
            }
        }
        catch (Exception e1)
        {
            Console.WriteLine("Error Message: " + e1.StackTrace);
            System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
        }
    }
}