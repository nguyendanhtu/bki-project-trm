<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Welcome.aspx.cs" Inherits="CongTTGV_Welcome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<style type="text/css">
.lbl-header-welcome
{
    text-align:center;
    color:#810C15;
    font-weight:bold;
    font-size:1.5em;
    font-family:arial;
}
.a-not-under-line
{
   text-decoration:none;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<p class="lbl-header-welcome">CỔNG THÔNG TIN GIẢNG VIÊN</p>
<p class="lbl-welcome-content">Chào mừng giảng viên: <a class="a-not-under-line" href="F1201_HoSoGiangVien.aspx"><asp:Label ID="m_lbl_ten_giang_vien" runat="server" Font-Bold="true" ForeColor="#810C15"></asp:Label></a></p>
</asp:Content>

