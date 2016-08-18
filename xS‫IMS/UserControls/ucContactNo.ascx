<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucContactNo.ascx.cs" Inherits="UserControls_ucContactNo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:TextBox ID="txtContactNo" runat="server" CssClass="textBoxStyle" MaxLength="15"></asp:TextBox>
    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" 
        runat="server" Enabled="True" TargetControlID="txtContactNo" FilterType= "Custom, Numbers" ValidChars="()-+">
        </asp:FilteredTextBoxExtender>
        