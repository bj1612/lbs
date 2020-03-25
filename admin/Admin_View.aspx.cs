using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_View : System.Web.UI.Page
{
    string connStr, current_user = "", user_name = "";
    string admin_email = "", sub_email = "", mode_email = "", student_email = "", complaint_level = "", category_name = "";
    int complaint_id = 0;
    bool checkfirstcomplaint = true;
    string loadcomplaintquery = "", commentquery = "", fetchcategoryquery = "";
    string first_name = "", last_name = "";
    int category_id = 0, academic_id=0;
    protected void Page_Load(object sender, EventArgs e)
    {
        connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        if (Session["email"] == null)
        {
            Response.Redirect(@"/lbs/index.aspx");
        }
        if (Session["email"] != null)
        {
            admin_email = Session["email"].ToString();
        }
        if (Session["typeofuser"] != null)
        {
            current_user = Session["typeofuser"].ToString();
            if (current_user.Equals("university_admin") == false)
            {
                if (current_user.Equals("institute_admin") == false)
                {
                    if (current_user.Equals("department_admin") == false)
                    {
                        Response.Redirect("/lbs/logout.aspx");
                    }
                }
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
                string loadmoderatorquery = "", loadmoderatorpendingcomplaintquery = "", loadmoderatorcompletecomplaintquery = "",loadsubadminquery="";
                if (complaint_level.Equals("university"))
                {
                    fetchcategoryquery = "SELECT * from university_category where university_category_id=@category_id";
                    loadsubadminquery = "SELECT * FROM university_subadmin where university_admin_email=@admin_email";
                    loadmoderatorquery = "SELECT * FROM university_mode where university_subadmin_email=@sub_email";
                    loadmoderatorpendingcomplaintquery = "Select * from university_complaint where complaint_progress='Pending' and university_complaint_id in (select university_complaint_id from university_mode_assign where university_mode_email=@mode_email and (assign_status='Assign' or assign_status='Completed'))";
                    loadmoderatorcompletecomplaintquery = "Select * from university_complaint where complaint_progress='Completed' and university_complaint_id in (select university_complaint_id from university_mode_assign where university_mode_email=@mode_email and (assign_status='Assign' or assign_status='Completed'))";
                    loadcomplaintquery = "select * from university_complaint where university_complaint_id=@complaint_id";
                    commentquery = "SELECT * FROM university_student_comment where university_complaint_id=@complaint_id";


                    //loadcategoryquery = "SELECT * FROM university_category";
                    //checkmode = "SELECT * FROM university_mode_assign where university_mode_email=@mode_email and university_complaint_id=@complaint_id and (assign_status='Assign' or assign_status='Completed')";
                    //checkisclosed = "SELECT * FROM university_complaint where university_complaint_id=@complaint_id and complaint_progress='Completed' and complaint_level=@complaint_level";
                    //fetchcomplaintquery = "SELECT * FROM university_complaint where university_complaint_id=@complaint_id and complaint_level=@complaint_level";
                }
                if (complaint_level.Equals("institute"))
                {
                    fetchcategoryquery = "SELECT * from institute_category where institute_category_id=@category_id";
                    loadsubadminquery = "SELECT * FROM institute_subadmin where institute_admin_email=@admin_email";
                    loadmoderatorquery = "SELECT * FROM institute_mode where institute_subadmin_email=@sub_email";
                    loadmoderatorpendingcomplaintquery = "Select * from institute_complaint where complaint_progress='Pending' and institute_complaint_id in (select institute_complaint_id from institute_mode_assign where institute_mode_email=@mode_email and (assign_status='Assign' or assign_status='Completed'))";
                    loadmoderatorcompletecomplaintquery = "Select * from institute_complaint where complaint_progress='Completed' and institute_complaint_id in (select institute_complaint_id from institute_mode_assign where institute_mode_email=@mode_email and (assign_status='Assign' or assign_status='Completed'))";
                    loadcomplaintquery = "select * from institute_complaint where institute_complaint_id=@complaint_id";
                    commentquery = "SELECT * FROM institute_student_comment where institute_complaint_id=@complaint_id";

                    //loadcategoryquery = "SELECT * FROM institute_category";
                    //checkmode = "SELECT * FROM institute_mode_assign where institute_mode_email=@mode_email and institute_complaint_id=@complaint_id and (assign_status='Assign' or assign_status='Completed')";
                    //checkisclosed = "SELECT * FROM institute_complaint where institute_complaint_id=@complaint_id and complaint_progress='Completed' and complaint_level=@complaint_level";
                    //fetchcomplaintquery = "SELECT * FROM institute_complaint where institute_complaint_id=@complaint_id and complaint_level=@complaint_level";
                }
                if (complaint_level.Equals("department"))
                {
                    fetchcategoryquery = "SELECT * from department_category where department_category_id=@category_id";
                    loadsubadminquery = "SELECT * FROM department_subadmin where department_admin_email=@admin_email";
                    loadmoderatorquery = "SELECT * FROM department_mode where department_subadmin_email=@sub_email";
                    loadmoderatorpendingcomplaintquery = "Select * from department_complaint where complaint_progress='Pending' and department_complaint_id in (select department_complaint_id from department_mode_assign where department_mode_email=@mode_email and (assign_status='Assign' or assign_status='Completed'))";
                    loadmoderatorcompletecomplaintquery = "Select * from department_complaint where complaint_progress='Completed' and department_complaint_id in (select department_complaint_id from department_mode_assign where department_mode_email=@mode_email and (assign_status='Assign' or assign_status='Completed'))";
                    loadcomplaintquery = "select * from department_complaint where department_complaint_id=@complaint_id";
                    commentquery = "SELECT * FROM department_student_comment where department_complaint_id=@complaint_id";

                    //loadcategoryquery = "SELECT * FROM department_category";
                    //checkmode = "SELECT * FROM department_mode_assign where department_mode_email=@mode_email and department_complaint_id=@complaint_id and (assign_status='Assign' or assign_status='Completed')";
                    //checkisclosed = "SELECT * FROM department_complaint where department_complaint_id=@complaint_id and complaint_progress='Completed' and complaint_level=@complaint_level";
                    //fetchcomplaintquery = "SELECT * FROM department_complaint where department_complaint_id=@complaint_id and complaint_level=@complaint_level";
                }

                bool checkmodefirstcomplaint = true;
                bool checkfirstsubadmin = true;
                bool checkfirstsubadminmode = true;
                bool checkfirstmode = true;
                bool checkpendingfirst = true;
                subadminlist.InnerHtml = "";
                moderatortabContent.InnerHtml = "";
                complainttabContent.InnerHtml = "";
                complaintviewtab.InnerHtml = "";
                subadminlist.InnerHtml += @"<a class='list-group-item list-group-item-action' disabled style='background-color: #000066;color: white;'>Sub Admin</a>";
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(loadsubadminquery, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@admin_email", admin_email);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    first_name = reader.GetString(0);
                                    last_name = reader.GetString(1);
                                    sub_email = reader.GetString(2);
                                    string subemail = sub_email;
                                    subemail = new string((from c in subemail
                                                      where char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)
                                                      select c
                                           ).ToArray());
                                    if (checkfirstsubadmin == true)
                                    {
                                        subadminlist.InnerHtml += @"<a class='list-group-item list-group-item-action active' onclick='childActive();' id='" + subemail + "' data-toggle='list' href='#tab-subadmin-" + subemail + "' role='tab' aria-controls='tab-subadmin-" + subemail + "'>" + first_name + " " + last_name + "</a>";
                                        checkfirstsubadmin = false;
                                    }
                                    else
                                    {
                                        subadminlist.InnerHtml += @"<a class='list-group-item list-group-item-action' onclick='childActive();' id='" + subemail + "' data-toggle='list' href='#tab-subadmin-" + subemail + "' role='tab' aria-controls='tab-subadmin-" + subemail + "'>" + first_name + " " + last_name + "</a>";
                                    }
                                    if (checkfirstsubadminmode == true)
                                    {
                                        moderatortabContent.InnerHtml += @"<div class='tab-pane fade show active' id='tab-subadmin-" + subemail + "' role='tabpanel' aria-labelledby='" + subemail + "'>";
                                        checkfirstsubadminmode = false;
                                    }
                                    else
                                    {
                                        moderatortabContent.InnerHtml += @"<div class='tab-pane fade' id='tab-subadmin-" + subemail + "' role='tabpanel' aria-labelledby='" + subemail + "'>";
                                    }
                                            moderatortabContent.InnerHtml += @"<div class='list-group' id='"+subemail+"-moderator-list' role='tablist'>";
                                                moderatortabContent.InnerHtml += @"<a class='list-group-item list-group-item-action' disabled style='background-color: #000066;color: white;'>Moderator</a>";
                                                using (SqlConnection connection1 = new SqlConnection(connStr))
                                                {
                                                    using (SqlCommand command1 = new SqlCommand(loadmoderatorquery, connection1))
                                                    {
                                                        connection1.Open();
                                                        command1.Parameters.AddWithValue("@sub_email", sub_email);

                                                        using (SqlDataReader reader1 = command1.ExecuteReader())
                                                        {
                                                            if (reader1.HasRows)
                                                            {
                                                                while (reader1.Read())
                                                                {
                                                                    first_name = reader1.GetString(0);
                                                                    last_name = reader1.GetString(1);
                                                                    mode_email = reader1.GetString(2);
                                                                    string modeemail = mode_email;
                                                                    modeemail = new string((from c in modeemail
                                                                                            where char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)
                                                                                            select c
                                                                           ).ToArray());
                                                                    if (checkfirstmode == true)
                                                                    {
                                                                        moderatortabContent.InnerHtml += "<a class='list-group-item list-group-item-action custom-moderator-list-check remove-active-moderator' onClick='modeclick(\"" + mode_email + "\");removeActiveModerator(this.id);' id='" + modeemail + "' data-toggle='list' href='#tab-moderator-" + modeemail + "' role='tab' aria-controls='tab-moderator-" + modeemail + "'>" + first_name + " " + last_name + "</a>";
                                                                        checkfirstmode = false;
                                                                    }
                                                                    else
                                                                    {
                                                                        moderatortabContent.InnerHtml += "<a class='list-group-item list-group-item-action custom-moderator-list-check remove-active-moderator' onClick='modeclick(\"" + mode_email + "\");removeActiveModerator(this.id);' id='" + modeemail + "' data-toggle='list' href='#tab-moderator-" + modeemail + "' role='tab' aria-controls='tab-moderator-" + modeemail + "'>" + first_name + " " + last_name + "</a>";
                                                                    }
                                                                    if (checkmodefirstcomplaint == true)
                                                                    {
                                                                        complainttabContent.InnerHtml += @"<div class='tab-pane fade remove-moderator-tab' id='tab-moderator-" + modeemail + "' role='tabpanel' aria-labelledby='" + modeemail + "'>";
                                                                        checkmodefirstcomplaint = false;
                                                                    }
                                                                    else
                                                                    {
                                                                        complainttabContent.InnerHtml += @"<div class='tab-pane fade remove-moderator-tab' id='tab-moderator-" + modeemail + "' role='tabpanel' aria-labelledby='" + modeemail + "'>";
                                                                    }
                                                                    complainttabContent.InnerHtml += @"<div class='row'>";
                                                                    complainttabContent.InnerHtml += @"<div class='col-sm-12 col-md-6 col-lg-12'>";
                                                                    complainttabContent.InnerHtml += @"<div class='list-group' id='" + modeemail + "-pending-list' role='tablist'>";
                                                                    complainttabContent.InnerHtml += @"<a class='list-group-item list-group-item-action' disabled style=' background-color: #000066;color: white;'>Pending Complaints</a>";

                                                                    using (SqlConnection connection2 = new SqlConnection(connStr))
                                                                    {
                                                                        using (SqlCommand command2 = new SqlCommand(loadmoderatorpendingcomplaintquery, connection2))
                                                                        {
                                                                            connection2.Open();
                                                                            command2.Parameters.AddWithValue("@mode_email", mode_email);

                                                                            using (SqlDataReader reader2 = command2.ExecuteReader())
                                                                            {
                                                                                if (reader2.HasRows)
                                                                                {
                                                                                    while (reader2.Read())
                                                                                    {
                                                                                        complaint_id = reader2.GetInt32(0);
                                                                                        if (checkpendingfirst == true)
                                                                                        {
                                                                                            complainttabContent.InnerHtml += @"<a class='list-group-item list-group-item-action custom-list-check moderator-change' id='" + modeemail + "-" + complaint_id + "' onClick='removeActive(this.id);' data-toggle='list' href='#tab-complaint-" + complaint_id + "' role='tab' aria-controls='tab-complaint-" + complaint_id + "'>" + complaint_id + "</a>";
                                                                                            LoadComplaint(complaint_id, modeemail);
                                                                                            checkpendingfirst = false;
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            complainttabContent.InnerHtml += @"<a class='list-group-item list-group-item-action custom-list-check moderator-change' id='" + modeemail + "-" + complaint_id + "' onClick='removeActive(this.id);' data-toggle='list' href='#tab-complaint-" + complaint_id + "' role='tab' aria-controls='tab-complaint-" + complaint_id + "'>" + complaint_id + "</a>";
                                                                                            LoadComplaint(complaint_id, modeemail);
                                                                                        }
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    complainttabContent.InnerHtml += @"<a class='list-group-item list-group-item-action custom-list-check' disabled>No Pending Complaints</a>";
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                    complainttabContent.InnerHtml += @"</div>";
                                                                    complainttabContent.InnerHtml += @"</div>";
                                                                    complainttabContent.InnerHtml += @"<div class='col-sm-12 col-md-6 col-lg-12'>";
                                                                    complainttabContent.InnerHtml += @"<div class='list-group' id='" + mode_email + "-complete-list' role='tablist'>";
                                                                    complainttabContent.InnerHtml += @"<a class='list-group-item list-group-item-action' disabled style='background-color: #000066;color: white;'>Solved Complaints</a>";

                                                                    using (SqlConnection connection2 = new SqlConnection(connStr))
                                                                    {
                                                                        using (SqlCommand command2 = new SqlCommand(loadmoderatorcompletecomplaintquery, connection2))
                                                                        {
                                                                            connection2.Open();
                                                                            command2.Parameters.AddWithValue("@mode_email", mode_email);

                                                                            using (SqlDataReader reader2 = command2.ExecuteReader())
                                                                            {
                                                                                if (reader2.HasRows)
                                                                                {
                                                                                    while (reader2.Read())
                                                                                    {
                                                                                        complaint_id = reader2.GetInt32(0);
                                                                                        if (checkpendingfirst == true)
                                                                                        {
                                                                                            complainttabContent.InnerHtml += @"<a class='list-group-item list-group-item-action custom-list-check moderator-change' id='" + modeemail + "-" + complaint_id + "' onClick='removeActive(this.id);' data-toggle='list' href='#tab-complaint-" + complaint_id + "' role='tab' aria-controls='tab-complaint-" + complaint_id + "'>" + complaint_id + "</a>";
                                                                                            LoadComplaint(complaint_id, modeemail);
                                                                                            checkpendingfirst = false;
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            complainttabContent.InnerHtml += @"<a class='list-group-item list-group-item-action custom-list-check moderator-change' id='" + modeemail + "-" + complaint_id + "' onClick='removeActive(this.id);' data-toggle='list' href='#tab-complaint-" + complaint_id + "' role='tab' aria-controls='tab-complaint-" + complaint_id + "'>" + complaint_id + "</a>";
                                                                                            LoadComplaint(complaint_id, modeemail);
                                                                                        }
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    complainttabContent.InnerHtml += @"<a class='list-group-item list-group-item-action custom-list-check' disabled>No Completed Complaints</a>";
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
                                                                moderatortabContent.InnerHtml += @"<a class='list-group-item list-group-item-action' disabled style=' background-color: #000066;color: white;'>No Moderator Assigned</a>";
                                                            }
                                                        }
                                                    }
                                                }
                                        moderatortabContent.InnerHtml += @"</div>";
                                    moderatortabContent.InnerHtml += @"</div>";
                                }
                            }
                            else
                            {
                                subadminlist.InnerHtml += @"<a class='list-group-item list-group-item-action' disabled>No SubAdmin Assigned</a>";
                            }
                        }
                    }
                }
            }
            else
            {
                Response.Redirect(@"/lbs/admin/Admin_View.aspx");
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
                                LoadAcademic();
                                complaintviewtab.InnerHtml += @"<div class='card' style='text-align:center; width:2000px;margin-top: 20px;' >";
                                complaintviewtab.InnerHtml += @"<div class='card-header' style='background-color:orange;color:White; font-size:x-large;'><span><a href='/lbs/viewProfile.aspx?ID=" + student_email + "&Data=" + academic_id + "' style='text-decoration:none;color:white;' target='blank' title='View Student Profile'>" + complaint_title + "</a></span></div>";
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
                                                        complaintviewtab.InnerHtml += @"<a href='/lbs/moderator/viewModeratorProfile.aspx?ID=" + mode_email + "' style='font-weight: bold;text-decoration:none;color:black;' target='blank'>" + comment_username + "</a>";//Moderator Name
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
                                                        complaintviewtab.InnerHtml += @"<a href='/lbs/viewProfile.aspx?ID=" + student_email + "&Data=" + academic_id + "' style='font-weight: bold;text-decoration:none;color:black;' target='blank'>" + comment_username + "</a>";// Student Name
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
    protected void LoadAcademic()
    {
        string fetchstudentinfoquery1 = "select student_academic_detail_id from student_academic_detail where status='Active' and student_email=@student_email";
        using (SqlConnection connection = new SqlConnection(connStr))
        {
            using (SqlCommand command = new SqlCommand(fetchstudentinfoquery1, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@student_email", student_email);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            academic_id = reader.GetInt32(0);
                        }
                    }
                }
            }
        }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        AdminViewUpdatePanel1.Update();
    }
}