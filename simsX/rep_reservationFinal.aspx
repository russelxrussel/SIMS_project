<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rep_reservationFinal.aspx.cs" Inherits="rep_reservationFinal" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register src="UserControls/ucCalendar.ascx" tagname="ucCalendar" tagprefix="jrv" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <link href="css/UserControlsStyle.css" rel="stylesheet" type="text/css" />
    <title>Enrollment Report</title>

<style type="text/css">
    
#dSelection
{
height: 55px;
}

#dSelLeft
{
position: relative;
float: left; 
padding-top: 13px;
height: 50px;
width: 200px;
 
}

#dSelRight
{
position: relative;
float: left; 
padding-top: 10px;
height: 50px;
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

    <div id="dSelection">
    
        <div id="dSelLeft">
        <asp:RadioButton runat="server" ID="rbList" Text="Detail Report" GroupName="rad1" Checked="true" /><br />
        <asp:RadioButton runat="server" ID="rbSummary" Text="Summary Report" GroupName="rad1" /> <br />
        </div>
        
        <div id="dSelRight">
        <table>
        <tr>
        <td>Date From:</td><td><asp:TextBox ID="txtDateStart" runat="server" CssClass="calendarTextBox"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDateStart" Enabled="true">
            </asp:CalendarExtender>
            </td>
            
        </tr>
        <tr>
        <td>Date To:</td><td><asp:TextBox ID="txtDateEnd" runat="server" CssClass="calendarTextBox"></asp:TextBox>
        <asp:CalendarExtender ID="ceDOA" runat="server" TargetControlID="txtDateEnd" Enabled="True"></asp:CalendarExtender>
        </td>
        <td><asp:Button runat="server" id="btnGenerate" Text="Display" /></td>
        </tr>

        </table>

        </div>
    </div>
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
