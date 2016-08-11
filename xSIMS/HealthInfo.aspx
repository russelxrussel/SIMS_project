<%@ Page Title="" Language="C#" MasterPageFile="~/SIMSMaster.master" AutoEventWireup="true" CodeFile="HealthInfo.aspx.cs" Inherits="HealthInfo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/HealthEntry.css" rel="stylesheet" type="text/css" />
    
     <%--Hold the studentnumber to be referenced and use for database search--%> 
     <script type="text/javascript">

         $(document).ready(function () {
             var prm = Sys.WebForms.PageRequestManager.getInstance();
             prm.add_initializeRequest(InitialRequest);
             prm.add_endRequest(EndRequest);

             //Auto Complete Initial
             SetAutoComplete();
             SetAccordion();
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
                         url: "WService.asmx/GetStudentList",
                         method: "POST",
                         contentType: "application/json;charset=utf-8",
                         data: JSON.stringify({ _studentname: $("#<%= txtSearch.ClientID %>").val() }),
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
                     $("[id*=hfStudNum]").val(i.item.val);
                 },
                 minLength: 2
             });
         }

    </script>
    

    <style type="text/css">
  
        
        #dComplaintLabel1
        {
        background-color:Lime;
        }
        
        .controlStyle
        {
        width: 20px;
        height: 20px;    
        }
        
        
         .imgSaveLoc
        {           
          position:relative;
          left:10px;
          top: 5px; 
          width:20px;
          height:20px;      
        }  
        
        
        .TextMultiLine_Resize
        {
        
        font-family: calibri;
        font-size: 10pt;
        resize: none; 
        width: 200px;
        height: 30px; 
        
        }
       

    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
<asp:UpdatePanel runat="server" ID="upEntry" UpdateMode="Conditional">
<ContentTemplate>

<div id="dMain">

<asp:Panel runat="server" ID="panApplicantSelection">

<asp:Panel runat="server" ID="panControl1">

<table>
<tr>
    <asp:TextBox ID="txtSearch" runat="server" CssClass="inputSearch"></asp:TextBox>
    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtSearch"
        WatermarkText="Type Here">
    </asp:TextBoxWatermarkExtender>
    <asp:ImageButton ID="imgSearch" CssClass="imgSearch" runat="server" ImageUrl="~/images/controlsIcon/search.png"
        ToolTip="Search Applicant" onclick="imgSearch_Click" />
       &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
    <asp:ImageButton ID="imgSave" runat="server" CssClass="imgSaveLoc"  
        ImageUrl="~/images/controlsIcon/save.png" ToolTip="Save" 
        onclick="imgSave_Click"
       />
    </tr>
</table>

  <%--Hold the studentnumber to be referenced and use for database search--%>
        <asp:HiddenField ID="hfStudNum" runat="server" />
</asp:Panel>




</asp:Panel>


<asp:Panel runat="server" ID="panHealthDE">


<div id="dLeft2">
<br />
<div id="dBriefInfo">

<div id="dStudInfoTitle">
Student Information
</div>
<div id="dPics">
<table>
<tr>
<asp:Image ID="imgStudentPicture" runat="server" Height="100px" Width="100px" CssClass="img-circle" />
</tr>
</table>
</div>

<div id="dInfo2">
<table>
<tr>
<td>Stud No.</td><td><b><asp:Label runat="server" ID="lblStudNum"></asp:Label></b></td>
</tr>
<tr>
<td>Level:</td><td><b><asp:Label runat="server" ID="lblGradeLevel"></asp:Label></b></td>
</tr>
<tr>
<td>Section:</td><td><b><asp:Label runat="server" ID="lblSection"></asp:Label></b></td>
</tr>
<tr>
<td>MOT:</td><td><b><asp:Label runat="server" ID="lblMOT"></asp:Label></b></td>
</tr>
</table>
</div>

<table>
<tr>
<td>Name: </td> <td><b><asp:Label runat="server" ID="lblStudentName"></asp:Label></b></td>
</tr>

<tr>
<td>Notify:</td><td><b><asp:Label runat="server" ID="lblContactName"></asp:Label></b></td>
</tr>

<tr><td>Relation:</td><td><asp:Label runat="server" ID="lblRelation"></asp:Label></td></tr>
</tr>

<tr><td>Contact#:</td><td><asp:Label runat="server" ID="lblContactNumber"></asp:Label></td></tr>
</tr>

<tr><td>Address:</td><td><asp:Label runat="server" ID="lblContactAddress"></asp:Label></td>
</tr>
</table>

<br />
<asp:Panel runat="server" ID="applicantClinicStatus">
Recommendation:&nbsp <asp:DropDownList runat="server" ID="ddClinicRecommendation" CssClass="dd"></asp:DropDownList>
</asp:Panel>
<br />
</div>
   
</div>



<div id="dTabPanel">

<asp:TabContainer ID="tcHealthEntry" runat="server" CssClass="MyTabStyle">

    <asp:TabPanel runat="server" ID="tpComplaint">
    <HeaderTemplate>Complaint</HeaderTemplate>
    <ContentTemplate>

     <div id="dComplaintContainer">
    
    <div id="dComplaintLeft">
    
    
        <div id="dComplaintContent">
        <table width="100px">
        <tr>
        <td>Date:</td><td><asp:TextBox ID="txtDateComplaint" runat="server" CssClass="inputCalendar"></asp:TextBox> <asp:CalendarExtender
                                ID="CalendarExtender3" runat="server" TargetControlID="txtDateComplaint" Enabled="True">
                            </asp:CalendarExtender></td>
        <td>Time:</td><td><asp:TextBox runat="server" ID="txtTimeComplaint" CssClass="inputTime"></asp:TextBox><asp:MaskedEditExtender
                ID="MaskedEditExtender1" runat="server" MaskType="Time" 
                TargetControlID="txtTimeComplaint" Mask="99:99" CultureAMPMPlaceholder="" 
                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" >
            </asp:MaskedEditExtender>
            
        </td>
        </tr>
       
        </table>
      <hr />
        <table width="100px">
        <tr><td>Complaint:</td><td><asp:DropDownList runat="server" ID="ddComplaintSelection" CssClass="dropdown_ver_default"></asp:DropDownList></td>
        <td><asp:LinkButton runat="server" ID="lnkAddComplaint" CssClass="link_sliding_lightBlue" 
                onclick="lnkAddComplaint_Click">SELECT</asp:LinkButton></td>
        </tr>
        <tr>
        <td colspan="2"> 
        <asp:Panel runat="server" ID="panComplaintContent">
        <div id="dComplaintGrid">
        <asp:GridView runat="server" ID="gvComplaintList"
                CssClass="mGrid"
                GridLines="None" 
                EnableModelValidation="True">
                <AlternatingRowStyle CssClass="alt" /> 
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                    <asp:LinkButton runat="server" ID="lnkRemoveComplaint" onClick="lnkRemoveComplaint_Click" CssClass="link_sliding_lightBlue">Remove</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        
        </asp:GridView>
        <hr />
        </div> 
        </asp:Panel>
        </td>
        </tr>
    
     <asp:Panel runat="server" ID="panMedicineContent">

      <tr><td>Meds/Action:</td><td><asp:DropDownList runat="server" ID="ddMedicineSelection" CssClass="dropdown_ver_default"></asp:DropDownList></td>
        <td><asp:LinkButton runat="server" ID="lnkAddMedicine" CssClass="link_sliding_lightBlue" 
         onClick="lnkAddMedicine_Click">SELECT</asp:LinkButton></td>
        </tr>
        <asp:Panel runat="server" ID="panMedBatch" Visible="False">
        <div id="dMedBatch">
 
        
        <tr>
         <td>Batch:</td><td><asp:DropDownList runat="server" ID="ddMedBatch" 
                CssClass="dropdown_ver_default" AutoPostBack="True" 
                onselectedindexchanged="ddMedBatch_SelectedIndexChanged">        
        </asp:DropDownList></td> <td></td>
        </tr>

         <tr><td>Available Qty:</td><td><asp:Label runat="server" ID="lblAvailableQuantity"></asp:Label></td><td></td>
         </tr>

          <tr>
        <td>Qiven Qty:</td><td><asp:TextBox runat="server" ID="txtMedQuantity"></asp:TextBox>
            <asp:LinkButton runat="server" ID="lnkBatchAdd" CssClass="link_sliding_lightBlue" 
                onclick="lnkBatchAdd_Click">Add</asp:LinkButton></td><td></td>
        </tr>
      
       </div> 
        </asp:Panel>


        <tr>
        <td colspan="2">  
        <div id="dMedicineGrid">
        <asp:GridView runat="server" ID="gvMedicineList" CssClass="mGrid"
                GridLines="None" 
                EnableModelValidation="True">
                <AlternatingRowStyle CssClass="alt" /> 
        
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                    <asp:LinkButton runat="server" ID="lnkRemoveMedicine" CssClass="link_sliding_lightBlue" OnClick="lnkRemoveMedicine_Click">Remove</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        
        </asp:GridView>
        </div></td><td></td><td></td>
        </tr>
        </asp:Panel>
    
        <tr>
         <td>Notes:</td><td><asp:TextBox runat="server" ID="txtNote" TextMode="MultiLine" CssClass="TextMultiLine_Resize"></asp:TextBox></td><td></td>
        </tr>
        <tr>
        <td>Status:</td><td><asp:CheckBox runat="server" ID="chkSentHome" Text="Sent to Home" />
            <asp:CheckBox runat="server" ID="chkSentHospital" Text="Sent to Hospital" 
                oncheckedchanged="chkSentHospital_CheckedChanged"  AutoPostBack="True"/></td><td></td>
        </tr>
        </table>
 
        </div>
  <br />
    <asp:Label runat="server" ID="lblTransCode" Visible="False"></asp:Label>
     <asp:LinkButton runat="server" ID="lnkSaveComplaint" CssClass="link_sliding_lightGreen"
             Text="UPDATE" onclick="lnkSaveComplaint_Click"></asp:LinkButton> 
              
   </div>



  <!-- INCIDENT CONTENT 
  07-25-2016
  -->

  <div id="dComplaintRight">
  

<asp:Panel runat="server" ID="panIncident" Visible="False">
<div id="dIncident">
<div id="dIncidentLabel">Incident Summary</div>
  <table>
  <tr>
  <td>Time of Incident</td><td><asp:DropDownList runat="server" ID="ddTimeIncident" CssClass="dropdown_ver_default"></asp:DropDownList></td>
  </tr>

  <tr>
  <td>Place of Incident</td><td><asp:DropDownList runat="server" ID="ddPlaceIncident" CssClass="dropdown_ver_default"></asp:DropDownList></td>
  </tr>

  <tr>
  <td>Physician</td><td><asp:TextBox runat="server" ID="txtPhysician"></asp:TextBox></td>
  </tr>

  <tr>
  <td>Amount</td><td><asp:TextBox runat="server" ID="txtAmount"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td>Remarks</td><td><asp:TextBox runat="server" ID="txtRemarks" TextMode="MultiLine" CssClass="TextMultiLine_Resize"></asp:TextBox></td>
  </tr>

  </table>
</div>
</asp:Panel>

<asp:Panel runat="server" ID="panComplaintHistory" Visible="False">
  <div id="dComplaintHistory">
  <div id="dComplaintHistoryLabel">Complaint History</div>
  <asp:GridView runat="server" ID="gvComplaintHistory" CssClass="mGrid" 
          EnableModelValidation="True" AutoGenerateColumns="False" 
          AllowPaging="True" PageSize="7">
      <Columns>
          <asp:TemplateField>
          <ItemTemplate>
          <asp:LinkButton runat="server" ID="lnkEdit" Text="Edit" CssClass="link_sliding_lightBlue"></asp:LinkButton>
          </ItemTemplate>
          </asp:TemplateField>  
          
          <asp:BoundField DataField="transcode" HeaderText="refnum" ReadOnly="True" >
                   <HeaderStyle CssClass="hideColumn" />
          <ItemStyle CssClass="hideColumn" />
          </asp:BoundField>
                   <asp:BoundField DataField="compDate" HeaderText="Date" ReadOnly="True" DataFormatString="{0:dd/MM/yyyy}" />
          <asp:BoundField DataField="complaintDesc" HeaderText="Complaint" 
              ReadOnly="True" />
 
      </Columns>
  </asp:GridView>
  </div>
 </asp:Panel>


 </div>
  
 
     </div>

  
  

            
    </ContentTemplate>
    </asp:TabPanel>

    <asp:TabPanel runat="server" ID="tp1">
        <HeaderTemplate>Health Record Interview</HeaderTemplate>
        <ContentTemplate>
            <div id="dHealthDetails">
                <table>
                    <tr>
                        <td>
                            <asp:CheckBox runat="server" ID="chkCongenital" Text="Was your child diagnosed with any congenital/inborn disease?" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Please Specify:
                            <asp:TextBox runat="server" ID="txtCongenitalDesc" CssClass="txtInput"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox runat="server" ID="chkHospitalized" Text="Was your child hospitalized because of an illness? " />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Date:<asp:TextBox ID="txtDateHospitalized" runat="server" CssClass="calendarTextBox"></asp:TextBox>&nbsp;
                            Reason:
                            <asp:TextBox runat="server" ID="txtHospitalized" CssClass="txtInput"></asp:TextBox><asp:CalendarExtender
                                ID="ceDOA" runat="server" TargetControlID="txtDateHospitalized" Enabled="True">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox runat="server" ID="chkSurgery" Text="Has your child undergone minor/major surgery? " />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Date:<asp:TextBox ID="txtDateSurgery" runat="server" CssClass="calendarTextBox"></asp:TextBox><asp:CalendarExtender
                                ID="CalendarExtender1" runat="server" TargetControlID="txtDateSurgery" Enabled="True">
                            </asp:CalendarExtender>
                            &nbsp; Please Specify:
                            <asp:TextBox runat="server" ID="txtSurgery" CssClass="txtInput"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox runat="server" ID="chkAccidents" Text="Was your child involved in any serious accidents? " />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Date:<asp:TextBox ID="txtDateAccident" runat="server" CssClass="calendarTextBox"></asp:TextBox><asp:CalendarExtender
                                ID="CalendarExtender2" runat="server" TargetControlID="txtDateAccident" Enabled="True">
                            </asp:CalendarExtender>
                            &nbsp; Please Specify:
                            <asp:TextBox runat="server" ID="txtAccidents" CssClass="txtInput"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <b>Remarks from the Parents/Guardian:</b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="txtRemarksParent" TextMode="MultiLine" Width="400px"
                                Height="30px"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Remarks from Nurse:</b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="txtNurseRemarks" TextMode="MultiLine" Width="400px"
                                Height="30px"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
                <br />
            </div>
        </ContentTemplate>
    </asp:TabPanel>
  
    <%--Illness and Medicine tab--%>

    <asp:TabPanel runat="server" ID="tpIllness">
    <HeaderTemplate>Illness / Medicine</HeaderTemplate>
    <ContentTemplate>
    <asp:Accordion ID="Accordion1" runat="server" HeaderCssClass="accHeaderClass" HeaderSelectedCssClass="accHeaderSelectedClass"
        AutoSize="None">
        <Panes>
            <asp:AccordionPane runat="server" ID="AccordionPanel1">
                <Header>
                    Illness for the past 5 years up to Present</Header>
                <Content>
                    <div id="illCat1">
                        <br />
                        <asp:Label ID="Label1" runat="server" Font-Bold="True">Category 1</asp:Label><asp:CheckBoxList
                            ID="chkIllnessListCat1" runat="server" RepeatColumns="4">
                        </asp:CheckBoxList>
                        <asp:TextBox runat="server" ID="txtOthers" TextMode="MultiLine" Width="400px"
                                Height="30px"></asp:TextBox>
                        <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtOthers" WatermarkText="Type Others">
                        </asp:TextBoxWatermarkExtender>
                    </div>
                    <div id="illCat2">
                        <br />
                        <asp:Label ID="Label2" runat="server" Font-Bold="True">Category 2</asp:Label><asp:CheckBoxList
                            ID="chkIllnessListCat2" runat="server" RepeatColumns="1" ForeColor="#CC0000">
                        </asp:CheckBoxList>
                    </div>
                </Content>
            </asp:AccordionPane>
        </Panes>
        <Panes>
            <asp:AccordionPane runat="server" ID="apMedicine">
                <Header>
                    Medicine Maybe Given to Child</Header>
                <Content>
                    <div id="MedicineGiven">
                        <br />
                        <asp:CheckBoxList ID="chkMedicineMayGiven" runat="server" RepeatColumns="4">
                        </asp:CheckBoxList>
                    </div>
                    <br />
                </Content>
            </asp:AccordionPane>
        </Panes>
    </asp:Accordion>
    </ContentTemplate>
    </asp:TabPanel>

   
</asp:TabContainer>

</div>



</asp:Panel><%--End of Panel for Date Entry--%>


</div>


<!--Message Notification GENERIC 
 update: 11/11/2015
 -->

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

