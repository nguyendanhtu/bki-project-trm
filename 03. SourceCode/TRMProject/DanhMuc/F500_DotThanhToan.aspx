<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F500_DotThanhToan.aspx.cs" Inherits="DanhMuc_F500_DotThanhToan" %>
<%@ Import Namespace ="IP.Core.IPCommon" %>
<%@ Register assembly="eWorld.UI" namespace="eWorld.UI" tagprefix="ew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
	<tr>
		<td class="cssPageTitleBG" colspan="3">
		    <asp:label id="lblUser" runat="server" CssClass="cssPageTitle" 
                Text="Danh mục đợt thanh toán"/>
		</td>
	</tr>
	<tr>
		<td colspan="3">
		    <asp:validationsummary id="vdsCategory" runat="server" CssClass="cssManField" Font-Bold="true" />
		   <asp:label id="m_lbl_mess" Visible="false" runat="server" CssClass="cssManField" />
		</td>
	</tr>
	    <tr>
		<td align="right"  style="width:20%;">
			&nbsp;</td>
		<td style="width:70%;">
		    &nbsp;</td>
		<td style="width:10%;">  
			&nbsp;</td>
		</tr>
	    <tr>
		<td align="right" style="width:30%;">
			<asp:label id="lblDonViThanhToan" CssClass="cssManField" runat="server" 
                Text="Đơn vị thanh toán" />
		                    </td>
		<td style="width:60%;">
			
		    <asp:DropDownList id="m_cbo_dm_loai_don_vi_thanh_toan" runat="server" Width="65%" 
                        CssClass="cssDorpdownlist"  />
		                    </td>
		<td style="width:10%;">  
			&nbsp;</td>
		</tr>
	<tr>
		<td align="right" style="width:30%;">
			<asp:label id="lbl_ma_mon" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;M&lt;/U&gt;ã đợt thanh toán" />
		</td>
		<td style="width:60%;">
			<asp:textbox id="m_txt_ma_dot_tt" CssClass="cssTextBox" 
                CausesValidation="false"  runat="server" 
                MaxLength="100" Width="50%" />
                &nbsp;(*)<asp:RequiredFieldValidator id="m_ctv_ma_mon" runat="server" 
                ControlToValidate="m_txt_ma_dot_tt" ErrorMessage="Bạn phải nhập Mã đợt thanh toán" 
                Display="Static" Text="*" />
		    </td>
		<td style="width:10%;"> 
			&nbsp;</td>
	</tr>
	    <tr>
		<td align="right" >
			<asp:label id="lbl_ten_mon" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;T&lt;/U&gt;ên đợt thanh toán" AccessKey="T" />
		    </td>
		<td align="left">
			<asp:textbox id="m_txt_ten_dot_tt" CssClass="cssTextBox" 
                CausesValidation="false"  runat="server" 
                MaxLength="400" Width="65%" />
                &nbsp;(*)<asp:RequiredFieldValidator id="m_ctv_ten_mon" runat="server" 
                ControlToValidate="m_txt_ten_dot_tt" ErrorMessage="Bạn phải nhập Tên đợt thanh toán" 
                Display="Static" Text="*" />
            </td>
		<td >
			&nbsp;</td>
		</tr>
    <tr>
        <td align="right">
			<asp:label id="lbl_ngay_ket_thuc_du_kien" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;N&lt;/U&gt;gày thanh toán dự kiến" AccessKey="T" />
		</td>
        <td align="left">
			
			        <ew:CalendarPopup ID="m_dat_ngay_ket_thuc_du_kien" runat="server" 
                        ControlDisplay="TextBoxImage" GoToTodayText="Hôm nay:" 
                        ImageUrl="~/Images/cal.gif" Nullable="True" NullableLabelText="" 
                        ShowGoToToday="True" Width="60%" SelectedDate="" Text="" Culture="vi-VN" 
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
        <td>&nbsp;</td>
    </tr>
	<tr>
		<td align="right">
			<asp:label id="lbl_ngay_thu_chung_tu" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;N&lt;/U&gt;gày thu chứng từ" AccessKey="T" />
		</td>
		<td valign="top" >
			
			        <ew:CalendarPopup ID="m_dat_ngay_thu_chung_tu" runat="server" 
                        ControlDisplay="TextBoxImage" GoToTodayText="Hôm nay:" 
                        ImageUrl="~/Images/cal.gif" Nullable="True" NullableLabelText="" 
                        ShowGoToToday="True" Width="60%" SelectedDate="" Text="" Culture="vi-VN" 
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
		<td align="right">
			<asp:label id="lbl_trang_thai_dot_tt" CssClass="cssManField" runat="server" 
                Text="Trạng thái đợt thanh toán"/>
		</td>
		<td valign="top" >
			
		    <asp:DropDownList id="m_cbo_dm_trang_thai_dot_thanh_toan" runat="server" Width="30%" 
                        CssClass="cssDorpdownlist" Enabled="False"/>
        </td>
	</tr>	
	<tr>
		<td align="right">
			<asp:label id="lbl_ghi_chu1" CssClass="cssManField" runat="server" 
                Text="Ghi chú"/>
		</td>
		<td valign="top" colspan="1">
			
			<asp:textbox id="m_txt_ghi_chu" TextMode="MultiLine" Rows="4" CssClass="cssTextBox" 
                CausesValidation="false"  runat="server" 
                MaxLength="400" Width="65%" />
        </td>
	</tr>	
    <tr>
		<td align="right">
			&nbsp;</td>
		<td valign="top" colspan="2">
       
                <asp:HiddenField ID="hdf_id_dot_tt" runat = "server" Value="" />
                <asp:HiddenField ID="hdf_ma_dot_tt" runat = "server" Value="" />
                </td>
	</tr>	
	<tr>
	    <td></td>
		<td colspan="2" align="left">
			&nbsp;&nbsp;
			<asp:button id="m_cmd_tao_moi" accessKey="c" CssClass="cssButton" 
                runat="server" Width="98px" Text="Tạo mới(c)" 
                onclick="m_cmd_tao_moi_Click" />&nbsp;&nbsp;
			<asp:button id="m_cmd_cap_nhat" accessKey="u" CssClass="cssButton" 
                runat="server" Width="98px" Text="Cập nhật(u)" 
                onclick="m_cmd_cap_nhat_Click" />&nbsp;&nbsp;
			        <asp:Button ID="m_cmd_xuat_excel" runat="server" CausesValidation="False" 
                        CssClass="cssButton" Height="25px"  Text="Xuất Excel" 
                        Width="98px" onclick="m_cmd_xuat_excel_Click"/>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:button id="btnCancel" accessKey="r" CssClass="cssButton" runat="server" 
                Width="98px" Text="Xóa trắng(r)" CausesValidation="false" onclick="btnCancel_Click" />
		</td>
	</tr>
    <tr>
		<td class="cssPageTitleBG" colspan="3">
		    <asp:label id="lbl_danh_sach_dot_tt_result" runat="server" CssClass="cssPageTitle" 
                Text="Danh sách Đợt thanh toán"/>
		</td>
	</tr>	
    <tr>
		<td align="left">
                <asp:label id="m_lbl_thong_bao" runat="server" CssClass="cssManField" />
        </td>
         <td align="left">  
        </td>

	</tr>	
    <tr>
		<td align="right">
                <asp:label id="Label1" runat="server" Text="Đơn vị thanh toán" CssClass="cssManField" />
        </td>
         <td align="left">  
			
		    <asp:DropDownList id="m_cbo_dm_loai_don_vi_thanh_toan_search" runat="server" Width="65%"  AutoPostBack="true"
                        CssClass="cssDorpdownlist" 
                 onselectedindexchanged="m_cbo_dm_loai_don_vi_thanh_toan_search_SelectedIndexChanged"  />
        </td>

	</tr>
    <tr>
		<td align="right">
                <asp:label id="Label2" runat="server" Text="Trạng thái đợt thanh toán" CssClass="cssManField" />
        </td>
         <td align="left">  
			
		    <asp:DropDownList id="m_cbo_dm_trang_thai_dot_thanh_toan_search" runat="server" Width="30%" AutoPostBack="true"
                        CssClass="cssDorpdownlist" 
                 onselectedindexchanged="m_cbo_dm_trang_thai_dot_thanh_toan_search_SelectedIndexChanged"  />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <asp:label id="Label12" runat="server" Text="Tháng thanh toán" 
                 CssClass="cssManField" />
			
		    &nbsp;
			
		    <asp:DropDownList id="m_cbo_thang_thanh_toan" runat="server" 
                 Width="10%" AutoPostBack="true"
                        CssClass="cssDorpdownlist" 
                 onselectedindexchanged="m_cbo_thang_thanh_toan_SelectedIndexChanged">
                <asp:ListItem Value="0">Tất cả</asp:ListItem>
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
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
             </asp:DropDownList>
        </td>

	</tr>
	<tr>
		<td align="center" colspan="3" style="height:450px;" valign="top">
		    &nbsp;
           
              <asp:GridView ID="m_grv_dm_dot_thanh_toan" runat="server" AutoGenerateColumns="False" 
                Width="100%" DataKeyNames="ID" 
                CellPadding="4" ForeColor="#333333" GridLines="Both" 
                AllowPaging="True" AllowSorting="True" PageSize="20" 
                onpageindexchanging="m_grv_dm_dot_thanh_toan_PageIndexChanging" 
                onrowdeleting="m_grv_dm_dot_thanh_toan_RowDeleting" 
                onselectedindexchanging="m_grv_dm_dot_thanh_toan_SelectedIndexChanging">
                  <AlternatingRowStyle BackColor="White" />
                <Columns>
                  <asp:TemplateField HeaderText="Xóa">
                    <ItemTemplate> <asp:LinkButton ID = "lbt_delete" runat="server" Text="Xóa" 
                     CommandName="Delete" CausesValidation="false" OnClientClick="return confirm ('Xóa đợt thanh toán sẽ xóa toàn bộ các thanh toán trong đợt thanh toán đó. Bạn có thực sự muốn xóa đợt thanh tóan này?')"></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="3%" />
                    </asp:TemplateField>
                    <asp:CommandField SelectText="Sửa" ShowSelectButton="True" HeaderText="Sửa" ItemStyle-Width="2%" />
                    <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="3%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="MA_DOT_TT" HeaderText="Mã đợt thanh toán" 
                        Visible="true">
                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle></asp:BoundField>
                    <asp:BoundField DataField="TEN_DOT_TT" HeaderText="Tên đợt TT" ItemStyle-Width="15%" />
                    
                    <asp:TemplateField HeaderText="Đơn vị TT" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%# mapping_don_vi_thanh_toan(CIPConvert.ToDecimal(Eval("ID_DON_VI_THANH_TOAN"))) %></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Trạng thái đợt TT" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%# mapping_trang_thai_dot_thanh_toan(CIPConvert.ToDecimal(Eval("ID_TRANG_THAI_DOT_TT"))) %></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:TemplateField>
                      <asp:BoundField DataField="NGAY_TT_DU_KIEN" HeaderText="Ngày thanh toán dự kiến" DataFormatString="{0:dd/MM/yyyy}"
                        ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="NGAY_THU_CHUNG_TU" HeaderText="Ngày thu chứng từ" DataFormatString="{0:dd/MM/yyyy}"
                        ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:BoundField>
                     <asp:BoundField DataField="GHI_CHU" HeaderText="Ghi chú" >
                        <ItemStyle HorizontalAlign="Center" Width="17%"></ItemStyle></asp:BoundField>
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

