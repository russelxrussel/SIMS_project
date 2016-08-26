<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="rep_EmpDiscount.aspx.cs" Inherits="rep_EmpDiscount" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        function Print() {
            var dvReport = document.getElementById("rcontent");
            var frame1 = dvReport.getElementsByTagName("iframe")[0];
            if (navigator.appName.indexOf("Internet Explorer") != -1) {
                frame1.name = frame1.id;
                window.frames[frame1.id].focus();
                window.frames[frame1.id].print();
            }
            else {
                var frameDoc = frame1.contentWindow ? frame1.contentWindow : frame1.contentDocument.document ? frame1.contentDocument.document : frame1.contentDocument;
                frameDoc.print();
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
     <div id="rcontent">      

        <input id="btnPrint" type="button" value="Print" onclick="Print()" />  
         <CR:CrystalReportViewer ID="crv" runat="server" 
              AutoDataBind="true" EnableDatabaseLogonPrompt="False" 
              EnableParameterPrompt="False" 
              PrintMode="ActiveX" ToolPanelView="None" EnableDrillDown="False" 
              HasCrystalLogo="False" HasDrilldownTabs="False" HasDrillUpButton="False"
              ReuseParameterValuesOnRefresh="True" 
              Enabled="False" PageZoomFactor="100" HasZoomFactorList="False" 
              BestFitPage="False" HasPrintButton="False" />
    </div>

    </div>
    </form>
</body>
</html>
