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
                Response.Redirect(@"/lbs/index.aspx");
            }
        }
        if (IsPostBack == false)
        {
            if (Session["emailid"] != null)
            {
                Session["emailid"] = null;
            }
            if (Session["password"] != null)
            {
                Session["password"] = null;
            }
        }
    }
    protected void Login_Click(object sender, EventArgs e)
    {
        //Remove Css Class
        string alertclassname = "alert-danger";
        string first = "";
        string last = "";
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
        int logcount = 0;
        string typeuser = "";

        Email.Attributes.Add("class", String.Join(" ", Email
                      .Attributes["class"]
                      .Split(' ')
                      .Except(new string[] { "", alertclassname })
                      .ToArray()
              ));
        Password.Attributes.Add("class", String.Join(" ", Password
                      .Attributes["class"]
                      .Split(' ')
                      .Except(new string[] { "", alertclassname })
                      .ToArray()
              ));

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
                    logcount++;
                    typeuser += "System Admin|";
                    while (reader.Read())
                    {
                        first = reader.GetString(0);
                        last = reader.GetString(1);
                        systemadmin = true;
                    }
                }
            }

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand(uniadminquery, connection);
                connection.Open();

                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@pass", pass);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    logcount++;
                    typeuser += "University Admin|";
                    while (reader.Read())
                    {
                        first = reader.GetString(0);
                        last = reader.GetString(1);
                        uniadmin = true;
                    }
                }
            }

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand(insadminquery, connection);
                connection.Open();

                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@pass", pass);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    logcount++;
                    typeuser += "Institute Admin|";
                    while (reader.Read())
                    {
                        first = reader.GetString(0);
                        last = reader.GetString(1);
                        insadmin = true;
                    }
                }
            }

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand(depadminquery, connection);
                connection.Open();

                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@pass", pass);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    logcount++;
                    typeuser += "Department Admin|";
                    while (reader.Read())
                    {
                        first = reader.GetString(0);
                        last = reader.GetString(1);
                        depadmin = true;
                    }
                }
            }

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand(unisubadminquery, connection);
                connection.Open();

                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@pass", pass);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    logcount++;
                    typeuser += "University Sub Admin|";
                    while (reader.Read())
                    {
                        first = reader.GetString(0);
                        last = reader.GetString(1);
                        unisub = true;
                    }
                }
            }

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand(inssubadminquery, connection);
                connection.Open();

                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@pass", pass);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    logcount++;
                    typeuser += "Institute Sub Admin|";
                    while (reader.Read())
                    {
                        first = reader.GetString(0);
                        last = reader.GetString(1);
                        inssub = true;
                    }
                }
            }

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand(depsubadminquery, connection);
                connection.Open();

                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@pass", pass);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    logcount++;
                    typeuser += "Department Sub Admin|";
                    while (reader.Read())
                    {
                        first = reader.GetString(0);
                        last = reader.GetString(1);
                        depsub = true;
                    }
                }
            }

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand(unimodequery, connection);
                connection.Open();

                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@pass", pass);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    logcount++;
                    typeuser += "University Moderator|";
                    while (reader.Read())
                    {
                        first = reader.GetString(0);
                        last = reader.GetString(1);
                        unimode = true;
                    }
                }
            }

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand(insmodequery, connection);
                connection.Open();

                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@pass", pass);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    logcount++;
                    typeuser += "Institute Moderator|";
                    while (reader.Read())
                    {
                        first = reader.GetString(0);
                        last = reader.GetString(1);
                        insmode = true;
                    }
                }
            }

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand(depmodequery, connection);
                connection.Open();

                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@pass", pass);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    logcount++;
                    typeuser += "Department Moderator|";
                    while (reader.Read())
                    {
                        first = reader.GetString(0);
                        last = reader.GetString(1);
                        depmode = true;
                    }
                }
            }

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand(studentquery, connection);
                connection.Open();

                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@pass", pass);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    logcount++;
                    typeuser += "Student|";
                    while (reader.Read())
                    {
                        first = reader.GetString(0);
                        last = reader.GetString(1);
                        student = true;
                    }
                }
            }
            if ((systemadmin == false) && (uniadmin == false) && (insadmin == false) && (depadmin == false) && (unisub == false) && (inssub == false) && (depsub == false) && (unimode == false) && (insmode == false) && (depmode == false) && (student == false))
            {
                //Login Unsuccessful
                Email.Text = "";
                Password.Text = "";
                //Add Css Class
                Email.Attributes.Add("class", String.Join(" ", Email
                       .Attributes["class"]
                       .Split(' ')
                       .Except(new string[] { "", alertclassname })
                       .Concat(new string[] { alertclassname })
                       .ToArray()
               ));
                Password.Attributes.Add("class", String.Join(" ", Password
                       .Attributes["class"]
                       .Split(' ')
                       .Except(new string[] { "", alertclassname })
                       .Concat(new string[] { alertclassname })
                       .ToArray()
               ));
                string message = "Invalid Login Details";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("');");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", sb.ToString(), true);
            }
            if (logcount == 1)
            {
                if (systemadmin == true)
                {
                    Session["email"] = email;
                    Session["typeofuser"] = "system_admin";
                    if ((first.Equals("") == false) && (last.Equals("") == false))
                    {
                        Session["username"] = first + " " + last;
                    }
                    Response.Redirect(@"/lbs/systemAdmin/Register_systemAdmin.aspx");
                }
                if (uniadmin == true)
                {
                    Session["email"] = email;
                    Session["typeofuser"] = "university_admin";
                    if ((first.Equals("") == false) && (last.Equals("") == false))
                    {
                        Session["username"] = first + " " + last;
                    }
                    Response.Redirect(@"/lbs/admin/Admin_View.aspx");
                }
                if (insadmin == true)
                {
                    Session["email"] = email;
                    Session["typeofuser"] = "institute_admin";
                    if ((first.Equals("") == false) && (last.Equals("") == false))
                    {
                        Session["username"] = first + " " + last;
                    }
                    Response.Redirect(@"/lbs/admin/Admin_View.aspx");
                }
                if (depadmin == true)
                {
                    Session["email"] = email;
                    Session["typeofuser"] = "department_admin";
                    if ((first.Equals("") == false) && (last.Equals("") == false))
                    {
                        Session["username"] = first + " " + last;
                    }
                    Response.Redirect(@"/lbs/admin/Admin_View.aspx");
                }
                if (unisub == true)
                {
                    Session["email"] = email;
                    Session["typeofuser"] = "university_sub_admin";
                    if ((first.Equals("") == false) && (last.Equals("") == false))
                    {
                        Session["username"] = first + " " + last;
                    }
                    Response.Redirect(@"/lbs/subAdmin/subadmin_index.aspx");
                }
                if (inssub == true)
                {
                    Session["email"] = email;
                    Session["typeofuser"] = "institute_sub_admin";
                    if ((first.Equals("") == false) && (last.Equals("") == false))
                    {
                        Session["username"] = first + " " + last;
                    }
                    Response.Redirect(@"/lbs/subAdmin/subadmin_index.aspx");
                }
                if (depsub == true)
                {
                    Session["email"] = email;
                    Session["typeofuser"] = "department_sub_admin";
                    if ((first.Equals("") == false) && (last.Equals("") == false))
                    {
                        Session["username"] = first + " " + last;
                    }
                    Response.Redirect(@"/lbs/subAdmin/subadmin_index.aspx");
                }
                if (unimode == true)
                {
                    Session["email"] = email;
                    Session["typeofuser"] = "university_moderator";
                    if ((first.Equals("") == false) && (last.Equals("") == false))
                    {
                        Session["username"] = first + " " + last;
                    }
                    Response.Redirect(@"/lbs/moderator/track_complaint.aspx");
                }
                if (insmode == true)
                {
                    Session["email"] = email;
                    Session["typeofuser"] = "institute_moderator";
                    if ((first.Equals("") == false) && (last.Equals("") == false))
                    {
                        Session["username"] = first + " " + last;
                    }
                    Response.Redirect(@"/lbs/moderator/track_complaint.aspx");
                }
                if (depmode == true)
                {
                    Session["email"] = email;
                    Session["typeofuser"] = "department_moderator";
                    if ((first.Equals("") == false) && (last.Equals("") == false))
                    {
                        Session["username"] = first + " " + last;
                    }
                    Response.Redirect(@"/lbs/moderator/track_complaint.aspx");
                }
                if (student == true)
                {
                    Session["email"] = email;
                    Session["typeofuser"] = "student";
                    if ((first.Equals("") == false) && (last.Equals("") == false))
                    {
                        Session["username"] = first + " " + last;
                    }
                    Response.Redirect(@"/lbs/index.aspx");
                }
            }
            else if(logcount>1)
            {
                char[] separator = { '|'}; 
                String[] userlist = typeuser.Split(separator,StringSplitOptions.RemoveEmptyEntries);
                userradiolist.Items.Clear();
                userradiolist.Items.Add(new ListItem("Select Admin Type", "Select Admin Type"));
                foreach (string user in userlist)
                {
                    userradiolist.Items.Add(new ListItem(user, user));
                }
                Session["emailid"] = email;
                Session["password"] = pass;
                System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
                sb1.Append("ClickButtonTrigger();");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "call function", sb1.ToString(), true);
                //btnTrigger.ServerClick += new System.EventHandler(this.btnTrigger_Click);
            }
        }
        catch (Exception e1)
        {
            Console.WriteLine("Error Message: " + e1.StackTrace);
            System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
        }
    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        try
        {
            string query = "";

            string urltogo = "";

            string last = "";
            string first = "";
            string email = Session["emailid"].ToString();
            string pass = Session["password"].ToString();
            string typeofuser = "";

            string usertype = userradiolist.SelectedValue;

            if (usertype.Equals("System Admin"))
            {
                query = "select * from system_admin where system_admin_email=@email and password=@pass";
                urltogo = @"/lbs/systemAdmin/Register_systemAdmin.aspx";
                typeofuser = "system_admin";
            }
            if (usertype.Equals("University Admin"))
            {
                query = "select * from university_admin where university_admin_email=@email and password=@pass";
                urltogo = @"/lbs/admin/Admin_View.aspx";
                typeofuser = "university_admin";
            }
            if (usertype.Equals("Institute Admin"))
            {
                query = "select * from institute_admin where institute_admin_email=@email and password=@pass";
                urltogo = @"/lbs/admin/Admin_View.aspx";
                typeofuser = "institute_admin";
            }
            if (usertype.Equals("Department Admin"))
            {
                query = "select * from department_admin where department_admin_email=@email and password=@pass";
                urltogo = @"/lbs/admin/Admin_View.aspx";
                typeofuser = "department_admin";
            }
            if (usertype.Equals("University Sub Admin"))
            {
                query = "select * from university_subadmin where university_subadmin_email=@email and password=@pass";
                urltogo = @"/lbs/subAdmin/subadmin_index.aspx";
                typeofuser = "university_sub_admin";
            }
            if (usertype.Equals("Institute Sub Admin"))
            {
                query = "select * from institute_subadmin where institute_subadmin_email=@email and password=@pass";
                urltogo = @"/lbs/subAdmin/subadmin_index.aspx";
                typeofuser = "institute_sub_admin";
            }
            if (usertype.Equals("Department Sub Admin"))
            {
                query = "select * from department_subadmin where department_subadmin_email=@email and password=@pass";
                urltogo = @"/lbs/subAdmin/subadmin_index.aspx";
                typeofuser = "department_sub_admin";
            }
            if (usertype.Equals("University Moderator"))
            {
                query = "select * from university_mode where university_mode_email=@email and password=@pass";
                urltogo = @"/lbs/moderator/track_complaint.aspx";
                typeofuser = "university_moderator";
            }
            if (usertype.Equals("Institute Moderator"))
            {
                query = "select * from institute_mode where institute_mode_email=@email and password=@pass";
                urltogo = @"/lbs/moderator/track_complaint.aspx";
                typeofuser = "institute_moderator";
            }
            if (usertype.Equals("Department Moderator"))
            {
                query = "select * from department_mode where department_mode_email=@email and password=@pass";
                urltogo = @"/lbs/moderator/track_complaint.aspx";
                typeofuser = "department_moderator";
            }
            if (usertype.Equals("Student"))
            {
                query = "select * from student where student_email=@email and password=@pass";
                urltogo = @"/lbs/index.aspx";
                typeofuser = "student";
            }

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@pass", pass);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        first = reader.GetString(0);
                        last = reader.GetString(1);
                    }
                    Session["email"] = email;
                    Session["typeofuser"] = typeofuser;
                    if ((first.Equals("") == false) && (last.Equals("") == false))
                    {
                        Session["username"] = first + " " + last;
                    }
                    //System.Diagnostics.Debug.WriteLine("Email: " + email+" Password: "+pass+" Type of User: "+typeofuser+" First: "+first+" Last: "+last+" URL: "+urltogo);
                    Response.Redirect(urltogo);
                }
            }
        }
        catch (Exception e1)
        {
            System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
        }
    }
}