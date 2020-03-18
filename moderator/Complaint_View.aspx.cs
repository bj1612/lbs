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
    string connStr, current_user = "", user_name = "";
    string mode_email = "", student_email = "", complaint_level = "";
    int complaint_id = 0;
    protected void Comment_Load()
    {
        string commentquery = "";
        bool firstmodecomment = true;
        string updatecomplainttable = "";
        try
        {
            if (complaint_level.Equals("") == false)
            {
                if (complaint_level.Equals("university"))
                {
                    commentquery = "SELECT * FROM university_student_comment where university_complaint_id=@complaint_id";
                    updatecomplainttable = "update university_complaint set complaint_status='In Progress' where university_complaint_id=@complaint_id";
                }
                if (complaint_level.Equals("institute"))
                {
                    commentquery = "SELECT * FROM institute_student_comment where institute_complaint_id=@complaint_id";
                    updatecomplainttable = "update institute_complaint set complaint_status='In Progress' where institute_complaint_id=@complaint_id";
                }
                if (complaint_level.Equals("department"))
                {
                    commentquery = "SELECT * FROM department_student_comment where department_complaint_id=@complaint_id";
                    updatecomplainttable = "update department_complaint set complaint_status='In Progress' where department_complaint_id=@complaint_id";
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
                                        firstmodecomment = false;
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
                                        messageboxdiv.InnerHtml += "Student";// Student Name
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

                if (firstmodecomment == true)
                {
                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(updatecomplainttable, connection))
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@complaint_id", complaint_id);

                            command.ExecuteNonQuery();
                            progressdiv.InnerHtml = "In Progress";
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
            mode_email = Session["email"].ToString();
        }
        if (Session["typeofuser"] != null)
        {
            current_user = Session["typeofuser"].ToString();
            if (current_user.Contains("moderator") == false)
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
            Response.Redirect(@"/lbs/moderator/track_complaint.aspx");
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
                        Response.Redirect(@"/lbs/moderator/track_complaint.aspx");
                    }
                }
            }

        }
        else
        {
            Response.Redirect(@"/lbs/student/track_complaint.aspx");
        }
        /*System.Diagnostics.Debug.WriteLine("student_email: " + student_email);
        System.Diagnostics.Debug.WriteLine("Complaint_id: " + complaint_id);
        System.Diagnostics.Debug.WriteLine("Complaint_level: " + complaint_level);*/
        try
        {
            string checkmode = "", checkisclosed = "", fetchcomplaintquery = "", loadcategoryquery="";
            bool checkmodebool = false;
            if (complaint_level.Equals("") == false)
            {
                if (complaint_level.Equals("university"))
                {
                    loadcategoryquery = "SELECT * FROM university_category";
                    checkmode = "SELECT * FROM university_mode_assign where university_mode_email=@mode_email and university_complaint_id=@complaint_id and (assign_status='Assign' or assign_status='Completed')";
                    checkisclosed = "SELECT * FROM university_complaint where university_complaint_id=@complaint_id and complaint_progress='Completed' and complaint_level=@complaint_level";
                    fetchcomplaintquery = "SELECT * FROM university_complaint where university_complaint_id=@complaint_id and complaint_level=@complaint_level";
                }
                if (complaint_level.Equals("institute"))
                {
                    loadcategoryquery = "SELECT * FROM institute_category";
                    checkmode = "SELECT * FROM institute_mode_assign where institute_mode_email=@mode_email and institute_complaint_id=@complaint_id and (assign_status='Assign' or assign_status='Completed')";
                    checkisclosed = "SELECT * FROM institute_complaint where institute_complaint_id=@complaint_id and complaint_progress='Completed' and complaint_level=@complaint_level";
                    fetchcomplaintquery = "SELECT * FROM institute_complaint where institute_complaint_id=@complaint_id and complaint_level=@complaint_level";
                }
                if (complaint_level.Equals("department"))
                {
                    loadcategoryquery = "SELECT * FROM department_category";
                    checkmode = "SELECT * FROM department_mode_assign where department_mode_email=@mode_email and department_complaint_id=@complaint_id and (assign_status='Assign' or assign_status='Completed')";
                    checkisclosed = "SELECT * FROM department_complaint where department_complaint_id=@complaint_id and complaint_progress='Completed' and complaint_level=@complaint_level";
                    fetchcomplaintquery = "SELECT * FROM department_complaint where department_complaint_id=@complaint_id and complaint_level=@complaint_level";
                }
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(loadcategoryquery, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    string category_id = reader.GetInt32(0).ToString();
                                    string category_name = reader.GetString(1);
                                    if (!string.IsNullOrEmpty(category_name))
                                    {
                                        ReassignCategory.Items.Add(new ListItem(category_name, category_id));
                                    }
                                }
                            }
                        }
                    }
                }

                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(checkmode, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@mode_email", mode_email);
                        command.Parameters.AddWithValue("@complaint_id", complaint_id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                checkmodebool = true;
                            }
                        }
                    }
                }
                if (checkmodebool == true)
                {
                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(checkisclosed, connection))
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@complaint_id", complaint_id);
                            command.Parameters.AddWithValue("@complaint_level", complaint_level);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    commenttextboxdiv.Style["display"] = "none";
                                    reassigndiv.Style["display"] = "none";
                                    reportdiv.Style["display"] = "none";
                                    closediv.Style["display"] = "none";
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
                                    Response.Redirect(@"/lbs/moderator/track_complaint.aspx");
                                }
                            }
                        }
                    }
                    //Comment_Load
                    Comment_Load();
                }
                else
                {
                    Response.Redirect(@"/lbs/moderator/track_complaint.aspx");
                }
            }
        }
        catch (Exception e1)
        {
            System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
        }
    }
    protected void Comment_Click(object sender, EventArgs e)
    {
        string comment_description = CommentBox.Text;
        if (comment_description.Equals("") == false)
        {
            try
            {
                string insertquery = "";
                if (complaint_level.Equals("university") == true)
                {
                    insertquery = "insert into university_student_comment(university_complaint_id,sender_email,reciever_email,comment_date,comment_time,comment_description,type_of_user,comment_username) values (@complaint_id,@sender_email,@reciever_email,@comment_date,@comment_time,@comment_description,@type_of_user,@comment_username)";
                }
                if (complaint_level.Equals("institute"))
                {
                    insertquery = "insert into institute_student_comment(institute_complaint_id,sender_email,reciever_email,comment_date,comment_time,comment_description,type_of_user,comment_username) values (@complaint_id,@sender_email,@reciever_email,@comment_date,@comment_time,@comment_description,@type_of_user,@comment_username)";
                }
                if (complaint_level.Equals("department"))
                {
                    insertquery = "insert into department_student_comment(department_complaint_id,sender_email,reciever_email,comment_date,comment_time,comment_description,type_of_user,comment_username) values (@complaint_id,@sender_email,@reciever_email,@comment_date,@comment_time,@comment_description,@type_of_user,@comment_username)";
                }
                string comment_date = "", comment_time = "";
                comment_date = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
                comment_time = DateTime.Now.ToShortTimeString();
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(insertquery, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@complaint_id", complaint_id);
                        command.Parameters.AddWithValue("@sender_email", mode_email);
                        command.Parameters.AddWithValue("@reciever_email", student_email);
                        command.Parameters.AddWithValue("@comment_date", comment_date);
                        command.Parameters.AddWithValue("@comment_time", comment_time);
                        command.Parameters.AddWithValue("@comment_description", comment_description);
                        command.Parameters.AddWithValue("@type_of_user", current_user);
                        command.Parameters.AddWithValue("@comment_username", user_name);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e1)
            {
                System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
            }
            CommentBox.Text = "";
            Comment_Load();
        }
    }
    protected void Reassign_Click(object sender, EventArgs e)
    {   
        string reassign_description = reassign_text.Value;
        int updatedcategory_id = 0; 
        updatedcategory_id = Convert.ToInt32(ReassignCategory.SelectedValue);
        string updatemodeassign="";
        if (reassign_description.Equals("") == false && updatedcategory_id!=0)
        {
            try
            {
                if (complaint_level.Equals("university"))
                {
                    updatemodeassign = "update university_mode_assign set assign_status='Resign',university_category_id=@updatedcategory_id,reassign_description=@reassign_description,reassign_request_user=@type_of_user where university_complaint_id=@complaint_id and university_mode_email=@mode_email";                    
                }
                if (complaint_level.Equals("institute"))
                {
                    updatemodeassign = "update institute_mode_assign set assign_status='Resign',institute_category_id=@updatedcategory_id,reassign_description=@reassign_description,reassign_request_user=@type_of_user where institute_complaint_id=@complaint_id and institute_mode_email=@mode_email";
                }
                if (complaint_level.Equals("department"))
                {
                    updatemodeassign = "update department_mode_assign set assign_status='Resign',department_category_id=@updatedcategory_id,reassign_description=@reassign_description,reassign_request_user=@type_of_user where department_complaint_id=@complaint_id and department_mode_email=@mode_email";
                }
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(updatemodeassign, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@updatedcategory_id", updatedcategory_id);
                        command.Parameters.AddWithValue("@reassign_description", reassign_description);
                        command.Parameters.AddWithValue("@type_of_user", current_user);
                        command.Parameters.AddWithValue("@complaint_id", complaint_id);
                        command.Parameters.AddWithValue("@mode_email", mode_email);

                        command.ExecuteNonQuery();
                    }
                }
                reassign_text.Value = "";
                reassigndiv.Style["display"] = "none";
                reportdiv.Style["display"] = "none";
                closediv.Style["display"] = "none";
                Response.Redirect("/lbs/moderator/track_complaint.aspx");
            }
            catch (Exception e1)
            {
                System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
            }
        }
    }
    protected void Report_Click(object sender, EventArgs e)
    {
        string report_description = rep_desc.Value;
        string report_type ="";
        report_type = ReportType.SelectedValue;
        string insertreportquery = "";
        string updatemodeassign = "";
        if (report_description.Equals("") == false && report_type.Equals("Type")==false)
        {
            try
            {
                if (complaint_level.Equals("university"))
                {
                    insertreportquery = "insert into university_complaint_report (university_complaint_id,university_mode_email,type_of_report,report_description) values(@complaint_id,@mode_email,@report_type,@report_description)";
                    updatemodeassign = "update university_mode_assign set assign_status='Resign',reassign_status='Yes' where university_complaint_id=@complaint_id and university_mode_email=@mode_email";
                }
                if (complaint_level.Equals("institute"))
                {
                    insertreportquery = "insert into institute_complaint_report (institute_complaint_id,institute_mode_email,type_of_report,report_description) values(@complaint_id,@mode_email,@report_type,@report_description)";
                    updatemodeassign = "update institute_mode_assign set assign_status='Resign',reassign_status='Yes' where institute_complaint_id=@complaint_id and institute_mode_email=@mode_email";
                }
                if (complaint_level.Equals("department"))
                {
                    insertreportquery = "insert into department_complaint_report (department_complaint_id,department_mode_email,type_of_report,report_description) values(@complaint_id,@mode_email,@report_type,@report_description)";
                    updatemodeassign = "update department_mode_assign set assign_status='Resign',reassign_status='Yes' where department_complaint_id=@complaint_id and department_mode_email=@mode_email";
                }
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(insertreportquery, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@complaint_id", complaint_id);
                        command.Parameters.AddWithValue("@mode_email", mode_email);
                        command.Parameters.AddWithValue("@report_type", report_type);
                        command.Parameters.AddWithValue("@report_description", report_description);

                        command.ExecuteNonQuery();
                    }
                }

                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(updatemodeassign, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@complaint_id", complaint_id);
                        command.Parameters.AddWithValue("@mode_email", mode_email);

                        command.ExecuteNonQuery();
                    }
                }
                rep_desc.Value = "";
                reassigndiv.Style["display"] = "none";
                reportdiv.Style["display"] = "none";
                closediv.Style["display"] = "none";
                Response.Redirect("/lbs/moderator/track_complaint.aspx");
            }
            catch (Exception e1)
            {
                System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
            }
        }
    }
    protected void Close_Click(object sender, EventArgs e)
    {
        string updatecomplaint = "";
        string updatemodeassign = "";
        string modecompletevalue = "";
        string updatemodetable = "";
        int solvedcomplaint = 0;
        try
        {
            if (complaint_level.Equals("university"))
            {
                updatecomplaint = "update university_complaint set complaint_status='Closed',complaint_progress='Completed' where university_complaint_id=@complaint_id and student_email=@student_email";
                updatemodeassign = "update university_mode_assign set assign_status='Completed' where university_complaint_id=@complaint_id and university_mode_email=@mode_email";
                modecompletevalue = "select no_of_solved_complaint from university_mode where university_mode_email=@mode_email";
                updatemodetable = "update university_mode set no_of_solved_complaint=@solvedcomplaint where university_mode_email=@mode_email";
            }
            if (complaint_level.Equals("institute"))
            {
                updatecomplaint = "update institute_complaint set complaint_status='Closed',complaint_progress='Completed' where institute_complaint_id=@complaint_id and student_email=@student_email";
                updatemodeassign = "update institute_mode_assign set assign_status='Completed' where institute_complaint_id=@complaint_id and institute_mode_email=@mode_email";
                modecompletevalue = "select no_of_solved_complaint from institute_mode where institute_mode_email=@mode_email";
                updatemodetable = "update institute_mode set no_of_solved_complaint=@solvedcomplaint where institute_mode_email=@mode_email";
            }
            if (complaint_level.Equals("department"))
            {
                updatecomplaint = "update department_complaint set complaint_status='Closed',complaint_progress='Completed' where department_complaint_id=@complaint_id and student_email=@student_email";
                updatemodeassign = "update department_mode_assign set assign_status='Completed' where department_complaint_id=@complaint_id and department_mode_email=@mode_email";
                modecompletevalue = "select no_of_solved_complaint from department_mode where department_mode_email=@mode_email";
                updatemodetable = "update department_mode set no_of_solved_complaint=@solvedcomplaint where department_mode_email=@mode_email";
            }
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand(updatecomplaint, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@complaint_id", complaint_id);
                    command.Parameters.AddWithValue("@student_email", student_email);

                    command.ExecuteNonQuery();
                }
            }

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand(updatemodeassign, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@complaint_id", complaint_id);
                    command.Parameters.AddWithValue("@mode_email", mode_email);

                    command.ExecuteNonQuery();
                }
            }

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand(modecompletevalue, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@mode_email", mode_email);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                solvedcomplaint = reader.GetInt32(0);
                            }
                        }
                    }
                }
            }
            solvedcomplaint++;
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand(updatemodetable, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@solvedcomplaint", solvedcomplaint);
                    command.Parameters.AddWithValue("@mode_email", mode_email);

                    command.ExecuteNonQuery();
                }
            }
            reassigndiv.Style["display"] = "none";
            reportdiv.Style["display"] = "none";
            closediv.Style["display"] = "none";
            Response.Redirect("/lbs/moderator/track_complaint.aspx");
        }
        catch (Exception e1)
        {
            System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
        }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        ComplaintUpdatePanel1.Update();
    }
}