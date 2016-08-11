<%@ Page Title="" Language="C#" MasterPageFile="~/SIMSMaster.master" AutoEventWireup="true" CodeFile="admAppScreening.aspx.cs" Inherits="admAppScreening" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/AppScheduling.css" rel="stylesheet" type="text/css" />

  <style type="text/css">
        .LabelDetails
        {
            Font-Weight: bold;
            Margin-Left: 10px;
        }
      .style1
      {
          width: 179px;
      }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:UpdatePanel runat="server" ID="upAppScheduling" UpdateMode="Conditional">
<ContentTemplate>


<div id="dMain">

    <div id="dTop">
    <table width="100%">
    <tr>
    <td class="style1"><asp:DropDownList ID="ddLevelType" runat="server" 
        CssClass="dropDownStyle"></asp:DropDownList>
        <asp:ImageButton ID="imgSearchViaLevel" CssClass="imgSearch" runat="server" ImageUrl="~/images/controlsIcon/search.png"
        ToolTip="Search Applicant" onclick="imgSearchViaLevel_Click"/></td>
    <td>
    <asp:TextBox runat="server" ID="txtSearch" CssClass="inputSearch"></asp:TextBox>
    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtSearch"
        WatermarkText="Type Here">
    </asp:TextBoxWatermarkExtender>
    <asp:ImageButton ID="imgSearch" CssClass="imgSearch" runat="server" ImageUrl="~/images/controlsIcon/search.png"
        ToolTip="Search Applicant" onclick="imgSearch_Click"/>
    </td>
    </tr>
    </table>
    </div>
    <br />

    <!-- Content / CRUD Process -->

    <div id="dContent">
      <asp:GridView ID="gvApplicantScheduleList" runat="server" 
        AutoGenerateColumns="False" EnableModelValidation="True" Font-Names="Calibri" Font-Size="13px" 
        onrowdatabound="gvApplicantScheduleList_RowDataBound" 
            onselectedindexchanged="gvApplicantScheduleList_SelectedIndexChanged" 
            AllowPaging="True" 
            onpageindexchanging="gvApplicantScheduleList_PageIndexChanging"
               CssClass="gview" 
              PagerStyle-CssClass="pgr">
        <Columns>

            <asp:BoundField DataField="GenderCode">
            <ItemStyle CssClass="hideColumn"/>
             <HeaderStyle CssClass="hideColumn" />
            </asp:BoundField>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Image ID="imgIcon" runat="server" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20px" />
            </asp:TemplateField>
            <asp:BoundField DataField="AppNum" ReadOnly="True" />
            <asp:BoundField DataField="Name" ReadOnly="True" />

            <asp:TemplateField HeaderText="OR#">
                <ItemTemplate>
                    <asp:TextBox ID="txtOR" runat="server" CssClass="textBoxStyle"></asp:TextBox>
                    <asp:CheckBox ID="chkFree" runat="server" Text="Free" />
                </ItemTemplate>


            </asp:TemplateField>

            <asp:TemplateField HeaderText="Examination">
            <ItemTemplate>
               <asp:DropDownList runat="server" ID="ddExamScheduleList" CssClass="dropDownStyle"></asp:DropDownList>
            </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Interview">
            <ItemTemplate>
            <asp:DropDownList runat="server" ID="ddIntScheduleList" CssClass="dropDownStyle"></asp:DropDownList>
            </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Status">
            <ItemTemplate>
            <asp:DropDownList runat="server" ID="ddExamStatus" CssClass="dropDownStyle"></asp:DropDownList>
            </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Control">
                <ItemTemplate>
                    <asp:ImageButton ID="imgControl" runat="server" 
                        CssClass="imgNew" 
                        onclick="imgNew_Click" />
                </ItemTemplate>

               
            </asp:TemplateField>
            
          
            
        </Columns>
    </asp:GridView>
    </div>
   
</div>




<div id="xMessage">
    <div id="title">
    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/messageIcon/messagebox.png" CssClass="imgTitle"/><label id="lblTitle" class="labelTitle">SSI-School Integrated Management System</label></div>
    <div id="msgIconLeft"><img id="imgIcon" class="imageClass"/></div>  
     <div id="msgTextRight">
         <div id="up">
             <label id="lblMessage" class="label">
             </label>
         </div>
         <div id="below">
             <input type="button" id="OK" value="Close" />
         </div>
     </div>
  </div>
</ContentTemplate>


</asp:UpdatePanel><!--End of Update Panel -->

<asp:Panel runat="server" ID="panelShowOR">

<asp:GridView runat="server" ID="gvORList">

</asp:GridView>
</asp:Panel>

<%--    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="lnkFindOR" PopupControlID="panelShowOR" OkControlID="" CancelControlID="">
   
    </asp:ModalPopupExtender>  --%>  
</asp:Content>

