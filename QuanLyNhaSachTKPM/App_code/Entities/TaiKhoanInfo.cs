using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TaiKhoanInfo
/// </summary>
public class TaiKhoanInfo
{
	public TaiKhoanInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    int mauser;
    string username;
    string password;
    string hoten;
    string email;
    string sdt;
    string tinh;
    string quan;
    string phuong;
    string diachi;
    int maquyen;

    public int MaUser
    {
        set { mauser = value; }
        get { return mauser; }
    }
    public string Username
    {
        set { username = value; }
        get { return username; }
    }
    public string Password
    {
        set { password = value; }
        get { return password; }
    }
    public string HoTen
    {
        set { hoten = value; }
        get { return hoten; }
    }
    public string Email
    {
        set { email = value; }
        get { return email; }
    }
    public string SDT
    {
        set { sdt = value; }
        get { return sdt; }
    }
    public string TINH_THANHPHO
    {
        set { tinh = value; }
        get { return tinh; }
    }
    public string QUAN_HUYEN
    {
        set { quan = value; }
        get { return quan; }
    }
    public string PHUONG_XA
    {
        set { phuong = value; }
        get { return phuong; }
    }
    public string DiaChi
    {
        set { diachi = value; }
        get { return diachi; }
    }
    public int MaQuyen
    {
        set { maquyen = value; }
        get { return maquyen; }
    }
}