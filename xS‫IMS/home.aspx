<%@ Page Title="" Language="C#" MasterPageFile="~/SIMSMaster.master" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly=" System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"  Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/home.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
    .linkCenter 
    {
    text-align: center;
    width:20px;
    }
    
    </style>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:UpdatePanel runat="server" ID="upDashBoard" >
<ContentTemplate>


<div id="dashTitle" class="dashboardTitle">Dashboard: </div> 

<br />
<asp:Panel runat="server" ID="panAdmissionDash">
<div id="mainAdmssionDash">
<div id="leftAdmDash">
    <div id="leftAdmRow1">
   <asp:Label runat="server" class="appStatLabel">Applicant Statistics </asp:Label>

   <asp:LinkButton runat="server" ID="lnkTotalCountApplicant" CssClass="totalAppCount" 
            onclick="lnkTotalCountApplicant_Click">
  </asp:LinkButton>

 <div id="dAppStatCount">
<%--   <div id="header" class="dHeader">Applicant Stat - Count</div>
--%>
   <asp:Panel ID="genControl" runat="server" Width="400px">

  <!-- This area hold the dynamic controls created --> 
   </asp:Panel>
    
  <%-- <div id="dWLSSIC">

   <div class="divBackWL" id="dWL">
   <asp:Label runat="server" ID="lblWaitListed" CssClass="lblDynamicTitle">WL</asp:Label>
   <asp:LinkButton runat="server" ID="lnkWaitListed" CssClass="lblDynamicLinkValue" 
           onclick="lnkWaitListed_Click"></asp:LinkButton>
   </div>

   <div class="divBackSSI" id="SSIC">
   <asp:Label runat="server" ID="ssiChild" CssClass="lblDynamicTitle">SC</asp:Label>
    <asp:LinkButton runat="server" ID="lnkssiChild" CssClass="lblDynamicLinkValue" 
           onclick="lnkssiChild_Click"></asp:LinkButton>
   </div>
   </div>--%>

   </div>

    </div>

    <div id="leftAdmRow2">

        <div id="leftAdmCol1">
       
        
        </div>

        <div id="leftAdmCol2">
                     <div id="leftCol2Row1">
                     <asp:LinkButton runat="server" ID="lnkAppMaleCount" CssClass="countAppMale" 
                             onclick="lnkAppMaleCount_Click"></asp:LinkButton>
                    </div>

                    <div id="leftCol2Row2">
                    <asp:LinkButton runat="server" ID="lnkAppFemaleCount" CssClass="countAppFemale" 
                            onclick="lnkAppFemaleCount_Click"></asp:LinkButton>
                    </div>
        </div>
    </div>

</div>

<div id="rightAdmDash">

<!--Row1 Reserved Total-->
<div id ="rightAdmRow1">
 <asp:Label runat="server" ID="lblReservedStat" CssClass="appStatLabel">
 Reserved Statistics
 </asp:Label>
 <asp:LinkButton runat="server" ID="lnkTotalReservedCount" CssClass="TotalReservedCount"> </asp:LinkButton>
  <div id="divReserveTable">
        <asp:Label ID="Label1" runat="server">NEW</asp:Label>
        <asp:GridView ID="gvListOfReserveNew" runat="server" EnableModelValidation="True"
            CellPadding="1" Font-Names="Calibri" Font-Size="9pt" AutoGenerateColumns="False"
            CssClass="linkCenter" Width="350px">
            <Columns>
                <asp:TemplateField HeaderText="P1">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("P1") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="P2">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("P2") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="P3">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("P3") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="G1">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("G1") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="G2">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("G2") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="G3">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("G3") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="G4">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("G4") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="G5">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("G5") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="G6">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("G6") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="G7">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("G7") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="G8">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("G8") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="G9">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("G9") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="G10">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("G10") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="G11">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("G11") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TOTAL">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("TOTAL") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="Label2" runat="server">OLD</asp:Label>
        <asp:GridView ID="gvListOfReserve" runat="server" CellPadding="1"
            Font-Names="Calibri" Font-Size="9pt" AutoGenerateColumns="False" Width="350px"
            CssClass="linkCenter">
            <Columns>
                <asp:TemplateField HeaderText="P1">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("P1") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="P2">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("P2") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="P3">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("P3") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="G1">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("G1") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="G2">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("G2") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="G3">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("G3") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="G4">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("G4") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="G5">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("G5") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="G6">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("G6") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="G7">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("G7") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="G8">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("G8") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="G9">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("G9") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="G10">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("G10") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="G11">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("G11") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TOTAL">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("TOTAL") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
         <asp:Label ID="Label3" runat="server">TOTAL</asp:Label>
        <asp:GridView ID="gvListTotalReserve" runat="server" CellPadding="1"
            Font-Names="Calibri" Font-Size="9pt" AutoGenerateColumns="False" Width="350px"
            CssClass="linkCenter">
            <Columns>
                <asp:TemplateField HeaderText="P1">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("P1") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="P2">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("P2") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="P3">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("P3") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="G1">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("G1") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="G2">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("G2") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="G3">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("G3") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="G4">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("G4") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="G5">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("G5") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="G6">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("G6") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="G7">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("G7") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="G8">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("G8") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="G9">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("G9") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="G10">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("G10") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="G11">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("G11") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TOTAL">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkLevel" Text='<%# Eval("TOTAL") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        
    </div>  




</div>
<div id="rightAdmRow2">
 
<div id="rightAdmCol1">
</div>
<div id="rightAdmCol2"></div>
</div>
</div>

</div>
</asp:Panel>


  
<%--Every Item have panel to control what user can view or access
Code is dsh1....n
Russel Vasquez 10/06/2015--%>



<%--<asp:Panel runat="server" ID="dsh1">
 Reserved Student
<div id="dAdmissionCurrentStat">  

 <div id="Div2" class="classStat">Admission Statistics Overview</div>  

 <asp:Accordion ID="Accordion1" runat="server" HeaderCssClass="accHeaderClass" HeaderSelectedCssClass="accHeaderSelectedClass" TransitionDuration="300">
 
 <Panes>
 
 <asp:AccordionPane runat="server" ID="AccordionPanel1" >
    <Header>Applicant Stat Count</Header>
    <Content>

 </Content>
 </asp:AccordionPane>
 </Panes>     



 <Panes>
 <asp:AccordionPane runat="server" ID="apReserved">
 <Header>Reserved Student Stat Count</Header>
 <Content>
  <h1>Reserved Student Stat Count</h1>
  

 </Content>
 </asp:AccordionPane>
 </Panes>


 
  </asp:Accordion> 

 </div>

</asp:Panel>
--%>


<asp:Panel runat="server" ID="dsh2"> 

<div id="SlotTable">
<div id="subSlotTable" class="classSlotTable">Admission Slot Overview</div>

<asp:GridView ID="gvSlotDetails" runat="server" AutoGenerateColumns="False" 
           CellPadding="3" EnableModelValidation="True" ForeColor="#333333" 
           GridLines="Horizontal" Width="400px" Font-Names="Calibri" Font-Size="14px">
          
           <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
           <Columns>
               <asp:BoundField DataField="LevelTypeCode" HeaderText="Level" ReadOnly="True" >
               <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15px" />
               <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15px" />
               </asp:BoundField>
               <asp:BoundField DataField="StudentCount" HeaderText="Target Student" >
               <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15px" />
               <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15px" />
               </asp:BoundField>
               <asp:TemplateField HeaderText="Closed">
                   <ItemTemplate>
                       <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="#"
                           Text='<%# Eval("ClosedSlot") %>'></asp:HyperLink>
                   </ItemTemplate>
                   <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20px" />
                   <ItemStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" 
                       Width="20px" />
               </asp:TemplateField>
               <asp:BoundField DataField="OpenSlot" HeaderText="Open" ReadOnly="True" >
               <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20px" />
               <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20px" 
                   Font-Bold="True" ForeColor="#CC0000" BackColor="#FFFFCC" />
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

</asp:Panel>




<asp:Panel ID="dsh3" runat="server" Visible="false">
<div id="dTargetStudentChart">
<div id="Div1" class="classGraphTargetStudent">Target Student Overview</div>
<asp:Panel runat="server" ID="panChart" Width="300px">
       <asp:Chart ID="Chart1" runat="server" 
             Height="300px" Width="500px" BackImageAlignment="Left">
         
           
           <Titles>
           <asp:Title Name="Title1" Alignment="TopLeft" Font="Verdana, 10pt, style=Bold">
           
           </asp:Title>

           </Titles>
           
           
           <Series>
           
               <asp:Series Name="Series1" 
                   CustomProperties="DrawingStyle=Cylinder, MaxPixelPointWidth=50" 
                   ShadowOffset="2" Color="White" IsValueShownAsLabel="true" 
                   IsXValueIndexed="false" Palette="BrightPastel" YAxisType="Primary" 
                   XAxisType="Primary" Font="Calibri, 8.25pt" BackImageAlignment="Left">
              
               </asp:Series>
           </Series>

                

           <ChartAreas>
               <asp:ChartArea Name="ChartArea1" BorderWidth="2" AlignmentOrientation="Horizontal" 
                   Area3DStyle-Enable3D="true" Area3DStyle-LightStyle="Simplistic" 
                   IsSameFontSizeForAllAxes="True" Area3DStyle-Perspective="0" 
                   Area3DStyle-Rotation="0" Area3DStyle-WallWidth="8" AlignmentStyle="All" 
                   ShadowOffset="2" BackColor="White" ShadowColor="White" 
                   BackImageAlignment="Left">
              
                   <axisy islabelautofit="False">
                       <LabelStyle Font="Calibri, 8.25pt" />
                   </axisy>
                   <axisx>
                       <majorgrid enabled="False" />

                   </axisx>
                   <Area3DStyle Enable3D="True" Rotation="0" />
              
                   <Area3DStyle Enable3D="True" Rotation="0" />
              
                   <Area3DStyle Enable3D="True" Rotation="0" />
              
                   <Area3DStyle Enable3D="True" Rotation="0" />
              
               </asp:ChartArea>
           </ChartAreas>



        
       </asp:Chart>
   </asp:Panel>

   </div>

</asp:Panel>


   

</ContentTemplate>
</asp:UpdatePanel>
   
  
</asp:Content>

