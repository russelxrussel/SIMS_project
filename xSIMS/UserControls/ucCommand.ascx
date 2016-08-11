<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucCommand.ascx.cs" Inherits="UserControls_ucCommand" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:UpdatePanel ID="upCommand" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
<ContentTemplate>
    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
    <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
        CompletionInterval="500" Enabled="True" FirstRowSelected="True" 
        MinimumPrefixLength="1" ServiceMethod="GetCompleteList" 
        TargetControlID="txtSearch" UseContextKey="true">
    </asp:AutoCompleteExtender>
<asp:Button ID="btnNew" runat="server" Text="NEW" onclick="btnNew_Click" />
<asp:Button ID="btnEDIT" runat="server" Text="EDIT" onclick="btnEDIT_Click" />
</ContentTemplate> 
</asp:UpdatePanel>