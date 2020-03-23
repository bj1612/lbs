using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class SubAdmin_View : System.Web.UI.Page
{
    string connStr, current_user = "", user_name = "";
    string sub_email = "", mode_email = "", student_email = "", complaint_level = "", category_name = "";
    int complaint_id = 0;
    string loadcomplaintquery = "", commentquery = "", fetchcategoryquery="";
    bool checkfirstcomplaint = true;
    int category_id = 0;
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
        try
        {
            if (current_user.Contains("university"))
            {
                complaint_level = "university";
            }
            if (current_user.Contains("institute"))
            {
                complaint_level = "institute";
            }
            if (current_user.Contains("department"))
            {
                complaint_level = "department";
            }
            if (complaint_level.Equals("") == false)
            {
                string loadmoderatorquery = "", loadmoderatorpendingcomplaintquery = "", loadmoderatorcompletecomplaintquery = "";
                if (complaint_level.Equals("university"))
                {
                    fetchcategoryquery = "SELECT * from university_category where university_category_id=@category_id";
                    loadmoderatorquery = "SELECT * FROM university_mode where university_subadmin_email=@sub_email";
                    loadmoderatorpendingcomplaintquery = "Select * from university_complaint where complaint_progress='Pending' and university_complaint_id in (select university_complaint_id from university_mode_assign where university_mode_email=@mode_email and (assign_status='Assign' or assign_status='Completed'))";
                    loadmoderatorcompletecomplaintquery = "Select * from university_complaint where complaint_progress='Completed' and university_complaint_id in (select university_complaint_id from university_mode_assign where university_mode_email=@mode_email and (assign_status='Assign' or assign_status='Completed'))";
                    loadcomplaintquery = "select * from university_complaint where university_complaint_id=@complaint_id";
                    commentquery = "SELECT * FROM university_student_comment where university_complaint_id=@complaint_id";
                }
                if (complaint_level.Equals("institute"))
                {
                    fetchcategoryquery = "SELECT * from institute_category where institute_category_id=@category_id";
                    loadmoderatorquery = "SELECT * FROM institute_mode where institute_subadmin_email=@sub_email";
                    loadmoderatorpendingcomplaintquery = "Select * from institute_complaint where complaint_progress='Pending' and institute_complaint_id in (select institute_complaint_id from institute_mode_assign where institute_mode_email=@mode_email and (assign_status='Assign' or assign_status='Completed'))";
                    loadmoderatorcompletecomplaintquery = "Select * from institute_complaint where complaint_progress='Completed' and institute_complaint_id in (select institute_complaint_id from institute_mode_assign where institute_mode_email=@mode_email and (assign_status='Assign' or assign_status='Completed'))";
                    loadcomplaintquery = "select * from institute_complaint where institute_complaint_id=@complaint_id";
                    commentquery = "SELECT * FROM institute_student_comment where institute_complaint_id=@complaint_id";
                }
                if (complaint_level.Equals("department"))
                {
                    fetchcategoryquery = "SELECT * from department_category where department_category_id=@category_id";
                    loadmoderatorquery = "SELECT * FROM department_mode where department_subadmin_email=@sub_email";
                    loadmoderatorpendingcomplaintquery = "Select * from department_complaint where complaint_progress='Pending' and department_complaint_id in (select department_complaint_id from department_mode_assign where department_mode_email=@mode_email and (assign_status='Assign' or assign_status='Completed'))";
                    loadmoderatorcompletecomplaintquery = "Select * from department_complaint where complaint_progress='Completed' and department_complaint_id in (select department_complaint_id from department_mode_assign where department_mode_email=@mode_email and (assign_status='Assign' or assign_status='Completed'))";
                    loadcomplaintquery = "select * from department_complaint where department_complaint_id=@complaint_id";
                    commentquery = "SELECT * FROM department_student_comment where department_complaint_id=@complaint_id";
                }
                
                //Loading Moderators
                bool checkmodefirstcomplaint = true;
                bool checkfirstmode = true;
                bool checkpendingfirst = true;
                moderatorlist.InnerHtml = "";
                complainttabContent.InnerHtml = "";
                complaintviewtab.InnerHtml = "";
                moderatorlist.InnerHtml += @"<a class='list-group-item list-group-item-action' disabled style='background-color: #000066;color: white;'>Moderator</a>";
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(loadmoderatorquery, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@sub_email", sub_email);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    string first_name = reader.GetString(0);
                                    string last_name = reader.GetString(1);
                                    mode_email = reader.GetString(2);
                                    string modeemail = mode_email;
                                    modeemail = new string((from c in modeemail
                                                            where char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)
                                                            select c
                                           ).ToArray());
                                    if (checkfirstmode == true)
                                    {
                                        moderatorlist.InnerHtml += "<a class='list-group-item list-group-item-action active' id='" + modeemail + "' onclick='childActive();' data-toggle='list' href='#tab-moderator-" + modeemail + "' role='tab' aria-controls='tab-moderator-" + modeemail + "'>" + first_name + " " + last_name + "</a>";
                                        checkfirstmode = false;
                                    }
                                    else
                                    {
                                        moderatorlist.InnerHtml += "<a class='list-group-item list-group-item-action' id='" + modeemail + "' onclick='childActive();' data-toggle='list' href='#tab-moderator-" + modeemail + "' role='tab' aria-controls='tab-moderator-" + modeemail + "'>" + first_name + " " + last_name + "</a>";
                                    }
                                    if (checkmodefirstcomplaint == true)
                                    {
                                        complainttabContent.InnerHtml += @"<div class='tab-pane show active fade' id='tab-moderator-" + modeemail + "' role='tabpanel' aria-labelledby='" + modeemail + "'>";
                                        checkmodefirstcomplaint = false;
                                    }
                                    else
                                    {
                                        complainttabContent.InnerHtml += @"<div class='tab-pane fade' id='tab-moderator-" + modeemail + "' role='tabpanel' aria-labelledby='" + modeemail + "'>";
                                    }
                                    complainttabContent.InnerHtml += @"<div class='row'>";
                                    complainttabContent.InnerHtml += @"<div class='col-sm-12 col-md-6 col-lg-12'>";
                                    complainttabContent.InnerHtml += @"<div class='list-group' id='" + modeemail + "-pending-list' role='tablist'>";
                                    complainttabContent.InnerHtml += @"<a class='list-group-item list-group-item-action' disabled style=' background-color: #000066;color: white;'>Pending Complaints</a>";

                                    using (SqlConnection connection1 = new SqlConnection(connStr))
                                    {
                                        using (SqlCommand command1 = new SqlCommand(loadmoderatorpendingcomplaintquery, connection1))
                                        {
                                            connection1.Open();
                                            command1.Parameters.AddWithValue("@mode_email", mode_email);

                                            using (SqlDataReader reader1 = command1.ExecuteReader())
                                            {
                                                if (reader1.HasRows)
                                                {
                                                    while (reader1.Read())
                                                    {
                                                        complaint_id = reader1.GetInt32(0);
                                                        if (checkpendingfirst == true)
                                                        {
                                                            complainttabContent.InnerHtml += @"<a class='list-group-item list-group-item-action remove-complaint-active moderator-change' id='" + modeemail + "-" + complaint_id + "' onClick='removeActive(this.id);' data-toggle='list' href='#tab-complaint-" + complaint_id + "' role='tab' aria-controls='tab-complaint-" + complaint_id + "'>" + complaint_id + "</a>";
                                                            LoadComplaint(complaint_id, modeemail);
                                                            checkpendingfirst = false;
                                                        }
                                                        else
                                                        {
                                                            complainttabContent.InnerHtml += @"<a class='list-group-item list-group-item-action remove-complaint-active moderator-change' id='" + modeemail + "-" + complaint_id + "' onClick='removeActive(this.id);' data-toggle='list' href='#tab-complaint-" + complaint_id + "' role='tab' aria-controls='tab-complaint-" + complaint_id + "'>" + complaint_id + "</a>";
                                                            LoadComplaint(complaint_id, modeemail);
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    complainttabContent.InnerHtml += @"<a class='list-group-item list-group-item-action remove-complaint-active' disabled>No Pending Complaints</a>";
                                                }
                                            }
                                        }
                                    }
                                    complainttabContent.InnerHtml += @"</div>";
                                    complainttabContent.InnerHtml += @"</div>";
                                    complainttabContent.InnerHtml += @"<div class='col-sm-12 col-md-6 col-lg-12'>";
                                    complainttabContent.InnerHtml += @"<div class='list-group' id='" + mode_email + "-complete-list' role='tablist'>";
                                    complainttabContent.InnerHtml += @"<a class='list-group-item list-group-item-action' disabled style='background-color: #000066;color: white;'>Solved Complaints</a>";

                                    using (SqlConnection connection1 = new SqlConnection(connStr))
                                    {
                                        using (SqlCommand command1 = new SqlCommand(loadmoderatorcompletecomplaintquery, connection1))
                                        {
                                            connection1.Open();
                                            command1.Parameters.AddWithValue("@mode_email", mode_email);

                                            using (SqlDataReader reader1 = command1.ExecuteReader())
                                            {
                                                if (reader1.HasRows)
                                                {
                                                    while (reader1.Read())
                                                    {
                                                        complaint_id = reader1.GetInt32(0);
                                                        if (checkpendingfirst == true)
                                                        {
                                                            complainttabContent.InnerHtml += @"<a class='list-group-item list-group-item-action remove-complaint-active moderator-change' id='" + modeemail + "-" + complaint_id + "' onClick='removeActive(this.id);' data-toggle='list' href='#tab-complaint-" + complaint_id + "' role='tab' aria-controls='tab-complaint-" + complaint_id + "'>" + complaint_id + "</a>";
                                                            LoadComplaint(complaint_id, modeemail);
                                                            checkpendingfirst = false;
                                                        }
                                                        else
                                                        {
                                                            complainttabContent.InnerHtml += @"<a class='list-group-item list-group-item-action remove-complaint-active moderator-change' id='" + modeemail + "-" + complaint_id + "' onClick='removeActive(this.id);' data-toggle='list' href='#tab-complaint-" + complaint_id + "' role='tab' aria-controls='tab-complaint-" + complaint_id + "'>" + complaint_id + "</a>";
                                                            LoadComplaint(complaint_id, modeemail);
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    complainttabContent.InnerHtml += @"<a class='list-group-item list-group-item-action remove-complaint-active' disabled>No Completed Complaints</a>";
                                                }
                                            }
                                        }
                                    }
                                    complainttabContent.InnerHtml += @"</div>";
                                    complainttabContent.InnerHtml += @"</div>";
                                    complainttabContent.InnerHtml += @"</div>";
                                    complainttabContent.InnerHtml += @"</div>";
                                }
                            }
                            else
                            {
                                moderatorlist.InnerHtml += @"<a class='list-group-item list-group-item-action remove-complaint-active' disabled>No Moderator Assigned</a>";
                            }
                        }
                    }
                }
            }
            else
            {
                Response.Redirect(@"/lbs/subAdmin/subadmin_index.aspx");
            }

        }
        catch (Exception e1)
        {
            System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
        }
    }
    protected void LoadComplaint(int complaint_idd,string mode_emaill)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand(loadcomplaintquery, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@complaint_id", complaint_idd);

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
                                if (checkfirstcomplaint == true)
                                {
                                    complaintviewtab.InnerHtml += @"<div class='tab-pane fade remove-complaint-list' id='tab-complaint-" + complaint_idd + "' role='tabpanel' aria-labelledby='" + mode_emaill + "-" + complaint_idd + "'>";
                                    checkfirstcomplaint = false;
                                }
                                else
                                {
                                    complaintviewtab.InnerHtml += @"<div class='tab-pane fade remove-complaint-list' id='tab-complaint-" + complaint_idd + "' role='tabpanel' aria-labelledby='" + mode_emaill + "-" + complaint_idd + "'>";
                                }
                                complaintviewtab.InnerHtml += @"<div class='row justify-content-center'>";
                                complaintviewtab.InnerHtml += @"<div class='card' style='text-align:center; width:2000px;' >";
                                complaintviewtab.InnerHtml += @"<div class='card-header' style='background-color:orange;color:White; font-size:larger;'>";
                                complaintviewtab.InnerHtml += @"<div class='row'>";
                                complaintviewtab.InnerHtml += @"<div class='col'>";
                                complaintviewtab.InnerHtml += @"<div class='row'>";
                                complaintviewtab.InnerHtml += @"<div class='col col-lg-6'>ID:</div>";
                                complaintviewtab.InnerHtml += @"<div class='col col-lg-6' style='margin-right:20px;padding-left:5px;color:Black;'>" + complaint_idd + "</div>";
                                complaintviewtab.InnerHtml += @"</div>";
                                complaintviewtab.InnerHtml += @"</div>";
                                complaintviewtab.InnerHtml += @"<div class='col'>";
                                complaintviewtab.InnerHtml += @"<div class='col'>Date:</div>";
                                complaintviewtab.InnerHtml += @"<div class='col' style='margin-right:20px;padding-left:5px;color:Black;'>" + complaint_date + "</div>";
                                complaintviewtab.InnerHtml += @"</div>";
                                complaintviewtab.InnerHtml += @"<div class='col'>";
                                complaintviewtab.InnerHtml += @"<div class='col'>Time:</div>";
                                complaintviewtab.InnerHtml += @"<div class='col' style='margin-right:20px;padding-left:5px;color:Black;'>" + complaint_time + "</div>";
                                complaintviewtab.InnerHtml += @"</div>";
                                complaintviewtab.InnerHtml += @"<div class='col'>";
                                complaintviewtab.InnerHtml += @"<div class='col'>Progress:</div>";
                                complaintviewtab.InnerHtml += @"<div class='col' style='margin-right:20px;padding-left:5px;color:Black;'>" + complaint_progress + "</div>";
                                complaintviewtab.InnerHtml += @"</div>";
                                complaintviewtab.InnerHtml += @"<div class='col'>";
                                complaintviewtab.InnerHtml += @"<div class='col'>Status:</div>";
                                complaintviewtab.InnerHtml += @"<div class='col' style='margin-right:20px;padding-left:5px;color:Black;'>" + complaint_status + "</div>";
                                complaintviewtab.InnerHtml += @"</div>";
                                LoadCategoryName();
                                complaintviewtab.InnerHtml += @"<div class='col'>";
                                complaintviewtab.InnerHtml += @"<div class='col'>Category:</div>";
                                complaintviewtab.InnerHtml += @"<div class='col' style='margin-right:20px;padding-left:5px;color:Black;'>" + category_name + "</div>";
                                complaintviewtab.InnerHtml += @"</div>";
                                complaintviewtab.InnerHtml += @"</div>";
                                complaintviewtab.InnerHtml += @"</div>";
                                complaintviewtab.InnerHtml += @"</div>";
                                complaintviewtab.InnerHtml += @"<div class='card' style='text-align:center; width:2000px;margin-top: 20px;' >";
                                complaintviewtab.InnerHtml += @"<div class='card-header' style='background-color:orange;color:White; font-size:x-large;'><span>" + complaint_title + "</span></div>";
                                complaintviewtab.InnerHtml += @"<div class='card-body'>";
                                complaintviewtab.InnerHtml += @"<blockquote class='blockquote mb-0'>";
                                complaintviewtab.InnerHtml += @"<p class='text-info'>" + complaint_description + "</p>";
                                complaintviewtab.InnerHtml += @"</blockquote>";
                                complaintviewtab.InnerHtml += @"</div>";
                                complaintviewtab.InnerHtml += @"</div>";
                                complaintviewtab.InnerHtml += @"<div class='mesgs'>";
                                complaintviewtab.InnerHtml += @"<div class='msg_history'>";
                                complaintviewtab.InnerHtml += @"<div class='row'>";
                                using (SqlConnection connection1 = new SqlConnection(connStr))
                                {
                                    using (SqlCommand command1 = new SqlCommand(commentquery, connection1))
                                    {
                                        connection1.Open();
                                        command1.Parameters.AddWithValue("@complaint_id", complaint_idd);

                                        using (SqlDataReader reader1 = command1.ExecuteReader())
                                        {
                                            if (reader1.HasRows)
                                            {
                                                while (reader1.Read())
                                                {
                                                    string comment_date = reader1.GetDateTime(4).ToString("dd MMMM yyyy");
                                                    string comment_time = reader1.GetString(5);
                                                    comment_time = DateTime.Parse(comment_time, System.Globalization.CultureInfo.InvariantCulture).ToString("hh:mm tt");
                                                    string comment_description = reader1.GetString(6);
                                                    string type_of_user = reader1.GetString(7);
                                                    string comment_username = reader1.GetString(8);
                                                    if (type_of_user.Equals("university_moderator") || type_of_user.Equals("institute_moderator") || type_of_user.Equals("department_moderator"))
                                                    {
                                                        complaintviewtab.InnerHtml += @"<div class='col-sm-1 col-md-2 col-lg-2'>";
                                                        complaintviewtab.InnerHtml += @"</div>";
                                                        complaintviewtab.InnerHtml += @"<div class='outgoing_msg col-sm-11 col-md-10 col-lg-10'>";
                                                        complaintviewtab.InnerHtml += @"<div class='sent_msg'>";
                                                        complaintviewtab.InnerHtml += @"<div>";
                                                        complaintviewtab.InnerHtml += @"<div style='padding-left:10px;margin-bottom:5px;'>";
                                                        complaintviewtab.InnerHtml += comment_username;//Moderator Name
                                                        complaintviewtab.InnerHtml += @"</div>";
                                                        complaintviewtab.InnerHtml += @"</div>";
                                                        complaintviewtab.InnerHtml += @"<p>" + comment_description + "</p>";
                                                        complaintviewtab.InnerHtml += @"<span class='time_date'> " + comment_time + "    |    " + comment_date + "</span>";
                                                        complaintviewtab.InnerHtml += @"</div>";
                                                        complaintviewtab.InnerHtml += @"</div>";
                                                    }
                                                    if (type_of_user.Equals("student"))
                                                    {
                                                        complaintviewtab.InnerHtml += @"<div class='incoming_msg col-sm-11 col-md-10 col-lg-10'>";
                                                        complaintviewtab.InnerHtml += @"<div class='incoming_msg_img'>";
                                                        complaintviewtab.InnerHtml += @"<div style='width:300px;'>";
                                                        complaintviewtab.InnerHtml += @"<img src='/lbs/img/user-profile.png' alt='user-image' style='float:left;width:33px;margin-right:10px;'/>";
                                                        complaintviewtab.InnerHtml += @"<div style='padding-left:10px;padding-top:5px;'>";
                                                        complaintviewtab.InnerHtml += comment_username;// Student Name
                                                        complaintviewtab.InnerHtml += @"</div>";
                                                        complaintviewtab.InnerHtml += @"</div>";
                                                        complaintviewtab.InnerHtml += @"</div>";
                                                        complaintviewtab.InnerHtml += @"<div class='received_msg'>";
                                                        complaintviewtab.InnerHtml += @"<div class='received_withd_msg'>";
                                                        complaintviewtab.InnerHtml += @"<p>" + comment_description + "</p>";
                                                        complaintviewtab.InnerHtml += @"<span class='time_date'> " + comment_time + "    |    " + comment_date + "</span>";
                                                        complaintviewtab.InnerHtml += @"</div>";
                                                        complaintviewtab.InnerHtml += @"</div>";
                                                        complaintviewtab.InnerHtml += @"</div>";
                                                        complaintviewtab.InnerHtml += @"<div class='col-sm-1 col-md-2 col-lg-2'>";
                                                        complaintviewtab.InnerHtml += @"</div>";
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                complaintviewtab.InnerHtml += @"</div>";
                                complaintviewtab.InnerHtml += @"</div>";
                                complaintviewtab.InnerHtml += @"</div>";
                                complaintviewtab.InnerHtml += @"</div>";
                                complaintviewtab.InnerHtml += @"</div>";
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
    protected void LoadCategoryName()
    {
        try
        {
            using (SqlConnection catconnection = new SqlConnection(connStr))
            {
                using (SqlCommand catcommand = new SqlCommand(fetchcategoryquery, catconnection))
                {
                    catconnection.Open();
                    catcommand.Parameters.AddWithValue("@category_id", category_id);

                    using (SqlDataReader catreader = catcommand.ExecuteReader())
                    {
                        if (catreader.HasRows)
                        {
                            while (catreader.Read())
                            {
                                category_name = catreader.GetString(1);
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
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        SubAdminViewUpdatePanel1.Update();
    }
}