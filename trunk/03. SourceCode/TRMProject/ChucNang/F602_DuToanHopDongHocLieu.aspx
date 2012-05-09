<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F602_DuToanHopDongHocLieu.aspx.cs" Inherits="ChucNang_F602_DuToanHopDongHocLieu" %>
<%@ Import Namespace ="IP.Core.IPCommon" %>
<%@ Register assembly="eWorld.UI" namespace="eWorld.UI" tagprefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">   
    <style type="text/css">
        .style1
        {
            width: 7%;
            height: 29px;
        }
        .style2
        {
            width: 10%;
            height: 29px;
        }
        .style3
        {
            width: 5%;
            height: 29px;
        }
        .style4
        {
            width: 1%;
            height: 29px;
        }
    </style>
    <script type="text/javascript">           
        function openPopUp() {
            var popUrl = 'F601_CheckSoHopDong.aspx?loai=HL&sohd=' + document.getElementById('<%= m_txt_so_hop_dong.ClientID %>').value;
            var name = 'KiemTraSoHopDong';
            var appearence = 'dependent=yes,menubar=no,resizable=no,' +
                                          'status=no,toolbar=no,titlebar=no,' +
                                          'left=5,top=280,width=990px,height=540px';
            var openWindow = window.open(popUrl, name, appearence);
            openWindow.focus();
        }
        function check_fill() {
            var str_so_hd = document.getElementById('<%= m_txt_so_hop_dong.ClientID %>').value;
            if (str_so_hd == "") {
                alert("Bạn chưa nhập số hợp đồng");
                return;
            }
        }
        function check_nhap() {
            var v_rdl_parent = document.getElementById('<%=  rdl_noi_dung_list.ClientID%>');
            var radio = document.getElementsByTagName('input');
            var v_str_loai_tt = ''; // Thanhly hay là Tamung
            for (var i = 0; i < radio.length; i++) {
                if (radio[i].checked) v_str_loai_tt = radio[i].value.toString();
            }
            var dc_tong_gia_tri_nghiem_thu_chua_xu_ly = document.getElementById('<%=  m_txt_gia_tri_nghiem_thu_thuc_te.ClientID%>').value.toString();
            if (v_str_loai_tt == 'Thanhly') {
                // Nếu là thanh lý mà không nhập tổng giá trị nghiệm thu thực tế
                if (dc_tong_gia_tri_nghiem_thu_chua_xu_ly == '') {
                    document.getElementById('<%= m_lbl_khong_nhap_nghiem_thu_thuc_te.ClientID %>').innerHTML = 'Hãy nhập tổng giá trị nghiệm thu thực tế';
                    return;
                } else document.getElementById('<%= m_lbl_khong_nhap_nghiem_thu_thuc_te.ClientID %>').innerHTML = '';
            } else document.getElementById('<%= m_lbl_khong_nhap_nghiem_thu_thuc_te.ClientID %>').innerHTML = '';
        }

        // Hàm này có tác dụng format tiền về dạng kế toán
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
        // Hàm này tính toán số tiền
        function calculate_money() {

            // Áp dụng tính tiền tự động
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

            // Lấy thông tin - Đây là tạm ứng hay thanh lý
            var v_rdl_parent = document.getElementById('<%=  rdl_noi_dung_list.ClientID%>');
            var radio = document.getElementsByTagName('input');
            var v_str_loai_tt = ''; // Thanhly hay là Tamung
            for (var i = 0; i < radio.length; i++) {
                if (radio[i].checked) v_str_loai_tt = radio[i].value.toString();
            }
            var dc_tong_gia_tri_nghiem_thu_chua_xu_ly = document.getElementById('<%=  m_txt_gia_tri_nghiem_thu_thuc_te.ClientID%>').value.toString();
            // Lớn hơn hoặc bằng 1 triệu thì có tính thuế và đây là thanh lý
            if (v_dc_so_tien_thanh_toan >= 1000000 && v_str_loai_tt == 'Thanhly') {
                // Xử lý số tiền thanh lý
                var v_arr_nghiem_thu = new Array();
                var v_dc_nghiem_thu = "";
                v_arr_nghiem_thu = dc_tong_gia_tri_nghiem_thu_chua_xu_ly.split(',');
                for (var i = 0; i < v_arr_nghiem_thu.length; i++) {
                    v_dc_nghiem_thu += v_arr_nghiem_thu[i];
                }
                var v_dc_nghiem_thu_da_xu_ly = parseFloat(v_dc_nghiem_thu); // Đây là số tiền nghiệm thu thực tế

                document.getElementById('<%=  m_txt_so_tien_thue1.ClientID%>').value = formatCurrency(v_dc_nghiem_thu_da_xu_ly / 10);
                document.getElementById('<%=  m_txt_so_tien_thuc_nhan.ClientID%>').value = formatCurrency(v_dc_so_tien_thanh_toan - v_dc_nghiem_thu_da_xu_ly / 10);
            }
            // Đây là tạm ứng hoặc số tiền thanh toán < 1,000,000
            else {
                    document.getElementById('<%=  m_txt_so_tien_thue1.ClientID%>').value = 0;
                    document.getElementById('<%=  m_txt_so_tien_thuc_nhan.ClientID%>').value = formatCurrency(v_dc_so_tien_thanh_toan);
                
            } 
        }
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<table  cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
<tr>
		<td class="cssPageTitleBG">
		    <asp:label id="lblUser" runat="server" CssClass="cssPageTitle" 
                Text="Lên bảng kê hợp đồng học liệu"/>
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
                <td align="right" style="width:12%;">
			       
			<asp:label id="lblTenGiangVien" CssClass="cssManField" runat="server" 
                Text="Đợt thanh toán" />
			       
                         </td>
                <td align="left" colspan="4">
              <asp:DropDownList ID="m_cbo_dot_thanh_toan" Width="96%" runat="server" CssClass="cssDorpdownlist"
                        AutoPostBack="true" 
                        onselectedindexchanged="m_cbo_dot_thanh_toan_SelectedIndexChanged" >
               </asp:DropDownList>
                         </td>
                <td align="left" style="width:10%;"></td>
                <td align="left" style="width:1%;"></td>
            </tr>
            <tr>
                <td align="right" style="width:7%;">
			       
			<asp:label id="lblMon4" CssClass="cssManField" runat="server" 
                Text="Số hợp đồng khung" />
			       
                </td>
                <td align="left" colspan="2">

                <asp:TextBox ID="m_txt_so_hop_dong" Width="96%" CssClass="cssTextBox"
                        runat="server"></asp:TextBox>
                        </td>
                <td align="right" style="width:3%;">
			        <asp:button id="m_cmd_check_so_hd" accessKey="c" CssClass="cssButton" 
                runat="server" Width="98px" Text="Kiểm tra" 
                        Height="24px"  CausesValidation="false" onclick="m_cmd_check_so_hd_Click"/>
                </td>
                <td align="left" style="width:10%;">
			
			        &nbsp;</td>
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
			        &nbsp;</td>
                <td align="left" style="width:10%;">    
			
                    &nbsp;</td> 
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
			       
			<asp:label id="lblMon6" CssClass="cssManField" runat="server" 
                Text="Nội dung thanh toán" />
			       
                </td>
                <td align="left" style="width:10%;">    
                    <asp:RadioButtonList ID="rdl_noi_dung_list" runat="server"
                        RepeatDirection="Horizontal" Width="98%" >
                        <asp:ListItem Value="Thanhly" Selected="True">Thanh lý</asp:ListItem>
                        <asp:ListItem Value="Tamung">Tạm ứng</asp:ListItem>
                    </asp:RadioButtonList></td> <td align="left" style="width:1%;">
			       
			<asp:label id="lbl_lan_so"  CssClass="cssManField" runat="server" 
                Text="đợt " />
			    <asp:DropDownList ID="m_cbo_lan_so" Width="40%" runat="server" CssClass="cssDorpdownlist">
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
               </asp:DropDownList>
                </td>
                 <td align="right" style="width:5%;">&nbsp;</td>
                <td align="left" style="width:10%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%; height:40px;">
			       
			<asp:label id="lblMon7" CssClass="cssManField" runat="server" 
                Text="Tổng giá trị nghiệm thu thực tế" />
                </td>
                <td align="left" style="width:10%;">  
                 <asp:TextBox  ID="m_txt_gia_tri_nghiem_thu_thuc_te" CssClass="csscurrency" Width="96%" onblur='check_nhap()'
                        runat="server"></asp:TextBox>  
                        </td> 
                <td align="left" style="width:1%;">			       
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" 
                            ErrorMessage="Invalid Price" Text="*"
    ValidationGroup="complete" EnableClientScript="true" ControlToValidate="m_txt_gia_tri_nghiem_thu_thuc_te"
    ValidationExpression="^\d+(\.\d\d)?$" Display="Dynamic" runat="server"/>
    <asp:CompareValidator runat="server" id="compPrimeNumberPositive0" Operator="GreaterThan" Type="Currency"
        Display="Dynamic" ValueToCompare="0" ControlToValidate="m_txt_gia_tri_nghiem_thu_thuc_te" 
                            ErrorMessage = "Giá trị nhập không đúng định dạng" />
                        </td>
                <td align="left" colspan="2">
			       
			<asp:label id="m_lbl_khong_nhap_nghiem_thu_thuc_te" CssClass="cssManField" runat="server" 
                Text=""/>
                </td>
                 <td align="right" style="width:5%;"></td>
                <td align="left" style="width:10%;"></td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			       
			<asp:label id="lbltan_suat" CssClass="cssManField" runat="server" 
                Text="Số tiền thanh toán đợt này (VNĐ) (*)" />
			       
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
                     <td align="left" style="width:1%;">&nbsp;</td>
                 <td align="right" style="width:5%;">&nbsp;</td>
                <td align="left" style="width:10%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			       
			<asp:label id="lbltan_suat0" CssClass="cssManField" runat="server" 
                Text="Trong đó:" Font-Underline= "true" Font-Bold="true" />
			       
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                         ErrorMessage="Bạn phải nhập số tiền thuế" Text="*" 
                        ControlToValidate="m_txt_so_tien_thue1"> </asp:RequiredFieldValidator>	       
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ErrorMessage="Invalid Price" Text="*"
    ValidationGroup="complete" EnableClientScript="true" ControlToValidate="m_txt_so_tien_thue1"
    ValidationExpression="^\d+(\.\d\d)?$" Display="Dynamic" runat="server"/>
<asp:CompareValidator runat="server" id="CompareValidator2" Operator="GreaterThanEqual" Type="Currency"
        Display="Dynamic" ValueToCompare="0" ControlToValidate="m_txt_so_tien_thue1" ErrorMessage = "Giá trị nhập không đúng định dạng" />
    </td>
                <td align="right" style="width:5%;">
			       
			<asp:label id="lbltan_suat1" CssClass="cssManField" runat="server" 
                Text="Số tiền thực nhận (VNĐ)" />
			       
                </td>
                <td align="left" style="width:10%;">  
                    <asp:TextBox  ID="m_txt_so_tien_thuc_nhan" CssClass="csscurrency" Width="96%" 
                        runat="server"></asp:TextBox>
                        </td> <td align="left" style="width:1%;">&nbsp;
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                         ErrorMessage="Bạn phải nhập số tiền thực nhận" Text="*" 
                        ControlToValidate="m_txt_so_tien_thuc_nhan"> </asp:RequiredFieldValidator>	
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ErrorMessage="Invalid Price" Text="*"
    ValidationGroup="complete" EnableClientScript="true" ControlToValidate="m_txt_so_tien_thuc_nhan"
    ValidationExpression="^\d+(\.\d\d)?$" Display="Dynamic" runat="server"/>
    <asp:CompareValidator runat="server" id="CompareValidator1" Operator="GreaterThanEqual" Type="Currency"
        Display="Dynamic" ValueToCompare="0" ControlToValidate="m_txt_so_tien_thuc_nhan" ErrorMessage = "Giá trị nhập không đúng định dạng" />
                </td>
                 <td align="right" style="width:5%;">&nbsp;</td>
                <td align="left" style="width:10%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			       
			<asp:label id="lbltan_suat3" CssClass="cssManField" runat="server" 
                Text="Trạng thái thanh toán" />
			       
                </td>
                <td align="left" colspan="3">    
              <asp:DropDownList ID="m_cbo_trang_thai_thanh_toan" Width="96%" Enabled="false" runat="server">
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
                <td align="left" colspan="3">
                <asp:TextBox ID="m_txt_mo_ta" CssClass="cssTextBox" Width="96%" 
                        runat="server"></asp:TextBox>
                         </td> 
                <td align="left" style="width:10%;">    
                    &nbsp;</td> <td align="left" style="width:1%;">&nbsp;</td>
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
                         Text="Cập nhật bảng kê" Width="101px" onclick="m_cmd_cap_nhat_du_toan_Click" 
                       />
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
                Text="Danh sách bảng kê hợp đồng học liệu"/>
		</td>
	</tr>	
    <tr>
		<td align="left">
                          <asp:Label ID="m_lbl_thong_bao" CssClass="cssManField" runat="server"></asp:Label>
                <asp:HiddenField ID="hdf_id_gv" runat="server" />
                <asp:HiddenField ID="hdf_id_trang_thai_thanh_toan_cu" runat="server" />
                <asp:HiddenField ID="hdf_check_click_kiem_tra_so_hd" runat="server" />
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
                onpageindexchanging="m_grv_danh_sach_du_toan_PageIndexChanging" 
                PageSize="20">
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
                     <asp:BoundField DataField="NGAY_THANH_TOAN" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày thanh toán">
                     <ItemStyle Width="8%" HorizontalAlign="Center" />
                    </asp:BoundField>
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
                      <asp:BoundField DataField="GIA_TRI_NGHIEM_THU_THUC_TE" DataFormatString="{0:N0}" HeaderText="Giá trị nghiệm thu thực tế (VNĐ)">
                     <ItemStyle Width="8%" HorizontalAlign="Center" />
                    </asp:BoundField>
                     <asp:BoundField DataField="TONG_TIEN_THANH_TOAN" DataFormatString="{0:N0}" 
                        HeaderText="Tổng tiền thanh toán đợt này (VNĐ)">
                     <ItemStyle Width="8%" HorizontalAlign="Center" />
                    </asp:BoundField>
                     <asp:BoundField DataField="SO_TIEN_THUE" DataFormatString="{0:N0}" HeaderText="Số tiền thuế (VNĐ)">
                     <ItemStyle Width="8%" HorizontalAlign="Center" />
                    </asp:BoundField>
                     <asp:BoundField DataField="TONG_TIEN_THUC_NHAN" DataFormatString="{0:N0}" 
                        HeaderText="Tổng tiền thực nhận đợt này (VNĐ)">
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

