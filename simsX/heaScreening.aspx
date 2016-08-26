<%@ Page Title="" Language="C#" MasterPageFile="~/SIMSMaster.master" AutoEventWireup="true" CodeFile="heaScreening.aspx.cs" Inherits="heaScreening" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/HealthEntry.css" rel="stylesheet" type="text/css" />
    
    

    <style type="text/css">

   
        
        .controlStyle
        {
        width: 20px;
        height: 20px;    
        }
        
        
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div><h4>Health Screening </h4></div>
<hr />

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
    </tr>
</table>
</asp:Panel>




<div id="dLeft">
    <asp:GridView ID="gvAppStudentList" runat="server" AutoGenerateColumns="False" 
        CellPadding="3" EnableModelValidation="True" 
        CssClass="gview" Width="400px"
         AlternatingRowStyle-CssClass="alt"
         EditRowStyle-CssClass="editrow"
         PagerStyle-CssClass="pgr"
        onrowdatabound="gvAppStudentList_RowDataBound" AllowPaging="True" 
        onpageindexchanging="gvAppStudentList_PageIndexChanging">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Image ID="imgStatus" runat="server" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="10px" />
            </asp:TemplateField>
            <asp:BoundField DataField="AppNum" HeaderText="No." ReadOnly="True" >
            <HeaderStyle Font-Bold="True" Font-Names="calibri" Font-Size="11pt" 
                HorizontalAlign="Left" />
            <ItemStyle Font-Names="calibri" Font-Size="10pt" HorizontalAlign="Left" 
                Width="55px" />
            </asp:BoundField>
            
            <asp:BoundField DataField="GenderCode" HeaderText="Gender" ReadOnly="true"> 
            <ItemStyle CssClass="hideColumn"/>
             <HeaderStyle CssClass="hideColumn" />
            </asp:BoundField>
            <asp:BoundField DataField="Fullname" HeaderText="Name" ReadOnly="True">
            <HeaderStyle Font-Bold="True" Font-Names="calibri" Font-Size="11pt" 
                HorizontalAlign="Left" />
            <ItemStyle Font-Names="calibri" Font-Size="10pt" HorizontalAlign="Left" 
                Width="150px" />
              </asp:BoundField>

            <asp:BoundField DataField="LevelTypeCode" HeaderText="Level" Visible="False">
              <HeaderStyle Font-Bold="True" Font-Names="calibri" Font-Size="11pt" 
                HorizontalAlign="Center" />
            <ItemStyle Font-Names="calibri" Font-Size="11pt" HorizontalAlign="Center" 
                Width="20px" />
              </asp:BoundField>
            
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="imgAction" runat="server" CssClass="controlStyle" 
                        CausesValidation="False" onclick="imgAction_Click" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="30px" Font-Names="calibri" 
                    Font-Size="11pt" />
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="#003300" HorizontalAlign="Left" 
            Font-Bold="True" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    </asp:GridView>

  <%--  <script type="text/javascript">
        $(function () {
            $("[id*=gvAppStudentList] td").hover(function () {
                $("td", $(this).closest("tr")).addClass("hover_row");
            }, function () {
                $("td", $(this).closest("tr")).removeClass("hover_row");
            });
        });
    </script>--%>

   <br /> 
</div>

</asp:Panel>


<asp:Panel runat="server" ID="panHealthDE" Visible="false">

<asp:Panel runat="server" ID="panControl2">
<table>
<tr>
    <asp:ImageButton ID="imgReturn" runat="server" 
        ImageUrl="~/images/controlsIcon/return.png" ToolTip="Return" 
        CausesValidation="false" CssClass="imgReturn" onclick="imgReturn_Click"/>
    <asp:ImageButton ID="imgSave" runat="server" CssClass="imgSave"  
        ImageUrl="~/images/controlsIcon/save.png" ToolTip="Save" 
        onclick="imgSave_Click"
       />

</tr>  
</table>
</asp:Panel>



<div id="dLeft2">
<br />
<div id="dBriefInfo">
<fieldset>
<legend>Brief Info</legend>
<table>
<tr>
<td>Name: </td> <td><b><asp:Label runat="server" ID="lblStudentName"></asp:Label></b></td>
</tr>
<tr>
<td>Notify:</td><td><asp:Label runat="server" ID="lblEmergency"></asp:Label></td>
</tr>
<tr><td>Contact:</td><td><asp:Label runat="server" ID="lblContacts"></asp:Label></td></tr>
</table>
</fieldset>
<br />
<asp:Panel runat="server" ID="applicantClinicStatus">
Recommendation:&nbsp <asp:DropDownList runat="server" ID="ddClinicRecommendation" CssClass="dd"></asp:DropDownList>
</asp:Panel>
<br />
</div>
   
</div>



<div id="dTabPanel">

<asp:TabContainer ID="tcHealthEntry" runat="server">
    <asp:TabPanel runat="server" ID="tp1">
        <HeaderTemplate>
            Health Record Interview</HeaderTemplate>
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
<asp:TabPanel runat="server" ID="tpIllness"><HeaderTemplate>Illness / Medicine</HeaderTemplate><ContentTemplate>
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

