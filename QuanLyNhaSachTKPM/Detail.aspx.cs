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

public partial class Detail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["dm"] != null)
            {
                load(DataList1,Request.QueryString["dm"].ToString());
            }
        }
    }

    void load(DataList x, string maloai)
    {
        SachBLL hb = new SachBLL();
        ArrayList lst = new ArrayList();
        lst = (ArrayList)hb.showSach("select * from SACH where MaTL=" + maloai + "order by MaSach desc");
        x.DataSource = lst;
        x.DataBind();
    }

}