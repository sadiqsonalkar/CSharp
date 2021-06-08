A software company wants to conduct campus interview the eligibility criteria is the candidate must have scored a first class in SSC and HSC also the candidate must have secured an average of 55% across the first 2 years. There should be no gap in education.
The job location is either Mumbai or Pune. Design an ASP.NET web page that accepts details such as name, email, marks at various levels, passing years, job location, and determine whether the candidate is eligible for the job or not and the job location.


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
    double ssc_m, hsc_m, fy_m, sy_m;
    int hsc_y, fy_y, sy_y,ssc_y;
    protected void Button1_Click(object sender, EventArgs e)
    {
        ssc_m = Convert.ToDouble(TextBox3.Text);
        hsc_m = Convert.ToDouble(TextBox4.Text);
        fy_m = Convert.ToDouble(TextBox5.Text);
        sy_m = Convert.ToDouble(TextBox6.Text);

        ssc_y = Convert.ToInt32(TextBox4.Text);
        hsc_y = Convert.ToInt32(TextBox6.Text);
        fy_y = Convert.ToInt32(TextBox8.Text);
        sy_y = Convert.ToInt32(TextBox10.Text);

        if (Page.IsValid)
        {
            if ((ssc_m >= 60) && (hsc_m >= 60) && (((fy_m + sy_m) / 2) >= 55) && ((sy_y - ssc_y) == 4))
            {
                Label1.Text = TextBox1.Text + " You are eligible for interview at Job location " + DropDownList1.SelectedValue;
            }
            else
            {
                Label1.Text = " You are not eligible for interview ";
            }
        }
    }
}
