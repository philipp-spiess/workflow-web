<%@ Page Title="Workflow Web" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="workflow_web._Default" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

 <asp:ScriptManager ID="MainScriptManager" runat="server" enablepartialrendering="true" />
 <asp:UpdatePanel ID="UpdateLists" runat="server">

    <ContentTemplate>
        <center>
            <asp:ListBox ID="ProgrammListe" runat="server" Height="356px"  Width="400px">
            </asp:ListBox>
            <asp:ListBox ID="ArbeitsauftraegeListe" runat="server" Height="356px" 
            Width="400px">
            </asp:ListBox>
        </center>
        <center>
            <asp:Button ID="StartProgram" runat="server" onclick="Start_Click" 
                Text="Start Program" Width="400px" />
            <asp:Button ID="Weiterfuehren" runat="server" onclick="Weiterfuehren_Click" 
                Text="Programm Weiterführen" Width="400px" />
        </center>
        <br />
        <center>
         <asp:Button ID="Aktualisieren" runat="server" Text="Aktualisieren" 
            onclick="Aktualisieren_Click" Width="320px" />
        </center>
        <br />
        <center style="height: 18px">
            <asp:Label ID="Label1" runat="server" Text="Nothing to see here!"></asp:Label>
        </center>
    </ContentTemplate>

  </asp:UpdatePanel>

</asp:Content>
