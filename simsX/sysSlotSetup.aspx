<%@ Page Title="" Language="C#" MasterPageFile="~/SIMSMaster.master" AutoEventWireup="true" CodeFile="sysSlotSetup.aspx.cs" Inherits="sysSlotSetup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:UpdatePanel runat="server" ID="upSlotSetup">
<ContentTemplate>
<asp:Panel runat="server" ID="panControl1">
<table>
<tr>
<asp:ImageButton runat="server" id="imgNew" 
        ImageUrl="~/images/controlsIcon/new.png" />
 </tr>
</table>
</asp:Panel>


<div id="entry">
<table>
<tr><td>Level Category: </td><td>
    <asp:DropDownList ID="ddLevelCategory" runat="server" AutoPostBack="True" 
        onselectedindexchanged="ddLevelCategory_SelectedIndexChanged">
    </asp:DropDownList>
</td></tr>
<tr><td>Level Type: </td><td><asp:DropDownList ID="ddLevelType" runat="server">
    </asp:DropDownList></td></tr>
<tr><td>Target No.:</td><td><asp:TextBox runat="server" ID="txtNoApplicant" CssClass="textBoxStyle_Grades"></asp:TextBox><asp:FilteredTextBoxExtender ID="Filtered12" runat="server" TargetControlID="txtNoApplicant" FilterType="Numbers">
                    </asp:FilteredTextBoxExtender></td></tr>
</table>
</div>


<div id="dataContent">


    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataSourceID="SqlDataSource1" EnableModelValidation="True" 
        ForeColor="#333333" GridLines="None" DataKeyNames="id">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField HeaderText="id" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:CSSIMS %>" 
        DeleteCommand="DELETE FROM xSystem.SetupSlot_MF WHERE [id] = @id" 
        InsertCommand="INSERT INTO xSystem.SetupSlot_MF ([SY], [LevelCatCode], [LevelTypeCode], [osInit], [sAccumulate], [sOpen]) VALUES (@SY, @LevelCatCode, @LevelTypeCode, @osInit, @sAccumulate, @sOpen)" 
        SelectCommand="SELECT * FROM xSystem.SetupSlot_MF WHERE ([SY] = @SY)" 
        UpdateCommand="UPDATE xSystem.SetupSlot_MF SET [SY] = @SY, [LevelCatCode] = @LevelCatCode, [LevelTypeCode] = @LevelTypeCode, [osInit] = @osInit, [sAccumulate] = @sAccumulate, [sOpen] = @sOpen WHERE [id] = @id">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="SY" Type="String" />
            <asp:Parameter Name="LevelCatCode" Type="String" />
            <asp:Parameter Name="LevelTypeCode" Type="String" />
            <asp:Parameter Name="osInit" Type="Int32" />
            <asp:Parameter Name="sAccumulate" Type="Int32" />
            <asp:Parameter Name="sOpen" Type="Int32" />
        </InsertParameters>
        <SelectParameters>
            <asp:SessionParameter Name="SY" SessionField="S_SY" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="SY" Type="String" />
            <asp:Parameter Name="LevelCatCode" Type="String" />
            <asp:Parameter Name="LevelTypeCode" Type="String" />
            <asp:Parameter Name="osInit" Type="Int32" />
            <asp:Parameter Name="sAccumulate" Type="Int32" />
            <asp:Parameter Name="sOpen" Type="Int32" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>


</div>


</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

