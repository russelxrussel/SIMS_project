<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rep_EnrollmentForm.aspx.cs" Inherits="rep_EnrollmentForm" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
     <div id="rcontent">      

         <CR:CrystalReportViewer ID="crv" runat="server" 
              AutoDataBind="true" EnableDatabaseLogonPrompt="False" 
              EnableParameterPrompt="False" HasToggleGroupTreeButton="true" 
              PrintMode="ActiveX" ToolPanelView="GroupTree" EnableDrillDown="False" 
              HasCrystalLogo="False" HasDrilldownTabs="False" HasDrillUpButton="False"
              ReuseParameterValuesOnRefresh="True" HasToggleParameterPanelButton="False" 
              Enabled="False" PageZoomFactor="100" HasZoomFactorList="False" 
              BestFitPage="False" HasExportButton="true" HasGotoPageButton="False" 
              HasPageNavigationButtons="True" HasSearchButton="False"/>
   
    </div>

    </div>
    </form>
</body>
</html>
