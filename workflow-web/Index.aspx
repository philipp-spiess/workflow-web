<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Index.aspx.cs" Inherits="workflow_web._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ListBox ID="ProgrammListe" runat="server" Height="356px"  Width="326px">
    </asp:ListBox>
    <asp:ListBox ID="ArbeitsauftraegeListe" runat="server" Height="355px" Width="337px">
    </asp:ListBox>
    <asp:Button ID="StartProgram" runat="server" onclick="Start_Click" 
        Text="Start Program" Width="252px" />
    <asp:Button ID="Weiterfuehren" runat="server" onclick="Weiterfuehren_Click" 
        Text="Programm Weiterführen" Width="237px" />
</asp:Content>
