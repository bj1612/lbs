using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class track_complaint : System.Web.UI.Page
{
    string connStr;
    protected void Page_Load(object sender, EventArgs e)
    {
        connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
        Response.Cache.SetNoStore();
        string student_email = "";
        if (Session["email"] == null)
        {
            Response.Redirect(@"/lbs/index.aspx");
        }
        if (Session["email"] != null)
        {
            student_email = Session["email"].ToString();
        }
        try
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand("SELECT university_complaint_id,complaint_level,complaint_date,complaint_time,complaint_title FROM university_complaint where student_email=@student_email and complaint_progress='Pending' UNION SELECT institute_complaint_id,complaint_level,complaint_date,complaint_time,complaint_title FROM institute_complaint where student_email=@student_email and complaint_progress='Pending' UNION SELECT department_complaint_id,complaint_level,complaint_date,complaint_time,complaint_title FROM department_complaint where student_email=@student_email and complaint_progress='Pending' ORDER BY complaint_date,complaint_time desc", connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@student_email", student_email);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            pendingdiv.InnerHtml = @"<table class='table table-responsive table-hover' style='color:#FF5500'>";
                            pendingdiv.InnerHtml += @"<thead>";
                            pendingdiv.InnerHtml += @"<tr>";
                            pendingdiv.InnerHtml += @"<th scope='col'>Complaint No.</th>";
                            pendingdiv.InnerHtml += @"<th scope='col'>Type</th>";
                            pendingdiv.InnerHtml += @"<th scope='col'>Subject</th>";
                            pendingdiv.InnerHtml += @"</tr>";
                            pendingdiv.InnerHtml += @"</thead>";
                            pendingdiv.InnerHtml += @"<tbody>";
                            while (reader.Read())
                            {
                                int complaint_id = reader.GetInt32(0);
                                string complaint_level = reader.GetString(1);
                                string complaint_title = reader.GetString(4);
                                pendingdiv.InnerHtml += @"<tr>";
                                pendingdiv.InnerHtml += @"<th scope='row'><a href='/lbs/student/Detail_complaint.aspx?ID=" + complaint_id + "&Type=" + complaint_level + "' style='text-decoration:none;'>" + complaint_id + "</a></th>";
                                pendingdiv.InnerHtml += @"<td><a href='/lbs/student/Detail_complaint.aspx?ID=" + complaint_id + "&Type=" + complaint_level + "' style='text-decoration:none;'>" + System.Globalization.CultureInfo.CurrentUICulture.TextInfo.ToTitleCase(complaint_level) + "</a></td>";
                                pendingdiv.InnerHtml += @"<td><a href='/lbs/student/Detail_complaint.aspx?ID=" + complaint_id + "&Type=" + complaint_level + "' style='text-decoration:none;'>" + complaint_title + "</a></td>";
                                pendingdiv.InnerHtml += @"</tr>";
                            }
                            pendingdiv.InnerHtml += @"</tbody>";
                            pendingdiv.InnerHtml += @"</table>";
                        }
                        else
                        {
                            pendingdiv.InnerHtml = @"No Pending Complaint";
                        }
                    }
                }
            }
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand("SELECT university_complaint_id,complaint_level,complaint_date,complaint_time,complaint_title FROM university_complaint where student_email=@student_email and complaint_progress='Completed' UNION SELECT institute_complaint_id,complaint_level,complaint_date,complaint_time,complaint_title FROM institute_complaint where student_email=@student_email and complaint_progress='Completed' UNION SELECT department_complaint_id,complaint_level,complaint_date,complaint_time,complaint_title FROM department_complaint where student_email=@student_email and complaint_progress='Completed' ORDER BY complaint_date,complaint_time desc", connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@student_email", student_email);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            completeddiv.InnerHtml = @"<table class='table table-responsive table-hover' style='color:#FF5500'>";
                            completeddiv.InnerHtml += @"<thead>";
                            completeddiv.InnerHtml += @"<tr>";
                            completeddiv.InnerHtml += @"<th scope='col'>Complaint No.</th>";
                            completeddiv.InnerHtml += @"<th scope='col'>Type</th>";
                            completeddiv.InnerHtml += @"<th scope='col'>Subject</th>";
                            completeddiv.InnerHtml += @"</tr>";
                            completeddiv.InnerHtml += @"</thead>";
                            completeddiv.InnerHtml += @"<tbody>";
                            while (reader.Read())
                            {
                                int complaint_id = reader.GetInt32(0);
                                string complaint_level = reader.GetString(1);
                                string complaint_title = reader.GetString(4);
                                completeddiv.InnerHtml += @"<tr>";
                                completeddiv.InnerHtml += @"<th scope='row'><a href='/lbs/student/Detail_complaint.aspx?ID=" + complaint_id + "&Type=" + complaint_level + "' style='text-decoration:none;'>" + complaint_id + "</a></th>";
                                completeddiv.InnerHtml += @"<td><a href='/lbs/student/Detail_complaint.aspx?ID=" + complaint_id + "&Type=" + complaint_level + "' style='text-decoration:none;'>" + System.Globalization.CultureInfo.CurrentUICulture.TextInfo.ToTitleCase(complaint_level) + "</a></td>";
                                completeddiv.InnerHtml += @"<td><a href='/lbs/student/Detail_complaint.aspx?ID=" + complaint_id + "&Type=" + complaint_level + "' style='text-decoration:none;'>" + complaint_title + "</a></td>";
                                completeddiv.InnerHtml += @"</tr>";
                            }
                            completeddiv.InnerHtml += @"</tbody>";
                            completeddiv.InnerHtml += @"</table>";
                        }
                        else
                        {
                            completeddiv.InnerHtml = @"No Completed Complaint";
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