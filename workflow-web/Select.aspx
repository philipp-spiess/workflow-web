<%@ Page Language="C#" Title="Select following Program" AutoEventWireup="true" CodeBehind="Select.aspx.cs" Inherits="workflow_web.Select" MasterPageFile="~/Site.master" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1>Bitte wähle ein Nachfolgeprogramm</h1>
    <center>
        <asp:ListBox ID="Programme" runat="server" Height="356px"  Width="400px"></asp:ListBox>
    </center> 
    <br />
    <center>
        <asp:Button ID="Go" runat="server" Text="Programm auswählen" 
            onclick="Go_Click" />
    </center>
    <br />
    <center>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </center>
</asp:Content>