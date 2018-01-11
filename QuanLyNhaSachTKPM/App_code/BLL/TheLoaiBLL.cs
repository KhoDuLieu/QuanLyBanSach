using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

/// <summary>
/// Summary description for TheLoaiBLL
/// </summary>
public class TheLoaiBLL
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ToString());
	public TheLoaiBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int nhapTL(TheLoaiInfo hh)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("insert_theloai", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter[] par = new SqlParameter[]{
            new SqlParameter("@TenTL",SqlDbType.NVarChar),
           };
        par[0].Value = hh.TenTL;
        cmd.Parameters.AddRange(par);
        int r = cmd.ExecuteNonQuery();
        conn.Close();
        return r;
    }

    public IList showTL(string Sql)
    {
        conn.Open();
        string sql = Sql;
        SqlCommand cmd = new SqlCommand(sql, conn);
        ArrayList lst = new ArrayList();
        TheLoaiInfo hh;
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            hh = new TheLoaiInfo();
            if (!dr.IsDBNull(0)) hh.MaTL = dr.GetInt32(0);
            if (!dr.IsDBNull(1)) hh.TenTL = dr.GetString(1);



            lst.Add(hh);
        }
        dr.Close();
        conn.Close();
        return lst;
    }
    public int xoaTL(int MaTL)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("delete_theloai", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter[] par = new SqlParameter[]{
            new SqlParameter("@MaTL",SqlDbType.Int)};
        par[0].Value = MaTL;
        cmd.Parameters.AddRange(par);
        int r = cmd.ExecuteNonQuery();
        conn.Close();
        return r;
    }

    public int capNhatTL(int MaTL, string TenTL)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("update THELOAI set TenTL=@TenTL where MaTL=@MaTL", conn);
        SqlParameter[] par = new SqlParameter[]{
            new SqlParameter("@MaTL",SqlDbType.Int),
            new SqlParameter("@TenTL",SqlDbType.NVarChar)
           
        };

        par[0].Value = MaTL;
        par[1].Value = TenTL;

        cmd.Parameters.AddRange(par);
        int r = cmd.ExecuteNonQuery();
        conn.Close();
        return r;
    }
}