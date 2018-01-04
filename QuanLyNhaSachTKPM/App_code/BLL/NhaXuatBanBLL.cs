using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
/// <summary>
/// Summary description for NhaXuatBanBLL
/// </summary>
public class NhaXuatBanBLL
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ToString());
	public NhaXuatBanBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int nhapNXB(NhaXuatBanInfo hh)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("insert_nxb", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter[] par = new SqlParameter[]{
            new SqlParameter("@TenNXB",SqlDbType.NVarChar),
            new SqlParameter("@Email",SqlDbType.NVarChar),
            new SqlParameter("@SDT",SqlDbType.NVarChar),
         new SqlParameter("@DiaChi",SqlDbType.NVarChar)};
        par[0].Value = hh.TenNXB;
        par[1].Value = hh.Email;
        par[2].Value = hh.SDT;
        par[3].Value = hh.DiaChi;
        cmd.Parameters.AddRange(par);
        int i = cmd.ExecuteNonQuery();
        conn.Close();
        return i;
    }

    public IList showNXB(string Sql)
    {
        conn.Open();
        string sql = Sql;
        SqlCommand cmd = new SqlCommand(sql, conn);
        ArrayList lst = new ArrayList();
        NhaXuatBanInfo hh;
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            hh = new NhaXuatBanInfo();
            if (!dr.IsDBNull(0)) hh.MaNXB = dr.GetInt32(0);
            if (!dr.IsDBNull(1)) hh.TenNXB = dr.GetString(1);
            if (!dr.IsDBNull(2)) hh.Email = dr.GetString(2);
            if (!dr.IsDBNull(3)) hh.SDT = dr.GetString(3);
            if (!dr.IsDBNull(4)) hh.DiaChi = dr.GetString(4);
           

            lst.Add(hh);
        }
        dr.Close();
        conn.Close();
        return lst;
    }
    public int xoaNXB(int MaNXB)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("delete_nxb", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter[] par = new SqlParameter[]{
            new SqlParameter("@MaNXB",SqlDbType.Int)};
        par[0].Value = MaNXB;
        cmd.Parameters.AddRange(par);
        int i = cmd.ExecuteNonQuery();
        conn.Close();
        return i;
    }
  
    public int capNhatNXB(int MaNXB, string TenNXB, string Email, string SDT, string DiaChi)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("update NHAXUATBAN set TenNXB=@TenNXB,Email=@Email,SDT=@SDT,DiaChi=@DiaChi where MaNXB=@MaNXB", conn);
        SqlParameter[] par = new SqlParameter[]{
            new SqlParameter("@MaNXB",SqlDbType.Int),
            new SqlParameter("@TenNXB",SqlDbType.NVarChar),
            new SqlParameter("@Email",SqlDbType.NVarChar),
            new SqlParameter("@SDT",SqlDbType.NVarChar),
            new SqlParameter("@DiaChi",SqlDbType.NVarChar)
        };
         
        par[0].Value = MaNXB;
        par[1].Value = TenNXB;
        par[2].Value = Email;
        par[3].Value = SDT;
        par[4].Value = DiaChi; 
        cmd.Parameters.AddRange(par);
        int i = cmd.ExecuteNonQuery();
        conn.Close();
        return i;
    }
}