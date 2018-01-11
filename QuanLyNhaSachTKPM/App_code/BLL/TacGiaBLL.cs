using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

/// <summary>
/// Summary description for TacGiaBLL
/// </summary>
public class TacGiaBLL
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ToString());
	public TacGiaBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int nhapTG(TacGiaInfo hh)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("insert_tacgia", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter[] par = new SqlParameter[]{
            new SqlParameter("@TenTG",SqlDbType.NVarChar),
           };
        par[0].Value = hh.TenTG;
        cmd.Parameters.AddRange(par);
        int i = cmd.ExecuteNonQuery();
        conn.Close();
        return i;
    }

    public IList showTG(string Sql)
    {
        conn.Open();
        string sql = Sql;
        SqlCommand cmd = new SqlCommand(sql, conn);
        ArrayList lst = new ArrayList();
        TacGiaInfo hh;
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            hh = new TacGiaInfo();
            if (!dr.IsDBNull(0)) hh.MaTG = dr.GetInt32(0);
            if (!dr.IsDBNull(1)) hh.TenTG = dr.GetString(1);
            


            lst.Add(hh);
        }
        dr.Close();
        conn.Close();
        return lst;
    }
    public int xoaTG(int MaTG)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("delete_tacgia", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter[] par = new SqlParameter[]{
            new SqlParameter("@MaTG",SqlDbType.Int)};
        par[0].Value = MaTG;
        cmd.Parameters.AddRange(par);
        int i = cmd.ExecuteNonQuery();
        conn.Close();
        return i;
    }

    public int capNhatTG(int MaTG, string TenTG)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("update TACGIA set TenTG=@TenTG where MaTG=@MaTG", conn);
        SqlParameter[] par = new SqlParameter[]{
            new SqlParameter("@MaTG",SqlDbType.Int),
            new SqlParameter("@TenTG",SqlDbType.NVarChar)
           
        };

        par[0].Value = MaTG;
        par[1].Value = TenTG;
      
        cmd.Parameters.AddRange(par);
        int i = cmd.ExecuteNonQuery();
        conn.Close();
        return i;
    }
}