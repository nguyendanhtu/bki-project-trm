<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F1722_TongHopThanhToanGV.aspx.cs" Inherits="CongTTGV_F1722_TongHopThanhToanGV" %>
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
                Text="Danh sách đợt Thanh toán"/>
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
                Width="150%" DataKeyNames="ID_DOT_THANH_TOAN"
                CellPadding="4" ForeColor="#333333" 
                onpageindexchanging="m_grv_danh_sach_du_toan_PageIndexChanging" 
                PageSize="30" >
                  <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="STT">
                       <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="1%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="Mã giảng viên">
                       <ItemTemplate><%# Eval("ID_GIANG_VIEN")%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="7%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="Họ tên">
                       <ItemTemplate><%# mapping_tengv_by_id(CIPConvert.ToDecimal(Eval("ID_GIANG_VIEN")))%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="7%"></ItemStyle>
                    </asp:TemplateField> 

                     <asp:TemplateField HeaderText="Mã đợt thanh toán">
                       <ItemTemplate><%# mapping_sophieutt_by_ID(CIPConvert.ToDecimal(Eval("ID_DOT_THANH_TOAN")))%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                    </asp:TemplateField>

                      <asp:TemplateField HeaderText="Đơn vị quản lý">
                       <ItemTemplate><%# mapping_dvtt_by_ID(CIPConvert.ToDecimal(Eval("ID_DOT_THANH_TOAN")))%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Số tài khoản">
                        <ItemStyle Width="10%" />
                        <ItemTemplate><%# mapping_sotaikhoan_by_id(CIPConvert.ToDecimal(Eval("ID_GIANG_VIEN")))%></ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Tên ngân hàng" 
                        ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%# mapping_tennganhang_by_id(CIPConvert.ToDecimal(Eval("ID_GIANG_VIEN")))%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                    </asp:TemplateField> 
                      <asp:TemplateField FooterText="Tổng: " HeaderText="Mã số thuế">
                          <ItemStyle Width="10%" />
                          <ItemTemplate><%# mapping_masothue_by_id(CIPConvert.ToDecimal(Eval("ID_GIANG_VIEN")))%></ItemTemplate>
                    </asp:TemplateField>
                       <asp:TemplateField HeaderText="Tông tiền thanh toán đợt này(VNĐ)" 
                        ItemStyle-HorizontalAlign="Right">
                       <ItemTemplate><%# string.Format("{0:N0}", Eval("TONG_TIEN_THANH_TOAN"))%></ItemTemplate>
                           <FooterTemplate>
                               <%#string.Format("{0:N0}", get_tong_tien_dot_TT()) %>
                           </FooterTemplate>
                           <FooterStyle HorizontalAlign="Left" />
                        <ItemStyle ForeColor="Black" HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Right" 
                        HeaderText="Số tiền thuế(VNĐ)">
                       <ItemTemplate><%# string.Format("{0:N0}",  (CIPConvert.ToDecimal(Eval("TONG_TIEN_THANH_TOAN")) > 1000000) ? CIPConvert.ToDecimal(Eval("TONG_TIEN_THANH_TOAN")) /10 : 0) %></ItemTemplate>
                        <FooterStyle HorizontalAlign="Right" />
                         <FooterTemplate>
                               <%#string.Format("{0:N0}", (get_tong_tien_dot_TT() > 1000000)? get_tong_tien_dot_TT()/10 : 0) %>
                           </FooterTemplate>
                        <ItemStyle></ItemStyle>
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Tổng số tiền thực nhận(VNĐ)">
                        <ItemTemplate><%# string.Format("{0:N0}", CIPConvert.ToDecimal(Eval("TONG_TIEN_THANH_TOAN")) - ((CIPConvert.ToDecimal(Eval("TONG_TIEN_THANH_TOAN")) > 1000000) ? CIPConvert.ToDecimal(Eval("TONG_TIEN_THANH_TOAN")) / 10 : 0))%></ItemTemplate>
                         <FooterTemplate>
                               <%#string.Format("{0:N0}", get_tong_tien_dot_TT() - ((get_tong_tien_dot_TT() > 1000000) ? get_tong_tien_dot_TT() / 10 : 0))%>
                           </FooterTemplate>
                    </asp:TemplateField>
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

