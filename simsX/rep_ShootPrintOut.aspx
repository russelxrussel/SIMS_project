﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rep_ShootPrintOut.aspx.cs" Inherits="rep_ShootPrintOut" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SIMS</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <div id="Selection">
    <asp:RadioButton runat="server" ID="rbMOT" Text="Mode of Transpo" GroupName="rad1" Checked="true" /><br />
    <asp:RadioButton runat="server" ID="rbFrat" Text="Fraternity/Sorority Waiver" GroupName="rad1" /> <br />
    <asp:RadioButton runat="server" ID="rbYA" Text="Yearly Agreement Form" GroupName="rad1" /> <br />
    <asp:Button runat="server" ID="btnSubmit" Text="Load Selection" 
            onclick="btnSubmit_Click" />
    </div>

      <br />
       <div id="rcontent">      

         <CR:CrystalReportViewer ID="crv" runat="server" 
              AutoDataBind="true" EnableDatabaseLogonPrompt="False" 
              EnableParameterPrompt="False" HasToggleGroupTreeButton="true" 
              PrintMode="ActiveX" ToolPanelView="GroupTree"
              ReuseParameterValuesOnRefresh="True"  
              PageZoomFactor="75" 
              BestFitPage="False" HasExportButton="true" 
              HasPageNavigationButtons="True" />
   
    </div>
    </div>
    </form>
</body>
</html>
