<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F706_TongHopCongViecGVCM.aspx.cs" Inherits="BaoCao_F706_TongHopCongViecGVCM" %>
<%@ Register assembly="eWorld.UI" namespace="eWorld.UI" tagprefix="ew" %>
<%@ Import Namespace="IP.Core.IPCommon" %>
<%@ Import Namespace="WebDS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
    <tr>
		<td class="cssPageTitleBG" colspan="4">
		    <asp:label id="m_lbl_ds_cv_gv" runat="server" CssClass="cssPageTitle" 
                Text="Duyệt chuyển thanh toán"/>
		</td>
	</tr>
          <tr>
        <td colspan="2" align="left">
		</td>
    </tr> 
    <tr>
         <td align="right" style="width:15%;"><asp:label id="Label1" CssClass="cssManField" runat="server" 
                Text="Tháng" />
        </td>
        <td align="left" style="width:30%;">
            <asp:DropDownList id="m_cbo_thang_dat_hang" runat="server" AutoPostBack="true"
                        CssClass="cssDorpdownlist" Width="40%"
                onselectedindexchanged="m_cbo_thang_dat_hang_SelectedIndexChanged">
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		            </td>
                    <td  align="right">
                        <asp:label id="Label4" CssClass="cssManField" runat="server"  style="width:10%;"
                Text="Năm" />
                    </td>
                    <td style="width:45%;">
            <asp:DropDownList id="m_cbo_nam_dat_hang" runat="server" AutoPostBack="true"
                        CssClass="cssDorpdownlist" Width="30%" 
                            onselectedindexchanged="m_cbo_nam_dat_hang_SelectedIndexChanged">
                    </asp:DropDownList>
                    </td>
    </tr>
    <tr>
         <td align="right" style="width:12%;"><asp:label id="Label3" CssClass="cssManField" runat="server" 
                Text="Trạng thái công việc" />
        </td>
        <td align="left" colspan="2">
            <asp:DropDownList id="m_cbo_trang_thai_cv_loc" runat="server" AutoPostBack="true"
                        CssClass="cssDorpdownlist" Width="70%" 
                onselectedindexchanged="m_cbo_trang_thai_cv_loc_SelectedIndexChanged">
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td></td>
            </tr>
	<tr>
        <td>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:button id="m_cmd_xuat_excel" accessKey="u" CssClass="cssButton"
                runat="server" Width="98px" Height="25px"  Text="Xuất Excel" 
                CausesValidation="false" OnClick="m_cmd_xuat_excel_Click"/>
        </td>
               <td> &nbsp;</td>
    </tr>
    <tr>
		<td align="center" colspan="4" valign="top">
		    &nbsp;
            <asp:GridView ID="m_grv_gd_assign_su_kien_cho_giang_vien" runat="server" AutoGenerateColumns="False"
                Width="100%" DataKeyNames="ID" ShowFooter="true"
                CellPadding="4" ForeColor="#333333" 
                AllowPaging="True" AllowSorting="True" PageSize="35"
                onpageindexchanging="m_grv_gd_assign_su_kien_cho_giang_vien_PageIndexChanging">
                  <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Công việc">
                        <ItemTemplate>
                            <%# Eval("TEN_NOI_DUNG")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Số lượng" DataField="TONG_SO_LUONG" 
                        DataFormatString="{0:0}" ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Đơn vị tính" FooterText="Tổng tiền: " FooterStyle-HorizontalAlign="Right"
                     ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%# Eval("DON_VI_TINH")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField Visible="false" HeaderText="Đơn giá" DataField="DON_GIA" FooterText="Tổng tiền: "
                        DataFormatString="{0:N0}" ItemStyle-HorizontalAlign="Right" >
<ItemStyle HorizontalAlign="Right"></ItemStyle>
                    </asp:BoundField>
                       <asp:BoundField HeaderText="Thành tiền" DataField="THANH_TIEN" FooterText="Tổng tiền: "
                       FooterStyle-HorizontalAlign="Right"
                        DataFormatString="{0:N0}" ItemStyle-HorizontalAlign="Right" >
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                    </asp:BoundField>
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
</table>
</asp:Content>

