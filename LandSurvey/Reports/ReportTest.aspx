<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportTest.aspx.cs" Inherits="LandSurvey.Reports.ReportTest" %>

<%@ Register assembly="Syncfusion.EJ.Web, Version=17.1460.0.32, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89" namespace="Syncfusion.JavaScript.Web" tagprefix="ej" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/jquery.validate.min.js"></script>
    <script src="../Scripts/ej.web.all.min.js"></script>
    <script src="../Scripts/ej.grid.min.js"></script>
    <script src="../Scripts/ej.unobtrusive.min.js"></script>
    <script src="../Scripts/jquery.validate.unobtrusive.min.js"></script>
    <link href="../Content/ej.widgets.core.min.css" rel="stylesheet" />
    <link href="../Content/ej.web.all.min.css" rel="stylesheet" />

   
          <style>
              .full-height {
                 height: 100%;
                }
          </style>
    <div>   
          
    <div> 
            <h3>Family Details </h3>
        </div>
    <br />
   <%-- <asp:updatepanel id="UpdatePanel1" runat="server" xmlns:asp="#unknown">
         <Contenttemplate>--%>
        <div class="row">
          
           <div class="col-sm-2" >Select Village Name :</div>
            <div class="col-sm-3"> <asp:DropDownList ID="cmbVillage" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbVillage_SelectedIndexChanged" CssClass="form-control" Width="250px">
                    </asp:DropDownList>
            </div>
           <div class="col-sm-2">Select Family Number :</div>
          <div class="col-sm-2"><asp:DropDownList ID="cmbFamilyNo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbFamily_SelectedIndexChanged" CssClass="form-control" Width="250px">
                    </asp:DropDownList>
              <div class="col-sm-1"> </div>
              <div class="col-sm-2"> </div>
          </div>
 
        </div>
     <%-- </Contenttemplate>
        </asp:updatepanel>--%>
        <br />

<%--        <asp:UpdatePanel ID="updatepn2" runat="server"> 
             <ContentTemplate> --%>
          <div>
                <ej:Grid ID="Grid1" runat="server"  AllowPaging="True" IsResponsive="True" OnServerPdfExporting="Grid1_ServerPdfExporting">
                    <ToolbarSettings ShowToolbar="true" ToolbarItems="excelExport,wordExport,pdfExport"></ToolbarSettings>
                    <%--<PageSettings PageSize="5"></PageSettings>--%>
                      <Columns>
                        <ej:Column Field="srno" HeaderText="Sr.No."  Width="50" />
                        <ej:Column Field="holdername" HeaderText="Holder Name" Width="125" HeaderTemplateID="#empTemplate"   />
                        <ej:Column Field="surveyno" HeaderText="Survey No."  Width="75" />
                        <ej:Column Field="surveyarea" HeaderText="Survey Area" Width="75" />
                        <ej:Column Field="holderarea" HeaderText="Holder Area" Width="75" /> 
                        <ej:Column Field="areaaquired" HeaderText="Aquired Area" Width="75" />
                    </Columns>
                </ej:Grid>
        </div>
       <%--</contenttemplate>
              <Triggers> 
              <asp:PostBackTrigger controlid="Grid1"/> 
             </Triggers> 
        </asp:updatepanel>--%>
        <br />

   <br />
    <br />
                  
        </div> 
</asp:Content>
