using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;



public partial class Update : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string connectionString = null;
        SqlConnection cnn;
        SqlCommand command;
        connectionString = "Data Source=VEDANSH-PC; Integrated Security=true;Initial Catalog= Registration; uid=YourUserName; Password=yourpassword";
        cnn = new SqlConnection(connectionString);
        cnn.Open();
        string sql = "update reg set FirstName='"+ TextBox1.Value+ "' where LastName='" + TextBox2.Value + "'";
        command = new SqlCommand(sql, cnn);

        command.ExecuteNonQuery();
        Response.Write("<script>alert('Update');</script>");
        command.Dispose();
        cnn.Close();

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string connectionString = null;
        SqlConnection cnn;
        SqlCommand command;
        connectionString = "Data Source=VEDANSH-PC; Integrated Security=true;Initial Catalog= Registration; uid=YourUserName; Password=yourpassword";
        cnn = new SqlConnection(connectionString);
        cnn.Open();
        SqlDataReader read = (null);

        string sql = "select * from reg where FirstName='" + TextBox1.Value + "'";
        command = new SqlCommand(sql, cnn);
        command.ExecuteNonQuery();
        read = command.ExecuteReader();
        read.Read();
        TextBox1.Value = (read["FirstName"].ToString());
        TextBox2.Value = (read["LastName"].ToString());
        TextBox3.Value = (read["ContactNo"].ToString());
        TextBox4.Value = (read["Password"].ToString());
        TextBox5.Value = (read["EMail"].ToString());

        
        command.Dispose();
        cnn.Close();
    }
}