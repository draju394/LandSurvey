<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RptVillageMaster.aspx.cs" Inherits="LandSurvey.Reports.RptVillageMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/jquery.validate.min.js"></script>
    <script src="../Scripts/ej.web.all.min.js"></script>
    <script src="../Scripts/ej.grid.min.js"></script>
    <script src="../Scripts/ej.unobtrusive.min.js"></script>
    <script src="../Scripts/jquery.validate.unobtrusive.min.js"></script>
    <link href="../Content/ej.widgets.core.min.css" rel="stylesheet" />
    <link href="../Content/ej.web.all.min.css" rel="stylesheet" />
    
        
        <div> 
            <h3>Village Details </h3>
        </div>
   
          <div>
                <ej:Grid ID="grdVillageM" runat="server"  AllowPaging="True" IsResponsive="True" OnServerPdfExporting="grdVillageM_ServerPdfExporting" >
                    <ToolbarSettings ShowToolbar="true" ToolbarItems="excelExport,wordExport,pdfExport"></ToolbarSettings>
                    <%--<PageSettings PageSize="5"></PageSettings>--%>
                      <Columns>
                        <ej:Column Field="srno" HeaderText="Sr.No."  Width="50" />
                        <ej:Column Field="villagecode" HeaderText="Village Code" Width="125" HeaderTemplateID="#empTemplate"   />
                        <ej:Column Field="villagename" HeaderText="Village Name"  Width="75" />
                        <ej:Column Field="villagemname" HeaderText="Village Marathi Name" Width="75" />
                        <ej:Column Field="districtid" HeaderText="District" Width="75" /> 
                        <ej:Column Field="talukaid" HeaderText="Taluka" Width="75" />
                    </Columns>
                </ej:Grid>
        </div>
       
        <br />

   <br />
    <br />

</asp:Content>
