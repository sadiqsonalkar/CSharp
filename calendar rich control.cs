Design ASP.Net page with calendar rich control. If the day is a public holiday make it unselected. Display a label “My birthday” if the user selects its birth date.
Code:

using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        DateTime dt = new DateTime();
        dt = Calendar1.SelectedDate;
        Label1.Text = dt.ToLongDateString();
    }
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.Date.Day == 15 && e.Day.Date.Month == 8)
        {
            e.Day.IsSelectable = false;
        }
        if (e.Day.Date.Day == 17 && e.Day.Date.Month == 8)
        {
            Label l=new Label();
            e.Cell.Controls.Add(l);
            l.Text=("My Birthday");
            e.Cell.BackColor=System.Drawing.Color.Aqua;
        }
    }
}


