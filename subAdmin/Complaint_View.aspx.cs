using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Complaint_View : System.Web.UI.Page
{
    string connStr, current_user = "", user_name = "",mode_user="";
    string sub_email="",mode_email = "", student_email = "", complaint_level = "",request_type="",category_name="";
    int complaint_id = 0;
    int category_id = 0;
    string fetchmodequery="";
    int no_of_completed_complaint = 0;
    int university_id = 0, institute_id = 0, department_id = 0;
    protected void Comment_Load()
    {
        string commentquery = "";
        try
        {
            if (complaint_level.Equals("") == false)
            {
                if (complaint_level.Equals("university"))
                {
                    commentquery = "SELECT * FROM university_student_comment where university_complaint_id=@complaint_id";
                }
                if (complaint_level.Equals("institute"))
                {
                    commentquery = "SELECT * FROM institute_student_comment where institute_complaint_id=@complaint_id";
                }
                if (complaint_level.Equals("department"))
                {
                    commentquery = "SELECT * FROM department_student_comment where department_complaint_id=@complaint_id";
                }
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commentquery, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@complaint_id", complaint_id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                messageboxdiv.InnerHtml = "";
                                while (reader.Read())
                                {
                                    string comment_date = reader.GetDateTime(4).ToString("dd MMMM yyyy");
                                    string comment_time = reader.GetString(5);
                                    comment_time = DateTime.Parse(comment_time, System.Globalization.CultureInfo.InvariantCulture).ToString("hh:mm tt");
                                    string comment_description = reader.GetString(6);
                                    string type_of_user = reader.GetString(7);
                                    string comment_username = reader.GetString(8);
                                    if (type_of_user.Equals("university_moderator") || type_of_user.Equals("institute_moderator") || type_of_user.Equals("department_moderator"))
                                    {
                                        messageboxdiv.InnerHtml += @"<div class='col-sm-1 col-md-2 col-lg-2'>";
                                        messageboxdiv.InnerHtml += @"</div>";
                                        messageboxdiv.InnerHtml += @"<div class='outgoing_msg col-sm-11 col-md-10 col-lg-10'>";
                                        messageboxdiv.InnerHtml += @"<div class='sent_msg'>";
                                        messageboxdiv.InnerHtml += @"<div>";
                                        messageboxdiv.InnerHtml += @"<div style='padding-left:10px;margin-bottom:5px;'>";
                                        messageboxdiv.InnerHtml += comment_username;//Moderator Name
                                        messageboxdiv.InnerHtml += @"</div>";
                                        messageboxdiv.InnerHtml += @"</div>";
                                        messageboxdiv.InnerHtml += @"<p>" + comment_description + "</p>";
                                        messageboxdiv.InnerHtml += @"<span class='time_date'> " + comment_time + "    |    " + comment_date + "</span>";
                                        messageboxdiv.InnerHtml += @"</div>";
                                        messageboxdiv.InnerHtml += @"</div>";
                                    }
                                    if (type_of_user.Equals("student"))
                                    {
                                        messageboxdiv.InnerHtml += @"<div class='incoming_msg col-sm-11 col-md-10 col-lg-10'>";
                                        messageboxdiv.InnerHtml += @"<div class='incoming_msg_img'>";
                                        messageboxdiv.InnerHtml += @"<div style='width:300px;'>";
                                        messageboxdiv.InnerHtml += @"<img src='/lbs/img/user-profile.png' alt='user-image' style='float:left;width:33px;margin-right:10px;'/>";
                                        messageboxdiv.InnerHtml += @"<div style='padding-left:10px;padding-top:5px;'>";
                                        messageboxdiv.InnerHtml += comment_username;// Student Name
                                        messageboxdiv.InnerHtml += @"</div>";
                                        messageboxdiv.InnerHtml += @"</div>";
                                        messageboxdiv.InnerHtml += @"</div>";
                                        messageboxdiv.InnerHtml += @"<div class='received_msg'>";
                                        messageboxdiv.InnerHtml += @"<div class='received_withd_msg'>";
                                        messageboxdiv.InnerHtml += @"<p>" + comment_description + "</p>";
                                        messageboxdiv.InnerHtml += @"<span class='time_date'> " + comment_time + "    |    " + comment_date + "</span>";
                                        messageboxdiv.InnerHtml += @"</div>";
                                        messageboxdiv.InnerHtml += @"</div>";
                                        messageboxdiv.InnerHtml += @"</div>";
                                        messageboxdiv.InnerHtml += @"<div class='col-sm-1 col-md-2 col-lg-2'>";
                                        messageboxdiv.InnerHtml += @"</div>";
                                    }
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
    protected void Page_Load(object sender, EventArgs e)
    {
        connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

        if (Session["email"] == null)
        {
            Response.Redirect(@"/lbs/index.aspx");
        }
        if (Session["email"] != null)
        {
            sub_email = Session["email"].ToString();
        }
        if (Session["typeofuser"] != null)
        {
            current_user = Session["typeofuser"].ToString();
            if (current_user.Contains("sub_admin") == false)
            {
                Response.Redirect("/lbs/logout.aspx");
            }
        }
        if (Session["username"] != null)
        {
            user_name = Session["username"].ToString();
        }
        if (Request.QueryString["ID"] != null)
        {
            complaint_id = Convert.ToInt32(Request.QueryString["ID"]);
        }
        else
        {
            Response.Redirect(@"/lbs/subAdmin/subadmin_index.aspx");
        }
        if (Request.QueryString["Type"] != null)
        {
            complaint_level = Request.QueryString["Type"];
            if (complaint_level.Equals("university") == false)
            {
                if (complaint_level.Equals("institute") == false)
                {
                    if (complaint_level.Equals("department") == false)
                    {
                        Response.Redirect(@"/lbs/subAdmin/subadmin_index.aspx");
                    }
                }
            }

        }
        else
        {
            Response.Redirect(@"/lbs/subAdmin/subadmin_index.aspx");
        }
        if (Request.QueryString["RequestTypeC"] != null)
        {
            request_type = Request.QueryString["RequestTypeC"];
            if (request_type.Equals("Reassign") == false)
            {
                if (request_type.Equals("Reappeal") == false)
                {
                    if (request_type.Equals("Report") == false)
                    {
                        Response.Redirect(@"/lbs/subAdmin/subadmin_index.aspx");
                    }
                }
            }

        }
        else
        {
            Response.Redirect(@"/lbs/subAdmin/subadmin_index.aspx");
        }

        try
        {
            string fetchcomplaintquery = "", fetchcategoryquery = "",fetchstudentquery="";
            if (complaint_level.Equals("") == false)
            {
                if (complaint_level.Equals("university"))
                {
                    fetchcomplaintquery = "SELECT * FROM university_complaint where university_complaint_id=@complaint_id and complaint_level=@complaint_level";
                    fetchcategoryquery = "SELECT * from university_category where university_category_id=@category_id";
                    fetchmodequery = "select * from university_mode where university_mode_email=(select university_mode_email from university_mode_assign where university_complaint_id=@complaint_id and reassign_status is NULL and (assign_status='Resign' or assign_status='Reappeal'))";
                    if (request_type.Equals("Report"))
                    {
                        fetchmodequery = "select * from university_mode where university_mode_email=(select university_mode_email from university_mode_assign where university_complaint_id=@complaint_id and reassign_status='Yes' and assign_status='Resign')";
                    }
                }
                if (complaint_level.Equals("institute"))
                {
                    fetchcomplaintquery = "SELECT * FROM institute_complaint where institute_complaint_id=@complaint_id and complaint_level=@complaint_level";
                    fetchcategoryquery = "SELECT * from institute_category where institute_category_id=@category_id";
                    fetchmodequery = "select * from institute_mode where institute_mode_email=(select institute_mode_email from institute_mode_assign where institute_complaint_id=@complaint_id and reassign_status is NULL and (assign_status='Resign' or assign_status='Reappeal'))";
                    if (request_type.Equals("Report"))
                    {
                        fetchmodequery = "select * from institute_mode where institute_mode_email=(select institute_mode_email from institute_mode_assign where institute_complaint_id=@complaint_id and reassign_status='Yes' and assign_status='Resign')";
                    }
                }
                if (complaint_level.Equals("department"))
                {
                    fetchcomplaintquery = "SELECT * FROM department_complaint where department_complaint_id=@complaint_id and complaint_level=@complaint_level";
                    fetchcategoryquery = "SELECT * from department_category where department_category_id=@category_id";
                    fetchmodequery = "select * from department_mode where department_mode_email=(select department_mode_email from department_mode_assign where department_complaint_id=@complaint_id and reassign_status is NULL and (assign_status='Resign' or assign_status='Reappeal'))";
                    if (request_type.Equals("Report"))
                    {
                        fetchmodequery = "select * from department_mode where department_mode_email=(select department_mode_email from department_mode_assign where department_complaint_id=@complaint_id and reassign_status='Yes' and assign_status='Resign')";
                    }
                }
                
                using (SqlConnection modconnection = new SqlConnection(connStr))
                {
                    using (SqlCommand modcommand = new SqlCommand(fetchmodequery, modconnection))
                    {
                        modconnection.Open();
                        modcommand.Parameters.AddWithValue("@complaint_id", complaint_id);

                        using (SqlDataReader modreader = modcommand.ExecuteReader())
                        {
                            if (modreader.HasRows)
                            {
                                while (modreader.Read())
                                {
                                    string first_name = modreader.GetString(0);
                                    string last_name = modreader.GetString(1);
                                    mode_user = first_name + " " + last_name;
                                    no_of_completed_complaint = modreader.GetInt32(5);
                                    mode_email = modreader.GetString(2);
                                }
                            }
                            else
                            {
                                Response.Redirect(@"/lbs/subAdmin/subadmin_index.aspx");
                            }
                        }
                    }
                }
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(fetchcomplaintquery, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@complaint_id", complaint_id);
                        command.Parameters.AddWithValue("@complaint_level", complaint_level);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    student_email = reader.GetString(1);
                                    category_id = reader.GetInt32(3);
                                    string complaint_date = reader.GetDateTime(4).ToShortDateString();
                                    string complaint_time = reader.GetString(5);
                                    complaint_time = DateTime.Parse(complaint_time, System.Globalization.CultureInfo.InvariantCulture).ToString("hh:mm tt");
                                    string complaint_title = reader.GetString(6);
                                    string complaint_description = reader.GetString(7);
                                    string complaint_status = reader.GetString(8);
                                    string complaint_progress = reader.GetString(9);
                                    complaintiddiv.InnerHtml = "" + complaint_id;
                                    complaintdatediv.InnerHtml = complaint_date;
                                    complainttimediv.InnerHtml = complaint_time;
                                    progressdiv.InnerHtml = complaint_status;
                                    statusdiv.InnerHtml = complaint_progress;
                                    titlediv.InnerHtml = complaint_title;
                                    descriptiondiv.InnerHtml = complaint_description;
                                }
                            }
                            else
                            {
                                Response.Redirect(@"/lbs/subAdmin/subadmin_index.aspx");
                            }
                        }
                    }
                }
                //Comment_Load
                Comment_Load();
                fetchstudentquery = "select university_id,institute_id,department_id from student where student_email=@student_email";
                using (SqlConnection stuconnection = new SqlConnection(connStr))
                {
                    using (SqlCommand stucommand = new SqlCommand(fetchstudentquery, stuconnection))
                    {
                        stuconnection.Open();
                        stucommand.Parameters.AddWithValue("@student_email", student_email);

                        using (SqlDataReader stureader = stucommand.ExecuteReader())
                        {
                            if (stureader.HasRows)
                            {
                                while (stureader.Read())
                                {
                                    university_id = stureader.GetInt32(0);
                                    institute_id = stureader.GetInt32(1);
                                    department_id = stureader.GetInt32(2);
                                }
                            }
                            else
                            {
                                Response.Redirect(@"/lbs/subAdmin/subadmin_index.aspx");
                            }
                        }
                    }
                }

                string fetchrequestdetailquery = "";
                if (request_type.Equals("Reassign"))
                {
                    reassigndiv.Style["display"] = "block";
                    if (complaint_level.Equals("university"))
                    {
                        fetchrequestdetailquery = "select * from university_mode_assign where university_complaint_id=@complaint_id and reassign_status is NULL and assign_status='Resign'";
                    }
                    if (complaint_level.Equals("institute"))
                    {
                        fetchrequestdetailquery = "select * from institute_mode_assign where institute_complaint_id=@complaint_id and reassign_status is NULL and assign_status='Resign'";
                    }
                    if (complaint_level.Equals("department"))
                    {
                        fetchrequestdetailquery = "select * from department_mode_assign where department_complaint_id=@complaint_id and reassign_status is NULL and assign_status='Resign'";
                    }
                }
                if (request_type.Equals("Reappeal"))
                {
                    reappealdiv.Style["display"] = "block";
                    if (complaint_level.Equals("university"))
                    {
                        fetchrequestdetailquery = "select * from university_mode_assign where university_complaint_id=@complaint_id and reassign_status is NULL and assign_status='Reappeal'";
                    }
                    if (complaint_level.Equals("institute"))
                    {
                        fetchrequestdetailquery = "select * from institute_mode_assign where institute_complaint_id=@complaint_id and reassign_status is NULL and assign_status='Reappeal'";
                    }
                    if (complaint_level.Equals("department"))
                    {
                        fetchrequestdetailquery = "select * from department_mode_assign where department_complaint_id=@complaint_id and reassign_status is NULL and assign_status='Reappeal'";
                    }
                }
                if (request_type.Equals("Report"))
                {
                    reportdiv.Style["display"] = "block";
                    if (complaint_level.Equals("university"))
                    {
                        fetchrequestdetailquery = "select * from university_complaint_report where university_complaint_id=@complaint_id and report_approved is NULL";
                    }
                    if (complaint_level.Equals("institute"))
                    {
                        fetchrequestdetailquery = "select * from institute_complaint_report where institute_complaint_id=@complaint_id and report_approved is NULL";
                    }
                    if (complaint_level.Equals("department"))
                    {
                        fetchrequestdetailquery = "select * from department_complaint_report where department_complaint_id=@complaint_id and report_approved is NULL";
                    }
                }
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(fetchcategoryquery, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@category_id", category_id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    category_name = reader.GetString(1);
                                    catdiv.InnerHtml = category_name;
                                }
                            }
                            else
                            {
                                Response.Redirect(@"/lbs/subAdmin/subadmin_index.aspx");
                            }
                        }
                    }
                }
                string desc="";
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(fetchrequestdetailquery, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@complaint_id", complaint_id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    if (request_type.Equals("Reassign"))
                                    {
                                        int updatecategory_id = reader.GetInt32(5);
                                        if (category_id != updatecategory_id)
                                        {
                                            using (SqlConnection connection1 = new SqlConnection(connStr))
                                            {
                                                using (SqlCommand command1 = new SqlCommand(fetchcategoryquery, connection1))
                                                {
                                                    connection1.Open();
                                                    command1.Parameters.AddWithValue("@category_id", updatecategory_id);

                                                    using (SqlDataReader reader1 = command1.ExecuteReader())
                                                    {
                                                        if (reader1.HasRows)
                                                        {
                                                            while (reader1.Read())
                                                            {
                                                                category_name = reader1.GetString(1);
                                                                reassigncatname.InnerHtml = category_name;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Response.Redirect(@"/lbs/subAdmin/subadmin_index.aspx");
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            reassigncatname.InnerHtml = category_name;
                                        }
                                        desc=reader.GetString(6);
                                        reassigndesc.InnerHtml = desc;
                                        reassignmodenamediv.InnerHtml = mode_user;
                                        reassignmodeemaildiv.InnerHtml = mode_email;
                                    }
                                    if (request_type.Equals("Reappeal"))
                                    {
                                        desc = reader.GetString(6);
                                        reappealcatdiv.InnerHtml = category_name;
                                        reappealdesc.InnerHtml = desc;
                                        reappealmodenamediv.InnerHtml = mode_user;
                                        reappealmodeemaildiv.InnerHtml = mode_email;
                                    }
                                    if (request_type.Equals("Report"))
                                    {
                                        reportcatdiv.InnerHtml = category_name;
                                        mode_email = reader.GetString(2);
                                        string type_of_report = reader.GetString(3);
                                        string report_desc = reader.GetString(4);
                                        reportmodenamediv.InnerHtml = mode_user;
                                        reportmodeemaildiv.InnerHtml = mode_email;
                                        reporttypediv.InnerHtml = type_of_report;
                                        reportdesc.InnerHtml = report_desc;
                                    }
                                }
                            }
                            else
                            {
                                Response.Redirect(@"/lbs/subAdmin/subadmin_index.aspx");
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
    protected void Yes_Click(object sender, EventArgs e)
    {
        try
        {
            if (request_type.Equals("Reassign"))
            {
                string updateressignquery = "";
                if (complaint_level.Equals("university"))
                {
                    updateressignquery = "update university_mode_assign set reassign_status='Yes' where university_complaint_id=@complaint_id and university_mode_email=@mode_email";
                }
                if (complaint_level.Equals("institute"))
                {
                    updateressignquery = "update institute_mode_assign set reassign_status='Yes' where institute_complaint_id=@complaint_id and institute_mode_email=@mode_email";
                }
                if (complaint_level.Equals("department"))
                {
                    updateressignquery = "update department_mode_assign set reassign_status='Yes' where department_complaint_id=@complaint_id and department_mode_email=@mode_email";
                }
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(updateressignquery, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@complaint_id", complaint_id);
                        command.Parameters.AddWithValue("@mode_email", mode_email);

                        command.ExecuteNonQuery();
                    }
                }
                //do moderator change
                ModeratorChange();
            }
            if (request_type.Equals("Reappeal"))
            {
                string updatereappealquery = "", updatemodecompletechangequery = "", updatecomplaintquery="";
                if (complaint_level.Equals("university"))
                {
                    updatereappealquery = "update university_mode_assign set reassign_status='Yes' where university_complaint_id=@complaint_id and university_mode_email=@mode_email";
                    updatemodecompletechangequery = "update university_mode set no_of_solved_complaint=@no_of_completed_complaint where university_mode_email=@mode_email";
                    updatecomplaintquery = "update university_complaint set complaint_status='Open',complaint_progress='Pending' where university_complaint_id=@complaint_id";
                }
                if (complaint_level.Equals("institute"))
                {
                    updatereappealquery = "update institute_mode_assign set reassign_status='Yes' where institute_complaint_id=@complaint_id and institute_mode_email=@mode_email";
                    updatemodecompletechangequery = "update institute_mode set no_of_solved_complaint=@no_of_completed_complaint where institute_mode_email=@mode_email";
                    updatecomplaintquery = "update institute_complaint set complaint_status='Open',complaint_progress='Pending' where institute_complaint_id=@complaint_id";
                }
                if (complaint_level.Equals("department"))
                {
                    updatereappealquery = "update department_mode_assign set reassign_status='Yes' where department_complaint_id=@complaint_id and department_mode_email=@mode_email";
                    updatemodecompletechangequery = "update department_mode set no_of_solved_complaint=@no_of_completed_complaint where department_mode_email=@mode_email";
                    updatecomplaintquery = "update department_complaint set complaint_status='Open',complaint_progress='Pending' where department_complaint_id=@complaint_id";
                }
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(updatereappealquery, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@complaint_id", complaint_id);
                        command.Parameters.AddWithValue("@mode_email", mode_email);

                        command.ExecuteNonQuery();
                    }
                }
                //decrement completed no. from mode
                no_of_completed_complaint--;
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(updatemodecompletechangequery, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@no_of_completed_complaint", no_of_completed_complaint);
                        command.Parameters.AddWithValue("@mode_email", mode_email);

                        command.ExecuteNonQuery();
                    }
                }
                //change complaint status 'Open',complaint progress 'Pending'
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(updatecomplaintquery, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@complaint_id", complaint_id);

                        command.ExecuteNonQuery();
                    }
                }
                //do moderator change
                ModeratorChange();
            }
            if (request_type.Equals("Report"))
            {
                string updatereportquery = "",updatecomplaintquery="";
                if (complaint_level.Equals("university"))
                {
                    updatereportquery = "update university_complaint_report set report_approved='Yes' where university_complaint_id=@complaint_id and university_mode_email=@mode_email";
                    updatecomplaintquery = "update university_complaint set complaint_status='Reported',complaint_progress='Completed' where university_complaint_id=@complaint_id";
                }
                if (complaint_level.Equals("institute"))
                {
                    updatereportquery = "update institute_complaint_report set report_approved='Yes' where institute_complaint_id=@complaint_id and institute_mode_email=@mode_email";
                    updatecomplaintquery = "update institute_complaint set complaint_status='Reported',complaint_progress='Completed' where institute_complaint_id=@complaint_id";
                }
                if (complaint_level.Equals("department"))
                {
                    updatereportquery = "update department_complaint_report set report_approved='Yes' where department_complaint_id=@complaint_id and department_mode_email=@mode_email";
                    updatecomplaintquery = "update department_complaint set complaint_status='Reported',complaint_progress='Completed' where department_complaint_id=@complaint_id";
                }
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(updatereportquery, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@complaint_id", complaint_id);
                        command.Parameters.AddWithValue("@mode_email", mode_email);

                        command.ExecuteNonQuery();
                    }
                }
                //change complaint status 'Reported',progress 'Completed'
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(updatecomplaintquery, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@complaint_id", complaint_id);

                        command.ExecuteNonQuery();
                    }
                }
            }
            Response.Redirect(@"/lbs/subAdmin/subadmin_index.aspx");
        }
        catch (Exception e1)
        {
            System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
        }
    }
    protected void No_Click(object sender, EventArgs e)
    {
        try
        {
            if (request_type.Equals("Reassign"))
            {
                string updateressignquery = "";
                if (complaint_level.Equals("university"))
                {
                    updateressignquery = "update university_mode_assign set reassign_status='No',assign_status='Assign' where university_complaint_id=@complaint_id and university_mode_email=@mode_email";
                }
                if (complaint_level.Equals("institute"))
                {
                    updateressignquery = "update institute_mode_assign set reassign_status='No',assign_status='Assign' where institute_complaint_id=@complaint_id and institute_mode_email=@mode_email";
                }
                if (complaint_level.Equals("department"))
                {
                    updateressignquery = "update department_mode_assign set reassign_status='No',assign_status='Assign' where department_complaint_id=@complaint_id and department_mode_email=@mode_email";
                }
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(updateressignquery, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@complaint_id", complaint_id);
                        command.Parameters.AddWithValue("@mode_email", mode_email);

                        command.ExecuteNonQuery();
                    }
                }
            }
            if (request_type.Equals("Reappeal"))
            {
                string updatereappealquery = "", updatecomplaintquery = "";
                if (complaint_level.Equals("university"))
                {
                    updatereappealquery = "update university_mode_assign set reassign_status='No',assign_status='Completed' where university_complaint_id=@complaint_id and university_mode_email=@mode_email";
                    updatecomplaintquery = "update university_complaint set complaint_status='Closed' where university_complaint_id=@complaint_id";
                }
                if (complaint_level.Equals("institute"))
                {
                    updatereappealquery = "update institute_mode_assign set reassign_status='No',assign_status='Completed' where institute_complaint_id=@complaint_id and institute_mode_email=@mode_email";
                    updatecomplaintquery = "update institute_complaint set complaint_status='Closed' where institute_complaint_id=@complaint_id";
                }
                if (complaint_level.Equals("department"))
                {
                    updatereappealquery = "update department_mode_assign set reassign_status='No',assign_status='Completed' where department_complaint_id=@complaint_id and department_mode_email=@mode_email";
                    updatecomplaintquery = "update department_complaint set complaint_status='Closed' where department_complaint_id=@complaint_id";
                }
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(updatereappealquery, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@complaint_id", complaint_id);
                        command.Parameters.AddWithValue("@mode_email", mode_email);

                        command.ExecuteNonQuery();
                    }
                }
                //change complaint status 'Closed'
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(updatecomplaintquery, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@complaint_id", complaint_id);

                        command.ExecuteNonQuery();
                    }
                }
            }
            if (request_type.Equals("Report"))
            {
                string updatereportquery = "";
                if (complaint_level.Equals("university"))
                {
                    updatereportquery = "update university_complaint_report set report_approved='No' where university_complaint_id=@complaint_id and university_mode_email=@mode_email";
                }
                if (complaint_level.Equals("institute"))
                {
                    updatereportquery = "update institute_complaint_report set report_approved='No' where institute_complaint_id=@complaint_id and institute_mode_email=@mode_email";
                }
                if (complaint_level.Equals("department"))
                {
                    updatereportquery = "update department_complaint_report set report_approved='No' where department_complaint_id=@complaint_id and department_mode_email=@mode_email";
                }
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(updatereportquery, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@complaint_id", complaint_id);
                        command.Parameters.AddWithValue("@mode_email", mode_email);

                        command.ExecuteNonQuery();
                    }
                }
                //do moderator change
                ModeratorChange();
            }
            Response.Redirect(@"/lbs/subAdmin/subadmin_index.aspx");
        }
        catch (Exception e1)
        {
            System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
        }
    }
    protected void ModeratorChange()
    {
        string moderatorfetchquery = "", moderatorinsertquery = "", moderatorupdateassignquery="",moderatorupdatenextquery = "";
        if (complaint_level.Equals("university"))
        {
            moderatorfetchquery = "select university_mode_email,status,total_no_of_complaint from university_mode where university_subadmin_email = (select university_subadmin_email from university_subadmin where university_category_id=@category_id and university_admin_email=(select university_admin_email from university_admin where university_id=@id))";
            moderatorinsertquery = "insert into university_mode_assign(university_complaint_id,university_mode_email) values (@complaint_id,@mode_email)";
            moderatorupdateassignquery = "update university_mode set status=@no,total_no_of_complaint=@total_no_of_complaint where university_mode_email=@assign_moderator_email";
            moderatorupdatenextquery = "update university_mode set status=@yes where university_mode_email=@update_moderator_email";
        }
        if (complaint_level.Equals("institute"))
        {
            moderatorfetchquery = "select institute_mode_email,status,total_no_of_complaint from institute_mode where institute_subadmin_email = (select institute_subadmin_email from institute_subadmin where institute_category_id=@category_id and institute_admin_email=(select institute_admin_email from institute_admin where institute_id=@id))";
            moderatorinsertquery = "insert into institute_mode_assign(institute_complaint_id,institute_mode_email) values (@complaint_id,@mode_email)";
            moderatorupdateassignquery = "update institute_mode set status=@no,total_no_of_complaint=@total_no_of_complaint where institute_mode_email=@assign_moderator_email";
            moderatorupdatenextquery = "update institute_mode set status=@yes where institute_mode_email=@update_moderator_email";
        }
        if (complaint_level.Equals("department"))
        {
            moderatorfetchquery = "select department_mode_email,status,total_no_of_complaint from department_mode where department_subadmin_email = (select department_subadmin_email from department_subadmin where department_category_id=@category_id and department_admin_email=(select department_admin_email from department_admin where department_id=@id))";
            moderatorinsertquery = "insert into department_mode_assign(department_complaint_id,department_mode_email) values (@complaint_id,@mode_email)";
            moderatorupdateassignquery = "update department_mode set status=@no,total_no_of_complaint=@total_no_of_complaint where department_mode_email=@assign_moderator_email";
            moderatorupdatenextquery = "update department_mode set status=@yes where department_mode_email=@update_moderator_email";
        }
        
        string update_moderator_email = "";
        string assign_moderator_email = "";
        string assign_same_moderator_email = "";
        string first_moderator = "";
        string firststatus = "";
        //int statusyescount = 0;
        //int totalcount = 0;
        int total_no_of_complaint = 0;
        bool shouldupdatenext = true;

        using (SqlConnection connection = new SqlConnection(connStr))
        {
            using (SqlCommand command = new SqlCommand(moderatorfetchquery, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@mode_email", mode_email);
                command.Parameters.AddWithValue("@category_id", category_id);

                if (complaint_level.Equals("university"))
                {
                    command.Parameters.AddWithValue("@id", university_id);
                }
                if (complaint_level.Equals("institute"))
                {
                    command.Parameters.AddWithValue("@id", institute_id);
                }
                if (complaint_level.Equals("department"))
                {
                    command.Parameters.AddWithValue("@id", department_id);
                }

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
                                if (first_moderator.Equals(mode_email))
                                {
                                    firststatus = reader.GetString(1);
                                    if (firststatus.Equals("Yes"))
                                    {
                                        //first_moderator = "";
                                        //statuscheckmode = true;
                                        shouldupdatenext = false;
                                        assign_same_moderator_email = reader.GetString(0);
                                        while (reader.Read())
                                        {
                                            assign_same_moderator_email = "";
                                            assign_moderator_email = reader.GetString(0);
                                            total_no_of_complaint = reader.GetInt32(2);
                                            break;
                                        }
                                        break;
                                    }
                                }
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
        
        if (shouldupdatenext == false)
        {
            if (assign_same_moderator_email.Equals("") == false)
            {
                //update same moderator assign status as assign in mode assign
                string moderatorupdatesamequery = "";
                if (complaint_level.Equals("university"))
                {
                    if (request_type.Equals("Reassign"))
                    {
                        moderatorupdatesamequery = "update university_mode_assign set assign_status='Assign',reassign_status='No' where university_complaint_id=@complaint_id and university_mode_email=@mode_email";
                    }
                    if (request_type.Equals("Reappeal"))
                    {
                        moderatorupdatesamequery = "update university_mode_assign set assign_status='Assign' where university_complaint_id=@complaint_id and university_mode_email=@mode_email";
                    }
                }
                if (complaint_level.Equals("institute"))
                {
                    if (request_type.Equals("Reassign"))
                    {
                        moderatorupdatesamequery = "update institute_mode_assign set assign_status='Assign',reassign_status='No' where institute_complaint_id=@complaint_id and institute_mode_email=@mode_email";
                    }
                    if (request_type.Equals("Reappeal"))
                    {
                        moderatorupdatesamequery = "update institute_mode_assign set assign_status='Assign' where institute_complaint_id=@complaint_id and institute_mode_email=@mode_email";
                    }
                }
                if (complaint_level.Equals("department"))
                {
                    if (request_type.Equals("Reassign"))
                    {
                        moderatorupdatesamequery = "update department_mode_assign set assign_status='Assign',reassign_status='No' where department_complaint_id=@complaint_id and department_mode_email=@mode_email";
                    }
                    if (request_type.Equals("Reappeal"))
                    {
                        moderatorupdatesamequery = "update department_mode_assign set assign_status='Assign' where department_complaint_id=@complaint_id and department_mode_email=@mode_email";
                    }
                }

                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(moderatorupdatesamequery, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@complaint_id", complaint_id);
                        command.Parameters.AddWithValue("@mode_email", assign_same_moderator_email);

                        command.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                //insert new assign moderator in mode assign and update total no of complaint in mode table
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(moderatorinsertquery, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@complaint_id", complaint_id);
                        command.Parameters.AddWithValue("@mode_email", assign_moderator_email);

                        command.ExecuteNonQuery();
                    }
                }
                //updatemoderatorassignquery
                string moderatorupdateassigndiffquery = "";
                if (complaint_level.Equals("university"))
                {
                    moderatorupdateassigndiffquery = "update university_mode set total_no_of_complaint=@total_no_of_complaint where university_mode_email=@assign_moderator_email";
                }
                if (complaint_level.Equals("institute"))
                {
                    moderatorupdateassigndiffquery = "update institute_mode set total_no_of_complaint=@total_no_of_complaint where institute_mode_email=@assign_moderator_email";
                }
                if (complaint_level.Equals("department"))
                {
                    moderatorupdateassigndiffquery = "update department_mode set total_no_of_complaint=@total_no_of_complaint where department_mode_email=@assign_moderator_email";
                }

                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(moderatorupdateassigndiffquery, connection))
                    {
                        connection.Open();

                        total_no_of_complaint++;
                        command.Parameters.AddWithValue("@total_no_of_complaint", total_no_of_complaint);
                        command.Parameters.AddWithValue("@assign_moderator_email", assign_moderator_email);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }
        else
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand(moderatorinsertquery, connection))
                {
                    connection.Open();

                    command.Parameters.AddWithValue("@complaint_id", complaint_id);
                    command.Parameters.AddWithValue("@mode_email", assign_moderator_email);

                    command.ExecuteNonQuery();
                }
            }

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
        }
    }
}