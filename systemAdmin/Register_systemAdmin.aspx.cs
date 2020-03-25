using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Register_systemAdmin : System.Web.UI.Page
{
    string connStr, query;
    protected void Page_Load(object sender, EventArgs e)
    {
        connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        if (Session["email"] == null)
        {
            Response.Redirect(@"/lbs/index.aspx");
        }
        if (Session["typeofuser"] == null)
        {
            string current_user = Session["typeofuser"].ToString();
            if (current_user.Equals("system_admin") == false)
            {
                Response.Redirect(@"/lbs/index.aspx");
            }
        }
    }
    protected void Register_Click(object sender, EventArgs e)
    {
        try
        {
            if (Password.Text.Equals(Confirm.Text))
            {
                query = "insert into system_admin values(@first,@last,@email,@pass)";
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@first", First.Text);
                        command.Parameters.AddWithValue("@last", Last.Text);
                        command.Parameters.AddWithValue("@email", Email.Text);
                        command.Parameters.AddWithValue("@pass", Password.Text);

                        command.ExecuteNonQuery();
                        string message = "Registeration Successful";
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append("alert('");
                        sb.Append(message);
                        sb.Append("');");
                        sb.Append("window.location ='/lbs/systemAdmin/Register_systemAdmin.aspx';");
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", sb.ToString(), true);
                    }
                }
            }
            else
            {
                string message = "Password doesnt match confirm password";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("');");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", sb.ToString(), true);
                Password.Text = "";
                Confirm.Text = "";
            }
        }
        catch (Exception e1)
        {
            System.Diagnostics.Debug.WriteLine("Error Message: " + e1.StackTrace);
        }
    }
}