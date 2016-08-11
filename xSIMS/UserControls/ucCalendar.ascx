<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucCalendar.ascx.cs" Inherits="UserControls_ucCalendar" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:TextBox ID="txtCalendar" runat="server" CssClass="calendarTextBox"></asp:TextBox>
    <asp:MaskedEditExtender ID="meeCalendar" runat="server" TargetControlID="txtCalendar" Mask="99/99/9999" 
    MessageValidatorTip="true" ErrorTooltipEnabled="true"  MaskType="Date" 
    InputDirection="LeftToRight">
    </asp:MaskedEditExtender>
    <asp:MaskedEditValidator ID="mevCalendar" runat="server" 
    ControlToValidate="txtCalendar" ControlExtender="meeCalendar" 
    Display="Dynamic" 
    InvalidValueMessage="Date not Valid"
    InvalidValueBlurredMessage="*"
    IsValidEmpty="false"></asp:MaskedEditValidator>
<asp:RequiredFieldValidator ID="rfvCalendar" runat="server" ErrorMessage="Date Requrired" Text="*" ControlToValidate="txtCalendar" Display="Dynamic"></asp:RequiredFieldValidator>
    <asp:CalendarExtender ID="ceDOA" runat="server" TargetControlID="txtCalendar">
    </asp:CalendarExtender>