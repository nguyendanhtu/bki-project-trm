<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F603_ThanhToanChiTiet.aspx.cs" Inherits="ChucNang_F603_ThanhToanChiTiet" %>
<%@ Register assembly="eWorld.UI" namespace="eWorld.UI" tagprefix="ew" %>
<%@ Import Namespace="IP.Core.IPCommon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
    <tr>
		<td class="cssPageTitleBG">
		    <asp:label id="m_lbl_thong_tin_hd" runat="server" CssClass="cssPageTitle" 
                Text="Lên chi tiết cho bảng kê"/>
		</td>
	</tr>
    <tr>
		<td>
        <table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0"> 
            <tr>
                <td align="right" style="width:7%;">
			<asp:label id="Label1" CssClass="cssManField" runat="server" 
                Text="Số phiếu thanh toán: " /></td>
                <td align="left" style="width:10%;"> &nbsp;
			<asp:Label id="m_lbl_so_phieu_thanh_toan"  runat="server" 
                MaxLength="64" Width="96%" />
                         </td>
                         <td align="left" style="width:1%;"> 
                             &nbsp;</td>
                <td align="right" style="width:7%;">
			       
			<asp:label id="Label5" CssClass="cssManField" runat="server" 
                Text="Ngày thanh toán: " />
			       
			    </td>
                <td align="left" style="width:10%;"> &nbsp;
			        <asp:label id="m_lbl_dat_ngay_thanh_toan" runat="server" /></td>
                <td align="left" style="width:1%;">&nbsp;</td>
                 <td align="right" style="width:5%;">&nbsp;</td>
                <td align="left" style="width:10%;">&nbsp;</td>
                <td align="left" style="width:1%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:7%;">
			       
			<asp:label id="m_lbl_dv_thanh_toan" CssClass="cssManField" runat="server" 
                Text="Đơn vị thanh toán: " />
			       
                         </td>
                <td align="left" style="width:10%;">
                    <asp:label id="m_lbl_don_vi_thanh_toan" runat="server" /></td>
                         <td align="left" style="width:1%;"> 
                             &nbsp;</td>
                <td align="right" style="width:5%;">
			       
			<asp:label id="Label4" CssClass="cssManField" runat="server" 
                Text="Số hợp đồng: " />
			       
			    </td>
                <td align="left" colspan="3">	
                    <asp:Label ID="m_lbl_so_hop_dong" runat = "server"></asp:Label></td>
                <td align="left" style="width:10%;"></td>
                <td align="left" style="width:1%;"></td>
            </tr>
            <tr>
                <td align="right" style="width:5%;"></td>
                <td align="left" style="width:10%;">    
			        &nbsp;</td> 
                <td align="left" style="width:1%;"></td>
                <td align="left" style="width:5%;">
			        &nbsp;</td>
                <td align="left" style="width:10%;">    
			        &nbsp;</td> <td align="left" style="width:1%;"></td>
                 <td align="right" style="width:5%;"></td>
                <td align="left" style="width:10%;"></td>
            </tr>
            </table>

		</td>
	</tr>
	<tr>
		<td class="cssPageTitleBG">
		    <asp:label id="lblUser" runat="server" CssClass="cssPageTitle" 
                Text="Thông tin chi tiết thanh toán"/>
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
                <td align="right" style="width:8%;">
			       
			<asp:label id="lblTenGiangVien" CssClass="cssManField" runat="server" 
                Text="Nội dung thanh toán" />
			       
                         </td>
                <td align="left" colspan="6">
              <asp:DropDownList ID="m_cbo_noi_dung_tt" Width="96%" runat="server" 
                        AutoPostBack="true" 
                        onselectedindexchanged="m_cbo_noi_dung_tt_SelectedIndexChanged" >
               </asp:DropDownList>
                         </td>
                <td align="left" style="width:10%;"></td>
                <td align="left" style="width:1%;"></td>
            </tr>
            <tr>
                <td align="right" style="width:7%;">
			        &nbsp;</td>
                <td align="left" style="width:10%;">

                    &nbsp;</td>
                     <td align="left" style="width:1%">
                         &nbsp;</td>
                <td align="right" style="width:3%;">
			        &nbsp;</td>
                <td align="left" style="width:10%;">
			
			        &nbsp;</td>
                      <td align="left" style="width:1%;">
                          &nbsp;</td>
                 <td align="right" style="width:5%;">
			       
			         &nbsp;</td>
                <td align="left" style="width:10%;">
		            &nbsp;</td>
                <td align="left" style="width:1%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:7%;">
			       
			<asp:label id="lblMon4" CssClass="cssManField" runat="server" 
                Text="Số lượng / hệ số" />
			       
                </td>
                <td align="left" style="width:10%;">
                <ew:numericbox ID="m_txt_so_luong_he_so" Width="96%" runat="server" 
                        TextAlign="Right">
                </ew:numericbox>
                       </td>
                <td align="left" style="width:5%;">
			        <asp:RequiredFieldValidator ID="req_vali2" runat="server" 
                         ErrorMessage="Bạn phải nhập số lượng hệ số" Text="*" ControlToValidate="m_txt_so_luong_he_so">
                         </asp:RequiredFieldValidator>
			        &nbsp;</td>
                <td align="right" style="width:7%;">
			
			<asp:label id="lbldon_vi_tinh" CssClass="cssManField" runat="server" 
                Text="Đơn vị tính" />
			       
                </td>
                      <td align="left" style="width:1%;">
                          <asp:label id="m_lbl_don_vi_tinh" runat="server" /></td>
                 <td align="right" style="width:5%;">
			       
			         &nbsp;</td>
                <td align="left" style="width:10%;">
		            &nbsp;</td>
                <td align="left" style="width:1%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			<asp:label id="lblGiaTriHopDong" CssClass="cssManField" runat="server" 
                Text="Đơn giá hợp đồng (VNĐ)" />
                </td>
                <td align="left" style="width:10%;">    
			      <asp:TextBox  ID="m_txt_don_gia_hd" CssClass="csscurrency" Width="96%" 
                        runat="server"></asp:TextBox> 
                </td> 
                <td align="left" style="width:1%;">
                          <asp:RequiredFieldValidator ID="req_validator" runat="server" 
                         ErrorMessage="Bạn phải nhập đơn giá" Text="*" ControlToValidate="m_txt_don_gia_hd"></asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ErrorMessage="Invalid Price" Text="*"
    ValidationGroup="complete" EnableClientScript="true" ControlToValidate="m_txt_don_gia_hd"
    ValidationExpression="^\d+(\.\d\d)?$" Display="Dynamic" runat="server"/>
    <asp:CompareValidator runat="server" id="CompareValidator1" Operator="GreaterThan" Type="Currency"
        Display="Dynamic" ValueToCompare="0" ControlToValidate="m_txt_don_gia_hd" ErrorMessage = "Giá trị nhập không đúng định dạng" />                         
                         </td>
                <td align="right" style="width:9%;">
			       
			<asp:label id="lbltan_suat" CssClass="cssManField" runat="server" 
                Text="Tần suất thanh toán" />
			       
                </td>
                <td align="left" style="width:10%;">    
			        &nbsp;<asp:label id="m_lbl_tan_suat" runat="server" /></td> <td align="left" style="width:1%;">&nbsp;</td>
                 <td align="right" style="width:5%;">&nbsp;</td>
                <td align="left" style="width:10%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			
			<asp:label id="lbldescription" CssClass="cssManField" runat="server" 
                Text="Mô tả" />
			       
                </td>
                <td align="left" colspan="3">    
			        &nbsp;<asp:TextBox id="m_txt_description" runat="server" Width="96%" ></asp:TextBox> </td> 
                <td align="left" style="width:10%;">    
			        &nbsp;</td> <td align="left" style="width:1%;"></td>
                 <td align="right" style="width:5%;"></td>
                <td align="left" style="width:10%;"></td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">&nbsp;</td>
                <td align="left" style="width:10%;">    
			        &nbsp;</td> 
                <td align="left" style="width:1%;">&nbsp;</td>
                <td align="left" style="width:5%;">
			        &nbsp;</td>
                <td align="left" style="width:10%;">    
			        &nbsp;</td> <td align="left" style="width:1%;">&nbsp;</td>
                 <td align="right" style="width:5%;">&nbsp;</td>
                <td align="left" style="width:10%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			        &nbsp;</td>
                <td align="left" style="width:1%;">
			        <asp:button id="m_cmd_luu_du_lieu" accessKey="s" CssClass="cssButton" 
                runat="server" Width="98px" Text="Tạo chi tiết" 
                        Height="24px" onclick="m_cmd_luu_du_lieu_Click" />
                </td>
			   <td align="left" style="width:1%;"></td>
                 <td align="left" colspan="2">
                     <asp:Button ID="m_cmd_cap_nhat_pl" runat="server" accessKey="s" 
                         CssClass="cssButton" Height="24px" 
                         Text="Cập nhật chi tiết" Width="98px" onclick="m_cmd_cap_nhat_pl_Click"/>
                 </td>
                <td align="left" style="width:1%;"></td>
                <td align="left" style="width:10%;">
                    <asp:Button ID="m_cmd_xoa_trang" runat="server" CausesValidation="False" 
                        CssClass="cssButton" Height="25px" Text="Xóa trắng" 
                        Width="98px" onclick="m_cmd_xoa_trang_Click" />
                </td>  
                  <td align="left" style="width:10%;">
                      &nbsp;</td>  
            </tr>
        </table>

		</td>
	</tr>
    <tr>
		<td class="cssPageTitleBG" colspan="2">
		    <asp:label id="Label11" runat="server" CssClass="cssPageTitle" 
                Text="Danh sách chi tiết thanh toán"/>
		</td>
	</tr>	
    <tr>
		<td align="left">
                <asp:Button ID="m_cmd_exit" runat="server" accessKey="s" CssClass="cssButton" 
                          Height="24px" Text="Thoát" Width="98px" CausesValidation="false" 
                          onclick="m_cmd_exit_Click" /><br />
                          <asp:Label ID="m_lbl_thong_bao" CssClass="cssManField" runat="server"></asp:Label>
                <asp:HiddenField ID="hdf_id_gv" runat="server" />
        </td>
        <td >
		    &nbsp;</td>
	</tr>	
	<tr>
		<td align="center" colspan="2" style="height:450px;" valign="top">
		    &nbsp;
   <asp:GridView ID="m_grv_gd_thanh_toan_detail" AllowPaging="True" 
                runat="server" AutoGenerateColumns="False" 
                Width="100%" DataKeyNames="ID"
                CellPadding="4" ForeColor="#333333" 
            AllowSorting="True" onrowdeleting="m_grv_gd_thanh_toan_detail_RowDeleting" 
                onselectedindexchanging="m_grv_gd_thanh_toan_detail_SelectedIndexChanging" >
                  <AlternatingRowStyle BackColor="White" />
                <Columns>
                <asp:TemplateField HeaderText="Xóa">
                    <ItemTemplate> <asp:LinkButton ToolTip="Xóa" ID = "lbt_delete" runat="server"
                     CommandName="Delete" CausesValidation="false" OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')">
                      <img src="/TRMProject/Images/Button/deletered.png" alt="Delete" />
                     </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="3%" HorizontalAlign="Center"/>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Sửa">
                    <ItemTemplate>
                     <asp:LinkButton CausesValidation="false" CommandName="Select" ToolTip="Sửa" ID = "lbt_edit" runat="server">
                    <img src='/TRMProject/Images/Button/edit.png' alt='Sửa' />
                    </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="3%" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Số phiếu thanh toán" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%#  get_so_phieu_thanh_toan_by_id_gd_thanh_toan(CIPConvert.ToDecimal(Eval("ID_GD_THANH_TOAN")))%></ItemTemplate>
                        <ItemStyle Width="15%" HorizontalAlign="Center" />
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Số hợp đồng" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%#  get_so_hop_dong_by_id(CIPConvert.ToDecimal(Eval("ID_HOP_DONG_KHUNG")))%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                    </asp:TemplateField> 
                     <asp:TemplateField HeaderText="Nội dung thanh toán">
                       <ItemTemplate><%#  get_noi_dung_tt_by_id(CIPConvert.ToDecimal(Eval("ID_NOI_DUNG_THANH_TOAN")))%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                    </asp:TemplateField> 
                     <asp:TemplateField HeaderText="Số lượng / hệ số" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%#CIPConvert.ToStr(CIPConvert.ToDecimal(Eval("SO_LUONG_HE_SO")), "0.00")%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:TemplateField> 
                     <asp:BoundField DataField="DON_VI_TINH" HeaderText="Đơn vị tính">
                     <ItemStyle Width="5%" HorizontalAlign="Center" />
                    </asp:BoundField>
                     <asp:TemplateField HeaderText="Đơn giá (VNĐ)">
                       <ItemTemplate><%#CIPConvert.ToStr(CIPConvert.ToDecimal(Eval("DON_GIA_TT")),"#,###0")%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                    </asp:TemplateField> 
                     <asp:TemplateField HeaderText="Tần suất thanh toán">
                       <ItemTemplate><%# "Theo " + Eval("TAN_SUAT")%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="DESCRIPTION" HeaderText="Mô tả">
                     <ItemStyle Width="10%" HorizontalAlign="Left" />
                    </asp:BoundField>
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

