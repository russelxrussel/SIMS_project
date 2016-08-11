<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="css/jqueryCSS.css" rel="stylesheet" type="text/css" />
<script src="jscripts/jquery-ui.min.js" type="text/javascript"></script>
<script src="jscripts/jquery.min.js" type="text/javascript"></script>
<script src="jscripts/chili.js" type="text/javascript"></script>
<script src="jscripts/jquery-1.11.3.js" type="text/javascript"></script>
<script src="jscripts/blockUI.js" type="text/javascript"></script>
<link href="css/message.css" rel="stylesheet" type="text/css" />

    <title>testing</title>



<script type="text/javascript">

//  Working eto alert
    $(document).ready(function () {

        function test1() {
            $.growlUI('Growl Notification', 'Ok ang', 5000);
        }

        $("#Button1").click(function () {
            //alert("HELLOOOO");
            $("#Panel1").animate(
            {
                width: "350px",
                opacity: 0.5,
                fontSize: "16px"
            }, 5000);

            //            $.blockUI({
            //                message: '<h2> Error </h2>',
            //                timeout: 2000
            //            });

            test1();
        });

    });

    


//    $(document).ajaxStop($.unblockUI);

//    function test() {
//        $.ajax({ url: 'wait.php', cache: false });
//    }


//    $(document).ready(function () {
//        $("#Button1").click(function () {
//            $.blockUI({ css: { backgrounColor: '#f00', color: '#fff'} });
//            test();
//        });

//    });

 

</script>

//This is for testing of message
<%--<style>
#xMessage
{
padding-top: 2px;
width: 300px;
height: 200px; 
background-color:Blue;
}

#messageHeader
{
    height:20px;
    width:300px;
    background-color:Gray;
    font-size: 12px;
    font-family:Verdana, Calibri;
    vertical-align: middle;
    
}

</style>--%>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div>
        <asp:Menu ID="Menu1" runat="server" BackColor="#E3EAEB" 
            DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" 
            ForeColor="#666666" Orientation="Horizontal" StaticSubMenuIndent="10px">
            <StaticSelectedStyle BackColor="#1C5E55" />
            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <DynamicHoverStyle BackColor="#666666" ForeColor="White" />
            <DynamicMenuStyle BackColor="#E3EAEB" BorderStyle="Solid" />
            <DynamicSelectedStyle BackColor="#1C5E55" />
            <DynamicMenuItemStyle BackColor="#999999" HorizontalPadding="5px" 
                VerticalPadding="2px" />
            <StaticHoverStyle BackColor="#666666" ForeColor="White" />
        </asp:Menu>
    </div>
    
    <asp:DropDownList ID="DropDownList1" runat="server">
    </asp:DropDownList>
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    <asp:Button ID="Button2" runat="server" Text="Button" />
    <br />
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />

    <input id="Button1" type="button" value="button" />
    <br />
    <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="4" 
        RepeatDirection="Horizontal">
    </asp:CheckBoxList>
    <br />
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
        AutoDataBind="True" EnableDatabaseLogonPrompt="False" 
        EnableParameterPrompt="False" GroupTreeImagesFolderUrl="" Height="1202px" 
        ReportSourceID="CrystalReportSource1" ToolbarImagesFolderUrl="" 
        ToolPanelWidth="200px" Width="1104px" />
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="reports\test1.rpt">
        </Report>
    </CR:CrystalReportSource>
    <br />

    <asp:Button ID="Button3" runat="server" Text="Button" onclick="Button3_Click" />
    <br />
    <asp:Panel ID="Panel1" runat="server">
    <fieldset>
    <legend>TEsting legeng</legend>
    <p> this was a testing </p>
    </fieldset>
    </asp:Panel>

    <div id="xMessage">
    <div id="msgIcon"><img id="imgIcon" class="imageClass" src="images/messageIcon/success.png"/></div>
    <div id="msgText"><p><label id="lblMessage">Thsi tdasd</label></p></div>
    </div>

     <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
        MinimumPrefixLength="1" Enabled="True" TargetControlID="TextBox1" 
        ServiceMethod="GetCompleteList" FirstRowSelected="True" 
        UseContextKey="True" CompletionInterval="500">
    </asp:AutoCompleteExtender>


    </form>
</body>
</html>
