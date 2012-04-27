<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F800_BaoCaoTrangThaiGiangVien.aspx.cs" Inherits="BaoCao_F800_BaoCaoTrangThaiGiangVien" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<table  cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
<tr>
		<td class="cssPageTitleBG">
		    <label class="cssPageTitle">Báo cáo thống kê trạng thái giảng viên</label>
		</td>
	</tr>
    <tr>
		<td>
        </td>
	</tr>
	<tr>
		<td align="center" colspan="2" valign="top">
   <asp:GridView ID="m_grv_danh_sach_du_toan" AllowPaging="True" 
                runat="server" AutoGenerateColumns="False" 
                Width="80%" DataKeyNames="ID"
                CellPadding="4" ForeColor="#333333" 
                PageSize="30">
                  <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="STT">
                       <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                    </asp:TemplateField> 
                      <asp:BoundField HeaderText="Đơn vị quản lý" DataField="DON_VI_QUAN_LY">
                    <ItemStyle Width="20%" HorizontalAlign="Left" />
                    </asp:BoundField>
                     <asp:BoundField HeaderText="Trạng thái giảng viên" DataField="TRANG_THAI_GIANG_VIEN">
                    <ItemStyle Width="30%" HorizontalAlign="Left" />
                    </asp:BoundField>
                     <asp:BoundField HeaderText="GV Chuyên môn" DataField="GV_CHUYEN_MON">
                    <ItemStyle Width="11%" HorizontalAlign="Center" />
                    </asp:BoundField>
                      <asp:BoundField HeaderText="GV hướng dẫn" DataField="GV_HUONG_DAN">
                    <ItemStyle Width="11%" HorizontalAlign="Center" />
                    </asp:BoundField>
                     <asp:BoundField HeaderText="GV học liệu" DataField="GV_HOC_LIEU">
                    <ItemStyle Width="11%" HorizontalAlign="Center" />
                    </asp:BoundField>
                     <asp:TemplateField HeaderText="Tổng">
                       <ItemTemplate><%# get_tong_hang(Eval("GV_CHUYEN_MON"), Eval("GV_HUONG_DAN"), Eval("GV_HOC_LIEU"))%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
                    </asp:TemplateField> 
                </Columns>
                  <EditRowStyle BackColor="#7C6F57" />
                  <HeaderStyle BackColor="#810c15" Font-Bold="True" ForeColor="White" />
                  <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                  <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle CssClass="cssSelectedRow" BackColor="#C5BBAF" Font-Bold="True" 
                      ForeColor="#333333"></SelectedRowStyle>
            </asp:GridView>
            </td>
	</tr>
    <tr>
     <td align="center">
                    <asp:Button ID="m_cmd_xuat_excel" runat="server" CausesValidation="False" 
                        CssClass="cssButton" Height="25px"  Text="Xuất Excel" 
                        Width="98px" onclick="m_cmd_xuat_excel_Click" />
    </td>
    </tr>
</table>
</asp:Content>

