using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

/// <summary>
/// Summary description for SachBLL
/// </summary>
public class SachBLL
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ToString());
	public SachBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int nhapSach(SachInfo hh)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("insert_sach", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter[] par = new SqlParameter[]{
            new SqlParameter("@MaNXB",SqlDbType.Int),
            new SqlParameter("@MaTL",SqlDbType.Int),
            new SqlParameter("@MaTG",SqlDbType.Int),
            new SqlParameter("@Tensach",SqlDbType.NVarChar),
            new SqlParameter("@Soluong",SqlDbType.Int),
            new SqlParameter("@Dongia",SqlDbType.BigInt),
            new SqlParameter("@Hinhanh",SqlDbType.NVarChar),
            new SqlParameter("@Mota",SqlDbType.NText)};
        par[0].Value = hh.MaNXB;
        par[1].Value = hh.MaTL;
        par[2].Value = hh.MaTG;
        par[3].Value = hh.TenSach;
        par[4].Value = hh.Soluong;
        par[5].Value = hh.Dongia;
        par[6].Value = hh.Hinhanh;
        par[7].Value = hh.Mota;
        cmd.Parameters.AddRange(par);
        int i = cmd.ExecuteNonQuery();
        conn.Close();
        return i;
    }

    public IList showSach(string Sql)
    {
        conn.Open();
        string sql = Sql;
        SqlCommand cmd = new SqlCommand(sql, conn);
        ArrayList lst = new ArrayList();
        SachInfo hh;
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            hh = new SachInfo();
            if (!dr.IsDBNull(0)) hh.MaSach = dr.GetInt32(0);
            if (!dr.IsDBNull(1)) hh.MaNXB = dr.GetInt32(1);
            if (!dr.IsDBNull(2)) hh.MaTL = dr.GetInt32(2);
            if (!dr.IsDBNull(3)) hh.MaTG = dr.GetInt32(3);
            if (!dr.IsDBNull(4)) hh.TenSach = dr.GetString(4);
            if (!dr.IsDBNull(5)) hh.Soluong = dr.GetInt32(5);
            if (!dr.IsDBNull(6)) hh.Dongia = dr.GetInt64(6);
            if (!dr.IsDBNull(7)) hh.Hinhanh = dr.GetString(7);
            if (!dr.IsDBNull(8)) hh.Mota = dr.GetString(8);
            if (!dr.IsDBNull(9)) hh.Ngaynhap = dr.GetDateTime(9);

            lst.Add(hh);
        }
        dr.Close();
        conn.Close();
        return lst;
    }
    public int xoaSach(int MaSach)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("delete_sach", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter[] par = new SqlParameter[]{
            new SqlParameter("@MaSach",SqlDbType.Int)};
        par[0].Value = MaSach;
        cmd.Parameters.AddRange(par);
        int i = cmd.ExecuteNonQuery();
        conn.Close();
        return i;
    }
    public int laySLSach(string TenSach)
    {
        conn.Open();
        string sql = "select SoLuong from SACH where TenSach=N'" + TenSach + "'";
        SqlCommand cmd = new SqlCommand(sql, conn);
        Object obj = cmd.ExecuteScalar();
        conn.Close();
        return int.Parse(obj.ToString());
    }
    public int capNhatSach(int MaSach, int SoLuong, Int64 Gia)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("update SACH set SoLuong=@SoLuong,DonGia=@Gia where MaSach=@MaSach", conn);
        SqlParameter[] par = new SqlParameter[]{
            new SqlParameter("@MaSach",SqlDbType.Int),
            new SqlParameter("@SoLuong",SqlDbType.Int),
            new SqlParameter("@Gia",SqlDbType.BigInt)};
        par[0].Value = MaSach;
        par[1].Value = SoLuong;
        par[2].Value = Gia;
        cmd.Parameters.AddRange(par);
        int i = cmd.ExecuteNonQuery();
        conn.Close();
        return i;
    }
}