<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F1307_PhuLucHopDong.aspx.cs" Inherits="CongTTGV_F1307_PhuLucHopDong" %>
<%@ Register assembly="eWorld.UI" namespace="eWorld.UI" tagprefix="ew" %>
<%@ Import Namespace="IP.Core.IPCommon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<style>
 .cssTextBoxnumber
 {
     text-align:right;
 }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
    <tr>
		<td class="cssPageTitleBG">
		    <asp:label id="m_lbl_thong_tin_hd" runat="server" CssClass="cssPageTitle" 
                Text="Thông tin hợp đồng"/>
		</td>
	</tr>
    <tr>
		<td>
        <table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0"> 
            <tr>
                <td align="right" style="width:7%;">
			<asp:label id="Label1" CssClass="cssManField" runat="server" 
                Text="Số hợp đồng khung: " /></td>
                <td align="left" style="width:10%;"> &nbsp;
			<asp:Label id="m_lbl_so_hop_dong"  runat="server" 
                MaxLength="64" Width="96%" />
                         </td>
                         <td align="left" style="width:1%;"> 
                             &nbsp;</td>
                <td align="right" style="width:7%;">
			       
			<asp:label id="Label5" CssClass="cssManField" runat="server" 
                Text="Ngày ký: " />
			       
			    </td>
                <td align="left" style="width:10%;"> &nbsp;
			        <asp:label id="m_lbl_dat_ngay_ky" runat="server" /></td>
                <td align="left" style="width:1%;">&nbsp;</td>
                 <td align="right" style="width:5%;">&nbsp;</td>
                <td align="left" style="width:10%;">&nbsp;</td>
                <td align="left" style="width:1%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:7%;">
			       
			<asp:label id="Label4" CssClass="cssManField" runat="server" 
                Text="Đơn vị quản lý: " />
			       
                         </td>
                <td align="left" style="width:10%;">
                    &nbsp;<asp:Label ID="m_lbl_dv_qly" runat = "server"></asp:Label></td>
                         <td align="left" style="width:1%;"> 
                             &nbsp;</td>
                <td align="right" style="width:5%;">
			       
			<asp:label id="m_lbl_dv_thanh_toan" CssClass="cssManField" runat="server" 
                Text="Đơn vị thanh toán: " />
			       
			    </td>
                <td align="left" colspan="3">	
                    &nbsp;<asp:label id="m_lbl_don_vi_thanh_toan" runat="server" /></td>
                <td align="left" style="width:10%;"></td>
                <td align="left" style="width:1%;"></td>
            </tr>
            <tr>
                <td align="right" style="width:7%;">
			       
			<asp:label id="Label2" Enabled="false" CssClass="cssManField" runat="server" 
                Text="Giảng viên: " />
			       
                </td>
                <td align="left" style="width:10%;">
                 &nbsp;
			<asp:Label id="m_lbl_ten_giang_vien" runat="server" />
                         </td>
                     <td align="left" style="width:1%;">
                         &nbsp;</td>
                <td align="right" style="width:5%;">
			       
			<asp:label id="m_lbl_dv_thanh_toan0" CssClass="cssManField" runat="server" 
                Text="Loại hợp đồng" />
			       
			    </td>
                <td align="left" style="width:10%;">
			
			        <asp:label id="m_lbl_loai_hop_dong" runat="server" /></td>
                      <td align="left" style="width:1%;">
                          &nbsp;</td>
                 <td align="right" style="width:5%;">
			       
			         &nbsp;</td>
                <td align="left" style="width:10%;">
		            &nbsp;</td>
                <td align="left" style="width:1%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;"></td>
                <td align="left" style="width:10%;">    
			        &nbsp;</td> 
                <td align="left" style="width:1%;"></td>
                <td align="left" style="width:5%;">
			        &nbsp;</td>
                <td align="left" style="width:10%;">    
			        &nbsp;</td> <td align="left" style="width:1%;"></td>
                 <td align="right" style="width:5%;"></td>
                <td align="left" style="width:10%;"></td>
            </tr>
            </table>

		</td>
	</tr>
    <tr>
		<td class="cssPageTitleBG" colspan="2">
		    <asp:label id="Label11" runat="server" CssClass="cssPageTitle" 
                Text="Phụ lục hợp đồng khung"/>
		</td>
	</tr>	
    <tr>
		<td align="left">
                <asp:Button ID="m_cmd_exit" runat="server" accessKey="s" CssClass="cssButton" 
                          Height="24px" Text="Thoát" Width="98px" CausesValidation="false" 
                          onclick="m_cmd_exit_Click" /><br />
                          <asp:Label ID="m_lbl_thong_bao" CssClass="cssManField" runat="server"></asp:Label>
                <asp:HiddenField ID="hdf_id_gv" runat="server" />
        </td>
        <td >
		    &nbsp;</td>
	</tr>	
	<tr>
		<td align="center" colspan="2" style="height:450px;" valign="top">
		    &nbsp;
   <asp:GridView ID="m_grv_gd_hop_dong_noi_dung_tt" AllowPaging="True" 
                runat="server" AutoGenerateColumns="False" 
                Width="100%" DataKeyNames="ID"
                CellPadding="4" ForeColor="#333333" 
            AllowSorting="True">
                  <AlternatingRowStyle BackColor="White" />
                <Columns>
                <asp:TemplateField HeaderText="Xóa" Visible="false">
                    <ItemTemplate> <asp:LinkButton ToolTip="Xóa" ID = "lbt_delete" runat="server"
                     CommandName="Delete" CausesValidation="false" OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')">
                      <img src="/TRMProject/Images/Button/deletered.png" alt="Delete" />
                     </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="5%" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Sửa" Visible="false">
                    <ItemTemplate>
                     <asp:LinkButton CausesValidation="false" CommandName="Select" ToolTip="Sửa" ID = "lbt_edit" runat="server">
                    <img src='/TRMProject/Images/Button/edit.png' alt='Sửa' />
                    </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="5%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="NOI_DUNG_THANH_TOAN" HeaderText="Nội dung thanh toán">
                    <ItemStyle Width="40%" HorizontalAlign="Left" />
                    </asp:BoundField>
                     <asp:TemplateField HeaderText="Số lượng - Hệ số / Tần suất" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%#CIPConvert.ToStr(CIPConvert.ToDecimal(Eval("SO_LUONG_HE_SO")), "0.00")%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                    </asp:TemplateField> 
                     <asp:BoundField DataField="DON_VI_TINH" HeaderText="Đơn vị tính">
                     <ItemStyle Width="10%" HorizontalAlign="Center" />
                    </asp:BoundField>
                     <asp:TemplateField HeaderText="Đơn giá (VNĐ)">
                       <ItemTemplate><%#CIPConvert.ToStr(CIPConvert.ToDecimal(Eval("DON_GIA_HD")),"#,###0")%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                    </asp:TemplateField> 
                     <asp:TemplateField HeaderText="Tần suất thanh toán">
                       <ItemTemplate><%# "Theo " + Eval("TAN_SUAT")%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                    </asp:TemplateField>  
                </Columns>
                  <EditRowStyle BackColor="#7C6F57" />
                  <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                  <HeaderStyle BackColor="#810c15" Font-Bold="True" ForeColor="White" />
                  <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                  <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle CssClass="cssSelectedRow" BackColor="#C5BBAF" Font-Bold="True" 
                      ForeColor="#333333"></SelectedRowStyle>
            </asp:GridView>
            </td>
	</tr>

</table>
</asp:Content>

