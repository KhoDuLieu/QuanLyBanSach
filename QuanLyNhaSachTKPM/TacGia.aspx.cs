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

public partial class TacGia : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        loadTG();
    }
   
    protected void btnThem_Click(object sender, EventArgs e)
    {
        TacGiaInfo hh = new TacGiaInfo();


        hh.TenTG = txtTenTG.Text;
       

        TacGiaBLL hb = new TacGiaBLL();
        int i = hb.nhapTG(hh);
        if (i > 0)
        {
            //Thêm Mới Thành công nếu thông tin nhập chính xác và đầy đủ
            lblThongBao.Visible = true;
            lblThongBao.Text = "Thêm mới thành công!";
            loadTG();
        }
        else
        {
            //ngược lại lỗi nếu sai
            lblThongBao.Visible = true;
            lblThongBao.Text = "Kiểm tra dữ liệu nhập vào!";
        }
    }
    void loadTG()
    {

        TacGiaBLL hb = new TacGiaBLL();
        ArrayList lst = new ArrayList();
        lst = (ArrayList)hb.showTG("select * from TACGIA order by MaTG desc");
        GVTG.DataSource = lst;
        GVTG.DataBind();
    }
    protected void btnNull_Click(object sender, EventArgs e)
    {
        txtTenTG.Text = null;
        lblThongBao.Visible = false;
    }
    protected void GVTG_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //xóa 
        int MaTG = int.Parse(GVTG.DataKeys[e.RowIndex].Value.ToString());
        TacGiaBLL hb = new TacGiaBLL();
        hb.xoaTG(MaTG);
        loadTG();
        lblThongBao.Visible = true;
        lblThongBao.Text = "Xóa thành công!";
    }
    protected void GVTG_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVTG.PageIndex = e.NewPageIndex;
        int trang_thu = e.NewPageIndex;
        int so_dong = GVTG.PageSize;
        stt = trang_thu * so_dong + 1;
        loadTG();
    }
    int stt = 1;
    public string get_stt()
    {
        return Convert.ToString(stt++);
    }
    protected void GVTG_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
}