    <%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F306_HopDongKhungGiangVien.aspx.cs" Inherits="ChucNang_F306_HopDongKhungGiangVien" %>
<%@ Register assembly="eWorld.UI" namespace="eWorld.UI" tagprefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
  <tr>
		<td class="cssPageTitleBG" colspan="3">
		    <asp:label id="m_lbl_header_giang_vien" runat="server" CssClass="cssPageTitle" 
                Text="Danh sách hợp đồng khung"/>
		</td>
	</tr>	
  <tr>
        <td>
        <asp:Panel ID="m_pnl_table" runat="server">
           <table id="m_tb_them_moi_hd_khung" cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0"> 
            <tr>
            <td colspan="2">
		    <asp:validationsummary id="vdsCategory" runat="server" CssClass="cssManField" Font-Bold="true" />
		   <asp:label id="m_lbl_mess" runat="server" CssClass="cssManField" />
		</td>
        </tr>
            <tr>
                <td align="right" style="width:5%;">
			<asp:label id="lblSoHopDong" CssClass="cssManField" runat="server" 
                Text="Số hợp đồng" />
                         </td>
                <td align="left" style="width:10%;">
			<asp:textbox id="m_txt_so_hop_dong" CssClass="cssTextBox"  runat="server" 
                MaxLength="64" Width="96%" />
                         </td>
                         <td align="left" style="width:1%;"> 
                             <asp:RequiredFieldValidator ID="m_rfv_so_hop_dong" runat="server"  Text="*"
                        ControlToValidate="m_txt_so_hop_dong" ErrorMessage="Bạn phải nhập Số hợp đồng"></asp:RequiredFieldValidator></td>
                <td align="left" style="width:5%;">
			       
			        <asp:Label ID="lblNgayKi0" runat="server" CssClass="cssManField" 
                        Text="Ngày kí" />
			       
			    </td>
                <td align="left" style="width:10%;">
                    <ew:CalendarPopup ID="m_dat_ngay_ki" runat="server" 
                        ControlDisplay="TextBoxImage" Culture="vi-VN" DisableTextboxEntry="False" 
                        GoToTodayText="Hôm nay:" ImageUrl="~/Images/cal.gif" Nullable="True" 
                        NullableLabelText="" SelectedDate="" ShowGoToToday="True" Text="" Width="70%">
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
                <td align="left" style="width:1%;"></td>
                 <td align="right" style="width:5%;">
                     <asp:Label ID="lblPophutrach" runat="server" CssClass="cssManField" 
                         Text="PO phụ trách HĐ" />
                </td>
                <td align="left" style="width:10%;">
                    <asp:DropDownList ID="m_cbo_po_phu_trach" runat="server" 
                        CssClass="cssDorpdownlist" Width="96%" />
                </td>
                <td align="left" style="width:1%;"></td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			        <asp:Label ID="lblDonViQuanLy" runat="server" CssClass="cssManField" 
                        Text="Đơn vị quản lý HĐ" />
                         </td>
                <td align="left" style="width:10%;">	
                    <asp:DropDownList ID="m_cbo_dm_loai_don_vi_quan_li" runat="server" 
                        CssClass="cssDorpdownlist" Width="96%" />
                         </td>
                         <td align="left" style="width:1%;"> 
                             &nbsp;</td>
                <td align="left" style="width:5%;">
		            <asp:Label ID="lblDonViThanhToan" runat="server" CssClass="cssManField" 
                        Text="Đơn vị thanh toán" />
                </td>
                <td align="left" colspan="3">
                    <asp:DropDownList ID="m_cbo_dm_loai_don_vi_thanh_toan" runat="server" 
                        CssClass="cssDorpdownlist" Width="85%" />
                </td>
                <td align="left" style="width:10%;">&nbsp;</td>
                <td align="left" style="width:1%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			        <asp:Label ID="lblTenGiangVien" runat="server" CssClass="cssManField" 
                        Text="Tên giảng viên" />
		                    </td>
                <td align="left" style="width:10%;">
			        <asp:DropDownList ID="m_cbo_gvien" runat="server" Width="96%">
                    </asp:DropDownList>
		                    </td>
                         <td align="left" style="width:1%;"> 
                             &nbsp;</td>
                <td align="left" style="width:5%;">
			       
			        <asp:Label ID="lblLoaiHopDong" runat="server" CssClass="cssManField" 
                        Text="Loại hợp đồng" />
		                    </td>
                <td align="left" style="width:10%;">
			        <asp:DropDownList ID="m_cbo_dm_loai_hop_dong" runat="server" 
                        CssClass="cssDorpdownlist" Width="96%" />
                            </td>
                <td align="left" style="width:1%;">&nbsp;</td>
                 <td align="right" style="width:5%;">
			       
			         &nbsp;</td>
                <td align="left" style="width:10%;">
			        &nbsp;</td>
                <td align="left" style="width:1%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			        <asp:Label ID="lblMon1" runat="server" CssClass="cssManField" Text="Môn 1" />
                </td>
                <td align="left" style="width:10%;">
		            <asp:DropDownList ID="m_cbo_dm_mon_hoc_1" runat="server" 
                        CssClass="cssDorpdownlist" Width="96%" />
                </td>
                     <td align="left" style="width:1%;">
                         &nbsp;</td>
                <td align="right" style="width:5%;">
			        <asp:Label ID="lblMon2" runat="server" CssClass="cssManField" Text="Môn 2" />
		                    </td>
                <td align="left" style="width:10%;">
			
		            <asp:DropDownList ID="m_cbo_dm_mon_hoc_2" runat="server" 
                        CssClass="cssDorpdownlist" Width="96%" />
		                    </td>
                      <td align="left" style="width:1%;">
                          &nbsp;</td>
                 <td align="right" style="width:5%;">
			       
			         <asp:Label ID="lblMon3" runat="server" CssClass="cssManField" Text="Môn 3" />
                </td>
                <td align="left" style="width:10%;">
			        <asp:DropDownList ID="m_cbo_dm_mon_hoc_3" runat="server" 
                        CssClass="cssDorpdownlist" Width="96%" />
                </td>
                <td align="left" style="width:1%;">&nbsp;</td>
            </tr>
               <tr>
                   <td align="right" style="width:5%;">
                       <asp:Label ID="lblMon4" runat="server" CssClass="cssManField" Text="Môn 4" />
                   </td>
                   <td align="left" style="width:10%;">
                       <asp:DropDownList ID="m_cbo_dm_mon_hoc_4" runat="server" 
                           CssClass="cssDorpdownlist" Width="96%" />
                   </td>
                   <td align="left" style="width:1%;">
                       &nbsp;</td>
                   <td align="right" style="width:5%;">
                       <asp:Label ID="lblMon5" runat="server" CssClass="cssManField" Text="Môn 5" />
                   </td>
                   <td align="left" style="width:10%;">
                       <asp:DropDownList ID="m_cbo_dm_mon_hoc_5" runat="server" 
                           CssClass="cssDorpdownlist" Width="96%" />
                   </td>
                   <td align="left" style="width:1%;">
                       &nbsp;</td>
                   <td align="right" style="width:5%;">
                       <asp:Label ID="lblMon6" runat="server" CssClass="cssManField" Text="Môn 6" />
                   </td>
                   <td align="left" style="width:10%;">
                       <asp:DropDownList ID="m_cbo_dm_mon_hoc_6" runat="server" 
                           CssClass="cssDorpdownlist" Width="96%" />
                   </td>
                   <td align="left" style="width:1%;">
                       &nbsp;</td>
               </tr>
               <tr>
                   <td align="right" style="width:5%;">
                       <asp:Label ID="lblNgayHieuLuc" runat="server" CssClass="cssManField" 
                           Text="Ngày hiệu lực" />
                   </td>
                   <td align="left" style="width:10%;">
                       <ew:CalendarPopup ID="m_dat_ngay_hieu_luc" runat="server" 
                           ControlDisplay="TextBoxImage" Culture="vi-VN" DisableTextboxEntry="False" 
                           GoToTodayText="Hôm nay:" ImageUrl="~/Images/cal.gif" Nullable="True" 
                           NullableLabelText="" ShowGoToToday="True" Text="" Width="70%">
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
                   <td align="left" style="width:1%;">
                       &nbsp;</td>
                   <td align="right" style="width:5%;">
                       <asp:Label ID="lblNgayKetThuc" runat="server" CssClass="cssManField" 
                           Text="Ngày kết thúc" />
                   </td>
                   <td align="left" style="width:10%;">
                       <ew:CalendarPopup ID="m_dat_ngay_ket_thuc" runat="server" 
                           ControlDisplay="TextBoxImage" Culture="vi-VN" DisableTextboxEntry="False" 
                           GoToTodayText="Hôm nay:" ImageUrl="~/Images/cal.gif" Nullable="True" 
                           NullableLabelText="" ShowGoToToday="True" Text="" Width="70%">
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
                   <td align="left" style="width:1%;">
                       &nbsp;</td>
                   <td align="right" style="width:5%;">
                       &nbsp;</td>
                   <td align="left" style="width:10%;">
                       &nbsp;</td>
                   <td align="left" style="width:1%;">
                   </td>
               </tr>
            <tr>
                <td align="right" style="width:5%;">
			<asp:label id="lblTrangThaiHopDong" CssClass="cssManField" runat="server" 
                Text="Trạng thái hợp đồng" />
                </td>
                <td align="left" style="width:10%;">
		    <asp:DropDownList id="m_cbo_dm_trang_thai_hop_dong" runat="server" Width="96%" 
                        CssClass="cssDorpdownlist"  />
                </td>
                     <td align="left" style="width:1%;">
                         &nbsp;</td>
                <td align="right" style="width:5%;">
			        <asp:Label ID="lblGiaTriHopDong" runat="server" CssClass="cssManField" 
                        Text="Giá trị hợp đồng" />
		                    </td>
                <td align="left" style="width:10%;">
			          <asp:TextBox  ID="m_txt_gia_tri_hop_dong" CssClass="csscurrency"   Width="70%"
                        runat="server"></asp:TextBox> 
		                    &nbsp;<asp:Label ID="lblMon7" runat="server" CssClass="cssManField" 
                        Text="VNĐ" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ErrorMessage="Invalid Price" Text="*"
    ValidationGroup="complete" EnableClientScript="true" ControlToValidate="m_txt_gia_tri_hop_dong"
    ValidationExpression="^\d+(\.\d\d)?$" Display="Dynamic" runat="server"/>
    <asp:CompareValidator runat="server" id="CompareValidator1" Operator="GreaterThanEqual" Type="Currency"
        Display="Dynamic" ValueToCompare="0" ControlToValidate="m_txt_gia_tri_hop_dong" ErrorMessage = "Giá trị nhập không đúng định dạng" />
		                    </td>
                      <td align="left" style="width:1%;">
                          &nbsp;</td>
                 <td align="right" style="width:5%;">
			       
			<asp:label id="lblThueSuat" CssClass="cssManField" runat="server" 
                Text="Thuế suất (%)" />
		                    </td>
                <td align="left" style="width:10%;">
                <ew:NumericBox  id="m_txt_thue_suat" Width="96%" TextAlign="Right" runat="server"></ew:NumericBox> 
                         </td>
                <td align="left" style="width:1%;">
                         &nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			<asp:label id="lblHocLieu" CssClass="cssManField" runat="server" 
                Text="Là hợp đồng học liệu" />
		                    </td>
                <td align="left" style="width:10%;">
			        <asp:RadioButtonList ID="m_rbt_hoclieu_yn" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="Y">Có</asp:ListItem>
                        <asp:ListItem Value="N" Selected="True">Không</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                     <td align="left" style="width:1%;">
                         &nbsp;</td>
                <td align="right" style="width:5%;">
			<asp:label id="lblVanHanh" CssClass="cssManField" runat="server" 
                Text="Là hợp đồng vận hành" />
		                    </td>
                <td align="left" style="width:10%;">
			        <asp:RadioButtonList ID="m_rbt_bt_vanhanh_yn" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="Y" Selected="True">Có</asp:ListItem>
                        <asp:ListItem Value="N">Không</asp:ListItem>
                    </asp:RadioButtonList>
		                    </td>
                     <td align="left" style="width:1%;">
                         &nbsp;</td>
                 <td align="right" style="width:5%;">
			<asp:label id="lblco_so_hd" CssClass="cssManField" runat="server" 
                Text="Đã cấp số hợp đồng?" />
		                    </td>
                <td align="left" style="width:10%;">
			        <asp:RadioButtonList ID="m_rbt_co_so_hd_yn" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="Y" Selected="True">Có</asp:ListItem>
                        <asp:ListItem Value="N">Không</asp:ListItem>
                    </asp:RadioButtonList>
		                    </td>            
                         <td align="left" style="width:1%;"></td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
                    <asp:Label ID="lblGhiChu" runat="server" CssClass="cssManField" 
                        Text="Ghi chú" />
                </td>
                <td align="left" colspan="7">
                    <asp:TextBox ID="m_txt_ghi_chu1" runat="server" CssClass="cssTextBox" 
                        MaxLength="64" Width="96%" />
                </td>
                <td align="left" style="width:1%;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
                    <asp:Label ID="lblGhiChu1" runat="server" CssClass="cssManField" 
                        Text="Ghi chú 2" />
                </td>
                <td align="left" colspan="7">    
			        <asp:TextBox ID="m_txt_ghi_chu2" runat="server" CssClass="cssTextBox" 
                        MaxLength="64" Width="96%" />
                </td> 
            </tr>
               <tr>
                   <td align="right" style="width:5%;">
                       <asp:Label ID="lblGhiChu2" runat="server" CssClass="cssManField" 
                           Text="Ghi chú 3" />
                   </td>
                   <td align="left" colspan="7">
                       <asp:TextBox ID="m_txt_ghi_chu3" runat="server" CssClass="cssTextBox" 
                           MaxLength="64" Width="96%" />
                   </td>
               </tr>
               <tr>
                   <td align="right" style="width:5%;">
                       <asp:Label ID="lblGhiChu3" runat="server" CssClass="cssManField" 
                           Text="Ghi chú 4" />
                   </td>
                   <td align="left" colspan="7">
                       <asp:TextBox ID="m_txt_ghi_chu4" runat="server" CssClass="cssTextBox" 
                           MaxLength="64" Width="96%" />
                   </td>
               </tr>
               <tr>
                   <td align="right" style="width:5%;">
                       &nbsp;</td>
                   <td align="left" style="width:10%;">
                       &nbsp;</td>
                   <td align="left" style="width:1%;">
                       &nbsp;</td>
                   <td align="left" style="width:5%;">
                       &nbsp;</td>
                   <td align="left" style="width:10%;">
                       &nbsp;</td>
                   <td align="left" style="width:1%;">
                       &nbsp;</td>
                   <td align="right" style="width:5%;">
                       &nbsp;</td>
                   <td align="left" style="width:10%;">
                       &nbsp;</td>
               </tr>
            <tr>
                <td align="right" style="width:5%;">
			        &nbsp;</td>
                <td align="left" style="width:1%;">
			        <asp:button id="m_cmd_luu_du_lieu" accessKey="s" CssClass="cssButton" 
                runat="server" Width="98px" Text="Lưu dữ liệu" 
                        Height="24px" onclick="m_cmd_luu_du_lieu_Click"  />
                </td>
			   <td align="left" style="width:1%;"></td>
                 <td align="left" style="width:5%;">
                     <asp:Button ID="m_cmd_luu_va_sinh_pl" runat="server" accessKey="s" 
                        Height="25px"
                         Text="Lưu HD &amp; sinh phụ lục" Width="151px" 
                         onclick="m_cmd_luu_va_sinh_pl_Click" />
                </td>
                <td align="left" style="width:10%;">
                 <asp:button id="m_cmd_thoat" CssClass="cssButton" 
                runat="server" Width="98px" Text="Thoát" 
                        Height="25px" CausesValidation="False" onclick="m_cmd_thoat_Click"  />
                 </td>     
                <td align="left" style="width:1%;"></td>
            </tr>
        </table>
        </asp:Panel>     
        </td>
    </tr>  
    <tr>
		<td class="cssPageTitleBG" colspan="3">
		    <asp:label id="Label11" runat="server" CssClass="cssPageTitle" 
                Text="Kết quả lọc dữ liệu"/>
		</td>
	</tr>	
    <tr>
		<td align="left">
        &nbsp;<asp:button id="cmd_them_moi" accessKey="c" CssClass="cssButton" 
                runat="server" Width="98px" Text="Tạo mới(c)" 
                Height="27px" onclick="cmd_them_moi_Click"/><br />
                <asp:Label ID="m_lbl_thong_bao" CssClass="cssManField" runat="server"></asp:Label>
                <asp:HiddenField ID="hdf_id_gv" runat="server" />
        </td>
        <td >
		    &nbsp;</td>
	</tr>	
	<tr>
		<td align="center" colspan="3" style="height:450px;" valign="top">
		    &nbsp;
   <asp:GridView ID="m_grv_dm_danh_sach_hop_dong_khung" AllowPaging="True" 
                runat="server" AutoGenerateColumns="False" 
                Width="101%" DataKeyNames="ID"
                CellPadding="4" ForeColor="#333333" 
            AllowSorting="True" 
                onpageindexchanging="m_grv_dm_danh_sach_hop_dong_khung_PageIndexChanging" 
                onrowdeleting="m_grv_dm_danh_sach_hop_dong_khung_RowDeleting" >
                  <AlternatingRowStyle BackColor="White" />
                <Columns>
                <asp:TemplateField HeaderText="Xóa">
                    <ItemTemplate> <asp:LinkButton ToolTip="Xóa" ID = "lbt_delete" runat="server"
                     CommandName="Delete" OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')">
                      <img src="/TRMProject/Images/Button/deletered.png" alt="Delete" />
                     </asp:LinkButton>
                    </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Sửa">
                    <ItemTemplate> <asp:HyperLink ToolTip="Sửa" ImageUrl="/TRMProject/Images/Button/edit.png" ID = "lbt_edit" runat="server"
                     NavigateUrl='<%# "/TRMProject/ChucNang/F306_HopDongKhungGiangVien.aspx?mode=edit&id_hd="+Eval("ID") %>'></asp:HyperLink>
                    </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Phụ lục hợp đồng">
                    <ItemTemplate> <asp:HyperLink ToolTip="Phụ lục hợp đồng" ImageUrl="/TRMProject/Images/Button/detail.png" ID = "lbt_phu_luc_hop_dong" runat="server"
                     NavigateUrl='<%# "/TRMProject/ChucNang/F307_PhuLucHopDong.aspx?id_hd="+Eval("ID") %>'></asp:HyperLink>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                     <asp:BoundField DataField="SO_HOP_DONG" HeaderText="Số hợp đồng" 
                        Visible="true">
                        <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle></asp:BoundField>
                         <asp:BoundField DataField="NGAY_KY" HeaderText="Ngày ký" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false" />
                        <asp:BoundField DataField="LOAI_HOP_DONG" HeaderText="Loại hợp đồng">
                    </asp:BoundField>
                     <asp:BoundField DataField="DON_VI_QUAN_LY" HeaderText="Đơn vị quản lý">
                    </asp:BoundField>
                        <asp:BoundField DataField="DON_VI_THANH_TOAN" HeaderText="Đơn vị thanh toán">
                    </asp:BoundField>
                     <asp:BoundField DataField="FIRST_MON" HeaderText="Môn 1" />
                     <asp:BoundField DataField="SEC_MON" HeaderText="Môn 2" />
                     <asp:BoundField DataField="THIR_MON" HeaderText="Môn 3" />
                     <asp:BoundField DataField="FOURTH_MON" HeaderText="Môn 4" />
                     <asp:BoundField DataField="FITH_MON" HeaderText="Môn 5" />
                     <asp:BoundField DataField="SIXTH_MON" HeaderText="Môn 6" />
                     <asp:BoundField DataField="NGAY_HIEU_LUC" HeaderText="Ngày hiệu lực" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false">
                    </asp:BoundField>
                    <asp:BoundField DataField="NGAY_KET_THUC_DU_KIEN" HeaderText="Ngày kết thúc " DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false">
                    </asp:BoundField>
                    <asp:BoundField DataField="TRANG_THAI_HOP_DONG" HeaderText="Trạng thái hợp đồng">
                    </asp:BoundField>
                     <asp:BoundField DataField="MA_PO_PHU_TRACH" HeaderText="Mã PO Phụ trách">
                    </asp:BoundField>
                     <asp:BoundField ItemStyle-HorizontalAlign="Right" DataField="GIA_TRI_HOP_DONG" DataFormatString="{0:N0}" HeaderText="Giá trị hợp đồng" />
                    <asp:BoundField DataField="THUE_SUAT" DataFormatString="{0:N1}%" HeaderText="Thuế suất(%)">
                    </asp:BoundField>
                    <asp:TemplateField>
                    <HeaderTemplate>Làm học liệu?</HeaderTemplate>
                    <ItemTemplate>
                    <label><%# mapping_hl(Eval("HOC_LIEU_YN").ToString())%></label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField>
                       <HeaderTemplate>Vận hành?</HeaderTemplate>
                    <ItemTemplate>
                    <label><%# mapping_vh(Eval("VAN_HANH_YN").ToString())%></label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                      <asp:TemplateField>
                       <HeaderTemplate>Có số hợp đồng?</HeaderTemplate>
                    <ItemTemplate>
                    <label><%# mapping_cs(Eval("CO_SO_HD_YN").ToString())%></label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                      <asp:BoundField DataField="GHI_CHU" HeaderText="Ghi chú" />
                     <asp:BoundField DataField="GHI_CHU2" HeaderText="Ghi chú 2" />
                     <asp:BoundField DataField="GHI_CHU3" HeaderText="Ghi chú 3" />
                     <asp:BoundField DataField="GHI_CHU4" HeaderText="Ghi chú 4" />
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

