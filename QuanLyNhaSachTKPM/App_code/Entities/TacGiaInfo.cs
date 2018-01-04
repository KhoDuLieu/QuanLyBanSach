using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TacGia
/// </summary>
public class TacGiaInfo
{
    public TacGiaInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    int matg;
    string tentg;


    public int MaTG
    {
        set { matg = value; }
        get { return matg; }
    }
    public string TenTG
    {
        set { tentg = value; }
        get { return tentg; }
    }
   
}