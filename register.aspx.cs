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
                        while (reader.Read())
                        {
                            string university_id = reader.GetInt32(0).ToString();
                            string university_name = reader.GetString(1);
                            if (!string.IsNullOrEmpty(university_name))
                            {
                                university.Items.Add(new ListItem(university_name, university_id));
                            }
                        }
                    }
                }
            }
            catch (Exception e1)
            {
                Console.WriteLine("Error Message: "+e1.StackTrace);
                System.Diagnostics.Debug.WriteLine("Error Message: "+e1.StackTrace);
            }
            int year=Convert.ToInt32(DateTime.Today.Year.ToString());
            int month = Convert.ToInt32(DateTime.Now.ToString("MM"));
            if(month<7)
            {
                year--;
            }
            for (int i = 0; i < 4; i++)
            {
                admission_year.Items.Add(new ListItem(year.ToString(),year.ToString()));
                year--;
            }
            string message = "Please provide correct details.Detail once submitted can not be updated.";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("');");
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", sb.ToString(), true);
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
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void inputState_SelectedIndexChanged(object sender, EventArgs e)
    {
        string university_selected = university.SelectedValue;
        string institute_selected = inputState.SelectedValue ;
        if (university_selected.Equals("University Name")==false)
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
                        //command.Parameters.Add("@ins_id", SqlDbType.Int).Value = Convert.ToInt32(institute_selected);
                        connection.Open();

                        command.Parameters.Add(institute_id_param);

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            DropDownList1.Items.Clear();
                            DropDownList1.Items.Add(new ListItem("Department Name", "Department Name"));
                            while (reader.Read())
                            {
                                string department_id = reader.GetInt32(0).ToString();
                                string item = reader.GetString(1);
                                if (!string.IsNullOrEmpty(item))
                                {
                                    DropDownList1.Items.Add(new ListItem(item, department_id));
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
                DropDownList1.Items.Clear();
                DropDownList1.Items.Add(new ListItem("Department Name", "Department Name"));
                inputState.Items.FindByValue("Institute Name").Selected = true;
                DropDownList1.Items.FindByValue("Department Name").Selected = true;
            }
        }
        else
        {
            inputState.Items.Clear();
            inputState.Items.Add(new ListItem("Institute Name", "Institute Name"));
            DropDownList1.Items.Clear();
            DropDownList1.Items.Add(new ListItem("Department Name", "Department Name"));
            university.Items.FindByValue("University Name").Selected = true;
            inputState.Items.FindByValue("Institute Name").Selected = true;
            DropDownList1.Items.FindByValue("Department Name").Selected = true;
        }
    }
    protected void university_SelectedIndexChanged(object sender, EventArgs e)
    {
        string university_selected = university.SelectedValue;
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
                    //command.Parameters.Add("@uni_id", SqlDbType.Int).Value = Convert.ToInt32(university_selected);
                    connection.Open();

                    command.Parameters.Add(university_id_param);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        DropDownList1.Items.Clear();
                        DropDownList1.Items.Add(new ListItem("Department Name", "Department Name"));
                        inputState.Items.Clear();
                        inputState.Items.Add(new ListItem("Institute Name", "Institute Name"));
                        while (reader.Read())
                        {
                            string institute_id = reader.GetInt32(0).ToString();
                            string item = reader.GetString(1);
                            if (!string.IsNullOrEmpty(item))
                            {
                                inputState.Items.Add(new ListItem(item,institute_id));
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
            inputState.Items.Clear();
            inputState.Items.Add(new ListItem("Institute Name", "Institute Name"));
            DropDownList1.Items.Clear();
            DropDownList1.Items.Add(new ListItem("Department Name", "Department Name"));
            university.Items.FindByValue("University Name").Selected = true;
            inputState.Items.FindByValue("Institute Name").Selected = true;
            DropDownList1.Items.FindByValue("Department Name").Selected = true;
        }
    }
    protected void RegisterButton_Click(object sender, EventArgs e)
    {
        bool checkdrop = true;
        string alertclassname = "alert-danger";
        string first = First.Text;
        string last = Last.Text;
        long contact = Convert.ToInt64(Contact.Text);
        string emailid = Email.Text;
        string password = Password.Text;
        string confirmpassword = Confirm.Text;
        int universityid=0;
        bool student_exist = false;
        if(university.SelectedValue!="University Name")
        {
            universityid = Convert.ToInt32(university.SelectedValue);
            //Remove a Class
            university.Attributes.Add("class", String.Join(" ", university
                      .Attributes["class"]
                      .Split(' ')
                      .Except(new string[] { "", alertclassname })
                      .ToArray()
              ));
        }
        else
        {
            university.Attributes.Add("class", String.Join(" ", university
                       .Attributes["class"]
                       .Split(' ')
                       .Except(new string[] { "", alertclassname })
                       .Concat(new string[] { alertclassname })
                       .ToArray()
               ));
            checkdrop = false;
        }
        int instituteid=0;
        if (inputState.SelectedValue != "Institute Name")
        {
            instituteid = Convert.ToInt32(inputState.SelectedValue);
            //Remove a Class
            inputState.Attributes.Add("class", String.Join(" ", inputState
                      .Attributes["class"]
                      .Split(' ')
                      .Except(new string[] { "", alertclassname })
                      .ToArray()
              ));
        }
        else
        {
            inputState.Attributes.Add("class", String.Join(" ", inputState
                       .Attributes["class"]
                       .Split(' ')
                       .Except(new string[] { "", alertclassname })
                       .Concat(new string[] { alertclassname })
                       .ToArray()
               ));
            checkdrop = false;
        }
        int departmentid=0;
        if(DropDownList1.SelectedValue!="Department Name")
        {
           departmentid = Convert.ToInt32(DropDownList1.SelectedValue);
           //Remove a Class
           DropDownList1.Attributes.Add("class", String.Join(" ", DropDownList1
                     .Attributes["class"]
                     .Split(' ')
                     .Except(new string[] { "", alertclassname })
                     .ToArray()
             ));
        }
        else
        {
            DropDownList1.Attributes.Add("class", String.Join(" ", DropDownList1
                       .Attributes["class"]
                       .Split(' ')
                       .Except(new string[] { "", alertclassname })
                       .Concat(new string[] { alertclassname })
                       .ToArray()
               ));
            checkdrop = false;
        }
        int admissionyear=0;
        if (admission_year.SelectedValue != "Admission Year")
        {
            admissionyear = Convert.ToInt32(admission_year.SelectedValue);
            //Remove a Class
            admission_year.Attributes.Add("class", String.Join(" ", admission_year
                      .Attributes["class"]
                      .Split(' ')
                      .Except(new string[] { "", alertclassname })
                      .ToArray()
              ));
        }
        else
        {
            admission_year.Attributes.Add("class", String.Join(" ", admission_year
                       .Attributes["class"]
                       .Split(' ')
                       .Except(new string[] { "", alertclassname })
                       .Concat(new string[] { alertclassname })
                       .ToArray()
               ));
            checkdrop = false;
        }
        string currentyear="";
        if (current_year.SelectedValue != "Current Year")
        {
            currentyear = current_year.SelectedValue;
            //Remove a Class
            current_year.Attributes.Add("class", String.Join(" ", current_year
                      .Attributes["class"]
                      .Split(' ')
                      .Except(new string[] { "", alertclassname })
                      .ToArray()
              ));
        }
        else
        {
            current_year.Attributes.Add("class", String.Join(" ", current_year
                       .Attributes["class"]
                       .Split(' ')
                       .Except(new string[] { "", alertclassname })
                       .Concat(new string[] { alertclassname })
                       .ToArray()
               ));
            checkdrop = false;
        }
        string shift="";
        if (Shift.SelectedValue != "Shift")
        {
            shift = Shift.SelectedValue;
            //Remove a Class
            Shift.Attributes.Add("class", String.Join(" ", Shift
                      .Attributes["class"]
                      .Split(' ')
                      .Except(new string[] { "", alertclassname })
                      .ToArray()
              ));
        }
        else
        {
            Shift.Attributes.Add("class", String.Join(" ", Shift
                       .Attributes["class"]
                       .Split(' ')
                       .Except(new string[] { "", alertclassname })
                       .Concat(new string[] { alertclassname })
                       .ToArray()
               ));
            checkdrop = false;
        }
        int rollno = Convert.ToInt32(Roll.Text);
        long pnr = Convert.ToInt64(PNR.Text);
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
            string insertquery = "insert into student values(@first,@last,@email,@pass,@contact,@ins_id,@dep_id,@uni_id)";
            string insertquery1 = "insert into student_academic_detail (student_email,department_id,admission_year,current_year,roll_no,prn_no,shift,status) values(@email,@dep_id,@adm,@cur,@roll,@pnr,@shift,'Active')";
            string selectquery = "select * from student where student_email=@student_email";
            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(selectquery, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@student_email", emailid);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                student_exist = true;
                            }
                        }
                    }
                }

                if (student_exist == false)
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
                            command.Parameters.AddWithValue("@contact", contact);
                            command.Parameters.AddWithValue("@ins_id", instituteid);
                            command.Parameters.AddWithValue("@dep_id", departmentid);
                            command.Parameters.AddWithValue("@uni_id", universityid);

                            command.ExecuteNonQuery();
                        }
                    }

                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(insertquery1, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@email", emailid);
                            command.Parameters.AddWithValue("@dep_id", departmentid);
                            command.Parameters.AddWithValue("@adm", admissionyear);
                            command.Parameters.AddWithValue("@cur", currentyear);
                            command.Parameters.AddWithValue("@roll", rollno);
                            command.Parameters.AddWithValue("@pnr", pnr);
                            command.Parameters.AddWithValue("@shift", shift);

                            command.ExecuteNonQuery();
                        }
                    }
                    Response.Redirect("/lbs/login.aspx");
                }
                else
                {
                    string message = "You are already registered";
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("alert('");
                    sb.Append(message);
                    sb.Append("');");
                    sb.Append("window.location ='/lbs/login.aspx';");
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", sb.ToString(), true);
                }
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.Message);
            }

        }
    }
    protected void admission_year_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (admission_year.SelectedValue.Equals("Admission Year"))
        {
            current_year.Items.Clear();
            current_year.Items.Add(new ListItem("Current Year", "Current Year"));
        }
        else
        {
            int year = Convert.ToInt32(DateTime.Today.Year.ToString());
            int month = Convert.ToInt32(DateTime.Now.ToString("MM"));
            if (month < 7)
            {
                year--;
            }
            current_year.Items.Clear();
            for (int i = 0; i < 4; i++)
            {
                int checkyear = Convert.ToInt32(admission_year.SelectedValue);
                if ((checkyear == year) && (i == 0))
                {
                    current_year.Items.Add(new ListItem("Current Year", "Current Year"));
                    current_year.Items.Add(new ListItem("First Year", "First Year"));
                    current_year.Items.Add(new ListItem("Second Year", "Second Year"));
                    current_year.Items.FindByValue("First Year").Selected = true;
                    break;
                }
                if ((checkyear == year) && (i == 1))
                {
                    current_year.Items.Add(new ListItem("Current Year", "Current Year"));
                    current_year.Items.Add(new ListItem("Second Year", "Second Year"));
                    current_year.Items.Add(new ListItem("Third Year", "Third Year"));
                    current_year.Items.FindByValue("Second Year").Selected = true;
                    break;
                }
                if ((checkyear == year) && (i == 2))
                {
                    current_year.Items.Add(new ListItem("Current Year", "Current Year"));
                    current_year.Items.Add(new ListItem("Third Year", "Third Year"));
                    current_year.Items.Add(new ListItem("Fourth Year", "Fourth Year"));
                    current_year.Items.FindByValue("Third Year").Selected = true;
                    break;
                }
                if ((checkyear == year) && (i == 3))
                {
                    current_year.Items.Add(new ListItem("Current Year", "Current Year"));
                    current_year.Items.Add(new ListItem("Fourth Year", "Fourth Year"));
                    current_year.Items.FindByValue("Fourth Year").Selected = true;
                    break;
                }
                year--;
            }
        }
    }
        
}