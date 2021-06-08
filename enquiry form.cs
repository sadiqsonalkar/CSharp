Design ticket enquiry form for a theatre. Select location (Mumbai/Pune) using radio button.  When user clicks a location, it fills a combo box with names of theatre’s in that city.   When user selects the name of the theatre, the list of films currently shown and their show timings should be displayed in table.

Code:

Default.aspx
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    TableRow tr;
    TableCell tc1, tc2;
    protected void Page_Load(object sender, EventArgs e)
    {
    }    
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue == "Mumbai")
        {
            DropDownList2.Items.Clear();
            DropDownList2.Items.Add("PVR");
            DropDownList2.Items.Add("INOX");
        }
        if (DropDownList1.SelectedValue == "Pune")
        {
            DropDownList2.Items.Clear();
            DropDownList2.Items.Add("IMAX");
            DropDownList2.Items.Add("GALAXY");
        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        Table1.Rows.Clear();
        if (DropDownList2.SelectedValue == "PVR")
        {
            addmov("Padmavat", "12-2");
            addmov("Zila Ghaziabad", "3-5");
        }
        else if (DropDownList2.SelectedValue == "INOX")
        {
            addmov("Ungli", "12-2");
            addmov("Begam Jaan", "3-5");
        }
        else if (DropDownList2.SelectedValue == "IMAX")
        {
            addmov("Raees", "12-2");
            addmov("The Killer", "3-5");
        }
        else
        {
            addmov("The Ghazi Attack", "12-2");
            addmov("Haseena Parker", "3-5");
        }
    }

    void addmov(String name, String time)
    {
        tr = new TableRow();
        tc1 = new TableCell();
        tc2 = new TableCell();
        tc1.Text = name;
        tc2.Text = time;
        tr.Cells.Add(tc1);
        tr.Cells.Add(tc2);
        Table1.Rows.Add(tr);
    }
}
