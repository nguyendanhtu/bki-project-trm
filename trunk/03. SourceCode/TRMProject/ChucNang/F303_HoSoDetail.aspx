﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F303_HoSoDetail.aspx.cs" Inherits="ChucNang_F303_HoSoDetail" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script language="javascript" type="text/javascript">
        function confirm_delete() {
            if (confirm("Are you sure you want to delete the contact?") == true)
                return true;
            else
                return false;
        }

        function OpenSiteFromUrl(siteUrl) {
            var name = 'ProfileForm';
            var appearence = 'dependent=yes,menubar=no,resizable=yes,' +
                        'status=no,toolbar=no,titlebar=no, scrollbars=1' +
                        'left=100,top=50,width=800px,height=600px';
            var openWindow = window.open(siteUrl, name, appearence);
            openWindow.focus();
        }
    </script>
    <table cellspacing="0" cellpadding="2" style="width: 100%;" class="cssTable" border="0">
        <tr>
            <td class="cssPageTitleBG" colspan="3">
                <asp:Label ID="lblUser" runat="server" CssClass="cssPageTitle" 
                    Text="Hồ sơ detail" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:ValidationSummary ID="vdsCategory" runat="server" CssClass="cssManField" Font-Bold="true" />
                <asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField" />
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 15%;">
                &nbsp;
            </td>
            <td style="width: 30%;">
                &nbsp;
            </td>
            <td style="width: 5%;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblHoSo" CssClass="cssManField" runat="server" Text="&lt;U&gt;T&lt;/U&gt;ên hồ sơ"
                    AccessKey="L" />
            </td>
            <td align="left">
                <asp:DropDownList ID="m_cbo_ho_so" runat="server" Width="323px">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblLoaiHoSo" CssClass="cssManField" runat="server" 
                    Text="&lt;U&gt;L&lt;/U&gt;oại hồ sơ" />
            </td>
            <td align="left">
                <asp:DropDownList ID="m_cbo_loai_ho_so" runat="server" Width="323px">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblHoSoDinhKem" CssClass="cssManField" runat="server" 
                    Text="&lt;U&gt;H&lt;/U&gt;ồ sơ đính kèm" />
            </td>
            <td valign="top" colspan="2">
                <asp:DropDownList ID="m_cbo_ho_so_dinh_kem" runat="server" Width="323px" 
                    AccessKey="M">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblGhiChu" CssClass="cssManField" runat="server" Text="&lt;U&gt;G&lt;/U&gt;hi chú " />
            </td>
            <td valign="top" colspan="2">
                <asp:TextBox ID="m_txt_ghi_chu" runat="server" TextMode="MultiLine" Width="495px"
                    Height="83px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;
            </td>
            <td valign="top" colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="2" align="left">
                <asp:Button ID="m_cmd_tao_moi" AccessKey="c" CssClass="cssButton" runat="server"
                    Width="98px" Text="Tạo mới(c)" />&nbsp;
                <asp:Button ID="m_cmd_cap_nhat" AccessKey="u" CssClass="cssButton" runat="server"
                    Width="98px" Text="Cập nhật(u)" />&nbsp;
                <asp:Button ID="btnCancel" AccessKey="r" CssClass="cssButton" runat="server" Width="98px"
                    Text="Xóa trắng(r)" />
                <asp:HiddenField ID="hdf_id" runat="server" Value="" />
            </td>
        </tr>
        <tr>
            <td class="cssPageTitleBG" colspan="3">
                <asp:Label ID="Label11" runat="server" CssClass="cssPageTitle" 
                    Text="Danh sách hồ sơ detail" />
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="m_lbl_thong_bao" Visible="false" runat="server" CssClass="cssManField" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblLocTenHoSo" CssClass="cssManField" runat="server" 
                    Text="&lt;U&gt;T&lt;/U&gt;ên hồ sơ " />
            </td>
            <td>
                <asp:DropDownList ID="m_cbo_loc_ten_ho_so" runat="server" Width="310px" 
                    AutoPostBack="True" />
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblLocLoaiHoSo" CssClass="cssManField" runat="server" 
                    Text="&lt;U&gt;L&lt;/U&gt;oại hồ sơ" />
                <asp:DropDownList ID="m_cbo_loc_loai_ho_so" runat="server" Width="310px" 
                    AutoPostBack="True" />
            </td>
        </tr>
        <tr>
            <td align="right" valign="baseline">
                <asp:Label ID="lblLocNgayCapNhat" CssClass="cssManField" runat="server" Text="&lt;U&gt;N&lt;/U&gt;gày cập nhật " />
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label1" CssClass="cssManField" runat="server" Text="Từ ngày" />
                &nbsp;
            </td>
            <td>
                <ew:CalendarPopup ID="m_dat_ngay_bat_dau_tu" runat="server" ControlDisplay="TextBoxImage"
                    GoToTodayText="Hôm nay:" ImageUrl="~/Images/cal.gif" Nullable="True" NullableLabelText=""
                    ShowGoToToday="True" Width="30%" SelectedDate="" Text="" Culture="vi-VN" DisableTextboxEntry="False">
                    <WeekdayStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                        ForeColor="Black" />
                    <WeekendStyle BackColor="LightGray" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                        ForeColor="Black" />
                    <OffMonthStyle BackColor="AntiqueWhite" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                        Font-Size="XX-Small" ForeColor="Gray" />
                    <SelectedDateStyle BackColor="Yellow" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                        Font-Size="XX-Small" ForeColor="Black" />
                    <MonthHeaderStyle BackColor="Yellow" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                        Font-Size="XX-Small" ForeColor="Black" />
                    <DayHeaderStyle BackColor="Orange" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                        ForeColor="Black" />
                    <ClearDateStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                        ForeColor="Black" />
                    <GoToTodayStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                        ForeColor="Black" />
                    <TodayDayStyle BackColor="LightGoldenrodYellow" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                        Font-Size="XX-Small" ForeColor="Black" />
                    <HolidayStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                        ForeColor="Black" />
                </ew:CalendarPopup>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label2" CssClass="cssManField" runat="server" Text="Đến ngày" />&nbsp;
                <ew:CalendarPopup ID="m_dat_ngay_ket_thuc_tu" runat="server" ControlDisplay="TextBoxImage"
                    GoToTodayText="Hôm nay:" ImageUrl="~/Images/cal.gif" Nullable="True" NullableLabelText=""
                    ShowGoToToday="True" Width="30%" SelectedDate="" Text="" Culture="vi-VN" DisableTextboxEntry="False">
                    <WeekdayStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                        ForeColor="Black" />
                    <WeekendStyle BackColor="LightGray" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                        ForeColor="Black" />
                    <OffMonthStyle BackColor="AntiqueWhite" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                        Font-Size="XX-Small" ForeColor="Gray" />
                    <SelectedDateStyle BackColor="Yellow" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                        Font-Size="XX-Small" ForeColor="Black" />
                    <MonthHeaderStyle BackColor="Yellow" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                        Font-Size="XX-Small" ForeColor="Black" />
                    <DayHeaderStyle BackColor="Orange" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                        ForeColor="Black" />
                    <ClearDateStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                        ForeColor="Black" />
                    <GoToTodayStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                        ForeColor="Black" />
                    <TodayDayStyle BackColor="LightGoldenrodYellow" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                        Font-Size="XX-Small" ForeColor="Black" />
                    <HolidayStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                        ForeColor="Black" />
                </ew:CalendarPopup>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblLocHoSoDinhKem" CssClass="cssManField" runat="server" 
                    Text="&lt;U&gt;H&lt;/U&gt;ồ sơ đính kèm" />
            </td>
            <td>
                <asp:DropDownList ID="m_cbo_loc_ho_so_dinh_kem" runat="server" Width="310px" 
                    AutoPostBack="True" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3" style="height: 450px;" valign="top">
                &nbsp;
                <asp:GridView ID="m_grv_ho_so_detail" AllowPaging="True" runat="server" AutoGenerateColumns="False"
                    Width="100%" DataKeyNames="ID" CellPadding="4" ForeColor="#333333" 
                    AllowSorting="True">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbt_delete" runat="server" CommandName="Delete" Text="Xóa" ToolTip="Xóa"
                                    OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')">
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField SelectText="Sửa" ShowSelectButton="True" />
                        <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ID_LOAI_TU_DIEN" HeaderText="Loại từ điển" Visible="False">
                            <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="HO_SO" HeaderText="Hồ sơ" />
                        <asp:BoundField DataField="LOAI_HO_SO" HeaderText="Loại hồ sơ" />
                        <asp:BoundField DataField="NGAY_CAP_NHAT" DataFormatString="{0:N1}" HeaderText="Ngày cập nhật"
                            ItemStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="HO_SO_DINH_KEM" HeaderText="Hồ sơ đính kèm" 
                            ItemStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="GHI_CHU" DataFormatString="{0:N0}" HeaderText="Ghi chú" />
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

