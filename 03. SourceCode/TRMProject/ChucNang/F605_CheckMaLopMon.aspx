<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F605_CheckMaLopMon.aspx.cs" Inherits="ChucNang_F605_CheckMaLopMon" %>
<%@ Import Namespace ="IP.Core.IPCommon" %>
<%@ Register assembly="eWorld.UI" namespace="eWorld.UI" tagprefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
         <tr>
		<td class="cssPageTitleBG" colspan="3">
		    <asp:label id="m_lbl_loc_du_lieu" runat="server" CssClass="cssPageTitle" 
                Text="Danh sách Hợp đồng khung"/>
		</td>
	</tr>
    <tr>
        <td align="right" style="width:15%">
		  <asp:label id="m_lbl_tu_khoa" runat="server" CssClass="cssManField" Text="Số hợp đồng tìm kiếm" />
		</td>
        <td align="left" style="width:15%">  
		    &nbsp;<asp:Label  id="m_lbl_so_hd" runat="server"></asp:Label> </td>
            <td align="left">  
		  <asp:label id="m_lbl_tu_khoa1" runat="server" CssClass="cssManField" 
                    Text="Mã lớp môn: " />
		        &nbsp;<asp:Label  id="m_lbl_ma_lop_mon" runat="server"></asp:Label> 
		</td>
    </tr>	
    <tr>
		<td colspan="3">
		  
                &nbsp;</td>
	</tr>	
    <tr>
		<td colspan="3">
		  
                          <asp:Label ID="m_lbl_thong_bao" CssClass="cssManField" runat="server"></asp:Label>
                </td>
	</tr>	
    <tr>
		<td class="cssPageTitleBG"colspan="3" >
		    <asp:label id="m_lbl_lich_su_giao_dich" runat="server" CssClass="cssPageTitle" 
                Text="Lịch sử giao dịch"/>
		</td>
	</tr>
	<tr>
		<td align="center" valign="top" colspan="3">
            <asp:GridView ID="m_grv_dm_danh_sach_hop_dong_khung" AllowPaging="True" 
                runat="server" AutoGenerateColumns="False" ShowFooter="true"
                Width="100%" DataKeyNames="ID"
                CellPadding="4" ForeColor="#333333" 
            AllowSorting="True" >
                  <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><asp:Label ID="m_lbl_stt" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="SO_PHIEU_THANH_TOAN" HeaderText="Mã đợt thanh toán"/>
                     <asp:TemplateField HeaderText="Số hợp đồng">
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_so_hop_dong" runat="server" Text='<%# Eval("SO_HOP_DONG").ToString() %>' ></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="REFERENCE_CODE" HeaderText="Các lớp phụ trách" />
                      <asp:BoundField DataField="GHI_CHU_CAC_MON_PHU_TRACH" HeaderText="Tên các môn phụ trách" />
                     <asp:TemplateField HeaderText="Mã giảng viên">
                    <ItemTemplate><%# mapping_magv_by_id(CIPConvert.ToDecimal(Eval("ID_GIANG_VIEN")))%></ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tên giảng viên">
                    <ItemTemplate>
                    <label><a href='<%# "/TRMProject/ChucNang/F201_CapNhatThongTinGiangVien.aspx?mode=edit&id="+Eval("ID_GIANG_VIEN") %>'>
                    <%# Eval("TEN_GIANG_VIEN").ToString() %></a></label>
                    </ItemTemplate>
                    <ItemStyle Width="10%"/>
                    </asp:TemplateField> 
                      <asp:TemplateField HeaderText="Thời gian lớp môn" FooterText="Tổng tiền đã thanh toán: ">
                    <ItemTemplate><%# mapping_thoi_gian_lop_mon((Eval("GHI_CHU_THOI_GIAN_LOP_MON")))%></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Số tiền thanh toán" FooterText="">
                    <ItemTemplate><%# CIPConvert.ToStr(CIPConvert.ToDecimal(Eval("TONG_TIEN_THANH_TOAN")), "#,###")%></ItemTemplate>
                     <ItemStyle HorizontalAlign="Right"></ItemStyle>
                     <FooterStyle HorizontalAlign="Right" />
                    </asp:TemplateField>                   
                </Columns>
                  <EditRowStyle BackColor="#7C6F57" />
                  <FooterStyle BackColor="#810c15" Font-Bold="True" ForeColor="White" />
                  <HeaderStyle BackColor="#810c15" Font-Bold="True" ForeColor="White" />
                  <PagerSettings Position="TopAndBottom" />
                  <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                  <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle CssClass="cssSelectedRow" BackColor="#C5BBAF" Font-Bold="True" 
                      ForeColor="#333333"></SelectedRowStyle>
            </asp:GridView>           
            </td>
	</tr>
 </table>
</asp:Content>

