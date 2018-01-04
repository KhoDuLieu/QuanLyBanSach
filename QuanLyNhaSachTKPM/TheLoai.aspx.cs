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
using System.IO;


public partial class TheLoai : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        loadTL();
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        TheLoaiInfo hh = new TheLoaiInfo();


        hh.TenTL = txtTenTL.Text;


        TheLoaiBLL hb = new TheLoaiBLL();
        int i = hb.nhapTL(hh);
        if (i > 0)
        {
            //Thêm Mới Thành công nếu thông tin nhập chính xác và đầy đủ
            lblThongBao.Visible = true;
            lblThongBao.Text = "Thêm mới thành công!";
            loadTL();
        }
        else
        {
            //ngược lại lỗi nếu sai
            lblThongBao.Visible = true;
            lblThongBao.Text = "Kiểm tra dữ liệu nhập vào!";
        }
    }
    void loadTL()
    {

        TheLoaiBLL hb = new TheLoaiBLL();
        ArrayList lst = new ArrayList();
        lst = (ArrayList)hb.showTL("select * from THELOAI order by MaTL desc");
        GVTL.DataSource = lst;
        GVTL.DataBind();
    }
    protected void btnNull_Click(object sender, EventArgs e)
    {
        txtTenTL.Text = null;
        lblThongBao.Visible = false;
    }
    protected void GVTL_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //xóa 
        int MaTL = int.Parse(GVTL.DataKeys[e.RowIndex].Value.ToString());
        TheLoaiBLL hb = new TheLoaiBLL();
        hb.xoaTL(MaTL);
        loadTL();
        lblThongBao.Visible = true;
        lblThongBao.Text = "Xóa thành công!";
    }
    protected void GVTL_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVTL.PageIndex = e.NewPageIndex;
        int trang_thu = e.NewPageIndex;
        int so_dong = GVTL.PageSize;
        stt = trang_thu * so_dong + 1;
        loadTL();
    }
    int stt = 1;
    public string get_stt()
    {
        return Convert.ToString(stt++);
    }
    protected void GVTL_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
}