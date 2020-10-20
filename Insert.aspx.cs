using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

public partial class Insert : System.Web.UI.Page
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
        string sql = "insert into reg(FirstName,LastName,ContactNo,Password,EMail) values(@FirstName,@LastName,@ContactNo,@Password,@EMail)";
        command = new SqlCommand(sql, cnn);
        command.Parameters.AddWithValue("@FirstName", System.Data.SqlDbType.NVarChar);
        command.Parameters.AddWithValue("@LastName", System.Data.SqlDbType.NVarChar);
        command.Parameters.AddWithValue("@ContactNo", System.Data.SqlDbType.NVarChar);
        command.Parameters.AddWithValue("@Password", System.Data.SqlDbType.NVarChar);
        command.Parameters.AddWithValue("@EMail", System.Data.SqlDbType.NVarChar);
        command.Parameters["@FirstName"].Value = TextBox1.Value;
        command.Parameters["@LastName"].Value = TextBox2.Value;
        command.Parameters["@ContactNo"].Value = TextBox3.Value;
        command.Parameters["@Password"].Value = TextBox4.Value;
        command.Parameters["@EMail"].Value = TextBox5.Value;

        command.ExecuteNonQuery();
        Response.Write("<script>alert('inserted');</script>");
        command.Dispose();
        cnn.Close();


    }
}