using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TheLoai
/// </summary>
public class TheLoaiInfo
{
    public TheLoaiInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    int matl;
    string tentl;


    public int MaTL
    {
        set { matl= value; }
        get { return matl; }
    }
    public string TenTL
    {
        set { tentl= value; }
        get { return tentl; }
    }
   
}