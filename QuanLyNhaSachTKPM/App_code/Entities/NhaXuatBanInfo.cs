using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NhaXuatBanInfo
/// </summary>
public class NhaXuatBanInfo
{
	public NhaXuatBanInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    int manxb;
    string tennxb;
    string email;
    string sdt;
    string diachi;


    public int MaNXB
    {
        set { manxb =value;}
        get { return manxb; }
    }
    public string TenNXB
    {
        set { tennxb =value;}
        get { return tennxb; }
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
    public string DiaChi
    {
        set { diachi = value; }
        get { return diachi; }
    }
}