using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class subAdmin_subadmin_index : System.Web.UI.Page
{
    string connStr, current_user = "", sub_email = "", complaint_level = "";
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
                string loadreassignquery = "", loadreappealquery = "", loadreportquery = "";
                if (complaint_level.Equals("university"))
                {
                    loadreassignquery = "select university_complaint_id,complaint_title from university_complaint where university_complaint_id in(select university_complaint_id from university_mode_assign where assign_status='Resign' and reassign_status is NULL and university_mode_email in (select university_mode_email from university_mode where university_subadmin_email=@sub_email))";
                    loadreappealquery = "select university_complaint_id,complaint_title from university_complaint where complaint_status='Reappeal' and university_complaint_id in(select university_complaint_id from university_mode_assign where assign_status='Reappeal' and reassign_status is NULL and university_mode_email in (select university_mode_email from university_mode where university_subadmin_email=@sub_email))";
                    loadreportquery = "select university_complaint_id,complaint_title from university_complaint where university_complaint_id in(select university_complaint_id from university_complaint_report where report_approved is NULL and university_complaint_id in(select university_complaint_id from university_mode_assign where university_mode_email in (select university_mode_email from university_mode where university_subadmin_email=@sub_email)))";
                }
                if (complaint_level.Equals("institute"))
                {
                    loadreassignquery = "select institute_complaint_id,complaint_title from institute_complaint where institute_complaint_id in(select institute_complaint_id from institute_mode_assign where assign_status='Resign' and reassign_status is NULL and institute_mode_email in (select institute_mode_email from institute_mode where institute_subadmin_email=@sub_email))";
                    loadreappealquery = "select institute_complaint_id,complaint_title from institute_complaint where complaint_status='Reappeal' and institute_complaint_id in(select institute_complaint_id from institute_mode_assign where assign_status='Reappeal' and reassign_status is NULL and institute_mode_email in (select institute_mode_email from institute_mode where institute_subadmin_email=@sub_email))";
                    loadreportquery = "select institute_complaint_id,complaint_title from institute_complaint where institute_complaint_id in(select institute_complaint_id from institute_complaint_report where report_approved is NULL and institute_complaint_id in(select institute_complaint_id from institute_mode_assign where institute_mode_email in (select institute_mode_email from institute_mode where institute_subadmin_email=@sub_email)))";
                }
                if (complaint_level.Equals("department"))
                {
                    loadreassignquery = "select department_complaint_id,complaint_title from department_complaint where department_complaint_id in(select department_complaint_id from department_mode_assign where assign_status='Resign' and reassign_status is NULL and department_mode_email in (select department_mode_email from department_mode where department_subadmin_email=@sub_email))";
                    loadreappealquery = "select department_complaint_id,complaint_title from department_complaint where complaint_status='Reappeal' and department_complaint_id in(select department_complaint_id from department_mode_assign where assign_status='Reappeal' and reassign_status is NULL and department_mode_email in (select department_mode_email from department_mode where department_subadmin_email=@sub_email))";
                    loadreportquery = "select department_complaint_id,complaint_title from department_complaint where department_complaint_id in(select department_complaint_id from department_complaint_report where report_approved is NULL and department_complaint_id in(select department_complaint_id from department_mode_assign where department_mode_email in (select department_mode_email from department_mode where department_subadmin_email=@sub_email)))";
                }

                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(loadreassignquery, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@sub_email", sub_email);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                resigndiv.InnerHtml = @"<table class='table table-responsive table-hover' style='color:#FF5500'>";
                                resigndiv.InnerHtml += @"<thead>";
                                resigndiv.InnerHtml += @"<tr>";
                                resigndiv.InnerHtml += @"<th scope='col'>Complaint No.</th>";
                                resigndiv.InnerHtml += @"<th scope='col'>Subject</th>";
                                resigndiv.InnerHtml += @"</tr>";
                                resigndiv.InnerHtml += @"</thead>";
                                resigndiv.InnerHtml += @"<tbody>";
                                while (reader.Read())
                                {
                                    int complaint_id = reader.GetInt32(0);
                                    string complaint_title = reader.GetString(1);
                                    resigndiv.InnerHtml += @"<tr>";
                                    resigndiv.InnerHtml += @"<th scope='row'><a href='/lbs/subAdmin/Complaint_View.aspx?ID=" + complaint_id + "&Type=" + complaint_level + "&RequestTypeC=Reassign' style='text-decoration:none;'>" + complaint_id + "</a></th>";
                                    resigndiv.InnerHtml += @"<td><a href='/lbs/subAdmin/Complaint_View.aspx?ID=" + complaint_id + "&Type=" + complaint_level + "&RequestTypeC=Reassign' style='text-decoration:none;'>" + complaint_title + "</a></td>";
                                    resigndiv.InnerHtml += @"</tr>";
                                }
                                resigndiv.InnerHtml += @"</tbody>";
                                resigndiv.InnerHtml += @"</table>";
                            }
                            else
                            {
                                resigndiv.InnerHtml = @"No Reassigned Complaint";
                            }
                        }
                    }
                }

                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(loadreappealquery, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@sub_email", sub_email);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reappealdiv.InnerHtml = @"<table class='table table-responsive table-hover' style='color:#FF5500'>";
                                reappealdiv.InnerHtml += @"<thead>";
                                reappealdiv.InnerHtml += @"<tr>";
                                reappealdiv.InnerHtml += @"<th scope='col'>Complaint No.</th>";
                                reappealdiv.InnerHtml += @"<th scope='col'>Subject</th>";
                                reappealdiv.InnerHtml += @"</tr>";
                                reappealdiv.InnerHtml += @"</thead>";
                                reappealdiv.InnerHtml += @"<tbody>";
                                while (reader.Read())
                                {
                                    int complaint_id = reader.GetInt32(0);
                                    string complaint_title = reader.GetString(1);
                                    reappealdiv.InnerHtml += @"<tr>";
                                    reappealdiv.InnerHtml += @"<th scope='row'><a href='/lbs/subAdmin/Complaint_View.aspx?ID=" + complaint_id + "&Type=" + complaint_level + "&RequestTypeC=Reappeal' style='text-decoration:none;'>" + complaint_id + "</a></th>";
                                    reappealdiv.InnerHtml += @"<td><a href='/lbs/subAdmin/Complaint_View.aspx?ID=" + complaint_id + "&Type=" + complaint_level + "&RequestTypeC=Reappeal' style='text-decoration:none;'>" + complaint_title + "</a></td>";
                                    reappealdiv.InnerHtml += @"</tr>";
                                }
                                reappealdiv.InnerHtml += @"</tbody>";
                                reappealdiv.InnerHtml += @"</table>";
                            }
                            else
                            {
                                reappealdiv.InnerHtml = @"No Reappealed Complaint";
                            }
                        }
                    }
                }

                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(loadreportquery, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@sub_email", sub_email);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reportdiv.InnerHtml = @"<table class='table table-responsive table-hover' style='color:#FF5500'>";
                                reportdiv.InnerHtml += @"<thead>";
                                reportdiv.InnerHtml += @"<tr>";
                                reportdiv.InnerHtml += @"<th scope='col'>Complaint No.</th>";
                                reportdiv.InnerHtml += @"<th scope='col'>Subject</th>";
                                reportdiv.InnerHtml += @"</tr>";
                                reportdiv.InnerHtml += @"</thead>";
                                reportdiv.InnerHtml += @"<tbody>";
                                while (reader.Read())
                                {
                                    int complaint_id = reader.GetInt32(0);
                                    string complaint_title = reader.GetString(1);
                                    reportdiv.InnerHtml += @"<tr>";
                                    reportdiv.InnerHtml += @"<th scope='row'><a href='/lbs/subAdmin/Complaint_View.aspx?ID=" + complaint_id + "&Type=" + complaint_level + "&RequestTypeC=Report' style='text-decoration:none;'>" + complaint_id + "</a></th>";
                                    reportdiv.InnerHtml += @"<td><a href='/lbs/subAdmin/Complaint_View.aspx?ID=" + complaint_id + "&Type=" + complaint_level + "&RequestTypeC=Report' style='text-decoration:none;'>" + complaint_title + "</a></td>";
                                    reportdiv.InnerHtml += @"</tr>";
                                }
                                reportdiv.InnerHtml += @"</tbody>";
                                reportdiv.InnerHtml += @"</table>";
                            }
                            else
                            {
                                reportdiv.InnerHtml = @"No Reported Complaint";
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