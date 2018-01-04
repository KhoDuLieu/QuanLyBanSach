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


public partial class Admin : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadSach();
            showNhaXuatBan(); 
            showLoai(); 
            showTacGia(); 
        }
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        string ext = Path.GetExtension(txtHinhanh.PostedFile.FileName);
        if (ext == ".png" || ext == ".jpg") //gán hình ảnh được thêm có định dạng đuôi jpg hoặc png
        {
            string now = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
            txtHinhanh.SaveAs(Server.MapPath("~/image/hang/") + "\\" + now + ext); // đường dẫn đến Thư Mục Chứa hình ảnh hàng được nhập
            SachInfo hh = new SachInfo();
            //Thêm Mới Hàng
            hh.MaNXB = int.Parse(ddlMaNXB.SelectedValue);
            hh.MaTL = int.Parse(ddlMaTL.SelectedValue);
            hh.MaTG = int.Parse(ddlMaTG.SelectedValue);
            hh.TenSach = txtTenSach.Text;
            hh.Soluong = int.Parse(txtSoluong.Text);
            hh.Dongia = Int64.Parse(txtDongia.Text);
            hh.Hinhanh = "../image/hang/" + now + ext;
            hh.Mota = txtMota.Value;
            SachBLL hb = new SachBLL();
            int i = hb.nhapSach(hh);
            if (i > 0)
            {
                //Thêm Mới Thành công nếu thông tin nhập chính xác và đầy đủ
                lblThongBao.Visible = true;
                lblThongBao.Text = "Thêm mới thành công!";
                loadSach();
            }
            else
            {
                //ngược lại lỗi nếu sai
                lblThongBao.Visible = true;
                lblThongBao.Text = "Kiểm tra dữ liệu nhập vào!";
            }
        }
        else
        {
            //ảnh sai định dạng
            lblThongBao.Visible = true;
            lblThongBao.Text = "Ảnh không không hợp lệ!";
        }

    }
    void loadSach()
    {
        //lấy ra mã hàng của bảng hàng
        SachBLL hb = new SachBLL();
        ArrayList lst = new ArrayList();
        lst = (ArrayList)hb.showSach("select * from SACH order by MaSach desc");
        GridView1.DataSource = lst;
        GridView1.DataBind();
    }
    protected void btnNull_Click(object sender, EventArgs e)
    {
        //làm trống các form yêu cầu nhập lại nội dung cần thêm
        txtDongia.Text = null;
        txtMota.Value = null;
        txtSoluong.Text = null;
        txtTenSach.Text = null;
        lblThongBao.Visible = false;
        ddlMaNXB.SelectedIndex = 0;
        ddlMaTL.SelectedIndex = 0;
        ddlMaTG.SelectedIndex = 0;
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //xóa sản phẩm
        int MaSach = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
        SachBLL hb = new SachBLL();
        hb.xoaSach(MaSach);
        loadSach();
        lblThongBao.Visible = true;
        lblThongBao.Text = "Xóa thành công!";
    }
  
    private void showLoai()
    {
       
        ddlMaTL.Items.Clear();
        ddlMaTL.Items.Add(new ListItem("Chọn loại", "0"));
        SqlDataAdapter ad = new SqlDataAdapter("select * from THELOAI", conn);
        DataTable dt = new DataTable();
        ad.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlMaTL.Items.Add(new ListItem(dt.Rows[i]["TenTL"].ToString(), dt.Rows[i]["MaTL"].ToString()));
            }
        }
    }
    private void showNhaXuatBan()
    {

        ddlMaNXB.Items.Clear();
        ddlMaNXB.Items.Add(new ListItem("Chọn nhà xuất bản", "0"));
        SqlDataAdapter ad = new SqlDataAdapter("select * from NHAXUATBAN", conn);
        DataTable dt = new DataTable();
        ad.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlMaNXB.Items.Add(new ListItem(dt.Rows[i]["TenNXB"].ToString(), dt.Rows[i]["MaNXB"].ToString()));
            }
        }
    }
    private void showTacGia()
    {

        ddlMaTG.Items.Clear();
        ddlMaTG.Items.Add(new ListItem("Chọn tác giả", "0"));
        SqlDataAdapter ad = new SqlDataAdapter("select * from TACGIA", conn);
        DataTable dt = new DataTable();
        ad.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlMaTG.Items.Add(new ListItem(dt.Rows[i]["TenTG"].ToString(), dt.Rows[i]["MaTG"].ToString()));
            }
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        int trang_thu = e.NewPageIndex;
        int so_dong = GridView1.PageSize;
        stt = trang_thu * so_dong + 1;
        loadSach();
    }
    int stt = 1;
    public string get_stt()
    {
        return Convert.ToString(stt++);
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //cập nhật thông tin hàng
        if (e.CommandName == "CapNhat")
        {
            foreach (GridViewRow r in GridView1.Rows)
            {
                if (GridView1.DataKeys[r.DataItemIndex].Value.ToString() == e.CommandArgument.ToString())
                {
                    TextBox txtSoLuong = (TextBox)r.Cells[3].FindControl("txtSoLuong");
                    int soluong = int.Parse(txtSoLuong.Text);
                    TextBox txtGia = (TextBox)r.Cells[4].FindControl("txtGia");
                    Int64 gia = Int64.Parse(txtGia.Text);
                    SachBLL hb = new SachBLL();
                    hb.capNhatSach(int.Parse(e.CommandArgument.ToString()),soluong,gia);
                    string scr = "<script>alert('Cập nhật thành công.')</script>";
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Thông báo", scr);
                }
            }
        }
    }
}