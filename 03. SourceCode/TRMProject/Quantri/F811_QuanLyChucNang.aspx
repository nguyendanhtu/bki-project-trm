<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F811_QuanLyChucNang.aspx.cs" Inherits="Quantri_F811_QuanLyChucNang" %>
<%@ Register assembly="eWorld.UI" namespace="eWorld.UI" tagprefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
	<tr>
		<td class="cssPageTitleBG" colspan="3">
		    <asp:label id="lblUser" runat="server" CssClass="cssPageTitle" 
                Text="Quản lý các chức năng của hệ thống"/>
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
			<asp:label id="lbl_content" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;T&lt;/U&gt;ên chức năng" />
		</td>
		<td style="width:30%;">
			<asp:textbox id="m_txt_ten_chuc_nang" CssClass="cssTextBox" CausesValidation="false" 
            runat="server" Width="90%" />
                &nbsp;
                <asp:RequiredFieldValidator id="m_ct_noi_dung" runat="server" 
                ControlToValidate="m_txt_ten_chuc_nang" ErrorMessage="Bạn phải nhập tên chức năng" Text="*" />
		</td>
		<td style="width:5%;"> 
			&nbsp;</td>
	</tr>
	    <tr>
		<td align="right" >
			<asp:label id="lbl_loai_hop_dong" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;U&lt;/U&gt;RL của chức năng" AccessKey="L" />
		    </td>
		<td align="left">
            <asp:TextBox ID="m_txt_url_form" Width="90%" runat="server">
            </asp:TextBox>
            </td>
		<td >
			&nbsp;</td>
		</tr>
	<tr>
		<td align="right" >
			<asp:label id="lbl_ma_don_vi_tinh" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;C&lt;/U&gt;hức năng cha" />
		</td>
		<td align="left">
		    <asp:DropDownList ID="m_cbo_chuc_nang_cha" runat="server" Width="80%" 
                onselectedindexchanged="m_cbo_chuc_nang_cha_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
        </td>
		<td >
			&nbsp;</td>
	</tr>
	<tr>
		<td align="right" >
			<asp:label id="lbl_ma_don_vi_tinh0" CssClass="cssManField" runat="server" 
                Text="Vị trí" />
		</td>
		<td align="left">
		    <asp:DropDownList ID="m_cbo_vi_tri" runat="server" Width="20%" 
                onselectedindexchanged="m_cbo_vi_tri_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
        </td>
		<td >
			&nbsp;</td>
	</tr>
	<tr>
		<td align="right" >
			<asp:label id="lbl_ma_tan_xuat1" CssClass="cssManField" runat="server" 
                Text="Được sử dụng YN?" />
		</td>
		<td align="left">
            <asp:RadioButtonList ID="m_rdl_su_dung_yn" runat="server" 
                RepeatDirection="Horizontal" Width="117px">
                <asp:ListItem Value="Y" Selected="True">Có</asp:ListItem>
                <asp:ListItem Value="N">Không</asp:ListItem>
            </asp:RadioButtonList>
            </td>
		<td >
			&nbsp;</td>
	</tr>
	    <tr>
		<td align="right">
			<asp:label id="lbl_ma_tan_xuat0" CssClass="cssManField" runat="server" 
                Text="Được hiển thị YN?" />
		    </td>
		<td valign="top" colspan="2">
		    &nbsp; 
            <asp:RadioButtonList ID="m_rdl_hien_thi_yn" runat="server" 
                RepeatDirection="Horizontal" Width="117px">
                <asp:ListItem Value="Y" Selected="True">Có</asp:ListItem>
                <asp:ListItem Value="N">Không</asp:ListItem>
            </asp:RadioButtonList>
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
                onclick="m_cmd_cap_nhat_Click"  />&nbsp;
			<asp:button id="btnCancel" accessKey="r" CssClass="cssButton" runat="server" 
                Width="98px" Text="Xóa trắng(r)" onclick="btnCancel_Click" />
                <asp:HiddenField ID="hdf_id" runat = "server" Value="" />
		</td>
	</tr>
    <tr>
		<td class="cssPageTitleBG" colspan="3">
		    <asp:label id="Label11" runat="server" CssClass="cssPageTitle" 
                Text="Danh sách các chức năng của hệ thống"/>
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
			<asp:label id="lbl_ghi_chu0" CssClass="cssManField" runat="server" 
                Text="Chức năng cấp 1" />
		</td>
        <td >
		    <asp:DropDownList id="m_cbo_chuc_nang_cap_1" runat="server" Width="320px" 
                AutoPostBack="True" 
                onselectedindexchanged="m_cbo_chuc_nang_cap_1_SelectedIndexChanged" />
        </td>
	</tr>	
	<tr>
		<td align="center" colspan="3" style="height:450px;" valign="top">
		    &nbsp;
           
        <asp:GridView ID="m_grv_dm_chuc_nang_he_thong" AllowPaging="True" 
                runat="server" AutoGenerateColumns="False" 
                Width="100%" DataKeyNames="ID" 
                CellPadding="4" ForeColor="#333333" AllowSorting="True" 
                onpageindexchanging="m_grv_dm_chuc_nang_he_thong_PageIndexChanging" 
                onrowdeleting="m_grv_dm_chuc_nang_he_thong_RowDeleting" 
                onselectedindexchanging="m_grv_dm_chuc_nang_he_thong_SelectedIndexChanging" >
                  <AlternatingRowStyle BackColor="White" />
                <Columns>
                  <asp:TemplateField HeaderText="Xóa">
                    <ItemTemplate>
                     <asp:LinkButton ID = "lbt_delete"  runat="server"
                     CommandName="Delete" ToolTip="Xóa" OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')">
                     <img alt="Xóa" src="../Images/Button/deletered.png" />
                     </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Sửa">
                    <ItemTemplate>
                     <asp:LinkButton ID = "lbt_update"  runat="server" CausesValidation="false"
                     CommandName="Select" ToolTip="Sửa">
                     <img alt="Sửa" src="../Images/Button/edit.png" />
                     </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="TEN_CHUC_NANG" HeaderText="Tên chức năng" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                      <asp:TemplateField HeaderText="Tên chức năng cha">
                       <ItemTemplate><%# Eval("CHUC_NANG_PARENT_ID")%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="URL_FORM" ItemStyle-HorizontalAlign="Left"
                        HeaderText="URL của chức năng">
                    </asp:BoundField>
                     <asp:BoundField DataField="VI_TRI" HeaderText="Vị trí" 
                        ItemStyle-HorizontalAlign="Center" > 
                    </asp:BoundField>
                     <asp:TemplateField HeaderText="Được sử dụng YN">
                       <ItemTemplate><%# mapping_yn(Eval("TRANG_THAI_YN"))%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Được hiển thị YN">
                       <ItemTemplate><%# mapping_yn(Eval("HIEN_THI_YN"))%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    </asp:TemplateField>
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

