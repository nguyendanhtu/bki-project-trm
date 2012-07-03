<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F1723_ChiTietThanhToanGV.aspx.cs" Inherits="CongTTGV_F1723_ChiTietThanhToanGV" %>
<%@ Import Namespace ="IP.Core.IPCommon" %>
<%@ Register assembly="eWorld.UI" namespace="eWorld.UI" tagprefix="ew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
    <tr>
		<td class="cssPageTitleBG">
		    <asp:label id="m_lbl_thong_tin_hd" runat="server" CssClass="cssPageTitle" 
                Text="Lên chi tiết cho bảng kê"/>
		</td>
	</tr>
    <tr>
		<td>
        <table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0"> 
            <tr>
                <td align="right" style="width:7%;">
			<asp:label id="Label1" CssClass="cssManField" runat="server" 
                Text="Số phiếu thanh toán: " /></td>
                <td align="left" style="width:10%;"> &nbsp;
			<asp:Label id="m_lbl_so_phieu_thanh_toan"  runat="server" 
                MaxLength="64" Width="96%" />
                         </td>
                         <td align="left" style="width:1%;"> 
                             &nbsp;</td>
                <td align="right" style="width:7%;">
			       
			<asp:label id="Label5" CssClass="cssManField" runat="server" 
                Text="Ngày thanh toán: " />
			       
			    </td>
                <td align="left" style="width:10%;"> &nbsp;
			        <asp:label id="m_lbl_dat_ngay_thanh_toan" runat="server" /></td>
                <td align="left" style="width:1%;">&nbsp;</td>
                 <td align="right" style="width:5%;">&nbsp;</td>
                <td align="left" style="width:10%;">&nbsp;</td>
                <td align="left" style="width:1%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:7%;">
			       
			<asp:label id="m_lbl_dv_thanh_toan" CssClass="cssManField" runat="server" 
                Text="Đơn vị thanh toán: " />
			       
                         </td>
                <td align="left" style="width:10%;">
                    <asp:label id="m_lbl_don_vi_thanh_toan" runat="server" /></td>
                         <td align="left" style="width:1%;"> 
                             &nbsp;</td>
                <td align="right" style="width:5%;">
			       
			<asp:label id="Label4" CssClass="cssManField" runat="server" 
                Text="Số hợp đồng: " />
			       
			    </td>
                <td align="left" colspan="3">	
                    <asp:Label ID="m_lbl_so_hop_dong" runat = "server"></asp:Label></td>
                <td align="left" style="width:10%;"></td>
                <td align="left" style="width:1%;"></td>
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
             <tr>
		        <td>
                                              
                </td>
                <td >
		            &nbsp;<asp:Button ID="m_btt_xuatExcel" runat="server" accessKey="s" CssClass="cssButton" 
                                  Height="24px" Text="Xuất Excel" Width="98px" 
                        CausesValidation="false" onclick="m_btt_xuatExcel_Click" /><br />            
                </td>
                <td>
                </td>
                <td><asp:Button ID="m_cmd_exit" runat="server" accessKey="s" CssClass="cssButton" 
                          Height="24px" Text="Thoát" Width="98px" CausesValidation="false" 
                          onclick="m_cmd_exit_Click" /><br />
                </td>
	        </tr>	
            </table>

		</td>
	</tr>
    <tr>
		<td class="cssPageTitleBG" colspan="2">
		    <asp:label id="Label11" runat="server" CssClass="cssPageTitle" 
                Text="Danh sách chi tiết thanh toán"/>
		</td>
	</tr>	
    <tr>
		<td align="left">                
                          <asp:Label ID="m_lbl_thong_bao" CssClass="cssManField" runat="server"></asp:Label>                
        </td>
        <td >
		    &nbsp;</td>
	</tr>	
	<tr>
		<td align="center" colspan="2" style="height:450px;" valign="top">
		    &nbsp;
   <asp:GridView ID="m_grv_gd_thanh_toan_detail" AllowPaging="True" 
                runat="server" AutoGenerateColumns="False" 
                Width="100%" DataKeyNames="ID" ShowFooter="true"
                CellPadding="4" ForeColor="#333333" 
            AllowSorting="True" >
                  <AlternatingRowStyle BackColor="White" />
                <Columns>                
                    <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Số phiếu thanh toán" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%#  get_so_phieu_thanh_toan_by_id_gd_thanh_toan(CIPConvert.ToDecimal(Eval("ID_GD_THANH_TOAN")))%></ItemTemplate>
                        <ItemStyle Width="15%" HorizontalAlign="Center" />
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Số hợp đồng" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%#  get_so_hop_dong_by_id(CIPConvert.ToDecimal(Eval("ID_HOP_DONG_KHUNG")))%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                    </asp:TemplateField> 
                     <asp:TemplateField HeaderText="Nội dung thanh toán">
                       <ItemTemplate><%#  get_noi_dung_tt_by_id(CIPConvert.ToDecimal(Eval("ID_NOI_DUNG_THANH_TOAN")))%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                    </asp:TemplateField> 
                     <asp:TemplateField HeaderText="Số lượng / hệ số" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%#CIPConvert.ToStr(CIPConvert.ToDecimal(Eval("SO_LUONG_HE_SO")), "0.00")%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:TemplateField> 
                     <asp:BoundField DataField="DON_VI_TINH" HeaderText="Đơn vị tính">
                     <ItemStyle Width="5%" HorizontalAlign="Center" />
                    </asp:BoundField>
                     <asp:TemplateField HeaderText="Đơn giá (VNĐ)" FooterText="Tổng tiền: ">
                       <ItemTemplate><%#CIPConvert.ToStr(CIPConvert.ToDecimal(Eval("DON_GIA_TT")),"#,###0")%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Thành tiền (VNĐ)">
                       <ItemTemplate><%#get_so_tien_thanh_toan(Eval("SO_LUONG_HE_SO"), Eval("DON_GIA_TT"))%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                        <FooterStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Tần suất thanh toán">
                       <ItemTemplate><%# "Theo " + Eval("TAN_SUAT")%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="DESCRIPTION" HeaderText="Mô tả">
                     <ItemStyle Width="10%" HorizontalAlign="Left" />
                    </asp:BoundField>
                </Columns>
                  <EditRowStyle BackColor="#7C6F57" />
                   <FooterStyle BackColor="#810c15" Font-Bold="True" ForeColor="White"  />
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

