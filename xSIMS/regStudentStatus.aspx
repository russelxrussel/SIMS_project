<%@ Page Title="" Language="C#" MasterPageFile="~/SIMSMaster.master" AutoEventWireup="true" CodeFile="regStudentStatus.aspx.cs" Inherits="regStudentStatus" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="jscripts/jquery-1.11.3.js" type="text/javascript"></script>
    <script src="jscripts/jquery-ui.js" type="text/javascript"></script>
    <link href="css/jquery-ui.css" rel="stylesheet" type="text/css" />

<%-- AutoComplete Script --%> 
 <script type="text/javascript">
     $(document).ready(function () {
         var prm = Sys.WebForms.PageRequestManager.getInstance();
         prm.add_initializeRequest(InitialRequest);
         prm.add_endRequest(EndRequest);

         //Auto Complete Initial
         SetAutoComplete();
         //search();

         //showDialog();
         //         showDialog();





     });

     function InitialRequest(sender, args) {
     }

     function EndRequest(sender, args) {
         SetAutoComplete();

       //  search();
       //  showDialog();
     }
     
     
     function SetAutoComplete() {
         $("#<%= txtSearch.ClientID %>").autocomplete({
             source: function (request, response) {
                 $.ajax({
                     url: "WService.asmx/GetActiveStudents",
                     method: "POST",
                     contentType: "application/json;charset=utf-8",
                     data: JSON.stringify({ _studentname: $("#<%= txtSearch.ClientID %>").val() }),
                     dataType: "json",
                     success: function (data) {
                         //response(data.d)
                         response($.map(data.d, function (item) {
                             return {
                                 label: item.split('*')[1],
                                 val: item.split('*')[0]
                             }
                         }))
                     },
                     error: function (err) {
                         //alert(err);
                         console.log('Error:', data);
                     }
                 })
             },

             select: function (e, i) {
                 $("[id*=hfStudNum]").val(i.item.val);
             }
         });
     }

   

     function search(){
         //Keypress on search
         $('#<%=txtSearch.ClientID %>').keypress(function (e) {
             var p = e.which;
             if (p == 13) {
//                 var text = $('#<%=txtSearch.ClientID %>');
//                 alert(text.val());
                 messageBtn();
                 //return false;
                 //create function that will attach click on delete button

             }
         });
     }

     //Call asp page method



    </script>
 

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:UpdatePanel runat="server" ID="upStudStatus">
<ContentTemplate>

<asp:TextBox ID="txtSearch" runat="server" CssClass="textSearch"></asp:TextBox>
 <asp:ImageButton ID="imgSearch" CssClass="imgSearch" runat="server" ImageUrl="~/images/controlsIcon/search.png"
        ToolTip="Search Student" onclick="imgSearch_Click"/>
        <asp:DropDownList ID="ddLevelType" runat="server" 
        CssClass="dropDownStyle"></asp:DropDownList>
<asp:ImageButton ID="imgSearchLevel" CssClass="imgSearch" runat="server" ImageUrl="~/images/controlsIcon/search.png"
ToolTip="Search Via Level" onclick="imgSearchLevel_Click"/>

 <asp:Label ID="lblRemove" runat="server" Text="Label"></asp:Label>
 <asp:HiddenField ID="hfStudNum" runat="server" />
<asp:GridView runat="server" id="gvActiveStudents" CssClass="gview" 
        AllowPaging="True" PageSize="12" AutoGenerateColumns="False" 
        EnableModelValidation="True" 
        onrowdatabound="gvActiveStudents_RowDataBound"
        PagerStyle-CssClass="pgr" 
        onpageindexchanging="gvActiveStudents_PageIndexChanging">

    <Columns>
        <asp:BoundField DataField="StudNum" HeaderText="Stud Num" />
        <asp:BoundField DataField="Fullname" HeaderText="Stud Name" />
        <asp:BoundField DataField="Current_LevelCode" HeaderText="Level" />
        <asp:TemplateField HeaderText="Reservation - Status">
            <ItemTemplate>
                <asp:DropDownList ID="ddAdmStatus" runat="server" CssClass="grid_dropdown_ver2">
                </asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Control">
        <ItemTemplate>
              <asp:ImageButton ID="imgControl" runat="server" 
                        CssClass="imgNew" onclick="imgControl_Click" />
        
<%--<!--Will use as default dialog box-->
 <!-- ModalPopupExtender -->--%>
            <asp:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="imgControl"
                OkControlID="btnYes" CancelControlID="btnNo" BackgroundCssClass="modalBackground">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup">
                <div id="titleConfirm">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/messageIcon/question.png"
                        CssClass="imgTitle" /><label id="Label1" class="labelTitle">SSI-School Integrated Management
                            System</label></div>
                <br />
                <asp:Label runat="server" ID="lblConfirmMessage" CssClass="confirmLabelMessage">Do you want to update this record?</asp:Label>
                <hr />
                <br />
                <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="buttonConfirm"/>
                <asp:Button ID="btnNo" runat="server" Text="No" CssClass="buttonConfirm_NO" />
            </asp:Panel>

            <asp:ConfirmButtonExtender ID="imgSave_ConfirmButtonExtender" runat="server" ConfirmText="Are you sure you want to proceed?"
                Enabled="true" TargetControlID="imgControl" DisplayModalPopupID="mp1">
            </asp:ConfirmButtonExtender>



        </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="studtypecode" />
    </Columns>



    <PagerStyle CssClass="pgr" />



</asp:GridView>



</ContentTemplate>
</asp:UpdatePanel>
  


</asp:Content>

