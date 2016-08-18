<%@ Page Title="" Language="C#" MasterPageFile="~/SIMSMaster.master" AutoEventWireup="true" CodeFile="heaSetUp.aspx.cs" Inherits="heaSetUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/HealthEntry.css" rel="stylesheet" type="text/css" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divHeaSetUp">


<div id="divHeaContainer">
<asp:UpdatePanel runat="server" ID="upHealthSetUp">
<ContentTemplate>

    <asp:Panel runat="server" id="panMedicineEntry">
  <div id="divHeaMedicineEntry">
     <table>
     <tr>
     <td>Medicine Code:</td><td><asp:TextBox runat="server" MaxLength="3" ID="txtMedicineCode" CssClass="txtInput_Short_UPPER"></asp:TextBox></td>
     </tr>
     <tr>
     <td>Medicine Desc:</td><td><asp:TextBox runat="server" ID="txtMedicineDesc" CssClass="txtInput_UPPER"></asp:TextBox></td>
     </tr>
     <tr>
     <td>Generic Name:</td><td><asp:TextBox runat="server" ID="txtGenericName" CssClass="txtInput_UPPER"></asp:TextBox></td>
     </tr>
     <tr>
     <td>Medicine Type:</td><td><asp:DropDownList runat="server" ID="ddMedicineType" CssClass="dropdown_ver_lightBlue"></asp:DropDownList></td>
     </tr>
      <tr>
     <td>Medicine Level:</td><td><asp:DropDownList runat="server" ID="ddMedicineLevel" CssClass="dropdown_ver_lightBlue"></asp:DropDownList></td>
     </tr>
     <tr>
     <td></td><td><asp:LinkButton runat="server" ID="lnkSave" Text="Save" onclick="lnkSave_Click" CssClass="lnkControl"></asp:LinkButton></td>
     </tr>
 </table>
    </div>
    </asp:Panel>


</ContentTemplate>
</asp:UpdatePanel>

</div>

</div>
</asp:Content>

