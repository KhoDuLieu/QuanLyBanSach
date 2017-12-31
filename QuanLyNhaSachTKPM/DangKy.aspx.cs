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

public partial class DangKy : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Username"] == null)
            {
                showProvince();
                ddlDistrict.Items.Add(new ListItem(".:Chọn Quận/Huyện:.", "0"));
                ddlWard.Items.Add(new ListItem(".:Chọn Phường/Xã:.", "0"));
            }
            else
                Response.Redirect("Default.aspx");
        }
    }
    protected void btnNull_Click(object sender, EventArgs e)
    {
        txtDiaChi.Text = null;
        txtEmail.Text = null;
        txtHoTen.Text = null;
        txtMatKhau.Text = null;
        txtMatKhau2.Text = null;
        txtSDT.Text = null;
        txtTaiKhoan.Text = null;
        txtCaptcha.Text = null;
        ddlDistrict.SelectedIndex = 0;
        ddlProvince.SelectedIndex = 0;
        ddlWard.SelectedIndex = 0;
    }
    protected void btnDangky_Click(object sender, EventArgs e)
    {
        cc.ValidateCaptcha(txtCaptcha.Text);
        if (cc.UserValidated)
        {
            TaiKhoanBLL tb = new TaiKhoanBLL();
            if (tb.test_trungUsername(txtTaiKhoan.Text))
            {
                TaiKhoanInfo tk = new TaiKhoanInfo();
                tk.Username = txtTaiKhoan.Text;
                tk.Password = txtMatKhau.Text;
                tk.HoTen = txtHoTen.Text;
                tk.Email = txtEmail.Text;
                tk.TINH_THANHPHO = ddlProvince.SelectedValue;
                tk.QUAN_HUYEN = ddlDistrict.SelectedValue;
                tk.PHUONG_XA = ddlWard.SelectedValue;
                tk.DiaChi = txtDiaChi.Text;
                tk.SDT = txtSDT.Text;
                tk.MaQuyen = 2;
                int i = tb.dangKy(tk);
                if (i > 0)
                {
                    Response.Redirect("Default.aspx?mess=reg-done");
                }
                else
                    Response.Write("<script>alert('Lỗi!')</script>");
            }
            else
            {
                lblThongBao.Visible = true;
                lblThongBao.Text = "Tên tài khoản đã được sử dụng";
            }
        }
        else
        {
            lblTB.Visible = true;
            lblTB.Text = "Mã bảo vệ chưa đúng.";
        }
    }
    private void showProvince()
    {
        ddlProvince.Items.Clear();
        ddlProvince.Items.Add(new ListItem(".:Chọn Tỉnh/Thành Phố:.", "0"));
        SqlDataAdapter ad = new SqlDataAdapter("Select * from TINH_THANHPHO", conn);
        DataTable dt = new DataTable();
        ad.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlProvince.Items.Add(new ListItem(dt.Rows[i]["TenTTP"].ToString(), dt.Rows[i]["TTPID"].ToString()));
            }
        }
    }
    private void showDistrict()
    {
        ddlDistrict.Items.Clear();
        ddlDistrict.Items.Add(new ListItem(".:Chọn Quận/Huyện:.", "0"));
        SqlDataAdapter ad = new SqlDataAdapter("Select * from QUAN_HUYEN where TTPID = " + ddlProvince.SelectedValue, conn);
        DataTable dt = new DataTable();
        ad.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlDistrict.Items.Add(new ListItem(dt.Rows[i]["TenQH"].ToString(), dt.Rows[i]["QHID"].ToString()));
            }
        }
    }
    private void showWard()
    {
        ddlWard.Items.Clear();
        ddlWard.Items.Add(new ListItem(".:Chọn Phường/Xã:.", "0"));
        SqlDataAdapter ad = new SqlDataAdapter("Select * from PHUONG_XA where QHID = " + ddlDistrict.SelectedValue, conn);
        DataTable dt = new DataTable();
        ad.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlWard.Items.Add(new ListItem(dt.Rows[i]["TenPX"].ToString(), dt.Rows[i]["PXID"].ToString()));
            }
        }
    }
    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        showDistrict();
    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        showWard();
    }
    protected void txtMatKhau_PreRender(object sender, EventArgs e)
    {
        txtMatKhau.Attributes["value"] = txtMatKhau.Text;
    }
    protected void txtMatKhau2_PreRender(object sender, EventArgs e)
    {
        txtMatKhau2.Attributes["value"] = txtMatKhau2.Text;
    }
    protected void rfCaptcha_Click(object sender, ImageClickEventArgs e)
    {
        txtCaptcha.Text = null;
    }
}