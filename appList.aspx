<%@ Page Language="C#" AutoEventWireup="true" CodeFile="appList.aspx.cs" Inherits="appList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/ControlsStyle.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gvAppList" runat="server" AutoGenerateColumns="False" 
            AllowPaging="true" PageSize="15"
            CssClass="gview"
            AlternatingRowStyle-CssClass="alt"
            EditRowStyle-CssClass="editrow"
            PagerStyle-CssClass="pgr" onpageindexchanging="gvAppList_PageIndexChanging"
            >
            <Columns>
                <asp:BoundField DataField="AppNum" />
                <asp:BoundField DataField="Fullname" HeaderText="Applicant Name" >
                <ControlStyle Width="150px" />
                <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:CheckBoxField DataField="WLStatus" HeaderText="WL" 
                    ReadOnly="True" />
                <asp:CheckBoxField DataField="SSIChild" HeaderText="SSI-C" 
                    ReadOnly="True" />
                <asp:BoundField DataField="GenderCode" ReadOnly="True" HeaderText="Gender" >
                <HeaderStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="LevelTypeCode" HeaderText="Level" />
                <asp:BoundField DataField="Admission" HeaderText="App Info" >
                <ItemStyle ForeColor="Red" />
                </asp:BoundField>
                <asp:BoundField DataField="Clinic" HeaderText="Health" />
                <asp:BoundField DataField="Guidance" HeaderText="Entrance Exam" />
            </Columns>

        </asp:GridView>
    </div>
    </form>
</body>
</html>
