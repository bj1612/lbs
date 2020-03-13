using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient; 

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connStr);
        using (connection)
        {
            SqlCommand command = new SqlCommand("SELECT university_name FROM university",connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    string item = reader.GetString(1);
                    if (!string.IsNullOrEmpty(item))
                    {
                        university.Items.Add(new ListItem(item, item));
                    }
                }
                reader.NextResult();
            }
        }
    }
}