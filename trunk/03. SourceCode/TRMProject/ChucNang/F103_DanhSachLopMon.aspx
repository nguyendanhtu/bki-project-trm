<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F103_DanhSachLopMon.aspx.cs" Inherits="ChuNang_F103_DanhSachLopMon" %>
<%@ Import Namespace="WebDS.CDBNames" %>
<%@ Import Namespace="IP.Core.IPCommon"%>
<%@ Register assembly="eWorld.UI" namespace="eWorld.UI" tagprefix="ew" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
   <script language="javascript" type="text/javascript">
       function confirm_delete() {
           if (confirm("Are you sure you want to delete the contact?") == true)
               return true;
           else
               return false;
       }

       function OpenSiteFromUrl(siteUrl) {
           var name = 'ProfileForm';
           var appearence = 'dependent=yes,menubar=no,resizable=yes,' +
                        'status=no,toolbar=no,titlebar=no, scrollbars=1' +
                        'left=100,top=50,width=800px,height=600px';
           var openWindow = window.open(siteUrl, name, appearence);
           openWindow.focus();
       }
    </script>
    <table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
	<tr>
		<td class="cssPageTitleBG">
		    <asp:label id="lblUser" runat="server" CssClass="cssPageTitle" 
                Text="Danh sách lớp môn"/>
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
			<asp:label id="lblFullName" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;T&lt;/U&gt;ên môn học" />
                         </td>
                <td align="left" style="width:10%;">
		    <asp:DropDownList id="m_cbo_dm_mon_hoc" runat="server" Width="96%" 
                        CssClass="cssDorpdownlist"  />
                         </td>
                         <td align="left" style="width:1%;"> 
                             &nbsp;</td>
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
			<asp:label id="lblFullName4" CssClass="cssManField" runat="server" 
                Text="Có Online?" />
                </td>
                <td align="left" style="width:10%;">
			        <asp:RadioButtonList ID="m_rbt_online_yn" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="ALL">Tất cả</asp:ListItem>
                        <asp:ListItem Value="Y">Có</asp:ListItem>
                        <asp:ListItem Value="N">Không</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                     <td align="left" style="width:1%;">
                         &nbsp;</td>
                <td align="right" style="width:5%;">
			<asp:label id="lblFullName5" CssClass="cssManField" runat="server" 
                Text="Có Offline?" />
		                    </td>
                <td align="left" style="width:10%;">
			
			        <asp:RadioButtonList ID="m_rbt_offline_yn" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="ALL">Tất cả</asp:ListItem>
                        <asp:ListItem Value="Y">Có</asp:ListItem>
                        <asp:ListItem Value="N">Không</asp:ListItem>
                    </asp:RadioButtonList>
		                    </td>
                      <td align="left" style="width:1%;">
                          &nbsp;</td>
                 <td align="right" style="width:5%;">
			<asp:label id="lblFullName6" CssClass="cssManField" runat="server" 
                Text="Có bài tập giữa kỳ?" />
		                    </td>
                <td align="left" style="width:10%;">
			        <asp:RadioButtonList ID="m_rbt_bt_gky_yn" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="ALL">Tất cả</asp:ListItem>
                        <asp:ListItem Value="Y">Có</asp:ListItem>
                        <asp:ListItem Value="N">Không</asp:ListItem>
                    </asp:RadioButtonList>
		                    </td>
                <td align="left" style="width:1%;"></td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			<asp:label id="Label19" CssClass="cssManField" runat="server" 
                Text="Ngày bắt đầu:" Font-Bold="True" Font-Underline="True" />
		                    </td>
                <td align="left" style="width:10%;">
			
			        &nbsp;</td>
                     <td align="left" style="width:1%;">
                         &nbsp;</td>
                <td align="right" style="width:5%;">
			<asp:label id="Label17" CssClass="cssManField" runat="server" 
                Text="Ngày kết thúc:" />
		                    </td>
                <td align="left" style="width:10%;">
			
			        &nbsp;</td>
                     <td align="left" style="width:1%;">
                         &nbsp;</td>
                 <td align="right" style="width:5%;">
			<asp:label id="Label6" CssClass="cssManField" runat="server" 
                Text="Ngày thi:" />
		                    </td>
                <td align="left" style="width:10%;">
			
			        &nbsp;</td>            
                         <td align="left" style="width:1%;">
                             &nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			<asp:label id="Label2" CssClass="cssManField" runat="server" 
                Text="Từ ngày" />
		                    </td>
                <td align="left" style="width:10%;">
						        <ew:CalendarPopup ID="m_dat_ngay_bat_dau_tu" runat="server" 
                        ControlDisplay="TextBoxImage" GoToTodayText="Hôm nay:" 
                        ImageUrl="~/Images/cal.gif" Nullable="True" NullableLabelText="" 
                        ShowGoToToday="True" Width="80%" SelectedDate="" Text="" Culture="vi-VN" 
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
                    </ew:CalendarPopup>
                </td>
                     <td align="left" style="width:1%;">
                         <asp:CompareValidator ID="CompareValidator1" runat="server" 
                             ControlToCompare="m_dat_ngay_bat_dau_tu" 
                             ControlToValidate="m_dat_ngay_bat_dau_den" 
                             ErrorMessage="Ngày bắt đầu Đến ngày phải lớn hơn từ ngày" 
                             Operator="GreaterThan" SetFocusOnError="True" Type="Date">*</asp:CompareValidator>
                </td>
                <td align="right" style="width:5%;">
			<asp:label id="Label20" CssClass="cssManField" runat="server" 
                Text="Từ ngày" />
		                    </td>
                <td align="left" style="width:10%;">
			    			        <ew:CalendarPopup ID="m_dat_ngay_ket_thuc_tu" runat="server" 
                        ControlDisplay="TextBoxImage" GoToTodayText="Hôm nay:" 
                        ImageUrl="~/Images/cal.gif" Nullable="True" NullableLabelText="" 
                        ShowGoToToday="True" Width="80%" SelectedDate="" Text="" Culture="vi-VN" 
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
                    </ew:CalendarPopup>
		                    </td>
                     <td align="left" style="width:1%;">
                         <asp:CompareValidator ID="CompareValidator2" runat="server" 
                             ControlToCompare="m_dat_ngay_ket_thuc_tu" 
                             ControlToValidate="m_dat_ngay_ket_thuc_den" 
                             ErrorMessage="Ngày kết thúc Đến ngày phải lớn hơn từ ngày" 
                             Operator="GreaterThan" SetFocusOnError="True" Type="Date">*</asp:CompareValidator>
                </td>
                 <td align="right" style="width:5%;">
			<asp:label id="Label21" CssClass="cssManField" runat="server" 
                Text="Từ ngày" />
		                    </td>
                <td align="left" style="width:10%;">
						        <ew:CalendarPopup ID="m_dat_ngay_thi_tu" runat="server" 
                        ControlDisplay="TextBoxImage" GoToTodayText="Hôm nay:" 
                        ImageUrl="~/Images/cal.gif" Nullable="True" NullableLabelText="" 
                        ShowGoToToday="True" Width="80%" SelectedDate="" Text="" Culture="vi-VN" 
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
                    </ew:CalendarPopup>
		                    </td>            
                         <td align="left" style="width:1%;">
                             <asp:CompareValidator ID="CompareValidator3" runat="server" 
                                 ControlToCompare="m_dat_ngay_thi_tu" ControlToValidate="m_dat_ngay_thi_den" 
                                 ErrorMessage="Ngày thi Đến ngày phải nhỏ hơn từ ngày" Operator="GreaterThan" 
                                 SetFocusOnError="True">*</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			<asp:label id="Label16" CssClass="cssManField" runat="server" 
                Text="Đến ngày" />
		                    </td>
                <td align="left" style="width:10%;">
                			        <ew:CalendarPopup ID="m_dat_ngay_bat_dau_den" runat="server" 
                        ControlDisplay="TextBoxImage" GoToTodayText="Hôm nay:" 
                        ImageUrl="~/Images/cal.gif" Nullable="True" NullableLabelText="" 
                        ShowGoToToday="True" Width="80%" SelectedDate="" Text="" Culture="vi-VN" 
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
                    </ew:CalendarPopup>
		                    </td>
                                 <td align="left" style="width:1%;"></td>
                <td align="right" style="width:5%;">
			<asp:label id="Label18" CssClass="cssManField" runat="server" 
                Text="Đến ngày" />
		                    </td>
                <td align="left" style="width:10%;">
                			        <ew:CalendarPopup ID="m_dat_ngay_ket_thuc_den" runat="server" 
                        ControlDisplay="TextBoxImage" GoToTodayText="Hôm nay:" 
                        ImageUrl="~/Images/cal.gif" Nullable="True" NullableLabelText="" 
                        ShowGoToToday="True" Width="80%" SelectedDate="" Text="" Culture="vi-VN" 
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
                    </ew:CalendarPopup>
                            </td>
                                 <td align="left" style="width:1%;"></td>
                 <td align="right" style="width:5%;">
			<asp:label id="Label8" CssClass="cssManField" runat="server" 
                Text="Đến ngày" />
		                    </td>
                <td align="left" style="width:10%;">
                			        <ew:CalendarPopup ID="m_dat_ngay_thi_den" runat="server" 
                        ControlDisplay="TextBoxImage" GoToTodayText="Hôm nay:" 
                        ImageUrl="~/Images/cal.gif" Nullable="True" NullableLabelText="" 
                        ShowGoToToday="True" Width="80%" SelectedDate="" Text="" Culture="vi-VN" 
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
                    </ew:CalendarPopup>
		        </td>     <td align="left" style="width:1%;"></td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			<asp:label id="Label4" CssClass="cssManField" runat="server" 
                Text="Từ khóa tìm kiếm" />
		                    </td>
                <td align="left" style="width:10%;">     

		            <asp:TextBox ID="m_txt_tu_khoa_tim_kiem" runat="server" CssClass="cssTextBox" 
                        Width="244%"></asp:TextBox>

			    </td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			        &nbsp;</td>
                   <td align="left" style="width:1%;" colspan="4">

                <asp:label id="lblFullName1" CssClass="cssLabel" runat="server" 
                
                
                           Text="(Từ khóa tìm kiếm: Mã lớp môn hoặc Tên môn học hoặc PO phụ trách hoặc chương trình phụ trách)" />

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
	    <td>
			<asp:button id="m_cmd_tao_moi0" accessKey="m" CssClass="cssButton" 
                runat="server" Width="98px" Text="Thêm lớp môn" Height="24px" 
                onclick="m_cmd_tao_moi" />
		                    </td>
	</tr>
    <tr>
		<td class="cssPageTitleBG">
		    <asp:label id="m_lbl_ket_qua_loc" runat="server" CssClass="cssPageTitle" 
                Text="Kết quả lọc dữ liệu"/>
		</td>
	</tr>	
    <tr>
		<td align="right">
		    <asp:GridView ID="m_grv" runat="server" AutoGenerateColumns="False" 
                Width="100%" DataKeyNames="ID" 
                CellPadding="4" ForeColor="#333333" CssClass="cssGrid" 
                onrowdatabound="m_grv_RowDataBound" AllowPaging="True" AllowSorting="True" 
                onpageindexchanging="m_grv_PageIndexChanging" PageSize="20" 
                EnableModelValidation="True" onrowdeleting="m_grv_RowDeleting">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center"><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="MA_LOP_MON" ItemStyle-HorizontalAlign="Center" 
                        HeaderText="Mã lớp môn" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Môn học">
                        <ItemTemplate>
                            <asp:Label ID="m_lbl_mon_hoc" runat="server" 
                                Text="<%#get_mapping_ten_mon_hoc((decimal)Eval(GD_LOP_MON.ID_MON_HOC))%>"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ngày bắt đầu">
                        <ItemTemplate>
                            <asp:Label ID="m_lbl_ngay_bat_dau" runat="server" 
                                Text='<%# Eval(GD_LOP_MON.NGAY_BAT_DAU,"{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ngày kết thúc">
                        <ItemTemplate>
                            <asp:Label ID="m_lbl_ngay_ket_thuc" runat="server" Text='<%# Eval(GD_LOP_MON.NGAY_KET_THUC,"{0:dd/MM/yyyy}") %>' 
                                ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ngày thi">
                        <ItemTemplate>
                            <asp:Label ID="m_lbl_ngay_thi" runat="server" 
                                Text='<%# Eval(GD_LOP_MON.NGAY_THI,"{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="PO_PHU_TRACH" HeaderText="PO phụ trách">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle></asp:BoundField>
                    <asp:BoundField DataField="CHUONG_TRINH_PHU_TRACH" ItemStyle-HorizontalAlign="Center" 
                        HeaderText="CT phụ trách" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Có Online?">
                        <ItemTemplate>
                            <asp:Label ID="m_lbl_lop_online_yn" runat="server" 
                             Text="<%#get_mapping_yn((string)Eval(GD_LOP_MON.ONLINES_YN))%>"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Có Offline?">
                        <ItemTemplate>
                            <asp:Label ID="m_lbl_lop_offline_yn" runat="server"
                            Text="<%#get_mapping_yn((string)Eval(GD_LOP_MON.OFFLINE_YN))%>"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Có Bài tập giữ kỳ kỳ?">
                        <ItemTemplate>
                            <asp:Label ID="m_lbl_bt_giua_ky_yn" runat="server"
                            Text="<%#get_mapping_yn((string)Eval(GD_LOP_MON.BAI_TAP_GKY_YN))%>"></asp:Label>
                        </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="SO_LUONG_HV" HeaderText="SL học viên" >
                    <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SO_LUONG_ONLINES" HeaderText="Số tiết Online">
                                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SO_LUONG_OFFLINE" HeaderText="Số tiết Offline">
                                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Xóa">
                    <ItemTemplate> <asp:LinkButton ToolTip="Xóa" ID = "lbt_delete" runat="server"
                     CommandName="Delete" OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')">
                      <img src="/TRMProject/Images/Button/deletered.png" alt="Delete" />
                     </asp:LinkButton>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HyperLink ID="m_lnk_sua" runat="server" Target="_blank"
                                
                                NavigateUrl='<%# "~/ChucNang/F102_CapNhatThongTinLopMon.aspx?mode=update&id_lop_mon="+Eval(GD_LOP_MON.ID) %>' 
                                ImageUrl="~/Images/Button/edit.png">Sửa</asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HyperLink ID="m_lnk_lop_mon_detail" runat="server" Target="_blank" 
                                ToolTip="Chi tiết lớp môn"  
                                NavigateUrl='<%# "~/ChucNang/F104_ChiTietLopMon.aspx?id_lop_mon="+Eval(GD_LOP_MON.ID) %>' 
                                ImageUrl="~/Images/Button/detail.png">Chi tiết</asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#810c15" Font-Bold="True" ForeColor="White" />
                <PagerSettings Position="TopAndBottom" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle CssClass="cssSelectedRow" BackColor="#C5BBAF" 
                    Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
            </asp:GridView>
        </td>
	</tr>	
    <tr>
		<td align="center" style="height:450px;" valign="top">
		    &nbsp;</td>
	</tr>	

</table>
</asp:Content>
