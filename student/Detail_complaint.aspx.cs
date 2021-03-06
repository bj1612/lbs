﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Detail_complaint : System.Web.UI.Page
{
    string connStr,current_user="",user_name="";
    string student_email = "", complaint_level = "", category_name="";
    int complaint_id = 0;
    int category_id = 0;
    int academic_id = 0;
    protected void Comment_Load() 
    {
        try
        {
            if (complaint_level.Equals("university"))
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand("SELECT * FROM university_student_comment where university_complaint_id=@complaint_id", connection))
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
                                    if (type_of_user.Equals("university_moderator"))
                                    {
                                        messageboxdiv.InnerHtml += @"<div class='incoming_msg col-sm-11 col-md-10 col-lg-10'>";
                                        messageboxdiv.InnerHtml += @"<div class='incoming_msg_img'>";
                                        messageboxdiv.InnerHtml += @"<div style='width:300px;'>";
                                        messageboxdiv.InnerHtml += @"<img src='/lbs/img/user-profile.png' alt='user-image' style='float:left;width:33px;margin-right:10px;'/>";
                                        messageboxdiv.InnerHtml += @"<div style='padding-left:10px;padding-top:5px;font-weight: bold;text-decoration:none;color:black;'>";
                                        messageboxdiv.InnerHtml += "Support Team";// Moderator Name
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
                                    if (type_of_user.Equals("student"))
                                    {
                                        messageboxdiv.InnerHtml += @"<div class='col-sm-1 col-md-2 col-lg-2'>";
                                        messageboxdiv.InnerHtml += @"</div>";
                                        messageboxdiv.InnerHtml += @"<div class='outgoing_msg col-sm-11 col-md-10 col-lg-10'>";
                                        messageboxdiv.InnerHtml += @"<div class='sent_msg'>";
                                        messageboxdiv.InnerHtml += @"<div>";
                                        messageboxdiv.InnerHtml += @"<div style='padding-left:10px;margin-bottom:5px;'>";
                                        messageboxdiv.InnerHtml += @"<a href='/lbs/viewProfile.aspx?ID=" + student_email + "' style='font-weight: bold;text-decoration:none;color:black;'>" + comment_username + "</a>";//Student Name
                                        messageboxdiv.InnerHtml += @"</div>";
                                        messageboxdiv.InnerHtml += @"</div>";
                                        messageboxdiv.InnerHtml += @"<p>" + comment_description + "</p>";
                                        messageboxdiv.InnerHtml += @"<span class='time_date'> " + comment_time + "    |    " + comment_date + "</span>";
                                        messageboxdiv.InnerHtml += @"</div>";
                                        messageboxdiv.InnerHtml += @"</div>";
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (complaint_level.Equals("institute"))
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand("SELECT * FROM institute_student_comment where institute_complaint_id=@complaint_id", connection))
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
                                    if (type_of_user.Equals("institute_moderator"))
                                    {
                                        messageboxdiv.InnerHtml += @"<div class='incoming_msg col-sm-11 col-md-10 col-lg-10'>";
                                        messageboxdiv.InnerHtml += @"<div class='incoming_msg_img'>";
                                        messageboxdiv.InnerHtml += @"<div style='width:300px;'>";
                                        messageboxdiv.InnerHtml += @"<img src='/lbs/img/user-profile.png' alt='user-image' style='float:left;width:33px;margin-right:10px;'/>";
                                        messageboxdiv.InnerHtml += @"<div style='padding-left:10px;padding-top:5px;font-weight: bold;text-decoration:none;color:black;'>";
                                        messageboxdiv.InnerHtml += "Support Team";// Moderator Name
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
                                    if (type_of_user.Equals("student"))
                                    {
                                        messageboxdiv.InnerHtml += @"<div class='col-sm-1 col-md-2 col-lg-2'>";
                                        messageboxdiv.InnerHtml += @"</div>";
                                        messageboxdiv.InnerHtml += @"<div class='outgoing_msg col-sm-11 col-md-10 col-lg-10'>";
                                        messageboxdiv.InnerHtml += @"<div class='sent_msg'>";
                                        messageboxdiv.InnerHtml += @"<div>";
                                        messageboxdiv.InnerHtml += @"<div style='padding-left:10px;margin-bottom:5px;'>";
                                        messageboxdiv.InnerHtml += @"<a href='/lbs/viewProfile.aspx?ID=" + student_email + "' style='font-weight: bold;text-decoration:none;color:black;'>" + comment_username + "</a>";//Student Name
                                        messageboxdiv.InnerHtml += @"</div>";
                                        messageboxdiv.InnerHtml += @"</div>";
                                        messageboxdiv.InnerHtml += @"<p>" + comment_description + "</p>";
                                        messageboxdiv.InnerHtml += @"<span class='time_date'> " + comment_time + "    |    " + comment_date + "</span>";
                                        messageboxdiv.InnerHtml += @"</div>";
                                        messageboxdiv.InnerHtml += @"</div>";
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (complaint_level.Equals("department"))
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand("SELECT * FROM department_student_comment where department_complaint_id=@complaint_id", connection))
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
                                    if (type_of_user.Equals("department_moderator"))
                                    {
                                        messageboxdiv.InnerHtml += @"<div class='incoming_msg col-sm-11 col-md-10 col-lg-10'>";
                                        messageboxdiv.InnerHtml += @"<div class='incoming_msg_img'>";
                                        messageboxdiv.InnerHtml += @"<div style='width:300px;'>";
                                        messageboxdiv.InnerHtml += @"<img src='/lbs/img/user-profile.png' alt='user-image' style='float:left;width:33px;margin-right:10px;'/>";
                                        messageboxdiv.InnerHtml += @"<div style='padding-left:10px;padding-top:5px;font-weight: bold;text-decoration:none;color:black;'>";
                                        messageboxdiv.InnerHtml += "Support Team";// Moderator Name
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
                                    if (type_of_user.Equals("student"))
                                    {
                                        messageboxdiv.InnerHtml += @"<div class='col-sm-1 col-md-2 col-lg-2'>";
                                        messageboxdiv.InnerHtml += @"</div>";
                                        messageboxdiv.InnerHtml += @"<div class='outgoing_msg col-sm-11 col-md-10 col-lg-10'>";
                                        messageboxdiv.InnerHtml += @"<div class='sent_msg'>";
                                        messageboxdiv.InnerHtml += @"<div>";
                                        messageboxdiv.InnerHtml += @"<div style='padding-left:10px;margin-bottom:5px;'>";
                                        messageboxdiv.InnerHtml += @"<a href='/lbs/viewProfile.aspx?ID=" + student_email + "' style='font-weight: bold;text-decoration:none;color:black;'>" + comment_username + "</a>";//Student Name
                                        messageboxdiv.InnerHtml += @"</div>";
                                        messageboxdiv.InnerHtml += @"</div>";
                                        messageboxdiv.InnerHtml += @"<p>" + comment_description + "</p>";
                                        messageboxdiv.InnerHtml += @"<span class='time_date'> " + comment_time + "    |    " + comment_date + "</span>";
                                        messageboxdiv.InnerHtml += @"</div>";
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
            student_email = Session["email"].ToString();
        }
        if (Session["typeofuser"] != null)
        {
            current_user = Session["typeofuser"].ToString();
            if (current_user.Equals("student")==false)
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
            Response.Redirect(@"/lbs/student/track_complaint.aspx");
        }
        if (Request.QueryString["Type"] != null)
        {
            complaint_level = Request.QueryString["Type"];
            if (complaint_level.Equals("university")==false)
            {
                if (complaint_level.Equals("institute") == false)
                {
                    if (complaint_level.Equals("department")==false)
                    {
                        Response.Redirect(@"/lbs/student/track_complaint.aspx");
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
            string fetchcategoryquery = "",fetchmodeassignquery="";
            if (complaint_level.Equals("university"))
            {
                fetchmodeassignquery = "select * from university_mode_assign where university_complaint_id=@complaint_id and assign_status='Completed' and reassign_status='No' and reassign_request_user='student'";
                fetchcategoryquery = "SELECT * from university_category where university_category_id=@category_id";
                string checkisclosed = "SELECT * FROM university_complaint where student_email=@student_email and university_complaint_id=@complaint_id and complaint_progress='Completed' and complaint_level=@complaint_level";
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(checkisclosed, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@student_email", student_email);
                        command.Parameters.AddWithValue("@complaint_id", complaint_id);
                        command.Parameters.AddWithValue("@complaint_level", complaint_level);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                commenttextboxdiv.Style["display"] = "none";
                                while (reader.Read())
                                {
                                    category_id = reader.GetInt32(3);
                                    string complaint_status = reader.GetString(8);
                                    if (complaint_status.Equals("Reappeal") == false)
                                    {
                                        if (complaint_status.Equals("Reported") == false)
                                        {
                                            reappealdiv.Style["display"] = "block";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand("SELECT * FROM university_complaint where student_email=@student_email and university_complaint_id=@complaint_id and complaint_level=@complaint_level", connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@student_email", student_email);
                        command.Parameters.AddWithValue("@complaint_id", complaint_id);
                        command.Parameters.AddWithValue("@complaint_level", complaint_level);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
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
                                Response.Redirect(@"/lbs/student/track_complaint.aspx");
                            }
                        }
                    }
                }
                //Comment_Load
                Comment_Load();
            }
            if (complaint_level.Equals("institute"))
            {
                fetchmodeassignquery = "select * from institute_mode_assign where institute_complaint_id=@complaint_id and assign_status='Completed' and reassign_status='No' and reassign_request_user='student'";
                fetchcategoryquery = "SELECT * from institute_category where institute_category_id=@category_id";
                string checkisclosed = "SELECT * FROM institute_complaint where student_email=@student_email and institute_complaint_id=@complaint_id and complaint_progress='Completed' and complaint_level=@complaint_level";
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(checkisclosed, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@student_email", student_email);
                        command.Parameters.AddWithValue("@complaint_id", complaint_id);
                        command.Parameters.AddWithValue("@complaint_level", complaint_level);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                commenttextboxdiv.Style["display"] = "none";
                                while (reader.Read())
                                {
                                    category_id = reader.GetInt32(3);
                                    string complaint_status = reader.GetString(8);
                                    if (complaint_status.Equals("Reappeal") == false)
                                    {
                                        if (complaint_status.Equals("Reported") == false)
                                        {
                                            reappealdiv.Style["display"] = "block";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand("SELECT * FROM institute_complaint where student_email=@student_email and institute_complaint_id=@complaint_id and complaint_level=@complaint_level", connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@student_email", student_email);
                        command.Parameters.AddWithValue("@complaint_id", complaint_id);
                        command.Parameters.AddWithValue("@complaint_level", complaint_level);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
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
                                Response.Redirect(@"/lbs/student/track_complaint.aspx");
                            }
                        }
                    }
                }
                //Comment_Load
                Comment_Load();
            }
            if (complaint_level.Equals("department"))
            {
                fetchmodeassignquery = "select * from department_mode_assign where department_complaint_id=@complaint_id and assign_status='Completed' and reassign_status='No' and reassign_request_user='student'";
                fetchcategoryquery = "SELECT * from department_category where department_category_id=@category_id";
                string checkisclosed = "SELECT * FROM department_complaint where student_email=@student_email and department_complaint_id=@complaint_id and complaint_progress='Completed' and complaint_level=@complaint_level";
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(checkisclosed, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@student_email", student_email);
                        command.Parameters.AddWithValue("@complaint_id", complaint_id);
                        command.Parameters.AddWithValue("@complaint_level", complaint_level);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                commenttextboxdiv.Style["display"] = "none";
                                while (reader.Read())
                                {
                                    category_id = reader.GetInt32(3);
                                    string complaint_status = reader.GetString(8);
                                    if (complaint_status.Equals("Reappeal") == false)
                                    {
                                        if (complaint_status.Equals("Reported") == false)
                                        {
                                            reappealdiv.Style["display"] = "block";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand("SELECT * FROM department_complaint where student_email=@student_email and department_complaint_id=@complaint_id and complaint_level=@complaint_level", connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@student_email", student_email);
                        command.Parameters.AddWithValue("@complaint_id", complaint_id);
                        command.Parameters.AddWithValue("@complaint_level", complaint_level);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
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
                                Response.Redirect(@"/lbs/student/track_complaint.aspx");
                            }
                        }
                    }
                }
                //Comment_Load
                Comment_Load();
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
                            Response.Redirect(@"/lbs/student/track_complaint.aspx");
                        }
                    }
                }
            }
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand(fetchmodeassignquery, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@complaint_id", complaint_id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reappealdiv.Style["display"] = "none";
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
    protected void Comment_Click(object sender, EventArgs e)
    {
        string comment_description=CommentBox.Text;
        if (comment_description.Equals("")==false)
        {
            try
            {
                if (complaint_level.Equals("university") == true)
                {
                    string selectquery = "select university_mode_email from university_mode_assign where (assign_status='Assign' or (assign_status='Resign' and reassign_status is NULL)) and university_complaint_id=@complaint_id";
                    string reciever_email = "";

                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(selectquery, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@complaint_id", complaint_id);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        reciever_email = reader.GetString(0);
                                    }
                                }
                            }
                        }
                    }

                    string comment_date = "", comment_time = "";
                    string insertquery = "insert into university_student_comment(university_complaint_id,sender_email,reciever_email,comment_date,comment_time,comment_description,type_of_user,comment_username) values (@university_complaint_id,@sender_email,@reciever_email,@comment_date,@comment_time,@comment_description,@type_of_user,@comment_username)";
                    comment_date = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
                    comment_time = DateTime.Now.ToShortTimeString();
                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(insertquery, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@university_complaint_id", complaint_id);
                            command.Parameters.AddWithValue("@sender_email", student_email);
                            command.Parameters.AddWithValue("@reciever_email", reciever_email);
                            command.Parameters.AddWithValue("@comment_date", comment_date);
                            command.Parameters.AddWithValue("@comment_time", comment_time);
                            command.Parameters.AddWithValue("@comment_description", comment_description);
                            command.Parameters.AddWithValue("@type_of_user", current_user);
                            command.Parameters.AddWithValue("@comment_username", user_name);

                            command.ExecuteNonQuery();
                        }
                    }
                }
                if (complaint_level.Equals("institute"))
                {
                    string selectquery = "select institute_mode_email from institute_mode_assign where (assign_status='Assign' or (assign_status='Resign' and reassign_status is NULL)) and institute_complaint_id=@complaint_id";
                    string reciever_email = "";

                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(selectquery, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@complaint_id", complaint_id);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        reciever_email = reader.GetString(0);
                                    }
                                }
                            }
                        }
                    }

                    string comment_date = "", comment_time = "";
                    string insertquery = "insert into institute_student_comment(institute_complaint_id,sender_email,reciever_email,comment_date,comment_time,comment_description,type_of_user,comment_username) values (@institute_complaint_id,@sender_email,@reciever_email,@comment_date,@comment_time,@comment_description,@type_of_user,@comment_username)";
                    comment_date = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
                    comment_time = DateTime.Now.ToShortTimeString();
                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(insertquery, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@institute_complaint_id", complaint_id);
                            command.Parameters.AddWithValue("@sender_email", student_email);
                            command.Parameters.AddWithValue("@reciever_email", reciever_email);
                            command.Parameters.AddWithValue("@comment_date", comment_date);
                            command.Parameters.AddWithValue("@comment_time", comment_time);
                            command.Parameters.AddWithValue("@comment_description", comment_description);
                            command.Parameters.AddWithValue("@type_of_user", current_user);
                            command.Parameters.AddWithValue("@comment_username", user_name);

                            command.ExecuteNonQuery();
                        }
                    }
                }
                if (complaint_level.Equals("department"))
                {
                    string selectquery = "select department_mode_email from department_mode_assign where (assign_status='Assign' or (assign_status='Resign' and reassign_status is NULL)) and department_complaint_id=@complaint_id";
                    string reciever_email = "";

                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(selectquery, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@complaint_id", complaint_id);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        reciever_email = reader.GetString(0);
                                    }
                                }
                            }
                        }
                    }

                    string comment_date = "", comment_time = "";
                    string insertquery = "insert into department_student_comment(department_complaint_id,sender_email,reciever_email,comment_date,comment_time,comment_description,type_of_user,comment_username) values (@department_complaint_id,@sender_email,@reciever_email,@comment_date,@comment_time,@comment_description,@type_of_user,@comment_username)";
                    comment_date = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
                    comment_time = DateTime.Now.ToShortTimeString();
                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(insertquery, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@department_complaint_id", complaint_id);
                            command.Parameters.AddWithValue("@sender_email", student_email);
                            command.Parameters.AddWithValue("@reciever_email", reciever_email);
                            command.Parameters.AddWithValue("@comment_date", comment_date);
                            command.Parameters.AddWithValue("@comment_time", comment_time);
                            command.Parameters.AddWithValue("@comment_description", comment_description);
                            command.Parameters.AddWithValue("@type_of_user", current_user);
                            command.Parameters.AddWithValue("@comment_username", user_name);

                            command.ExecuteNonQuery();
                        }
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
    protected void Reappeal_Click(object sender, EventArgs e)
    {
        string reassign_description = reappeal_text.Value;
        if (reassign_description.Equals("") == false)
        {
            try
            {
                if (complaint_level.Equals("university"))
                {
                    string updatemodeassign = "update university_mode_assign set assign_status='Reappeal',university_category_id=@category_id,reassign_description=@reassign_description,reassign_request_user=@type_of_user where university_complaint_id=@complaint_id and reassign_status is NULL";
                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(updatemodeassign, connection))
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@category_id", category_id);
                            command.Parameters.AddWithValue("@reassign_description", reassign_description);
                            command.Parameters.AddWithValue("@type_of_user", current_user);
                            command.Parameters.AddWithValue("@complaint_id", complaint_id);

                            command.ExecuteNonQuery();
                        }
                    }
                    string updatecomplaint = "update university_complaint set complaint_status='Reappeal' where university_category_id=@category_id and student_email=@student_email and university_complaint_id=@complaint_id and complaint_progress='Completed' and complaint_level=@complaint_level";
                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(updatecomplaint, connection))
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@category_id", category_id);
                            command.Parameters.AddWithValue("@student_email", student_email);
                            command.Parameters.AddWithValue("@complaint_id", complaint_id);
                            command.Parameters.AddWithValue("@complaint_level", complaint_level);

                            command.ExecuteNonQuery();
                        }
                    }
                    reappeal_text.Value = "";
                    reappealdiv.Style["display"] = "none";
                    Response.Redirect("/lbs/student/Detail_complaint.aspx?ID=" + complaint_id + "&Type=" + complaint_level);
                }
                if (complaint_level.Equals("institute"))
                {
                    string updatemodeassign = "update institute_mode_assign set assign_status='Reappeal',institute_category_id=@category_id,reassign_description=@reassign_description,reassign_request_user=@type_of_user where institute_complaint_id=@complaint_id and reassign_status is NULL";
                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(updatemodeassign, connection))
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@category_id", category_id);
                            command.Parameters.AddWithValue("@reassign_description", reassign_description);
                            command.Parameters.AddWithValue("@type_of_user", current_user);
                            command.Parameters.AddWithValue("@complaint_id", complaint_id);

                            command.ExecuteNonQuery();
                        }
                    }
                    string updatecomplaint = "update institute_complaint set complaint_status='Reappeal' where institute_category_id=@category_id and student_email=@student_email and institute_complaint_id=@complaint_id and complaint_progress='Completed' and complaint_level=@complaint_level";
                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(updatecomplaint, connection))
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@category_id", category_id);
                            command.Parameters.AddWithValue("@student_email", student_email);
                            command.Parameters.AddWithValue("@complaint_id", complaint_id);
                            command.Parameters.AddWithValue("@complaint_level", complaint_level);

                            command.ExecuteNonQuery();
                        }
                    }
                    reappeal_text.Value = "";
                    reappealdiv.Style["display"] = "none";
                    Response.Redirect("/lbs/student/Detail_complaint.aspx?ID=" + complaint_id + "&Type=" + complaint_level);
                }
                if (complaint_level.Equals("department"))
                {
                    string updatemodeassign = "update department_mode_assign set assign_status='Reappeal',department_category_id=@category_id,reassign_description=@reassign_description,reassign_request_user=@type_of_user where department_complaint_id=@complaint_id and reassign_status is NULL";
                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(updatemodeassign, connection))
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@category_id", category_id);
                            command.Parameters.AddWithValue("@reassign_description", reassign_description);
                            command.Parameters.AddWithValue("@type_of_user", current_user);
                            command.Parameters.AddWithValue("@complaint_id", complaint_id);

                            command.ExecuteNonQuery();
                        }
                    }
                    string updatecomplaint = "update department_complaint set complaint_status='Reappeal' where department_category_id=@category_id and student_email=@student_email and department_complaint_id=@complaint_id and complaint_progress='Completed' and complaint_level=@complaint_level";
                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        using (SqlCommand command = new SqlCommand(updatecomplaint, connection))
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@category_id", category_id);
                            command.Parameters.AddWithValue("@student_email", student_email);
                            command.Parameters.AddWithValue("@complaint_id", complaint_id);
                            command.Parameters.AddWithValue("@complaint_level", complaint_level);

                            command.ExecuteNonQuery();
                        }
                    }
                    reappeal_text.Value = "";
                    reappealdiv.Style["display"] = "none";
                    Response.Redirect("/lbs/student/Detail_complaint.aspx?ID=" + complaint_id + "&Type=" + complaint_level);
                }
            }
            catch (Exception e1)
            {
                System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
            }
        }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        CommentUpdatePanel1.Update();
    }
}