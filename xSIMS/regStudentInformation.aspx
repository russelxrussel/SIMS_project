<%@ Page Title="" Language="C#" MasterPageFile="~/SIMSMaster.master" AutoEventWireup="true" CodeFile="regStudentInformation.aspx.cs" Inherits="regStudentInformation" %>


<%@ Register src="UserControls/ucMobile.ascx" tagname="ucMobile" tagprefix="jrv" %>
<%@ Register src="UserControls/ucCalendar.ascx" tagname="ucCalendar" tagprefix="jrv" %>
<%@ Register src="UserControls/ucProperText.ascx" tagname="ucProperText" tagprefix="jrv" %>
<%@ Register src="UserControls/ucContactNo.ascx" tagname="ucContactNo" tagprefix="jrv" %>
<%@ Register src="UserControls/ucUpperCaseTextNV.ascx" tagname="ucUpperCaseTextNV" tagprefix="jrv" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/StudentInfo.css" rel="stylesheet" type="text/css" />

    <%-- AutoComplete Script --%> 
     <script type="text/javascript">

         $(document).ready(function () {
             var prm = Sys.WebForms.PageRequestManager.getInstance();
             prm.add_initializeRequest(InitialRequest);
             prm.add_endRequest(EndRequest);

             //Auto Complete Initial
             SetAutoComplete();
             SetAccordion();
         });

        function InitialRequest(sender, args)
        {
        }

        function EndRequest(sender, args)
        {
            SetAutoComplete();
            SetAccordion();
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


        //Accordion
        function SetAccordion() {
      
            $("#dAccordionControl").accordion(
            {
            heightStyle: "content"
            });
        }

    
    </script>

    <script type ="text/javascript">
    //Active state of Accordion
//     $(function (){
//     var activeAccIndex = parseInt($('').val());

//     $('#accordion').accordion({
//     autoHeight: false,
//     event: "mousedown",
//     active: active
    </script>

     <style type="text/css">
        
        .lStudentNo
        { 
          font-size: 16px;
          font-weight:bold;
          font-family:Calibri;  
          width: 100px;
            
        }
        .tableStyle
        {
            width: 500px;
        }
                
        .UpperCase
        {
           text-transform: uppercase; /*UPPER CASE */ 
        }
         
        .imgSaveLoc
        {
          position:relative;
          left:10px;
          top: 5px; 
          width:20px;
          height:20px;   
        }     
       
    </style>
     
 

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
<asp:UpdatePanel runat="server" ID="updatePanel" UpdateMode="Conditional">
 <ContentTemplate>

<style type="text/css">
 
</style>

<div id="dMain">
    <!-- TOP -->
    <div id="dTop">
    <div id="topRow1">
    <div id="dSearchSection">
    <asp:TextBox runat="server" id="txtSearch" CssClass="inputSearch"></asp:TextBox>
        <asp:TextBoxWatermarkExtender ID="txtSearch_TextBoxWatermarkExtender" 
            runat="server" Enabled="True" TargetControlID="txtSearch" WatermarkText="Type Here">
        </asp:TextBoxWatermarkExtender>
        
        <%--Hold the studentnumber to be referenced and use for database search--%>
        <asp:HiddenField ID="hfStudNum" runat="server" />

 
   <asp:ImageButton ID="imgSearch" CssClass="imgSearch" runat="server" ImageUrl="~/images/controlsIcon/search.png"
        ToolTip="Search Student" CausesValidation="false" onclick="imgSearch_Click"/>

    <asp:ImageButton ID="imgSave" CssClass="imgSaveLoc" runat="server" ImageUrl="~/images/controlsIcon/save.png"
        ToolTip="Update Student Information" onclick="imgSave_Click" />

      
    </div>

    </div>

<%--This control will cover all elements state--%>
<asp:Panel runat="server" ID="panContentTop">

    <asp:Label runat="server" ID="lblTest1"></asp:Label>

    <div id="topRow2">
    
    <div id="topRow2Col1">
             <asp:Image ID="imgStudentPicture" runat="server" Height="100px" Width="100px" />
             <asp:Label runat="server" id="lblStudentNo" CssClass="lStudentNo"></asp:Label>
            </div>

    <div id="topRow2Col2">
    <table>
    <tr>
    <td>Last Name:</td><td><jrv:ucProperText ID="ucTxtLastName" runat="server"/></td>
    </tr>
    <tr>
    <td>First Name:</td><td><jrv:ucProperText ID="ucTxtFirstName" runat="server"/></td>
    </tr>
    <tr>
    <td>Middle Name:</td><td><asp:TextBox runat="server" ID="ucTxtMiddleName" CssClass="grid_textbox"></asp:TextBox></td>
    </tr>
<%--    <jrv:ucProperText ID="ucTxtMiddleName" runat="server" />--%>
    <tr>
    <td>Middle Initial:</td><td><asp:TextBox ID="txtMI" runat="server" CssClass="textBoxStyle_min"></asp:TextBox></td>
    </tr>
    <tr>
    <td>Suffix:</td><td><asp:TextBox ID="txtSuffix" runat="server" CssClass="textBoxStyle_min"></asp:TextBox></td>
    </tr>
    </table>
    </div>

    <div id="topRow2Col3">
    <table>
    <tr>
    <td>Date of Birth:</td><td><asp:TextBox ID="txtBirthDate" runat="server" CssClass="calendarTextBox" onblur="outFocus();"></asp:TextBox><asp:RequiredFieldValidator
                                runat="server" ID="rfvTxtBirthDate" ErrorMessage="Birthdate Required" Text="*"
                                ControlToValidate="txtBirthDate" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:MaskedEditExtender ID="meeCalendar" runat="server" TargetControlID="txtBirthDate"
                                Mask="99/99/9999" ErrorTooltipEnabled="True" MaskType="Date" CultureAMPMPlaceholder=""
                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                Enabled="True">
                            </asp:MaskedEditExtender>
                            <asp:MaskedEditValidator ID="mevCalendar" runat="server" ControlToValidate="txtBirthDate"
                                ControlExtender="meeCalendar" Display="Dynamic" InvalidValueMessage="Date not Valid"
                                InvalidValueBlurredMessage="*" IsValidEmpty="False" ErrorMessage="mevCalendar"></asp:MaskedEditValidator>
                            <asp:CalendarExtender ID="ceDOA" runat="server" TargetControlID="txtBirthDate" Enabled="True">
                            </asp:CalendarExtender></td>
    </tr>
    <tr>
    <td>Place of Birth:</td><td><asp:TextBox ID="txtPlaceOfBirth" runat="server" CssClass="textBoxStyle"></asp:TextBox>
                        </td>
    </tr>
    <tr>
    <td>Gender:</td><td><asp:DropDownList ID="ddGender" runat="server" CssClass="dropDownStyle">
                            </asp:DropDownList></td>
    </tr>
    
    <tr>
    <td>Citizenship:</td><td><asp:DropDownList ID="ddCitizenship" runat="server" CssClass="dropDownStyle">
                            </asp:DropDownList></td>
    </tr>
    <tr>
    <td>Religion:</td><td><asp:DropDownList ID="ddReligion" runat="server" CssClass="dropDownStyle">
                            </asp:DropDownList></td>
    </tr>
    
    </table>

 
    </div>

    <div id="topRow2Col4">
    <table>
    <tr>
    <td>Contact:</td><td><jrv:ucProperText ID="ucContactPerson" runat="server"></jrv:ucProperText></td>
    </tr>
    <tr>
    <td>Mobile#:</td><td><asp:TextBox runat="server" ID="ucMobile" CssClass="grid_textbox"></asp:TextBox></td></tr>
   <%-- <jrv:ucMobile ID="ucMobile2" runat="server"></jrv:ucMobile>
   <jrv:ucContactNo ID="ucTelNo" runat="server"></jrv:ucContactNo>
    --%>

     <tr>
    <td>Tele#:</td><td><asp:TextBox runat="server" ID="ucTelNo" CssClass="grid_textbox"></asp:TextBox></td>
    </tr>
    <tr>
    <td>Email:</td><td><asp:TextBox runat="server" ID="txtEmailAdd" Width="150px"></asp:TextBox>
                                <asp:RegularExpressionValidator runat="server" ErrorMessage="Email Not Valid" ID="revEmail"
                                    ControlToValidate="txtEmailAdd" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator></td>
    </tr>
    
    </table>
    </div>

    <div id="topRow2Col5">
    <table>
    <tr>
    <td><asp:TextBox ID="txtAddNoStreet" runat="server" Height="50px" TextMode="MultiLine"
                                        Width="180px" MaxLength="150"></asp:TextBox>
                                    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtenderAddress" runat="server"
                                        TargetControlID="txtAddNoStreet" WatermarkText="Blk/Street/Subdivision" Enabled="True">
                                    </asp:TextBoxWatermarkExtender></td>
    </tr>
    <tr>
    <td>City:<asp:DropDownList ID="ddCity" runat="server" CssClass="dropDownStyle" 
                                        AutoPostBack="True" onselectedindexchanged="ddCity_SelectedIndexChanged">
                                    </asp:DropDownList></td>
    </tr>

    <tr>
    <td>Barangay:<asp:DropDownList ID="ddArea" runat="server" CssClass="dropDownStyle">
                                    </asp:DropDownList></td>
    </tr>
    </table>
    </div>

    </div>
  
</asp:Panel> <%--End of Panel--%>  

    </div>


<!--TAB Container Section -->
  <asp:Panel runat="server" ID="panContentTab"> <!--Use to disable initially the content of TAB -->

    <!-- CONTENT -->
    <div id="dContent">

        <asp:TabContainer ID="tcDetails" runat="server" Height="260px" Width="990px"
            ActiveTabIndex="0" Font-Bold="True" 
            Font-Names="calibri" Font-Size="15px">
        
        <asp:TabPanel runat="server" ID="tabStudDetails">
        <HeaderTemplate>More Info</HeaderTemplate>
        <ContentTemplate>
            <div id="dAddInfoContent">

            <asp:Panel runat="server" ID="panelAddInfo" Visible="False">

            <table>
            <tr><td>Barcode: </td>
            
            <td><asp:TextBox runat="server" ID="txtBarcode" CssClass="grid_textbox"></asp:TextBox></td>
            <td>&nbsp;&nbsp; ||</td>
                        <td>
                            LRN:
                        </td>
                        
                        <td>
                            <asp:TextBox runat="server" ID="txtLRN" CssClass="grid_textbox"></asp:TextBox>
                        </td>
                      <td>
                      </td>
                      <td>&nbsp;&nbsp; ||</td>
                     <td>Employee Child:</td>
                     <td><asp:CheckBox ID="chkSSIChild" runat="server" ForeColor="#CC0000" /></td>
                     <td><asp:LinkButton runat="server" ID="lnkBLS" CssClass="lnkControl" 
                             onclick="lnkBLS_Click">Update</asp:LinkButton></td>     
  
                    </tr>
                </table>
            <br />
            <div id="dAddInfoLeft">
             <div id="dAddInfoLeftTitle">
               <asp:Label runat="server" ID="lblSYStatus"></asp:Label>
             </div>   
             <table>
          
            <tr>
            <td>Student Status:</td><td><asp:CheckBox ID="chkActive" runat="server" Text="Active" ForeColor="#CC0000" /></td> 
            <td><asp:LinkButton runat="server" ID="lnkUpdateStatus" CssClass="link_sliding_lightGreen"
                    onclick="lnkUpdateStatus_Click">Update</asp:LinkButton></td>
            </tr>
            <tr>
            <td>Current Level:</td>
            <td><asp:Label runat="server" id="lblCurrentLevel"></asp:Label></td>
            </tr>
            
            <tr>
            <td>Section:</td><td><asp:Label runat="server" ID="lblCurrentSection"></asp:Label></td>
            </tr>

            <tr>
            <td><asp:Label runat="server" ID="lblStrandText">Strand:</asp:Label></td>
            <td>
            <asp:Label runat="server" ID="lblStrand"></asp:Label><asp:DropDownList runat="server" ID="ddStrand" CssClass="dropdown_ver_lightBlue"></asp:DropDownList>
            </td>
               <td><asp:LinkButton runat="server" ID="lnkUpdateStrand" OnClick="lnkUpdateStrand_Click" CssClass="lnkControl">Update</asp:LinkButton></td>
            </tr>

           

            <tr>
            <td>Reservation Status:</td><td><asp:DropDownList runat="server" ID="ddReservedStatus" CssClass="dropdown_ver_lightBlue"></asp:DropDownList></td>
            <td><asp:LinkButton runat="server" ID="lnkUpdateReserve" OnClick="lnkUpdateReserve_Click"  CssClass="lnkControl">Update</asp:LinkButton></td>
            </tr>

            <tr>
            <td>Enrollment Status:</td><td><asp:DropDownList runat="server" ID="ddEnrollmentStatus" CssClass="dropdown_ver_lightBlue"></asp:DropDownList></td>
            <td><asp:LinkButton runat="server" ID="lnkUpdateEnrollment" OnClick="lnkUpdateEnrollment_Click"  CssClass="lnkControl">Update</asp:LinkButton></td>
            </tr>

            <tr>
            <td>Mode of Transportation: </td><td><asp:DropDownList runat="server" ID="ddMOT" CssClass="dropdown_ver_lightBlue"></asp:DropDownList></td>
            <td><asp:LinkButton runat="server" ID="lnkUpdateMOT" OnClick="lnkUpdateMOT_Click"  CssClass="lnkControl">Update</asp:LinkButton></td>
            </tr>
            </table>
            </div>

            <div id="dAddInfoRight">
            
            <table>
            <tr>
            <td>DATE APPLIED:</td><td><asp:Label runat="server" ID="lblDateApplied"></asp:Label></td>
            </tr>

            <tr>
            <td>SY ENTRY:</td><td><asp:Label runat="server" ID="lblEntrySY"></asp:Label></td>
            </tr>

            <tr>
            <td>LEVEL ENTRY:</td><td><asp:Label runat="server" ID="lblGradeLevel"></asp:Label></td>
            </tr>
            
            </table>
 
        </div>
        
</asp:Panel>   
            
            
            </div>
        </ContentTemplate>
        </asp:TabPanel>
        
        <asp:TabPanel ID="tabEducationBG" runat="server">
        <HeaderTemplate>Educational</HeaderTemplate>
        <ContentTemplate>

        <asp:Panel runat="server" ID="panelEducation" Visible="false"> 
      
      <div id="dEducDetails"> 
       <table>
       
       <tr>
       <td>Educ Type:</td><td><asp:DropDownList runat="server" ID="ddEduType" CssClass="dropdown_ver_lightBlue"></asp:DropDownList></td>
       </tr>
       
       <tr><td>School Name:</td><td><asp:TextBox runat="server" ID="txtSchoolName" CssClass="grid_textbox"></asp:TextBox></td></tr>
       <tr><td>Address</td><td> <asp:TextBox runat="server" ID="txtSchAddress" CssClass="grid_textbox"></asp:TextBox></td><td>Year:</td><td> <asp:TextBox runat="server" ID="txtYearGrad" CssClass="grid_textbox"></asp:TextBox></td><td> 
           <asp:LinkButton runat="server" ID="lnkAddEducation" 
               onclick="lnkAddEducation_Click" CssClass="lnkControl">(+) Education</asp:LinkButton></td></tr>  
       </table>
       </div>
     <hr />
     <div id="dgridEducdetails">
            <asp:GridView ID="gvEducation" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" CellPadding="4" 
                CssClass="gview" DataKeyNames="ID" 
                EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                onrowcancelingedit="gvEducation_RowCancelingEdit" 
                onrowdatabound="gvEducation_RowDataBound" onrowediting="gvEducation_RowEditing" 
                onrowupdating="gvEducation_RowUpdating">
                <AlternatingRowStyle CssClass="alt" />
                <Columns>
                    <asp:BoundField DataField="ID" >
                    <HeaderStyle CssClass="hideColumn" />
                    <ItemStyle CssClass="hideColumn" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="TYPE">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddEduType" runat="server" CssClass="dropdown_ver_lightBlue">
                            </asp:DropDownList>
                            <asp:Label ID="lblEduType" runat="server" Text='<%# Bind("EduType") %>' 
                                Visible="false"></asp:Label>
                            <%-- This will be dummy--%>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="label" runat="server" Text='<%# Bind("EduType") %>'></asp:Label>
                         </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SCHOOL NAME">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtSchoolName" runat="server" CssClass="grid_textbox" 
                                Text='<%# Bind("SchoolName") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" CssClass="UpperCase" 
                                Text='<%# Bind("SchoolName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ADDRESS">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAddress" runat="server" CssClass="grid_textbox" 
                                Text='<%# Bind("Address") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" CssClass="UpperCase" 
                                Text='<%# Bind("Address") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="YEAR">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtYearGrad" runat="server" CssClass="grid_textbox" 
                                Text='<%# Bind("Yeargrad") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" CssClass="UpperCase" 
                                Text='<%# Bind("Yeargrad") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" />
                </Columns>
                <EditRowStyle CssClass="editrow" />
                <PagerStyle CssClass="pgr" />
            </asp:GridView>
       </div>

</asp:Panel>    
   
        </ContentTemplate>
        </asp:TabPanel>
        

        <asp:TabPanel ID="tabFamilyBG" runat="server">
        <HeaderTemplate>Family / Guardian Info</HeaderTemplate>        
        
        <ContentTemplate>

        <asp:Panel runat="server" ID="panelFamily" Visible="false">
        
        <div id="dFamilyBg">
     
        <div id="fatherDiv">
        <b class="FamilyTitle">Father Details:</b>
        <table>
        <tr>
        <td>Last Name:</td><td><jrv:ucUpperCaseTextNV ID="ucFLastName" runat="server"/></td>
       <td> <asp:ImageButton ID="imgSwitchParent" CssClass="imgSave" runat="server" ImageUrl="~/images/iconLabel/change1.png"
        ToolTip="Switch Parent Info" onclick="imgSwitchParent_Click"  /></td>
        <tr>
        <td>First Name:</td><td><jrv:ucUpperCaseTextNV ID="ucFFirstName" runat="server"/></td></tr>
        <tr>
        <td>Middle Name:</td><td><jrv:ucUpperCaseTextNV ID="ucFMiddleName" runat="server"/></td></tr>
        <tr>
        <td>Occupation:</td><td><jrv:ucUpperCaseTextNV ID="ucFOccupation" runat="server"/></td></tr>
        <tr>
        <td>Citizenship:</td><td><asp:DropDownList runat="server" ID="ddFCitizenship" CssClass="dropdown_ver_lightBlue"></asp:DropDownList></td></tr>
        <tr>
        <td>Educ Attainment:</td><td><asp:TextBox runat="server" ID="txtFEducAttainment"></asp:TextBox></td></tr>
         <tr>
        <td>Company:</td><td><asp:TextBox runat="server" ID="txtFCompany"></asp:TextBox></td></tr>
         <tr>
        <td>Comp. Address:</td><td><asp:TextBox runat="server" ID="txtFCompAddress"></asp:TextBox></td></tr>
        <tr>
        <td>Telephone:</td><td><asp:TextBox runat="server" ID="ucFTelephone"></asp:TextBox></td></tr>
        <tr>
        <td>Cel/Mobile No:</td><td><asp:TextBox runat="server" ID="ucFMobile"></asp:TextBox></td></tr>
   
        </table>
        </div>

        <div id="motherDiv">
        <b class="FamilyTitle">Mother Details:</b>
        <table>
        <tr>
        <td>Last Name:</td><td><jrv:ucUpperCaseTextNV ID="ucMLastName" runat="server"/></td></tr>
        <tr>
        <td>First Name:</td><td><jrv:ucUpperCaseTextNV ID="ucMFirstName" runat="server"/></td></tr>
        <tr>
        <td>Middle Name:</td><td><jrv:ucUpperCaseTextNV ID="ucMMiddleName" runat="server"/></td></tr>
        <tr>
        <td>Occupation:</td><td><jrv:ucUpperCaseTextNV ID="ucMOccupation" runat="server"/></td></tr>
        <tr>
        <td>Citizenship:</td><td><asp:DropDownList runat="server" ID="ddMCitizenship" CssClass="dropdown_ver_lightBlue"></asp:DropDownList></td></tr>
        <tr>
        <td>Educ Attainment:</td><td><asp:TextBox runat="server" ID="txtMEducAttainment"></asp:TextBox></td></tr>
         <tr>
        <td>Company:</td><td><asp:TextBox runat="server" ID="txtMCompany"></asp:TextBox></td></tr>
         <tr>
        <td>Comp. Address:</td><td><asp:TextBox runat="server" ID="txtMCompAddress"></asp:TextBox></td></tr>
        <tr>
        <td>Telephone:</td><td><asp:TextBox runat="server" ID="ucMTelephone"></asp:TextBox></td></tr>
        <tr>
        <td>Cel/Mobile No:</td><td><asp:TextBox runat="server" ID="ucMMobile"></asp:TextBox></td></tr>
   
        </table>
        </div>
        
        <div id="guardianDiv">
        <b class="FamilyTitle">Guardian Details:</b>
        <table>
        <tr>
        <td>Last Name:</td><td><jrv:ucUpperCaseTextNV ID="ucGLastName" runat="server"/></td></tr>
        <tr>
        <td>First Name:</td><td><jrv:ucUpperCaseTextNV ID="ucGFirstName" runat="server"/></td></tr>
        <tr>
        <td>Middle Name:</td><td><jrv:ucUpperCaseTextNV ID="ucGMiddleName" runat="server"/></td></tr>
        <tr>
        <td>Address</td><td><asp:TextBox runat="server" ID="txtGAddress"></asp:TextBox></td></tr>
        <tr>
        <td>Telephone:</td><td><asp:TextBox runat="server" ID="ucGTelephone" runat="server"></asp:TextBox></td></tr>

        <tr>
        <td>Cel/Mobile No:</td><td><asp:TextBox runat="server" ID="ucGMobile" runat="server"></asp:TextBox></td></tr>
            </tr>
            <tr>
                <td>
                    Relation:</td>
                <td>
                    <asp:TextBox ID="txtGRelation" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <hr />

        <b class="FamilyTitle">Select Primary Contact Incase:</b>
        <table>
        <tr>
        <td><asp:RadioButton runat="server" ID="optPrimaryFather" Text="Father" GroupName="contact" CssClass="FamilyContact"/></td>
        <td><asp:RadioButton runat="server" ID="optPrimaryMother" Text="Mother" GroupName="contact" CssClass="FamilyContact"/></td>
        <td><asp:RadioButton runat="server" ID="optGuardian" Text="Guardian"  GroupName="contact" CssClass="FamilyContact"/></td>
        </tr>

        </table>
        
        </div>
        
        <asp:LinkButton runat="server" ID="lnkUpadteRelative" OnClick="lnkUpdateRelative_Click" CssClass="lnkControl">Update Contacts</asp:LinkButton>

        </div>
        
        </asp:Panel>

        </ContentTemplate>
        
        </asp:TabPanel>
        
        
        <asp:TabPanel runat="server" ID="tabSiblings">
        <HeaderTemplate>Siblings</HeaderTemplate>
        <ContentTemplate>
      
       <asp:Panel runat="server" ID="panelSibling" Visible="false">

        <div id="dSiblings">
       
        <div id="dSibTop">
        <table>
        <tr>
        <td> <asp:DropDownList runat="server" ID="ddSiblings" CssClass="dropdown_ver_lightBlue"></asp:DropDownList></td>
        <td> <asp:LinkButton runat="server" ID="lnkSiblingOtherSel" 
                EnableModelValidation="false" onclick="lnkSiblingOtherSel_Click" CssClass="lnkControl">Display all Students</asp:LinkButton></td>
        </tr>
        <tr>
        <td>Sibling Ordering: <asp:DropDownList runat="server" ID="ddSOrder">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>8</asp:ListItem>
           
            </asp:DropDownList>
        </td>
        
        <td></td>
        </tr>
        <tr>
        <td>
        <asp:LinkButton runat="server" ID="lnkAddSibling" EnableModelValidation="false" 
                onclick="lnkAddSibling_Click" CssClass="lnkControl">(+) Sibling</asp:LinkButton>
        </td>
        </tr>
        </table>
        </div>
       
        <div id="dSibBot">
        <asp:GridView runat="server" ID="gvSiblings" CssClass="gview" 
                EnableModelValidation="True" AutoGenerateColumns="False" DataKeyNames="ID"
                onrowcancelingedit="gvSiblings_RowCancelingEdit" 
                onrowdeleting="gvSiblings_RowDeleting" onrowediting="gvSiblings_RowEditing" 
                onrowupdating="gvSiblings_RowUpdating" 
                onrowdatabound="gvSiblings_RowDataBound">
            <Columns>
                <asp:BoundField DataField="ID" >
                <ItemStyle CssClass="hideColumn" />
                <HeaderStyle CssClass="hideColumn" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="S-Order">
                    <ItemTemplate>
                   <%-- <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("SiblingOrder") %>' Width="20px"></asp:TextBox>--%>
                            <asp:Label ID="label" runat="server" Text='<%# Bind("SiblingOrder") %>'></asp:Label>
                   
                    </ItemTemplate>
                    <EditItemTemplate>
                    <asp:DropDownList ID="ddSiblingOrder" runat="server" CssClass="grid_dropdown">
                    
                     </asp:DropDownList>

                     <%-- label will be dummy to display the current content to drop down--%>
                            <asp:Label ID="lblSiblingOrder" runat="server" Text='<%# Bind("SiblingOrder") %>' 
                             visible="false"></asp:Label>
                            
                    </EditItemTemplate>
                </asp:TemplateField>
                
                <asp:BoundField DataField="FullName" HeaderText="Sibling(s)" ReadOnly="True" />
                <asp:BoundField DataField="Current_LevelCode" HeaderText="Level" ReadOnly="True" />
               
                <asp:CommandField ShowEditButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        
        </asp:GridView>
        </div>

      </div>

      </asp:Panel>
      
        </ContentTemplate>
        
        
        </asp:TabPanel>


       <asp:TabPanel runat="server" ID="tpCredentials">
        <HeaderTemplate>Credentials</HeaderTemplate>
        <ContentTemplate>

        <asp:Panel runat="server" ID="panelCredential" Visible="false">
            <div id="Credentials">
                <div id="CredentialLeft">
                    <b>Credentials Submitted:</b>
                    <table>
                        <tr>
                            <td>
                                <asp:CheckBox ID="chkF138" runat="server" Text="Photocopy of Report Card (Form 138)" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="chkBC" runat="server" Text="Original Birth Certificate from NSO" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="chk1x1Picture" runat="server" Text="1 x 1 Colored Picture (2 pcs)" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="chkEnvelope" runat="server" Text="Brown Envelope (Long)" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="chkGoodMoral" runat="server" Text="Good Moral" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="chkRecommendation" runat="server" Text="Recommendation Letter" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="chk137" runat="server" Text="Form-137 (Student Permanent Record)" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="chkNCAE" runat="server" Text="NCAE Result (for Grade 11 Applicant Only)" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="chkInterview" runat="server" Text="Interview (c/o Guidance Facilitator)" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="CredentialRight">
                    Others:<br />
                    <asp:TextBox ID="txtOthers" runat="server" TextMode="MultiLine" Width="300px" Height="75px"></asp:TextBox>
                  <br />
                  <br />
                  <br />
                  <asp:LinkButton runat="server" ID="lnkCredentials" onclick="lnkCredentials_Click" CssClass="lnkControl">Update Credentials</asp:LinkButton>
                </div>

                <div id="CredentialControl">
                
                </div>

            </div>
            </asp:Panel>

        </ContentTemplate>
        </asp:TabPanel>

        </asp:TabContainer>

    </div>

     </asp:Panel>
      <%--End of Panel--%>  

</div>



</ContentTemplate>
 </asp:UpdatePanel>



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

</asp:Content>

