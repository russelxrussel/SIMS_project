<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rep_FailedApplicant.aspx.cs" Inherits="rep_FailedApplicant" %>
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
     <div id="dmain">
    <div id="rhead">
       <asp:LinkButton ID="lnkClose" runat="server" 
           onclick="lnkClose_Click">Back to Home</asp:LinkButton>
       
    </div>
    <div id="rcontent">
        <CR:CrystalReportViewer ID="crv_Failed" runat="server" AutoDataBind="true" 
            HasCrystalLogo="False" ToolPanelView="None" 
            ToolPanelWidth="200px" Width="1024px" EnableDatabaseLogonPrompt="False" 
            EnableParameterPrompt="False" HasToggleGroupTreeButton="False" 
            HasToggleParameterPanelButton="False" ReuseParameterValuesOnRefresh="True" 
             />
    </div>
    </div>
    </div>
    </form>
</body>
</html>
