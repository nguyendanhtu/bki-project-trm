<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F305_ChonGiangVien.aspx.cs" Inherits="ChucNang_F305_ChonGiangVien" %>
<%@ Register assembly="eWorld.UI" namespace="eWorld.UI" tagprefix="ew" %>
<%@ Import Namespace ="IP.Core.IPCommon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<style type="text/css">
 a 
 {
   text-decoration:none;    
 }
</style>

<script language="javascript">
    function GetRowValue(val) {
        // hardcoded value used to minimize the code.
        // ControlID can instead be passed as query string to the popup window
        window.opener.document.getElementById("m_txt_ten_gv").value = val;
        this.alert(val);
        window.close();
    }
</script>
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
                <td align="right" style="width:5%;">
			<asp:label id="lblFullName" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;T&lt;/U&gt;ên giảng viên" />
                         </td>
                <td align="left" colspan="3">
                <asp:TextBox ID="m_txt_ten_giang_vien" runat="server" CssClass="cssTextBox" 
                        Width="85%"></asp:TextBox>
		            &nbsp;</td>
                <td align="left" style="width:10%;">&nbsp;</td>
                <td align="left" style="width:1%;"></td>
                 <td align="right" style="width:5%;"></td>
                <td align="left" style="width:10%;"></td>
                <td align="left" style="width:1%;"></td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
                    &nbsp;<asp:label id="m_lbl_sex" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;G&lt;/U&gt;iới tính" /></td>
                <td align="left" colspan="3">
                    &nbsp; <asp:RadioButtonList ID="rdl_gender_check" runat="server" 
                       
                        RepeatDirection="Horizontal" Width="167px">
                        <asp:ListItem Selected="True">All</asp:ListItem>
                        <asp:ListItem Value="Male">Nam</asp:ListItem>
                        <asp:ListItem Value="Female">Nữ</asp:ListItem>
                    </asp:RadioButtonList></td>
                <td align="left" style="width:10%;">
                    &nbsp;</td>
                <td align="left" style="width:1%;">
                    &nbsp;</td>
                <td align="right" style="width:5%;">
                    &nbsp;</td>
                <td align="left" style="width:10%;">
                    &nbsp;</td>
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
                <td align="right" style="width:10%;">
                    <asp:label id="Label12" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;N&lt;/U&gt;gày bắt đầu hợp tác" />
		            </td>
                <td align="left" colspan="2">
               <ew:calendarpopup ID="m_dat_ngay_bd_hop_tac" runat="server" 
                        ControlDisplay="TextBoxImage" GoToTodayText="Hôm nay:" 
                        ImageUrl="~/Images/cal.gif" Nullable="True" NullableLabelText="" 
                        ShowGoToToday="True" Width="60%" Text="" Culture="vi-VN" 
                        DisableTextboxEntry="False">
                        <weekdaystyle backcolor="White" font-names="Verdana,Helvetica,Tahoma,Arial" 
                            font-size="XX-Small" forecolor="Black" />
                        <weekendstyle backcolor="LightGray" font-names="Verdana,Helvetica,Tahoma,Arial" 
                            font-size="XX-Small" forecolor="Black" />
                        <offmonthstyle backcolor="AntiqueWhite" 
                            font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small" 
                            forecolor="Gray" />
                        <selecteddatestyle backcolor="Yellow" 
                            font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small" 
                            forecolor="Black" />
                        <monthheaderstyle backcolor="Yellow" 
                            font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small" 
                            forecolor="Black" />
                        <DayHeaderStyle BackColor="Orange" Font-Names="Verdana,Helvetica,Tahoma,Arial" 
                            Font-Size="XX-Small" ForeColor="Black" />
                        <cleardatestyle backcolor="White" font-names="Verdana,Helvetica,Tahoma,Arial" 
                            font-size="XX-Small" forecolor="Black" />
                        <gototodaystyle backcolor="White" font-names="Verdana,Helvetica,Tahoma,Arial" 
                            font-size="XX-Small" forecolor="Black" />
                        <TodayDayStyle BackColor="LightGoldenrodYellow" 
                            Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small" 
                            ForeColor="Black" />
                        <holidaystyle backcolor="White" font-names="Verdana,Helvetica,Tahoma,Arial" 
                            font-size="XX-Small" forecolor="Black" />
                    </ew:calendarpopup>
		            </td>
                <td align="left" style="width:10%;">
                    &nbsp;</td>
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
                <td align="right" style="width:10%;">
                    <asp:label id="Label13" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;T&lt;/U&gt;háng sinh nhật Giảng viên" />
		            </td>
                <td align="left" colspan="2">
                    <asp:DropDownList id="m_cbo_thang_sn_GV" runat="server" Width="65%" 
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
                    &nbsp;</td>
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
                <td align="left" style="width:10%;">
                    &nbsp;</td>
                <td align="left" style="width:1%;">
                    &nbsp;</td>
                <td align="right" style="width:5%;">
                    &nbsp;</td>
                <td align="left" style="width:10%;">
                    &nbsp;</td>
                <td align="left" style="width:1%;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			        &nbsp;</td>
                   <td align="left" style="width:1%;" colspan="4">

                <asp:label id="lblFullName1" CssClass="cssLabel" runat="server" 
                
                Text="(Từ khóa tìm kiếm: Mã giảng viên, tên giảng viên hoặc email, trường đào tạo,loại hợp đồng, ngày bắt đầu hợp tác, ngày sinh,....)" />

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
                        Height="23px" onclick="m_cmd_loc_du_lieu_Click" />
			</td>
                             <td align="left" style="width:1%;">&nbsp;</td>
                <td align="right" >
			        &nbsp;</td>
                <td align="left" >    
			<asp:button id="m_cmd_xuat_excel" accessKey="x" CssClass="cssButton" 
                runat="server" Width="98px" Text="Xuất Excel (x)" Height="22px"  />
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
		    <asp:label id="Label11" runat="server" CssClass="cssPageTitle" 
                Text="Kết quả lọc dữ liệu"/>
		</td>
	</tr>	
    <tr>
		<td align="left">
        &nbsp;<asp:label id="m_lbl_thong_bao" runat="server" CssClass="cssManField" />
        </td>
        <td >
		    &nbsp;</td>
	</tr>	
	<tr>
		<td align="center" colspan="3" style="height:450px;" valign="top">
		    &nbsp;
   <asp:GridView ID="m_grv_dm_danh_sach_giang_vien_to_choose" AllowPaging="True" 
                runat="server" AutoGenerateColumns="False" 
                Width="100%" DataKeyNames="ID"
                CellPadding="4" ForeColor="#333333" 
            AllowSorting="True" 
                
                onselectedindexchanging="m_grv_dm_danh_sach_giang_vien_SelectedIndexChanging" >
                  <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                    <ItemTemplate><asp:LinkButton CommandName="Select" id="lbt_choose_teacher" runat="server">Chọn</asp:LinkButton>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="MA_GIANG_VIEN" HeaderText="Mã giảng viên" 
                        Visible="False">
                        </asp:BoundField>
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
                    <label><a href='<%# "/TRMProject/ChucNang/F201_CapNhatThongTinGiangVien.aspx?mode=edit&id="+Eval("ID") %>'>
                    <%# Eval("TEN_GIANG_VIEN").ToString() %></a></label>
                    </ItemTemplate>
                    <ItemStyle Width="200px"/>
                    </asp:TemplateField>
                       <asp:BoundField DataField="NGAY_SINH" HeaderText="Ngày sinh" DataFormatString="{0:dd/MM/yyyy}">
                    </asp:BoundField>
                    <asp:TemplateField>
                    <HeaderTemplate>Giới tính</HeaderTemplate>
                    <ItemTemplate>
                    <label><%# mapping_gender(Eval("GIOI_TINH_YN").ToString()) %></label>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="EMAIL" HeaderText="Email">
                    </asp:BoundField>
                     <asp:BoundField DataField="TEN_CO_QUAN_CONG_TAC" HeaderText="Tên cơ quan công tác">
                    </asp:BoundField>
                    <asp:TemplateField>
                    <HeaderTemplate>Ảnh cá nhân</HeaderTemplate>
                    <ItemTemplate>
                    <img alt="anh ca nhan" src='<%# "/TRMProject/Images/PrivateImages/"+ Eval("ANH_CA_NHAN") %>' />
                    </ItemTemplate>
                    </asp:TemplateField>
                     <asp:BoundField DataField="HOC_VI" HeaderText="Học vị" />
                     <asp:BoundField DataField="HOC_HAM" HeaderText="Học hàm" />
                     <asp:BoundField DataField="CHUYEN_NGANH_CHINH" HeaderText="Chuyên ngành chính" />
                     <asp:BoundField DataField="TRANG_THAI_GIANG_VIEN" HeaderText="Trạng thái giảng viên" />
                     <asp:BoundField DataField="DON_VI_QUAN_LY" HeaderText="Đơn vị quản lý" />
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

