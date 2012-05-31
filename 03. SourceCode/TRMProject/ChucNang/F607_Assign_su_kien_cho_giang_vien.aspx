<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F607_Assign_su_kien_cho_giang_vien.aspx.cs" Inherits="ChucNang_F607_Assign_su_kien_cho_giang_vien" %>
<%@ Register assembly="eWorld.UI" namespace="eWorld.UI" tagprefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
    <tr>
		<td class="cssPageTitleBG" colspan="4">
		    <asp:label id="m_lbl_ds_gv_sk" runat="server" CssClass="cssPageTitle" 
                Text="Danh sách Giảng viên - Sự kiện"/>
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
			<asp:label id="lbl_loai_su_kien" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;L&lt;/U&gt;oại sự kiện" />
                         </td>
                <td align="left" style="width:38%;">
                &nbsp;<asp:DropDownList id="m_cbo_loai_su_kien" runat="server" 
                        CssClass="cssDorpdownlist" Width="85%" AutoPostBack="true"
                        onselectedindexchanged="m_cbo_loai_su_kien_SelectedIndexChanged">
                    </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <td align="right" style="width:12%;">
			<asp:label id="lbl_ten_su_kien" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;S&lt;/U&gt;ự kiện" />
                         </td>
                <td align="left" style="width:38%;">
                &nbsp;<asp:DropDownList id="m_cbo_su_kien" runat="server" 
                        CssClass="cssDorpdownlist" Width="85%"
                        onselectedindexchanged="m_cbo_su_kien_SelectedIndexChanged" >
                    </asp:DropDownList>
                    </td>
                <td align="right" style="width:12%;">
                    			
			<asp:label id="lbl_ten_giang_vien" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;T&lt;/U&gt;ên giảng viên" />
                    			
		            </td>
                <td align="left" style="width:38%;">
                     <asp:DropDownList id="m_cbo_ten_giang_vien" runat="server" 
                        CssClass="cssDorpdownlist" Width="85%" AutoPostBack="true"
                         onselectedindexchanged="m_cbo_ten_giang_vien_SelectedIndexChanged"  >
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" style="width:12%;">
			<asp:label id="lbl_so_tien_gv_huong" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;S&lt;/U&gt;ố tiền GV hưởng" />
                         </td>
                <td align="left" style="width:38%;">
                &nbsp;<asp:TextBox ID="m_txt_so_tien_gv_huong" runat="server" CssClass="cssTextBox" 
                        Width="84%"></asp:TextBox>
                 &nbsp;<asp:CompareValidator runat="server" id="CompareValidator2" Operator="GreaterThanEqual" Type="Currency"
                Display="Dynamic" ValueToCompare="0" ControlToValidate="m_txt_so_tien_gv_huong" Text="*" ErrorMessage = "Số tiền nhập không đúng định dạng" CssClass="cssManField" />
                    </td>
            <td align="right" style="width:12%;">
                    			
			<asp:label id="lbl_vai_tro_giang_vien" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;V&lt;/U&gt;ai trò giảng viên" />
                    			
		            </td>
                <td align="left" style="width:38%;">
                     <asp:DropDownList id="m_cbo_vai_tro_gv" runat="server" 
                        CssClass="cssDorpdownlist" Width="85%"  >
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                    <td align="right" style="width:12%;">
			<asp:label id="lbl_so_hd" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;S&lt;/U&gt;ố hợp đồng (nếu có)" />
                         </td>
                <td align="left" style="width:38%;">
                &nbsp;<asp:DropDownList id="m_cbo_so_hd" runat="server" 
                        CssClass="cssDorpdownlist" Width="85%"  >
                    </asp:DropDownList>
                    </td>
                    <td align="right" style="width:12%;">
			<asp:label id="lbl_ngay_tt" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;T&lt;/U&gt;hanh toán ngay" />
                         </td>
                <td align="left" style="width:38%;"><asp:RadioButtonList ID="m_rdl_thanh_toan_ngay" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="Y" Selected="True">Có</asp:ListItem>
                <asp:ListItem Value="N">Không</asp:ListItem>
            </asp:RadioButtonList>
                    </td>
            </tr>
             <tr>
                <td align="right" style="width:12%;">
			<asp:label id="lbl_trang_thai" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;T&lt;/U&gt;rạng thái" />
                         </td>
                <td align="left" style="width:38%;">
                &nbsp;<asp:DropDownList id="m_cbo_trang_thai_sk" runat="server" 
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
                        Width="93%"></asp:TextBox>
                    </td>
            </tr>
            <tr>
               <td align="right" style="width:12%;">
			<asp:label id="lbl_tu_khoa" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;T&lt;/U&gt;ừ khóa tìm kiếm" />
                         </td>
		<td align="left" style="width:38%;">
		    &nbsp;<asp:TextBox ID="m_txt_tu_khoa" runat="server" CssClass="cssTextBox" 
                        Width="98%"></asp:TextBox>
	    <td align="left" style="width:50%;" colspan="2">
            <asp:label id="Label1" CssClass="cssLabel" runat="server" 
                Text="(Dùng trong trường hợp muốn lọc dữ liệu.)" />
        </td>
		</td> 
            </tr>
            <tr>
               <td align="right" style="width:12%;">
			
                         </td>
		<td colspan="3" align="left">
			<asp:label id="Label2" CssClass="cssLabel" runat="server" 
                Text="(Từ khóa tìm kiếm: Tên sự kiện, tên giảng viên, vai trò của giảng viên, trạng thái...)" />
		</td> 
            </tr>
            <tr>
	    <td></td>
		<td colspan="3" align="left">
			&nbsp;&nbsp;
            <asp:button id="m_cmd_loc_du_lieu" accessKey="c" CssClass="cssButton" 
                runat="server" Width="98px" Height="25px"  Text="Lọc dữ liệu(l)" 
                />&nbsp;&nbsp;
			<asp:button id="m_cmd_tao_moi" accessKey="l" CssClass="cssButton" 
                runat="server" Width="98px" Height="25px"  Text="Tạo mới(c)" 
                />&nbsp;&nbsp;
			<asp:button id="m_cmd_cap_nhat" accessKey="u" CssClass="cssButton" 
                runat="server" Width="98px" Height="25px"  Text="Cập nhật(u)" 
                 />&nbsp;&nbsp;
			        <asp:Button ID="m_cmd_xuat_excel" runat="server" CausesValidation="False" 
                        CssClass="cssButton" Height="25px"  Text="Xuất Excel" 
                        Width="98px"/>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:button id="btnCancel" accessKey="r" CssClass="cssButton" runat="server" 
                Width="98px" Height="25px"  Text="Xóa trắng(r)" CausesValidation="false" />
		</td>
	</tr>
            </table>        
        </td>
    </tr>  
    <tr>
		<td class="cssPageTitleBG" colspan="4">
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
                onrowupdating="m_grv_gd_assign_su_kien_cho_giang_vien_RowUpdating">
                  <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sự kiện">
                        <ItemTemplate>
                            <%# mapping_ten_su_kien_by_id(Eval("ID_SU_KIEN"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Giảng viên">
                        <ItemTemplate>
                            <%# mapping_ten_giang_vien_by_id(Eval("ID_GIANG_VIEN"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Số tiền hưởng" ItemStyle-HorizontalAlign="Right" DataField="SO_TIEN_GV_HUONG" DataFormatString="{0:N0}"/>
                    <asp:TemplateField HeaderText="Vai trò GV">
                        <ItemTemplate>
                            <%# mapping_vai_tro_giang_vien_by_id(Eval("ID_VAI_TRO_GV"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Số hợp đồng">
                        <ItemTemplate>
                            <%# mapping_so_hop_dong_by_id(Eval("ID_HOP_DONG"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Thanh toán ngay">
                        <ItemTemplate>
                            <%# mapping_thanh_toan_ngay(Eval("THANH_TOAN_NGAY_YN").ToString())%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Trạng thái">
                        <ItemTemplate>
                            <%# mapping_trang_thai_su_kien_giang_vien_by_id(Eval("ID_TRANG_THAI"))%>
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

