<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F102_CapNhatThongTinLopMon.aspx.cs" Inherits="ChucNang_F102_CapNhatThongTinLopMon" %>

<%@ Register assembly="eWorld.UI" namespace="eWorld.UI" tagprefix="ew" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
	<tr>
		<td class="cssPageTitleBG">
		    <asp:label id="lblUser" runat="server" CssClass="cssPageTitle" 
                Text="Thông tin lớp môn"/>
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
			<asp:label id="lblFullName5" CssClass="cssManField" runat="server" 
                Text="Mã lớp môn" />
                         </td>
                <td align="left" style="width:10%;">
			<asp:textbox id="m_txt_ma_lop_mon" CssClass="cssTextBox"  runat="server" 
                MaxLength="500" Width="96%" />
                         </td>
                         <td align="left" style="width:1%;"> 
                             <asp:RequiredFieldValidator ID="m_rfv_ma_lop_mon" runat="server" 
                        ControlToValidate="m_txt_ma_lop_mon" ErrorMessage="Bạn phải nhập Mã lớp môn">*</asp:RequiredFieldValidator></td>
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
			<asp:label id="lblFullName" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;T&lt;/U&gt;ên môn học" />
                </td>
                <td align="left" style="width:10%;">
		    <asp:DropDownList id="m_cbo_dm_mon_hoc" runat="server" Width="96%" 
                        CssClass="cssDorpdownlist"  />
                </td>
                     <td align="left" style="width:1%;">
                         <asp:RequiredFieldValidator ID="m_rfv_offline0" runat="server" 
                             ErrorMessage="Bạn phải chọn Tên môn học" 
                             ControlToValidate="m_cbo_dm_mon_hoc">*</asp:RequiredFieldValidator>
                </td>
                <td align="right" style="width:5%;">
			<asp:label id="lblFullName14" CssClass="cssManField" runat="server" 
                Text="Có Offline?" />
		                    </td>
                <td align="left" style="width:10%;">
			
			        <asp:RadioButtonList ID="m_rbt_offline_yn" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="Y">Có</asp:ListItem>
                        <asp:ListItem Value="N">Không</asp:ListItem>
                    </asp:RadioButtonList>
		                    </td>
                      <td align="left" style="width:1%;">
                         <asp:RequiredFieldValidator ID="m_rfv_offline1" runat="server" 
                             
                             ErrorMessage="Bạn phải chọn Có Offline? Có hoặc Không" 
                             ControlToValidate="m_rbt_offline_yn">*</asp:RequiredFieldValidator>
                </td>
                 <td align="right" style="width:5%;">
                     &nbsp;</td>
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
                        <asp:ListItem Value="Y">Có</asp:ListItem>
                        <asp:ListItem Value="N">Không</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                     <td align="left" style="width:1%;">
                         <asp:RequiredFieldValidator ID="m_rfv_offline" runat="server" 
                             
                             ErrorMessage="Bạn phải chọn Có Online? Có hoặc Không" 
                             ControlToValidate="m_rbt_online_yn">*</asp:RequiredFieldValidator>
                </td>
                <td align="right" style="width:5%;">
			<asp:label id="lblFullName15" CssClass="cssManField" runat="server" 
                Text="Có bài tập giữa kỳ?" />
		                    </td>
                <td align="left" style="width:10%;">
			        <asp:RadioButtonList ID="m_rbt_bt_gky_yn" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="Y">Có</asp:ListItem>
                        <asp:ListItem Value="N">Không</asp:ListItem>
                    </asp:RadioButtonList>
		                    </td>
                     <td align="left" style="width:1%;">
                         <asp:RequiredFieldValidator ID="m_rfv_offline2" runat="server" 
                             
                             ErrorMessage="Bạn phải chọn Có bài tập giữa kỳ? Có hoặc Không" 
                             ControlToValidate="m_rbt_online_yn">*</asp:RequiredFieldValidator>
                </td>
                 <td align="right" style="width:5%;">
			         &nbsp;</td>
                <td align="left" style="width:10%;">
                    &nbsp;</td>            
                         <td align="left" style="width:1%;"></td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			<asp:label id="lblFullName6" CssClass="cssManField" runat="server" 
                Text="Ngày bắt đầu" />
		                    </td>
                <td align="left" style="width:10%;">
                			        <ew:CalendarPopup ID="m_dat_ngay_bat_dau" runat="server" 
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
			<asp:label id="lblFullName8" CssClass="cssManField" runat="server" 
                Text="Ngày kết thúc" />
		                    </td>
                <td align="left" style="width:10%;">
                			        <ew:CalendarPopup ID="m_dat_ngay_ket_thuc" runat="server" 
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
			         &nbsp;</td>
                <td align="left" style="width:10%;">
			        &nbsp;</td>     <td align="left" style="width:1%;"></td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			<asp:label id="lblFullName9" CssClass="cssManField" runat="server" 
                Text="Ngày thi" /></td>
                <td align="left" style="width:10%;"> 
                			        <ew:CalendarPopup ID="m_dat_ngay_thi" runat="server" 
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
			        &nbsp;</td>
                <td align="left" style="width:10%;">     
			        &nbsp;</td>
                 <td align="left" style="width:1%;"></td>
                 <td align="right" style="width:5%;"></td>
                <td align="left" style="width:10%;"></td>     
                <td align="left" style="width:1%;"></td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			<asp:label id="lblFullName7" CssClass="cssManField" runat="server" 
                Text="PO phụ trách" />
                </td>
                <td align="left" style="width:10%;">     
			<asp:textbox id="m_txt_po_phu_trach" CssClass="cssTextBox"  runat="server" 
                MaxLength="500" Width="96%" />
			    </td>
                 <td align="left" style="width:1%;"></td>
                <td align="right" style="width:5%;">
			<asp:label id="lblFullName10" CssClass="cssManField" runat="server" 
                Text="C/trình phụ trách" />
		                    </td>
                <td align="left" style="width:10%;">    
			<asp:textbox id="m_txt_chuong_trinh_phu_trach" CssClass="cssTextBox"  runat="server" 
                MaxLength="500" Width="96%" /></td>
                 <td align="left" style="width:1%;"></td>
                <td align="right" style="width:5%;"></td>
                <td align="left" style="width:10%;">    </td> 
                   <td align="left" style="width:1%;"></td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			<asp:label id="lblFullName11" CssClass="cssManField" runat="server" 
                Text="Số lượng học viên" />
                 </td>
                <td align="left" style="width:10%;">          
			        <ew:NumericBox ID="m_txt_slhv" runat="server" Width="96%" TextAlign="Right"></ew:NumericBox>
                </td>
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
			<asp:label id="lblFullName12" CssClass="cssManField" runat="server" 
                Text="Số tiết Online" />
			        </td>
                <td align="left">     
			        <ew:NumericBox ID="m_txt_slhv_online" runat="server" Width="96%" 
                        TextAlign="Right"></ew:NumericBox>
			</td>
                             <td align="left" style="width:1%;">&nbsp;</td>
                <td align="right" >
			<asp:label id="lblFullName13" CssClass="cssManField" runat="server" 
                Text="Số tiết Offline" />
			        </td>
                <td align="left" >    
			        <ew:NumericBox ID="m_txt_slhv_offline" runat="server" Width="96%" 
                        TextAlign="Right"></ew:NumericBox>
			</td>
                             <td align="left" >&nbsp;</td>
                 <td align="right" ></td>
                <td align="left" ></td>    
                <td align="left" ></td>
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
            <tr>
                <td align="right" style="width:5%;">
			        &nbsp;</td>
                <td align="left" style="width:1%;">
			        <asp:button id="m_cmd_luu_du_lieu" accessKey="s" CssClass="cssButton" 
                runat="server" Width="98px" Text="Lưu dữ liệu" onclick="m_cmd_luu_du_lieu_Click" 
                        Height="24px" />
                </td>
			   <td align="left" style="width:1%;"></td>
                 <td align="left" style="width:5%;">
                     &nbsp;</td>
                <td align="left" style="width:10%;">
                 <asp:button id="m_cmd_thoat" CssClass="cssButton" 
                runat="server" Width="98px" Text="Thoát" onclick="m_cmd_thoat_Click" 
                        Height="25px"  />
                 </td>     
                <td align="left" style="width:1%;"></td>
            </tr>
        </table>
		</td>
	</tr>
	<tr>
    <td></td></tr>
</table>
</asp:Content>
