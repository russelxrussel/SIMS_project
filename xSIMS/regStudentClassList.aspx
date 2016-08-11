<%@ Page Title="" Language="C#" MasterPageFile="~/SIMSMaster.master" AutoEventWireup="true" CodeFile="regStudentClassList.aspx.cs" Inherits="regStudentClassList" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link href="css/ClassList.css" rel="stylesheet" type="text/css" />

<%----Script--%>

<script type="text/javascript">

    $(document).ready(function () {
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_initializeRequest(InitialRequest);
        prm.add_endRequest(EndRequest);

        //Initial SOURCE GRIDVIEW CHECK
        toggleSelect(source);
        toggleSelectionHeadOff();

        //        //Initial DESTINATION GRIDVIEW CHECK
        toggleSelectDestination(source);
        toggleSelectionDestinationHeadOff();

    });

    function EndRequest(sender, args) {
        //Initial SOURCE GRIDVIEW CHECK
        toggleSelect(source);
        toggleSelectionHeadOff();

        //        //Initial DESTINATION GRIDVIEW CHECK
        toggleSelectDestination(source);
        toggleSelectionDestinationHeadOff();
    }


    //SOURCE GRIDVIEW

    function toggleSelect(source) {
        $("#<%=gvSource.ClientID%> input[name$='chkSource']").each(function () {
            $(this).attr('checked', source.checked);
        });

    }

    function toggleSelectionHeadOff() {
        if ($("#<%=gvSource.ClientID%> input[name$='chkSource']").length == $("#<%=gvSource.ClientID%> input[name$='chkSource']:checked").length) {
            $("#<%=gvSource.ClientID%> input[name$='chkSourceAll']").first().attr('checked', true);
        }
        else {
            $("#<%=gvSource.ClientID%> input[name$='chkSourceAll']").first().attr('checked', false);
        }

    }



    //DESTINATION GRIDVIEW
    function toggleSelectDestination(source) {
        $("#<%=gvDestination.ClientID%> input[name$='chkDestination']").each(function () {
            $(this).attr('checked', source.checked);
        });

    }


    function toggleSelectionDestinationHeadOff() {
        if ($("#<%=gvDestination.ClientID%> input[name$='chkDestination']").length == $("#<%=gvDestination.ClientID%> input[name$='chkDestination']:checked").length) {
            $("#<%=gvDestination.ClientID%> input[name$='chkDestinationAll']").first().attr('checked', true);
        }
        else {
            $("#<%=gvDestination.ClientID%> input[name$='chkDestinationAll']").first().attr('checked', false);
        }

    }



</script>



</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
 <ContentTemplate>
 <div id="divM">
      <div id="divFormMenu">

       <asp:Label runat="server" ID="lblFormMessage" CssClass="FormMessage"></asp:Label>

        <table>
        <tr>
        <td><asp:ImageButton ID="imgNew" runat="server" ImageUrl="~/images/menus/new.png"
        CssClass="imgNew" ToolTip="Create New Section Assignment" onclick="imgNew_Click" /></td>
        <td><asp:Label runat="server" ID="lblspacer" Width="25px"></asp:Label></td>
        <td><asp:ImageButton ID="imgModify" runat="server" ImageUrl="~/images/menus/find.png"
        ToolTip="Modify Section Assignment" onclick="imgModify_Click"/></td>
        </tr>
        </table>
      </div>
      <div id="divTop">
     <asp:Panel runat="server" ID="PanelSetter" Enabled="false">
     <div id="dInput">
         <table>
            <tr>
            <td>SELECT LEVEL :</td>
            <td> 
                <asp:DropDownList runat="server" ID ="ddLevelType" 
                     CssClass="dropdown_ver_lightBlue" 
                    onselectedindexchanged="ddLevelType_SelectedIndexChanged">
             </asp:DropDownList>
             </td>
            </tr>

<%--            <tr>
            <td>STRAND</td>
            <td>
            <asp:DropDownList runat="server" ID ="ddStrand" 
                    CssClass="dropdown_ver_lightBlue">
             </asp:DropDownList>
            </td>
            </tr>--%>

            <tr>
            <td>SELECT SECTION :</td>
            <td>
                <asp:DropDownList runat="server" ID ="ddSection" 
                    CssClass="dropdown_ver_lightBlue">
                </asp:DropDownList>
            </td>
            </tr>

            <tr><td>SELECT ROOM :</td><td><asp:DropDownList runat="server" ID="ddRoomList" CssClass="dropdown_ver_lightBlue"></asp:DropDownList></td></tr>
            
         </table>
     </div>
    
     <div id="dInfo">
     <table>
     <tr><td>TEACHERS:</td><td><asp:DropDownList runat="server" ID="ddTeacherList" CssClass="dropdown_ver_lightBlue"></asp:DropDownList></td></tr>
     <tr><td>SCHEDULE:</td><td><asp:TextBox runat="server" ID="txtDaysDesc" CssClass="schedTextSchedule"></asp:TextBox></td></tr>
     <tr>
            <td>BUILDING:</td>
            <td>   
               <asp:TextBox runat="server" ID="txtBuildingDesc" CssClass="schedTextSchedule"></asp:TextBox></td>
            </tr>
            
     </table>
     </div>

      <asp:Button runat="server" id="btnSet" Text="SET" 
                Width="50px" onclick="btnSet_Click" />
      
     </asp:Panel>

   <%--  <asp:LinkButton runat="server" ID="btnSet" Text="SET" CssClass="lnkControl" Width="50px" onclick="btnSet_Click"></asp:LinkButton>--%>

     <asp:Panel ID="panelEdit" runat="server">
           <asp:Button runat="server" id="btnEdit" Text="Edit" 
                Width="50px" onclick="btnEdit_Click"/>
     </asp:Panel>
     

 </div>
     <div id="divGutter">
     </div>
      
      <%--Main Panel for Transaction--%>
    
     <div id="divSelection">
   
      <asp:Panel runat="server" ID="pnlTransaction">
        <div id="divSource">
        
        SOURCE: <asp:Label runat="server" ID="lblSourceCount"></asp:Label>
        <asp:Panel ID="pnlSource" runat="server" ScrollBars="Auto" Width="415px" Height="400px">
            <asp:GridView runat="server" id="gvSource"
                GridLines = "None"
                CssClass="mGrid"
                AlternatingRowStyle-CssClass = "alt" 
             AllowPaging="false"
             PagerStyle-CssClass = "pgr" 
            AutoGenerateColumns="False" 
            onpageindexchanging="gvSource_PageIndexChanging" PageSize="15"
            AlternatingRowStyle-BorderStyle="NotSet" EnableModelValidation="True" 
            onrowdatabound="gvSource_RowDataBound">
    
        <AlternatingRowStyle CssClass="alt" />
        <Columns>
            <asp:TemplateField>
            <HeaderTemplate>
            <asp:CheckBox runat="server" ID="chkSourceAll" onclick="toggleSelect(this);" />
            </HeaderTemplate>

            <ItemTemplate>
            <asp:CheckBox runat="server" ID="chkSource" onclick="toggleSelectionHeadOff();" />
            </ItemTemplate>
            
            </asp:TemplateField>
     
             <asp:BoundField DataField="GenderCode">
             <ItemStyle CssClass="hideColumn"/>
             <HeaderStyle CssClass="hideColumn" />
             </asp:BoundField>
            
             
            <asp:TemplateField>
            <ItemTemplate>
                <asp:Image ID="imgIcon" runat="server" />
            </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="StudNum" HeaderText="Stud Num" />
            <asp:BoundField DataField="StudName" HeaderText="Name" />
        </Columns>
    
        <PagerStyle CssClass="pgr" />
    
    </asp:GridView>
    </asp:Panel>
        </div>

        <div id="divTransfer">
             <table>
             <tr>
             <td>
           <%-- <asp:Button runat="server" ID="btnTransfer" Text="Transfer >>" 
             onclick="btnTransfer_Click"/>--%>

             <asp:LinkButton runat="server" ID="btnTransfer" Text ="TRANSFER >>" onclick="btnTransfer_Click" CssClass="lnkControl"></asp:LinkButton>
             </td>
             </tr>
             <tr>
             <td>
             <asp:Label runat="server" ID="decoyGutterTransfer" Height="20px"></asp:Label>
             </td>
             </tr>
             <tr>
             <td>
             <%--<asp:Button runat="server" ID="btnReturn" Text="<< Return" onclick="btnReturn_Click" /> --%>
             <asp:LinkButton runat="server" ID="btnReturn" Text ="<< RETURN" onclick="btnReturn_Click" CssClass="lnkControl"></asp:LinkButton>
              </td>
              </tr>
               <asp:Label runat="server" ID="lblCountSelected"></asp:Label>
               
               
               </table>
        </div>

    <div id="divDestination">
    DESTINATION: <asp:Label runat="server" ID="lblDestinationCount"></asp:Label>
    <asp:Panel ID="pnlDestination" runat="server" ScrollBars="Auto" Width="415px" Height="400px">
      <asp:GridView runat="server" id="gvDestination"
    GridLines = "None"
    CssClass="mGrid"
    AlternatingRowStyle-CssClass = "alt" 
             AllowPaging="false"
             PagerStyle-CssClass = "pgr" 
            AutoGenerateColumns="False"
            onrowdatabound="gvDestination_RowDataBound"
            >
    
        <AlternatingRowStyle CssClass="alt" />
        <Columns>
            <asp:TemplateField>
            <HeaderTemplate>
            <asp:CheckBox runat="server" ID="chkDestinationAll" onclick="toggleSelectDestination(this);" />
            </HeaderTemplate>

            <ItemTemplate>
            <asp:CheckBox runat="server" ID="chkDestination" onclick="toggleSelectionDestinationHeadOff();" />
            </ItemTemplate>
            
            </asp:TemplateField>
     
            <asp:BoundField DataField="GenderCode">
             <ItemStyle CssClass="hideColumn"/>
             <HeaderStyle CssClass="hideColumn" />
             </asp:BoundField>
            
             
            <asp:TemplateField>
            <ItemTemplate>
                <asp:Image ID="imgIcon" runat="server" />
            </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="StudNum" HeaderText="Stud Num" />
            <asp:BoundField DataField="StudName" HeaderText="Name" />
        </Columns>
    
        <PagerStyle CssClass="pgr" />
    
    </asp:GridView>
    </asp:Panel>
    </div>
     </asp:Panel>
    </div>

 
    
 <br />

</div>    
   
 

    <asp:Label runat="server" ID="lblCount"></asp:Label>

<%--<!--Will use as default dialog box-->
 <!-- ModalPopupExtender -->--%>
  <%--         <asp:ModalPopupExtender ID="mp1" runat="server" PopupControlID="PanelConfirm" TargetControlID="btnTransfer"
                OkControlID="btnYes" CancelControlID="btnNo" BackgroundCssClass="modalBackground">
            </asp:ModalPopupExtender>

            <asp:Panel ID="PanelConfirm" runat="server" CssClass="modalPopup">
                <div id="titleConfirm">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/messageIcon/question.png"
                        CssClass="imgTitle" /><label id="Label1" class="labelTitle">SSI-School Integrated Management
                            System</label></div>
                <br />
                <asp:Label runat="server" ID="lblConfirmMessage" CssClass="confirmLabelMessage">Do you want to transfer selected student(s)?</asp:Label>
                <hr />
                <br />
                <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="buttonConfirm"/>
                <asp:Button ID="btnNo" runat="server" Text="No" CssClass="buttonConfirm_NO" />
            </asp:Panel>

            <asp:ConfirmButtonExtender ID="imgSave_ConfirmButtonExtender" runat="server" ConfirmText="Are you sure you want to proceed?"
                Enabled="true" TargetControlID="btnTransfer" DisplayModalPopupID="mp1">
            </asp:ConfirmButtonExtender> 

--%>

             <asp:ModalPopupExtender ID="mpeModify" runat="server" PopupControlID="pnlPopUp" TargetControlID="imgModify"
                 BackgroundCssClass="modalBackground">
            </asp:ModalPopupExtender>

            <asp:Panel runat="server" ID="pnlPopUp">
            <div id="divGpopUpBG">
            <div id="divGpopUpTitleBar">
            <div id="divGpopUpClose">
            <asp:ImageButton ID="imgGpopUpClose" runat="server" ImageUrl="~/images/menus/close.png"
              ToolTip="Close"/>     
            </div>
            </div>
            
           
            <div id="divGpopUpContent">
          
            <asp:Panel runat="server" ID="pnlPopUpContent" ScrollBars="Auto" Height="400px">
              

               <!-- PLACE CONTENT HERE -->

               <asp:GridView runat="server" ID="gvListSection" 
                GridLines = "None"
                CssClass="mGrid"
                AlternatingRowStyle-CssClass = "alt" 
                AllowPaging="false"
                PagerStyle-CssClass = "pgr" 
                AutoGenerateColumns="False" 
                AlternatingRowStyle-BorderStyle="NotSet" EnableModelValidation="True">
                   <AlternatingRowStyle CssClass="alt" />
               <Columns>
                    <asp:TemplateField>
                    <ItemTemplate>
                    <asp:LinkButton runat="server" ID="lnkEdit" onclick="lnkEdit_Click">Edit</asp:LinkButton>
                    </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="id">
                     <ItemStyle CssClass="hideColumn"/>
                    <HeaderStyle CssClass="hideColumn" />
                    </asp:BoundField>

                    <asp:BoundField DataField="levelSection" HeaderText="Level & Section" />
                    <asp:BoundField DataField="roomDescription" HeaderText="Room" />
                    <asp:BoundField DataField="Schedule" HeaderText="Schedule" />
                    <asp:BoundField DataField="TeacherName" HeaderText="Adviser" />
                </Columns>
                   <PagerStyle CssClass="pgr" />
               </asp:GridView>

               <!-- END OF CONTENT-->

             </asp:Panel>
               
             </div>

            <div id="divGpopipFooter"></div>
            </div>

            </asp:Panel>

</div>
  


<%--<!--MESSAGE BOX -->
<div id="xMessage">
    <div id="title">
    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/messageIcon/messagebox.png" CssClass="imgTitle"/>
    <label id="lblTitle" class="labelTitle">SSI-School Integrated Management System</label>
    </div>

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
--%>
 </ContentTemplate>  
</asp:UpdatePanel>
</asp:Content>

