<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucGradeText.ascx.cs" Inherits="UserControls_ucGradeText" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:TextBox runat="server" ID="txtGrade" MaxLength="5" CssClass="textBoxStyle_Grades"></asp:TextBox>
<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtGrade" FilterType= "Custom, Numbers" ValidChars=".">
</asp:FilteredTextBoxExtender>
