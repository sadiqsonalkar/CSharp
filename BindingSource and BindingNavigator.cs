For students table, containing Roll, Name and Marks, design a form that allows add, modify and delete operations using suitable buttons.  Provide navigation facility to access First, Last, Next & Previous records.  Also add searching & sorting facilities on specified columns.  [Use BindingSource and BindingNavigator feature]

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
    static int flag;
    static OleDbConnection con;
    OleDbCommand cmd;
    OleDbDataReader dr;

    public void visiblity(bool b)
    {
        Panel1.Visible = b;
        TextBox1.Enabled = b;
        TextBox2.Enabled = b;
        TextBox3.Enabled = b;
        TextBox4.Enabled = b;
        TextBox5.Enabled = b;
        TextBox6.Enabled = b;
        TextBox7.Enabled = b;
        TextBox8.Enabled = b;
    }

    public void empty()
    { TextBox1.Text = "";
    TextBox2.Text = "";
    TextBox3.Text = "";
    TextBox4.Text = "";
    TextBox5.Text = "";
    TextBox6.Text = "";
    TextBox7.Text = "";
    TextBox8.Text = "";
    }

    public void display(int i)
    {
        con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\sushil\\Documents\\Student.mdb");
        con.Open();
        cmd = new OleDbCommand("Select * from student where Roll_Number="+i, con);
        dr = cmd.ExecuteReader();
        dr.Read();
         TextBox1.Text = "" + dr[0].ToString();
          TextBox2.Text = "" + dr[1].ToString();
          TextBox3.Text = "" + dr[2].ToString();
          TextBox4.Text = "" + dr[3].ToString();
          TextBox5.Text = "" + dr[4].ToString();
          TextBox6.Text = "" + dr[5].ToString();
          TextBox7.Text = "" + dr[6].ToString();
          TextBox8.Text = "" + dr[7].ToString();
          dr.Close();
    }

    public void load()
    {
        DropDownList1.Items.Clear();
        con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\sushil\\Documents\\Student.mdb");
        con.Open();
        cmd = new OleDbCommand("Select Roll_Number from student", con);
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            DropDownList1.Items.Add(dr[0].ToString());
        }
        dr.Close();       
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Button5.Visible = false;
        Button6.Visible = false;
        if (!Page.IsPostBack)
        {  
            load();
            visiblity(false);
        }      
    }

    protected void Button2_Click(object sender, EventArgs e)
    {     
        int a =Int32.Parse(DropDownList1.SelectedValue);
        cmd = new OleDbCommand("delete from student where Roll_Number=" + a,con);
        int x= cmd.ExecuteNonQuery();
        DropDownList1.Items.Remove(DropDownList1.SelectedValue);
        load();                
    }
   
    protected void Button1_Click(object sender, EventArgs e)
    {
        Button5.Visible = true;
        Button6.Visible = true;
        visiblity(true);
        flag = 2;
        TextBox1.Enabled = false;
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        visiblity(false);
        Panel1.Visible = true;
        int i = Int32.Parse(DropDownList1.SelectedValue);
        display(i);
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        flag = 1;
        visiblity(true);
        Button5.Visible = true;
        Button6.Visible = true;
        update.Visible = false;
        Button2.Visible = false;
        empty();
        load();
        TextBox1.Enabled = false;
    }


    protected void Button5_Click(object sender, EventArgs e)
    {        
        update.Visible = true;
        Button2.Visible = true;
        Button5.Visible = false;
        Button6.Visible = false;
        Save();
        load();   
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        empty();
        update.Visible = true;
        Button2.Visible = true;
        Button5.Visible = false;
        Button6.Visible = false;
    }

    public void Save()
    {
        int text = Int32.Parse(TextBox1.Text);
        int zip = Int32.Parse(TextBox8.Text);
        int phone = Int32.Parse(TextBox4.Text);
        if (flag == 2)
        {
            int a = Int32.Parse(DropDownList1.SelectedValue);
            cmd = new OleDbCommand("update student set First_Name='" + TextBox2.Text + "',Last_Name='" + TextBox3.Text + "',Phone=" + phone + ",Address='" + TextBox5.Text + "',City='" + TextBox6.Text + "',State='" + TextBox7.Text + "',Zip_Code=" + zip + " where Roll_Number=" + a);
            cmd.Connection = con;
            int x = cmd.ExecuteNonQuery();     
        }
        if (flag == 1)
        {
            cmd = new OleDbCommand("insert into student values("+text+",'" + TextBox2.Text + "','" + TextBox3.Text + "'," + phone + ",'" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "'," + zip + ")");
            cmd.Connection = con;
            int x = cmd.ExecuteNonQuery();
        }
        load();
    }
}
