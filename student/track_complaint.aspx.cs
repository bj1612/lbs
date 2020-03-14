using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class track_complaint : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["email"] == null)
        {
            Response.Redirect(@"/lbs/index.aspx");
        }
        if (Session["typeofuser"] == null)
        {
            Response.Redirect(@"/lbs/index.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //tableDiv.InnerHtml += "<label style='font-size:x-large;'>Unsolved Complaint</label><asp:Table ID='Table1' runat='server' class='table table-hover mt-0'><asp:TableRow ID='TableRow1' runat='server' style='background-color: #f88017; color: white;'><asp:TableCell ID='TableCell1' runat='server'>Complaint</asp:TableCell><asp:TableCell ID='TableCell2' runat='server'>Subject</asp:TableCell></asp:TableRow><asp:TableRow ID='TableRow2' runat='server'><asp:TableCell ID='TableCell4' runat='server'>1</asp:TableCell><asp:TableCell ID='TableCell5' runat='server'>Mark</asp:TableCell></asp:TableRow></asp:Table>";
    }
}