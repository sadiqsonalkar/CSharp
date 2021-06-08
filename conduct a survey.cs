A news channel wants to conduct a survey of some famous personalities of the year.  The user initially inputs his/her name, age and email.  
The survey will be valid only if user is above 18 years of age and has an email id.  First page allows user to select Best Sportsperson, 
2nd page asks Best Actor and the third – Best Writer.  At the end, it shows a thank you message with user’s name and shows all the choices made by him/her.

Default.aspx
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Button1_click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Session["name"] = TextBox1.Text;
            Session["email"] = TextBox3.Text;
            Response.Redirect("Default2.aspx");
        }
    }
}

Default2.aspx
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid){
            Session["sports"] = DropDownList1.SelectedItem;
            Response.Redirect("Default3.aspx");
        }
    }
}

Default3.aspx
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Session["actor"] = CheckBoxList1.SelectedItem;
            Response.Redirect("Default4.aspx");
        }
    }
}

Default4.aspx
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Session["writer"] = RadioButtonList1.SelectedItem;
            Response.Redirect("Default5.aspx");
        }
    }
}

Default5.aspx
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default5 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = Session["name"].ToString();
        Label2.Text = Session["email"].ToString();
        Label3.Text = Session["sports"].ToString();
        Label4.Text = Session["actor"].ToString();
        Label5.Text = Session["writer"].ToString();
    }
}
