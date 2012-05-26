<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F202_DanhSachGiangVien.aspx.cs" Inherits="ChuNang_F202_DanhSachGiangVien" %>
<%@ Register assembly="eWorld.UI" namespace="eWorld.UI" tagprefix="ew" %>
<%@ Import Namespace ="IP.Core.IPCommon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
 a 
 {
   text-decoration:none;    
 }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

 <table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
    <tr>
		<td class="cssPageTitleBG" colspan="3">
		    <asp:label id="Label1" runat="server" CssClass="cssPageTitle" 
                Text="Danh sách giảng viên"/>
		</td>
	</tr>	
    <tr>
        <td>
        
        <table cellspacing="0" cellpadding="2" style="width:1000px;" class="cssTable" border="0"> 
            <tr>
                <td align="right" style="width:7%;">
			<asp:label id="lblFullName" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;H&lt;/U&gt;ọ tên giảng viên" />
                         </td>
                <td align="left" colspan="3">
                &nbsp;<asp:TextBox ID="m_txt_ten_giang_vien" runat="server" CssClass="cssTextBox" 
                        Width="85%"></asp:TextBox>
		            &nbsp;</td>
                <td align="right" style="width:7%;">
                    <asp:label id="Label13" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;T&lt;/U&gt;háng sinh nhật Giảng viên" />
		            </td>
                <td align="left" colspan="2">
                    &nbsp;<asp:DropDownList id="m_cbo_thang_sn_GV" runat="server" Width="75%" 
                        CssClass="cssDorpdownlist"  >
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
                <td align="left" style="width:10%;"></td>
                <td align="left" style="width:1%;"></td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
                    <br />
                    &nbsp;<asp:label id="m_lbl_sex" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;G&lt;/U&gt;iới tính" /></td>
                <td align="left" colspan="3">
                    &nbsp; <asp:RadioButtonList ID="rdl_gender_check" runat="server" 
                       
                        RepeatDirection="Horizontal" Width="167px">
                        <asp:ListItem Selected="True">All</asp:ListItem>
                        <asp:ListItem Value="Male">Nam</asp:ListItem>
                        <asp:ListItem Value="Female">Nữ</asp:ListItem>
                    </asp:RadioButtonList></td>
                <td align="right" style="width:7%;">
                    <br />
                    <asp:label id="Label12" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;T&lt;/U&gt;háng bđ hợp tác" />
		            </td>
                <td align="left" colspan="2">
                    <asp:DropDownList id="m_cbo_thang_bd_hop_tac" runat="server" Width="75%" 
                        CssClass="cssDorpdownlist"  >
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
                <td align="left" style="width:10%;">
                    <asp:label id="Label16" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;N&lt;/U&gt;ăm bđ hợp tác" />
		            &nbsp;&nbsp;
                    <asp:DropDownList id="m_cbo_nam_bd_hop_tac" runat="server" Width="40%" 
                        CssClass="cssDorpdownlist"  >
                    </asp:DropDownList>
                    </td>
                <td align="left" style="width:1%;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
                    &nbsp;<asp:label id="Label3" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;T&lt;/U&gt;rạng thái giảng viên" /></td>
                <td align="left" colspan="3">
                    &nbsp; <asp:DropDownList id="m_cbo_trang_thai_g_vien" runat="server" Width="85%" 
                        CssClass="cssDorpdownlist"  />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                <td align="right" style="width:7%;">
                    &nbsp;</td>
                <td align="left" colspan="3" style="margin-left: 40px" rowspan="6">
			        &nbsp;<asp:CheckBoxList ID="m_cbl_loai_hinh_thuc_cong_tac" runat="server">
                        <asp:ListItem>Hướng dẫn</asp:ListItem>
                        <asp:ListItem>Chuyên Môn</asp:ListItem>
                        <asp:ListItem>Viết Học Liệu</asp:ListItem>
                        <asp:ListItem>Duyệt Học Liệu</asp:ListItem>
                        <asp:ListItem>Thẩm định Học Liệu</asp:ListItem>
                        <asp:ListItem>Quay học liệu</asp:ListItem>
                        <asp:ListItem>Hội Đồng Khoa Học</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
                <td align="left" style="width:1%;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
                    &nbsp;<asp:label id="Label5" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;Đ&lt;/U&gt;ơn vị quản lý" /></td>
                <td align="left" colspan="3">
                    &nbsp; <asp:DropDownList ID="m_cbo_don_vi_q_ly" runat="server" 
                        CssClass="cssDorpdownlist" Width="85%" /></td>
                <td align="right" style="width:7%;">
			<asp:label id="lblLoaiHopDongGiaoVien" CssClass="cssManField" runat="server" 
                Text="Hình thức cộng tác:" />
		                    </td>
                <td align="left" style="width:1%;">
                    &nbsp;</td>
            </tr>                   
            <tr>
                <td align="right" style="width:5%;">
                    &nbsp; <asp:label id="Label4" CssClass="cssManField" runat="server" 
                Text="Từ khóa tìm kiếm" /></td>
                <td align="left" colspan="3">
                     &nbsp;<asp:TextBox ID="m_txt_tu_khoa_tim_kiem" runat="server" CssClass="cssTextBox" 
                        Width="85%"></asp:TextBox></td>
                <td align="left" style="width:7%;">
                    &nbsp;</td>
                <td align="left" style="width:1%;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
                    <asp:label id="Label14" CssClass="cssManField" runat="server" 
                Text="PO phụ trách chính" /></td>
                <td align="left" colspan="3">
                     <asp:TextBox ID="m_txt_po_phu_trach_chinh" runat="server" CssClass="cssTextBox" 
                        Width="85%"></asp:TextBox></td>
                <td align="left" style="width:7%;">
                    &nbsp;</td>
                <td align="left" style="width:1%;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
                    <asp:label id="Label15" CssClass="cssManField" runat="server" 
                Text="PO phụ trách phụ 1" /></td>
                <td align="left" colspan="3">
                     <asp:TextBox ID="m_txt_po_phu_trach_phu" runat="server" CssClass="cssTextBox" 
                        Width="85%"></asp:TextBox></td>
                <td align="left" style="width:7%;">
                    &nbsp;</td>
                <td align="left" style="width:1%;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="left" colspan="5">

                &nbsp;&nbsp;&nbsp;

                <asp:label id="lblFullName1" CssClass="cssLabel" runat="server" 
                
                Text="(Từ khóa tìm kiếm: Mã giảng viên, tên giảng viên hoặc email, trường đào tạo,loại hợp đồng, ngày bắt đầu hợp tác,...)" />

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
                <td align="left" style="width:7%;">     
			        &nbsp;</td>     
                    <td align="left" style="width:1%;"></td>
                 <td align="right" style="width:5%;"></td>
                <td align="left" style="width:10%;"></td>     <td align="left" style="width:1%;"></td>
            </tr>
            <tr>
                <td align="right" >
			        &nbsp;</td>
                <td align="left" colspan="2">     
			<asp:button id="m_cmd_loc_du_lieu" accessKey="l" CssClass="cssButton" 
                runat="server" Width="98px" Text="Lọc dữ liệu(l)" 
                        Height="23px" onclick="m_cmd_loc_du_lieu_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:LinkButton id="m_lbt_advanced_search" PostBackUrl="/TRMProject/ChucNang/F205_AdvanceSearchGiangVien.aspx" runat="server" CausesValidation="false" Text= "Tìm kiếm nâng cao"></asp:LinkButton>
			</td>
                <td align="right" >
			        &nbsp;</td>
                <td align="left" >    
			<asp:button id="m_cmd_xuat_excel" accessKey="x" CssClass="cssButton" 
                runat="server" Width="98px" Text="Xuất Excel (x)" Height="22px" 
                        onclick="m_cmd_xuat_excel_Click"  />
			</td>
                             <td align="left" >&nbsp;</td>
                 <td align="right" >
                 <asp:HiddenField id="hdf_id" runat="server"/></td>
                <td align="left" ></td>    
                <td align="left" ></td>
            </tr>
            </table>        
        </td>
    </tr>  
    <tr>
		<td class="cssPageTitleBG" colspan="3">
		    <asp:label id="m_lbl_ket_qua_loc_du_lieu" runat="server" CssClass="cssPageTitle" 
                Text="Kết quả lọc dữ liệu"/>
		</td>
	</tr>	
    <tr>
		<td align="left">
        &nbsp;<asp:button Visible="false"  id="cmd_them_moi" accessKey="c" CssClass="cssButton" 
                runat="server" Width="98px" Text="Tạo mới(c)" 
                onclick="cmd_them_moi_Click" Height="28px"/>
                <br />
                <asp:label id="m_lbl_thong_bao" runat="server" CssClass="cssManField" />
        </td>
        <td >
		    &nbsp;</td>
	</tr>	
	<tr>
		<td align="center" colspan="3" style="height:450px;" valign="top">
		    &nbsp;
   <asp:GridView ID="m_grv_dm_danh_sach_giang_vien" AllowPaging="True" 
                runat="server" AutoGenerateColumns="False" 
                Width="101%" DataKeyNames="ID"
                CellPadding="4" ForeColor="#333333" 
            AllowSorting="True" 
            onpageindexchanging="m_grv_dm_danh_sach_giang_vien_PageIndexChanging" 
            onrowdeleting="m_grv_dm_danh_sach_giang_vien_RowDeleting" PageSize="15" >
                  <AlternatingRowStyle BackColor="White" />
                <Columns>
                 <asp:TemplateField Visible="false" HeaderText="Xóa" >
                    <ItemTemplate> <asp:LinkButton  ID = "lbt_delete"  runat="server"
                     CommandName="Delete" ToolTip="Xóa" OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')">
                     <img src="/TRMProject/Images/Button/deletered.png" alt="Delete" />
                     </asp:LinkButton>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sửa">
                    <ItemTemplate> <asp:HyperLink ToolTip="Sửa" ImageUrl="/TRMProject/Images/Button/edit.png" ID = "lbt_edit" runat="server"
                     NavigateUrl='<%# "/TRMProject/ChucNang/F201_CapNhatThongTinGiangVien.aspx?mode=edit&id="+Eval("ID") %>'></asp:HyperLink>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Hợp đồng giảng viên">
                    <ItemTemplate> <asp:HyperLink ToolTip="Hợp đồng giảng viên" ImageUrl="/TRMProject/Images/Button/detail.png" ID = "lbt_hop_dong_gv" runat="server"
                     NavigateUrl='<%# "/TRMProject/ChucNang/F306_HopDongKhungGiangVien.aspx?id_gv="+Eval("ID") %>'></asp:HyperLink>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><asp:Label ID="m_lbl_stt" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
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
                    <a href='<%# "/TRMProject/ChucNang/F201_CapNhatThongTinGiangVien.aspx?mode=edit&id="+Eval("ID") %>'>
                    <%# Eval("HO_VA_TEN_DEM").ToString().Trim()+" "+Eval("TEN_GIANG_VIEN").ToString() %></a>
                    </ItemTemplate>
                    <ItemStyle Width="200px"/>
                    </asp:TemplateField>
                    <asp:BoundField DataField="NGAY_SINH" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày sinh" />
                    <asp:TemplateField>
                    <HeaderTemplate>Giới tính</HeaderTemplate>
                    <ItemTemplate>
                    <label> <%# mapping_gender(Eval("GIOI_TINH_YN").ToString()) %></label>
                    </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField >
                    <HeaderTemplate>Đơn vị quản lý</HeaderTemplate>
                    <ItemTemplate>
                    <label><%# Eval("DON_VI_QUAN_LY").ToString() %></label>
                    </ItemTemplate>
                    </asp:TemplateField>
                       <asp:TemplateField>
                    <HeaderTemplate>Địa chỉ giảng viên</HeaderTemplate>
                    <ItemTemplate>
                    <label><%# Eval("DIA_CHI").ToString() %></label>
                    </ItemTemplate>
                    <ItemStyle Width="7%" />
                    </asp:TemplateField>
                    <asp:TemplateField >
                    <HeaderTemplate>Tên cơ quan công tác</HeaderTemplate>
                    <ItemTemplate>
                    <label><%# Eval("TEN_CO_QUAN_CONG_TAC").ToString() %></label>
                    </ItemTemplate>
                      <ItemStyle Width="7%" />
                    </asp:TemplateField>
                    <asp:TemplateField >
                    <HeaderTemplate>Điện thoại cơ quan</HeaderTemplate>
                    <ItemTemplate>
                    <label><%# Eval("TEL_OFFICE").ToString() %></label>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField >
                    <HeaderTemplate>Điện thoại di động</HeaderTemplate>
                    <ItemTemplate>
                    <label><%# Eval("MOBILE_PHONE").ToString() %></label>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField >
                    <HeaderTemplate>Điện thoại nhà riêng</HeaderTemplate>
                    <ItemTemplate>
                    <label><%# Eval("TEL_HOME").ToString() %></label>
                    </ItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField >
                    <HeaderTemplate>Số chứng minh</HeaderTemplate>
                    <ItemTemplate>
                    <label><%# Eval("SO_CMTND").ToString() %></label>
                    </ItemTemplate>
                    </asp:TemplateField>
                     <asp:BoundField DataField="NGAY_CAP" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày cấp" />
                      <asp:TemplateField>
                    <HeaderTemplate>Nơi cấp</HeaderTemplate>
                    <ItemTemplate>
                    <label><%# Eval("NOI_CAP").ToString() %></label>
                    </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField>
                    <HeaderTemplate>Email</HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="m_lbl_email" runat="server" Text='<%# Eval("EMAIL").ToString() %>'></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                    <HeaderTemplate>TOPICA Email</HeaderTemplate>
                    <ItemTemplate>
                    <label><%# Eval("EMAIL_TOPICA").ToString() %></label>
                    </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                    <HeaderTemplate>Số tài khoản</HeaderTemplate>
                    <ItemTemplate>
                    <label><%# Eval("SO_TAI_KHOAN").ToString() %></label>
                    </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField>
                    <HeaderTemplate>Tên ngân hàng</HeaderTemplate>
                    <ItemTemplate>
                    <label><%# Eval("TEN_NGAN_HANG").ToString() %></label>
                    </ItemTemplate>
                    </asp:TemplateField> 
                        <asp:TemplateField>
                    <HeaderTemplate>Mã số thuế</HeaderTemplate>
                    <ItemTemplate>
                    <label><%# Eval("MA_SO_THUE").ToString() %></label>
                    </ItemTemplate>
                    </asp:TemplateField> 
                          <asp:TemplateField>
                    <HeaderTemplate>Học vị</HeaderTemplate>
                    <ItemTemplate>
                    <label><%# mapping_hoc_vi(CIPConvert.ToStr(Eval("HOC_VI")))%></label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                       <asp:TemplateField>
                    <HeaderTemplate>Học hàm</HeaderTemplate>
                    <ItemTemplate>
                    <label><%# mapping_hoc_ham(CIPConvert.ToStr(Eval("HOC_HAM")))%></label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                   </asp:TemplateField>
                     <asp:TemplateField>
                    <HeaderTemplate>Chuyên ngành chính</HeaderTemplate>
                    <ItemTemplate>
                    <label><%# Eval("CHUYEN_NGANH_CHINH").ToString() %></label>
                    </ItemTemplate>
                    </asp:TemplateField> 
                    <asp:TemplateField>
                    <HeaderTemplate>Trường đào tạo</HeaderTemplate>
                    <ItemTemplate>
                    <label><%# Eval("TRUONG_DAO_TAO").ToString() %></label>
                    </ItemTemplate>
                    </asp:TemplateField> 
                    <asp:TemplateField>
                    <HeaderTemplate>Chức vụ hiện tại</HeaderTemplate>
                    <ItemTemplate>
                    <label><%# Eval("CHUC_VU_HIEN_TAI").ToString() %></label>
                    </ItemTemplate>
                    </asp:TemplateField> 
                     <asp:TemplateField>
                    <HeaderTemplate>Chức vụ cao nhất</HeaderTemplate>
                    <ItemTemplate>
                    <label><%# Eval("CHUC_VU_CAO_NHAT").ToString() %></label>
                    </ItemTemplate>
                    </asp:TemplateField> 
                    <asp:TemplateField Visible="false">
                    <HeaderTemplate>Ảnh cá nhân</HeaderTemplate>
                    <ItemTemplate>
                    <img alt="anh ca nhan" src='<%# "/TRMProject/Images/PrivateImages/"+ Eval("ANH_CA_NHAN") %>' />
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                    <HeaderTemplate>Trạng thái giảng viên</HeaderTemplate>
                    <ItemTemplate>
                    <label><%# Eval("TRANG_THAI_GIANG_VIEN").ToString() %></label>
                    </ItemTemplate>
                    </asp:TemplateField> 
                     <asp:TemplateField>
                    <HeaderTemplate>PO phụ trách chính</HeaderTemplate>
                    <ItemTemplate>
                    <label><%# Eval("PO_PHU_TRACH_CHINH").ToString() %></label>
                    </ItemTemplate>
                    </asp:TemplateField> 
                    <asp:TemplateField>
                    <HeaderTemplate>PO phụ trách phụ 1</HeaderTemplate>
                    <ItemTemplate>
                    <label><%# Eval("PO_PHU_TRACH_PHU").ToString() %></label>
                    </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField>
                    <HeaderTemplate>PO phụ trách phụ 2</HeaderTemplate>
                    <ItemTemplate>
                    <label><%# Eval("PO_PHU_TRACH_PHU2").ToString() %></label>
                    </ItemTemplate>
                    </asp:TemplateField> 
                     <asp:TemplateField>
                    <HeaderTemplate>PO phụ trách phụ 3</HeaderTemplate>
                    <ItemTemplate>
                    <label><%# Eval("PO_PHU_TRACH_PHU3").ToString() %></label>
                    </ItemTemplate>
                    </asp:TemplateField> 
                     <asp:TemplateField>
                    <HeaderTemplate>PO phụ trách phụ 4</HeaderTemplate>
                    <ItemTemplate>
                    <label><%# Eval("PO_PHU_TRACH_PHU4").ToString() %></label>
                    </ItemTemplate>
                    </asp:TemplateField> 
                       <asp:BoundField DataField="NGAY_BD_HOP_TAC" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày bắt đầu hợp tác" />

                    <asp:TemplateField>
                    <HeaderTemplate>GV hướng dẫn?</HeaderTemplate>
                    <ItemTemplate>
                    <label><%# mapping_hd(Eval("GVHD_YN").ToString())%></label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField>
                    <HeaderTemplate>GV chuyên môn?</HeaderTemplate>
                    <ItemTemplate>
                     <label><%# mapping_cm(Eval("GVCM_YN").ToString())%></label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField>
                    <HeaderTemplate>GV viết học liệu?</HeaderTemplate>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    <ItemTemplate>
                     <label><%# mapping_viet_hl(Eval("GV_VIET_HL_YN").ToString())%></label>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                    <HeaderTemplate>GV duyệt học liệu?</HeaderTemplate>
                    <ItemTemplate>
                   <label><%# mapping_duyet_hl(Eval("GV_DUYET_HL_YN").ToString())%></label>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                    <HeaderTemplate>GV thẩm định học liệu</HeaderTemplate>
                    <ItemTemplate>
                    <label><%# mapping_tham_dinh_hl(Eval("GV_THAM_DINH_HL_YN").ToString())%></label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField>
                    <HeaderTemplate>GV quay học liệu?</HeaderTemplate>
                    <ItemTemplate>
                    <label><%# mapping_quay_hl(Eval("GV_QUAY_HL").ToString())%></label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                     <asp:TemplateField>
                    <HeaderTemplate>GV hội đồng khoa học?</HeaderTemplate>
                    <ItemTemplate>
                    <label><%# mapping_hdkh(Eval("GV_HDKH_YN").ToString())%></label>
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
