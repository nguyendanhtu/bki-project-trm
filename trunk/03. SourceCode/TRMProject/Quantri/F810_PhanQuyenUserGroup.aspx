<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F810_PhanQuyenUserGroup.aspx.cs" Inherits="Quantri_F810_PhanQuyenUserGroup" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
	<tr>
		<td class="cssPageTitleBG" colspan="6">
		    <asp:label id="lblUser" runat="server" CssClass="cssPageTitle" 
                Text="Phân quyền cho nhóm người dùng"/>
		</td>
	</tr>
	<tr>
		<td colspan="6">
		    <asp:validationsummary id="vdsCategory" runat="server" CssClass="cssManField" Font-Bold="true" />
		   <asp:label id="m_lbl_mess" runat="server" CssClass="cssManField" />
		</td>
	</tr>
	    <tr>
		<td align="right">
			<asp:label id="Label4" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;N&lt;/U&gt;hóm người dùng (Quyền)"/>
		</td>
		<td >
		    <asp:DropDownList id="m_cbo_user_group" runat="server" Width="300px" 
                CssClass="cssDorpdownlist" AutoPostBack = "true" onselectedindexchanged="m_cbo_user_group_SelectedIndexChanged"
                  />
		</td>
		<td >
		    &nbsp;</td>
		<td >
			<asp:button id="m_cmd_cap_nhat" accessKey="u" CssClass="cssButton" 
                runat="server" Width="98px" Text="Cập nhật(u)" 
                onclick="m_cmd_cap_nhat_Click" Height="22px"  />
		    </td>
		<td >
			<asp:customvalidator id="m_cvt_loai_tu_dien" runat="server" 
                ControlToValidate="m_cbo_user_group" ErrorMessage="Bạn phải chọn Nhóm người dùng" 
                Display="Static" Text="*" />
		</td>
		<td >  
			&nbsp;</td>
		</tr>
	    <tr>
		<td align="right">
			&nbsp;</td>
		<td >
			<asp:label id="lblFullName0" CssClass="cssManField" runat="server" 
                Text="Chức năng phần mềm" />
		</td>
		<td >
		    &nbsp;</td>
		<td >
			<asp:label id="lblFullName1" CssClass="cssManField" runat="server" 
                Text="Chức năng của Nhóm người dùng" />
		    </td>
		<td >
			&nbsp;</td>
		<td >  
			&nbsp;</td>
		</tr>
	    <tr>
		<td align="right" width="200px">
			&nbsp;</td>
		<td width="300px" >
			<asp:ListBox ID="m_lst_chuc_nang" runat="server" Width="300px" Height="300px" 
                SelectionMode="Multiple"></asp:ListBox>
		</td>
		<td width="10px" align="center">
			<asp:ImageButton ID="m_cmd_right" runat="server" 
                ImageUrl="~/Images/ListTran/right.gif" onclick="m_cmd_right_Click" />
			<asp:ImageButton ID="m_cmd_right_all" runat="server" 
                ImageUrl="~/Images/ListTran/rightAll.gif" 
                onclick="m_cmd_right_all_Click" />
			<br />
            <br />
			<asp:ImageButton ID="m_cmd_left" runat="server" 
                ImageUrl="~/Images/ListTran/left.gif" onclick="m_cmd_left_Click" 
                style="height: 19px" />
			<asp:ImageButton ID="m_cmd_left_all" runat="server" 
                ImageUrl="~/Images/ListTran/leftAll.gif" onclick="m_cmd_left_all_Click" />
		    </td>
		<td width="300px" >
			<asp:ListBox ID="m_lst_chuc_nang_user" runat="server" Width="300px" 
                Height="300px" SelectionMode="Multiple"></asp:ListBox>
		    </td>
		<td >
			&nbsp;</td>
		<td >  
			&nbsp;</td>
		</tr>
	    	
	</table>
</asp:Content>



