<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F707_BaoCaoChiTietCongViecGVCMTheoTrangThai.aspx.cs" Inherits="BaoCao_F707_BaoCaoChiTietCongViecGVCMTheoTrangThai" %>
<%@ Register assembly="eWorld.UI" namespace="eWorld.UI" tagprefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
    <tr>
		<td class="cssPageTitleBG" colspan="4">
		    <asp:label id="m_lbl_ds_cv_gv" runat="server" CssClass="cssPageTitle" 
                Text="F707 - Báo cáo chi tiết công việc giảng viên chuyên môn"/>
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
			        <asp:label id="Label1" CssClass="cssManField" runat="server" 
                Text="Tên giảng viên" />
                         </td>
                <td align="left" style="width:38%;">
            <asp:DropDownList id="m_cbo_ten_giang_vien_loc" runat="server" AutoPostBack="true"
                        CssClass="cssDorpdownlist" Width="90%" 
                onselectedindexchanged="m_cbo_ten_giang_vien_loc_SelectedIndexChanged">
                    </asp:DropDownList>
                    </td>
                <td align="left">
                     <asp:label id="m_lbl_thong_bao_giang_vien" runat="server" CssClass="cssManField" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width:12%;">
			<asp:label id="lbl_so_hop_dong" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;S&lt;/U&gt;ố hợp đồng" />
                         </td>
                <td align="left" style="width:38%;">
                    <asp:DropDownList id="m_cbo_so_hop_dong_loc" runat="server" AutoPostBack="true"
                        CssClass="cssDorpdownlist" Width="90%" 
                onselectedindexchanged="m_cbo_so_hop_dong_loc_SelectedIndexChanged">
                    </asp:DropDownList>
                    </td>
                <td align="left">
                     <asp:label id="m_lbl_thong_bao_so_hd" runat="server" CssClass="cssManField" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width:12%;">
			<asp:label id="lbl_noi_dung_tt" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;C&lt;/U&gt;ông việc" />
                         </td>
                <td align="left" colspan="2" style="width:88%;">
                &nbsp;<asp:DropDownList id="m_cbo_noi_dung_thanh_toan" runat="server" 
                        CssClass="cssDorpdownlist" Width="93%" 
                        onselectedindexchanged="m_cbo_noi_dung_thanh_toan_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                    </td>
            </tr>
             <tr>
                <td align="right" style="width:12%;">
			<asp:label id="lbl_trang_thai" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;T&lt;/U&gt;rạng thái" />
                         </td>
                <td align="left" style="width:38%;">
                &nbsp;<asp:DropDownList id="m_cbo_trang_thai_cv_gv" runat="server"  AutoPostBack="true"
                        CssClass="cssDorpdownlist" 
                        onselectedindexchanged="m_cbo_trang_thai_cv_gv_SelectedIndexChanged"  >
                    </asp:DropDownList>
                    </td>
                    <td>
                     <asp:label id="m_lbl_thong_bao_trang_thai" runat="server" CssClass="cssManField" />
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
	    <td align="left" style="width:50%;">
            <asp:label id="lbl_tb_cap_nhat" CssClass="cssLabel" runat="server" 
                Text="(Dùng trong trường hợp muốn lọc dữ liệu.)" />
        </td>
		</td> 
            </tr>
            <tr>
               <td align="right" style="width:12%;">
			
                         </td>
		<td colspan="2" align="left">
			<asp:label id="lbl_tu_khoa_tim_kiem" CssClass="cssLabel" runat="server" 
                Text="(Từ khóa tìm kiếm: Số hợp đồng, nội dung thanh toán, trạng thái, họ và tên giảng viên, user người tạo...)" />
		</td> 
            </tr>
            <tr>
	    <td></td>
		<td colspan="2" align="left">
			&nbsp;&nbsp;
            <asp:button id="m_cmd_loc_du_lieu" accessKey="c" CssClass="cssButton" CausesValidation="false"
                runat="server" Width="98px" Height="25px"  Text="Lọc dữ liệu(l)" onclick="m_cmd_loc_du_lieu_Click" 
                />&nbsp;&nbsp;
                <asp:Button ID="m_cmd_xuat_excel" runat="server" CausesValidation="False" 
                        CssClass="cssButton" Height="25px"  Text="Xuất Excel" 
                        Width="98px" onclick="m_cmd_xuat_excel_Click"/>
			        &nbsp;&nbsp;
			        </td>
	</tr>
            </table>        
        </td>
    </tr> 
          <tr>
        <td colspan="4" align="left">
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
		<td align="center" colspan="4" style="height:450px;" valign="top">
		    &nbsp;
            <asp:GridView ID="m_grv_gd_assign_su_kien_cho_giang_vien" runat="server" AutoGenerateColumns="False" 
                Width="100%" DataKeyNames="ID" ShowFooter="true"
                CellPadding="4" ForeColor="#333333" 
                AllowPaging="True" AllowSorting="True" PageSize="20" 
                onpageindexchanging="m_grv_gd_assign_su_kien_cho_giang_vien_PageIndexChanging">
                  <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Số hợp đồng">
                        <ItemTemplate>
                            <%# Eval("SO_HOP_DONG")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Tên giảng viên">
                        <ItemTemplate>
                            <%# Eval("HO_VA_TEN_GIANG_VIEN")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Công việc">
                        <ItemTemplate>
                            <%# Eval("TEN_NOI_DUNG")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Đơn giá" DataField="DON_GIA" DataFormatString="{0:N0}" ItemStyle-HorizontalAlign="Right" />
                    <asp:TemplateField HeaderText="Số lượng" FooterText="Tổng tiền: "  FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <%#get_so_luong(Eval("ID_TRANG_THAI"), Eval("SO_LUONG_HE_SO"), Eval("SO_LUONG_NGHIEM_THU"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Số tiền thanh toán">
                        <FooterStyle HorizontalAlign="Right"/>
                        <ItemTemplate>
                            <asp:Label Text='<%# get_so_tien_thanh_toan(Eval("DON_GIA"),Eval("ID_TRANG_THAI"), Eval("SO_LUONG_HE_SO"), Eval("SO_LUONG_NGHIEM_THU")) %>' runat="server" ID="m_lbl_so_tien_nghiem_thu"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right"/>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Ngày đặt hàng" DataField="NGAY_DAT_HANG" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false" ItemStyle-HorizontalAlign="Center"/>
                     <asp:TemplateField HeaderText="Trạng thái">
                        <ItemTemplate>
                            <%# Eval("TEN_TRANG_THAI")%>
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

