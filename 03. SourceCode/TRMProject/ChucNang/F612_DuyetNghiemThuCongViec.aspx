<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F612_DuyetNghiemThuCongViec.aspx.cs" Inherits="ChucNang_F612_DuyetNghiemThuCongViec" %>
<%@ Register assembly="eWorld.UI" namespace="eWorld.UI" tagprefix="ew" %>
<%@ Import Namespace="IP.Core.IPCommon" %>
<%@ Import Namespace="WebDS" %>
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
<table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
    <tr>
		<td class="cssPageTitleBG" colspan="4">
		    <asp:label id="m_lbl_ds_cv_gv" runat="server" CssClass="cssPageTitle" 
                Text="Duyệt nghiệm thu công việc của GVCM"/>
		</td>
	</tr>
    <tr>
        <td colspan="4" align="left">
		   <asp:validationsummary id="vdsCategory" runat="server" CssClass="cssManField" Font-Bold="true" />
		   <asp:label id="m_lbl_mess" runat="server" CssClass="cssManField" />
		</td>
    </tr>	
    <tr>
        <td colspan="3"> 
        <table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0"> 
            <tr>
                <td align="right" style="width:12%;">
			        <asp:label id="Label4" CssClass="cssManField" runat="server" 
                Text="Tên giảng viên" />
                         </td>
                <td align="left" style="width:38%;">
            <asp:DropDownList id="m_cbo_ten_giang_vien" runat="server" AutoPostBack="true" Enabled="false"
                        CssClass="cssDorpdownlist" Width="90%">
                    </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <td align="right" style="width:12%;">
			<asp:label id="lbl_so_hop_dong" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;S&lt;/U&gt;ố hợp đồng" />
                         </td>
                <td align="left" style="width:38%;">
                    <asp:DropDownList id="m_cbo_so_hop_dong" runat="server" AutoPostBack="true"
                        CssClass="cssDorpdownlist" Width="90%">
                    </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <td align="right" style="width:12%;">
			<asp:label id="lbl_ngay_dat_hang" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;N&lt;/U&gt;gày đặt hàng" />
                         </td>
                <td align="left" colspan="2" style="width:88%;">
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
            </tr>
            <tr>
                <td align="right" style="width:12%;">
			<asp:label id="lbl_noi_dung_tt" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;C&lt;/U&gt;ông việc" />
                         </td>
                <td align="left" colspan="3" style="width:88%;">
                &nbsp;<asp:DropDownList id="m_cbo_noi_dung_thanh_toan" runat="server" Enabled="false"
                        CssClass="cssDorpdownlist" Width="80%">
                    </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                    <td align="right" style="width:12%;">
			<asp:label id="lbl_so_luong" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;S&lt;/U&gt;ố lượng đặt hàng" />
                         </td>
                <td align="left" style="width:38%;">
                &nbsp;<asp:TextBox  ID="m_txt_so_luong" CssClass="csscurrency" Width="20%" Enabled="false"
                        runat="server"></asp:TextBox> 
		            &nbsp;
                     <asp:RequiredFieldValidator ID="req_vali3" runat="server" 
                         ErrorMessage="Bạn phải nhập số lượng công việc" Text="*" 
                        ControlToValidate="m_txt_so_luong" CssClass="cssManField"> </asp:RequiredFieldValidator>
                    <asp:CompareValidator runat="server" id="compPrimeNumberPositive" Operator="GreaterThanEqual" Type="Currency"
                Display="Dynamic" ValueToCompare="0" ControlToValidate="m_txt_so_luong" Text="*" ErrorMessage = "Số lượng nhập không đúng định dạng" CssClass="cssManField" />
                    &nbsp;<asp:Label ID="m_lbl_don_vi" runat="server"></asp:Label>
                    </td>
                    <td align="right" style="width:12%;">
			<asp:label id="lbl_don_gia" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;Đ&lt;/U&gt;ơn giá" />
                         </td>
                <td align="left" style="width:38%;">
                &nbsp;<asp:TextBox ID="m_txt_don_gia" runat="server" CssClass="csscurrency"
                        Width="40%"></asp:TextBox>
		            &nbsp;
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                         ErrorMessage="Bạn phải nhập đơn giá" Text="*" 
                        ControlToValidate="m_txt_don_gia"> </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ErrorMessage="Invalid Price" Text="*"
    ValidationGroup="complete" EnableClientScript="true" ControlToValidate="m_txt_don_gia"
    ValidationExpression="^\d+(\.\d\d)?$" Display="Dynamic" runat="server"/>
                    <asp:CompareValidator runat="server" id="CompareValidator1" Operator="GreaterThanEqual" Type="Currency"
                Display="Dynamic" ValueToCompare="0" ControlToValidate="m_txt_don_gia" Text="*" ErrorMessage = "Đơn giá nhập không đúng định dạng" CssClass="cssManField"/>
                    </td>
            </tr>
             <tr>
                <td align="right" style="width:12%;">
			<asp:label id="lbl_so_luong0" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;S&lt;/U&gt;ố lượng nghiệm thu" />
                         </td>
                <td align="left" style="width:38%;">
                    <asp:TextBox ID="m_txt_so_luong_nghiem_thu" runat="server" 
                        CssClass="csscurrency" onblur="calculate_money()" Width="20%"></asp:TextBox>
                    &nbsp;
                    <asp:RequiredFieldValidator ID="req_vali4" runat="server" 
                        ControlToValidate="m_txt_so_luong_nghiem_thu" CssClass="cssManField" 
                        ErrorMessage="Bạn phải nhập số lượng nghiệm thu" Text="*"> </asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="compPrimeNumberPositive0" runat="server" 
                        ControlToValidate="m_txt_so_luong_nghiem_thu" CssClass="cssManField" 
                        Display="Dynamic" ErrorMessage="Số lượng nghiệm thu nhập không đúng định dạng" 
                        Operator="GreaterThanEqual" Text="*" Type="Currency" ValueToCompare="0" />
                    </td>
                    <td>
			<asp:label id="lbl_trang_thai" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;T&lt;/U&gt;rạng thái" />
                         </td>
                    <td><asp:DropDownList id="m_cbo_trang_thai_cv_gv" runat="server" 
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
	    <td></td>
		<td colspan="3" align="left">
			&nbsp;&nbsp;
            <asp:button id="m_cmd_cap_nhat" accessKey="u" CssClass="cssButton"
                runat="server" Width="98px" Height="25px"  Text="Duyệt" onclick="m_cmd_cap_nhat_Click"/>
                 &nbsp;&nbsp;
                <asp:Button ID="m_cmd_xuat_excel" runat="server" CausesValidation="False" 
                        CssClass="cssButton" Height="25px"  Text="Xuất Excel" 
                        Width="98px" onclick="m_cmd_xuat_excel_Click"/>
			        &nbsp;&nbsp;
			        <asp:Button ID="m_cmd_huy" runat="server" CausesValidation="False" 
                        CssClass="cssButton" Height="25px"  Text="Hủy" 
                        Width="98px" onclick="m_cmd_huy_Click"/>
		</td>
	</tr>
            </table>        
        </td>
    </tr> 
          <tr>
        <td colspan="3" align="left">
		   <asp:label id="m_lbl_thong_bao_sau_cap_nhat" runat="server" CssClass="cssManField" />
           <asp:HiddenField runat="server" ID="m_hdf_check_hd" />
		</td>
    </tr> 
    <tr>
		<td class="cssPageTitleBG" colspan="3">
		    <asp:label id="m_lbl_ket_qua_loc_du_lieu" runat="server" CssClass="cssPageTitle" 
                Text="Kết quả lọc dữ liệu"/>
		</td>
	</tr>
    <tr>
         <td align="right" style="width:12%;"><asp:label id="Label1" CssClass="cssManField" runat="server" 
                Text="Tên giảng viên" />
        </td>
        <td align="left" style="width:38%;">
            <asp:DropDownList id="m_cbo_ten_giang_vien_loc" runat="server" AutoPostBack="true"
                        CssClass="cssDorpdownlist" Width="60%" 
                onselectedindexchanged="m_cbo_ten_giang_vien_loc_SelectedIndexChanged">
                    </asp:DropDownList>
                    </td>
    </tr>
    <tr>
         <td align="right" style="width:12%;"><asp:label id="Label2" CssClass="cssManField" runat="server" 
                Text="Số hơp đồng" />
        </td>
        <td align="left" style="width:38%;">
            <asp:DropDownList id="m_cbo_so_hop_dong_loc" runat="server" AutoPostBack="true"
                        CssClass="cssDorpdownlist" Width="60%" 
                onselectedindexchanged="m_cbo_so_hop_dong_loc_SelectedIndexChanged">
                    </asp:DropDownList>
                    </td>
    </tr>
    <tr>
         <td align="right" style="width:12%;"><asp:label id="Label3" CssClass="cssManField" runat="server" 
                Text="Trạng thái công việc" />
        </td>
        <td align="left" style="width:38%;">
            <asp:DropDownList id="m_cbo_trang_thai_cv_loc" runat="server" AutoPostBack="true"
                        CssClass="cssDorpdownlist" Width="60%" 
                onselectedindexchanged="m_cbo_trang_thai_cv_loc_SelectedIndexChanged">
                    </asp:DropDownList>
                    </td>
            </tr>
	<tr>
		<td align="center" colspan="4" valign="top">
		    &nbsp;
            <asp:GridView ID="m_grv_gd_assign_su_kien_cho_giang_vien" runat="server" AutoGenerateColumns="False"
                Width="100%" DataKeyNames="ID" ShowFooter="true"
                CellPadding="4" ForeColor="#333333" 
                AllowPaging="True" AllowSorting="True" PageSize="20" 
                
                onselectedindexchanging="m_grv_gd_assign_su_kien_cho_giang_vien_SelectedIndexChanging" 
                onpageindexchanging="m_grv_gd_assign_su_kien_cho_giang_vien_PageIndexChanging">
                  <AlternatingRowStyle BackColor="White" />
                <Columns>
                 <asp:TemplateField>
                  <HeaderTemplate>
                   <input type="checkbox" id="chkAll" onclick="javascript:SelectAllCheckboxes(this)" runat="server" />
                  </HeaderTemplate>                 
                  <ItemTemplate>
                    <asp:CheckBox runat="server" ID="chkItem" ToolTip='<%# Eval("Id") %>' />
                    <asp:CheckBox runat="server" ID="chkTrangThai" ToolTip='<%# Eval("ID_TRANG_THAI") %>' Visible="false" />
                  </ItemTemplate>
                  <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>  
                  <asp:TemplateField HeaderText="Chỉnh sửa">
                        <ItemTemplate>
                        <asp:LinkButton runat='server' ID='m_lbt_duyet'
                         CommandName='Select' ToolTip='Chỉnh sửa' CausesValidation='false'>  
                         <center><img src='../Images/Button/edit.png' width='20px' height='20px' alt='Sửa' /></center>
                         </asp:LinkButton></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Số hợp đồng">
                        <ItemTemplate>
                            <%# Eval("SO_HOP_DONG")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Họ tên giảng viên">
                        <ItemTemplate>
                            <%# Eval("HO_VA_TEN_GIANG_VIEN")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Công việc">
                        <ItemTemplate>
                            <%# Eval("TEN_NOI_DUNG")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:BoundField HeaderText="Số lượng đặt hàng" DataField="SO_LUONG_HE_SO" 
                        DataFormatString="{0:0}" ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Đơn giá" DataField="DON_GIA" 
                        DataFormatString="{0:N0}" ItemStyle-HorizontalAlign="Right" >
<ItemStyle HorizontalAlign="Right"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Ngày đặt hàng" DataField="NGAY_DAT_HANG" 
                        DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false" 
                        ItemStyle-HorizontalAlign="Center">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                       <asp:BoundField HeaderText="Số lượng nghiệm thu" DataField="SO_LUONG_NGHIEM_THU" 
                        DataFormatString="{0:N0}" ItemStyle-HorizontalAlign="Right" FooterText="Tổng tiền: " FooterStyle-HorizontalAlign="Right" >
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                      <asp:TemplateField HeaderText="Số tiền nghiệm thu">
                        <FooterStyle HorizontalAlign="Right" />
                        <ItemTemplate>
                            <asp:Label Text='<%# get_so_tien_thanh_toan(Eval("DON_GIA"),Eval("SO_LUONG_NGHIEM_THU")) %>' runat="server" ID="m_lbl_so_tien_nghiem_thu"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right"/>
                    </asp:TemplateField>
                     <asp:BoundField HeaderText="Ngày nghiệm thu" DataField="NGAY_NGHIEM_THU" 
                        DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false" 
                        ItemStyle-HorizontalAlign="Center">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                     <asp:TemplateField HeaderText="Trạng thái">
                        <ItemTemplate>
                            <%# Eval("TEN_TRANG_THAI")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Ghi chú" DataField="GHI_CHU" />
                </Columns>
                  <EditRowStyle BackColor="#7C6F57" />
                  <FooterStyle BackColor="#810c15" Font-Bold="True" ForeColor="White"  />
                  <HeaderStyle BackColor="#810c15" Font-Bold="True" ForeColor="White" />
                  <PagerSettings Position="TopAndBottom" />
                  <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                  <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle CssClass="cssSelectedRow" BackColor="#C5BBAF" Font-Bold="True" 
                      ForeColor="#333333"></SelectedRowStyle>
            </asp:GridView>
            </td>
	</tr>
    <tr>
        <td>
            <asp:button id="m_cmd_duyet_ke_hoach" accessKey="u" CssClass="cssButton"
                runat="server" Width="98px" Height="25px"  Text="Duyệt" CausesValidation="false"
                onclick="m_cmd_duyet_ke_hoach_Click"/>
        </td>
    </tr>
</table>
</asp:Content>

