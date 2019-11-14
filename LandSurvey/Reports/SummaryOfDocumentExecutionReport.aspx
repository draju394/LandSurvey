<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SummaryOfDocumentExecutionReport.aspx.cs" Inherits="LandSurvey.Reports.SummaryOfDocumentExecutionReport" %>

<%@ Register Assembly="Syncfusion.EJ.Web, Version=17.1460.0.32, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89" Namespace="Syncfusion.JavaScript.Web" TagPrefix="ej" %>
<%@ Register Assembly="Syncfusion.EJ" Namespace="Syncfusion.JavaScript.Models" TagPrefix="ej" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/jquery.validate.min.js"></script>
    <script src="../Scripts/ej.web.all.min.js"></script>
    <script src="../Scripts/ej.grid.min.js"></script>
    <script src="../Scripts/ej.unobtrusive.min.js"></script>
    <script src="../Scripts/jquery.validate.unobtrusive.min.js"></script>
    <link href="../Content/ej.widgets.core.min.css" rel="stylesheet" />
    <link href="../Content/ej.web.all.min.css" rel="stylesheet" />

    <!--  jquery script 
    <script src="https://cdn.syncfusion.com/js/assets/external/jquery-1.10.2.min.js"></script>
     Essential JS UI widget  
    <script src="https://cdn.syncfusion.com/17.3.0.9/js/web/ej.web.all.min.js"></script> -->

    <style>
        .full-height {
            height: 100%;
        }
    </style>

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
        }

        //var chartData = [
        //    { month: 'Jan', sales: 35 },
        //    { month: 'Feb', sales: 28 },
        //    { month: 'Mar', sales: 34 },
        //    { month: 'Apr', sales: 32 },
        //    { month: 'May', sales: 40 },
        //    { month: 'Jun', sales: 32 },
        //    { month: 'Jul', sales: 35 },
        //    { month: 'Aug', sales: 55 },
        //    { month: 'Sep', sales: 38 },
        //    { month: 'Oct', sales: 30 },
        //    { month: 'Nov', sales: 25 },
        //    { month: 'Dec', sales: 32 }];

        //$(function () {
        //    $("#container").ejChart({
        //        series: [{

        //            type: 'line',
        //            dataSource: chartData,
        //            xName: "month",
        //            yName: "sales",
        //            primaryYAxis: {
        //                //Customize the axis label format.
        //                labelFormat: '${value}K'
        //            },
        //            series: [{
        //                marker: {
        //                    dataLabel: {
        //                        visible: true
        //                    }
        //                }
        //            }],
        //        }],
        //    });

    </script>

    <div>
        <div class="row" style="background-color: #f1c371; height: 35px; padding-top: 5px; border-radius: 5px 5px 5px 5px;">
            <div class="col-md-5">
                <label for="" style="color: saddlebrown; font-size: 18px;">Summary Of Document Execution Report</label>
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
            <h3>
            </h3>
        </div>
        
        <%-- <asp:updatepanel id="UpdatePanel1" runat="server" xmlns:asp="#unknown">
         <Contenttemplate>--%>
        <div class="row">
            <div class="col-sm-2">
                Select Village :
            </div>
            <div class="col-sm-3">
                <asp:DropDownList ID="cmbVillage" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbVillage_SelectedIndexChanged" CssClass="form-control" Width="250px">
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
            <ej:Grid ID="Grid1" runat="server" AllowPaging="True" IsResponsive="True" OnServerPdfExporting="Grid1_ServerPdfExporting" AllowTextWrap="true">
                <ToolbarSettings ShowToolbar="true" ToolbarItems="excelExport,wordExport,pdfExport"></ToolbarSettings>
                <PageSettings PageSize="5"></PageSettings>
                <TextWrapSettings WrapMode="Both" />
                <Columns>
                    <ej:Column Field="Documents Planned" HeaderText="Documents Planned" Width="50" />
                    <ej:Column Field="Visar Pavti" HeaderText="Visar Pavti" Width="50" />
                    <ej:Column Field="Agreement to Sale" HeaderText="Agreement to Sale" Width="75" />
                    <ej:Column Field="Sale Deed" HeaderText="Sale Deed" Width="50" />
                    <ej:Column Field="Registry" HeaderText="Registry" Width="50" />
                    <ej:Column Field="Final Mutation" HeaderText="Final Mutation" Width="75" />
                    <ej:Column Field="Updated 7/12" HeaderText="Updated 7/12" Width="75" />
                </Columns>
            </ej:Grid>

        </div>

        <div>
            <ej:Chart ID="Chart1" SeriesType="Column" Text="Summary of Document Execution" ToolTip="true" BorderColor="Black" XName="Column1" YName="Column2" runat="server" OnClientPreRender="onprerender">
                <Legend Visible="false"></Legend>
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
