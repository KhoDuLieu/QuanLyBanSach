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

public partial class NhaXuatBan : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        loadNXB();
       
    }
   
    protected void btnThem_Click(object sender, EventArgs e)
    {
        NhaXuatBanInfo hh = new NhaXuatBanInfo();
  
       
        hh.TenNXB = txtTenNXB.Text;
        hh.Email = txtEmail.Text;
        hh.SDT = txtSDT.Text;
        hh.DiaChi = txtDiaChi.Text;
       
        NhaXuatBanBLL hb = new NhaXuatBanBLL();
        int i = hb.nhapNXB(hh);
        if (i > 0)
        {
            //Thêm Mới Thành công nếu thông tin nhập chính xác và đầy đủ
            lblThongBao.Visible = true;
            lblThongBao.Text = "Thêm mới thành công!";
            loadNXB();
        }
        else
        {
            //ngược lại lỗi nếu sai
            lblThongBao.Visible = true;
            lblThongBao.Text = "Kiểm tra dữ liệu nhập vào!";
        }

    }
    void loadNXB()
    {
       
        NhaXuatBanBLL hb = new NhaXuatBanBLL();
        ArrayList lst = new ArrayList();
        lst = (ArrayList)hb.showNXB("select * from NHAXUATBAN order by MaNXB desc");
        GVNXB.DataSource = lst;
        GVNXB.DataBind();
    }
    protected void btnNull_Click(object sender, EventArgs e)
    {
        txtTenNXB.Text = null;
        txtEmail.Text = null;
        txtSDT.Text = null;
        txtDiaChi.Text = null;
        lblThongBao.Visible = false;
       
    }
    protected void GVNXB_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //xóa 
        int MaNXB = int.Parse(GVNXB.DataKeys[e.RowIndex].Value.ToString());
        NhaXuatBanBLL hb = new NhaXuatBanBLL();
        hb.xoaNXB(MaNXB);
        loadNXB();
        lblThongBao.Visible = true;
        lblThongBao.Text = "Xóa thành công!";
    }
    protected void GVNXB_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVNXB.PageIndex = e.NewPageIndex;
        int trang_thu = e.NewPageIndex;
        int so_dong = GVNXB.PageSize;
        stt = trang_thu * so_dong + 1;
        loadNXB();
    }
    int stt = 1;
    public string get_stt()
    {
        return Convert.ToString(stt++);
    }
    protected void GVNXB_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
    }
}