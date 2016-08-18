<%@ Page Title="" Language="C#" MasterPageFile="~/SIMSMaster.master" AutoEventWireup="true" CodeFile="admScreeningSetup.aspx.cs" Inherits="admScreeningSetup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/ScheduleSetup.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
     
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>Screening Setup</div>

<br />
<asp:UpdatePanel runat="server" ID="upScreeningSetup" UpdateMode="Conditional">
<ContentTemplate>

<div id="MainExamDetailsDiv">
    <div id="CreateExamDiv">
        <table cellspacing="5px" cellpadding="2px">
            <tr>
                <td align="right">
                    Type:
                </td>
                 <td>
                    <asp:DropDownList ID="ddScreeningType" runat="server" CssClass="dropDownStyle">
                    </asp:DropDownList>
                </td>
            </tr>
              <tr>
              <td align="right">Date:</td>
              <td>
                    <jrv:ucCalendar ID="ucScreeningDate" runat="server" />
                </td>
              </tr>  

              <tr>
              <td align="right">Time:</td>
                              <td>
                    <asp:TextBox ID="ScreningTime" runat="server" CssClass="calendarTextBox"></asp:TextBox>
                    <asp:MaskedEditExtender
                        ID="MaskedEditExtender1" runat="server" TargetControlID="ScreningTime" AcceptAMPM="true"
                        MaskType="Time" Mask="99:99">
                    </asp:MaskedEditExtender>
          
                </td>

              </tr>

              <tr>
               <td align="right">Slot:</td>
                              <td>
                                  <asp:DropDownList ID="ddSchedAvailSlot" runat="server" CssClass="dropDownStyle">
                                  </asp:DropDownList>
          
                </td>

              </tr>

              <tr>
              <td align="right">Desc:</td>
              <td><asp:TextBox runat="server" ID="txtExamDescription" TextMode="MultiLine" 
                      Font-Names="Calibri" Font-Size="11pt" Width="175px"></asp:TextBox></td>
              </tr>
                
                <tr>
                <td>
                </td>

                <td>
                 <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Create" />
                </td>
                </tr>
        </table>

   
    
    </div>

    <div id="ModiftExamDiv">
           <asp:GridView ID="gvScreening" runat="server" DataSourceID="sqlScreeningSetup" 
        EnableModelValidation="True" AutoGenerateColumns="False" CellPadding="4" 
        ForeColor="#333333" Font-Names="Calibri" Font-Size="11pt" AllowPaging="True" 
            onrowdatabound="gvScreening_RowDataBound" DataKeyNames="ID" 
            onrowupdating="gvScreening_RowUpdating"
              CssClass="gview"
              
              PagerStyle-CssClass="pgr"> 
        <Columns>
            <asp:TemplateField HeaderText="Status">
            <ItemTemplate>
                <asp:Image ID="imgIcon" runat="server" />
            </ItemTemplate>

                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />

            </asp:TemplateField>
            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True"  ItemStyle-CssClass="hideColumn" HeaderStyle-CssClass="hideColumn"/>
            <asp:TemplateField HeaderText="Type">
                <ItemTemplate>
                    <asp:Label ID="lblExamType" runat="server" Text='<%# Eval("ScreeningCode").ToString() == "E" ? "Examination" : "Interview" %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Date"> 
                <ItemTemplate>
                <asp:Label runat="server" ID="lblExamDate" Text='<%# Eval("Sdate", "{0:MM/dd/yyyy}") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtExamDate" runat="server" Text='<%# Eval("Sdate", "{0:MM/dd/yyyy}") %>' CssClass="calendarTextBox"></asp:TextBox>
                    <asp:MaskedEditExtender ID="meeCalendar" runat="server" TargetControlID="txtExamDate"
                        Mask="99/99/9999" MessageValidatorTip="true" ErrorTooltipEnabled="true" MaskType="Date"
                        InputDirection="LeftToRight">
                    </asp:MaskedEditExtender>
                    <asp:MaskedEditValidator ID="mevCalendar" runat="server" ControlToValidate="txtExamDate"
                        ControlExtender="meeCalendar" Display="Dynamic" InvalidValueMessage="Date not Valid"
                        InvalidValueBlurredMessage="*" IsValidEmpty="false"></asp:MaskedEditValidator>
                    <asp:RequiredFieldValidator ID="rfvCalendar" runat="server" ErrorMessage="Date Requrired"
                        Text="*" ControlToValidate="txtExamDate" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CalendarExtender ID="ceDOA" runat="server" TargetControlID="txtExamDate">
                    </asp:CalendarExtender>
                </EditItemTemplate>
            
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Time">
            <ItemTemplate>
            <asp:Label runat="server" ID="lblExamTime" Text='<%# Eval("Stime", "{0:t}") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
            <asp:TextBox ID="txtExamTime" runat="server" Text='<%# Eval("Stime", "{0:t}") %>' CssClass="calendarTextBox"></asp:TextBox>
            <asp:MaskedEditExtender
                        ID="MaskedEditExtender1" runat="server" TargetControlID="txtExamTime" AcceptAMPM="true"
                        MaskType="Time" Mask="99:99">
                    </asp:MaskedEditExtender>
                   
            </EditItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Available">
                <EditItemTemplate>
                    <asp:TextBox ID="txtSlotAvailable" runat="server" Text='<%# Eval("ScheduleAvailableSlot") %>' align="center" CssClass="textBoxStyle_min"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblSlotAvailable" runat="server" Text='<%# Eval("ScheduleAvailableSlot") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Description">
            <EditItemTemplate>
                        <asp:TextBox ID="txtExamDesc" runat="server" Text='<%# Eval("SDesc") %>' Font-Size="10pt" Font-Names="Calibri"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                        <asp:Label ID="lblExamDesc" runat="server" Text='<%# Eval("SDesc") %>'></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
             
            <asp:BoundField DataField="SY" ReadOnly="True" ItemStyle-CssClass="hideColumn" HeaderStyle-CssClass="hideColumn" />
            <asp:CommandField ShowEditButton="True" 
                CancelImageUrl="~/images/controlsIcon/cancel_sched.png" 
                EditImageUrl="~/images/controlsIcon/edit_sched.png" 
                UpdateImageUrl="~/images/controlsIcon/update_sched.png" 
                ButtonType="Image" CausesValidation="False" />
        </Columns>
        <PagerStyle CssClass="pgr" />
    </asp:GridView>

    <asp:SqlDataSource ID="sqlScreeningSetup" runat="server" 
        ConnectionString="<%$ ConnectionStrings:CSSIMS %>" 
        InsertCommand="INSERT INTO Admission.ScreeningSetup_RF ([SY], [ScreeningCode], [Sdate], [Stime], [SDesc], [STitle],[ScheduleAvailableSlot],  [DI], [UserCode]) VALUES (@SY, @ScreeningCode, @Sdate, @Stime, @SDesc, @STitle,@ScheduleAvailableSlot, @DI, @UserCode)" 
        SelectCommand="SELECT * FROM Admission.ScreeningSetup_RF ORDER By Sdate Desc" 
        UpdateCommand="UPDATE Admission.ScreeningSetup_RF SET Sdate=@Sdate, Stime=@Stime, SDesc=@SDesc, STitle=@STitle,ScheduleAvailableSlot=@ScheduleAvailableSlot, DU=@DU, UserCode=@UserCode WHERE [id] = @id" 
        >
         
        <InsertParameters>
            <asp:Parameter Name="SY" Type="String" />
            <asp:Parameter Name="ScreeningCode" Type="String" />
            <asp:Parameter DbType="Date" Name="Sdate" />
            <asp:Parameter Name="Stime" Type="String" />
            <asp:Parameter Name="SDesc" Type="String" />
            <asp:Parameter Name="STitle" Type="String" />
            <asp:Parameter Name="ScheduleAvailableSlot" Type="Int32" />
            <asp:Parameter Name="DI" Type="DateTime" />
            <asp:Parameter Name="UserCode" Type="String" />
        </InsertParameters>

        <UpdateParameters>
            <asp:Parameter DbType="Date" Name="Sdate" />
            <asp:Parameter Name="Stime" Type="String" />
            <asp:Parameter Name="SDesc" Type="String" />
            <asp:Parameter Name="STitle" Type="String" />
            <asp:Parameter Name="ScheduleAvailableSlot" Type="Int32" />
            <asp:Parameter Name="DU" Type="DateTime" />
            <asp:Parameter Name="UserCode" Type="String" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</div>
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




</asp:UpdatePanel> <%--End of Update Panel--%>

</asp:Content>

