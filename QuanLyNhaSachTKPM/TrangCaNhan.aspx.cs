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

public partial class TrangCaNhan : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Username"] != null)
            {
                showProvince();
                loadInfo();
            }
            else
                Response.Redirect("Default.aspx");
        }
    }
    void loadInfo()
    {
        conn.Open();
        string sql = "select * from TAIKHOAN where Username='" + Session["Username"].ToString() + "'";
        string tinh = "";
        string quan = "";
        string phuong = "";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            txtHoTen.Text = dr["HoTen"].ToString();
            txtEmail.Text = dr["Email"].ToString();
            txtDiaChi.Text = dr["DiaChi"].ToString();
            txtSDT.Text = dr["SDT"].ToString();
            tinh = dr["TTPID"].ToString();
            quan = dr["QHID"].ToString();
            phuong = dr["PXID"].ToString();
        }
        dr.Close();
        ddlDistrict.Items.Clear();
        ddlDistrict.Items.Add(new ListItem(".:Chọn Quận/Huyện:.", "0"));
        SqlDataAdapter ad = new SqlDataAdapter("Select * from QUAN_HUYEN where TTPID = " + tinh, conn);
        DataTable dt = new DataTable();
        ad.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlDistrict.Items.Add(new ListItem(dt.Rows[i]["TenQH"].ToString(), dt.Rows[i]["QHID"].ToString()));
            }
        }
        ddlWard.Items.Clear();
        ddlWard.Items.Add(new ListItem(".:Chọn Phường/Xã:.", "0"));
        SqlDataAdapter ad2 = new SqlDataAdapter("Select * from PHUONG_XA where QHID = " + quan, conn);
        DataTable dt2 = new DataTable();
        ad2.Fill(dt2);
        if (dt2.Rows.Count > 0)
        {
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                ddlWard.Items.Add(new ListItem(dt2.Rows[i]["TenPX"].ToString(), dt2.Rows[i]["PXID"].ToString()));
            }
        }
        conn.Close();
        ddlProvince.SelectedValue = tinh;
        ddlDistrict.SelectedValue = quan;
        ddlWard.SelectedValue = phuong;
    }
    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        showDistrict();
    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        showWard();
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox1.Checked)
            Panel1.Visible = true;
        else
            Panel1.Visible = false;
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
    protected void btnDoiMK_Click(object sender, EventArgs e)
    {
        //Thay đổi mật khẩu
        TaiKhoanBLL tb = new TaiKhoanBLL();
        if (tb.dangNhap(Session["Username"].ToString(), txtMKCu.Text))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("update TAIKHOAN set Pass=@Pass where Username=@Username", conn);//update
            SqlParameter[] par = new SqlParameter[]{
                new SqlParameter("@Username",SqlDbType.NVarChar),
                new SqlParameter("@Pass",SqlDbType.NVarChar)};
            par[0].Value = Session["Username"].ToString();
            par[1].Value = txtMKMoi.Text;
            cmd.Parameters.AddRange(par);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                lblThongBao.Visible = true;
                lblThongBao.Text = "Mật khẩu đã được thay đổi thành công.";
            }
            else
            {
                lblThongBao.Visible = true;
                lblThongBao.Text = "Mật khẩu đã được thay đổi thành công.";
            }
        }
        else
        {
            lblThongBao.Visible = true;
            lblThongBao.Text = "Mật khẩu cũ chưa đúng.";
        }
    }
    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        //cập nhật theo thông tin
        TaiKhoanInfo ti = new TaiKhoanInfo();
        ti.HoTen = txtHoTen.Text;
        ti.TINH_THANHPHO = ddlProvince.SelectedValue;
        ti.QUAN_HUYEN = ddlDistrict.SelectedValue;
        ti.PHUONG_XA = ddlWard.SelectedValue;
        ti.DiaChi = txtDiaChi.Text;
        ti.SDT = txtSDT.Text;
        ti.Email = txtEmail.Text;
        ti.Username = Session["Username"].ToString();
        TaiKhoanBLL tb = new TaiKhoanBLL();
        if (tb.updateUser(ti))
        {
            lblThongBao2.Visible = true;
            lblThongBao2.Text = "Cập nhật thông tin thành công."; // giá trị trả về đúng thì update thành công
            loadInfo();
        }
        else
        {
            lblThongBao2.Visible = true;
            lblThongBao2.Text = "Lỗi.";//ngược lại thì lỗi
        }
    }
}