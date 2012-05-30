﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F804_BaoCaoSoLuongHDThanhToanGVTongHop.aspx.cs" Inherits="BaoCao_F804_BaoCaoSoLuongHDThanhToanGVTongHop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<table  cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
<tr>
		<td class="cssPageTitleBG" colspan="6">
		    <label class="cssPageTitle">Báo cáo tổng hợp số lượng hợp đồng theo trạng thái thanh toán giảng viên</label>
		</td>
	</tr>
    <tr>
		<td colspan="6">
        </td>
	</tr>
    <tr>
                <td align="left" colspan="3">
                    <label class="cssManField" style="padding-left:10%">
                   Từ trước đến :
                    </label>
                </td>
                <td align="center">
                    &nbsp;</td>
                <td align="left" style="width:1%;" colspan="2">&nbsp;</td>
            </tr>
    <tr>
                <td align="right" style="width:5%">
                 <label class='cssManField'>Tháng </label></td>
                <td align="left"  style="width:10%">
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
                <td align="right" style="width:5%">
                    <label class="cssManField">
                    Năm
                    </label>
                </td>
                <td align="left" style="width:10%;">
                    <asp:DropDownList ID="m_cbo_nam_tinh_toan" runat="server" AutoPostBack="true" 
                        CssClass="cssDorpdownlist" Width="50%" 
                        onselectedindexchanged="m_cbo_nam_tinh_toan_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
	<tr>
		<td align="center" colspan="6" valign="top">
   <asp:GridView ID="m_grv_danh_sach_du_toan" AllowPaging="True" 
                runat="server" AutoGenerateColumns="False" 
                Width="90%" DataKeyNames="ID"
                CellPadding="4" ForeColor="#333333" 
                PageSize="30">
                  <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="STT">
                       <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                    </asp:TemplateField> 
                     <asp:BoundField HeaderText="Trạng thái thanh toán" 
                        DataField="TRANG_THAI_TT_HOP_DONG">
                    <ItemStyle Width="25%" HorizontalAlign="Left" />
                    </asp:BoundField>
                      <asp:BoundField HeaderText="Chuyên môn EDUTOP" DataField="HD_CHUYEN_MON_EDUTOP">
                       <ItemStyle Width="10%" HorizontalAlign="Center" />
                    </asp:BoundField>
                      <asp:BoundField HeaderText="Hướng dẫn EDUTOP" DataField="HD_HUONG_DAN_EDUTOP">
                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                    </asp:BoundField>
                     <asp:BoundField HeaderText="Học liệu EDUTOP" DataField="HD_HOC_LIEU_EDUTOP">
                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                    </asp:BoundField>
                     <asp:BoundField HeaderText="Chuyên môn ELC" DataField="HD_CHUYEN_MON_ELC">
                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:BoundField>
                     <asp:BoundField HeaderText="Hướng dẫn ELC" DataField="HD_HUONG_DAN_ELC">
                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                    </asp:BoundField>
                     <asp:BoundField HeaderText="Học liệu ELC" DataField="HD_HOC_LIEU_ELC">
                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Tổng">
                       <ItemTemplate><%# get_tong_hang(Eval("HD_CHUYEN_MON_EDUTOP"), Eval("HD_HUONG_DAN_EDUTOP"), Eval("HD_HOC_LIEU_EDUTOP"), Eval("HD_CHUYEN_MON_ELC"), Eval("HD_HUONG_DAN_ELC"), Eval("HD_HOC_LIEU_ELC"))%></ItemTemplate>
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
