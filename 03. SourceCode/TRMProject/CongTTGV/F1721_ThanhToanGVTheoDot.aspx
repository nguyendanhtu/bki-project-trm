<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F1721_ThanhToanGVTheoDot.aspx.cs" Inherits="CongTTGV_F1721_ThanhToanGVTheoDot" %>
<%@ Import Namespace ="IP.Core.IPCommon" %>
<%@ Register assembly="eWorld.UI" namespace="eWorld.UI" tagprefix="ew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table  cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
<tr>
		<td class="cssPageTitleBG">
		    <asp:label id="lblUser" runat="server" CssClass="cssPageTitle" 
                Text="Quá trình thanh toán của giảng viên"/>
		</td>
	</tr>
	<tr>
		<td>
		    &nbsp;</td>
	</tr>
    <tr>
		<td>
        <table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0"> 
            <tr>
                <td align="right" style="width:15%;height:30px;">			       
			       
			<asp:label id="Label6" CssClass="cssManField" runat="server" 
                Text="Tên giảng viên: " />
			       
                         </td>
                <td align="left" colspan="2">
              <asp:DropDownList ID="m_cbo_ten_giang_vien" CssClass="cssDorpdownlist" Enabled="false"
                        Width="90%" runat="server" 
                        AutoPostBack="true" 
                        onselectedindexchanged="m_cbo_ten_giang_vien_SelectedIndexChanged" 
                        Height="27px">
               </asp:DropDownList>
                         </td>
                <td align="left" colspan="2">			       
			       
			<asp:label id="Label7" CssClass="cssManField" runat="server" 
                Text="Mã giảng viên: " />
			   <asp:label id="m_lbl_ma_gv" runat="server"/>    
                         </td>
            </tr>
            <tr>
                <td align="right" style="width:15%;height:30px;">			       
			       
			<asp:label id="Label1" CssClass="cssManField" runat="server" 
                Text="Đơn vị thanh toán: " />
			       
                         </td>
                <td align="left" colspan="4">
              <asp:DropDownList ID="m_cbo_don_vi_thanh_toan" CssClass="cssDorpdownlist" Width="85%" runat="server" 
                        AutoPostBack="true" 
                        onselectedindexchanged="m_cbo_don_vi_thanh_toan_SelectedIndexChanged">
               </asp:DropDownList>
                         </td>
                <td align="left" style="width:1%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:17%;height:30px;">			       
			       
			<asp:label id="Label8" CssClass="cssManField" runat="server" 
                Text="Mã lớp môn (với TH vận hành): " />
                </td>
                <td align="left"  style="width:15%;">
                    <asp:TextBox ID="m_txt_reference_code" Width="90%" runat="server"></asp:TextBox>
                </td>
                <td align="right" style="width:13%;">			       
			       
			<asp:label id="Label9" Enabled="false" CssClass="cssManField" runat="server" 
                Text="Trạng thái thanh toán: " />
			       
                </td>
                <td align="left" colspan="2">
              <asp:DropDownList ID="m_cbo_trang_thai_thanh_toan" CssClass="cssDorpdownlist" 
                        Width="90%" runat="server" 
                        AutoPostBack="true" 
                        onselectedindexchanged="m_cbo_trang_thai_thanh_toan_SelectedIndexChanged">
               </asp:DropDownList>
                         </td>
            </tr>
            <tr>
                <td align="right" style="width:17%;height:30px;">			       
			       
			<asp:label id="Label3" Enabled="false" CssClass="cssManField" runat="server" 
                Text="Tháng thanh toán dự kiến: " />
			       
                </td>
                <td align="left"  style="width:15%;">
                    <asp:DropDownList id="m_cbo_thang_thanh_toan" runat="server" Width="50%" 
                        CssClass="cssDorpdownlist" AutoPostBack="true"
                        onselectedindexchanged="m_cbo_thang_thanh_toan_SelectedIndexChanged"  >
                        <asp:ListItem Selected="True" Value="0">Tất cả</asp:ListItem>
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                    </td>
                <td align="right" style="width:13%;">			       
			       
			<asp:label id="Label4" Enabled="false" CssClass="cssManField" runat="server" 
                Text="Năm thanh toán: " />
			       
                </td>
                <td align="left" style="width:15%;">
                    <asp:DropDownList id="m_cbo_nam_thanh_toan" runat="server" Width="50%" 
                        CssClass="cssDorpdownlist" AutoPostBack="true"
                        onselectedindexchanged="m_cbo_nam_thanh_toan_SelectedIndexChanged"  >
                    </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <td align="right" style="width:5%;height:35px;">
			       
			<asp:label id="Label10" Enabled="false" CssClass="cssManField" runat="server" 
                Text="Đợt thanh toán: " />
			       
                </td>
                <td align="left" colspan="3">    
			
              <asp:DropDownList ID="m_cbo_dot_thanh_toan" CssClass="cssDorpdownlist" 
                        Width="95%" runat="server" 
                        AutoPostBack="true" 
                        onselectedindexchanged="m_cbo_dot_thanh_toan_SelectedIndexChanged">
               </asp:DropDownList>
                         </td> 
                 <td align="right" style="width:5%;">&nbsp;</td>
                <td align="left" style="width:10%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;height:35px;">
			       
			<asp:label id="lbltan_suat3" CssClass="cssManField" runat="server" 
                Text="Loại hợp đồng" />
			       
                </td>
                <td align="left" colspan="2">    
			
                    <asp:RadioButtonList ID="m_rdl_loai_hop_dong" runat="server" 
                       
                        RepeatDirection="Horizontal" Width="70%">
                        <asp:ListItem Value="All" Selected="True">Tất cả</asp:ListItem>
                        <asp:ListItem Value="Vanhanh">Vận hành</asp:ListItem>
                        <asp:ListItem Value="Hoclieu">Học liệu</asp:ListItem>
                    </asp:RadioButtonList></td> 
                <td align="left" style="width:1%;">
			
                    &nbsp;</td>
                 <td align="right" style="width:5%;">&nbsp;</td>
                <td align="left" style="width:10%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			       
			        &nbsp;</td>
                <td align="left" colspan="3">
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
                     <asp:Button ID="m_cmd_tim_kiem" runat="server" accessKey="s" 
                         CssClass="cssButton" Height="24px" 
                         Text="Tìm kiếm" Width="98px" onclick="m_cmd_tim_kiem_Click" />
                 </td>
			   <td align="left" style="width:1%;">
                     &nbsp;</td>
                 <td align="left">
                    <asp:Button ID="m_cmd_xuat_excel" runat="server" CausesValidation="False" 
                        CssClass="cssButton" Height="25px"  Text="Xuất Excel" 
                        Width="98px" onclick="m_cmd_xuat_excel_Click" />
                </td>
                <td align="left" style="width:1%;">
                    &nbsp;</td>
                <td align="left" style="width:10%;">
                    &nbsp;</td>  
                  <td align="left" style="width:10%;">
                      &nbsp;</td>  
            </tr>
        </table>
		</td>
	</tr>
    <tr>
		<td class="cssPageTitleBG" colspan="2">
		    <asp:label id="m_lbl_danh_sach_thanh_toan" runat="server" CssClass="cssPageTitle" 
                Text="Danh sách Thanh toán"/>
		</td>
	</tr>	
    <tr>
		<td align="left">
            <asp:Label ID="m_lbl_thong_bao" CssClass="cssManField" runat="server"></asp:Label>
            <asp:HiddenField ID="hdf_id_gv" runat="server" />
        </td>
        <td>
		    &nbsp;</td>
	</tr>	

	<tr>
		<td align="center" colspan="2" style="height:450px;" valign="top">
		    &nbsp;
       <asp:GridView ID="m_grv_danh_sach_du_toan" AllowPaging="True" 
                runat="server" AutoGenerateColumns="False" ShowFooter="True"
                Width="150%" DataKeyNames="ID"
                CellPadding="4" ForeColor="#333333" 
                onpageindexchanging="m_grv_danh_sach_du_toan_PageIndexChanging" 
                PageSize="30" >
                  <AlternatingRowStyle BackColor="White" />
                <Columns>
                 <asp:TemplateField HeaderText="Xem chi Tiết">
                    <ItemTemplate> <asp:HyperLink ToolTip="Xem chi tiết thanh toán" ImageUrl="/TRMProject/Images/Button/detail.png" ID = "lbt_phu_luc_hop_dong" runat="server"
                     NavigateUrl='<%# "/TRMProject/CongTTGV/F1723_ChiTietThanhToanGV.aspx?id_gdtt="+Eval("ID")+"&id_dtt="+Eval("ID_DOT_THANH_TOAN") %>'></asp:HyperLink>
                    </ItemTemplate>
                         <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="STT">
                       <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="1%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="Mã giảng viên">
                       <ItemTemplate><%# mapping_magv_by_id(CIPConvert.ToDecimal(Eval("ID_GIANG_VIEN")))%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="7%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="Họ tên">
                       <ItemTemplate><%# Eval("TEN_GIANG_VIEN")%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="7%"></ItemStyle>
                    </asp:TemplateField> 

                     <asp:TemplateField HeaderText="Mã đợt thanh toán">
                       <ItemTemplate><%# Eval("SO_PHIEU_THANH_TOAN")%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="7%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Ngày thanh toán" DataField="NGAY_THANH_TOAN" DataFormatString="{0:dd/MM/yyy}" ItemStyle-HorizontalAlign="Center">
                        <ItemStyle Width="3%"></ItemStyle>
                    </asp:BoundField> 

                      <asp:TemplateField HeaderText="Đơn vị quản lý">
                       <ItemTemplate><%# mapping_don_vi_quan_ly(CIPConvert.ToDecimal(Eval("ID_DON_VI_QUAN_LY")))%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="5%"></ItemStyle>
                    </asp:TemplateField> 
                     <asp:BoundField HeaderText="Số hợp đồng" DataField="SO_HOP_DONG">
                    <ItemStyle Width="7%" HorizontalAlign="Left" />
                    </asp:BoundField>
                      <asp:TemplateField HeaderText="Loại hợp đồng" 
                        ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%# mapping_loai_hop_dong_gv(CIPConvert.ToDecimal(Eval("ID_HOP_DONG_KHUNG")))%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="5%"></ItemStyle>
                    </asp:TemplateField>
                      <asp:BoundField HeaderText="Thời gian thực hiện" DataField="THOI_GIAN">
                    <ItemStyle Width="4%" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Số tài khoản" DataField="SO_TAI_KHOAN">
                    <ItemStyle Width="3%" HorizontalAlign="Left" />
                    </asp:BoundField>
                     <asp:TemplateField HeaderText="Tên ngân hàng" 
                        ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%# Eval("TEN_NGAN_HANG")%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="7%"></ItemStyle>
                    </asp:TemplateField> 
                      <asp:BoundField DataField="MA_SO_THUE" HeaderText="Mã số thuế">
                     <ItemStyle Width="4%" HorizontalAlign="Right" />
                    </asp:BoundField>
                       <asp:TemplateField HeaderText="Tổng giá trị HĐ (VNĐ)" 
                        ItemStyle-HorizontalAlign="Right">
                       <ItemTemplate><%# mapping_gia_tri_hd(Eval("GIA_TRI_HOP_DONG"))%></ItemTemplate>
                        <ItemStyle  Width="5%"></ItemStyle>
                    </asp:TemplateField>
                     <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Tên các môn phụ trách">
                       <ItemTemplate><%# mapping_item_field_ten_cac_mon(CIPConvert.ToStr(Eval("LOAI_HOP_DONG")), Eval("GHI_CHU_CAC_MON_PHU_TRACH"))%></ItemTemplate>
                        <ItemStyle  Width="5%"></ItemStyle>
                    </asp:TemplateField> 
                     <asp:BoundField HeaderText="Đã thanh toán" DataField="DA_THANH_TOAN" 
                        DataFormatString="{0:N0}" FooterText="Tổng tiền:">
                        <FooterStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" Width="4%"></ItemStyle>
                     </asp:BoundField>
                     <asp:TemplateField HeaderText="Tông tiền thanh toán đợt này(VNĐ)">
                         <FooterStyle HorizontalAlign="Left" />
                         <ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="4%" />
                          <FooterTemplate>
                             <%#string.Format("{0:N0}", get_tong_tien_dot_TT()) %>
                         </FooterTemplate>
                       <ItemTemplate><%# Eval("TONG_TIEN_THANH_TOAN") %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Right" 
                        HeaderText="Số tiền còn phải thanh toán" FooterText="Thuế:">
                       <ItemTemplate><%# mapping_so_tien_con_phai_tt(Eval("CON_PHAI_THANH_TOAN"), Eval("LOAI_HOP_DONG"), Eval("REFERENCE_CODE"))%></ItemTemplate>
                        <FooterStyle HorizontalAlign="Right" />
                        <ItemStyle Width="5%"></ItemStyle>
                    </asp:TemplateField> 
                     <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Trạng thái thanh toán">
                         <FooterTemplate>
                             <%# string.Format("{0:N0}",(get_tong_tien_dot_TT() > 1000000)? double.Parse(CIPConvert.ToStr( get_tong_tien_dot_TT()))*0.1 : 0)  %>
                         </FooterTemplate>
                       <ItemTemplate><%# mapping_trang_thai_thanh_toan(CIPConvert.ToDecimal(Eval("ID_TRANG_THAI_THANH_TOAN"))) %></ItemTemplate>
                        <ItemStyle Width="5%"></ItemStyle>
                    </asp:TemplateField> 
                     <asp:BoundField DataField="PO_LAP_THANH_TOAN" HeaderText="PO lập thanh toán">
                     <ItemStyle Width="4%" HorizontalAlign="Left" />
                    </asp:BoundField>
                      <asp:BoundField DataField="DESCRIPTION" HeaderText="Ghi chú">
                     <ItemStyle Width="7%" HorizontalAlign="Left" />
                    </asp:BoundField>
                </Columns>
                  <EditRowStyle BackColor="#7C6F57" />
                  <FooterStyle BackColor="#810c15" Font-Bold="True" ForeColor="White" />
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

