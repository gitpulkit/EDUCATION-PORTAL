using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

public partial class Delete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string connectionString = null;
        SqlConnection cnn;
        SqlCommand command;
        connectionString = "Data Source=VEDANSH-PC; Integrated Security=true;Initial Catalog= Registration; uid=YourUserName; Password=yourpassword";
        cnn = new SqlConnection(connectionString);
        cnn.Open();
        string sql = "delete from reg where LastName='"+ TextBox2.Value+"'";
        command = new SqlCommand(sql, cnn);
       
        command.ExecuteNonQuery();
        Response.Write("<script>alert('Deleted');</script>");
        command.Dispose();
        cnn.Close();

    }
}