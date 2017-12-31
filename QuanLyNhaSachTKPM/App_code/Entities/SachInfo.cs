using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SachInfo
/// </summary>
public class SachInfo
{
	public SachInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    int masach;
    int manxb;
    int matl;
    int matg;
    string tensach;
    int soluong;
    Int64 dongia;
    string hinhanh;
    string mota;
    DateTime ngaynhap;

    public int MaSach
    {
        set { masach = value; }
        get { return masach; }
    }
    public int MaNXB
    {
        set { manxb = value; }
        get { return manxb; }
    }
    public int MaTL
    {
        set { matl = value; }
        get { return matl; }
    }
    public int MaTG
    {
        set { matg = value; }
        get { return matg; }
    }
    public string TenSach
    {
        set { tensach = value; }
        get { return tensach; }
    }
    public int Soluong
    {
        set { soluong = value; }
        get { return soluong; }
    }
    public Int64 Dongia
    {
        set { dongia = value; }
        get { return dongia; }
    }
    public string Hinhanh
    {
        set { hinhanh = value; }
        get { return hinhanh; }
    }
    public string Mota
    {
        set { mota = value; }
        get { return mota; }
    }
    public DateTime Ngaynhap
    {
        set { ngaynhap = value; }
        get { return ngaynhap; }
    }
}