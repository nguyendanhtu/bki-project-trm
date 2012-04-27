<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F407_LapDuToan.aspx.cs" Inherits="ChucNang_F407_LapDuToan" %>
<%@ Import Namespace ="IP.Core.IPCommon" %>
<%@ Register assembly="eWorld.UI" namespace="eWorld.UI" tagprefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
    <tr>
		<td class="cssPageTitleBG">
		    <asp:label id="m_lbl_thong_tin_hd" runat="server" CssClass="cssPageTitle" 
                Text="Thông tin Đợt thanh toán"/>
		</td>
	</tr>
    <tr>
		<td>
        <table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0"> 
            <tr>
                <td align="right" style="width:7%;">
			<asp:label id="Label1" CssClass="cssManField" runat="server" 
                Text="Đơn vị thanh toán: " /></td>
                <td align="left" colspan="4"> &nbsp;
			<asp:Label id="m_lbl_don_vi_thanh_toan"  runat="server" 
                MaxLength="64" Width="96%" />
                    &nbsp;
			             </td>
                <td align="left" style="width:1%;">&nbsp;</td>
                 <td align="right" style="width:5%;">&nbsp;</td>
                <td align="left" style="width:10%;">&nbsp;</td>
                <td align="left" style="width:1%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:7%;">
			       
			<asp:label id="Label4" CssClass="cssManField" runat="server" 
                Text="Mã đợt thanh toán: " />
			       
                         </td>
                <td align="left" style="width:10%;">
                    &nbsp;<asp:Label ID="m_lbl_ma_dot_thanh_toan" runat = "server"></asp:Label></td>
                         <td align="left" style="width:1%;"> 
                             &nbsp;</td>
                <td align="right" style="width:7%;">
			       
			<asp:label id="m_lbl_dv_thanh_toan" CssClass="cssManField" runat="server" 
                Text="Tên đợt thanh toán: " />
			       
			    </td>
                <td align="left" colspan="3">	
			        <asp:label id="m_lbl_ten_dot_thanh_toan" runat="server" /></td>
                <td align="left" style="width:10%;"></td>
                <td align="left" style="width:1%;"></td>
            </tr>
            <tr>
                <td align="right" style="width:7%;">
			       
			<asp:label id="Label2" Enabled="false" CssClass="cssManField" runat="server" 
                Text="Ngày thanh toán dự kiến: " />
			       
                </td>
                <td align="left" style="width:10%;">
                 &nbsp;
			<asp:Label id="m_lbl_ngay_tt_du_kien" runat="server" />
                         </td>
                     <td align="left" style="width:1%;">
                         &nbsp;</td>
                <td align="right" style="width:5%;">
			       
			<asp:label id="lbl_trang_thai_dot_tt" CssClass="cssManField" runat="server" 
                Text="Trạng thái đợt thanh toán" />
			       
			    </td>
                <td align="left" style="width:10%;">
			
			        <asp:label id="m_lbl_trang_thai_dot_tt" runat="server" /></td>
                      <td align="left" style="width:1%;">
                          &nbsp;</td>
                 <td align="right" style="width:5%;">
			       
			         &nbsp;</td>
                <td align="left" style="width:10%;">
		            &nbsp;</td>
                <td align="left" style="width:1%;">&nbsp;</td>
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
		<td class="cssPageTitleBG" colspan="3">
		    <asp:label id="Label5" runat="server" CssClass="cssPageTitle" 
                Text="Thông tin hợp đồng"/>
		</td>
	</tr>	
  <tr>
        <td>
        <table cellspacing="0" cellpadding="2" style="width:1000px;" class="cssTable" border="0"> 
            <tr>
                <td align="right" style="width:5%;">
			<asp:label id="lblFullName" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;S&lt;/U&gt;ố hợp đồng" />
                         </td>
                <td align="left" style="width:10%;">
		    <asp:TextBox ID="m_txt_ten_giang_vien" runat="server" CssClass="cssTextBox" 
                        Width="99%"></asp:TextBox>
                         </td>
                         <td align="left" style="width:1%;"> 
                             &nbsp;</td>
                <td align="left" style="width:5%;">
			       
			<asp:label id="lblFullName2" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;M&lt;/U&gt;ã PO phụ trách hợp đồng" />
			       
			    </td>
                <td align="left" style="width:10%;">
		    <asp:TextBox ID="m_txt_ten_giang_vien6" runat="server" CssClass="cssTextBox" 
                        Width="99%"></asp:TextBox>
                         </td>
                <td align="left" style="width:1%;"></td>
                 <td align="right" style="width:5%;">
			<asp:label id="lblFullName3" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;M&lt;/U&gt;ã lớp môn" />
                         </td>
                <td align="left" style="width:10%;">
		    <asp:TextBox ID="m_txt_ten_giang_vien7" runat="server" CssClass="cssTextBox" 
                        Width="99%"></asp:TextBox>
                         </td>
                <td align="left" style="width:1%;"></td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			<asp:label id="Label16" CssClass="cssManField" runat="server" 
                Text="Loại hợp đồng" />
		                    </td>
                <td align="left" style="width:10%;">
		    <asp:TextBox ID="m_txt_ten_giang_vien0" runat="server" CssClass="cssTextBox" 
                        Width="99%"></asp:TextBox>
                         </td>
                                 <td align="left" style="width:1%;"></td>
                <td align="right" style="width:5%;">
			<asp:label id="Label18" CssClass="cssManField" runat="server" 
                Text="Đơn vị quản lý HĐ" />
		                    </td>
                <td align="left" style="width:10%;">
		    <asp:TextBox ID="m_txt_ten_giang_vien1" runat="server" CssClass="cssTextBox" 
                        Width="99%"></asp:TextBox>
                         </td>
                                 <td align="left" style="width:1%;"></td>
                 <td align="right" style="width:5%;">
			<asp:label id="Label8" CssClass="cssManField" runat="server" 
                Text="Trạng thái hợp đồng" />
		                    </td>
                <td align="left" style="width:10%;">
		    <asp:TextBox ID="m_txt_ten_giang_vien2" runat="server" CssClass="cssTextBox" 
                        Width="99%"></asp:TextBox>
                         </td>     <td align="left" style="width:1%;"></td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			<asp:label id="lblNgayKi" CssClass="cssManField" runat="server" 
                Text="Ngày kí" />
		                    </td>
                <td align="left" style="width:10%;">
		    <asp:TextBox ID="m_txt_ten_giang_vien3" runat="server" CssClass="cssTextBox" 
                        Width="99%"></asp:TextBox>
                         </td>
                                 <td align="left" style="width:1%;">&nbsp;</td>
                <td align="right" style="width:5%;">
			       
			<asp:label id="lblNgayHieuLuc" CssClass="cssManField" runat="server" 
                Text="Ngày hiệu lực" />
		                    </td>
                <td align="left" style="width:10%;">
		    <asp:TextBox ID="m_txt_ten_giang_vien4" runat="server" CssClass="cssTextBox" 
                        Width="99%"></asp:TextBox>
                         </td>
                                 <td align="left" style="width:1%;">&nbsp;</td>
                 <td align="right" style="width:5%;">
			       
			<asp:label id="lblNgayketthuc" CssClass="cssManField" runat="server" 
                Text="Ngày kết thúc" />
		                    </td>
                <td align="left" style="width:10%;">
		    <asp:TextBox ID="m_txt_ten_giang_vien5" runat="server" CssClass="cssTextBox" 
                        Width="99%"></asp:TextBox>
                         </td>     <td align="left" style="width:1%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			        &nbsp;</td>
                <td align="left" style="width:10%;">          
			        &nbsp;</td>
			    <td align="left" style="width:1%;">
                    &nbsp;</td>
			
                <td align="left" style="width:5%;">
			        &nbsp;</td>
                <td align="left" style="width:10%;">     
			        &nbsp;</td>     <td align="left" style="width:1%;"></td>
                 <td align="right" style="width:5%;"></td>
                <td align="left" style="width:10%;"></td>     <td align="left" style="width:1%;"></td>
            </tr>
            </table>        
        </td>
    </tr>

     <tr>
		<td class="cssPageTitleBG" colspan="4">
		    <asp:label id="m_lbl_loc_du_lieu" runat="server" CssClass="cssPageTitle" 
                Text="Danh sách các thanh toán"/>
		</td>
	</tr>	
    <tr>
		<td colspan="4">
		  
                <asp:label id="m_lbl_thong_bao" runat="server" CssClass="cssManField" />
		  
		</td>
	</tr>	
	<tr>
		<td align="center" style="height:450px;" valign="top" colspan="4">
		    &nbsp;
            <asp:GridView ID="m_grv_dm_danh_sach_hop_dong_khung" AllowPaging="True" 
                runat="server" AutoGenerateColumns="False" 
                Width="100%" DataKeyNames="ID"
                CellPadding="4" ForeColor="#333333" 
            AllowSorting="True" >
                  <AlternatingRowStyle BackColor="White" />
                <Columns>
                  <asp:TemplateField HeaderText="Xóa">
                    <ItemTemplate> <asp:LinkButton ToolTip="Xóa" ID = "lbt_delete" runat="server"
                     CommandName="Delete" OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')">
                      <img src="/TRMProject/Images/Button/deletered.png" alt="Delete" />
                     </asp:LinkButton>
                    </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Sửa">
                    <ItemTemplate> <asp:HyperLink ToolTip="Sửa" ImageUrl="/TRMProject/Images/Button/edit.png" ID = "lbt_edit" runat="server"
                     NavigateUrl='<%# "/TRMProject/ChucNang/F407_LapDuToan.aspx?mode=edit&id="+Eval("ID") %>'></asp:HyperLink>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><asp:Label ID="m_lbl_stt" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>

                     <asp:TemplateField>
                    <HeaderTemplate>Số hợp đồng</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_so_hop_dong" runat="server" Text='<%# Eval("SO_HOP_DONG").ToString() %>' ></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField>
                    <HeaderTemplate>Mã PO Phụ trách hợp đồng</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_ma_po_phu_trach" runat="server" Text='<%# Eval("MA_PO_PHU_TRACH").ToString() %>' ></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                    </asp:TemplateField>
                     <asp:TemplateField>
                    <HeaderTemplate>Mã giảng viên</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_ma_gv" runat="server" Text='<%# get_ma_gv_form_id(CIPConvert.ToDecimal(Eval("ID_GIANG_VIEN"))) %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="200px"/>
                    </asp:TemplateField>
                    <asp:TemplateField>
                    <HeaderTemplate>Tên giảng viên</HeaderTemplate>
                    <ItemTemplate>
                    <label><a href='<%# "/TRMProject/ChucNang/F201_CapNhatThongTinGiangVien.aspx?mode=edit&id="+Eval("ID_GIANG_VIEN") %>'>
                    <%# Eval("GIANG_VIEN").ToString() %></a></label>
                    </ItemTemplate>
                    <ItemStyle Width="10%"/>
                    </asp:TemplateField>
                    <asp:BoundField DataField="NGAY_KY" HeaderText="Ngày ký" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false" />
                      <asp:BoundField DataField="NGAY_HIEU_LUC" HeaderText="Ngày hiệu lực" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false">
                    </asp:BoundField>
                    <asp:BoundField DataField="NGAY_KET_THUC_DU_KIEN" HeaderText="Ngày kết thúc " DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false">
                    </asp:BoundField>
                      <asp:TemplateField>
                    <HeaderTemplate>Đơn vị quản lý</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_don_vi_quan_ly" runat="server" Text='<%# Eval("DON_VI_QUAN_LY").ToString() %>' ></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                    </asp:TemplateField>
                     <asp:TemplateField>
                    <HeaderTemplate>Đơn vị thanh toán</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_don_vi_thanh_toan" runat="server" Text='<%# Eval("DON_VI_THANH_TOAN").ToString() %>' ></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField>
                    <HeaderTemplate>Môn 1</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_mon_1" runat="server" Text='<%# Eval("FIRST_MON").ToString() %>' ></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:TemplateField>
                     <asp:TemplateField>
                    <HeaderTemplate>Môn 2</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_mon_2" runat="server" Text='<%# Eval("SEC_MON").ToString() %>' ></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                    </asp:TemplateField>
                     <asp:TemplateField>
                    <HeaderTemplate>Môn 3</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_mon_3" runat="server" Text='<%# Eval("THIR_MON").ToString() %>' ></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                    </asp:TemplateField>
                     <asp:TemplateField>
                    <HeaderTemplate>Môn 4</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_mon_4" runat="server" Text='<%# Eval("FOURTH_MON").ToString() %>' ></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                    </asp:TemplateField>
                     <asp:TemplateField>
                    <HeaderTemplate>Môn 5</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_mon_5" runat="server" Text='<%# Eval("FITH_MON").ToString() %>' ></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                    </asp:TemplateField>
                     <asp:TemplateField>
                    <HeaderTemplate>Môn 6</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_mon_6" runat="server" Text='<%# Eval("SIXTH_MON").ToString() %>' ></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                    </asp:TemplateField>
                     <asp:TemplateField>
                    <HeaderTemplate>Trạng thái hợp đồng</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_trang_thai_hd" runat="server" Text='<%# Eval("TRANG_THAI_HOP_DONG").ToString() %>' ></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:TemplateField>                    
                      <asp:TemplateField Visible="false">
                    <HeaderTemplate>Giá trị hợp đồng</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_gia_tri_hd" runat="server" Text='<%# Eval("GIA_TRI_HOP_DONG").ToString()%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                    </asp:TemplateField>
                     <asp:BoundField DataField="GIA_TRI_HOP_DONG" DataFormatString="{0:N0}" HeaderText="Giá trị hợp đồng" ItemStyle-HorizontalAlign="Right" HtmlEncode="false">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
                    </asp:BoundField>
                     <asp:TemplateField Visible="false">
                    <HeaderTemplate>Thuế suất(%)</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_thue_suat" runat="server" Text='<%# Eval("THUE_SUAT").ToString() +"%"%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="THUE_SUAT" DataFormatString="{0:N1}%" HeaderText="Thuế suất(%)"  HtmlEncode="false"></asp:BoundField>
                    <asp:TemplateField>
                    <HeaderTemplate>HĐ học liệu?</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_lam_hoc_lieu" runat="server" Text='<%# mapping_hl(Eval("HOC_LIEU_YN").ToString())%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField>
                       <HeaderTemplate>HĐ vận hành?</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_van_hanh" runat="server" Text ='<%# mapping_vh(Eval("VAN_HANH_YN").ToString())%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField>
                       <HeaderTemplate>Có số hợp đồng?</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label  ID="m_lbl_co_so_hop_dong" runat="server" Text = '<%# mapping_cs(Eval("CO_SO_HD_YN").ToString())%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
                  <EditRowStyle BackColor="#7C6F57" />
                  <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                  <HeaderStyle BackColor="#810c15" Font-Bold="True" ForeColor="White" />
                  <PagerSettings Position="TopAndBottom" />
                  <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                  <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle CssClass="cssSelectedRow" BackColor="#C5BBAF" Font-Bold="True" 
                      ForeColor="#333333"></SelectedRowStyle>
            </asp:GridView>           
            </td>
	</tr>
 </table>
</asp:Content>

