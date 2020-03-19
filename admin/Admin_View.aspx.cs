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
    string admin_email="",sub_email = "", mode_email = "", student_email = "", complaint_level = "";
    int complaint_id = 0;
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
                string loadcomplaintquery = "", commentquery = "";
                if (complaint_level.Equals("university"))
                {
                    loadcomplaintquery = "select * from university_complaint where (complaint_progress='Pending' or complaint_progress='Completed') and university_complaint_id in (select university_complaint_id from university_mode_assign where (assign_status='Assign' or assign_status='Completed') and university_mode_email in (select university_mode_email from university_mode where university_subadmin_email in (select university_subadmin_email from  university_subadmin where university_admin_email=@admin_email)));";
                    commentquery = "SELECT * FROM university_student_comment where university_complaint_id=@complaint_id";

                    //loadcategoryquery = "SELECT * FROM university_category";
                    //checkmode = "SELECT * FROM university_mode_assign where university_mode_email=@mode_email and university_complaint_id=@complaint_id and (assign_status='Assign' or assign_status='Completed')";
                    //checkisclosed = "SELECT * FROM university_complaint where university_complaint_id=@complaint_id and complaint_progress='Completed' and complaint_level=@complaint_level";
                    //fetchcomplaintquery = "SELECT * FROM university_complaint where university_complaint_id=@complaint_id and complaint_level=@complaint_level";
                }
                if (complaint_level.Equals("institute"))
                {
                    loadcomplaintquery = "select * from institute_complaint where (complaint_progress='Pending' or complaint_progress='Completed') and institute_complaint_id in (select institute_complaint_id from institute_mode_assign where (assign_status='Assign' or assign_status='Completed') and institute_mode_email in (select institute_mode_email from institute_mode where institute_subadmin_email in (select institute_subadmin_email from  institute_subadmin where institute_admin_email=@admin_email)));";
                    commentquery = "SELECT * FROM institute_student_comment where institute_complaint_id=@complaint_id";

                    //loadcategoryquery = "SELECT * FROM institute_category";
                    //checkmode = "SELECT * FROM institute_mode_assign where institute_mode_email=@mode_email and institute_complaint_id=@complaint_id and (assign_status='Assign' or assign_status='Completed')";
                    //checkisclosed = "SELECT * FROM institute_complaint where institute_complaint_id=@complaint_id and complaint_progress='Completed' and complaint_level=@complaint_level";
                    //fetchcomplaintquery = "SELECT * FROM institute_complaint where institute_complaint_id=@complaint_id and complaint_level=@complaint_level";
                }
                if (complaint_level.Equals("department"))
                {
                    loadcomplaintquery = "select * from department_complaint where (complaint_progress='Pending' or complaint_progress='Completed') and department_complaint_id in (select department_complaint_id from department_mode_assign where (assign_status='Assign' or assign_status='Completed') and department_mode_email in (select department_mode_email from department_mode where department_subadmin_email in (select department_subadmin_email from  department_subadmin where department_admin_email=@admin_email)));";
                    commentquery = "SELECT * FROM department_student_comment where department_complaint_id=@complaint_id";

                    //loadcategoryquery = "SELECT * FROM department_category";
                    //checkmode = "SELECT * FROM department_mode_assign where department_mode_email=@mode_email and department_complaint_id=@complaint_id and (assign_status='Assign' or assign_status='Completed')";
                    //checkisclosed = "SELECT * FROM department_complaint where department_complaint_id=@complaint_id and complaint_progress='Completed' and complaint_level=@complaint_level";
                    //fetchcomplaintquery = "SELECT * FROM department_complaint where department_complaint_id=@complaint_id and complaint_level=@complaint_level";
                }

                //Loading Complaints
                bool checkfirstcomplaint = true;
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(loadcomplaintquery, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@admin_email", admin_email);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                complaintviewtab.InnerHtml = "";
                                while (reader.Read())
                                {
                                    complaint_id = reader.GetInt32(0);
                                    student_email = reader.GetString(1);
                                    string complaint_date = reader.GetDateTime(4).ToShortDateString();
                                    string complaint_time = reader.GetString(5);
                                    complaint_time = DateTime.Parse(complaint_time, System.Globalization.CultureInfo.InvariantCulture).ToString("hh:mm tt");
                                    string complaint_title = reader.GetString(6);
                                    string complaint_description = reader.GetString(7);
                                    string complaint_status = reader.GetString(8);
                                    string complaint_progress = reader.GetString(9);
                                    if (checkfirstcomplaint == true)
                                    {
                                        complaintviewtab.InnerHtml += @"<div class='tab-pane fade show active' id='tab-complaint-" + complaint_id + "' role='tabpanel'>";
                                        checkfirstcomplaint = false;
                                    }
                                    else
                                    {
                                        complaintviewtab.InnerHtml += @"<div class='tab-pane fade' id='tab-complaint-" + complaint_id + "' role='tabpanel'>";
                                    }
                                    complaintviewtab.InnerHtml += @"<div class='row justify-content-center'>";
                                    complaintviewtab.InnerHtml += @"<div class='card' style='text-align:center; width:2000px;margin-top: 20px;' >";
                                    complaintviewtab.InnerHtml += @"<div class='card-header' style='background-color:orange;color:White; font-size:larger;'>";
                                    complaintviewtab.InnerHtml += @"<div class='row'>";
                                    complaintviewtab.InnerHtml += @"<div class='col'>";
                                    complaintviewtab.InnerHtml += @"<div class='row'>";
                                    complaintviewtab.InnerHtml += @"<div class='col col-lg-6'>ID:</div>";
                                    complaintviewtab.InnerHtml += @"<div class='col col-lg-6' style='margin-right:20px;padding-left:5px;color:Black;'>" + complaint_id + "</div>";
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
                                            command1.Parameters.AddWithValue("@complaint_id", complaint_id);

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
}