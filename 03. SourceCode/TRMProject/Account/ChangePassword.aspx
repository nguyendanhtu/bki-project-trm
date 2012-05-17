<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Account_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
	<tr>
		<td class="cssPageTitleBG" colspan="3">
		    <asp:label id="lblUser" runat="server" CssClass="cssPageTitle" 
                Text="Thay đổi mật khẩu"/>
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
                Text="&lt;U&gt;M&lt;/U&gt;ật khẩu cũ"/>
		</td>
		<td style="width:30%;">
			<asp:textbox id="m_txt_old_password" CssClass="cssTextBox"  runat="server" TextMode="Password"
                MaxLength="25" Width="200px" />
		</td>
		<td style="width:5%;">  
			<asp:RequiredFieldValidator id="m_rqv_old_passwprd" runat="server" 
                ControlToValidate="m_txt_old_password" ErrorMessage="Mật khẩu cũ không được để trống" 
                Display="Static" Text="(*)" />
            </td>
		</tr>
	<tr>
		<td align="right" style="width:15%;">
			<asp:label id="lblFullName" CssClass="cssManField" runat="server" 
                Text="Mật khẩu mới" />
		</td>
		<td style="width:30%;">
			<asp:textbox id="m_txt_new_password" CssClass="cssTextBox"  runat="server" TextMode="Password"
                MaxLength="25" Width="200px" />
		</td>
		<td style="width:5%;"> 
				<asp:RequiredFieldValidator id="m_rqv_new_password" runat="server" 
                ControlToValidate="m_txt_new_password" ErrorMessage="Mật khẩu mới không được để trống" 
                Display="Static" Text="(*)" />
        </td>
	</tr>
	    <tr>
		<td align="right" >
		    <asp:label id="lblAnswer0" runat="server" CssClass="cssManField" 
                Text="Nhập lại mật khẩu" />
		</td>
		<td align="left">
		    <asp:textbox id="m_txt_mat_khau_retype" accessKey="m" runat="server"  Width="200px" 
                TextMode="Password" />
		</td>
		<td >
			<asp:RequiredFieldValidator id="m_ctv_retype_mat_khau" runat="server" 
                ControlToValidate="m_txt_mat_khau_retype" ErrorMessage="Mật khẩu nhập lại không được để trống" 
                Display="Static" Text="*" />
		    <asp:CompareValidator ID="m_ctv_mat_khau" runat="server" 
                ControlToCompare="m_txt_mat_khau_retype" ControlToValidate="m_txt_new_password" 
                ErrorMessage="Mật khẩu và mật khẩu nhập lại phải giống nhau">*</asp:CompareValidator>
		</td>
		</tr>
	<tr>
	    <td></td>
		<td colspan="2" align="left">
			<asp:button id="m_cmd_doi_mat_khau" accessKey="c" CssClass="cssButton" 
                runat="server" Width="98px" Text="Lưu" onclick="m_cmd_doi_mat_khau_Click"/>&nbsp;&nbsp;&nbsp;
			<asp:button id="m_cmd_thoat" accessKey="u" CssClass="cssButton" 
                runat="server" Width="98px" Text="Thoát" onclick="m_cmd_thoat_Click" />
			</td>
	</tr>
</table>
</asp:Content>

