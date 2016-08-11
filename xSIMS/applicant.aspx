<%@ Page Title="" Language="C#" MasterPageFile="~/SIMSMaster.master" AutoEventWireup="true" CodeFile="applicant.aspx.cs" Inherits="applicant" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<%@ Register src="UserControls/ucMobile.ascx" tagname="ucMobile" tagprefix="jrv" %>
<%@ Register src="UserControls/ucCalendar.ascx" tagname="ucCalendar" tagprefix="jrv" %>
<%@ Register src="UserControls/ucProperText.ascx" tagname="ucProperText" tagprefix="jrv" %>
<%@ Register src="UserControls/ucContactNo.ascx" tagname="ucContactNo" tagprefix="jrv" %>
   
 
<%@ Register src="UserControls/ucGradeText.ascx" tagname="ucGradeText" tagprefix="jrv" %>
   
 
<%@ Register src="UserControls/ucCommand.ascx" tagname="ucCommand" tagprefix="uc2" %>
   
 
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


 <link href="css/applicant.css" rel="stylesheet" type="text/css" />


 
  <style type="text/css">
        .style1
        {
        width: 300px;
    }
        .style2
        {
            width: 235px;
            height: 28px;
        }
          

        /*for Multiline disable resizing */
        
        textarea
        {
        resize: none;    
        }
        
        .style3
      {
          width: 294px;
      }
      .style4
      {
          width: 247px;
      }
        
        </style>


        


</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<div id="mainApplicant">



<!--Update Panel -->



<asp:UpdatePanel runat="server" ID="upApplicant" UpdateMode="Conditional" ChildrenAsTriggers="true">
<ContentTemplate>




<asp:Panel runat="server" ID="panControl1">
<table>
<tr>
    <asp:TextBox ID="txtSearch" runat="server" CssClass="inputSearch"></asp:TextBox>
    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtSearch"
        WatermarkText="Type Here">
    </asp:TextBoxWatermarkExtender>
    <asp:ImageButton ID="imgSearch" CssClass="imgSearch" runat="server" ImageUrl="~/images/controlsIcon/search.png"
        OnClick="imgSearch_Click" ToolTip="Search Applicant" />
    <asp:ImageButton ID="imgNew" runat="server" ImageUrl="~/images/controlsIcon/new.png"
        CssClass="imgNew" OnClick="imgNew_Click" ToolTip="Create New Applicant Record" />
    </tr>
</table>
</asp:Panel>

<asp:Panel runat="server" ID="panControl2">
<table>
<tr>
    <asp:ImageButton ID="imgReturn" runat="server" 
        ImageUrl="~/images/controlsIcon/return.png" ToolTip="Return" 
        onclick="imgReturn_Click" CausesValidation="false" CssClass="imgReturn"/>
    <asp:ImageButton ID="imgSave" runat="server" CssClass="imgSave"  
        ImageUrl="~/images/controlsIcon/save.png" ToolTip="Save"
        onclick="imgSave_Click" />

        <asp:Label runat="server" ID="messageLocal" Font-Bold="True" 
        Font-Names="Verdana" Font-Size="11pt" ForeColor="#CC0000"></asp:Label>
</tr>  
</table>
</asp:Panel>
<hr />

<!-- Content of the PAge -->

<asp:Panel runat="server" ID="panelApplicantPage" height="500px" ScrollBars="Vertical">
    <div id="Controls">
        <asp:Panel runat="server" ID="panControls">
           <div id="dAppList">
            <table width="100%">
                    <tr>
                    <td>
                        <asp:GridView ID="gvApplicant" runat="server" AllowPaging="True" 
                            AutoGenerateColumns="False" CellPadding="2" DataKeyNames="AppNum" 
                            EnableModelValidation="True" ForeColor="#333333" GridLines="Horizontal" 
                            onpageindexchanging="gvApplicant_PageIndexChanging" 
                            Font-Names="Calibri" 
                            Font-Size="11pt" onrowdatabound="gvApplicant_RowDataBound"
                            CssClass="gview"
                            AlternatingRowStyle-CssClass="alt"
                            EditRowStyle-CssClass="editrow"
                            PagerStyle-CssClass="pgr"
                            >
                           
                            <Columns>
                                <asp:BoundField DataField="GenderCode" ReadOnly="True" >
                                <ItemStyle CssClass="hideColumn"/>
                                <HeaderStyle CssClass="hideColumn" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Image ID="imgIcon" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="AppNum" HeaderText="">
                                <ControlStyle BackColor="#0066CC" />
                                <ItemStyle Width="75px" Font-Names="calibri" Font-Size="10pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FullName" HeaderText="Applicant Name">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="250px" />
                                <ItemStyle Width="200px" Font-Names="calibri" Font-Size="10pt" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Controls">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgEdit" runat="server" CausesValidation="false" 
                                            CssClass="imgEdit" ImageAlign="Left" ImageUrl="~/images/controlsIcon/edit.png" 
                                            onclick="imgEdit_Click" ToolTip="Edit" />
                                        <asp:ImageButton ID="imgPrint" runat="server" CssClass="imgPrint" 
                                            ImageAlign="Left" ImageUrl="~/images/controlsIcon/printer.png" 
                                            onclick="imgPrint_Click" ToolTip="Print" />
                                       
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <ItemStyle VerticalAlign="Middle"/>
                                </asp:TemplateField>
                            </Columns>
                           
                            <PagerSettings FirstPageImageUrl="~/images/Nav/nextLast.png" 
                                LastPageImageUrl="~/images/Nav/prevLast.png" 
                                NextPageImageUrl="~/images/Nav/next.png" 
                                PreviousPageImageUrl="~/images/Nav/prev.png" />
                            <PagerStyle BackColor="#CCCCCC" ForeColor="#006600" HorizontalAlign="Left" 
                                Font-Bold="True" />
                           
                        </asp:GridView>
                        </td>
                    </tr>
            </table>
            </div>

            <div id="dDeliquent">
            <b>Students on hold</b>
            <hr />
            <asp:GridView runat="server" ID="gvDeliquent" AllowPaging="True" 
                    AllowSorting="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" 
                    BorderWidth="1px" CellPadding="3" EnableModelValidation="True" 
                    ForeColor="Black" GridLines="Vertical" 
                    onpageindexchanging="gvDeliquent_PageIndexChanging" PageSize="12">
            
                <AlternatingRowStyle BackColor="White" />
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            
            </asp:GridView>
            </div>
        </asp:Panel>
    </div>


<asp:Panel runat="server" ID="panNew" Visible="false">

<div id="leftApp">

<asp:TabContainer runat="server" ID="AppTabMain">
<asp:TabPanel runat="server" ID="tpFirst">

<HeaderTemplate><b>Applicant Details</b></HeaderTemplate>
<ContentTemplate>
<div id="dTabContent1">
<fieldset id="Fieldset1" runat="server" title="Date of Application">
<table width="100%">

<tr align="left">
<td class="style1">Application Date:  
    <jrv:uccalendar ID="ucDateApplication" runat="server"/>
</td>
    <td><asp:CheckBox ID="chkWaitListed" runat="server" Text="Wait Listed?" /></td>
</tr>

<tr>
<td class="style1">Applicant Type: 
    <asp:DropDownList ID="ddAppType" runat="server" 
        CssClass="dropDownStyle" AutoPostBack="True" OnSelectedIndexChanged="ddAppType_SelectedIndexChanged"
        ></asp:DropDownList>
    </td>
    <td><asp:CheckBox ID="chkSSIChild" runat="server" Text="SSI Child?" /> </td>
</tr>

<tr>
<td class="style2">Level Applying: <asp:DropDownList ID="ddAppLevel" runat="server" 
        AutoPostBack="True" CssClass="dropDownStyle" 
        onselectedindexchanged="ddAppLevel_SelectedIndexChanged"></asp:DropDownList></td>
<td><asp:Panel ID="panStrand" runat="server">Strand Type: <asp:DropDownList ID="ddStrandType" runat="server" 
        CssClass="dropDownStyle"></asp:DropDownList></asp:Panel></td>
</tr>

</table>
</fieldset>
<fieldset id="Fieldset2" runat="server" title="ApplicantName">
<table width="100%">
<tr align="left">
<td><jrv:ucProperText ID="ucTxtLastName" runat="server"/></td>
<td><jrv:ucProperText ID="ucTxtFirstName" runat="server"/></td>
<td><jrv:ucProperText ID="ucTxtMiddleName" runat="server" /></td>
<td><asp:TextBox ID="txtMI" runat="server" CssClass="textBoxStyle_min"></asp:TextBox></td>
<td><asp:TextBox ID="txtSuffix" runat="server" CssClass="textBoxStyle_min"></asp:TextBox></td>
</tr>
<tr align="left">
<td>Last Name</td>
<td>First Name</td>
<td>Middle Name</td>
<td>M.I</td>
<td>Suffix</td>
</tr>
</table>
</fieldset>

<fieldset id="Fieldset3" runat="server" text="Date of Birth">
<table>
<tr>
<td>Date of Birth:</td><td>

<asp:TextBox ID="txtBirthDate" runat="server" 
     CssClass="calendarTextBox"
        onblur="outFocus();"></asp:TextBox><asp:RequiredFieldValidator runat="server" ID="rfvTxtBirthDate" ErrorMessage="Birthdate Required" Text="*" ControlToValidate="txtBirthDate" Display="Dynamic"></asp:RequiredFieldValidator>
    <asp:MaskedEditExtender ID="meeCalendar" runat="server" 
        TargetControlID="txtBirthDate" Mask="99/99/9999" ErrorTooltipEnabled="True"  
        MaskType="Date" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True">
    </asp:MaskedEditExtender>
    <asp:MaskedEditValidator ID="mevCalendar" runat="server" 
    ControlToValidate="txtBirthDate" ControlExtender="meeCalendar" 
    Display="Dynamic" 
    InvalidValueMessage="Date not Valid"
    InvalidValueBlurredMessage="*"
    IsValidEmpty="False" ErrorMessage="mevCalendar"></asp:MaskedEditValidator>
    <asp:CalendarExtender ID="ceDOA" runat="server" TargetControlID="txtBirthDate" 
        Enabled="True">
    </asp:CalendarExtender>

    </td>


</tr>
<tr>
<td>Place of Birth: </td><td><asp:TextBox ID="txtPlaceOfBirth" runat="server"
                    Height="30px" TextMode="MultiLine" Width="150px"></asp:TextBox>
    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" 
        TargetControlID="txtPlaceOfBirth" WatermarkText="Place of Birth" 
        WatermarkCssClass="waterMark" Enabled="True">
                </asp:TextBoxWatermarkExtender></td>
                <td>Gender:</td><td><asp:DropDownList ID="ddGender" runat="server" CssClass="dropDownStyle"></asp:DropDownList> </td>
</tr>

</table>

<fieldset id="Fieldset4" runat="server" text="Address">
Primary Contact:

<table>
<tr>
<td>Tel. #: </td><td><jrv:ucContactNo ID="ucTelNo" runat="server" />
<td>Mobile #:<jrv:ucMobile ID="ucMobile" runat="server" /></td>
</tr>
<tr>
<td>Contact Person:</td><td><jrv:ucProperText ID="ucContactPerson" runat="server"/></td>

    <td>Email Add:<asp:TextBox runat="server" ID="txtEmailAdd" Width="130px"></asp:TextBox>
    <asp:RegularExpressionValidator runat="server" ErrorMessage="Email Not Valid" 
        ID="revEmail" ControlToValidate="txtEmailAdd" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" >*</asp:RegularExpressionValidator></td>
</tr>
</table>

<table>
    <caption>
        <hr />
        <tr>
            <td rowspan="2">
            
                <asp:TextBox ID="txtAddNoStreet" runat="server" 
                    Height="50px" TextMode="MultiLine" Width="180px" MaxLength="150"></asp:TextBox>
                <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtenderAddress" 
                    runat="server" TargetControlID="txtAddNoStreet" 
                    WatermarkText="Blk/Street/Subdivision" Enabled="True">
                </asp:TextBoxWatermarkExtender>
            </td>
            <td>
                City:
                <asp:DropDownList ID="ddCity" runat="server" 
                    CssClass="dropDownStyle" 
                    onselectedindexchanged="ddCity_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td rowspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Barangay:
                <asp:DropDownList ID="ddArea" runat="server" CssClass="dropDownStyle" 
                    onselectedindexchanged="ddArea_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
    
    <tr><td>
        <asp:CheckBox ID="chkActive" runat="server" Text="Active" ForeColor="#CC0000"  Font-Bold="True" /> || &nbsp; &nbsp; <asp:CheckBox ID="chkAppBackOut" runat="server" Text="BackOUT" ForeColor="#CC0000" Font-Bold="True" /></td> 
        
        </tr>
    </caption>
</table>
</fieldset>
 
</fieldset>
</div>
</ContentTemplate>
</asp:TabPanel>



<asp:TabPanel runat="server" ID="tpOther">
<HeaderTemplate><b>Other Details</b></HeaderTemplate>
<ContentTemplate>
<div id="dTabContent2">
<asp:Panel ID="panShortMonth" runat="server">
<fieldset>
<legend>Age By June(Pre School Only)</legend>
<table width="100%">
<tr>
<td><asp:CheckBox runat="server" Text="Short by June?" ID="chkShort" /> </td>
<td>Month(s) Short: <asp:TextBox runat="server" ID="txtShortMonth" CssClass="textBoxStyle_min" MaxLength="1">
</asp:TextBox><asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers" TargetControlID="txtShortMonth"></asp:FilteredTextBoxExtender>
</td>
</tr>
</table>
</fieldset>

</asp:Panel>

<div id="divPrevGrade">
<asp:Panel runat="server" ID="panelPreviousGrade">
<fieldset title="Grade Evaluation">
<legend>Previous Grade Evaluation</legend>
<table align="left" style="border: 1px solid #000000; vertical-align: middle" width="100%">
<tr align="center">
<td></td>
<td><b>1st</b></td>
<td><b>2nd</b></td>
<td><b>3rd</b></td>
<td><b>4th</b></td>
</tr>

<tr align="center">
<td align="left"><b>English</b></td>
<td><jrv:ucGradeText ID="eng1" runat="server" /></td>
<td><jrv:ucGradeText ID="eng2" runat="server" /></td>
<td><jrv:ucGradeText ID="eng3" runat="server" /></td>
<td><jrv:ucGradeText ID="eng4" runat="server" /></td>
<td><asp:Label runat="server" ID="engTotal"></asp:Label></td>
</tr>

<tr align="center">
<td align="left"><b>Mathematics</b></td>
<td><jrv:ucGradeText ID="mat1" runat="server" /></td>
<td><jrv:ucGradeText ID="mat2" runat="server" /></td>
<td><jrv:ucGradeText ID="mat3" runat="server" /></td>
<td><jrv:ucGradeText ID="mat4" runat="server" /></td>
<td><asp:Label runat="server" ID="matTotal"></asp:Label></td>
</tr>

<tr align="center">
<td align="left"><b>Science</b></td>
<td><jrv:ucGradeText ID="sci1" runat="server" /></td>
<td><jrv:ucGradeText ID="sci2" runat="server" /></td>
<td><jrv:ucGradeText ID="sci3" runat="server" /></td>
<td><jrv:ucGradeText ID="sci4" runat="server" /></td>
<td><asp:Label runat="server" ID="sciTotal"></asp:Label></td>
</tr>

<tr align="center">
<td align="left"><b>Total</b></td>
<td><asp:Label runat="server" ID="lblGP1"></asp:Label></td>
<td><asp:Label runat="server" ID="lblGP2"></asp:Label></td>
<td><asp:Label runat="server" ID="lblGP3"></asp:Label></td>
<td><asp:Label runat="server" ID="lblGP4"></asp:Label></td>
<td><asp:Label runat="server" ID="lblAverage" Font-Bold="True" Font-Size="13pt" 
        ForeColor="Red"></asp:Label></td>
<td><asp:TextBox runat="server" ID="lblAverage2" Font-Bold="True" Font-Size="12pt" 
        ForeColor="Red" CssClass="textBoxStyle_Grades" MaxLength="5"></asp:TextBox></td>
</tr>

</table>
</fieldset>
<asp:Button runat="server" ID="computePreviousGrade" Text="Compute Previous Grade" 
        onclick="computePreviousGrade_Click" CausesValidation="False" />
</asp:Panel>
</div>
</div>
</ContentTemplate>
</asp:TabPanel>
</asp:TabContainer>

</div>

<div id="Credentials">
<b>Credentials Submitted:</b>
<table>

<tr>
<td>
    <asp:CheckBox ID="chkF138" runat="server"  Text="Photocopy of Report Card (Form 138)" />
</td>
</tr>

<tr>
<td>
<asp:CheckBox ID="chkBC" runat="server"  Text="Original Birth Certificate from NSO" />
</td>
</tr>

<tr>
<td>
<asp:CheckBox ID="chk1x1Picture" runat="server"  Text="1 x 1 Colored Picture (2 pcs)" />
</td>
</tr>

<tr>
<td>
<asp:CheckBox ID="chkEnvelope" runat="server"  Text="Brown Envelope (Long)" />
</td>
</tr>

<tr>
<td>
<asp:CheckBox ID="chkGoodMoral" runat="server"  Text="Good Moral" />
</td>
</tr>

<tr>
<td>
<asp:CheckBox ID="chkRecommendation" runat="server" Text="Recommendation Letter" />
</td>
</tr>

<tr>
<td>
<asp:CheckBox ID="chk137" runat="server"  Text="Form-137 (Student Permanent Record)" />
</td>
</tr>

<tr>
<td>
<asp:CheckBox ID="chkNCAE" runat="server"  Text="NCAE Result (for Grade 11 Applicant Only)" />
</td>
</tr>
<tr>
<td>
<asp:CheckBox ID="chkInterview" runat="server"  Text="Interview (c/o Guidance Facilitator)" />
</td>
</tr>
</table>

Others:<br />
    <asp:TextBox ID="txtOthers" runat="server" TextMode="MultiLine" Width="350px" Height="75px"></asp:TextBox>
    <br />
Remarks:<br />
    <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Width="350px" Height="75px"></asp:TextBox>

    <br />
</div>
</asp:Panel>








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



</asp:Panel> <!-- Page Panel -->

</ContentTemplate>

<Triggers>
</Triggers>
</asp:UpdatePanel>



</div>

</asp:Content>


