<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F610_DuyetChuyenThanhToan.aspx.cs" Inherits="ChucNang_F610_DuyetChuyenThanhToan" %>
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
                Text="Duyệt chuyển thanh toán"/>
		</td>
	</tr>
          <tr>
        <td colspan="3" align="left">
		   <asp:label id="m_lbl_thong_bao_sau_cap_nhat" runat="server" CssClass="cssManField" />
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
                Width="100%" DataKeyNames="ID" 
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
                        DataFormatString="{0:N0}" ItemStyle-HorizontalAlign="Right" >
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                     <asp:TemplateField HeaderText="Số tiền nghiệm thu">
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
    <tr>
        <td>
            <asp:button id="m_cmd_duyet_ke_hoach" accessKey="u" CssClass="cssButton"
                runat="server" Width="98px" Height="25px"  Text="Duyệt chuyển" CausesValidation="false"
                onclick="m_cmd_duyet_ke_hoach_Click"/>
        </td>
               <td> <asp:button id="m_cmd_huy_chuyen_duyet_thanh_toan" accessKey="u" 
                       CssClass="cssButton" Visible="false"
                runat="server" Width="98px" Height="25px"  Text="Hủy duyệt" 
                       CausesValidation="false" onclick="m_cmd_huy_chuyen_duyet_thanh_toan_Click"/>
        </td>
    </tr>
</table>
</asp:Content>

