using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Session.Abandon();
        Application.Lock();
        Application["OnlineUserCounter"] = Convert.ToInt32(Application["OnlineUserCounter"]) - 1;
        if (Convert.ToInt32(Application["OnlineUserCounter"]) < 0)
        {
            Application["OnlineUserCounter"] = 0;
        }
        Application.UnLock();
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
        Response.Cache.SetNoStore();
        Response.Redirect(@"/lbs/login.aspx");
    }
}