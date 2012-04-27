<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F205_AdvanceSearchGiangVien.aspx.cs" Inherits="ChucNang_F205_AdvanceSearchGiangVien" %>
<%@ Import Namespace="WebDS.CDBNames" %>
<%@ Register assembly="eWorld.UI" namespace="eWorld.UI" tagprefix="ew" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
	<tr>
		<td class="cssPageTitleBG">
		    <asp:label id="lblUser" runat="server" CssClass="cssPageTitle" 
                Text="Advance Search Giảng viên "/>
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
        <table cellspacing="0" cellpadding="2" style="width:1000px;" class="cssTable" border="0"> 
            <tr>
                <td align="right" class="style1">
			<asp:label id="m_lbl_ten_ngan_hang" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;T&lt;/U&gt;ên Ngân hàng" />
                         </td>
                <td align="left" colspan="4" class="style2">
		            <asp:TextBox ID="m_txt_ten_ngan_hang" runat="server" Width="559px"></asp:TextBox>
                         </td>
                <td align="left" class="style3"></td>
                 <td align="right" class="style1"></td>
                <td align="left" class="style4"></td>
                <td align="left" class="style3"></td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			<asp:label id="m_lbl_so_hop_dong" CssClass="cssManField" runat="server" 
                Text="Số lượng hợp đồng đã ký" />
                         </td>
                <td align="left" style="width:10%;">
                     <ew:NumericBox ID="m_txt_so_hop_dong" Width="207px" runat="server" TextAlign="Left"></ew:NumericBox>
                         </td>
                         <td align="left" style="width:1%;"> 
                             &nbsp;</td>
                <td align="left" style="width:5%;">
			       
			<asp:label id="m_lbl_mon_hoc" CssClass="cssManField" runat="server" 
                Text="Môn học" />
                         </td>
                <td align="left" style="width:10%;">
		    <asp:DropDownList id="m_cbo_dm_mon_hoc" runat="server" Width="96%" 
                        CssClass="cssDorpdownlist" AppendDataBoundItems="True"  />
                         </td>
                <td align="left" style="width:1%;">&nbsp;</td>
                 <td align="right" style="width:5%;">
			       
			<asp:label id="m_lbl_den_tu" CssClass="cssManField" runat="server" 
                Text="Đến từ" />
                         </td>
                <td align="left" style="width:10%;">
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="22px" Width="206px">
                        <asp:ListItem Value="doanh_nghiep">Doanh nghiệp</asp:ListItem>
                        <asp:ListItem Value="truong_hoc">Trường học </asp:ListItem>
                        <asp:ListItem Value="all">Cả hai</asp:ListItem>
                        <asp:ListItem Value="chua_biet">Chưa biết</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="left" style="width:1%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			        &nbsp;</td>
                   <td align="left" style="width:1%;" colspan="4">

                <asp:label id="lblFullName1" CssClass="cssLabel" runat="server" 
                
                
                           Text="(Từ khóa tìm kiếm: Tên ngân hàng hoặc số hợp đồng đã ký hoặc đến từ hoặc theo môn học)" />

		        </td>
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
            <tr>
                <td align="right" >
			        &nbsp;</td>
                <td align="left">     
			<asp:button id="m_cmd_loc_du_lieu" accessKey="l" CssClass="cssButton" 
                runat="server" Width="98px" Text="Lọc dữ liệu(l)" 
                        onclick="m_cmd_loc_du_lieu_Click" Height="23px" />
			</td>
                             <td align="left" style="width:1%;">&nbsp;</td>
                <td align="right" >
			        &nbsp;</td>
                <td align="left" >    
			<asp:button id="m_cmd_xuat_excel" accessKey="x" CssClass="cssButton" 
                runat="server" Width="98px" Text="Xuất Excel (x)" Height="22px"  />
			</td>
                             <td align="left" >&nbsp;</td>
                 <td align="right" ></td>
                <td align="left" ></td>    
                <td align="left" ></td>
            </tr>
            </table>        
        </td>
    </tr>   
	
    <tr>
		<td class="cssPageTitleBG">
		    <asp:label id="m_lbl_loc_du_lieu" runat="server" CssClass="cssPageTitle" 
                Text="Kết quả lọc dữ liệu"/>
		</td>
	</tr>	
    <tr>
    <td><asp:label id="m_lbl_thong_bao" runat="server" CssClass="cssManField" /></td>
    </tr>
    <tr>
		<td align="right">
   <asp:GridView ID="m_grv_dm_danh_sach_giang_vien" AllowPaging="True" 
                runat="server" AutoGenerateColumns="False" 
                Width="101%" DataKeyNames="ID"
                CellPadding="4" ForeColor="#333333" 
            AllowSorting="True" 
            onpageindexchanging="m_grv_dm_danh_sach_giang_vien_PageIndexChanging" 
            PageSize="15" >
                  <AlternatingRowStyle BackColor="White" />
                <Columns>
                 <asp:TemplateField>
                    <ItemTemplate> 
                        <asp:LinkButton ID = "lbt_delete"  runat="server"
                     CommandName="Delete" ToolTip="Xóa" 
                            OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')">
                     <img src="/TRMProject/Images/Button/deletered.png" alt="Delete" />
                     </asp:LinkButton>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                    <ItemTemplate> <asp:HyperLink ToolTip="Sửa" 
                            ImageUrl="/TRMProject/Images/Button/edit.png" ID = "lbt_edit" runat="server"
                            NavigateUrl='<%# "/TRMProject/ChucNang/F201_CapNhatThongTinGiangVien.aspx?mode=edit&id="+Eval("ID") %>'></asp:HyperLink>
                    </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField>
                    <ItemTemplate> <asp:HyperLink ToolTip="Hợp đồng giảng viên" ImageUrl="/TRMProject/Images/Button/detail.png" ID = "lbt_hop_dong_gv" runat="server"
                     NavigateUrl='<%# "/TRMProject/ChucNang/F306_HopDongKhungGiangVien.aspx?id_gv="+Eval("ID") %>'></asp:HyperLink>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="MA_GIANG_VIEN" HeaderText="Mã giảng viên" 
                        Visible="False">
                        <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle></asp:BoundField>
                    <asp:TemplateField>
                    <HeaderTemplate>Mã giảng viên</HeaderTemplate>
                    <ItemTemplate>
                    <label><%# Eval("MA_GIANG_VIEN").ToString() %></label>
                    </ItemTemplate>
                    <ItemStyle Width="200px"/>
                    </asp:TemplateField>
                    <asp:TemplateField>
                    <HeaderTemplate>Tên giảng viên</HeaderTemplate>
                    <ItemTemplate>
                    <label><%# Eval("HO_VA_TEN_DEM").ToString().Trim() + " " + Eval("TEN_GIANG_VIEN").ToString()%></label>
                    </ItemTemplate>
                    <ItemStyle Width="200px"/>
                    </asp:TemplateField>
                       <asp:BoundField DataField="NGAY_SINH" HeaderText="Ngày sinh" 
                        DataFormatString="{0:d}">
                    </asp:BoundField>
                     <asp:BoundField DataField="CHUC_VU_HIEN_TAI" HeaderText="Chức vụ hiện tại">
                    </asp:BoundField>
                    <asp:BoundField DataField="CHUC_VU_CAO_NHAT" HeaderText="Chức vụ cao nhất">
                    </asp:BoundField>
                     <asp:BoundField DataField="TEL_HOME" HeaderText="Điện thoại nhà riêng">
                    </asp:BoundField>
                     <asp:BoundField DataField="TEL_OFFICE" HeaderText="Điện thoại cơ quan">
                    </asp:BoundField>
                    <asp:BoundField DataField="EMAIL" HeaderText="Email">
                    </asp:BoundField>
                     <asp:BoundField DataField="TEN_CO_QUAN_CONG_TAC" 
                        HeaderText="Tên cơ quan công tác">
                    </asp:BoundField>
                    <asp:BoundField DataField="EMAIL_TOPICA" HeaderText="TOPICA Email">
                    </asp:BoundField>
                    <asp:TemplateField>
                    <HeaderTemplate>Ảnh cá nhân</HeaderTemplate>
                    <ItemTemplate>
                    <img alt="anh ca nhan" src='<%# "/TRMProject/Images/PrivateImages/"+ Eval("ANH_CA_NHAN") %>' />
                    </ItemTemplate>
                    </asp:TemplateField>
                     <asp:BoundField DataField="HOC_VI" HeaderText="Học vị" />
                     <asp:BoundField DataField="HOC_HAM" HeaderText="Học hàm" />
                     <asp:BoundField DataField="CHUYEN_NGANH_CHINH" 
                        HeaderText="Chuyên ngành chính" />
                     <asp:BoundField DataField="TRUONG_DAO_TAO" HeaderText="Trường đào tạo" />
                     <asp:BoundField DataField="TRANG_THAI_GIANG_VIEN" 
                        HeaderText="Trạng thái giảng viên" />
                     <asp:BoundField DataField="SO_TAI_KHOAN" HeaderText="Số tài khoản" />
                     <asp:BoundField DataField="TEN_NGAN_HANG" HeaderText="Tên ngân hàng" />
                     <asp:BoundField DataField="SO_CMTND" HeaderText="Số chứng minh" />
                       <asp:BoundField DataField="NGAY_CAP" HeaderText="Ngày Cấp" 
                        DataFormatString="{0:d}">
                    </asp:BoundField>
                     <asp:BoundField DataField="NOI_CAP" HeaderText="Nơi cấp" />
                     <asp:BoundField DataField="DON_VI_QUAN_LY" HeaderText="Đơn vị quản lý" />
                     <asp:BoundField DataField="MA_SO_THUE" HeaderText="Mã số thuế" />
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
    <tr>
		<td align="center" style="height:450px;" valign="top">
		    &nbsp;</td>
	</tr>	

</table>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 5%;
            height: 26px;
        }
        .style2
        {
            height: 26px;
        }
        .style3
        {
            width: 1%;
            height: 26px;
        }
        .style4
        {
            width: 10%;
            height: 26px;
        }
    </style>
</asp:Content>

