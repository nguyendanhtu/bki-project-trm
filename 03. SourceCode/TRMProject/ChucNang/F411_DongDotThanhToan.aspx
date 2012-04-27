<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F411_DongDotThanhToan.aspx.cs" Inherits="ChucNang_F411_DongDotThanhToan" %>
<%@ Import Namespace ="IP.Core.IPCommon" %>
<%@ Register assembly="eWorld.UI" namespace="eWorld.UI" tagprefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<script type="text/javascript">
    function openPopUp() {
        var url_2_open = '';
        var name = 'ChinhSuaThanhToan';
        var appearence = 'dependent=yes,menubar=no,resizable=no,' +
                                          'status=no,toolbar=no,titlebar=no,' +
                                          'left=5,top=280,width=990px,height=540px';
        var openWindow = window.open(url_2_open, name, appearence);
        openWindow.focus();
    }

    function OpenSiteFromUrl(siteUrl) {
        var name = 'ProfileForm';
        var appearence = 'dependent=yes,menubar=no,resizable=no,' +
                                          'status=no,toolbar=no,titlebar=no,' +
                                          'left=5,top=280,width=990px,height=540px';
        var openWindow = window.open(siteUrl, name, appearence);
        openWindow.focus();
    }
</script>
<table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
    <tr>
		<td class="cssPageTitleBG">
		    <asp:label id="m_lbl_thong_tin_hd" runat="server" CssClass="cssPageTitle" 
                Text="Đóng đợt thanh toán"/>
		</td>
	</tr>
    <tr>
		<td>
        <table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0"> 
            <tr>
                <td align="left" colspan="5">
                          <asp:Label ID="m_lbl_thong_bao1" CssClass="cssManField" 
                runat="server"></asp:Label>
                </td>
                <td align="left" style="width:1%;">&nbsp;</td>
                 <td align="right" style="width:5%;">&nbsp;</td>
                <td align="left" style="width:10%;">&nbsp;</td>
                <td align="left" style="width:1%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:7%; height:35px;">
			<asp:label id="Label1" CssClass="cssManField" runat="server" 
                Text="Đơn vị thanh toán: " /></td>
                <td align="left" colspan="4"> &nbsp;
			<asp:Label id="m_lbl_don_vi_thanh_toan"  runat="server" 
                Width="96%" />
                    &nbsp;
			             </td>
                <td align="left" style="width:1%;">&nbsp;</td>
                 <td align="right" style="width:5%;">&nbsp;</td>
                <td align="left" style="width:10%;">&nbsp;</td>
                <td align="left" style="width:1%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:7%;height:35px;">
			       
			<asp:label id="Label4" CssClass="cssManField" runat="server" 
                Text="Đợt thanh toán " />
			       
                         </td>
                <td align="left" colspan="4">
              <asp:DropDownList ID="m_cbo_dot_thanh_toan" CssClass="cssDorpdownlist" Width="96%" runat="server" 
                        AutoPostBack="true" 
                        onselectedindexchanged="m_cbo_dot_thanh_toan_SelectedIndexChanged">
               </asp:DropDownList>
                         </td>
                <td align="left">	
			        &nbsp;</td>
                <td align="left">	
			        &nbsp;</td>
                <td align="left" style="width:10%;"></td>
                <td align="left" style="width:1%;"></td>
            </tr>
            <tr>
                <td align="right" style="width:7%;height:35px;">
			       
			<asp:label id="Label2" Enabled="false" CssClass="cssManField" runat="server" 
                Text="Ngày thanh toán dự kiến: " />
			       
                </td>
                <td align="left" style="width:10%;">
                 &nbsp;
			<asp:Label id="m_lbl_ngay_tt_du_kien" runat="server" />
                         </td>
                     <td align="left" style="width:1%;">
                         &nbsp;</td>
                <td align="right" style="width:5%;">
			       
			<asp:label id="lbl_trang_thai_dot_tt" CssClass="cssManField" runat="server" 
                Text="Trạng thái đợt thanh toán" />
			       
			    </td>
                <td align="left" style="width:10%;">
			
			        <asp:label id="m_lbl_trang_thai_dot_tt" runat="server" /></td>
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
            <tr>
                <td align="right" style="width:5%;">&nbsp;</td>
                <td align="left" style="width:10%;">    
			        <asp:button id="m_cmd_dong_dot_tt" accessKey="c" CssClass="cssButton" 
                runat="server" Width="98px" Text="Đóng đợt TT" 
                        Height="24px" onclick="m_cmd_dong_dot_tt_Click"/>
                </td> 
                <td align="left" style="width:1%;">&nbsp;</td>
                <td align="left" style="width:5%;">
                     <asp:Button ID="m_cmd_thoat" runat="server" accessKey="s" 
                         CssClass="cssButton" Height="24px" 
                         Text="Thoát" Width="98px" onclick="m_cmd_thoat_Click"/>
                 </td>
                <td align="left" style="width:10%;">    
			        &nbsp;</td> <td align="left" style="width:1%;">&nbsp;</td>
                 <td align="right" style="width:5%;">&nbsp;</td>
                <td align="left" style="width:10%;">&nbsp;</td>
            </tr>
            </table>

		</td>
	</tr>

     <tr>
		<td class="cssPageTitleBG" colspan="4">
		    <asp:label id="m_lbl_loc_du_lieu" runat="server" CssClass="cssPageTitle" 
                Text=""/>
		</td>
	</tr>	
    <tr>
		<td colspan="4">
		   <asp:Label ID="m_lbl_thong_bao" CssClass="cssManField" 
                runat="server"></asp:Label>
                <asp:HiddenField ID="hdf_id_trang_thai_da_co_xac_nhan_gv" runat="server" />
                <asp:HiddenField ID="hdf_id_trang_thai_ngan_hang_chuyen_khoan_khong_thanh_cong" runat="server" />
        </td>
	</tr>	
	<tr>
		<td align="center" style="height:450px;" valign="top" colspan="4">
		    &nbsp;
            <asp:GridView ID="m_grv_danh_sach_du_toan" AllowPaging="True" 
                runat="server" AutoGenerateColumns="False" 
                Width="100%" DataKeyNames="ID"
                CellPadding="4" ForeColor="#333333" PageSize="20"
                onpageindexchanging="m_grv_danh_sach_du_toan_PageIndexChanging" 
                onselectedindexchanging="m_grv_danh_sach_du_toan_SelectedIndexChanging">
                  <AlternatingRowStyle BackColor="White" />
                <Columns>
                     <asp:TemplateField HeaderText="Hành động">
                    <ItemTemplate>
                     <asp:LinkButton CausesValidation="false" CommandName="Select" ToolTip="Chỉnh sửa thanh toán"
                     ID = "lbt_edit_xac_nhan_ngan_hang" runat="server">
                    <img src='/TRMProject/Images/Button/Update.gif' alt='Chỉnh sửa' />
                    </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="3%" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="3%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="SO_PHIEU_THANH_TOAN" HeaderText="Số phiếu thanh toán">
                    <ItemStyle Width="15%" HorizontalAlign="Left" />
                    </asp:BoundField>
                     <asp:TemplateField HeaderText="Số hợp đồng">
                       <ItemTemplate><%# get_so_hd_khung_by_id_hd(CIPConvert.ToDecimal(Eval("ID_HOP_DONG_KHUNG")))%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="12%"></ItemStyle>
                    </asp:TemplateField> 
                     <asp:TemplateField HeaderText="Là hợp đồng" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%# mapping_loai_hd(CIPConvert.ToStr(Eval("LOAI_HOP_DONG")))%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="6%"></ItemStyle>
                    </asp:TemplateField> 
                     <asp:BoundField DataField="REFERENCE_CODE" HeaderText="Các lớp phụ trách / Đợt tạm ứng">
                    <ItemStyle Width="7%" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Tên giảng viên" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%# Eval("TEN_GIANG_VIEN")%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                    </asp:TemplateField> 
                     <asp:BoundField DataField="TONG_TIEN_THANH_TOAN" DataFormatString="{0:N0}" HeaderText="Tổng tiền thanh toán (VNĐ)">
                     <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>
                     <asp:BoundField DataField="SO_TIEN_THUE" DataFormatString="{0:N0}" HeaderText="Số tiền thuế (VNĐ)">
                     <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>
                     <asp:BoundField DataField="TONG_TIEN_THUC_NHAN" DataFormatString="{0:N0}" HeaderText="Tổng tiền thực nhận (VNĐ)">
                     <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>
                     <asp:BoundField DataField="NGAY_THANH_TOAN" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày thanh toán">
                     <ItemStyle Width="6%" HorizontalAlign="Center" />
                    </asp:BoundField>
                     <asp:TemplateField HeaderText="Trạng thái">
                       <ItemTemplate><%# mapping_trang_thai_thanh_toan(CIPConvert.ToDecimal(Eval("ID_TRANG_THAI_THANH_TOAN")))%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                    </asp:TemplateField> 
                     <asp:TemplateField HeaderText="Mô tả">
                       <ItemTemplate><%# Eval("DESCRIPTION")%></ItemTemplate>
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

