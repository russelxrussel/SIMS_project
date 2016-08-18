<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rep_reservationList.aspx.cs" Inherits="rep_reservationList" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reservation Report</title>

<style type="text/css">
#dSelection
{
position: relative;
float: left;
left: 50px;
}

#divRepType
{
position: relative;
float: left;  

}
</style>

</head>
<body>
    <form id="form1" runat="server">
    <div>


        <br />

       <div id="rcontent">      

         <CR:CrystalReportViewer ID="crv" runat="server" 
              AutoDataBind="true" EnableDatabaseLogonPrompt="False" 
              EnableParameterPrompt="False" HasToggleGroupTreeButton="true" 
              PrintMode="ActiveX" ToolPanelView="GroupTree"
              ReuseParameterValuesOnRefresh="True"  
              PageZoomFactor="75" 
              BestFitPage="true" HasExportButton="true" HasPrintButton ="False" HasCrystalLogo="False" 
              HasPageNavigationButtons="True" />
   
    </div>
    </div>
    </form>
</body>
</html>
