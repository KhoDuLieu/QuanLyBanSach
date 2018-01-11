<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="TacGia.aspx.cs" Inherits="TacGia" %>

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
            <td class="auto-style1">Tên tác giả</td>
            <td class="auto-style5">
                <asp:TextBox ID="txtTenTG" runat="server" Width="320px"></asp:TextBox>
            </td>
            <td>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTenTG" Display="Dynamic" ErrorMessage="* Nhập tác giả" ForeColor="Red"></asp:RequiredFieldValidator>
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
    <asp:GridView ID="GVTG" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%" OnRowDeleting="GVTG_RowDeleting" DataKeyNames="MaTG" AllowPaging="True" OnPageIndexChanging="GVTG_PageIndexChanging" PageSize="5" OnRowCommand="GVTG_RowCommand" >
        <Columns>
            <asp:TemplateField HeaderText="STT">
                <ItemTemplate><%#get_stt() %></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Mã tác giả" InsertVisible="False">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("MaTG") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tên tác giả">
                <ItemTemplate>
                    <asp:TextBox ID="txtTenTG" runat="server" Text='<%# Eval("TenTG") %>' Width="70%"></asp:TextBox>
                </ItemTemplate>
                
            </asp:TemplateField>
            <asp:TemplateField HeaderText="">
                <ItemTemplate> 
                    <asp:LinkButton ID="Button1" runat="server" CommandName="CapNhat" CommandArgument='<%# Eval("MaTG") %>'
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

