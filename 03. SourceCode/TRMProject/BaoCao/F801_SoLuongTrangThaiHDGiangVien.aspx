<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F801_SoLuongTrangThaiHDGiangVien.aspx.cs" Inherits="BaoCao_F801_SoLuongTrangThaiHDGiangVien" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<table  cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
<tr>
		<td class="cssPageTitleBG" colspan="6">
		    <label class="cssPageTitle">Báo cáo thống kê hợp đồng theo trạng thái giảng viên</label>
		</td>
	</tr>
    <tr>
		<td colspan="6">
        </td>
	</tr>
    <tr>
                <td align="right" style="width:20%">
                 <label class='cssManField'>Thuộc EDUTOP hay ELC: </label>
                         </td>
                <td align="left" style="width:20%" colspan="2">
                  <asp:DropDownList ID="m_cbo_edutop_or_elc" CssClass="cssDorpdownlist" Width="50%" runat="server" 
                        AutoPostBack="true" 
                        onselectedindexchanged="m_cbo_edutop_or_elc_SelectedIndexChanged" >
                  <asp:ListItem Value="edutop">EDUTOP64</asp:ListItem>
                  <asp:ListItem Value="elc">ELC</asp:ListItem>
               </asp:DropDownList>
                         </td>
                <td align="center" colspan="3">
                         </td>
                <td align="left" style="width:1%;"></td>
            </tr>
    <tr>
                <td align="left" colspan="3">
                    <label class="cssManField" style="padding-left:10%">
                   Từ thời gian:
                    </label>
                </td>
                <td align="center">
                    &nbsp;</td>
                <td align="left" style="width:1%;" colspan="2">&nbsp;</td>
            </tr>
    <tr>
                <td align="right" style="width:10%">
                 <label class='cssManField'>Tháng </label></td>
                <td align="left"  style="width:20%">
                  <asp:DropDownList ID="m_cbo_thang_tinh_toan" CssClass="cssDorpdownlist" 
                        Width="50%" runat="server" 
                        AutoPostBack="true" 
                        onselectedindexchanged="m_cbo_thang_tinh_toan_SelectedIndexChanged" >
                      <asp:ListItem Value="0">Tất cả</asp:ListItem>
                      <asp:ListItem>1</asp:ListItem>
                      <asp:ListItem>2</asp:ListItem>
                      <asp:ListItem>3</asp:ListItem>
                      <asp:ListItem>4</asp:ListItem>
                      <asp:ListItem>5</asp:ListItem>
                      <asp:ListItem>6</asp:ListItem>
                      <asp:ListItem>7</asp:ListItem>
                      <asp:ListItem>8</asp:ListItem>
                      <asp:ListItem>9</asp:ListItem>
                      <asp:ListItem>10</asp:ListItem>
                      <asp:ListItem>11</asp:ListItem>
                      <asp:ListItem>12</asp:ListItem>
               </asp:DropDownList>
                         </td>
                <td align="left"  style="width:1%">
                    &nbsp;</td>
                <td align="right" style="width:10%">
                    <label class="cssManField">
                    Năm
                    </label>
                </td>
                <td align="left" style="width:20%;">
                    <asp:DropDownList ID="m_cbo_nam_tinh_toan" runat="server" AutoPostBack="true" 
                        CssClass="cssDorpdownlist" Width="50%" 
                        onselectedindexchanged="m_cbo_nam_tinh_toan_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td align="left" style="width:35%;">
                    <label class="cssManField">
                    Đến nay
                    </label>
                </td>
            </tr>
	<tr>
		<td align="center" colspan="7" valign="top">
   <asp:GridView ID="m_grv_danh_sach_du_toan" AllowPaging="True" 
                runat="server" AutoGenerateColumns="False" 
                Width="90%" DataKeyNames="ID"
                CellPadding="4" ForeColor="#333333" 
                PageSize="15">
                  <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="STT">
                       <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                    </asp:TemplateField> 
                      <asp:BoundField HeaderText="Đơn vị quản lý" DataField="DON_VI_QUAN_LY">
                    <ItemStyle Width="20%" HorizontalAlign="Left" />
                    </asp:BoundField>
                     <asp:BoundField HeaderText="Trạng thái hợp đồng" 
                        DataField="TRANG_THAI_HOP_DONG">
                    <ItemStyle Width="20%" HorizontalAlign="Left" />
                    </asp:BoundField>
                     <asp:BoundField HeaderText="HĐ Chuyên môn" DataField="HD_CHUYEN_MON">
                    <ItemStyle Width="15%" HorizontalAlign="Center" />
                    </asp:BoundField>
                      <asp:BoundField HeaderText="HĐ hướng dẫn" DataField="HD_HUONG_DAN">
                    <ItemStyle Width="15%" HorizontalAlign="Center" />
                    </asp:BoundField>
                     <asp:BoundField HeaderText="HĐ học liệu" DataField="HD_HOC_LIEU">
                    <ItemStyle Width="15%" HorizontalAlign="Center" />
                    </asp:BoundField>
                     <asp:TemplateField HeaderText="Tổng">
                       <ItemTemplate><%# get_sum_hang(Eval("HD_CHUYEN_MON"), Eval("HD_HUONG_DAN"), Eval("HD_HOC_LIEU"))%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
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
     <td align="center" colspan="6">
                    <asp:Button ID="m_cmd_xuat_excel" runat="server" CausesValidation="False" 
                        CssClass="cssButton" Height="25px"  Text="Xuất Excel" 
                        Width="98px" onclick="m_cmd_xuat_excel_Click" />
    </td>
    </tr>
</table>
</asp:Content>

