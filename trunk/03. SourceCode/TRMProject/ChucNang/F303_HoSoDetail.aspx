<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="F303_HoSoDetail.aspx.cs" Inherits="ChucNang_F303_HoSoDetail" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Import Namespace="IP.Core.IPCommon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style>
        .cssTextBoxnumber
        {
            text-align: right;
        }
        .style1
        {
            width: 11%;
        }
        .style2
        {
            width: 478px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table cellspacing="0" cellpadding="2" style="width: 100%;" class="cssTable" border="0">
        <tr>
            <td class="cssPageTitleBG">
                <asp:Label ID="m_lbl_thong_tin_ho_so" runat="server" CssClass="cssPageTitle" Text="Thông tin hồ sơ" />
            </td>
        </tr>
        <tr>
            <td>
                <table cellspacing="0" cellpadding="2" style="width: 100%;" class="cssTable" border="0">
                    <tr>
                        <td align="right" style="width: 7%;">
                            <asp:Label ID="Label1" CssClass="cssManField" runat="server" Text="Giảng viên: " />
                        </td>
                        <td align="left" style="width: 10%;">
                            &nbsp;
                            <asp:Label ID="m_lbl_giang_vien" runat="server" MaxLength="64" Width="96%" />
                        </td>
                        <td align="left" style="width: 1%;">
                            &nbsp;
                        </td>
                        <td align="right" style="width: 7%;">
                            <asp:Label ID="Label5" CssClass="cssManField" runat="server" Text="Ngày cập nhật: " />
                        </td>
                        <td align="left" style="width: 10%;">
                            &nbsp;
                            <asp:Label ID="m_lbl_dat_ngay_cap_nhat" runat="server" />
                        </td>
                        <td align="left" style="width: 1%;">
                            &nbsp;
                        </td>
                        <td align="right" style="width: 5%;">
                            &nbsp;
                        </td>
                        <td align="left" style="width: 10%;">
                            &nbsp;
                        </td>
                        <td align="left" style="width: 1%;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 7%;">
                            <asp:Label ID="Label4" CssClass="cssManField" runat="server" Text="Đơn vị thanh toán: " />
                        </td>
                        <td align="left" style="width: 10%;">
                            &nbsp;<asp:Label ID="m_lbl_don_vi_thanh_toan" runat="server"></asp:Label>
                        </td>
                        <td align="left" style="width: 1%;">
                            &nbsp;
                        </td>
                        <td align="right" style="width: 5%;">
                            <asp:Label ID="Label6" CssClass="cssManField" runat="server" Text="Trạng thái: " />
                        </td>
                        <td align="left" colspan="3">
                            &nbsp;<asp:Label ID="m_lbl_trang_thai" runat="server" />
                        </td>
                        <td align="left" style="width: 10%;">
                        </td>
                        <td align="left" style="width: 1%;">
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 5%;">
                        </td>
                        <td align="left" style="width: 10%;">
                            &nbsp;
                        </td>
                        <td align="left" style="width: 1%;">
                        </td>
                        <td align="left" style="width: 5%;">
                            &nbsp;
                        </td>
                        <td align="left" style="width: 10%;">
                            &nbsp;
                        </td>
                        <td align="left" style="width: 1%;">
                        </td>
                        <td align="right" style="width: 5%;">
                        </td>
                        <td align="left" style="width: 10%;">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="cssPageTitleBG">
                <asp:Label ID="lblUser" runat="server" CssClass="cssPageTitle" Text="Hồ sơ detail " />
            </td>
        </tr>
        <tr>
            <td>
                <asp:ValidationSummary ID="vdsCategory" runat="server" CssClass="cssManField" Font-Bold="true" />
                <asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField" />
            </td>
        </tr>
        <tr>
            <td>
                <table cellspacing="0" cellpadding="2" style="width: 100%;" class="cssTable" border="0">
                    <tr>
                        <td align="right" class="style1">
                            &nbsp;
                        </td>
                        <td align="left" class="style2">
                            &nbsp;
                        </td>
                        <td align="right" style="width: 7%;">
                            &nbsp;
                        </td>
                        <td align="left" style="width: 1%;">
                            &nbsp;
                        </td>
                        <td align="right" style="width: 5%;">
                            &nbsp;
                        </td>
                        <td align="left" style="width: 10%;">
                            &nbsp;
                        </td>
                        <td align="left" style="width: 1%;">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table cellspacing="0" cellpadding="2" style="width: 100%;" class="cssTable" border="0">
                    <tr>
                        <td align="right" style="width: 7%;">
                            <asp:Label ID="lblLoaiHoSo" CssClass="cssManField" runat="server" Text="Loại hồ sơ : " />
                        </td>
                        <td align="left" style="width: 10%;">
                            <asp:DropDownList ID="m_cbo_loai_ho_so" Width="50%" runat="server" 
                                AutoPostBack="true" 
                                onselectedindexchanged="m_cbo_loai_ho_so_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td align="right" style="width: 5%;">
                            &nbsp;
                        </td>
                        <td align="right" style="width: 7%;">
                            &nbsp;
                        </td>
                        <td align="left" style="width: 1%;">
                            &nbsp;
                        </td>
                        <td align="right" style="width: 5%;">
                            &nbsp;
                        </td>
                        <td align="left" style="width: 10%;">
                            &nbsp;
                        </td>
                        <td align="left" style="width: 1%;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 7%;">
                            <asp:Label ID="lblHoSoDinhKem" CssClass="cssManField" runat="server" Text="Hồ sơ đính kèm : " />
                        </td>
                        <td align="left" style="width: 10%;">
                            <asp:FileUpload ID="m_up_ho_so" runat="server" />
                            <br />
                            <br />
                            <asp:Label ID="lblHoSoDinhKem0" CssClass="cssManField" runat="server" 
                                Text="Đổi tên hồ sơ đính kèm : " />
                            <asp:TextBox ID="m_txt_ten_hs_dinh_kem" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="Button1" runat="server" onclick="Upload_Click" Text="Upload" />
                            <asp:Label ID="m_lbl_ten_hs_dinh_kem" runat="server" Text="Label" 
                                Visible="False"></asp:Label>
                            <asp:Label ID="m_lbl_id_ho_so" runat="server" Text="Label" Visible="False"></asp:Label>
                        </td>
                        <td align="right" style="width: 5%;">
                            &nbsp;
                        </td>
                        <td align="right" style="width: 7%;">
                            &nbsp;
                        </td>
                        <td align="left" style="width: 1%;">
                            &nbsp;
                        </td>
                        <td align="right" style="width: 5%;">
                            &nbsp;
                        </td>
                        <td align="left" style="width: 10%;">
                            &nbsp;
                        </td>
                        <td align="left" style="width: 1%;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 7%;">
                            <asp:Label ID="lblGhiChu" CssClass="cssManField" runat="server" Text="Ghi Chú : " />
                        </td>
                        <td align="left" style="width: 10%;">
                            <asp:TextBox ID="m_txt_ghi_chu" runat="server" TextMode="MultiLine" Width="495px"
                                Height="83px"></asp:TextBox>
                        </td>
                        <td align="right" style="width: 5%;">
                            &nbsp;
                        </td>
                        <td align="right" style="width: 7%;">
                            &nbsp;
                        </td>
                        <td align="left" style="width: 1%;">
                            &nbsp;
                        </td>
                        <td align="right" style="width: 5%;">
                            &nbsp;
                        </td>
                        <td align="left" style="width: 10%;">
                            &nbsp;
                        </td>
                        <td align="left" style="width: 1%;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 7%;">
                            &nbsp;
                        </td>
                        <td align="left" style="width: 10%;">
                            <asp:Button ID="m_cmd_luu_du_lieu" AccessKey="s" CssClass="cssButton" runat="server"
                                Width="98px" Text="Tạo phụ lục" Height="24px" 
                                onclick="m_cmd_luu_du_lieu_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="m_cmd_cap_nhat_pl" runat="server" AccessKey="s" CssClass="cssButton"
                                Height="24px" Text="Cập nhật phụ lục" Width="98px" 
                                onclick="m_cmd_cap_nhat_pl_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="m_cmd_thoat0" runat="server" CausesValidation="False" CssClass="cssButton"
                                Height="25px" Text="Xóa trắng" Width="98px" onclick="m_cmd_thoat_Click" />
                        </td>
                        <td align="right" style="width: 5%;">
                            &nbsp;
                        </td>
                        <td align="right" style="width: 7%;">
                            &nbsp;
                        </td>
                        <td align="left" style="width: 1%;">
                            &nbsp;
                        </td>
                        <td align="right" style="width: 5%;">
                            &nbsp;
                        </td>
                        <td align="left" style="width: 10%;">
                            &nbsp;
                        </td>
                        <td align="left" style="width: 1%;">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="cssPageTitleBG" colspan="2">
                <asp:Label ID="Label11" runat="server" CssClass="cssPageTitle" Text="Lọc hồ sơ detail" />
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Button ID="m_cmd_exit" runat="server" AccessKey="s" CssClass="cssButton" Height="24px"
                    Text="Thoát" Width="98px" CausesValidation="false" 
                    onclick="m_cmd_exit_Click" /><br />
                <asp:Label ID="m_lbl_thong_bao" CssClass="cssManField" runat="server"></asp:Label>
                <asp:HiddenField ID="hdf_id_gv" runat="server" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="height: 450px;" valign="top">
                &nbsp;
                <asp:GridView ID="m_grv_gd_ho_so_detail" AllowPaging="True" 
                runat="server" AutoGenerateColumns="False" 
                Width="100%" DataKeyNames="ID"
                CellPadding="4" ForeColor="#333333" 
            AllowSorting="True" onload="Page_Load" 
                    onpageindexchanged="m_cbo_loai_ho_so_SelectedIndexChanged" 
                    onrowdeleting="m_grv_gd_ho_so_gv_detail_RowDeleting" 
                    onselectedindexchanged="m_cbo_loai_ho_so_SelectedIndexChanged" 
                    onselectedindexchanging="m_grv_gd_ho_so_gv_detail_SelectedIndexChanging">
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
                    <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="TEN_LOAI_HO_SO" HeaderText="Tên loại hồ sơ">
                    <ItemStyle Width="30%" HorizontalAlign="Left" />
                    </asp:BoundField>
                     <asp:BoundField DataField="HO_SO_DINH_KEM" HeaderText="Hồ sơ đính kèm">
                    </asp:BoundField>
                     <asp:BoundField DataField="NGAY_CAP_NHAT" HeaderText="Ngày cập nhật" DataFormatString="{0:dd/MM/yyyy}">
                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="GHI_CHU" HeaderText="Ghi chú" />
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
