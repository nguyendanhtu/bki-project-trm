<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F1302_DanhSachHopDongKhung.aspx.cs" Inherits="ChucNang_F1302_DanhSachHopDongKhung" %>
<%@ Register assembly="eWorld.UI" namespace="eWorld.UI" tagprefix="ew" %>
<%@ Import Namespace ="IP.Core.IPCommon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<style type="text/css">
 a 
 {
   text-decoration:none;    
 }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
  <tr>
		<td class="cssPageTitleBG" colspan="3">
		    <asp:label id="Label1" runat="server" CssClass="cssPageTitle" 
                Text="Bộ lọc hợp đồng khung giảng viên"/>
		</td>
	</tr>	
  <tr>
        <td>
        <table cellspacing="0" cellpadding="2" style="width:1100px;" class="cssTable" border="0"> 
            <tr>
                <td align="right" style="width:5%;">
			<asp:label id="lblFullName" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;T&lt;/U&gt;ên giảng viên" />
                         </td>
                <td align="left" style="width:10%;">
		    <asp:TextBox ID="m_txt_ten_giang_vien" runat="server" CssClass="cssTextBox" Enabled="false"
                        Width="90%"></asp:TextBox>
                         </td>
                         <td align="left" style="width:1%;"> 
                             &nbsp;</td>
                <td align="right" style="width:10%;">
			       
			<asp:label id="lblFullName2" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;M&lt;/U&gt;ã PO phụ trách hợp đồng" />
			       
			    </td>
                <td align="left" style="width:10%;">
		    <asp:TextBox ID="m_txt_ma_PO_quan_ly" runat="server" CssClass="cssTextBox" 
                        Width="90%"></asp:TextBox>
                         </td>
                <td align="left" style="width:1%;"></td>
                 <td align="right" style="width:5%;">
			<asp:label id="lblFullName3" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;S&lt;/U&gt;ố hợp đồng" />
                         </td>
                <td align="left" style="width:10%;">
		    <asp:TextBox ID="m_txt_so_hd" runat="server" CssClass="cssTextBox" 
                        Width="90%"></asp:TextBox>
                         </td>
                <td align="left" style="width:1%;"></td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			<asp:label id="Label16" CssClass="cssManField" runat="server" 
                Text="Loại hợp đồng" />
		                    </td>
                <td align="left" style="width:10%;">
			        <asp:DropDownList ID="m_cbo_loai_hop_dong_search" 
                        runat="server" Height="22px" Width="90%"></asp:DropDownList></td>
                                 <td align="left" style="width:1%;"></td>
                <td align="right" style="width:5%;">
			<asp:label id="Label18" CssClass="cssManField" runat="server" 
                Text="Đơn vị quản lý HĐ" />
		                    </td>
                <td align="left" style="width:10%;">
                <asp:DropDownList ID="m_cbo_don_vi_quan_ly_search"
                        runat="server" Height="22px" Width="90%"></asp:DropDownList>
			        &nbsp;</td>
                                 <td align="left" style="width:1%;"></td>
                 <td align="right" style="width:5%;">
			<asp:label id="Label8" CssClass="cssManField" runat="server" 
                Text="Trạng thái hợp đồng" />
		                    </td>
                <td align="left" style="width:10%;">
                                <asp:DropDownList ID="m_cbo_trang_thai_hop_dong_search" 
                        runat="server" Height="22px" Width="90%"></asp:DropDownList>
			        &nbsp;</td>     <td align="left" style="width:1%;"></td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			<asp:label id="lblNgayKi" CssClass="cssManField" runat="server" 
                Text="Tháng ký" />
		                    </td>
                <td align="left" style="width:10%;">
                    <asp:DropDownList id="m_cbo_thang_ky" runat="server" Width="40%" 
                        CssClass="cssDorpdownlist"  >
                        <asp:ListItem Selected="True" Value="0">Tất cả</asp:ListItem>
                        <asp:ListItem Value="1">1</asp:ListItem>
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
                                 <td align="left" style="width:1%;">&nbsp;</td>
                <td align="right" style="width:5%;">
			       
			<asp:label id="lblNgayKi0" CssClass="cssManField" runat="server" 
                Text="Năm ký" />
		                    </td>
                <td align="left" style="width:10%;">
                    <asp:DropDownList id="m_cbo_nam_ky" runat="server" Width="40%" 
                        CssClass="cssDorpdownlist"  >
                    </asp:DropDownList>
                    </td>
                                 <td align="left" style="width:1%;">&nbsp;</td>
                 <td align="right" style="width:5%;">
			       
			         &nbsp;</td>
                <td align="left" style="width:10%;">
			        &nbsp;</td>     <td align="left" style="width:1%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			       
			<asp:label id="lblNgayHieuLuc" CssClass="cssManField" runat="server" 
                Text="Ngày hiệu lực" />
		                    </td>
                <td align="left" style="width:10%;">
			        <ew:CalendarPopup ID="m_dat_ngay_hieu_luc" runat="server" 
                        ControlDisplay="TextBoxImage" GoToTodayText="Hôm nay:" 
                        ImageUrl="~/Images/cal.gif" Nullable="True" NullableLabelText="" 
                        ShowGoToToday="True" Width="80%" Text="" Culture="vi-VN" 
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
                                 <td align="left" style="width:1%;">&nbsp;</td>
                <td align="right" style="width:5%;">
			       
			<asp:label id="lblNgayketthuc" CssClass="cssManField" runat="server" 
                Text="Ngày kết thúc" />
		                    </td>
                <td align="left" style="width:10%;">
			        <ew:CalendarPopup ID="m_dat_date_ket_thuc" runat="server" 
                        ControlDisplay="TextBoxImage" GoToTodayText="Hôm nay:" 
                        ImageUrl="~/Images/cal.gif" Nullable="True" NullableLabelText="" 
                        ShowGoToToday="True" Width="80%" Text="" Culture="vi-VN" 
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
                                 <td align="left" style="width:1%;">&nbsp;</td>
                 <td align="right" style="width:5%;">
			       
			         &nbsp;</td>
                <td align="left" style="width:10%;">
			        &nbsp;</td>     <td align="left" style="width:1%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			<asp:label id="Label4" CssClass="cssManField" runat="server" 
                Text="Từ khóa tìm kiếm" />
		                    </td>
                <td align="left" style="width:10%;">     

		            <asp:TextBox ID="m_txt_tu_khoa_tim_kiem" runat="server" CssClass="cssTextBox" 
                        Width="244%"></asp:TextBox>

			    </td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			        &nbsp;</td>
                   <td align="left" style="width:1%;" colspan="4">

                <asp:label id="lblFullName1" CssClass="cssLabel" runat="server" 
                
                Text="(Từ khóa tìm kiếm: Giảng viên, loại hợp đồng, trạng thái hợp đồng, ...)" />

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
			        &nbsp;</td>     <td align="left" style="width:1%;"></td>
                 <td align="right" style="width:5%;"></td>
                <td align="left" style="width:10%;"></td>     <td align="left" style="width:1%;"></td>
            </tr>
            <tr>
                <td align="right" >
			        &nbsp;</td>
                <td align="left">     
			<asp:button id="m_cmd_loc_du_lieu" accessKey="l" CssClass="cssButton" 
                runat="server" Width="98px" Text="Lọc dữ liệu(l)" 
                        Height="23px" onclick="m_cmd_loc_du_lieu_Click" />
			</td>
                             <td align="left" style="width:1%;">&nbsp;</td>
                <td align="right" >
			        &nbsp;</td>
                <td align="left" >    
			<asp:button id="m_cmd_xuat_excel" accessKey="x" CssClass="cssButton" 
                runat="server" Width="98px" Text="Xuất Excel (x)" Height="22px" 
                        onclick="m_cmd_xuat_excel_Click"  />
			</td>
                             <td align="left" >&nbsp;</td>
                 <td align="right" ></td>
                <td align="left" ></td>    
                <td align="left" ></td>
            </tr>
            </table>        
        </td>
    </tr>  
    <tr>
		<td class="cssPageTitleBG" colspan="3">
		    <asp:label id="m_lbl_loc_du_lieu" runat="server" CssClass="cssPageTitle" 
                Text="Kết quả lọc dữ liệu"/>
		</td>
	</tr>	
    <tr>
		<td align="left">
        &nbsp;<asp:button id="cmd_them_moi" accessKey="c" CssClass="cssButton" Visible="false"
                runat="server" Width="98px" Text="Tạo mới(c)" 
                Height="27px" onclick="cmd_them_moi_Click"/><br />
                <asp:Label ID="m_lbl_thong_bao" CssClass="cssManField" runat="server"></asp:Label>
        </td>
        <td >
		    &nbsp;</td>
	</tr>	
	<tr>
		<td align="center" colspan="3" style="height:450px;" valign="top">
		    &nbsp;
   <asp:GridView ID="m_grv_dm_danh_sach_hop_dong_khung" AllowPaging="true" 
                runat="server" AutoGenerateColumns="False" 
                Width="101%" DataKeyNames="ID"
                CellPadding="4" ForeColor="#333333" GridLines="Both" 
            AllowSorting="True" 
                onrowdeleting="m_grv_dm_danh_sach_hop_dong_khung_RowDeleting" 
                onpageindexchanging="m_grv_dm_danh_sach_hop_dong_khung_PageIndexChanging" >
                  <AlternatingRowStyle BackColor="White" />
                <Columns>
                     <asp:TemplateField HeaderText="Xóa" Visible="false">
                    <ItemTemplate> <asp:LinkButton ToolTip="Xóa" ID = "lbt_delete" runat="server"
                     CommandName="Delete" OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')">
                      <img src="/TRMProject/Images/Button/deletered.png" alt="Delete" />
                     </asp:LinkButton>
                    </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Chi tiết">
                    <ItemTemplate> <asp:HyperLink ToolTip="Chi tiết" ImageUrl="/TRMProject/Images/Button/edit.png" ID = "lbt_edit" runat="server"
                     NavigateUrl='<%# "/TRMProject/CongTTGV/F1301_ChiTietHopDong.aspx?mode=edit&id="+Eval("ID") %>'></asp:HyperLink>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Phụ lục hợp đồng">
                    <ItemTemplate> <asp:HyperLink ToolTip="Phụ lục hợp đồng" ImageUrl="/TRMProject/Images/Button/detail.png" ID = "lbt_phu_luc_hop_dong" runat="server"
                     NavigateUrl='<%# "/TRMProject/CongTTGV/F1307_PhuLucHopDong.aspx?id_hd="+Eval("ID") %>'></asp:HyperLink>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><asp:Label ID="m_lbl_stt" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>

                     <asp:TemplateField>
                    <HeaderTemplate>Số hợp đồng</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_so_hop_dong" runat="server" Text='<%# Eval("SO_HOP_DONG").ToString() %>' ></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                    </asp:TemplateField>
                      <asp:TemplateField Visible="false">
                    <HeaderTemplate>"Ngày ký</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_ngay_ky" runat="server" Text='<%# Eval("NGAY_KY").ToString() %>' ></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="NGAY_KY" HeaderText="Ngày ký" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false" />
                     <asp:TemplateField>
                    <HeaderTemplate>Mã giảng viên</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_ma_gv" runat="server" Text='<%# get_ma_gv_form_id(CIPConvert.ToDecimal(Eval("ID_GIANG_VIEN"))) %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="200px"/>
                    </asp:TemplateField>

                     <asp:TemplateField Visible="false">
                    <HeaderTemplate>Tên giảng viên</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_ten_gv" runat="server"
                    Text='<%# Eval("GIANG_VIEN").ToString() %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="200px"/>
                    </asp:TemplateField>

                    <asp:TemplateField>
                    <HeaderTemplate>Tên giảng viên</HeaderTemplate>
                    <ItemTemplate>
                    <label><a href='/TRMProject/CongTTGV/F1201_HoSoGiangVien.aspx'>
                    <%# Eval("GIANG_VIEN").ToString() %></a></label>
                    </ItemTemplate>
                    <ItemStyle Width="200px"/>
                    </asp:TemplateField>
                     <asp:TemplateField>
                    <HeaderTemplate>Mã số thuế</HeaderTemplate>
                    <ItemTemplate><%# Eval("MA_SO_THUE") %></ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                    </asp:TemplateField>
                     <asp:TemplateField>
                    <HeaderTemplate>Số tài khoản</HeaderTemplate>
                    <ItemTemplate><%# Eval("SO_TAI_KHOAN").ToString()%></ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="TEN_NGAN_HANG" HeaderText="Tên ngân hàng" />
                       <asp:TemplateField>
                    <HeaderTemplate>Loại hợp đồng</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_loai_hop_dong" runat="server" Text='<%# Eval("LOAI_HOP_DONG").ToString() %>' ></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                    </asp:TemplateField>
                      <asp:TemplateField>
                    <HeaderTemplate>Đơn vị quản lý</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_don_vi_quan_ly" runat="server" Text='<%# Eval("DON_VI_QUAN_LY").ToString() %>' ></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                    </asp:TemplateField>
                     <asp:TemplateField>
                    <HeaderTemplate>Đơn vị thanh toán</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_don_vi_thanh_toan" runat="server" Text='<%# Eval("DON_VI_THANH_TOAN").ToString() %>' ></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField>
                    <HeaderTemplate>Môn 1</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_mon_1" runat="server" Text='<%# Eval("FIRST_MON").ToString() %>' ></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                    </asp:TemplateField>
                     <asp:TemplateField>
                    <HeaderTemplate>Môn 2</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_mon_2" runat="server" Text='<%# Eval("SEC_MON").ToString() %>' ></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                    </asp:TemplateField>
                     <asp:TemplateField>
                    <HeaderTemplate>Môn 3</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_mon_3" runat="server" Text='<%# Eval("THIR_MON").ToString() %>' ></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                    </asp:TemplateField>
                     <asp:TemplateField>
                    <HeaderTemplate>Môn 4</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_mon_4" runat="server" Text='<%# Eval("FOURTH_MON").ToString() %>' ></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                    </asp:TemplateField>
                     <asp:TemplateField>
                    <HeaderTemplate>Môn 5</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_mon_5" runat="server" Text='<%# Eval("FITH_MON").ToString() %>' ></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                    </asp:TemplateField>
                     <asp:TemplateField>
                    <HeaderTemplate>Môn 6</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_mon_6" runat="server" Text='<%# Eval("SIXTH_MON").ToString() %>' ></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                    </asp:TemplateField>
                      <asp:TemplateField Visible="false">
                    <HeaderTemplate>ngay hieu luc</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_ngay_hieu_luc" runat="server" Text='<%# Eval("NGAY_HIEU_LUC").ToString() %>' ></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                    </asp:TemplateField>

                     <asp:BoundField DataField="NGAY_HIEU_LUC" HeaderText="Ngày hiệu lực" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false">
                    </asp:BoundField>
                    <asp:TemplateField Visible="false">
                    <HeaderTemplate>ngay ket thuc</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_ngay_ket_thuc" runat="server" Text='<%# Eval("NGAY_KET_THUC_DU_KIEN").ToString() %>' ></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="NGAY_KET_THUC_DU_KIEN" HeaderText="Ngày kết thúc " DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false">
                    </asp:BoundField>
                     <asp:TemplateField>
                    <HeaderTemplate>Trạng thái hợp đồng</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_trang_thai_hd" runat="server" Text='<%# Eval("TRANG_THAI_HOP_DONG").ToString() %>' ></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField>
                    <HeaderTemplate>Mã PO Phụ trách hợp đồng</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_ma_po_phu_trach" runat="server" Text='<%# Eval("MA_PO_PHU_TRACH").ToString() %>' ></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                    </asp:TemplateField>
                    
                      <asp:TemplateField Visible="false">
                    <HeaderTemplate>Giá trị hợp đồng</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_gia_tri_hd" runat="server" Text='<%# Eval("GIA_TRI_HOP_DONG").ToString()%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                    </asp:TemplateField>
                     <asp:BoundField DataField="GIA_TRI_HOP_DONG" DataFormatString="{0:N0}" HeaderText="Giá trị hợp đồng" ItemStyle-HorizontalAlign="Right" HtmlEncode="false">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
                    </asp:BoundField>
                     <asp:TemplateField Visible="false">
                    <HeaderTemplate>Thuế suất(%)</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_thue_suat" runat="server" Text='<%# Eval("THUE_SUAT").ToString() +"%"%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="THUE_SUAT" DataFormatString="{0:N1}%" HeaderText="Thuế suất(%)"  HtmlEncode="false"></asp:BoundField>
                    <asp:TemplateField>
                    <HeaderTemplate>HĐ học liệu?</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_lam_hoc_lieu" runat="server" Text='<%# mapping_hl(Eval("HOC_LIEU_YN").ToString())%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField>
                       <HeaderTemplate>HĐ vận hành?</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_van_hanh" runat="server" Text ='<%# mapping_vh(Eval("VAN_HANH_YN").ToString())%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField>
                       <HeaderTemplate>Có số hợp đồng?</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label  ID="m_lbl_co_so_hop_dong" runat="server" Text = '<%# mapping_cs(Eval("CO_SO_HD_YN").ToString())%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                     <asp:TemplateField>
                    <HeaderTemplate>Ghi chú</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_ghi_chu" runat="server" Text='<%# Eval("GHI_CHU").ToString() %>' ></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField>
                    <HeaderTemplate>Ghi chú 2</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_ghi_chu2" runat="server" Text='<%# Eval("GHI_CHU2").ToString() %>' ></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField>
                    <HeaderTemplate>Ghi chú 3</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_ghi_chu3" runat="server" Text='<%# Eval("GHI_CHU3").ToString() %>' ></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField>
                    <HeaderTemplate>Ghi chú 4</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_ghi_chu4" runat="server" Text='<%# Eval("GHI_CHU4").ToString() %>' ></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
                  <EditRowStyle BackColor="#7C6F57" />
                  <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
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

