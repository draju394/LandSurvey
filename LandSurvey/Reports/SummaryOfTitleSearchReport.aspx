<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SummaryOfTitleSearchReport.aspx.cs" Inherits="LandSurvey.Reports.SummaryOfTitleSearchReport" %>

<%@ Register Assembly="Syncfusion.EJ.Web, Version=17.1460.0.32, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89" Namespace="Syncfusion.JavaScript.Web" TagPrefix="ej" %>
<%@ Register Assembly="Syncfusion.EJ" Namespace="Syncfusion.JavaScript.Models" TagPrefix="ej" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/jquery.validate.min.js"></script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <script src="../Scripts/ej.web.all.min.js"></script>
    <script src="../Scripts/ej.grid.min.js"></script>
    <script src="../Scripts/ej.unobtrusive.min.js"></script>
    <script src="../Scripts/jquery.validate.unobtrusive.min.js"></script>
    <link href="../Content/ej.widgets.core.min.css" rel="stylesheet" />
    <link href="../Content/ej.web.all.min.css" rel="stylesheet" />



    <script type="text/javascript">  
        function onprerender(sender) {
            var length = sender.model.series[0].points.length - 1;

            sender.model.series[0].points[0].fill = "#f549b0";
            sender.model.series[0].points[1].fill = "#9ff549";
            sender.model.series[0].points[2].fill = "#e3f542";
            sender.model.series[0].points[3].fill = "#a0e33b";
            sender.model.series[0].points[4].fill = "#49f59c";
            sender.model.series[0].points[5].fill = "#49f5db";
            sender.model.series[0].points[6].fill = "#49a5f5";
            sender.model.series[0].points[7].fill = "#a249f5";
            sender.model.series[0].points[8].fill = "#ca49f5";
            sender.model.series[0].points[9].fill = "#f549f2";


        }
    </script>
    <style>
        .full-height {
            height: 100%;
        }
    </style>
    <div>
        <div class="row" style="background-color: #f1c371; height: 35px; padding-top: 5px; border-radius: 5px 5px 5px 5px;">
            <div class="col-md-5">
                <label for="" style="color: saddlebrown; font-size: 18px;">Summary Of Title Search Report</label>
                <label for="" style="color: white; font-size: 18px;" id="PopulationID"></label>
            </div>
            <%-- <div class="col-md-2">
                 <label for="" style="color:white;font-size: 18px;">बूथ संख्या :-</label>
                <label for="" style="color: white;font-size: 18px;" id="Booth_numberID"></label>
            </div>--%>
            <%--  <div class="col-md-2">
                 <label for="" style="color:white;font-size:18px;"> मतदारसंघ :</label>
                <label for="" style="color:white;font-size: 18px;" id="Vidhansabha_Id"></label>
            </div>--%>
        </div>

        <div>
            <h3></h3>
        </div>

        <%-- <asp:updatepanel id="UpdatePanel1" runat="server" xmlns:asp="#unknown">
         <Contenttemplate>--%>
        <div class="row">
            <div class="col-sm-2">
                Select Village :
            </div>
            <div class="col-sm-3">
                <asp:DropDownList ID="cmbVillage" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbVillage_SelectedIndexChanged"
                    CssClass="form-control" Width="250px">
                </asp:DropDownList>
            </div>
            <div class="col-sm-2">
            </div>
            <div class="col-sm-2">
            </div>
            <div class="col-sm-4">
            </div>
        </div>
        <%-- </Contenttemplate>
        </asp:updatepanel>--%>
        <br />
        <%--        <asp:UpdatePanel ID="updatepn2" runat="server"> 
             <ContentTemplate> --%>
        <div>
            <ej:Grid ID="Grid1" runat="server" AllowPaging="True" IsResponsive="True" AllowTextWrap="true" OnServerPdfExporting="Grid1_ServerPdfExporting">
                <ToolbarSettings ShowToolbar="true" ToolbarItems="excelExport,wordExport,pdfExport"></ToolbarSettings>
                <PageSettings PageSize="5"></PageSettings>
                <TextWrapSettings WrapMode="Both" />
                <Columns>
                    <ej:Column Field="Documents Planned" HeaderText="Documents Planned" AllowTextWrap="true" Width="75" />
                    <ej:Column Field="Mutation Search Report" HeaderText="Mutation Search Report" AllowTextWrap="true" Width="80" />
                    <ej:Column Field="Registry Search Report" HeaderText="Registry Search Report" AllowTextWrap="true" Width="80" />
                    <ej:Column Field="Primary Title Search" HeaderText="Primary Title Search" AllowTextWrap="true" Width="75" />
                    <ej:Column Field="Public Notice" HeaderText="Public Notice" AllowTextWrap="true" Width="50" />
                    <ej:Column Field="Final Title Search" HeaderText="Final Title Search" AllowTextWrap="true" Width="75" />
                    <ej:Column Field="Approved by Solicitor" HeaderText="Approved by Solicitor" AllowTextWrap="true" Width="85" />
                    <ej:Column Field="Approved by Client" HeaderText="Approved by Client" AllowTextWrap="true" Width="80" />
                    <ej:Column Field="Inputs for Public Notice" HeaderText="Inputs for Public Notice" AllowTextWrap="true" Width="80" />
                    <ej:Column Field="Clarifications from Head Office" HeaderText="Clarifications from Head Office" AllowTextWrap="true" Width="80" />
                </Columns>
            </ej:Grid>

        </div>

        <div>
            <ej:Chart ID="Chart1" SeriesType="Column" Text="Summary of Title Search" ToolTip="true" BorderColor="Black" XName="Column1" YName="Column2" runat="server" OnClientPreRender="onprerender">
                <Legend Visible="false"></Legend>
                <Series>
                </Series>
            </ej:Chart>


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
