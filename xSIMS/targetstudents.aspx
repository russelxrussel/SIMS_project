<%@ Page Title="" Language="C#" MasterPageFile="~/SIMSMaster.master" AutoEventWireup="true" CodeFile="targetstudents.aspx.cs" Inherits="targetstudents" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register src="UserControls/ucGradeText.ascx" tagname="ucGradeText" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/TargetApplicant.css" rel="stylesheet" type="text/css" />
     <link href="css/ControlsStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



<asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
<ContentTemplate>

<div id="entry">
<table>
<tr><td>Level Category: </td><td>
    <asp:DropDownList ID="ddLevelCategory" runat="server" AutoPostBack="True" 
        onselectedindexchanged="ddLevelCategory_SelectedIndexChanged" CssClass="dropDownStyle">
    </asp:DropDownList>
</td></tr>
<tr><td>Level Type: </td><td><asp:DropDownList ID="ddLevelType" runat="server" 
        CssClass="dropDownStyle" AutoPostBack="True" 
        onselectedindexchanged="ddLevelType_SelectedIndexChanged">
    </asp:DropDownList></td></tr>
<tr>
<td>Strand:</td>
<td><asp:DropDownList ID="ddStrand" runat="server" CssClass="dropDownStyle">
    </asp:DropDownList></td>
</tr>
<tr>
<td>Regular Slot:</td>
<td><asp:TextBox runat="server" ID="txtRegularCount" CssClass="textBoxStyle_Grades"></asp:TextBox><asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtRegularCount" FilterType="Numbers">
                    </asp:FilteredTextBoxExtender></td>
</tr>
<tr>
<td>SSI Child Slot:</td>
<td><asp:TextBox runat="server" ID="txtSSICCount" CssClass="textBoxStyle_Grades"></asp:TextBox><asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtSSICCount" FilterType="Numbers">
                    </asp:FilteredTextBoxExtender></td>
</tr>

<tr><td>Remarks:</td><td>
<asp:TextBox runat="server" ID="txtRemarks" TextMode="MultiLine" Width="150px" Height="50px" MaxLength="250"></asp:TextBox>
<asp:TextBox runat="server" ID="txtStudentCount" CssClass="textBoxStyle_Grades" Enabled="false" Visible="false"></asp:TextBox><asp:FilteredTextBoxExtender ID="Filtered12" runat="server" TargetControlID="txtStudentCount" FilterType="Numbers">
                    </asp:FilteredTextBoxExtender>&nbsp<asp:ImageButton runat="server" id="imgNew" 
        ImageUrl="~/images/controlsIcon/new.png" onclick="imgNew_Click" CssClass="imgNew" ToolTip="Add Target No of Students" /></td></tr>
</table>
</div>


<div id="dataContent">
  <asp:GridView runat="server" ID="gvTargetStudents" CssClass="gview" Width="400px" 
        AutoGenerateColumns="False" EnableModelValidation="True" DataKeyNames="ID"
        onrowediting="gvTargetStudents_RowEditing" 
        onrowcancelingedit="gvTargetStudents_RowCancelingEdit" 
        onrowupdating="gvTargetStudents_RowUpdating">
  
      <Columns>
          <asp:BoundField DataField="id" ItemStyle-CssClass="hideColumn" 
              HeaderStyle-CssClass="hideColumn" >
          <HeaderStyle CssClass="hideColumn" />
          <ItemStyle CssClass="hideColumn" />
          </asp:BoundField>
          <asp:BoundField DataField="leveltypecode" HeaderText="Level Type" ReadOnly="true"/>
          <asp:BoundField DataField="strandcode" HeaderText="Strand" ReadOnly="true" />
          <asp:TemplateField HeaderText="Regular">
              <EditItemTemplate>
                  <asp:TextBox ID="txtRegularCount" runat="server" CssClass="textBoxStyle_Grades" Text='<%# Bind("regularcount") %>'></asp:TextBox>
             <asp:FilteredTextBoxExtender ID="Filtered12" runat="server" TargetControlID="txtRegularCount" FilterType="Numbers">
                    </asp:FilteredTextBoxExtender>
              </EditItemTemplate>
              <ItemTemplate>
                  <asp:Label ID="Label1" runat="server" Text='<%# Bind("regularcount") %>'></asp:Label>
              </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="SSI Child">
              <EditItemTemplate>
                  <asp:TextBox ID="txtSSICCount" runat="server" CssClass="textBoxStyle_Grades" Text='<%# Bind("ssiccount") %>'></asp:TextBox>
               <asp:FilteredTextBoxExtender ID="Filtered13" runat="server" TargetControlID="txtSSICCount" FilterType="Numbers">
                    </asp:FilteredTextBoxExtender>
              </EditItemTemplate>
              <ItemTemplate>
                  <asp:Label ID="Label2" runat="server" Text='<%# Bind("ssiccount") %>'></asp:Label>
              </ItemTemplate>
          </asp:TemplateField>

          <asp:BoundField DataField="studentcount" HeaderText="Total" ReadOnly="true" />
          
          <asp:TemplateField HeaderText="Remarks">
              <EditItemTemplate>
                  <asp:TextBox ID="txtRemarks" runat="server" Text='<%# Bind("Remarks") %>'></asp:TextBox>

              </EditItemTemplate>
              <ItemTemplate>
                  <asp:Label ID="Label3" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
              </ItemTemplate>
          </asp:TemplateField>

          <asp:CommandField ShowEditButton="True" />
      </Columns>
  
  </asp:GridView>

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

