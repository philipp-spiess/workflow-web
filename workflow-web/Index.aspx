<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Index.aspx.cs" Inherits="workflow_web._Default" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

 <asp:ScriptManager ID="MainScriptManager" runat="server" enablepartialrendering="true" />
 <asp:UpdatePanel ID="UpdateLists" runat="server">

    <ContentTemplate>
    <asp:ListBox ID="ProgrammListe" runat="server" Height="356px"  Width="446px">
    </asp:ListBox>
    <asp:ListBox ID="ArbeitsauftraegeListe" runat="server" Height="355px" 
    Width="388px">
    </asp:ListBox>
    <asp:Button ID="StartProgram" runat="server" onclick="Start_Click" 
        Text="Start Program" Width="258px" />
    <asp:Button ID="Weiterfuehren" runat="server" onclick="Weiterfuehren_Click" 
        Text="Programm Weiterführen" Width="254px" />
     <asp:Button ID="Aktualisieren" runat="server" Text="Aktualisieren" 
        onclick="Aktualisieren_Click" Width="320px" />
    </ContentTemplate>

  </asp:UpdatePanel>

</asp:Content>
