<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F303_HoSoDetail.aspx.cs" Inherits="ChucNang_F303_HoSoDetail" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Import Namespace="IP.Core.IPCommon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style>
 .cssTextBoxnumber
 {
     text-align:right;
 }
        .style1
        {
            width: 11%;
        }
        .style2
        {
            width: 478px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
    <tr>
		<td class="cssPageTitleBG">
		    <asp:label id="m_lbl_thong_tin_ho_so" runat="server" CssClass="cssPageTitle" 
                Text="Thông tin hồ sơ"/>
		</td>
	</tr>
    <tr>
		<td>
        <table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0"> 
            <tr>
                <td align="right" style="width:7%;">
			<asp:label id="Label1" CssClass="cssManField" runat="server" 
                Text="Tên hồ Sơ: " /></td>
                <td align="left" style="width:10%;"> &nbsp;
			<asp:Label id="m_lbl_ten_ho_so"  runat="server" 
                MaxLength="64" Width="96%" />
                         </td>
                         <td align="left" style="width:1%;"> 
                             &nbsp;</td>
                <td align="right" style="width:7%;">
			       
			<asp:label id="Label5" CssClass="cssManField" runat="server" 
                Text="Ngày cập nhật: " />  
			    </td>
                <td align="left" style="width:10%;"> &nbsp;
			        <asp:label id="m_lbl_dat_ngay_cap_nhat" runat="server" /></td>
                <td align="left" style="width:1%;">&nbsp;</td>
                 <td align="right" style="width:5%;">&nbsp;</td>
                <td align="left" style="width:10%;">&nbsp;</td>
                <td align="left" style="width:1%;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:7%;">       
			<asp:label id="Label4" CssClass="cssManField" runat="server" 
                Text="Loại hồ sơ: " />
			              </td>
                <td align="left" style="width:10%;">
                    &nbsp;<asp:Label ID="m_lbl_loai_ho_so" runat = "server"></asp:Label></td>
                         <td align="left" style="width:1%;"> 
                             &nbsp;</td>
                <td align="right" style="width:5%;">      
			<asp:label id="m_lbl_dv_thanh_toan" CssClass="cssManField" runat="server" 
                Text="Ghi chú: " />  
			    </td>
                <td align="left" colspan="3">	
                    &nbsp;<asp:label id="m_lbl_ghi_chu" runat="server" /></td>
                <td align="left" style="width:10%;"></td>
                <td align="left" style="width:1%;"></td>
            </tr>
            <tr>
                <td align="right" style="width:7%;">  
			<asp:label id="Label2" Enabled="False" CssClass="cssManField" runat="server" 
                Text="Hồ sơ đính kèm: " />
                </td>
                <td align="left" style="width:10%;">
                 &nbsp;
			<asp:Label id="m_lbl_ho_so_dinh_kem" runat="server" />
                         </td>
                     <td align="left" style="width:1%;">
                         &nbsp;</td>
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
                Text="Hồ sơ detail "/>
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
                <td align="right" class="style1">
			       
			        &nbsp;</td>
                <td align="left" class="style2">
                    &nbsp;</td>
                <td align="right" style="width:7%;">
			
			        &nbsp;</td>
                      <td align="left" style="width:1%;">
                          &nbsp;</td>
                 <td align="right" style="width:5%;">
			       
			         &nbsp;</td>
                <td align="left" style="width:10%;">
		            &nbsp;</td>
                <td align="left" style="width:1%;">&nbsp;</td>
            </tr>
        </table>
		</td>
	</tr>
    <tr>
		<td>
        <table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0"> 
                    <tr>
                <td align="right" style="width:7%;">     
			<asp:label id="lblLoaiHoSo" CssClass="cssManField" runat="server" 
                Text="Loại hồ sơ : " />
                </td>
                <td align="left" style="width:10%;">
                <ew:NumericBox ID="m_txt_loai_ho_so" Width="65%" 
                        runat="server" TextAlign= "Right"></ew:NumericBox>
                        </td>
                <td align="right" style="width:5%;">
			        &nbsp;</td>
                <td align="right" style="width:7%;">
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
			       
			<asp:label id="lblHoSoDinhKem" CssClass="cssManField" runat="server" 
                Text="Hồ sơ đính kèm : " />
                </td>
                <td align="left" style="width:10%;">
                <ew:NumericBox ID="m_txt_ho_so_dinh_kem" Width="64%" 
                        runat="server" TextAlign= "Right"></ew:NumericBox>
                        </td>
                <td align="right" style="width:5%;">
			        &nbsp;</td>
                <td align="right" style="width:7%;">
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
			       
			<asp:label id="lblNgayCapNhat" CssClass="cssManField" runat="server" 
                Text="Ngày cập nhật : " />
                </td>
                <td align="left" style="width:10%;">
                    <ew:CalendarPopup ID="m_dat_ngay_cap_nhat" runat="server" 
                        ControlDisplay="TextBoxImage" Culture="vi-VN" DisableTextboxEntry="False" 
                        GoToTodayText="Hôm nay:" ImageUrl="~/Images/cal.gif" Nullable="True" 
                        NullableLabelText="" SelectedDate="" ShowGoToToday="True" Text="" Width="93%">
                        <WeekdayStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" 
                            Font-Size="XX-Small" ForeColor="Black" />
                        <WeekendStyle BackColor="LightGray" Font-Names="Verdana,Helvetica,Tahoma,Arial" 
                            Font-Size="XX-Small" ForeColor="Black" />
                        <OffMonthStyle BackColor="AntiqueWhite" 
                            Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small" 
                            ForeColor="Gray" />
                        <SelectedDateStyle BackColor="Yellow" 
                            Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small" 
                            ForeColor="Black" />
                        <MonthHeaderStyle BackColor="Yellow" 
                            Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small" 
                            ForeColor="Black" />
                        <DayHeaderStyle BackColor="Orange" Font-Names="Verdana,Helvetica,Tahoma,Arial" 
                            Font-Size="XX-Small" ForeColor="Black" />
                        <ClearDateStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" 
                            Font-Size="XX-Small" ForeColor="Black" />
                        <GoToTodayStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" 
                            Font-Size="XX-Small" ForeColor="Black" />
                        <TodayDayStyle BackColor="LightGoldenrodYellow" 
                            Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small" 
                            ForeColor="Black" />
                        <HolidayStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" 
                            Font-Size="XX-Small" ForeColor="Black" />
                    </ew:CalendarPopup>
                        </td>
                <td align="right" style="width:5%;">
			        &nbsp;</td>
                <td align="right" style="width:7%;">
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
			       
			<asp:label id="lblGhiChu" CssClass="cssManField" runat="server" 
                Text="Ghi Chú : " />
                </td>
                <td align="left" style="width:10%;">
                <asp:TextBox ID="m_txt_ghi_chu" runat="server" TextMode="MultiLine" Width="495px"
                    Height="83px"></asp:TextBox>
                        </td>
                <td align="right" style="width:5%;">
			        &nbsp;</td>
                <td align="right" style="width:7%;">
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
			        &nbsp;</td>
                <td align="left" style="width:10%;">
			        <asp:button id="m_cmd_luu_du_lieu" accessKey="s" CssClass="cssButton" 
                runat="server" Width="98px" Text="Tạo phụ lục" 
                        Height="24px" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			       
                     <asp:Button ID="m_cmd_cap_nhat_pl" runat="server" accessKey="s" 
                         CssClass="cssButton" Height="24px" 
                         Text="Cập nhật phụ lục" Width="98px"  />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="m_cmd_thoat0" runat="server" CausesValidation="False" 
                        CssClass="cssButton" Height="25px" Text="Xóa trắng" 
                        Width="98px" />
                        </td>
                <td align="right" style="width:5%;">
                     &nbsp;</td>
                <td align="right" style="width:7%;">
			        &nbsp;</td>
                      <td align="left" style="width:1%;">
                          &nbsp;</td>
                 <td align="right" style="width:5%;">
			         &nbsp;</td>
                <td align="left" style="width:10%;">
                    &nbsp;</td>
                <td align="left" style="width:1%;">&nbsp;</td>
            </tr>
        </table>
		</td>
	</tr>

    <tr>
		<td class="cssPageTitleBG" colspan="2">
		    <asp:label id="Label11" runat="server" CssClass="cssPageTitle" 
                Text="Lọc hồ sơ detail"/>
		</td>
	</tr>
        <tr>
		<td align="left">
                <asp:Button ID="m_cmd_exit" runat="server" accessKey="s" CssClass="cssButton" 
                          Height="24px" Text="Thoát" Width="98px" CausesValidation="false" /><br />
                          <asp:Label ID="m_lbl_thong_bao" CssClass="cssManField" runat="server"></asp:Label>
                <asp:HiddenField ID="hdf_id_gv" runat="server" />
        </td>
        <td >
		    &nbsp;</td>
	</tr>	
	<tr>
		<td align="center" colspan="2" style="height:450px;" valign="top">
		    &nbsp;
   <asp:GridView ID="m_grv_gd_ho_so_detail" AllowPaging="True" 
                runat="server" AutoGenerateColumns="False" 
                Width="100%" DataKeyNames="ID"
                CellPadding="4" ForeColor="#333333" 
            AllowSorting="True">
                  <AlternatingRowStyle BackColor="White" />
                <Columns>
                <asp:TemplateField HeaderText="Xóa">
                    <ItemTemplate> 
                    <asp:LinkButton ToolTip="Xóa" ID = "lbt_delete" runat="server"
                     CommandName="Delete" CausesValidation="false" OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')">
                      <img src="/TRMProject/Images/Button/deletered.png" alt="Delete" />
                     </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="3%" />
                 </asp:TemplateField>
                     <asp:TemplateField HeaderText="Sửa">
                    <ItemTemplate>
                     <asp:LinkButton CausesValidation="false" CommandName="Select" ToolTip="Sửa" ID = "lbt_edit" runat="server">
                    </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="3%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="TEN_HO_SO" HeaderText="Tên hồ sơ ">
                    <ItemStyle Width="15%" HorizontalAlign="Left" />
                    </asp:BoundField>
                     <asp:TemplateField HeaderText="Loại hồ sơ" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%#CIPConvert.ToStr(CIPConvert.ToDecimal(Eval("SO_LUONG_HE_SO")), "0.00")%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                    </asp:TemplateField> 
                     <asp:BoundField HeaderText="Hồ sơ đính kèm">
                     <ItemStyle Width="20%" HorizontalAlign="Center" />
                    </asp:BoundField>
                     <asp:TemplateField HeaderText="Ngày cập nhật">
                       <ItemTemplate><%#CIPConvert.ToStr(CIPConvert.ToDecimal(Eval("DON_GIA_HD")),"#,###0")%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                    </asp:TemplateField> 
                     <asp:TemplateField HeaderText="Ghi chú">
                       <ItemTemplate><%# "Theo " + Eval("TAN_SUAT")%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
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

