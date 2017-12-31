using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

public partial class TimKiem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["key"] != null)
            {
                string tukhoa = Request.QueryString["key"].ToString();
                load(DataList1, Request.QueryString["key"].ToString());
            }
        }
    }

    void load(DataList x, string tenhang)
    {
        SachBLL hb = new SachBLL();
        ArrayList lst = new ArrayList();
        lst = (ArrayList)hb.showSach("select * from SACH where TenSach like N'%" + tenhang + "%'");
        x.DataSource = lst;
        x.DataBind();
    }

}