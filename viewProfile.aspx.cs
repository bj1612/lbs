using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class student_viewProfile : System.Web.UI.Page
{
    //static bool edit = false;
    string connStr,current_user="";
    string student_email = "";
    int academic_id = 0;
    int university_id=0,institute_id=0,department_id = 0;
    int upduniversity_id = -1, updinstitute_id = -1, upddepartment_id = -1;
    string university_name = "", institute_name = "", department_name = "",first_name="",last_name="";
    int admission_year=0, roll_no = 0;
    Decimal prn_no=0,contact=0;
    string current_year = "", shift = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

        if (Session["email"] == null)
        {
            Response.Redirect(@"/lbs/index.aspx");
        }

        if (Session["typeofuser"] != null)
        {
            current_user = Session["typeofuser"].ToString();
            if (current_user.Equals("student"))
            {
                EditButton.Style["display"] = "block";
            }
        }
        if (Request.QueryString["ID"] != null)
        {
            student_email = Request.QueryString["ID"].ToString();
        }
        else
        {
            Response.Redirect(@"/lbs/index.aspx");
        }
        if (Request.QueryString["Data"] != null)
        {
            Int32.TryParse(Request.QueryString["Data"].ToString(), out academic_id);
            //academic_id = Convert.ToInt32(Request.QueryString["Data"]);
        }
        else
        {
            academic_id = 0;    
        }
        try
        {
            string fetchstudentinfoquery1="";
            if (academic_id != 0)
            {
                fetchstudentinfoquery1 = "select * from student_academic_detail where student_email=@student_email and student_academic_detail_id=@academic_id";
            }
            else
            {
                fetchstudentinfoquery1 = "select * from student_academic_detail where status='Active' and student_email=@student_email";
            }
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand(fetchstudentinfoquery1, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@student_email", student_email);
                    if (academic_id != 0)
                    {
                        command.Parameters.AddWithValue("@academic_id", academic_id);
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                department_id = reader.GetInt32(2);
                                admission_year = reader.GetInt32(3);
                                current_year = reader.GetString(4);
                                roll_no = reader.GetInt32(5);
                                prn_no = reader.GetDecimal(6);
                                shift = reader.GetString(7);

                            }
                        }
                        else
                        {
                            Response.Redirect(@"/lbs/index.aspx");
                        }
                    }
                }
            }
            

            string fetchdepartmentquery = "";
            fetchdepartmentquery = "select * from department where department_id=@department_id";
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand(fetchdepartmentquery, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@department_id", department_id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                institute_id = reader.GetInt32(1);
                                department_name = reader.GetString(2);
                            }
                        }
                        else
                        {
                            Response.Redirect(@"/lbs/index.aspx");
                        }
                    }
                }
            }
            

            string fetchinstitutequery = "";
            fetchinstitutequery = "select * from institute where institute_id=@institute_id";
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand(fetchinstitutequery, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@institute_id", institute_id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                institute_name = reader.GetString(1);
                                university_id = reader.GetInt32(6);
                            }
                        }
                        else
                        {
                            Response.Redirect(@"/lbs/index.aspx");
                        }
                    }
                }
            }
            

            string fetchuniversityquery = "";
            fetchuniversityquery = "select * from university where university_id=@university_id";
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand(fetchuniversityquery, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@university_id", university_id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                university_name = reader.GetString(1);
                            }
                        }
                        else
                        {
                            Response.Redirect(@"/lbs/index.aspx");
                        }
                    }
                }
            }

            string fetchstudentquery = "";
            fetchstudentquery = "select * from student where student_email=@student_email";
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand(fetchstudentquery, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@student_email", student_email);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                first_name = reader.GetString(0);
                                last_name = reader.GetString(1);
                                contact = reader.GetDecimal(4);
                            }
                        }
                        else
                        {
                            Response.Redirect(@"/lbs/index.aspx");
                        }
                    }
                }
            }

            if (!IsPostBack)
            {
                First.Text = first_name;
                Last.Text = last_name;
                Email.Text = student_email;
                Contact.Text = "" + contact;
                DropDownList4.Items.Add(new ListItem(admission_year.ToString(), admission_year.ToString()));
                DropDownList5.Items.Add(new ListItem(current_year, current_year));
                Shift.Items.Add(new ListItem(shift, shift));
                Roll.Text = "" + roll_no;
                PNR.Text = "" + prn_no;
                DropDownList1.Items.Add(new ListItem(department_name, department_id.ToString()));
                DropDownList3.Items.Add(new ListItem(institute_name, institute_id.ToString()));
                DropDownList2.Items.Add(new ListItem(university_name, university_id.ToString()));
                Session["edit"] = "false";
            }
        }
        catch (Exception e1)
        {
            System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
            Response.Redirect(@"/lbs/index.aspx");
        }
    }
    protected void EditButton_Click(object sender, EventArgs e)
    {
        string edit = "";
        if (Session["edit"] != null)
        {
            edit = Session["edit"].ToString();
        }
        if (edit.Equals("false"))
        {
            Contact.Enabled = true;
            DropDownList2.Enabled = true;
            DropDownList3.Enabled = true;
            DropDownList1.Enabled = true;
            DropDownList4.Enabled = true;
            DropDownList5.Enabled = true;
            Shift.Enabled = true;
            Roll.Enabled = true;
            PNR.Enabled = true;
            UpdateButton.Style["display"] = "block";
            edit = "true";
            LoadUniversityDropdown();
            Shift.Items.Clear();
            Shift.Items.Add(new ListItem("First Shift", "First Shift"));
            Shift.Items.Add(new ListItem("Second Shift", "Second Shift"));
            Shift.Items.Add(new ListItem("None", "None"));
            Shift.Items.FindByValue(shift).Selected = true;
            int year = Convert.ToInt32(DateTime.Today.Year.ToString());
            int month = Convert.ToInt32(DateTime.Now.ToString("MM"));
            if (month < 7)
            {
                year--;
            }
            for (int i = 0; i < 4; i++)
            {
                if (year != admission_year)
                {
                    DropDownList4.Items.Add(new ListItem(year.ToString(), year.ToString()));
                }
                year--;
            }
        }
        else if(edit.Equals("true"))
        {
            Contact.Enabled = false;
            DropDownList2.Enabled = false;
            DropDownList3.Enabled = false;
            DropDownList1.Enabled = false;
            DropDownList4.Enabled = false;
            DropDownList5.Enabled = false;
            Shift.Enabled = false;
            Roll.Enabled = false;
            PNR.Enabled = false;
            UpdateButton.Style["display"] = "none";
            edit = "false";
            Contact.Text = "" + contact;
            DropDownList4.Items.Clear();
            DropDownList4.Items.Add(new ListItem(admission_year.ToString(), admission_year.ToString()));
            DropDownList5.Items.Clear();
            DropDownList5.Items.Add(new ListItem(current_year, current_year));
            Shift.Items.Clear();
            Shift.Items.Add(new ListItem(shift, shift));
            Roll.Text = "" + roll_no;
            PNR.Text = "" + prn_no;
            DropDownList1.Items.Clear();
            DropDownList1.Items.Add(new ListItem(department_name, department_id.ToString()));
            DropDownList3.Items.Clear();
            DropDownList3.Items.Add(new ListItem(institute_name, institute_id.ToString()));
            DropDownList2.Items.Clear();
            DropDownList2.Items.Add(new ListItem(university_name, university_id.ToString()));
        }
        Session["edit"] = edit;
    }
    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (DropDownList2.SelectedValue.Equals("0"))
            {
                ListItem item = DropDownList2.Items.FindByValue(university_id.ToString());
                if (item != null)
                {
                    DropDownList2.ClearSelection();
                    DropDownList2.Items.FindByValue(university_id.ToString()).Selected = true;
                }
                else
                {
                    DropDownList2.ClearSelection();
                    DropDownList2.Items.Add(new ListItem(university_name, university_id.ToString()));
                    DropDownList2.Items.FindByValue(university_id.ToString()).Selected = true;
                }
                
            }

            if (DropDownList3.SelectedValue.Equals("0"))
            {
                ListItem item = DropDownList3.Items.FindByValue(institute_id.ToString());
                if (item != null)
                {
                    DropDownList3.ClearSelection();
                    DropDownList3.Items.FindByValue(institute_id.ToString()).Selected = true;
                }
                else
                {
                    DropDownList3.ClearSelection();
                    DropDownList3.Items.Add(new ListItem(institute_name, institute_id.ToString()));
                    DropDownList3.Items.FindByValue(institute_id.ToString()).Selected = true;
                }
                
            }

            if (DropDownList1.SelectedValue.Equals("0"))
            {
                ListItem item = DropDownList1.Items.FindByValue(department_id.ToString());
                if (item != null)
                {
                    DropDownList1.ClearSelection();
                    DropDownList1.Items.FindByValue(department_id.ToString()).Selected = true;
                }
                else
                {
                    DropDownList1.ClearSelection();
                    DropDownList1.Items.Add(new ListItem(department_name, department_id.ToString()));
                    DropDownList1.Items.FindByValue(department_id.ToString()).Selected = true;
                }
                
            }
            //update student and student_academic
            Decimal contact_det=Convert.ToDecimal(Contact.Text);
            int instituteid_det=Convert.ToInt32(DropDownList3.SelectedValue);
            int departmentid_det=Convert.ToInt32(DropDownList1.SelectedValue);
            int universityid_det=Convert.ToInt32(DropDownList2.SelectedValue);

            string departmentname_det = DropDownList1.SelectedItem.Text;
            string institutename_det = DropDownList3.SelectedItem.Text;
            string universityname_det = DropDownList2.SelectedItem.Text;

            int admissionyear_det=Convert.ToInt32(DropDownList4.SelectedValue);
            string currentyear_det=DropDownList5.SelectedValue;
            string shift_det=Shift.SelectedValue;
            int roll_det=Convert.ToInt32(Roll.Text);
            Decimal prn_det=Convert.ToDecimal(PNR.Text);

            string updatestudentquery = "update student set contact=@contactdet,institute_id=@instituteid_det,department_id=@departmentid_det,university_id=@universityid_det where student_email=@student_email";
            if (admissionyear_det == admission_year)
            {
                updatestudentquery = "update student set contact=@contactdet where student_email=@student_email";
            }
            string updatestudentacademicquery = "update student_academic_detail set admission_year=@adm,current_year=@curr,roll_no=@roll,shift=@shift where department_id=@id";
            string updatestudentacademicpreviousquery = "update student_academic_detail set status='Inactive' where department_id=@id";
            string insertstudentacademicquery = "insert into student_academic_detail (student_email,department_id,admission_year,current_year,roll_no,prn_no,shift,status) values(@email,@dep_id,@adm,@cur,@roll,@pnr,@shift,'Active')";
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand(updatestudentquery, connection))
                {
                    connection.Open();

                    command.Parameters.AddWithValue("@contactdet", contact_det);
                    if (admissionyear_det > admission_year)
                    {
                        command.Parameters.AddWithValue("@instituteid_det", instituteid_det);
                        command.Parameters.AddWithValue("@departmentid_det", departmentid_det);
                        command.Parameters.AddWithValue("@universityid_det", universityid_det);
                        DropDownList1.Items.Clear();
                        DropDownList1.Items.Add(new ListItem(departmentname_det, departmentid_det.ToString()));
                        DropDownList3.Items.Clear();
                        DropDownList3.Items.Add(new ListItem(institutename_det, instituteid_det.ToString()));
                        DropDownList2.Items.Clear();
                        DropDownList2.Items.Add(new ListItem(universityname_det, universityid_det.ToString()));
                    }
                    else
                    {
                        DropDownList1.Items.Clear();
                        DropDownList1.Items.Add(new ListItem(department_name, department_id.ToString()));
                        DropDownList3.Items.Clear();
                        DropDownList3.Items.Add(new ListItem(institute_name, institute_id.ToString()));
                        DropDownList2.Items.Clear();
                        DropDownList2.Items.Add(new ListItem(university_name, university_id.ToString()));
                    }
                    command.Parameters.AddWithValue("@student_email", student_email);

                    command.ExecuteNonQuery();
                }
            }

            if (admission_year < admissionyear_det)
            {
                if (department_id == departmentid_det)
                {
                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(updatestudentacademicquery, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@adm", admissionyear_det);
                            command.Parameters.AddWithValue("@curr", currentyear_det);
                            command.Parameters.AddWithValue("@roll", roll_det);
                            command.Parameters.AddWithValue("@shift", shift_det);
                            command.Parameters.AddWithValue("@id", department_id);

                            command.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(updatestudentacademicpreviousquery, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@id", department_id);

                            command.ExecuteNonQuery();
                        }
                    }

                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(insertstudentacademicquery, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@email", student_email);
                            command.Parameters.AddWithValue("@dep_id", departmentid_det);
                            command.Parameters.AddWithValue("@adm", admissionyear_det);
                            command.Parameters.AddWithValue("@cur", currentyear_det);
                            command.Parameters.AddWithValue("@roll", roll_det);
                            if (university_id != universityid_det)
                            {
                                //insert new department and change prn also
                                command.Parameters.AddWithValue("@pnr", prn_det);
                                PNR.Text = "" + prn_det;
                            }
                            else
                            {
                                //insert new department and dont change prn
                                command.Parameters.AddWithValue("@pnr", prn_no);
                                PNR.Text = "" + prn_no;
                            }
                            command.Parameters.AddWithValue("@shift", shift_det);

                            command.ExecuteNonQuery();
                        }
                    }
                }
                DropDownList4.Items.Clear();
                DropDownList4.Items.Add(new ListItem(admissionyear_det.ToString(), admissionyear_det.ToString()));
                DropDownList5.Items.Clear();
                DropDownList5.Items.Add(new ListItem(currentyear_det, currentyear_det));
                Shift.Items.Clear();
                Shift.Items.Add(new ListItem(shift_det, shift_det));
                Roll.Text = "" + roll_det;
            }
            Contact.Text = "" + contact_det;
            Contact.Enabled = false;
            DropDownList2.Enabled = false;
            DropDownList3.Enabled = false;
            DropDownList1.Enabled = false;
            DropDownList4.Enabled = false;
            DropDownList5.Enabled = false;
            Shift.Enabled = false;
            Roll.Enabled = false;
            PNR.Enabled = false;
            UpdateButton.Style["display"] = "none";
            Session["edit"] = "false";
        }
        catch (Exception e1)
        {
            System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
        }
    }
    protected void LoadUniversityDropdown()
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand("SELECT university_id,university_name FROM university", connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            DropDownList2.Items.Clear();
                            DropDownList2.Items.Add(new ListItem("Select University", "0"));
                            while (reader.Read())
                            {
                                string id = reader.GetInt32(0).ToString();
                                string name = reader.GetString(1);
                                if (!string.IsNullOrEmpty(name))
                                {
                                    DropDownList2.Items.Add(new ListItem(name, id));
                                }
                            }
                        }
                        else
                        {
                            DropDownList2.Items.Clear();
                            DropDownList2.Items.Add(new ListItem("Select University", "0"));
                            DropDownList2.Items.Add(new ListItem(university_name, university_id.ToString()));
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
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        //university
        try
        {
            upduniversity_id = Convert.ToInt32(DropDownList2.SelectedValue);
            if (upduniversity_id != 0)
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand("SELECT institute_id,institute_name FROM institute where university_id=@upduniversity_id", connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@upduniversity_id", upduniversity_id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                DropDownList1.Items.Clear();
                                DropDownList1.Items.Add(new ListItem("Select Department", "0"));
                                DropDownList3.Items.Clear();
                                DropDownList3.Items.Add(new ListItem("Select Institute", "0"));
                                while (reader.Read())
                                {
                                    string id = reader.GetInt32(0).ToString();
                                    string name = reader.GetString(1);
                                    if (!string.IsNullOrEmpty(name))
                                    {
                                        DropDownList3.Items.Add(new ListItem(name, id));
                                    }
                                }
                            }
                            else
                            {
                                DropDownList3.Items.Clear();
                                DropDownList3.Items.Add(new ListItem("Select Institute", "0"));
                                DropDownList3.Items.Add(new ListItem(institute_name, institute_id.ToString()));
                            }
                        }
                    }
                }
            }
            else
            {
                //DropDownList2.Items.Clear();
                //DropDownList2.Items.Add(new ListItem(university_name, university_id.ToString()));
                DropDownList3.ClearSelection();
                DropDownList1.ClearSelection();
                //DropDownList2.Items.FindByValue(university_id.ToString()).Selected = true;
                //DropDownList3.Items.Clear();
                //DropDownList3.Items.Add(new ListItem(institute_name, institute_id.ToString()));
                //DropDownList1.Items.Clear();
                //DropDownList1.Items.Add(new ListItem(department_name, department_id.ToString()));
            }
        }
        catch (Exception e1)
        {
            Console.WriteLine("Error Message: " + e1.StackTrace);
            System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
        }
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        //institute
        try
        {
            updinstitute_id = Convert.ToInt32(DropDownList3.SelectedValue);
            if (updinstitute_id != 0)
            {
                if (DropDownList2.SelectedValue.Equals("0"))
                {
                    DropDownList3.ClearSelection();
                }
                else
                {
                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand("SELECT department_id,department_name FROM department where institute_id=@updinstitute_id", connection))
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@updinstitute_id", updinstitute_id);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    DropDownList1.Items.Clear();
                                    DropDownList1.Items.Add(new ListItem("Select Department", "0"));
                                    while (reader.Read())
                                    {
                                        string id = reader.GetInt32(0).ToString();
                                        string name = reader.GetString(1);
                                        if (!string.IsNullOrEmpty(name))
                                        {
                                            DropDownList1.Items.Add(new ListItem(name, id));
                                        }
                                    }
                                }
                                else
                                {
                                    DropDownList1.Items.Clear();
                                    DropDownList1.Items.Add(new ListItem("Select Department", "0"));
                                    DropDownList1.Items.Add(new ListItem(department_name, department_id.ToString()));
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                DropDownList1.ClearSelection();
                /*DropDownList2.Items.Clear();
                DropDownList2.Items.Add(new ListItem(university_name, university_id.ToString()));
                DropDownList3.Items.Clear();
                DropDownList3.Items.Add(new ListItem(institute_name, institute_id.ToString()));
                DropDownList1.Items.Clear();
                DropDownList1.Items.Add(new ListItem(department_name, department_id.ToString()));*/
            }
        }
        catch (Exception e1)
        {
            Console.WriteLine("Error Message: " + e1.StackTrace);
            System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //department
        if (upddepartment_id != 0)
        {
            /*DropDownList2.Items.Clear();
            DropDownList2.Items.Add(new ListItem(university_name, university_id.ToString()));
            DropDownList3.Items.Clear();
            DropDownList3.Items.Add(new ListItem(institute_name, institute_id.ToString()));
            DropDownList1.Items.Clear();
            DropDownList1.Items.Add(new ListItem(department_name, department_id.ToString()));*/
            if (DropDownList2.SelectedValue.Equals("0") || DropDownList3.SelectedValue.Equals("0"))
            {
                DropDownList1.ClearSelection();
            }
        }
    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        //admission
        if (DropDownList4.SelectedValue.Equals(admission_year.ToString()))
        {
            DropDownList5.Items.Clear();
            DropDownList5.Items.Add(new ListItem(current_year, current_year));
        }
        else
        {
            int year = Convert.ToInt32(DateTime.Today.Year.ToString());
            int month = Convert.ToInt32(DateTime.Now.ToString("MM"));
            if (month < 7)
            {
                year--;
            }
            DropDownList5.ClearSelection();
            DropDownList5.Items.Clear();
            for (int i = 0; i < 4; i++)
            {
                int checkyear = Convert.ToInt32(DropDownList4.SelectedValue);
                if (year == admission_year)
                {
                    year--;
                    continue;
                }
                else
                {
                    if ((checkyear == year) && (i == 0))
                    {
                        DropDownList5.Items.Add(new ListItem("First Year", "First Year"));
                        DropDownList5.Items.Add(new ListItem("Second Year", "Second Year"));
                        DropDownList5.Items.FindByValue("First Year").Selected = true;
                        break;
                    }
                    if ((checkyear == year) && (i == 1))
                    {
                        DropDownList5.Items.Add(new ListItem("Second Year", "Second Year"));
                        DropDownList5.Items.Add(new ListItem("Third Year", "Third Year"));
                        DropDownList5.Items.FindByValue("Second Year").Selected = true;
                        break;
                    }
                    if ((checkyear == year) && (i == 2))
                    {
                        DropDownList5.Items.Add(new ListItem("Third Year", "Third Year"));
                        DropDownList5.Items.Add(new ListItem("Fourth Year", "Fourth Year"));
                        DropDownList5.Items.FindByValue("Third Year").Selected = true;
                        break;
                    }
                    if ((checkyear == year) && (i == 3))
                    {
                        DropDownList5.Items.Add(new ListItem("Fourth Year", "Fourth Year"));
                        DropDownList5.Items.FindByValue("Fourth Year").Selected = true;
                        break;
                    }
                    year--;
                }
            }
        }
    }
}