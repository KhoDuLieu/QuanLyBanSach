<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="NhaXuatBan.aspx.cs" Inherits="NhaXuatBan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   <style type="text/css">
        .auto-style1 {
           width: 109px;
       }
        .auto-style2 {           height: 15px;
       }
        .auto-style5 {
            width: 342px;
        }
        .auto-style6 {
            width: 109px;
            height: 15px;
        }
        #ContentPlaceHolder1_GridView1 a {
            font-weight:bold;
            margin:0 5px;
        }
            #ContentPlaceHolder1_GridView1 a:hover {
                color: #ff6a00;
            }
        #ContentPlaceHolder1_GridView1 > tbody > tr:nth-child(7) span {
            font-weight: bold;
            color: #ff6a00;
            margin:0 5px;
        }
       .auto-style7 {
           width: 109px;
           height: 29px;
       }
       .auto-style8 {
           width: 342px;
           height: 29px;
       }
       .auto-style9 {
           height: 29px;
       }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <table style="width: 100%;">
        <tr>
            <td class="auto-style1">Tên nhà xuất bản</td>
            <td class="auto-style5">
                <asp:TextBox ID="txtTenNXB" runat="server" Width="320px"></asp:TextBox>
            </td>
            <td>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTenNXB" Display="Dynamic" ErrorMessage="* Nhập tên nhà xuất bản" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Email</td>
            <td class="auto-style5">
                <asp:TextBox ID="txtEmail" runat="server" Width="320px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="* Nhập email" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">Số điện thoại</td>
            <td class="auto-style8">
                <asp:TextBox ID="txtSDT" runat="server" Width="320px"></asp:TextBox>
            </td>
            <td class="auto-style9">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSDT" Display="Dynamic" ErrorMessage="* Nhập số điện thoại" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Địa chỉ</td>
            <td class="auto-style5">
                <asp:TextBox ID="txtDiaChi" runat="server" Width="320px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDiaChi" Display="Dynamic" ErrorMessage="* Nhập địa chỉ" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style6"></td>
            <td class="auto-style2" colspan="2">
                </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style5">
                <asp:Button ID="btnThem" runat="server" Text="Thêm mới" OnClick="btnThem_Click" Width="100px" />
&nbsp;
                <asp:Button ID="btnNull" runat="server" Text="Nhập lại" Width="90px" CausesValidation="False" OnClick="btnNull_Click" />
            &nbsp;
                </td>
            <td>
                <asp:Label ID="lblThongBao" runat="server" Font-Bold="True" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
                </td>
        </tr>
    </table>
    <asp:GridView ID="GVNXB" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%" OnRowDeleting="GVNXB_RowDeleting" DataKeyNames="MaNXB" AllowPaging="True" OnPageIndexChanging="GVNXB_PageIndexChanging" PageSize="5" OnRowCommand="GVNXB_RowCommand"  >
        <Columns>
            <asp:TemplateField HeaderText="STT">
                <ItemTemplate><%#get_stt() %></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Mã nhà xuất bản" InsertVisible="False">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("MaNXB") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tên nhà xuất bản">
                <ItemTemplate>
                    <asp:TextBox ID="txtTenNXB" runat="server" Text='<%# Eval("TenNXB") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Email">
                <ItemTemplate>
                    <asp:TextBox ID="txtEmail" runat="server" Text='<%# Eval("Email") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Số điện thoại">
                <ItemTemplate>
                    <asp:TextBox ID="txtSDT" runat="server" Text='<%# Eval("SDT") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Địa chỉ">
                <ItemTemplate>
                    <asp:TextBox ID="txtDiaChi" runat="server" Text='<%# Eval("DiaChi") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="">
                <ItemTemplate> 
                    <asp:LinkButton ID="Button1" runat="server" CommandName="CapNhat" CommandArgument='<%# Eval("MaNXB") %>'
                            onclientclick="return confirm('Bạn có muốn cập nhật không?');" Text="Update" CausesValidation="False" /> 
                 </ItemTemplate>
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="">
                <ItemTemplate> 
                    <asp:LinkButton ID="Button2" runat="server" CommandName="Delete"
                            onclientclick="return confirm('Bạn có muốn xóa không?');" Text="Xóa" CausesValidation="False" /> 
                 </ItemTemplate>
            </asp:TemplateField> 
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>
</asp:Content>

