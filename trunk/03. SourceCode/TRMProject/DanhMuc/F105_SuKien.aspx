<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F105_SuKien.aspx.cs"
    Inherits="DanhMuc_F105_SuKien" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table cellspacing="0" cellpadding="2" style="width: 100%;" class="cssTable" border="0">
        <tr>
            <td class="cssPageTitleBG" colspan="3">
                <asp:Label ID="lblUser" runat="server" CssClass="cssPageTitle" Text="Danh mục sự kiện" />
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
            <td align="right" style="width: 15%;">
                <asp:Label ID="lbl_su_kien" CssClass="cssManField" runat="server" Text="&lt;U&gt;T&lt;/U&gt;ên sự kiện" />
            </td>
            <td style="width: 30%;">
                <asp:TextBox ID="m_txt_ten_su_kien" CssClass="cssTextBox" CausesValidation="false"
                    runat="server" MaxLength="64" Width="495px" />
                &nbsp;
                <asp:CustomValidator ID="m_ct_su_kien" runat="server" ControlToValidate="m_cbo_loai_su_kien"
                    ErrorMessage="Bạn phải nhập tên sự kiện" Display="Static" Text="*" />
            </td>
            <td style="width: 5%;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lbl_loai_su_kien" CssClass="cssManField" runat="server" Text="&lt;U&gt;L&lt;/U&gt;oại sự kiện"
                    AccessKey="L" />
            </td>
            <td align="left">
                <asp:DropDownList ID="m_ddl_loai_su_kien" runat="server" Width="323px">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lbl_ngay_dien_ra" CssClass="cssManField" runat="server" Text="&lt;U&gt;N&lt;/U&gt;gày diễn ra"
                    AccessKey="N" />
            </td>
            <td valign="top" colspan="2">
                <ew:CalendarPopup ID="m_dat_ngay_dien_ra" runat="server" ControlDisplay="TextBoxImage"
                    GoToTodayText="Hôm nay:" ImageUrl="~/Images/cal.gif" Nullable="True" NullableLabelText=""
                    ShowGoToToday="True" Width="320px" SelectedDate="" Text="" Culture="vi-VN" DisableTextboxEntry="False">
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
                <asp:Label ID="lbl_trang_thai" CssClass="cssManField" runat="server" Text="&lt;U&gt;T&lt;/U&gt;rạng thái" />
            </td>
            <td valign="top" colspan="2">
                <asp:DropDownList ID="m_ddl_trang_thai" runat="server" Width="323px" AccessKey="M">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lbl_mo_ta" CssClass="cssManField" runat="server" Text="&lt;U&gt;M&lt;/U&gt;ô tả" />
            </td>
            <td valign="top" colspan="2">
                <asp:TextBox ID="m_txt_mo_ta" runat="server" TextMode="MultiLine" Width="495px" Height="83px"></asp:TextBox>
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
                    Width="98px" Text="Tạo mới(c)" OnClick="m_cmd_tao_moi_Click" />&nbsp;
                <asp:Button ID="m_cmd_cap_nhat" AccessKey="u" CssClass="cssButton" runat="server"
                    Width="98px" Text="Cập nhật(u)" OnClick="m_cmd_cap_nhat_Click" />&nbsp;
                <asp:Button ID="btnCancel" AccessKey="r" CssClass="cssButton" runat="server" Width="98px"
                    Text="Xóa trắng(r)" OnClick="btnCancel_Click" />
                <asp:HiddenField ID="hdf_id" runat="server" Value="" />
            </td>
        </tr>
        <tr>
            <td class="cssPageTitleBG" colspan="3">
                <asp:Label ID="Label11" runat="server" CssClass="cssPageTitle" Text="Danh sách nội dung thanh toán" />
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
                <asp:Label ID="lbl_ghi_chu0" CssClass="cssManField" runat="server" Text="&lt;U&gt;L&lt;/U&gt;oại sự kiện" />
            </td>
            <td>
                <asp:DropDownList ID="m_cbo_loai_su_kien" runat="server" Width="320px" AutoPostBack="True"
                    OnSelectedIndexChanged="m_cbo_loai_su_kien_SelectedIndexChanged" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3" style="height: 450px;" valign="top">
                &nbsp;
                <asp:GridView ID="m_grv_dm_su_kien" AllowPaging="True" runat="server" AutoGenerateColumns="False"
                    Width="100%" DataKeyNames="ID" 
                    OnRowDeleting="m_grv_dm_tu_dien_RowDeleting" OnSelectedIndexChanging="m_grv_dm_su_kien_SelectedIndexChanging"
                    CellPadding="4" ForeColor="#333333" AllowSorting="True" 
                    OnPageIndexChanging="m_grv_dm_su_kien_PageIndexChanging" 
                    onrowediting="m_grv_dm_su_kien_RowEditing">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="Xóa">
                            <ItemTemplate>
                                <asp:LinkButton ToolTip="Xóa" ID="lbt_delete" runat="server" CommandName="Delete"
                                    OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')">
                      <img src="/TRMProject/Images/Button/deletered.png" alt="Delete" />
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sửa">
                            <ItemTemplate>
                                <asp:LinkButton ToolTip="Sửa" ID="lbt_edit" CommandName="Edit" runat="server"><img src="/TRMProject/Images/Button/edit.png" alt="Delete" /></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <%--                       <asp:BoundField DataField="ID_LOAI_TU_DIEN" HeaderText="Loại từ điển" Visible="False">
                            <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                        </asp:BoundField>--%>
                        <asp:BoundField DataField="TEN_SU_KIEN" HeaderText="Tên sự kiện" />
                        <asp:TemplateField HeaderText="Loại sự kiện">
                            <ItemTemplate>
                                <label>
                                    <%# mapping_ma_to_ten(Eval("ID_LOAI_SU_KIEN"))%></label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Trạng thái">
                            <ItemTemplate>
                                <label>
                                    <%# mapping_ma_to_ten(Eval("ID_TRANG_THAI"))%></label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="NGAY_DIEN_RA" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày diễn ra">
                            <ItemStyle Width="6%" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MO_TA" HeaderText="Mô tả" ItemStyle-HorizontalAlign="Center">
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
