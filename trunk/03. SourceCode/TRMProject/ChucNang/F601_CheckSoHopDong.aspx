<%@ Page Title="" MasterPageFile="~/Site.master" Language="C#" AutoEventWireup="true" CodeFile="F601_CheckSoHopDong.aspx.cs" Inherits="ChucNang_F601_CheckSoHopDong" %>
<%@ Import Namespace ="IP.Core.IPCommon" %>
<%@ Register assembly="eWorld.UI" namespace="eWorld.UI" tagprefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
         <tr>
		<td class="cssPageTitleBG" colspan="3">
		    <asp:label id="m_lbl_loc_du_lieu" runat="server" CssClass="cssPageTitle" 
                Text="Danh sách Hợp đồng khung"/>
		</td>
	</tr>
    <tr>
        <td align="right" style="width:15%">
		  
                <asp:label id="m_lbl_tu_khoa" runat="server" CssClass="cssManField" Text="Số hợp đồng tìm kiếm" />
		</td>
        <td align="left" style="width:15%">  
		    &nbsp;<asp:Label  id="m_lbl_so_hd" runat="server"></asp:Label> </td>
            <td align="left">  
		    &nbsp;</td>
    </tr>	
    <tr>
		<td colspan="3">
		  
                &nbsp;</td>
	</tr>	
    <tr>
		<td colspan="3">
		  
                          <asp:Label ID="m_lbl_thong_bao" CssClass="cssManField" runat="server"></asp:Label>
                </td>
	</tr>	
	<tr>
		<td align="center" style="height:450px;" valign="top" colspan="3">
		    &nbsp;
            <asp:GridView ID="m_grv_dm_danh_sach_hop_dong_khung" AllowPaging="True" 
                runat="server" AutoGenerateColumns="False" 
                Width="100%" DataKeyNames="ID"
                CellPadding="4" ForeColor="#333333" 
            AllowSorting="True" >
                  <AlternatingRowStyle BackColor="White" />
                <Columns>
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
                    <asp:Label ID="m_lbl_ma_gv" runat="server" Text='<%# CIPConvert.ToDecimal(Eval("ID_GIANG_VIEN")) %>'></asp:Label>
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

