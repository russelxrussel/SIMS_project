<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rep_PassedApplicant.aspx.cs" Inherits="rep_PassedApplicant" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/ControlsStyle.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="dmain">
    <div id="rhead">
       <asp:LinkButton ID="lnkClose" runat="server" 
           onclick="lnkClose_Click">Back to Home</asp:LinkButton>
       
    </div>
    <br />
    <div id="dSelection">
    Select: <asp:DropDownList ID="ddGradeLevel" runat="server" AutoPostBack="True" 
            onselectedindexchanged="ddGradeLevel_SelectedIndexChanged" CssClass="dropDownStyle"></asp:DropDownList>
    </div>
    <div id="rcontent">
        <CR:CrystalReportViewer ID="crv_Passed" runat="server" AutoDataBind="true" 
            HasCrystalLogo="False" ToolPanelView="None" 
            ToolPanelWidth="200px" Width="1024px" EnableDatabaseLogonPrompt="False" 
            EnableParameterPrompt="False" HasToggleGroupTreeButton="False" 
            HasToggleParameterPanelButton="False" ReuseParameterValuesOnRefresh="True" 
             />
    </div>
    </div>
    </form>
</body>
</html>
