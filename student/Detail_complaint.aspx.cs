﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Detail_complaint : System.Web.UI.Page
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
    protected void Page_Render(object sender, EventArgs e)
    {
        
    }
}