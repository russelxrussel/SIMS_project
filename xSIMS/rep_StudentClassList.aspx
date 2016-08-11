<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rep_StudentClassList.aspx.cs" Inherits="rep_StudentClassList" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register src="UserControls/ucCalendar.ascx" tagname="ucCalendar" tagprefix="jrv" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <link href="css/UserControlsStyle.css" rel="stylesheet" type="text/css" />
    <title>Class List Report</title>

<style type="text/css">
    
#dSelection
{
height: 85px;
}

#dSelLeft
{
position: relative;
float: left; 
padding-top: 13px;
height: 70px;
width: 250px;
 
}

#dSelRight
{
position: relative;
float: left; 
padding-top: 10px;
height: 70px;
width: 550px;
}

#rcontent
{

}



</style>

</head>
<body>

    
    <form id="form1" runat="server">

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>

   <asp:LinkButton runat="server" ID="lnkBackHome" Text="Return" 
                onclick="lnkBackHome_Click">Return to Home Page</asp:LinkButton>
   <hr />
        <div id="rcontent">      
       
         <CR:CrystalReportViewer ID="crv" runat="server" 
              AutoDataBind="true" EnableDatabaseLogonPrompt="False" 
              EnableParameterPrompt="False" HasToggleGroupTreeButton="true" 
              HasPrintButton="True" DisplayStatusbar="true" ToolPanelView="GroupTree"
              ReuseParameterValuesOnRefresh="True"  
              PageZoomFactor="75" 
              BestFitPage="False" HasExportButton="true" HasCrystalLogo="False" 
              HasPageNavigationButtons="True" PrintMode="ActiveX" />
   
    </div>
    </form>
</body>
</html>
