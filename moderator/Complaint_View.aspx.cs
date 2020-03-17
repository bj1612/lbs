using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Complaint_View : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Comment_Click(object sender, EventArgs e)
    {
        CommentBox.Text = "Comment";
    }
    protected void Reassign_Click(object sender, EventArgs e)
    {
        CommentBox.Text = reassign_text.Value;
        //CommentBox.Text = "Reassign";
    }
    protected void Report_Click(object sender, EventArgs e)
    {
        titlediv.InnerHtml = rep_desc.Value;
        CommentBox.Text = "Report";
    }
    protected void Close_Click(object sender, EventArgs e)
    {
        CommentBox.Text = "Close";
    }
}