<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucMobile.ascx.cs" Inherits="UserControls_ucMobile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


    <asp:TextBox ID="txtMobileNo" runat="server" Width="110px"></asp:TextBox>
    <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtMobileNo"
    MaskType="Number" Mask="(+63)999-9999999" MessageValidatorTip="true" ErrorTooltipEnabled="true" InputDirection="LeftToRight">
    
    </asp:MaskedEditExtender>

 <%--      <asp:MaskedEditExtender ID="meeCalendar" runat="server" TargetControlID="txtCalendar" Mask="99/99/9999" 
    MessageValidatorTip="true" ErrorTooltipEnabled="true"  MaskType="Date" 
    InputDirection="LeftToRight">
    </asp:MaskedEditExtender>
    <asp:MaskedEditValidator ID="mevCalendar" runat="server" 
    ControlToValidate="txtCalendar" ControlExtender="meeCalendar" 
    Display="Dynamic" 
    InvalidValueMessage="Date not Valid"
    InvalidValueBlurredMessage="*"
    IsValidEmpty="false"></asp:MaskedEditValidator>--%>


