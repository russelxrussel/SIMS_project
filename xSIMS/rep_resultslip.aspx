<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rep_resultslip.aspx.cs" Inherits="rep_resulslip" MasterPageFile="SIMSMaster.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/resultSlip.css" rel="stylesheet" type="text/css" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="dMain">

      <div id="dHeader">
      <table>
      <tr>
      <td><asp:DropDownList runat="server" ID="ddSlipType" 
              AutoPostBack="True" CssClass="dropDownStyle" 
              onselectedindexchanged="ddSlipType_SelectedIndexChanged"></asp:DropDownList></td>
              <td>
              </td>
              <td  style="width: 50px"></td>
              <td><asp:DropDownList ID="ddLevelType" runat="server" 
        CssClass="dropDownStyle"></asp:DropDownList>
         <asp:ImageButton ID="imgSearchViaLevel" CssClass="imgSearch" runat="server" ImageUrl="~/images/controlsIcon/search.png"
        ToolTip="Search Applicant" onclick="imgSearchViaLevel_Click"/>
        </td>
      </tr>
      </table>
         </div>
      <hr />
     
      
     <%-- <div id="rcontent">      
          <CR:CrystalReportViewer ID="crv" runat="server" 
              AutoDataBind="true" EnableDatabaseLogonPrompt="False" 
              EnableParameterPrompt="False" HasToggleGroupTreeButton="False" 
              PrintMode="ActiveX" ToolPanelView="None" EnableDrillDown="False" HasCrystalLogo="False" HasPrintButton="False" HasDrilldownTabs="False" HasDrillUpButton="False"
                ReuseParameterValuesOnRefresh="True" HasToggleParameterPanelButton="False" Enabled="False" PageZoomFactor="100" HasZoomFactorList="False" BestFitPage="False"/>
    </div>--%>

    <asp:GridView runat="server" ID="gvApplicantResult" AutoGenerateColumns="False" 
            EnableModelValidation="True"
             CssClass="gview"
            EditRowStyle-CssClass="editrow"
            PagerStyle-CssClass="pgr" AllowPaging="True" 
             onpageindexchanging="gvApplicantResult_PageIndexChanging" PageSize="10" onrowdatabound="gvApplicantResult_RowDataBound"
            >
        <Columns>
            <asp:BoundField DataField="AppNum" ReadOnly="True" />
            <asp:BoundField DataField="FullName" ReadOnly="true" />
            <asp:TemplateField HeaderText="Date Created">
                <ItemTemplate>
                    <asp:TextBox ID="txtDated" runat="server" CssClass="calendarTextBox"></asp:TextBox>
                      <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDated">
                    </asp:CalendarExtender>      
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Address To">
            <ItemTemplate>
            <asp:TextBox runat="server" ID="txtAddressTo" CssClass="textBoxStyle"></asp:TextBox></ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Date Expired">
             <ItemTemplate>
                    <asp:TextBox ID="txtDateExpired" runat="server" CssClass="calendarTextBox"></asp:TextBox>
                     <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDateExpired" DefaultView="Days">
                    </asp:CalendarExtender>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="LeveltypeCode" ReadOnly="true"  ItemStyle-CssClass="hideColumn" HeaderStyle-CssClass="hideColumn"/>

            <asp:TemplateField HeaderText="Print">
            <ItemTemplate>
             <asp:ImageButton ID="imgPrint" runat="server" CssClass="imgPrint" 
                                            ImageAlign="Left" ImageUrl="~/images/controlsIcon/printer.png" 
                                           ToolTip="Print" OnClick="imgPrint_Click" />
            </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    
          

<EditRowStyle CssClass="editrow"></EditRowStyle>

<PagerStyle CssClass="pgr"></PagerStyle>
    
          

    </asp:GridView>



    </div>


</asp:Content>