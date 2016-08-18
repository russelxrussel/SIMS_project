<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rep_app_aes.aspx.cs" Inherits="rep_app_aes" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server"> 
    <div>
    <asp:LinkButton ID="lnkClose" runat="server" 
            OnClientClick="Javascript:window.close(); return false;" 
            >Close</asp:LinkButton> ||| 
            <asp:LinkButton runat="server" ID="lnkAdmissionReport" onclick="lnkAdmissionReport_Click" 
            >Admission-Copy</asp:LinkButton> ||| 
        <asp:LinkButton runat="server" ID="lnkGuidanceReport" 
            onclick="lnkGuidanceReport_Click">Guidance-Copy</asp:LinkButton>
    <hr />
        <CR:CrystalReportViewer ID="crv_aes" runat="server" AutoDataBind="true" 
            EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" 
            HasCrystalLogo="False" PageZoomFactor="75" ToolPanelView="None" />

        <CR:CrystalReportViewer ID="crv_gaes" runat="server" AutoDataBind="true" 
            EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" 
            HasCrystalLogo="False" PageZoomFactor="75" ToolPanelView="None" 
            PrintMode="ActiveX" />

    </div>
    </form>
</body>
</html>
