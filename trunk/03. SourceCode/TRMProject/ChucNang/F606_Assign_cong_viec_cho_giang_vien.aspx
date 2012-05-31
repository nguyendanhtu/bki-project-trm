﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F606_Assign_cong_viec_cho_giang_vien.aspx.cs" Inherits="ChucNang_F606_Assign_cong_viec_cho_giang_vien" %>
<%@ Register assembly="eWorld.UI" namespace="eWorld.UI" tagprefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
    <tr>
		<td class="cssPageTitleBG" colspan="4">
		    <asp:label id="m_lbl_ds_cv_gv" runat="server" CssClass="cssPageTitle" 
                Text="Danh sách công việc mới - giảng viên"/>
		</td>
	</tr>
    <tr>
        <td colspan="4" align="left">
		   <asp:validationsummary id="vdsCategory" runat="server" CssClass="cssManField" Font-Bold="true" />
		   <asp:label id="m_lbl_mess" runat="server" CssClass="cssManField" />
		</td>
    </tr>	
    <tr>
        <td> 
        <table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0"> 
            <tr>
                <td align="right" style="width:12%;">
			<asp:label id="lbl_so_hop_dong" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;S&lt;/U&gt;ố hợp đồng" />
                         </td>
                <td align="left" style="width:38%;">
                &nbsp;<asp:TextBox ID="m_txt_so_hop_dong" runat="server" CssClass="cssTextBox" 
                        Width="85%"></asp:TextBox>
		            &nbsp;
                    </td>
                <td align="left" style="width:12%;">
                    			<asp:button id="m_btn_check" accessKey="l" CssClass="cssButton" 
                runat="server" Width="98px" Text="Kiểm tra" 
                        Height="23px" onclick="m_btn_check_Click" />
		            </td>
                <td align="left" style="width:38%;">
                     <asp:label id="m_lbl_thong_bao_so_hd" runat="server" CssClass="cssManField" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width:12%;">
			<asp:label id="lbl_noi_dung_tt" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;C&lt;/U&gt;ông việc" />
                         </td>
                <td align="left" colspan="3" style="width:88%;">
                &nbsp;<asp:DropDownList id="m_cbo_noi_dung_thanh_toan" runat="server" 
                        CssClass="cssDorpdownlist" Width="93%"  >
                    </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                    <td align="right" style="width:12%;">
			<asp:label id="lbl_so_luong" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;S&lt;/U&gt;ố lượng" />
                         </td>
                <td align="left" style="width:38%;">
                &nbsp;<asp:TextBox ID="m_txt_so_luong" runat="server" CssClass="cssTextBox" 
                        Width="20%" ></asp:TextBox>
		            &nbsp;<asp:CompareValidator runat="server" id="compPrimeNumberPositive" Operator="GreaterThanEqual" Type="Currency"
                Display="Dynamic" ValueToCompare="0" ControlToValidate="m_txt_so_luong" Text="*" ErrorMessage = "Số lượng nhập không đúng định dạng" CssClass="cssManField" />
                    </td>
                    <td align="right" style="width:12%;">
			<asp:label id="lbl_don_gia" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;Đ&lt;/U&gt;ơn giá" />
                         </td>
                <td align="left" style="width:38%;">
                &nbsp;<asp:TextBox ID="m_txt_don_gia" runat="server" CssClass="cssTextBox" 
                        Width="40%"></asp:TextBox>
		            &nbsp;<asp:CompareValidator runat="server" id="CompareValidator1" Operator="GreaterThanEqual" Type="Currency"
                Display="Dynamic" ValueToCompare="0" ControlToValidate="m_txt_don_gia" Text="*" ErrorMessage = "Đơn giá nhập không đúng định dạng" CssClass="cssManField"/>
                    </td>
            </tr>
            <tr>
                <td align="right" style="width:12%;">
			<asp:label id="lbl_ngay_dat_hang" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;N&lt;/U&gt;gày đặt hàng" />
                         </td>
                 <td align="left" style="width:38%;">&nbsp;
                       <ew:CalendarPopup ID="m_dat_ngay_bat_dau" runat="server" 
                        ControlDisplay="TextBoxImage" GoToTodayText="Hôm nay:" 
                        ImageUrl="~/Images/cal.gif" Nullable="True" NullableLabelText="" 
                        ShowGoToToday="True" Width="70%" Text="" Culture="vi-VN" 
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
                 <td align="right" style="width:12%;">
			<asp:label id="lbl_ngay_nghiem_thu" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;N&lt;/U&gt;gày nghiệm thu" />
                         </td>
                 <td align="left" style="width:38%;"> &nbsp;
                     <ew:CalendarPopup ID="m_dat_ngay_nghiem_thu" runat="server" 
                        ControlDisplay="TextBoxImage" GoToTodayText="Hôm nay:" 
                        ImageUrl="~/Images/cal.gif" Nullable="True" NullableLabelText="" 
                        ShowGoToToday="True" Width="80%" SelectedDate="" Text="" Culture="vi-VN" 
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
            </tr>
             <tr>
                <td align="right" style="width:12%;">
			<asp:label id="lbl_trang_thai" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;T&lt;/U&gt;rạng thái" />
                         </td>
                <td align="left" style="width:38%;">
                &nbsp;<asp:DropDownList id="m_cbo_trang_thai_cv_gv" runat="server" 
                        CssClass="cssDorpdownlist"  >
                    </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <td align="right" style="width:12%;">
			<asp:label id="lbl_ghi_chu" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;G&lt;/U&gt;hi chú" />
                         </td>
                <td align="left" colspan="3" style="width:88%;">
                &nbsp;<asp:TextBox ID="m_txt_ghi_chu" runat="server" CssClass="cssTextBox" TextMode="MultiLine" 
                        Width="94%"></asp:TextBox>
                    </td>
            </tr>
             <tr>
               <td align="right" style="width:12%;">
			<asp:label id="lbl_tu_khoa" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;T&lt;/U&gt;ừ khóa tìm kiếm" />
                         </td>
		<td align="left" style="width:38%;">
		    <asp:TextBox ID="m_txt_tu_khoa" runat="server" CssClass="cssTextBox" 
                        Width="98%"></asp:TextBox>
	    <td align="left" style="width:50%;" colspan="2">
            <asp:label id="lbl_tb_cap_nhat" CssClass="cssLabel" runat="server" 
                Text="(Dùng trong trường hợp muốn lọc dữ liệu.)" />
        </td>
		</td> 
            </tr>
            <tr>
               <td align="right" style="width:12%;">
			
                         </td>
		<td colspan="3" align="left">
			<asp:label id="lbl_tu_khoa_tim_kiem" CssClass="cssLabel" runat="server" 
                Text="(Từ khóa tìm kiếm: Số hợp đồng, nội dung thanh toán, trạng thái, họ và tên giảng viên, user người tạo...)" />
		</td> 
            </tr>
            <tr>
	    <td></td>
		<td colspan="3" align="left">
			&nbsp;&nbsp;
            <asp:button id="m_cmd_loc_du_lieu" accessKey="c" CssClass="cssButton" 
                runat="server" Width="98px" Height="25px"  Text="Lọc dữ liệu(l)" onclick="m_cmd_loc_du_lieu_Click" 
                />&nbsp;&nbsp;
                <asp:Button ID="m_cmd_xuat_excel" runat="server" CausesValidation="False" 
                        CssClass="cssButton" Height="25px"  Text="Xuất Excel" 
                        Width="98px"/>
			&nbsp;&nbsp;
			<asp:button id="m_cmd_cap_nhat" accessKey="u" CssClass="cssButton" Visible="false"
                runat="server" Width="98px" Height="25px"  Text="Cập nhật(u)" onclick="m_cmd_cap_nhat_Click" 
                 />&nbsp;&nbsp;
			        <asp:button id="m_cmd_tao_moi" accessKey="l" CssClass="cssButton" 
                runat="server" Width="98px" Height="25px"  Text="Tạo mới(c)" onclick="m_cmd_tao_moi_Click" 
                />&nbsp;&nbsp;
			<asp:button id="m_cmd_xoa_trang" accessKey="r" CssClass="cssButton" runat="server" 
                Width="98px" Height="25px"  Text="Xóa trắng(r)" CausesValidation="false" 
                onclick="btnCancel_Click" />&nbsp;&nbsp;
			        <asp:Button ID="m_cmd_huy" runat="server" CausesValidation="False" 
                        CssClass="cssButton" Height="25px"  Text="Hủy" Visible="false"
                        Width="98px" onclick="m_cmd_huy_Click"/>
		</td>
	</tr>
            </table>        
        </td>
    </tr> 
          <tr>
        <td colspan="4" align="left">
		   <asp:label id="m_lbl_thong_bao_sau_cap_nhat" runat="server" CssClass="cssManField" />
		</td>
    </tr> 
    <tr>
		<td class="cssPageTitleBG" colspan="3">
		    <asp:label id="m_lbl_ket_qua_loc_du_lieu" runat="server" CssClass="cssPageTitle" 
                Text="Kết quả lọc dữ liệu"/>
		</td>
	</tr>		
	<tr>
		<td align="center" colspan="4" style="height:450px;" valign="top">
		    &nbsp;
            <asp:GridView ID="m_grv_gd_assign_su_kien_cho_giang_vien" runat="server" AutoGenerateColumns="False" 
                Width="100%" DataKeyNames="ID" 
                CellPadding="4" ForeColor="#333333" 
                AllowPaging="True" AllowSorting="True" PageSize="20" 
                onrowdeleting="m_grv_gd_assign_su_kien_cho_giang_vien_RowDeleting" 
                onrowupdating="m_grv_gd_assign_su_kien_cho_giang_vien_RowUpdating">
                  <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Số hợp đồng">
                        <ItemTemplate>
                            <%# mapping_so_hop_dong_by_id(Eval("ID_HOP_DONG_KHUNG"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Công việc">
                        <ItemTemplate>
                            <%# mapping_noi_dung_thanh_toan_by_id(Eval("ID_NOI_DUNG_TT"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:BoundField HeaderText="Số lượng" DataField="SO_LUONG_HE_SO" DataFormatString="{0:0}" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderText="Đơn giá" DataField="DON_GIA" DataFormatString="{0:N0}" ItemStyle-HorizontalAlign="Right" />
                    <asp:BoundField HeaderText="Ngày đặt hàng" DataField="NGAY_DAT_HANG" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField HeaderText="Ngày nghiệm thu" DataField="NGAY_NGHIEM_THU" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false" ItemStyle-HorizontalAlign="Center" />
                     <asp:TemplateField HeaderText="Trạng thái">
                        <ItemTemplate>
                            <%# mapping_trang_thai_by_id(Eval("ID_TRANG_THAI"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Ghi chú" DataField="GHI_CHU" />
                    <asp:TemplateField HeaderText="Xóa">
                         <ItemTemplate>
                            <asp:LinkButton runat="server" ID="m_lbt_xoa" CommandName="Delete" OnClientClick="return confirm ('Bạn có thực sự muốn xóa ?')" ToolTip="Xóa" CausesValidation="false"><center><img src="../Images/Button/deletered.png" width="20px" height="20px" alt="Xóa" /></center></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sửa">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="m_lbt_sua" CommandName="Update" ToolTip="Sửa" CausesValidation="false"><center><img src="../Images/Button/edit.png" width="20px" height="20px" alt="Sửa" /></center></asp:LinkButton>
                        </ItemTemplate>
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
