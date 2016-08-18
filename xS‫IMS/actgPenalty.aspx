<%@ Page Title="" Language="C#" MasterPageFile="~/SIMSMaster.master" AutoEventWireup="true" CodeFile="actgPenalty.aspx.cs" Inherits="actgPenalty" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <link href="css/Penalty.css" rel="stylesheet" type="text/css" />

  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="container">

      <div id="penalty">

        <h2><span class="fontawesome-lock"></span>Penalty Computation</h2>

        <form action="#" method="POST">

          <fieldset>
                                   
                      <p><label for="sy">School Year</label></p>
                      <p>
                         <asp:DropDownList type="dpMOP" ID="drpSY" runat="server">
                          </asp:DropDownList>
                      </p>
                     

                      <p><label for="mop">Mode of Payment</label></p>
                      <p>
                          <asp:DropDownList type="dpMOP" ID="drpMOP" runat="server">
                          </asp:DropDownList>
                      </p>


                      <p><label for="dueDate">Due Date</label></p>
                      <p>
                     
                    <asp:TextBox type="txtduedate" ID="txtDated" runat="server" placeholder="Date"></asp:TextBox>
                      <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDated">
                    </asp:CalendarExtender>      
               
                      </p>
                      
                     <div class="line-separator"></div>
              <asp:Button type="submit" ID="Button1" runat="server" Text="Process" 
                          onclick="Button1_Click" />
              <asp:Button type="submit" ID="Button2" runat="server" Text="Verify" 
                          onclick="Button2_Click" />
               <asp:Button type="submit" ID="Button3" runat="server" Text="Send" 
                          onclick="Button3_Click" />

          </fieldset>

        </form>

      </div> <!-- end penalty -->

    </div>
</asp:Content>

