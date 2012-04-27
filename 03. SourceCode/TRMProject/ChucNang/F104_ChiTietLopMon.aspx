<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master"  AutoEventWireup="true" CodeFile="F104_ChiTietLopMon.aspx.cs" Inherits="ChucNang_F104_ChiTietLopMon" %>

<%@ Register assembly="eWorld.UI" namespace="eWorld.UI" tagprefix="ew" %>
<%@ Import Namespace="WebDS.CDBNames" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
	<tr>
		<td class="cssPageTitleBG">
		    <asp:label id="m_lbl_ma_lop_mon" runat="server" CssClass="cssPageTitle" 
                Text="Thông tin lớp môn chi tiết"/>
		</td>
	</tr>
	<tr>
		<td>
		    <asp:validationsummary id="vdsCategory" runat="server" CssClass="cssManField" Font-Bold="true" />
		   <asp:label id="m_lbl_mess" runat="server" CssClass="cssManField" />
		</td>
	</tr>
    <tr>
		<td>
        <table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0"> 
            <tr>
                <td align="right" style="width:5%;">
			<asp:label id="lblFullName5" CssClass="cssManField" runat="server" 
                Text="Mã lớp môn" />
                         </td>
                <td align="left" style="width:10%;">
			<asp:textbox id="m_txt_ma_lop_mon" CssClass="cssTextBox"  runat="server" 
                MaxLength="64" Width="96%" Enabled="False" />
                         </td>
                         <td align="left" style="width:1%;"> 
                         <asp:RequiredFieldValidator ID="m_rfv_offline3" runat="server" 
                             ErrorMessage="Bạn không thể cập nhật dữ liệu do không có Mã lớp môn" 
                             ControlToValidate="m_txt_ma_lop_mon">*</asp:RequiredFieldValidator>
                </td>
                <td align="left" style="width:5%;">
			       
			    </td>
                <td align="left" style="width:10%;">&nbsp;</td>
                <td align="left" style="width:1%;"></td>
                 <td align="right" style="width:5%;"></td>
                <td align="left" style="width:10%;"></td>
                <td align="left" style="width:1%;"></td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			<asp:label id="lblFullName" CssClass="cssManField" runat="server" 
                Text="Số hợp đồng khung" />
                </td>
                <td align="left" style="width:10%;">
		    <asp:DropDownList id="m_cbo_dm_hop_dong_khung" runat="server" Width="96%" 
                        CssClass="cssDorpdownlist" AutoPostBack="True" 
                        onselectedindexchanged="m_cbo_dm_hop_dong_khung_SelectedIndexChanged"  />
                </td>
                     <td align="left" style="width:1%;">
                         <asp:RequiredFieldValidator ID="m_rfv_offline0" runat="server" 
                             ErrorMessage="Bạn phải chọn Số hợp đồng khung" 
                             ControlToValidate="m_cbo_dm_hop_dong_khung">*</asp:RequiredFieldValidator>
                </td>
                <td align="right" style="width:5%;">
			<asp:label id="lblFullName14" CssClass="cssManField" runat="server" 
                Text="Nội dung thanh toán" />
                </td>
                <td align="left" style="width:10%;">
		    <asp:DropDownList id="m_cbo_noi_dung_thanh_toan" runat="server" Width="96%" 
                        CssClass="cssDorpdownlist"  />
                </td>
                      <td align="left" style="width:1%;">
                         <asp:RequiredFieldValidator ID="m_rfv_offline1" runat="server" 
                             ErrorMessage="Bạn phải chọn Nội dung thanh toán" 
                             ControlToValidate="m_cbo_noi_dung_thanh_toan">*</asp:RequiredFieldValidator>
                </td>
                 <td align="right" style="width:5%;">
                     &nbsp;</td>
                <td align="left" style="width:10%;"></td>
                <td align="left" style="width:1%;"></td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			<asp:label id="lblFullName4" CssClass="cssManField" runat="server" 
                Text="Số lượng/ hệ số" />
		                    </td>
                <td align="left" style="width:10%;">
			        <ew:NumericBox ID="m_txt_so_luong_he_so" runat="server" Width="96%" 
                        TextAlign="Right" PositiveNumber="True"></ew:NumericBox>
                </td>
                     <td align="left" style="width:1%;">
                         <asp:RequiredFieldValidator ID="m_rfv_offline" runat="server" 
                             
                             ErrorMessage="Bạn phải nhập Số lương hệ số" 
                             ControlToValidate="m_txt_so_luong_he_so">*</asp:RequiredFieldValidator>
                </td>
                <td align="right" style="width:5%;">
			<asp:label id="lblFullName15" CssClass="cssManField" runat="server" 
                Text="Thành tiền" />
		                    </td>
                <td align="left" style="width:10%;">
                 <asp:TextBox  ID="m_txt_thanh_tien" CssClass="csscurrency" Width="96%" 
                        runat="server"></asp:TextBox> 
                </td>
                     <td align="left" style="width:1%;">
                         <asp:RequiredFieldValidator ID="m_rfv_offline2" runat="server" 
                             
                             ErrorMessage="Bạn phải nhập Thành tiền" 
                             ControlToValidate="m_txt_thanh_tien">*</asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ErrorMessage="Invalid Price" Text="*"
    ValidationGroup="complete" EnableClientScript="true" ControlToValidate="m_txt_thanh_tien"
    ValidationExpression="^\d+(\.\d\d)?$" Display="Dynamic" runat="server"/>
    <asp:CompareValidator runat="server" id="CompareValidator1" Operator="GreaterThan" Type="Currency"
        Display="Dynamic" ValueToCompare="0" ControlToValidate="m_txt_thanh_tien" ErrorMessage = "Giá trị nhập không đúng định dạng" />                         
                </td>
                 <td align="right" style="width:5%;">
			         &nbsp;</td>
                <td align="left" style="width:10%;">
                    &nbsp;</td>            
                         <td align="left" style="width:1%;"></td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			<asp:label id="lblFullName6" CssClass="cssManField" runat="server" 
                Text="Trạng thái" />
		                    </td>
                <td align="left" style="width:10%;">
			        <asp:RadioButtonList ID="m_rbt_trang_thai_thanh_toan" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="Y">Đã thanh toán</asp:ListItem>
                        <asp:ListItem Value="N">Chưa thanh toán</asp:ListItem>
                    </asp:RadioButtonList>
		                    </td>
                                 <td align="left" style="width:1%;"> 
                             <asp:RequiredFieldValidator ID="m_rfv_ma_lop_mon" runat="server" 
                        ControlToValidate="m_rbt_trang_thai_thanh_toan" 
                                         ErrorMessage="Bạn phải chọn Trạng thái: Đã thanh toán hoặc Chưa thanh toán">*</asp:RequiredFieldValidator></td>
                <td align="right" style="width:5%;">
			        &nbsp;</td>
                <td align="left" style="width:10%;">
			        &nbsp;</td>
                                 <td align="left" style="width:1%;"></td>
                 <td align="right" style="width:5%;">
			         &nbsp;</td>
                <td align="left" style="width:10%;">
			        &nbsp;</td>     <td align="left" style="width:1%;"></td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			        &nbsp;</td>
                <td align="left" style="width:10%;">     
			        &nbsp;</td>
                <td align="left" style="width:1%;"></td>
                <td align="right" style="width:5%;">
			        &nbsp;</td>
                <td align="left" style="width:10%;">     
			        <asp:HiddenField ID="m_hdf_id" runat="server" Visible="False" />
                </td>
                 <td align="left" style="width:1%;"></td>
                 <td align="right" style="width:5%;"></td>
                <td align="left" style="width:10%;"></td>     
                <td align="left" style="width:1%;"></td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			        &nbsp;</td>
                <td align="left" style="width:10%;">     
			        <asp:button id="m_cmd_luu_du_lieu" accessKey="s" CssClass="cssButton" 
                runat="server" Width="98px" Text="Lưu dữ liệu" onclick="m_cmd_luu_du_lieu_Click" 
                        Height="24px" />
			    </td>
                 <td align="left" style="width:1%;"></td>
                <td align="right" style="width:5%;">
			        &nbsp;</td>
                <td align="left" style="width:10%;">    
                 <asp:button id="m_cmd_thoat" CssClass="cssButton" 
                runat="server" Width="98px" Text="Thoát" onclick="m_cmd_thoat_Click" 
                        Height="25px"  />
                 </td>
                 <td align="left" style="width:1%;"></td>
                <td align="right" style="width:5%;"></td>
                <td align="left" style="width:10%;">    </td> 
                   <td align="left" style="width:1%;"></td>
            </tr>
            </table>
		</td>
	</tr>
	<tr class="cssPageTitleBG">
    <td>
		    <asp:label id="m_lbl_ma_lop_mon0" runat="server" CssClass="cssPageTitle" 
                Text="Danh sách lớp môn chi tiết"/>
		</td></tr>
    	<tr>
    <td>
		    <asp:GridView ID="m_grv" runat="server" AutoGenerateColumns="False" 
                Width="100%" DataKeyNames="ID" 
                CellPadding="4" ForeColor="#333333" CssClass="cssGrid" 
                onrowdeleting="m_grv_RowDeleting" 
                onselectedindexchanging="m_grv_SelectedIndexChanging">
                
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                    <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Số hợp đồng khung">
                        <ItemTemplate>
                            <asp:Label ID="m_lbl_id_hop_dong_khung" runat="server" Text="<%# get_mapping_so_hop_dong_khung((decimal)Eval(GD_LOP_MON_DETAIL.ID_HOP_DONG_KHUNG)) %>" 
                                ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nội dung thanh toán">
                        <ItemTemplate>
                            <asp:Label ID="m_lbl_id_noi_dung_thanh_toan" runat="server" Text="<%# get_mapping_ten_noi_dung_thanh_toan((decimal)Eval(GD_LOP_MON_DETAIL.ID_NOI_DUNG_THANH_TOAN)) %>" 
                             ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="SO_LUONG_HE_SO" HeaderText="Số lượng/ hệ số" 
                        DataFormatString="{0:0.00}">
                    <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="THANH_TIEN" HeaderText="Thành tiền" 
                        DataFormatString="{0:0,0 vnđ}">
                                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Trạng thái">
                        <ItemTemplate>
                            <asp:Label ID="m_lbl_da_thanh_toan_yn" runat="server" 
                                Text="<%# get_mapping_da_thanh_toan_yn((string)Eval(GD_LOP_MON_DETAIL.DA_THANH_TOAN_YN)) %>"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:CommandField DeleteText="" ShowDeleteButton="True" 
                        ItemStyle-HorizontalAlign="Center" ButtonType="Image" 
                        DeleteImageUrl="~/Images/Button/deletered.png" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:CommandField>
                    <asp:CommandField ButtonType="Image" SelectText="" ShowSelectButton="True" 
                        SelectImageUrl="~/Images/Button/edit.png" >
                    <ItemStyle HorizontalAlign="Center" />
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
            </td></tr>
</table>
</asp:Content>