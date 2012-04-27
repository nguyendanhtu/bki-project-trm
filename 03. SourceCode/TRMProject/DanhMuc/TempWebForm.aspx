<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TempWebForm.aspx.cs" Inherits="DanhMuc_TempWebForm" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
	<tr>
		<td class="cssPageTitleBG" colspan="3">
		    <asp:label id="lblUser" runat="server" CssClass="cssPageTitle" 
                Text="Danh mục &lt;&gt;"/>
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
			&nbsp;</td>
		<td style="width:30%;">
		    &nbsp;</td>
		<td style="width:5%;">  
			&nbsp;</td>
		</tr>
	<tr>
		<td align="right" style="width:15%;">
			<asp:label id="lblFullName" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;M&lt;/U&gt;ã từ điển" />
		</td>
		<td style="width:30%;">
			<asp:textbox id="m_txt_ma_tu_dien" CssClass="cssTextBox"  runat="server" 
                MaxLength="64" Width="96%" />
		</td>
		<td style="width:5%;"> 
			<asp:customvalidator id="m_ctv_ma_tu_dien" runat="server" 
                ControlToValidate="m_txt_ma_tu_dien" ErrorMessage="Bạn phải nhập Mã từ điển" 
                Display="Static" Text="*" />
        </td>
	</tr>
	    <tr>
		<td align="right" >
		    &nbsp;</td>
		<td align="left">
		    &nbsp;</td>
		<td >
			&nbsp;</td>
		</tr>
	<tr>
		<td align="right" >
		    &nbsp;</td>
		<td align="left">
		    &nbsp;</td>
		<td >
			&nbsp;</td>
	</tr>
    <tr>
        <td align="right">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
    </tr>
	<tr>
		<td align="right">
			&nbsp;</td>
		<td valign="top" colspan="2">
		    &nbsp;</td>
	</tr>	
	<tr>
	    <td></td>
		<td colspan="2" align="left">
			<asp:button id="m_cmd_tao_moi" accessKey="c" CssClass="cssButton" 
                runat="server" Width="98px" Text="Tạo mới(c)" />&nbsp;
			<asp:button id="m_cmd_cap_nhat" accessKey="u" CssClass="cssButton" 
                runat="server" Width="98px" Text="Cập nhật(u)"  />&nbsp;
			<asp:button id="btnCancel" accessKey="r" CssClass="cssButton" runat="server" 
                Width="98px" Text="Xóa trắng(r)" />
		</td>
	</tr>
    <tr>
		<td class="cssPageTitleBG" colspan="3">
		    <asp:label id="Label11" runat="server" CssClass="cssPageTitle" 
                Text="Danh sách &lt;&gt;"/>
		</td>
	</tr>	
    <tr>
		<td align="right">
			&nbsp;</td>
        <td >
		    &nbsp;</td>
	</tr>	
	<tr>
		<td align="center" colspan="3" style="height:450px;" valign="top">
		    &nbsp;</td>
	</tr>	

</table>
</asp:Content>

