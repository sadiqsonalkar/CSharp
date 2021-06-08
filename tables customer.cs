Assuming that there are 2 tables customer (account no, account name, password, current balance) transaction (transaction id, account no, date, amount, transaction type, client) where transaction type can be credit or debit. 
User should input account number and password, for successful login it should welcome message with the users name current balance and transaction of the current month in grid.

Code:

Default.aspx
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
using System.Data.OleDb;

public partial class _Default : System.Web.UI.Page
{
    OleDbConnection con;
    OleDbCommand cmd;
    OleDbDataReader dr;
    String n, p;
    int no;
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        n = TextBox1.Text;
        no = Int32.Parse(n);
        p = TextBox2.Text;
        con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\sushil\\Desktop\\Cust_Transaction.mdb");
        con.Open();
        cmd = new OleDbCommand("select count(*) from cust where account_number=" +no+" and password='" + p+"'", con);
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            if (int.Parse(dr[0].ToString()) == 1)
            {
                cmd = new OleDbCommand("select account_name,current_balance from cust where account_number=" + no, con);
                dr = cmd.ExecuteReader();
                dr.Read();
                Session["number"]= n;
                Session["name"] = dr[0];
                Session["curr"] = dr[1];
                Response.Redirect("Default2.aspx");
               
            }
            else
            {
                Label1.Text = "Invalid Username or Password";
            }
        }
    }   
}

Default2.aspx
using System;
using System.Collections;
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
using System.Data.OleDb;

public partial class Default2 : System.Web.UI.Page
{
    OleDbConnection con;
    OleDbCommand cmd;
    OleDbDataAdapter da;
    protected void Page_Load(object sender, EventArgs e)
    {
        Int32 num = Int32.Parse(Session["number"].ToString());
        con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\sushil\\Desktop\\Cust_Transaction.mdb");
        try
        {
            con.Open();
            cmd = new OleDbCommand("select * from trans where account_number =  "+num, con);
            da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            String n= Session["name"].ToString();
            String c= Session["curr"].ToString();
            //da.Dispose();
            //cmd.Dispose();
            L.Text = "Welcome " + n + ", your current balance is : " + c;
            this.GridView1.Visible = true;
            GridView1.DataSource = ds;
            GridView1.DataBind();
            
        }
        catch (Exception exgf){L.Text=""+exgf.ToString(); }
    }
}
