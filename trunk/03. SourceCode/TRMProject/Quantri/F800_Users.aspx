<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F800_Users.aspx.cs" Inherits="Quantri_F800_Users" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
	<tr>
		<td class="cssPageTitleBG" colspan="3">
		    <asp:label id="lblUser" runat="server" CssClass="cssPageTitle" 
                Text="Quản lý người dùng"/>
		</td>
	</tr>
	<tr>
		<td colspan="3">
		    <asp:validationsummary id="vdsCategory" runat="server" CssClass="cssManField" Font-Bold="true" />
		   <asp:label id="m_lbl_mess" runat="server" CssClass="cssManField" />
		</td>
	</tr>
	    <tr>
		<td align="right" style="width:15%;">
			<asp:label id="Label4" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;N&lt;/U&gt;hóm người dùng"/>
		</td>
		<td style="width:30%;">
		    <asp:DropDownList id="m_cbo_user_group" runat="server" Width="264px" 
                CssClass="cssDorpdownlist" AutoPostBack = "true"
                onselectedindexchanged="m_cbo_loai_tu_dien_SelectedIndexChanged"  />
		</td>
		<td style="width:5%;">  
			<asp:customvalidator id="m_cvt_loai_tu_dien" runat="server" 
                ControlToValidate="m_cbo_user_group" ErrorMessage="Bạn phải chọn Nhóm người dùng" 
                Display="Static" Text="*" />
            </td>
		</tr>
	    <tr>
		<td align="right" style="width:15%;">
			<asp:label id="lblFullName0" CssClass="cssManField" runat="server" 
                Text="Họ và tên người dùng" />
		</td>
		<td style="width:30%;">
			<asp:textbox id="m_txt_ho_va_ten" CssClass="cssTextBox"  runat="server" 
                MaxLength="25" Width="200px" />
		</td>
		<td style="width:5%;"> 
			<asp:customvalidator id="m_ctv_ma_tu_dien0" runat="server" 
                ControlToValidate="m_txt_ho_va_ten" ErrorMessage="Bạn phải nhập Họ và tên người dùng" 
                Display="Static" Text="*" />
        </td>
	    </tr>
	<tr>
		<td align="right" style="width:15%;">
			<asp:label id="lblFullName" CssClass="cssManField" runat="server" 
                Text="Tên đăng nhập" />
		</td>
		<td style="width:30%;">
			<asp:textbox id="m_txt_ten_dang_nhap" CssClass="cssTextBox"  runat="server" 
                MaxLength="25" Width="120px" />
		</td>
		<td style="width:5%;"> 
			<asp:customvalidator id="m_ctv_ma_tu_dien" runat="server" 
                ControlToValidate="m_txt_ten_dang_nhap" ErrorMessage="Bạn phải nhập Tên đăng nhập" 
                Display="Static" Text="*" />
        </td>
	</tr>
	    <tr>
		<td align="right" >
		    <asp:label id="lblAnswer0" runat="server" CssClass="cssManField" 
                Text="Mật khẩu" />
		</td>
		<td align="left">
		    <asp:textbox id="m_txt_mat_khau" accessKey="m" runat="server"  Width="150px" 
                TextMode="Password" />
		</td>
		<td >
			<asp:customvalidator id="m_ctv_ten_tu_ngan" runat="server" 
                ControlToValidate="m_txt_mat_khau" ErrorMessage="Mật khẩu không được để trống, ít nhất 5 ký tự" 
                Display="Static" Text="*" />
		    <asp:CompareValidator ID="m_ctv_mat_khau" runat="server" 
                ControlToCompare="m_txt_mat_khau" ControlToValidate="m_txt_mat_khau_go_lai" 
                ErrorMessage="Mật khẩu và Nhập lại mật khẩu phải giống nhau">*</asp:CompareValidator>
		</td>
		</tr>
	<tr>
		<td align="right" >
		    <asp:label id="lblAnswer" runat="server" CssClass="cssManField" 
                Text="Nhập lại mật khẩu" />
		</td>
		<td align="left">
		    <asp:textbox id="m_txt_mat_khau_go_lai" accessKey="m" runat="server"  
                Width="150px" TextMode="Password" />
		</td>
		<td >
			<asp:customvalidator id="m_ctv_mk_go_lai" runat="server" 
                ControlToValidate="m_txt_mat_khau_go_lai" ErrorMessage="Mật khẩu không được để trống, ít nhất 5 ký tự" 
                Display="Static" Text="*" />
		</td>
	</tr>
    <tr>
        <td align="right">
            <asp:Label ID="m_lbl_ghi_chu" runat="server" CssClass="cssManField" 
                Text="Tài khoản bị khóa?" />
        </td>
        <td align="left">
		    <asp:CheckBox ID="m_chk_lock_yn" runat="server" 
                 />
		    </td>
    </tr>
	<tr>
		<td align="right">
			&nbsp;</td>
		<td valign="top" colspan="2">
		    <asp:HiddenField ID="m_hdf_id_user_group" runat="server" Visible="False" />
		    <asp:HiddenField ID="m_hdf_pw" runat="server" Visible="False" />
        </td>
	</tr>	
	<tr>
	    <td></td>
		<td colspan="2" align="left">
			<asp:button id="m_cmd_tao_moi" accessKey="c" CssClass="cssButton" 
                runat="server" Width="98px" Text="Tạo mới(c)" onclick="m_cmd_tao_moi_Click"  />&nbsp;
			<asp:button id="m_cmd_cap_nhat" accessKey="u" CssClass="cssButton" 
                runat="server" Width="98px" Text="Cập nhật(u)" 
                onclick="m_cmd_cap_nhat_Click"  />&nbsp;
			<asp:button id="btnCancel" accessKey="r" CssClass="cssButton" runat="server" 
                Width="98px" Text="Xóa trắng(r)" onclick="btnCancel_Click" />
		</td>
	</tr>
    <tr>
		<td class="cssPageTitleBG" colspan="3">
		    <asp:label id="Label11" runat="server" CssClass="cssPageTitle" 
                Text="Danh sách người dùng"/>
		</td>
	</tr>	
    <tr>
		<td align="left">
                <asp:label id="m_lbl_thong_bao" Visible="false" runat="server" CssClass="cssManField" />
        </td>
        <td >
		    &nbsp;</td>
	</tr>	
    <tr>
		<td align="right">
			<asp:label id="Label5" CssClass="cssManField" runat="server" 
                Text="Nhóm người dùng"/>
        </td>
        <td >
		    <asp:DropDownList id="m_cbo_user_group_on_grid" runat="server" Width="264px" 
                AutoPostBack="True" 
                onselectedindexchanged="m_cbo_loai_tu_dien_grv_SelectedIndexChanged"  />
        </td>
	</tr>	
	<tr>
		<td align="center" colspan="3" style="height:450px;" valign="top">
		    <asp:GridView ID="m_grv_dm_tu_dien" runat="server" AutoGenerateColumns="False" 
                Width="80%" DataKeyNames="ID" 
                onrowdeleting="m_grv_dm_tu_dien_RowDeleting" 
                onselectedindexchanging="m_grv_dm_tu_dien_SelectedIndexChanging" 
                CellPadding="4" ForeColor="#333333" CssClass="cssGrid">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center"><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>

                        <HeaderStyle Width="15px" />

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ID_USER_GROUP" HeaderText="Nhóm người dùng" 
                        Visible="False">
                        <ItemStyle HorizontalAlign="Left" Width="4%"></ItemStyle></asp:BoundField>
                    <asp:BoundField DataField="TEN" ItemStyle-HorizontalAlign="Center" 
                        HeaderText="Họ và tên người dùng" >
<ItemStyle HorizontalAlign="Left"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="TEN_TRUY_CAP" HeaderText="Tên đăng nhập" />
                    <asp:BoundField DataField="MAT_KHAU" HeaderText="Mật khẩu" Visible="False" />
                    <asp:BoundField DataField="TRANG_THAI" ItemStyle-HorizontalAlign="Center" 
                        HeaderText="Trạng thái tài khoản (O: Bình thường, 1: Bị khóa)" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:CommandField DeleteText="Xóa" ShowDeleteButton="True" 
                        ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:CommandField>
                    <asp:CommandField SelectText="Sửa" ShowSelectButton="True" 
                        ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:CommandField>
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#810c15" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle CssClass="cssSelectedRow" BackColor="#C5BBAF" 
                    Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
            </asp:GridView>
        </td>
	</tr>	

</table>
</asp:Content>

