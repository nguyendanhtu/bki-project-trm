<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F501_DuToanHopDongVanHanh.aspx.cs" Inherits="ChucNang_F501_DuToanHopDongVanHanh" %>
<%@ Import Namespace ="IP.Core.IPCommon" %>
<%@ Register assembly="eWorld.UI" namespace="eWorld.UI" tagprefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
     <script type="text/javascript">
         function openPopUp() {
             var popUrl = 'F601_CheckSoHopDong.aspx?loai=VH&sohd=' + document.getElementById('<%= m_txt_so_hop_dong.ClientID %>').value;
             var name = 'KiemTraSoHopDong';
             var appearence = 'dependent=yes,menubar=no,resizable=no,' +
                                          'status=no,toolbar=no,titlebar=no,' +
                                          'left=5,top=280,width=990px,height=540px';
             var openWindow = window.open(popUrl, name, appearence);
             openWindow.focus();
         }
         function openPopUpMaLopMon() {
             var popUrl = 'F605_CheckMaLopMon.aspx?malop=' + document.getElementById('<%= m_txt_ma_lop_mon.ClientID%>').value + '&sohd=' + document.getElementById('<%= m_txt_so_hop_dong.ClientID %>').value;
             var name = 'KiemTraSoHopDong';
             var appearence = 'dependent=yes,menubar=no,resizable=no,' +
                                          'status=no,toolbar=no,titlebar=no,' +
                                          'left=5,top=280,width=990px,height=540px';
             var openWindow = window.open(popUrl, name, appearence);
             openWindow.focus();
         }
         function formatCurrency(num) {
             num = num.toString().replace(/\$|\,/g, '');
             if (isNaN(num))
                 num = "0";
             sign = (num == (num = Math.abs(num)));
             num = Math.floor(num * 100 + 0.50000000001);
             num = Math.floor(num / 100).toString();
             for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++)
                 num = num.substring(0, num.length - (4 * i + 3)) + ',' +
            num.substring(num.length - (4 * i + 3));
             return (((sign) ? '' : '-') + num);
         }
         function calculate_money() {
             var dc_so_tien_thanh_toan_chua_xu_ly = document.getElementById('<%=  m_txt_so_tien_thanh_toan.ClientID%>').value.toString();
             if (dc_so_tien_thanh_toan_chua_xu_ly == '') {
                 document.getElementById('<%= m_lbl_khong_so_tien_thanh_toan.ClientID %>').innerHTML = 'Bạn chưa nhập số tiền thanh toán';
                 return;
             } else document.getElementById('<%= m_lbl_khong_so_tien_thanh_toan.ClientID %>').innerHTML = '';
             var v_arr = new Array();
             var v_dc_so_tien_thuc = "";
             v_arr = dc_so_tien_thanh_toan_chua_xu_ly.split(',');
             for (var i = 0; i < v_arr.length; i++) {
                 v_dc_so_tien_thuc += v_arr[i];
             }
             var v_dc_so_tien_thanh_toan = parseFloat(v_dc_so_tien_thuc);

             // Lớn hơn hoặc bằng 1 triệu thì có tính thuế
             if (v_dc_so_tien_thanh_toan >= 1000000) {
                 document.getElementById('<%=  m_txt_so_tien_thue1.ClientID%>').value = formatCurrency(v_dc_so_tien_thanh_toan / 10);
                 document.getElementById('<%=  m_txt_so_tien_thuc_nhan.ClientID%>').value =formatCurrency(9 * v_dc_so_tien_thanh_toan / 10);
             }
             else {
                 if (v_dc_so_tien_thanh_toan < 1000000) {
                     document.getElementById('<%=  m_txt_so_tien_thue1.ClientID%>').value = 0;
                     document.getElementById('<%=  m_txt_so_tien_thuc_nhan.ClientID%>').value =formatCurrency(v_dc_so_tien_thanh_toan);
                 }
             }
         }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table  cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
<tr>
		<td class="cssPageTitleBG">
		    <asp:label id="lblUser" runat="server" CssClass="cssPageTitle" 
                Text="Lên bảng kê hợp đồng vận hành"/>
		</td>
	</tr>
	<tr>
		<td>
		    <asp:validationsummary id="vdsCategory" runat="server" CssClass="cssManField" Font-Bold="true" />
		</td>
	</tr>
    <tr>
		<td>
        <table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0"> 
            <tr>
                <td align="left" colspan="5">
			       
                          <asp:Label ID="m_lbl_thong_bao1" CssClass="cssManField" runat="server"></asp:Label>
			       
                         </td>
                <td align="left" style="width:10%;">&nbsp;</td>
                <td align="left" style="width:1%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:14%;">
			       
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
                <td align="right" style="width:5%;">
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
                <td align="right" style="width:7%;">
			       
			<asp:label id="lblMon4" CssClass="cssManField" runat="server" 
                Text="Số hợp đồng khung(*)" />
			       
                </td>
                <td align="left" colspan="3">

                <asp:TextBox ID="m_txt_so_hop_dong" Width="96%" 
                        runat="server" CssClass="cssTextBox"></asp:TextBox>
                        </td>
                <td align="left" style="width:10%;">
			
			        &nbsp;&nbsp;
			
			        <asp:button id="m_cmd_check_so_hd" accessKey="c" CssClass="cssButton" 
                runat="server" Width="98px" Text="Kiểm tra HĐ" 
                        Height="24px" onclick="m_cmd_check_so_hd_Click" CausesValidation="false"/>
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
                <td align="right" style="width:5%;height:30px;">
			       
			<asp:label id="lblMon6" CssClass="cssManField" runat="server" 
                Text="Các lớp môn phụ trách(*)" />
			       
                </td>
                <td align="left" colspan="3">    
			
                <asp:TextBox ID="m_txt_ma_lop_mon" CssClass="cssTextBox" Width="96%" 
                        runat="server"></asp:TextBox>
                        </td> 
                <td align="left" style="width:10%;">    
                        <asp:RequiredFieldValidator ID="req_vali4" runat="server" 
                         ErrorMessage="Bạn phải nhập mã lớp môn" Text="*" 
                        ControlToValidate="m_txt_ma_lop_mon"> </asp:RequiredFieldValidator>
			        <asp:button id="m_cmd_check_ma_lop_mon" accessKey="c" CssClass="cssButton" 
                runat="server" Width="98px" Text="Kiểm tra LM" 
                        Height="24px"  CausesValidation="false" 
                            onclick="m_cmd_check_ma_lop_mon_Click"/>
                </td> <td align="left" colspan="2">(Ví dụ: MAN304.C2, MAN304.C3-C5-C7)</td>
                <td align="left" style="width:10%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%; height:30px;">
			       
			<asp:label id="lblMon7" CssClass="cssManField" runat="server" 
                Text="Tên các môn phụ trách" />
			       
                </td>
                <td align="left" colspan="4">    
			
                   
                <asp:TextBox ID="m_txt_ten_cac_mon_phu_trach" Width="96%" TextMode="MultiLine" Rows="3" 
                        runat="server" CssClass="cssTextBox"></asp:TextBox>
                        </td> 
                <td align="left" colspan="2">(Ví dụ: Marketing căn bản, Quản trị Marketing)</td>
                <td align="left" style="width:10%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%; height:30px;">
			       
			<asp:label id="lblMon8" CssClass="cssManField" runat="server" 
                Text="Thời gian lớp môn" />
			       
                </td>
                <td align="left" colspan="3">    
			
                   
                <asp:TextBox ID="m_txt_thoi_gian_lop_mon" CssClass="cssTextBox" Width="96%" 
                        runat="server"></asp:TextBox>
                        </td> 
                <td align="left" colspan="2">Ví dụ: 01/11/2011 - 30/11/2011</td>
                <td align="left" style="width:10%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%; height:30px;">
			       
			<asp:label id="lblMon9" CssClass="cssManField" runat="server" 
                Text="Hệ số quy mô lớp" />
			       
                </td>
                <td align="left">    
			
              <asp:TextBox  ID="m_txt_he_so_quy_mo" CssClass="csscurrency" Width="96%" 
                        runat="server"></asp:TextBox> 
                        </td> 
                <td align="left" style="width:1%;">			       
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ErrorMessage="Invalid Price" Text="*"
    ValidationGroup="complete" EnableClientScript="true" ControlToValidate="m_txt_he_so_quy_mo"
    ValidationExpression="^\d+(\.\d\d)?$" Display="Dynamic" runat="server"/>
    <asp:CompareValidator runat="server" id="CompareValidator3" Operator="GreaterThanEqual" Type="Currency"
        Display="Dynamic" ValueToCompare="0" ControlToValidate="m_txt_he_so_quy_mo" ErrorMessage = "Giá trị nhập không đúng định dạng" />
                        </td> 
                <td align="left" colspan="2">&nbsp;</td>
                <td align="left" style="width:10%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			       
			<asp:label id="lbltan_suat" CssClass="cssManField" runat="server" 
                Text="Số tiền thanh toán(VNĐ)(*)" />
			       
                </td>
                <td align="left" style="width:10%;">    
                <asp:TextBox  ID="m_txt_so_tien_thanh_toan" CssClass="csscurrency" Width="96%" 
                        runat="server" onblur="calculate_money()"></asp:TextBox> 
                        </td> 
                <td align="left" style="width:1%;">			       
                        <asp:RequiredFieldValidator ID="req_vali3" runat="server" 
                         ErrorMessage="Bạn phải nhập số tiền thanh toán" Text="*" 
                        ControlToValidate="m_txt_so_tien_thanh_toan"> </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ErrorMessage="Invalid Price" Text="*"
    ValidationGroup="complete" EnableClientScript="true" ControlToValidate="m_txt_so_tien_thanh_toan"
    ValidationExpression="^\d+(\.\d\d)?$" Display="Dynamic" runat="server"/>
    <asp:CompareValidator runat="server" id="compPrimeNumberPositive" Operator="GreaterThanEqual" Type="Currency"
        Display="Dynamic" ValueToCompare="0" ControlToValidate="m_txt_so_tien_thanh_toan" ErrorMessage = "Giá trị nhập không đúng định dạng" />
                       </td>
                 <td align="left" colspan="2">
			       
			<asp:label id="m_lbl_khong_so_tien_thanh_toan" CssClass="cssManField" runat="server" 
                Text=""/>
                </td>
                <td align="left" style="width:10%;">    
			        &nbsp;</td> <td align="left" style="width:1%;"></td>
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
                        &nbsp; 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                         ErrorMessage="Bạn phải nhập số tiền thuế" Text="*" 
                        ControlToValidate="m_txt_so_tien_thue1"> </asp:RequiredFieldValidator>	
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ErrorMessage="Invalid Price" Text="*"
    ValidationGroup="complete" EnableClientScript="true" ControlToValidate="m_txt_so_tien_thue1"
    ValidationExpression="^\d+(\.\d\d)?$" Display="Dynamic" runat="server"/>
<asp:CompareValidator runat="server" id="CompareValidator2" Operator="GreaterThanEqual" Type="Currency"
        Display="Dynamic" ValueToCompare="0" ControlToValidate="m_txt_so_tien_thue1" ErrorMessage = "Giá trị nhập không đúng định dạng" /></td>
                <td align="right" style="width:7%;">
			       
			<asp:label id="lbltan_suat1" CssClass="cssManField" runat="server" 
                Text="Số tiền thực nhận (VNĐ)" />
			       
                </td>
                <td align="left" style="width:10%;">    
                <asp:TextBox  ID="m_txt_so_tien_thuc_nhan" CssClass="csscurrency" Width="96%" 
                        runat="server"></asp:TextBox>
                        </td> <td align="left" style="width:1%;">&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                         ErrorMessage="Bạn phải nhập số tiền thực nhận" Text="*" 
                        ControlToValidate="m_txt_so_tien_thuc_nhan"> </asp:RequiredFieldValidator>	
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ErrorMessage="Invalid Price" Text="*"
    ValidationGroup="complete" EnableClientScript="true" ControlToValidate="m_txt_so_tien_thuc_nhan"
    ValidationExpression="^\d+(\.\d\d)?$" Display="Dynamic" runat="server"/>
    <asp:CompareValidator runat="server" id="CompareValidator1" Operator="GreaterThanEqual" Type="Currency"
        Display="Dynamic" ValueToCompare="0" ControlToValidate="m_txt_so_tien_thuc_nhan" ErrorMessage = "Giá trị nhập không đúng định dạng" /></td>
                 <td align="right" style="width:5%;">&nbsp;</td>
                <td align="left" style="width:10%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			       
			<asp:label id="lbltan_suat3" CssClass="cssManField" runat="server" 
                Text="Trạng thái thanh toán" />
			       
                </td>
                <td align="left" colspan="3">    
              <asp:DropDownList ID="m_cbo_trang_thai_thanh_toan" Enabled="false" Width="96%" runat="server">
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
                <td align="left" colspan="3">(Ví dụ: Thanh lý hợp đồng; Lương giảng viên tháng 11)</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			       
			<asp:label id="lblMon10" CssClass="cssManField" runat="server" 
                Text="Ghi chú 1" />
			       
                </td>
                <td align="left" colspan="4">
                <asp:TextBox ID="m_txt_ghi_chu_4" CssClass="cssTextBox" Width="98%" 
                        runat="server"></asp:TextBox>
                         </td> 
                <td align="left" style="width:1%;">&nbsp;</td>
                 <td align="right" style="width:5%;">&nbsp;</td>
                <td align="left" style="width:10%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			       
			<asp:label id="lblMon11" CssClass="cssManField" runat="server" 
                Text="Ghi chú 2" />
			       
                </td>
                <td align="left" colspan="4">
                <asp:TextBox ID="m_txt_ghi_chu_5" CssClass="cssTextBox" Width="98%" 
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
			        <asp:button id="m_cmd_luu_du_lieu" accessKey="c" CssClass="cssButton" 
                runat="server" Width="98px" Text="Tạo bảng kê" 
                        Height="24px" onclick="m_cmd_luu_du_lieu_Click"/>
                </td>
			   <td align="left" style="width:1%;">
                     <asp:Button ID="m_cmd_cap_nhat_du_toan" runat="server" accessKey="s" 
                         CssClass="cssButton" Height="24px" 
                         Text="Cập nhật bản kê" Width="98px" 
                         onclick="m_cmd_cap_nhat_du_toan_Click" />
                 </td>
                 <td align="center" colspan="2">
                    <asp:Button ID="m_cmd_xuat_excel" runat="server" CausesValidation="False" 
                        CssClass="cssButton" Height="25px"  Text="Xuất Excel" 
                        Width="98px" onclick="m_cmd_xuat_excel_Click"/>
                 </td>
                <td align="left" style="width:1%;">
                    <asp:Button ID="m_cmd_xoa_trang" runat="server" CausesValidation="False" 
                        CssClass="cssButton" Height="25px"  Text="Xóa trắng" 
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
		    <asp:label id="m_lbl_result" runat="server" CssClass="cssPageTitle" 
                Text="Danh sách bảng kê hợp đồng vận hành"/>
		</td>
	</tr>	
    <tr>
		<td align="left">
                          <asp:Label ID="m_lbl_thong_bao" CssClass="cssManField" runat="server"></asp:Label>
                <asp:HiddenField ID="hdf_id_gv" runat="server" />
                <asp:HiddenField ID="hdf_id_trang_thai_thanh_toan_cu" runat="server" />
                <asp:HiddenField ID="hdf_check_click_kiem_tra_so_hd" runat="server" />
                <asp:HiddenField ID="hdf_check_click_kiem_tra_lop_mon" runat="server" />
        </td>
        <td >
		    &nbsp;</td>
	</tr>	
	<tr>
		<td align="center" colspan="2" style="height:450px;" valign="top">
		    &nbsp;
   <asp:GridView ID="m_grv_danh_sach_du_toan" AllowPaging="True" 
                runat="server" AutoGenerateColumns="False" 
                Width="100%" DataKeyNames="ID"
                CellPadding="4" ForeColor="#333333" 
            AllowSorting="True" onrowdeleting="m_grv_danh_sach_du_toan_RowDeleting" 
                onselectedindexchanging="m_grv_danh_sach_du_toan_SelectedIndexChanging" 
                onpageindexchanging="m_grv_danh_sach_du_toan_PageIndexChanging" PageSize="20">
                  <AlternatingRowStyle BackColor="White" />
                <Columns>
                <asp:TemplateField HeaderText="Xóa">
                    <ItemTemplate> <asp:LinkButton ToolTip="Xóa" ID = "lbt_delete" runat="server"
                     CommandName="Delete" CausesValidation="false" OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')">
                      <img src="/TRMProject/Images/Button/deletered.png" alt="Delete" />
                     </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="3%" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Sửa">
                    <ItemTemplate>
                     <asp:LinkButton CausesValidation="false" CommandName="Select" ToolTip="Sửa" ID = "lbt_edit" runat="server">
                    <img src='/TRMProject/Images/Button/edit.png' alt='Sửa' />
                    </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="3%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Chi tiết bảng kê">
                    <ItemTemplate> <asp:HyperLink ToolTip="Chi tiết bảng kê" ImageUrl="/TRMProject/Images/Button/detail.png" ID = "lbt_phu_luc_hop_dong" runat="server"
                     NavigateUrl='<%# "/TRMProject/ChucNang/F603_ThanhToanChiTiet.aspx?id_gdtt="+Eval("ID") %>'></asp:HyperLink>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="3%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="SO_PHIEU_THANH_TOAN" HeaderText="Mã đợt thanh toán">
                    <ItemStyle Width="14%" HorizontalAlign="Left" />
                    </asp:BoundField>
                     <asp:TemplateField HeaderText="Số hợp đồng" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%# get_so_hd_khung_by_id_hd(CIPConvert.ToDecimal(Eval("ID_HOP_DONG_KHUNG")))%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Mã giảng viên" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%# mapping_magv_by_id(CIPConvert.ToDecimal(Eval("ID_GIANG_VIEN")))%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="7%"></ItemStyle>
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Tên giảng viên" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%# Eval("TEN_GIANG_VIEN")%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="9%"></ItemStyle>
                    </asp:TemplateField> 
                     <asp:BoundField DataField="REFERENCE_CODE" HeaderText="Các lớp môn phụ trách">
                    <ItemStyle Width="7%" HorizontalAlign="Left" />
                    </asp:BoundField>
                     <asp:BoundField DataField="GHI_CHU_CAC_MON_PHU_TRACH" HeaderText="Tên các môn phụ trách">
                    <ItemStyle Width="7%" HorizontalAlign="Left" />
                    </asp:BoundField>
                     <asp:TemplateField HeaderText="Thời gian lớp môn" ItemStyle-HorizontalAlign="Left">
                       <ItemTemplate><%# mapping_thoi_gian_lop_mon(Eval("GHI_CHU_THOI_GIAN_LOP_MON"))%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="7%"></ItemStyle>
                    </asp:TemplateField> 
                     <asp:BoundField DataField="GHI_CHU_HE_SO_DON_GIA"
                        HeaderText="Hệ số quy mô lớp">
                     <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>
                     <asp:BoundField DataField="TONG_TIEN_THANH_TOAN" DataFormatString="{0:N0}" 
                        HeaderText="Tổng tiền thanh toán đợt này (VNĐ)">
                     <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>
                     <asp:BoundField DataField="SO_TIEN_THUE" DataFormatString="{0:N0}" HeaderText="Số tiền thuế (VNĐ)">
                     <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>
                     <asp:BoundField DataField="TONG_TIEN_THUC_NHAN" DataFormatString="{0:N0}" 
                        HeaderText="Tổng tiền thực nhận đợt này (VNĐ)">
                     <ItemStyle Width="7%" HorizontalAlign="Center" />
                    </asp:BoundField>
                     <asp:BoundField DataField="NGAY_THANH_TOAN" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày thanh toán">
                     <ItemStyle Width="10%" HorizontalAlign="Center" />
                    </asp:BoundField>
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

