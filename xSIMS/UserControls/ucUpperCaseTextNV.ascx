<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucUpperCaseTextNV.ascx.cs" Inherits="UserControls_ucUpperCaseText" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:TextBox ID="txtValue" runat="server" CssClass="textBoxStyle" style="text-transform:uppercase;" MaxLength="50"></asp:TextBox>
    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" 
        runat="server" Enabled="True" TargetControlID="txtValue" FilterType= "Custom, LowercaseLetters, UppercaseLetters" ValidChars=" ,ñ,Ñ,.,-">
    </asp:FilteredTextBoxExtender>

