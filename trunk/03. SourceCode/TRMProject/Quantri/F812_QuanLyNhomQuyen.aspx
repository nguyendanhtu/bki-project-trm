<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F812_QuanLyNhomQuyen.aspx.cs" Inherits="Quantri_F812_QuanLyNhomQuyen" %>
<%@ Register assembly="eWorld.UI" namespace="eWorld.UI" tagprefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<style type="text/css">
        .style1
        {
            height: 19px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
	<tr>
		<td class="cssPageTitleBG" colspan="3">
		    <asp:label id="lblUser" runat="server" CssClass="cssPageTitle" 
                Text="Quản lý các nhóm quyền"/>
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
			<asp:label id="m_lbl_ten_nhom_quyen" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;T&lt;/U&gt;ên nhóm quyền" />
		</td>
		<td style="width:30%;">
			<asp:textbox id="m_txt_ten_nhom_quyen" CssClass="cssTextBox" CausesValidation="false"  runat="server" 
                MaxLength="64" Width="495px" />
                &nbsp;
                <asp:RequiredFieldValidator id="m_ct_noi_dung" runat="server" 
                ControlToValidate="m_txt_ten_nhom_quyen" ErrorMessage="Bạn phải nhập tên nhóm quyền" Text="*" />
		</td>
		<td style="width:5%;"> 
			&nbsp;</td>
	</tr>
	<tr>
		<td align="right">
			<asp:label id="lbl_mo_ta" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;M&lt;/U&gt;ô tả" />
		</td>
		<td valign="top" colspan="2">
		    <asp:TextBox ID="m_txt_mo_ta" runat="server" TextMode = "MultiLine" 
                Width="495px" Height="83px"></asp:TextBox>
        </td>
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
                runat="server" Width="98px" Text="Tạo mới(c)" 
                onclick="m_cmd_tao_moi_Click" />&nbsp;
			<asp:button id="m_cmd_cap_nhat" accessKey="u" CssClass="cssButton" 
                runat="server" Width="98px" Text="Cập nhật(u)" 
                onclick="m_cmd_cap_nhat_Click1" />&nbsp;
			<asp:button id="btnCancel" accessKey="r" CssClass="cssButton" runat="server" 
                Width="98px" Text="Xóa trắng(r)"/>
                <asp:HiddenField ID="hdf_id" runat = "server" Value="" />
		</td>
	</tr>
    <tr>
		<td class="cssPageTitleBG" colspan="3">
		    <asp:label id="Label11" runat="server" CssClass="cssPageTitle" 
                Text="Danh sách các nhóm quyền"/>
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
		<td align="center" colspan="3" style="height:450px;" valign="top">
		    &nbsp;
           
        <asp:GridView ID="m_grv_dm_nhom_quyen_he_thong" AllowPaging="True" 
                runat="server" AutoGenerateColumns="False" 
                Width="70%" DataKeyNames="ID" 
                  onrowdeleting="m_grv_dm_nhom_quyen_he_thong_RowDeleting"                 
                onselectedindexchanging="m_grv_dm_nhom_quyen_he_thong_SelectedIndexChanging" 
                CellPadding="4" ForeColor="#333333" AllowSorting="True" 
                onpageindexchanging="m_grv_dm_nhom_quyen_he_thong_PageIndexChanging">
                  <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Sửa">
                    <ItemTemplate>
                     <asp:LinkButton ID = "lbt_update"  runat="server" CausesValidation="false"
                     CommandName="Select" ToolTip="Sửa">
                     <img alt="Xóa" src="../Images/Button/edit.png" />
                     </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="USER_GROUP_NAME" HeaderText="Tên nhóm quyền" ItemStyle-Width="35%" ItemStyle-HorizontalAlign="Left">
                        </asp:BoundField>
                    <asp:BoundField DataField="DESCRIPTION" HeaderText="Mô tả" ItemStyle-Width="45%" ItemStyle-HorizontalAlign="Left" />
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

