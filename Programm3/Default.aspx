<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Programm3._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <center>
        <h1>Ich drehe den String um</h1>
    </center>
    <center>
        "<asp:Label ID="Daten" runat="server" Text="ERR"></asp:Label>"<br />
        <asp:Button ID="Go" runat="server" Text="Go" onclick="Go_Click" />
    </center>
</asp:Content>
