using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

public partial class Register_subadmin : System.Web.UI.Page
{
    string connStr;
    protected void Page_Load(object sender, EventArgs e)
    {
        connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;  
    }
    protected void RegisterButtonsubadmin_Click(object sender, EventArgs e)
    {

        string first = First.Text;
        string last = Last.Text;
        long contact = Convert.ToInt64(Contact.Text);
        string emailid = Email.Text;
        string password = Password.Text;
        string confirmpassword = Confirm.Text;
        string insertquery = "insert into department_subadmin values(@first_name,@last_name,@email,@pass,@contact)";
            try
            {
                SqlConnection connection = new SqlConnection(connStr);
                using (connection)
                {
                    using (SqlCommand command = new SqlCommand(insertquery, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@first_name", first);
                        command.Parameters.AddWithValue("@last_name", last);
                        command.Parameters.AddWithValue("@email", emailid);
                        command.Parameters.AddWithValue("@pass", password);
                        command.Parameters.AddWithValue("@contact", contact);
                                               
                        command.ExecuteNonQuery();
                        //Response.Redirect("login.aspx");
                        message.Text = "successfully done";
                        
                    }
                }
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.Message);
            }

        }
}