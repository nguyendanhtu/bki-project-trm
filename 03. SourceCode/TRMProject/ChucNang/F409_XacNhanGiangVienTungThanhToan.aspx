﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F409_XacNhanGiangVienTungThanhToan.aspx.cs" Inherits="ChucNang_F409_XacNhanGiangVienTungThanhToan" %>
<%@ Import Namespace ="IP.Core.IPCommon" %>
<%@ Register assembly="eWorld.UI" namespace="eWorld.UI" tagprefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<script type="text/javascript">
    function SelectAllCheckboxes(spanChk) {
        // Added as ASPX uses SPAN for checkbox
        var oItem = spanChk.children;
        var theBox = (spanChk.type == "checkbox") ? spanChk : spanChk.children.item[0];
        xState = theBox.checked;
        elm = theBox.form.elements;

        for (i = 0; i < elm.length; i++)
            if (elm[i].type == "checkbox" && elm[i].id != theBox.id) {
                if (elm[i].checked != xState)
                    elm[i].click();
            }
    }
 
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<table  cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
<tr>
		<td class="cssPageTitleBG" colspan="2">
		    <asp:label id="lblUser" runat="server" CssClass="cssPageTitle" 
                Text="Xác nhận giảng viên của thanh toán"/>
		</td>
	</tr>
	<tr>
		<td colspan="2">
                          <asp:Label ID="m_lbl_thong_bao0" CssClass="cssManField" 
                runat="server"></asp:Label>
                </td>
	</tr>
    <tr>
		<td colspan="2">
        <table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0"> 
            <tr>
                <td align="right" style="width:12%;">
			       
			<asp:label id="lblTenGiangVien" CssClass="cssManField" runat="server" 
                Text="Đợt thanh toán" />
			       
                         </td>
                <td align="left" colspan="4">
              <asp:DropDownList ID="m_cbo_dot_thanh_toan" CssClass="cssDorpdownlist" Width="96%" runat="server" 
                        AutoPostBack="true" 
                        onselectedindexchanged="m_cbo_dot_thanh_toan_SelectedIndexChanged">
               </asp:DropDownList>
                         </td>
                <td align="left" style="width:10%;"></td>
                <td align="left" style="width:1%;"></td>
            </tr>
            <tr>
                <td align="right" style="width:7%;">
			       
			<asp:label id="lblngaythanhtoan" CssClass="cssManField" runat="server" 
                Text="Ngày thanh toán" />
			       
                </td>
                <td align="left" style="width:10%;">

                   
			        <ew:CalendarPopup ID="m_dat_ngay_thanh_toan" runat="server" 
                        ControlDisplay="TextBoxImage" GoToTodayText="Hôm nay:" 
                        ImageUrl="~/Images/cal.gif" Nullable="True" NullableLabelText="" 
                        ShowGoToToday="True" Width="75%" SelectedDate="" Text="" Culture="vi-VN" 
                        DisableTextboxEntry="False">
                        <weekdaystyle backcolor="White" font-names="Verdana,Helvetica,Tahoma,Arial" 
                            font-size="XX-Small" forecolor="Black" />
                        <weekendstyle backcolor="LightGray" font-names="Verdana,Helvetica,Tahoma,Arial" 
                            font-size="XX-Small" forecolor="Black" />
                        <offmonthstyle backcolor="AntiqueWhite" 
                            font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small" 
                            forecolor="Gray" />
                        <selecteddatestyle backcolor="Yellow" 
                            font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small" 
                            forecolor="Black" />
                        <monthheaderstyle backcolor="Yellow" 
                            font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small" 
                            forecolor="Black" />
                        <DayHeaderStyle BackColor="Orange" Font-Names="Verdana,Helvetica,Tahoma,Arial" 
                            Font-Size="XX-Small" ForeColor="Black" />
                        <cleardatestyle backcolor="White" font-names="Verdana,Helvetica,Tahoma,Arial" 
                            font-size="XX-Small" forecolor="Black" />
                        <gototodaystyle backcolor="White" font-names="Verdana,Helvetica,Tahoma,Arial" 
                            font-size="XX-Small" forecolor="Black" />
                        <TodayDayStyle BackColor="LightGoldenrodYellow" 
                            Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small" 
                            ForeColor="Black" />
                        <holidaystyle backcolor="White" font-names="Verdana,Helvetica,Tahoma,Arial" 
                            font-size="XX-Small" forecolor="Black" />
                    </ew:CalendarPopup>

                   
                        </td>
                     <td align="left" style="width:1%">

			             &nbsp;</td>
                <td align="right" style="width:5%;">
			       
			<asp:label id="lblMon4" CssClass="cssManField" runat="server" 
                Text="Số hợp đồng khung" />
			       
                </td>
                <td align="left" style="width:10%;">
			
                <asp:TextBox ID="m_txt_so_hop_dong" Width="96%" 
                        runat="server" Enabled="false" CssClass="cssTextBox"></asp:TextBox>
                        </td>
                      <td align="left" style="width:1%;">
                          &nbsp;</td>
                 <td align="right" style="width:5%;">
			       
			         &nbsp;</td>
                <td align="left" style="width:10%;">
		            &nbsp;</td>
                <td align="left" style="width:1%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			       
			<asp:label id="m_lbl_tham_so" CssClass="cssManField" runat="server" 
                Text="" />
			       
                </td>
                <td align="left" style="width:10%;">    
			
                <asp:TextBox ID="m_txt_tham_so" CssClass="cssTextBox" Width="96%" Enabled="false"
                        runat="server"></asp:TextBox>
                        </td> 
                <td align="left" style="width:1%;">
                        &nbsp;</td>
                <td align="right" style="width:9%;">
			       
			        &nbsp;</td>
                <td align="left" style="width:10%;">    
			        &nbsp;</td> <td align="left" style="width:1%;">&nbsp;</td>
                 <td align="right" style="width:5%;">&nbsp;</td>
                <td align="left" style="width:10%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			       
			<asp:label id="lbltan_suat4" CssClass="cssManField" runat="server" 
                Text="Giá trị nghiệm thu thực tế(VNĐ)" />
			       
                </td>
                <td align="left" style="width:10%;">    
                <asp:TextBox  ID="m_txt_gia_tri_nghiem_thu_thuc_te" CssClass="csscurrency" Width="96%" 
                        runat="server"></asp:TextBox> 
                        </td> 
                <td align="left" style="width:1%;">			       
                        &nbsp;</td>
                <td align="left" style="width:5%;">
			       
			<asp:label id="lbltan_suat" CssClass="cssManField" runat="server" 
                Text="Số tiền thanh toán(VNĐ)" />
			       
                </td>
                <td align="left" style="width:10%;">    
                <asp:TextBox  ID="m_txt_so_tien_thanh_toan" CssClass="csscurrency" Width="96%" 
                        runat="server"></asp:TextBox> 
                        </td> <td align="left" style="width:1%;"></td>
                 <td align="right" style="width:5%;"></td>
                <td align="left" style="width:10%;"></td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			       
			<asp:label id="lbltan_suat0" CssClass="cssManField" runat="server" 
                Text="Trong đó:" Font-Underline= "true" />
			       
                </td>
                <td align="left" style="width:10%;">    
                    &nbsp;</td> 
                <td align="left" style="width:1%;">			       
                        &nbsp;</td>
                <td align="left" style="width:5%;">
			        &nbsp;</td>
                <td align="left" style="width:10%;">    
			        &nbsp;</td> <td align="left" style="width:1%;">&nbsp;</td>
                 <td align="right" style="width:5%;">&nbsp;</td>
                <td align="left" style="width:10%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			       
			<asp:label id="lbltan_suat2" CssClass="cssManField" runat="server" 
                Text="Số tiền thuế(VNĐ)" />
			       
                </td>
                <td align="left" style="width:10%;">    
                <asp:TextBox  ID="m_txt_so_tien_thue1" CssClass="csscurrency" Width="96%" 
                        runat="server"></asp:TextBox>
                        </td> 
                <td align="left" style="width:1%;">			       
                        &nbsp;</td>
                <td align="right" style="width:7%;">
			       
			<asp:label id="lbltan_suat1" CssClass="cssManField" runat="server" 
                Text="Số tiền thực nhận (VNĐ)" />
			       
                </td>
                <td align="left" style="width:10%;">    
                <asp:TextBox  ID="m_txt_so_tien_thuc_nhan" CssClass="csscurrency" Width="96%" 
                        runat="server"></asp:TextBox>
                        </td> <td align="left" style="width:1%;">&nbsp;</td>
                 <td align="right" style="width:5%;">&nbsp;</td>
                <td align="left" style="width:10%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			       
			<asp:label id="lbltan_suat3" CssClass="cssManField" runat="server" 
                Text="Trạng thái thanh toán" />
			       
                </td>
                <td align="left" colspan="3">    
              <asp:DropDownList ID="m_cbo_trang_thai_thanh_toan" Width="96%" runat="server">
               </asp:DropDownList>
                         </td> 
                <td align="left" style="width:10%;">    
                    &nbsp;</td> <td align="left" style="width:1%;">&nbsp;</td>
                 <td align="right" style="width:5%;">&nbsp;</td>
                <td align="left" style="width:10%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			       
			<asp:label id="lblMon5" CssClass="cssManField" runat="server" 
                Text="Mô tả" />
			       
                </td>
                <td align="left" colspan="4">
                <asp:TextBox ID="m_txt_mo_ta" CssClass="cssTextBox" Width="98%" 
                        runat="server"></asp:TextBox>
                         </td> 
                <td align="left" style="width:1%;">&nbsp;</td>
                 <td align="right" style="width:5%;">&nbsp;</td>
                <td align="left" style="width:10%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			       
			        &nbsp;</td>
                <td align="left" colspan="3">
                    &nbsp;</td> 
                <td align="left" style="width:10%;">    
                    &nbsp;</td> <td align="left" style="width:1%;">&nbsp;</td>
                 <td align="right" style="width:5%;">&nbsp;</td>
                <td align="left" style="width:10%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			        &nbsp;</td>
                <td align="left" style="width:1%;">
                     <asp:Button ID="m_cmd_cap_nhat_du_toan" runat="server" accessKey="s" 
                         CssClass="cssButton" Height="24px" 
                         Text="Chỉnh sửa" Width="98px" onclick="m_cmd_cap_nhat_du_toan_Click"/>
                 </td>
			   <td align="left" style="width:1%;">
                     &nbsp;</td>
                 <td align="left" colspan="1">
                    <asp:Button ID="m_cmd_bo_qua" runat="server" CausesValidation="False" 
                        CssClass="cssButton" Height="25px"  Text="Bỏ qua" 
                        Width="98px" onclick="m_cmd_bo_qua_Click"/>
                </td>
                <td align="right" style="width:1%;">
                    <asp:Button ID="m_cmd_xoa_trang" runat="server" CausesValidation="False" 
                        CssClass="cssButton" Height="25px"  Text="Thoát" 
                        Width="98px" onclick="m_cmd_xoa_trang_Click" />
                </td>
                <td align="left" style="width:10%;">
                    &nbsp;</td>  
                  <td align="left" style="width:10%;">
                      &nbsp;</td>  
            </tr>
        </table>

		</td>
	</tr>
    <tr>
		<td class="cssPageTitleBG" colspan="2">
		    <asp:label id="m_lbl_danh_sach_thanh_toan" runat="server" CssClass="cssPageTitle" 
                Text="Danh sách thanh toán"/>
		</td>
	</tr>	
    <tr>
		<td align="left" style="width:20%">
                          <asp:Label ID="m_lbl_thong_bao" CssClass="cssManField" runat="server"></asp:Label>
                <asp:HiddenField ID="hdf_id_gv" runat="server" />
                <asp:HiddenField ID="hdf_id_trang_thai_thanh_toan_cu" runat="server" /></td>
                </tr>
                <tr>
                 <td style="text-align:right">
                    <asp:Label ID="Label1" runat="server" CssClass="cssManField" 
                        Text="Tên giảng viên" />
                    </td>
                <td>
                <asp:DropDownList ID="m_cbo_ten_giang_vien" CssClass="cssDorpdownlist" runat="server" 
                        AutoPostBack="true"  Width="55%" 
                        onselectedindexchanged="m_cbo_ten_giang_vien_SelectedIndexChanged">
               </asp:DropDownList>
                    </td>
	</tr>	
                <tr>
                 <td style="text-align:right">
                    <asp:Label ID="Label2" runat="server" CssClass="cssManField" 
                        Text="Số hợp đồng" />
                    </td>
                <td>
                <asp:DropDownList ID="m_txt_so_hd_search" CssClass="cssDorpdownlist" runat="server" 
                        AutoPostBack="true"  Width="55%" 
                        onselectedindexchanged="m_txt_so_hd_search_SelectedIndexChanged">
               </asp:DropDownList>
                    </td>
        <td >&nbsp;</td>
	</tr>
                <tr>
                <td style="text-align:right">
                    <asp:Label ID="lbltan_suat5" runat="server" CssClass="cssManField" 
                        Text="Trạng thái thanh toán" />
                    </td>
                      <td><asp:DropDownList ID="m_cbo_trang_thai_tt_search" CssClass="cssDorpdownlist" runat="server" 
                        AutoPostBack="true"  Width="55%" 
                              onselectedindexchanged="m_cbo_trang_thai_tt_search_SelectedIndexChanged" >
               </asp:DropDownList></td></tr>
    <tr>
        <td>
            <asp:button id="m_cmd_xac_nhan" accessKey="u" CssClass="cssButton"
                runat="server" Width="98px" Height="25px"  Text="Xác nhận" 
                CausesValidation="false" onclick="m_cmd_xac_nhan_Click"/>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:button id="m_cmd_chua_xac_nhan" accessKey="u" 
                       CssClass="cssButton"
                runat="server" Width="98px" Height="25px"  Text="Hủy xác nhận"
                       CausesValidation="false" onclick="m_cmd_chua_xac_nhan_Click"/>
        </td>
    </tr>
	<tr>
		<td align="center" colspan="2" style="height:450px;" valign="top">
		    &nbsp;
   <asp:GridView ID="m_grv_danh_sach_du_toan" AllowPaging="True" 
                runat="server" AutoGenerateColumns="False" 
                Width="100%" DataKeyNames="ID"
                CellPadding="4" ForeColor="#333333" 
                onselectedindexchanging="m_grv_danh_sach_du_toan_SelectedIndexChanging" PageSize="20"
                onpageindexchanging="m_grv_danh_sach_du_toan_PageIndexChanging">
                  <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                  <HeaderTemplate>
                   <input type="checkbox" id="chkAll" onclick="javascript:SelectAllCheckboxes(this)" runat="server" />
                  </HeaderTemplate>                 
                  <ItemTemplate>
                    <asp:CheckBox runat="server" ID="chkItem" ToolTip='<%# Eval("ID") %>' />
                    <asp:CheckBox runat="server" ID="chkTrangThai" ToolTip='<%# Eval("ID_TRANG_THAI_THANH_TOAN") %>' Visible="false" />
                  </ItemTemplate>
                  <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                     <asp:TemplateField HeaderText="Chỉnh sửa">
                    <ItemTemplate>
                     <asp:LinkButton CausesValidation="false" CommandName="Select" ToolTip="Chỉnh sửa xác nhận giảng viên" ID = "lbt_edit_xac_nhan_ngan_hang" runat="server">
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
                     <asp:TemplateField HeaderText="Số hợp đồng" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%# get_so_hd_khung_by_id_hd(CIPConvert.ToDecimal(Eval("ID_HOP_DONG_KHUNG")))%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:TemplateField> 
                     <asp:TemplateField HeaderText="Là hợp đồng" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%# mapping_loai_hd(CIPConvert.ToStr(Eval("LOAI_HOP_DONG")))%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                    </asp:TemplateField> 
                     <asp:BoundField DataField="REFERENCE_CODE" HeaderText="Mã lớp / Đợt tạm ứng">
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
                     <asp:TemplateField HeaderText="Trạng thái" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%# mapping_trang_thai_thanh_toan(CIPConvert.ToDecimal(Eval("ID_TRANG_THAI_THANH_TOAN")))%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                    </asp:TemplateField> 
                      <asp:BoundField DataField="DESCRIPTION" HeaderText="Mô tả">
                     <ItemStyle Width="15%" HorizontalAlign="Left" />
                    </asp:BoundField>
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

