using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class register_complaint : System.Web.UI.Page
{
    string type_of_complaint="",category_of_complaint="";
    string connStr;
    string alertclassname = "alert-danger";
    string current_user;
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
            if (current_user.Equals("student") == false)
            {
                Response.Redirect("/lbs/logout.aspx");
            }
        }
    }
    protected void ComplaintType_SelectedIndexChanged(object sender, EventArgs e)
    {
        type_of_complaint = ComplaintType.SelectedValue;
        if (type_of_complaint.Equals("Complaint Type") == false)
        {
            if (type_of_complaint.Equals("university") == true)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand("SELECT * FROM university_category", connection))
                        {
                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    ComplaintCategory.Items.Clear();
                                    ComplaintCategory.Items.Add(new ListItem("Category", "Complaint Category"));
                                    while (reader.Read())
                                    {
                                        string university_category_id = reader.GetInt32(0).ToString();
                                        string university_category_name = reader.GetString(1);
                                        if (!string.IsNullOrEmpty(university_category_name))
                                        {
                                            ComplaintCategory.Items.Add(new ListItem(university_category_name, university_category_id));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception e1)
                {
                    System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
                }
            }
            if (type_of_complaint.Equals("institute") == true)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand("SELECT * FROM institute_category", connection))
                        {
                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    ComplaintCategory.Items.Clear();
                                    ComplaintCategory.Items.Add(new ListItem("Category", "Complaint Category"));
                                    while (reader.Read())
                                    {
                                        string institute_category_id = reader.GetInt32(0).ToString();
                                        string institute_category_name = reader.GetString(1);
                                        if (!string.IsNullOrEmpty(institute_category_name))
                                        {
                                            ComplaintCategory.Items.Add(new ListItem(institute_category_name, institute_category_id));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception e1)
                {
                    System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
                }
            }
            if (type_of_complaint.Equals("department") == true)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand("SELECT * FROM department_category", connection))
                        {
                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    ComplaintCategory.Items.Clear();
                                    ComplaintCategory.Items.Add(new ListItem("Category", "Complaint Category"));
                                    while (reader.Read())
                                    {
                                        string department_category_id = reader.GetInt32(0).ToString();
                                        string department_category_name = reader.GetString(1);
                                        if (!string.IsNullOrEmpty(department_category_name))
                                        {
                                            ComplaintCategory.Items.Add(new ListItem(department_category_name, department_category_id));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception e1)
                {
                    System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
                }
            }   

        }
        else
        {
            ComplaintCategory.Items.Clear();
            ComplaintCategory.Items.Add(new ListItem("Category", "Complaint Category"));
            ComplaintCategory.Items.FindByValue("Complaint Category").Selected = true;
            type_of_complaint = ComplaintType.SelectedValue;
            category_of_complaint = ComplaintCategory.SelectedValue;
        }
    }
    protected void RegisterComplaint_Click(object sender, EventArgs e)
    {
        string student_email="",complaint_date="",complaint_time="",complaint_title="",complaint_description="",complaint_status="",complaint_progress="";
        int category_id=0;
        string insertquery="";
        type_of_complaint = ComplaintType.SelectedValue;
        category_of_complaint = ComplaintCategory.SelectedValue;
        if (type_of_complaint.Equals("Complaint Type") == false)
        {
            //Remove Css Class
            ComplaintType.Attributes.Add("class", String.Join(" ", ComplaintType
                      .Attributes["class"]
                      .Split(' ')
                      .Except(new string[] { "", alertclassname })
                      .ToArray()
              ));
            if (category_of_complaint.Equals("Complaint Category") == false)
            {
                //Remove Css Class
                ComplaintCategory.Attributes.Add("class", String.Join(" ", ComplaintCategory
                      .Attributes["class"]
                      .Split(' ')
                      .Except(new string[] { "", alertclassname })
                      .ToArray()
              ));
                category_id = Convert.ToInt32(category_of_complaint);
                complaint_title = Subject.Text;
                complaint_description = Description.Text;
                complaint_status = "Open";
                complaint_progress = "Pending";
                if (Session["email"] != null)
                {
                    student_email = Session["email"].ToString();
                }
                complaint_date = DateTime.Now.Year+"-"+DateTime.Now.Month+"-"+DateTime.Now.Day;
                complaint_time = DateTime.Now.ToShortTimeString();
                

                if (type_of_complaint.Equals("university") == true)
                {
                    insertquery = "insert into university_complaint(student_email,complaint_level,university_category_id,complaint_date,complaint_time,complaint_title,complaint_description,complaint_status,complaint_progress) values (@student_email,@complaint_level,@university_category_id,@complaint_date,@complaint_time,@complaint_title,@complaint_description,@complaint_status,@complaint_progress)";
                    
                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(insertquery, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@student_email", student_email);
                            command.Parameters.AddWithValue("@complaint_level", type_of_complaint);
                            command.Parameters.AddWithValue("@university_category_id", category_id);
                            command.Parameters.AddWithValue("@complaint_date", complaint_date);
                            command.Parameters.AddWithValue("@complaint_time", complaint_time);
                            command.Parameters.AddWithValue("@complaint_title", complaint_title);
                            command.Parameters.AddWithValue("@complaint_description", complaint_description);
                            command.Parameters.AddWithValue("@complaint_status", complaint_status);
                            command.Parameters.AddWithValue("@complaint_progress", complaint_progress);

                            command.ExecuteNonQuery();
                        }
                    }

                    string complaintfetchquery="select university_complaint_id from university_complaint where student_email=@student_email and complaint_level=@complaint_level and university_category_id=@university_category_id and complaint_date=@complaint_date and complaint_time=@complaint_time and complaint_title=@complaint_title and complaint_description=@complaint_description and complaint_status=@complaint_status and complaint_progress=@complaint_progress";
                    int complaint_id = 0;

                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(complaintfetchquery, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@student_email", student_email);
                            command.Parameters.AddWithValue("@complaint_level", type_of_complaint);
                            command.Parameters.AddWithValue("@university_category_id", category_id);
                            command.Parameters.AddWithValue("@complaint_date", complaint_date);
                            command.Parameters.AddWithValue("@complaint_time", complaint_time);
                            command.Parameters.AddWithValue("@complaint_title", complaint_title);
                            command.Parameters.AddWithValue("@complaint_description", complaint_description);
                            command.Parameters.AddWithValue("@complaint_status", complaint_status);
                            command.Parameters.AddWithValue("@complaint_progress", complaint_progress);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        complaint_id = reader.GetInt32(0);
                                    }
                                }
                            }
                        }
                    }

                    string studentfetchquery = "select university_id from student where student_email=@student_email";
                    int university_id = 0;

                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(studentfetchquery, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@student_email", student_email);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        university_id = reader.GetInt32(0);
                                    }
                                }
                            }
                        }
                    }

                    string moderatorfetchquery = "select university_mode_email,status,total_no_of_complaint from university_mode where university_subadmin_email = (select university_subadmin_email from university_subadmin where university_category_id=@category_id and university_admin_email=(select university_admin_email from university_admin where university_id=@university_id))";
                    string update_moderator_email = "";
                    string assign_moderator_email = "";
                    string first_moderator = "";
                    //int statusyescount = 0;
                    //int totalcount = 0;
                    int total_no_of_complaint = 0;

                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(moderatorfetchquery, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@category_id", category_id);
                            command.Parameters.AddWithValue("@university_id", university_id);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    bool firsttry = true;
                                    while (reader.Read())
                                    {
                                        //totalcount++;
                                        if (firsttry == true)
                                        {
                                            first_moderator = reader.GetString(0);
                                            firsttry = false;
                                        }
                                        string status = reader.GetString(1);
                                        if (status.Equals("Yes"))
                                        {
                                            //statusyescount++;
                                            assign_moderator_email = reader.GetString(0);
                                            total_no_of_complaint = reader.GetInt32(2);
                                            while (reader.Read())
                                            {
                                                 update_moderator_email = reader.GetString(0);
                                                 break;
                                            }
                                            if (update_moderator_email.Equals("") == true)
                                            {
                                                update_moderator_email = first_moderator;
                                                break;
                                            }
                                            
                                        }
                                    }
                                }
                            }
                        }
                    }

                    string moderatorinsertquery = "insert into university_mode_assign(university_complaint_id,university_mode_email) values (@university_complaint_id,@university_mode_email)";
                    
                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(moderatorinsertquery, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@university_complaint_id", complaint_id);
                            command.Parameters.AddWithValue("@university_mode_email", assign_moderator_email);

                            command.ExecuteNonQuery();
                        }
                    }

                    string moderatorupdateassignquery = "update university_mode set status=@no,total_no_of_complaint=@total_no_of_complaint where university_mode_email=@assign_moderator_email";
                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(moderatorupdateassignquery, connection))
                        {
                            connection.Open();

                            total_no_of_complaint++;
                            command.Parameters.AddWithValue("@no", "No");
                            command.Parameters.AddWithValue("@total_no_of_complaint", total_no_of_complaint);
                            command.Parameters.AddWithValue("@assign_moderator_email", assign_moderator_email);

                            command.ExecuteNonQuery();
                        }
                    }

                    string moderatorupdatenextquery = "update university_mode set status=@yes where university_mode_email=@update_moderator_email";
                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(moderatorupdatenextquery, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@yes", "Yes");
                            command.Parameters.AddWithValue("@update_moderator_email", update_moderator_email);

                            command.ExecuteNonQuery();
                        }
                    }
                    /*System.Diagnostics.Debug.WriteLine("Student Email : " + student_email);
                    System.Diagnostics.Debug.WriteLine("Complaint type : " + type_of_complaint);
                    System.Diagnostics.Debug.WriteLine("Category : " + category_id);
                    System.Diagnostics.Debug.WriteLine("complaint_date : " + complaint_date);
                    System.Diagnostics.Debug.WriteLine("complaint_time : " + complaint_time);
                    System.Diagnostics.Debug.WriteLine("complaint_title : " + complaint_title);
                    System.Diagnostics.Debug.WriteLine("complaint_description : " + complaint_description);
                    System.Diagnostics.Debug.WriteLine("complaint_status : " + complaint_status);
                    System.Diagnostics.Debug.WriteLine("complaint_progress : " + complaint_progress);
                    System.Diagnostics.Debug.WriteLine("complaint_id : " + complaint_id);
                    System.Diagnostics.Debug.WriteLine("university_id : " + university_id);
                    System.Diagnostics.Debug.WriteLine("first_moderator : " + first_moderator);
                    System.Diagnostics.Debug.WriteLine("assign_moderator_email : " + assign_moderator_email);
                    System.Diagnostics.Debug.WriteLine("update_moderator_email : " + update_moderator_email);
                    System.Diagnostics.Debug.WriteLine("totalcount : " + totalcount);
                    System.Diagnostics.Debug.WriteLine("statusyescount : " + statusyescount);*/

                    Response.Redirect(@"/lbs/student/track_complaint.aspx");
                }
                if (type_of_complaint.Equals("institute") == true)
                {
                    insertquery = "insert into institute_complaint(student_email,complaint_level,institute_category_id,complaint_date,complaint_time,complaint_title,complaint_description,complaint_status,complaint_progress) values (@student_email,@complaint_level,@institute_category_id,@complaint_date,@complaint_time,@complaint_title,@complaint_description,@complaint_status,@complaint_progress)";

                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(insertquery, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@student_email", student_email);
                            command.Parameters.AddWithValue("@complaint_level", type_of_complaint);
                            command.Parameters.AddWithValue("@institute_category_id", category_id);
                            command.Parameters.AddWithValue("@complaint_date", complaint_date);
                            command.Parameters.AddWithValue("@complaint_time", complaint_time);
                            command.Parameters.AddWithValue("@complaint_title", complaint_title);
                            command.Parameters.AddWithValue("@complaint_description", complaint_description);
                            command.Parameters.AddWithValue("@complaint_status", complaint_status);
                            command.Parameters.AddWithValue("@complaint_progress", complaint_progress);

                            command.ExecuteNonQuery();
                        }
                    }

                    string complaintfetchquery = "select institute_complaint_id from institute_complaint where student_email=@student_email and complaint_level=@complaint_level and institute_category_id=@institute_category_id and complaint_date=@complaint_date and complaint_time=@complaint_time and complaint_title=@complaint_title and complaint_description=@complaint_description and complaint_status=@complaint_status and complaint_progress=@complaint_progress";
                    int complaint_id = 0;

                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(complaintfetchquery, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@student_email", student_email);
                            command.Parameters.AddWithValue("@complaint_level", type_of_complaint);
                            command.Parameters.AddWithValue("@institute_category_id", category_id);
                            command.Parameters.AddWithValue("@complaint_date", complaint_date);
                            command.Parameters.AddWithValue("@complaint_time", complaint_time);
                            command.Parameters.AddWithValue("@complaint_title", complaint_title);
                            command.Parameters.AddWithValue("@complaint_description", complaint_description);
                            command.Parameters.AddWithValue("@complaint_status", complaint_status);
                            command.Parameters.AddWithValue("@complaint_progress", complaint_progress);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        complaint_id = reader.GetInt32(0);
                                    }
                                }
                            }
                        }
                    }

                    string studentfetchquery = "select institute_id from student where student_email=@student_email";
                    int institute_id = 0;

                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(studentfetchquery, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@student_email", student_email);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        institute_id = reader.GetInt32(0);
                                    }
                                }
                            }
                        }
                    }

                    string moderatorfetchquery = "select institute_mode_email,status,total_no_of_complaint from institute_mode where institute_subadmin_email = (select institute_subadmin_email from institute_subadmin where institute_category_id=@category_id and institute_admin_email=(select institute_admin_email from institute_admin where institute_id=@institute_id))";
                    string update_moderator_email = "";
                    string assign_moderator_email = "";
                    string first_moderator = "";
                    //int statusyescount = 0;
                    //int totalcount = 0;
                    int total_no_of_complaint = 0;

                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(moderatorfetchquery, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@category_id", category_id);
                            command.Parameters.AddWithValue("@institute_id", institute_id);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    bool firsttry = true;
                                    while (reader.Read())
                                    {
                                        //totalcount++;
                                        if (firsttry == true)
                                        {
                                            first_moderator = reader.GetString(0);
                                            firsttry = false;
                                        }
                                        string status = reader.GetString(1);
                                        if (status.Equals("Yes"))
                                        {
                                            //statusyescount++;
                                            assign_moderator_email = reader.GetString(0);
                                            total_no_of_complaint = reader.GetInt32(2);
                                            while (reader.Read())
                                            {
                                                update_moderator_email = reader.GetString(0);
                                                break;
                                            }
                                            if (update_moderator_email.Equals("") == true)
                                            {
                                                update_moderator_email = first_moderator;
                                                break;
                                            }

                                        }
                                    }
                                }
                            }
                        }
                    }

                    string moderatorinsertquery = "insert into institute_mode_assign(institute_complaint_id,institute_mode_email) values (@institute_complaint_id,@institute_mode_email)";

                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(moderatorinsertquery, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@institute_complaint_id", complaint_id);
                            command.Parameters.AddWithValue("@institute_mode_email", assign_moderator_email);

                            command.ExecuteNonQuery();
                        }
                    }

                    string moderatorupdateassignquery = "update institute_mode set status=@no,total_no_of_complaint=@total_no_of_complaint where institute_mode_email=@assign_moderator_email";
                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(moderatorupdateassignquery, connection))
                        {
                            connection.Open();

                            total_no_of_complaint++;
                            command.Parameters.AddWithValue("@no", "No");
                            command.Parameters.AddWithValue("@total_no_of_complaint", total_no_of_complaint);
                            command.Parameters.AddWithValue("@assign_moderator_email", assign_moderator_email);

                            command.ExecuteNonQuery();
                        }
                    }

                    string moderatorupdatenextquery = "update institute_mode set status=@yes where institute_mode_email=@update_moderator_email";
                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(moderatorupdatenextquery, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@yes", "Yes");
                            command.Parameters.AddWithValue("@update_moderator_email", update_moderator_email);

                            command.ExecuteNonQuery();
                        }
                    }
                    /*System.Diagnostics.Debug.WriteLine("Student Email : " + student_email);
                    System.Diagnostics.Debug.WriteLine("Complaint type : " + type_of_complaint);
                    System.Diagnostics.Debug.WriteLine("Category : " + category_id);
                    System.Diagnostics.Debug.WriteLine("complaint_date : " + complaint_date);
                    System.Diagnostics.Debug.WriteLine("complaint_time : " + complaint_time);
                    System.Diagnostics.Debug.WriteLine("complaint_title : " + complaint_title);
                    System.Diagnostics.Debug.WriteLine("complaint_description : " + complaint_description);
                    System.Diagnostics.Debug.WriteLine("complaint_status : " + complaint_status);
                    System.Diagnostics.Debug.WriteLine("complaint_progress : " + complaint_progress);
                    System.Diagnostics.Debug.WriteLine("complaint_id : " + complaint_id);
                    System.Diagnostics.Debug.WriteLine("institute_id : " + institute_id);
                    System.Diagnostics.Debug.WriteLine("first_moderator : " + first_moderator);
                    System.Diagnostics.Debug.WriteLine("assign_moderator_email : " + assign_moderator_email);
                    System.Diagnostics.Debug.WriteLine("update_moderator_email : " + update_moderator_email);
                    System.Diagnostics.Debug.WriteLine("totalcount : " + totalcount);
                    System.Diagnostics.Debug.WriteLine("statusyescount : " + statusyescount);*/

                    Response.Redirect(@"/lbs/student/track_complaint.aspx");
                }
                if (type_of_complaint.Equals("department") == true)
                {
                    insertquery = "insert into department_complaint(student_email,complaint_level,department_category_id,complaint_date,complaint_time,complaint_title,complaint_description,complaint_status,complaint_progress) values (@student_email,@complaint_level,@department_category_id,@complaint_date,@complaint_time,@complaint_title,@complaint_description,@complaint_status,@complaint_progress)";

                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(insertquery, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@student_email", student_email);
                            command.Parameters.AddWithValue("@complaint_level", type_of_complaint);
                            command.Parameters.AddWithValue("@department_category_id", category_id);
                            command.Parameters.AddWithValue("@complaint_date", complaint_date);
                            command.Parameters.AddWithValue("@complaint_time", complaint_time);
                            command.Parameters.AddWithValue("@complaint_title", complaint_title);
                            command.Parameters.AddWithValue("@complaint_description", complaint_description);
                            command.Parameters.AddWithValue("@complaint_status", complaint_status);
                            command.Parameters.AddWithValue("@complaint_progress", complaint_progress);

                            command.ExecuteNonQuery();
                        }
                    }

                    string complaintfetchquery = "select department_complaint_id from department_complaint where student_email=@student_email and complaint_level=@complaint_level and department_category_id=@department_category_id and complaint_date=@complaint_date and complaint_time=@complaint_time and complaint_title=@complaint_title and complaint_description=@complaint_description and complaint_status=@complaint_status and complaint_progress=@complaint_progress";
                    int complaint_id = 0;

                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(complaintfetchquery, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@student_email", student_email);
                            command.Parameters.AddWithValue("@complaint_level", type_of_complaint);
                            command.Parameters.AddWithValue("@department_category_id", category_id);
                            command.Parameters.AddWithValue("@complaint_date", complaint_date);
                            command.Parameters.AddWithValue("@complaint_time", complaint_time);
                            command.Parameters.AddWithValue("@complaint_title", complaint_title);
                            command.Parameters.AddWithValue("@complaint_description", complaint_description);
                            command.Parameters.AddWithValue("@complaint_status", complaint_status);
                            command.Parameters.AddWithValue("@complaint_progress", complaint_progress);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        complaint_id = reader.GetInt32(0);
                                    }
                                }
                            }
                        }
                    }

                    string studentfetchquery = "select department_id from student where student_email=@student_email";
                    int department_id = 0;

                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(studentfetchquery, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@student_email", student_email);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        department_id = reader.GetInt32(0);
                                    }
                                }
                            }
                        }
                    }

                    string moderatorfetchquery = "select department_mode_email,status,total_no_of_complaint from department_mode where department_subadmin_email = (select department_subadmin_email from department_subadmin where department_category_id=@category_id and department_admin_email=(select department_admin_email from department_admin where department_id=@department_id))";
                    string update_moderator_email = "";
                    string assign_moderator_email = "";
                    string first_moderator = "";
                    //int statusyescount = 0;
                    //int totalcount = 0;
                    int total_no_of_complaint = 0;

                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(moderatorfetchquery, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@category_id", category_id);
                            command.Parameters.AddWithValue("@department_id", department_id);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    bool firsttry = true;
                                    while (reader.Read())
                                    {
                                        //totalcount++;
                                        if (firsttry == true)
                                        {
                                            first_moderator = reader.GetString(0);
                                            firsttry = false;
                                        }
                                        string status = reader.GetString(1);
                                        if (status.Equals("Yes"))
                                        {
                                            //statusyescount++;
                                            assign_moderator_email = reader.GetString(0);
                                            total_no_of_complaint = reader.GetInt32(2);
                                            while (reader.Read())
                                            {
                                                update_moderator_email = reader.GetString(0);
                                                break;
                                            }
                                            if (update_moderator_email.Equals("") == true)
                                            {
                                                update_moderator_email = first_moderator;
                                                break;
                                            }

                                        }
                                    }
                                }
                            }
                        }
                    }

                    string moderatorinsertquery = "insert into department_mode_assign(department_complaint_id,department_mode_email) values (@department_complaint_id,@department_mode_email)";

                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(moderatorinsertquery, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@department_complaint_id", complaint_id);
                            command.Parameters.AddWithValue("@department_mode_email", assign_moderator_email);

                            command.ExecuteNonQuery();
                        }
                    }

                    string moderatorupdateassignquery = "update department_mode set status=@no,total_no_of_complaint=@total_no_of_complaint where department_mode_email=@assign_moderator_email";
                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(moderatorupdateassignquery, connection))
                        {
                            connection.Open();

                            total_no_of_complaint++;
                            command.Parameters.AddWithValue("@no", "No");
                            command.Parameters.AddWithValue("@total_no_of_complaint", total_no_of_complaint);
                            command.Parameters.AddWithValue("@assign_moderator_email", assign_moderator_email);

                            command.ExecuteNonQuery();
                        }
                    }

                    string moderatorupdatenextquery = "update department_mode set status=@yes where department_mode_email=@update_moderator_email";
                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(moderatorupdatenextquery, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@yes", "Yes");
                            command.Parameters.AddWithValue("@update_moderator_email", update_moderator_email);

                            command.ExecuteNonQuery();
                        }
                    }
                    /*System.Diagnostics.Debug.WriteLine("Student Email : " + student_email);
                    System.Diagnostics.Debug.WriteLine("Complaint type : " + type_of_complaint);
                    System.Diagnostics.Debug.WriteLine("Category : " + category_id);
                    System.Diagnostics.Debug.WriteLine("complaint_date : " + complaint_date);
                    System.Diagnostics.Debug.WriteLine("complaint_time : " + complaint_time);
                    System.Diagnostics.Debug.WriteLine("complaint_title : " + complaint_title);
                    System.Diagnostics.Debug.WriteLine("complaint_description : " + complaint_description);
                    System.Diagnostics.Debug.WriteLine("complaint_status : " + complaint_status);
                    System.Diagnostics.Debug.WriteLine("complaint_progress : " + complaint_progress);
                    System.Diagnostics.Debug.WriteLine("complaint_id : " + complaint_id);
                    System.Diagnostics.Debug.WriteLine("department_id : " + department_id);
                    System.Diagnostics.Debug.WriteLine("first_moderator : " + first_moderator);
                    System.Diagnostics.Debug.WriteLine("assign_moderator_email : " + assign_moderator_email);
                    System.Diagnostics.Debug.WriteLine("update_moderator_email : " + update_moderator_email);
                    System.Diagnostics.Debug.WriteLine("totalcount : " + totalcount);
                    System.Diagnostics.Debug.WriteLine("statusyescount : " + statusyescount);*/

                    Response.Redirect(@"/lbs/student/track_complaint.aspx");
                }
            }
            else
            {
                //Add Css Class
                ComplaintCategory.Attributes.Add("class", String.Join(" ", ComplaintCategory
                           .Attributes["class"]
                           .Split(' ')
                           .Except(new string[] { "", alertclassname })
                           .Concat(new string[] { alertclassname })
                           .ToArray()
                   ));
            }
        }
        else
        {
            //Add Css Class
            ComplaintType.Attributes.Add("class", String.Join(" ", ComplaintType
                       .Attributes["class"]
                       .Split(' ')
                       .Except(new string[] { "", alertclassname })
                       .Concat(new string[] { alertclassname })
                       .ToArray()
               ));
            //Add Css Class
            ComplaintCategory.Attributes.Add("class", String.Join(" ", ComplaintCategory
                       .Attributes["class"]
                       .Split(' ')
                       .Except(new string[] { "", alertclassname })
                       .Concat(new string[] { alertclassname })
                       .ToArray()
               ));
        }
    }
    protected void ComplaintCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        category_of_complaint = ComplaintType.SelectedValue;
    }
}