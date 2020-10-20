using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            string connectionString = null;
            SqlConnection cnn;
            SqlCommand command;
            connectionString = "Data Source=VEDANSH-PC; Integrated Security=true;Initial Catalog= Registration; uid=YourUserName; Password=yourpassword";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string sql = "Select * from reg order by FirstName";
            command = new SqlCommand(sql, cnn);
            command.ExecuteNonQuery();
            rptData.DataSource = command.ExecuteReader();
            rptData.DataBind();
            cnn.Close();

        }
    }

    

}