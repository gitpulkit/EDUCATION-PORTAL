using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;

public class clsDataAccess : IDisposable
{
    private bool disposedValue = false;
    public SqlConnection Conn;

   
    public string connectionString = @"Data Source=LAPTOP-PL16VRSO;Initial Catalog=test; User id=sa; password=123456789; pooling=false; MultipleActiveResultSets = True; ";
    
    public void CreateConnection()
    {
        SqlConnection.ClearAllPools();
        if (Conn == null)
        {
            Conn = new SqlConnection(connectionString);
        }
        if (Conn.State == ConnectionState.Closed)
        {
            Conn.Open();
        }
        else
        {
            Conn.Close();
            Conn.Open();
        }
    }

    public SqlConnection GetConnectionObj()
    {
        CreateConnection();
        return Conn;
    }

    public void CloseConnection()
    {
        if (Conn != null)
        {
            if (Conn.State != ConnectionState.Closed)
            {
                Conn.Close();
                Conn.Dispose();
            }
            Conn = null;
        }
    }

    public DataTable GetDataTable_SP(string strsql, SqlParameter[] Para)
    {
        CreateConnection();
        SqlCommand Cmd = new SqlCommand(strsql, Conn);
        Cmd.CommandTimeout = 50000;
        Cmd.Parameters.Add(Para);
        SqlDataAdapter da = new SqlDataAdapter(Cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        CloseConnection();
        return dt;
    }

    public DataSet GetDataSet(string strsql)
    {
        CreateConnection();
        SqlCommand Cmd = new SqlCommand(strsql, Conn);
        Cmd.CommandTimeout = 600000;
        SqlDataAdapter da = new SqlDataAdapter(Cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        CloseConnection();
        return ds;
    }

    public DataTable GetDataTable(string strsql)
    {
        CreateConnection();
        SqlCommand Cmd = new SqlCommand(strsql, Conn);
        Cmd.CommandTimeout = 6000000;
        SqlDataAdapter da = new SqlDataAdapter(Cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        CloseConnection();
        return dt;
    }

    public Boolean DuplicateChackingInvoice(string TblName, string FieldName, string Value, string MasterFeild, int MasterId)
    {
        try
        {
            string Qry = "select " + FieldName + " from " + TblName + " where " + FieldName + "=" + Value.SqlEncode() + " and " + MasterFeild + " <> " + MasterId + "";
            if (GetDataTable(Qry).Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            ClsGeneral.ShowMessage(ex.Message);
            return false;
        }

    }

    public SqlDataReader GetReader(string strsql)
    {

        CreateConnection();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strsql;
        cmd.Connection = Conn;
        SqlDataReader reader = cmd.ExecuteReader();
        CloseConnection();
        return reader;
    }

    public bool reader(string strsql)
    {
        CreateConnection();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strsql;
        SqlDataReader reader = cmd.ExecuteReader();
        bool ans = reader.Read();
        reader.Close();
        CloseConnection();
        return ans;
    }

    public int ExecuteQuery(string strsql)
    {
        CreateConnection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = Conn;
        cmd.CommandTimeout = 600000;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strsql;
        int i;
        i = cmd.ExecuteNonQuery();
        CloseConnection();
        return i;
    }

    public int ExecuteQueryIdentity(string strsql)
    {
        CreateConnection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = Conn;
        cmd.CommandTimeout = 600000;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strsql + "; select scope_identity();";
        int i;
        i = Convert.ToInt32(cmd.ExecuteScalar());
        CloseConnection();
        return i;
    }

    public Boolean DuplicateChacking(string TblName, string FieldName, string Value, string MasterFeild, int MasterId)
    {
        try
        {
            if (FieldName.Trim().Length > 0)
            {
                string Qry = "select " + FieldName + " from " + TblName + " where " + FieldName + "='" + Value.SqlEncode() + "' and " + MasterFeild + " <> " + MasterId + "";
                if (GetDataTable(Qry).Rows.Count > 0)
                {
                    return true;
                }
                else
                {

                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        catch (Exception ex)
        {
            ClsGeneral.ShowMessage(ex.Message);
            return false;
        }

    }

    public Boolean DuplicateChacking2(string TblName, string FieldName, string Value, string MasterFeild, string MasterId)
    {
        try
        {
            string Qry = "select " + FieldName + " from " + TblName + " where " + FieldName + "='" + Value.SqlEncode() + "' and " + MasterFeild + " <> " + MasterId + "";
            if (GetDataTable(Qry).Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            ClsGeneral.ShowMessage(ex.Message);
            return false;
        }

    }

    public int GetInsertIndentity(string strsql)
    {
        CreateConnection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = Conn;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strsql + "; select scope_identity();";
        int i;
        i = Convert.ToInt32(cmd.ExecuteScalar());
        CloseConnection();
        return i;
    }

    #region " IDisposable Support "
    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposedValue)
        {
            if (disposing)
            {
                CloseConnection();

            }
        }
        this.disposedValue = true;
    }

    public void Dispose()
    {
        if (!(Conn.State == ConnectionState.Closed))
        {
            CloseConnection();
        }
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    public string ExecuteStringScalar(String SQL)
    {
        SqlConnection _objConn = new SqlConnection(connectionString);
        string value;
        try
        {
            _objConn.Open();
            SqlCommand objCmd = new SqlCommand(SQL, _objConn);
            value = (objCmd.ExecuteScalar()).ToString();
        }
        catch (SqlException ex)
        {
            throw new Exception("Error in SQL:" + SQL, ex);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message); //Rethrowing exception up to parent class
        }
        finally { _objConn.Close(); }
        return value;
    }
    #endregion

}
