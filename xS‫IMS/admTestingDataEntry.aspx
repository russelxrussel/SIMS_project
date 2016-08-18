<%@ Page Title="" Language="C#" MasterPageFile="~/SIMSMaster.master" AutoEventWireup="true" CodeFile="admTestingDataEntry.aspx.cs" Inherits="admTestingDataEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register src="UserControls/ucGradeText.ascx" tagname="ucGradeText" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/TestingStyle.css" rel="stylesheet" type="text/css" />
   
     <%-- AutoComplete Script --%> 
     <script type="text/javascript">

         $(document).ready(function () {
             var prm = Sys.WebForms.PageRequestManager.getInstance();
             prm.add_initializeRequest(InitialRequest);
             prm.add_endRequest(EndRequest);

             //Auto Complete Initial
             SetAutoComplete();

         });

         function InitialRequest(sender, args) {
         }

         function EndRequest(sender, args) {
             SetAutoComplete();
         }

         function SetAutoComplete() {
             $("#<%= txtSearch.ClientID %>").autocomplete({
                 source: function (request, response) {
                     $.ajax({
                         url: "WService.asmx/GetApplicantList",
                         method: "POST",
                         contentType: "application/json;charset=utf-8",
                         data: JSON.stringify({ _applicantname: $("#<%= txtSearch.ClientID %>").val() }),
                         dataType: "json",
                         success: function (data) {
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
                     $("[id*=hfAppNum]").val(i.item.val);
                 },
                 minLength: 2
             });
         }

    
    </script>
   
   
    <%-- Make the completion list transparent and then show it --%>

      <script type="text/javascript">
          $(function () {
              $("#accordion").accordion();
          });


                $(document).ready(function(){
                 $("#test").click(function () {
                     $("#dAppInfoDetails").slideToggle("slow");
                 });
                 });


             var prm = Sys.WebForms.PageRequestManager.getInstance();
             prm.add_endRequest(function () {
                 $(document).ready(function () {
                     $("#test").click(function () {
                         $("#dAppInfoDetails").slideToggle("slow");
                     });
                 });
             });

             function showMe() {

                 var btn = document.getElementById('<%=imgSearch.ClientID %>');

                 $("#btn").click(function () {
                     $("#dAppInfoDetails").slideToggle("slow");
                 });


                 $("#accordion").accordion();
             }


            

      </script>

       <!-- Script for computation as typing
    11/24/2015
    Russel Vasquez
    -->

     <script type="text/javascript">

         /*JAVASCRIPT COMPUTE PERCENTAGE ON EXAM
         SOURCE http://geekswithblogs.net/dotNETvinz/archive/2010/12/08/faq-gridview-calculation-with-javascript.aspx
         RUSSEL VASQUEZ
         11/25/2015 */

         function CalculateApplicantExam() {
             var gv = document.getElementById("<%= gvTestingDE.ClientID %>");
             var tb = gv.getElementsByTagName("input");
             var lb = gv.getElementsByTagName("span");

             var sub = 0;
             var total = 0;
             var indexQ = 1; //Target
             var indexP = 0; //Source

             var cutCount = tb.length / 2;

             for (var i = 0; i < tb.length; i++) {

                 if (tb[i].type == "text") {

                     sub = (parseFloat(lb[indexP].innerHTML) * parseFloat(tb[i].value)) / 100;

                     if (isNaN(sub)) {
                         lb[i + indexQ].innerHTML = "";
                         sub = 0;
                     }

                     else {
                         lb[i + indexQ].innerHTML = sub;
                     }


                     indexQ++;
                     indexP = indexP + 2;

                     total += parseFloat(sub);

                 }
             }


             lb[lb.length - 1].innerHTML = total.toFixed(2); //This will round off into 2 decimal places

             //Get previousgrade
             var prevG = document.getElementById('<%= txtPrevGrade.ClientID %>');
             var xTotal = 0;
             var prevGradeComp = 0;

             prevGradeComp = ((parseFloat(prevG.value) * 50) / 100)
             xTotal = prevGradeComp + total;


             //Display in Summary Content 
             document.getElementById('<%= lblPrev.ClientID %>').value = prevGradeComp.toFixed(2); //PreviousGrade
             document.getElementById('<%= lblAssessment.ClientID %>').value = total.toFixed(2)
             document.getElementById('<%= lblOverall.ClientID %>').value = xTotal.toFixed(2)
         }


         //To upper typing in search of applicant
         function alert() {

             alert('Applicant no schedule');
         }


    </script>




    <style type="text/css">
        .style1
        {
            width: 100px;
            padding-left: 40px;
           
        }
        
        
   

    </style>




</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script type="text/javascript">
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(showMe);
</script>

<asp:UpdatePanel runat="server" ID="upTestingResult" UpdateMode="Conditional">
<ContentTemplate>

<div id="dMain">

    <div id="dTop">
    <table cellpadding="5px">
    <tr>
    <td> <asp:TextBox runat="server" id="txtSearch" CssClass="inputSearch"></asp:TextBox>
     
     <%--Hold the studentnumber to be referenced and use for database search--%>
        <asp:HiddenField ID="hfAppNum" runat="server" />

         <asp:ImageButton ID="imgSearch" CssClass="imgSearch" runat="server" ImageUrl="~/images/controlsIcon/search.png"
        ToolTip="Search Applicant" onclick="imgSearch_Click"/>
        </td>

    <td class="style1">
        <asp:ImageButton ID="imgSave" CssClass="imgSave" runat="server" ImageUrl="~/images/controlsIcon/save.png"
        ToolTip="Save Test Result" onclick="imgSave_Click" />
       <!-- ModalPopupExtender -->
    <asp:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="imgSave"
    OkControlID="btnYes" CancelControlID="btnNo" BackgroundCssClass="modalBackground">
    </asp:ModalPopupExtender>

    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup">
    <div id="titleConfirm">
    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/messageIcon/question.png" CssClass="imgTitle"/><label id="Label1" class="labelTitle">SSI-School Integrated Management System</label></div>
     <br />
     <asp:Label runat="server" ID="lblConfirmMessage" CssClass="confirmLabelMessage">Are you sure you want to proceed on this action?</asp:Label>
     
     <hr />
     <br />
     <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="buttonConfirm" />
     <asp:Button ID="btnNo" runat="server" Text="No" CssClass="buttonConfirm" />
    </asp:Panel>
<!-- ModalPopupExtender -->

        <asp:ConfirmButtonExtender ID="imgSave_ConfirmButtonExtender" runat="server" 
            ConfirmText="Are you sure you want to proceed?" Enabled="true" TargetControlID="imgSave"
            DisplayModalPopupID="mp1">
        </asp:ConfirmButtonExtender>
        </td>

    </tr>
    </table>
      
    
       
 
     
        
        <div id="dAppInfoDetails">
        
        <div id="dAID0">
            <asp:Image ID="imgPictures" runat="server" />
        </div>

        <div id="dAID1">
        <table width="100%">
        <tr>
        <td></td><td><asp:Label runat="server" ID="lblAppNum"></asp:Label></td>
        </tr>
        
        <tr>
        <td></td>
        <td> <asp:Label runat="server" ID="lblFullName"></asp:Label></td>
        </tr>
        
        <tr>
        <td></td>
        <td><asp:Label runat="server" ID="lblDOB"></asp:Label> </td>
        </tr>        
        </table>
        </div>

        <div id="dAID2">
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblExamInfo"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblIntInfo"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                    <td>
                         <asp:Label runat="server" ID="lblLevelCatCode"></asp:Label> - <asp:Label runat="server" ID="lblLevelTypeCode"></asp:Label>
                    </td>
                    
                    </tr>
                </table>
            </div>
      
        </div>

       
    </div>
    
    <div id="dContent">
     <asp:Panel runat="server" ID="panelContent">

     <div id="dEntry">
         
         

         <div class="title">Data Entry</div>  
             <asp:GridView ID="gvTestingDE" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
                 OnRowDataBound="gvTestingDE_RowDataBound" OnRowCreated="gvTestingDE_RowCreated"
                 CellPadding="6" ShowFooter="True" ForeColor="#333333" GridLines="Horizontal">
                 <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                 <Columns>
                     <asp:BoundField DataField="testing_desc" HeaderText="Description">
                         <HeaderStyle HorizontalAlign="Left" />
                         <ItemStyle Font-Names="Arial Rounded MT Bold" Font-Size="13px" 
                         Width="250px" />
                     </asp:BoundField>
                     <asp:TemplateField HeaderText="%">
                         <ItemTemplate>
                             <asp:Label runat="server" ID="lblPercentage" Text='<%# Eval("Percentage") %>'></asp:Label>
                         </ItemTemplate>
                         <ItemStyle Font-Names="Verdana" Font-Size="13px" Width="50px" 
                             HorizontalAlign="Center" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Scores">
                         <ItemTemplate>
                             <asp:TextBox runat="server" ID="Scores" MaxLength="5" onkeyup="CalculateApplicantExam();"
                                 CssClass="EDEInput"></asp:TextBox>
                                 <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="Scores" FilterType= "Custom, Numbers" ValidChars=".">
                                </asp:FilteredTextBoxExtender>

                         </ItemTemplate>
                         <ItemStyle HorizontalAlign="Center" Width="80px" BackColor="#FFFFCC" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Result">
                         <ItemTemplate>
                             <asp:Label runat="server" ID="Result"></asp:Label>
                         </ItemTemplate>
                         <FooterTemplate>
                             <asp:Label ID="LBLTotal" runat="server" ForeColor="Red"></asp:Label>
                         </FooterTemplate>
                         <ItemStyle  Font-Names="Verdana" Font-Size="13px" Width="50px"
                             HorizontalAlign="Center" />
                     </asp:TemplateField>
                     <asp:BoundField DataField="TTCODE" HeaderText="TTCODE" ItemStyle-CssClass="hideColumn"
                         HeaderStyle-CssClass="hideColumn" FooterStyle-CssClass="hideColumn">
                         <FooterStyle CssClass="hideColumn" />
                         <HeaderStyle CssClass="hideColumn" />
                         <ItemStyle CssClass="hideColumn" />
                     </asp:BoundField>
                 </Columns>
                 <EditRowStyle BackColor="#999999" />
                 <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                 <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                 <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                 <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                 <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
             </asp:GridView>

        
 
     </div>
      
      
      <div id="dSummary">
     <div class="title">Summary</div>
     <table>
     <tr>
     <td>Previous Grade:</td><td> <asp:TextBox runat="server" ID="lblPrev" Enabled="false" CssClass="EDEResult"></asp:TextBox></td><td> 
         <asp:TextBox runat="server" ID="txtPrevGrade" CssClass="EDEInput" MaxLength="5" 
             onfocus="CalculateApplicantExam();" onkeyup="CalculateApplicantExam();" 
             Enabled="False"></asp:TextBox></td>
     </tr>
      <tr>
     <td>Assessment/Int:</td><td><asp:TextBox runat="server" ID="lblAssessment" Enabled="false" CssClass="EDEResult"></asp:TextBox></td>
     </tr>
      <tr>
     <td></td><td><br /></td>
     </tr>
      <tr>
     <td> Overall Result:</td><td><asp:TextBox runat="server" ID="lblOverall" 
              Enabled="false" CssClass="EDEResult"></asp:TextBox></td>
     </tr>
     </table>
      <hr />
     
      <div id="dObservation">
      <label class="subTitle">Observation:</label>
           <asp:TextBox runat="server" ID="txtObservation" TextMode="MultiLine" 
              Width="320px" Height="70px" MaxLength="250" Font-Names="Calibri" 
              Font-Size="13px" Font-Bold="True"></asp:TextBox>
     <hr />
      <label class="subTitle">Recommendations:</label>&nbsp<asp:DropDownList ID="ddRecommendation"
          runat="server" CssClass="ddSelection">
      </asp:DropDownList>
      </div>

         
     </div>
    
    

   


     </asp:Panel>
    </div>

</div>



<!--MESSAGE BOX -->
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
</asp:UpdatePanel>

</asp:Content>



