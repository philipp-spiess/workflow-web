<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Programm1._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <center>
        <h1>Irgendwas eingeben</h1>
    </center>
    <center>
        <asp:TextBox ID="Text" runat="server"></asp:TextBox>
        <asp:Button ID="Go" runat="server" Text="Go" onclick="Go_Click" />
    </center>
    <center>
        <asp:Label ID="Label1" runat="server" Text="Wie gesagt, einfach eingeben!"></asp:Label>
    </center>
   
</asp:Content>
