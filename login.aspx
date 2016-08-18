<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/jquery-ui.theme.css" rel="stylesheet" type="text/css" />
    <link href="css/login.css" rel="stylesheet" type="text/css" />
    <script src="jscripts/jquery.js" type="text/javascript"></script>
    <script src="jscripts/jquery-ui.js" type="text/javascript"></script>

    <style type="text/css">
    
    
     .inputUserName
     {
    width: 250px;
    box-sizing: border-box;
    border: 2px solid #ccc;
    border-radius: 8px;
    font-size: 16px;
    background-color: white;
    background-image: url('images/design_new/usernameicon.png');
    background-position: 10px 10px; 
    background-repeat: no-repeat;
    padding:  12px 20px 10px 50px;
     }
       
 .inputUserPassword
     {
    width: 250px;
    box-sizing: border-box;
    border: 2px solid #ccc;
    border-radius: 8px;
    font-size: 16px;
    background-color: white;
    background-image: url('images/design_new/passwordicon.png');
    background-position: 10px 10px; 
    background-repeat: no-repeat;
    padding: 12px 20px 12px 50px;
     }
     
     
 
     
     
     
    </style>

    <title></title>

   


</head>
<body>
    
    <form id="form1" runat="server">

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
 <div id="bg">
    <div id="mainLogin">
    <div id="LoginContent">
        <asp:TextBox ID="txtUserId" runat="server" CssClass="inputUserName"  AutoCompleteType="Disabled"></asp:TextBox>
        
        <br />
        <asp:TextBox ID="txtPassword" runat="server" CssClass="inputUserPassword" TextMode="Password"></asp:TextBox>
        <br />
       <asp:Button ID="btnLogin" runat="server" Text="Login" 
            onclick="btnLogin_Click" />
       </div>
    </div>

 
 <div id="dialog">
 <p><b>Invalid Username and Password.</b></p>
 </div>

 <script type="text/javascript">
     $('#dialog').dialog
 ({
     autoOpen: false,
     show: { effect: "fade", duration: 1000 },
     hide: { effect: "blind", duration: 500 },
     close: function (event, ui) { window.lication.href = "#"; }

 });

 function fncsave() {
     $('#dialog').dialog("open");
 }

 </script>

 </div>
    </form>


</body>
</html>
