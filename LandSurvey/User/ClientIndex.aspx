<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClientIndex.aspx.cs" Inherits="LandSurvey.User.ClientIndex" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
    * {
        box-sizing: border-box;
    }

    body {
        font-family: Arial, Helvetica, sans-serif;
    }

    .body-content {
        padding-top: 25px;
    }

    .column {
        float: left;
        width: 25%;
        padding: 0 10px;
        display: block;
        margin-bottom: 20px;
    }

    .row {
        margin: 0 -5px;
    }

    .column {
        width: 33.33%;
    }
    /* Clear floats after the columns */
    .row:after {
        content: "";
        display: table;
        clear: both;
    }

    .coll2 {
        float: right;
        width: 383px;
        height: 50%;
        padding: 0 10px;
        display: block;
        margin-bottom: 20px;
    }

    .coll_Last {
        float: left;
        width: 50%;
        height: 30%;
        padding: 0 10px;
        display: block;
        margin-bottom: 20px;
    }

    .coll2height {
        float: right;
        width: 20%;
        height: 20px;
        padding: 0 10px;
        display: block;
        padding-bottom: 10px !important;
        margin-bottom: 20px;
    }
    /* Style the counter cards */
    .card {
        box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
        padding: 16px;
        text-align: center;
        background-color: #f1f1f1;
        border-radius: .25rem !important;
    }

    .card2 {
        box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
        float: initial;
        text-align: right;
        background-color: #f1f1f1;
        background: linear-gradient(to bottom, #ccffff 0%, #ffffff 100%);
        height: 98px;
    }

    .content-wrapper {
        background: #f2edf3;
        padding: 2.75rem 2.25rem;
        width: 100%;
        -webkit-flex-grow: 1;
        flex-grow: 1;
    }

    .col-12 {
        flex: 0 0 100%;
        max-width: 100%;
    }

    .purchase-popup {
        background: rgba(191, 187, 187, 0.46);
        padding: 15px 20px;
        border-radius: 3px;
    }

    .purchase-popup {
        margin-bottom: 2.5rem;
    }

    .align-items-center {
        align-items: center !important;
    }

    .div-pie {
        width: 300px;
        height: 280px;
        padding-left: 55px;
    }


    input[type=text] {
        width: 200px;
        box-sizing: border-box;
        border: 2px solid #ccc;
        border-radius: 4px;
        font-size: 16px;
        background-color: white;
        background-image: url('searchicon.png');
        background-position: 10px 10px;
        background-repeat: no-repeat;
        padding: 12px 20px 12px 40px;
        -webkit-transition: width 0.4s ease-in-out;
        transition: width 0.4s ease-in-out;
    }

        input[type=text]:focus {
            width: 100%;
        }

    .searchButton {
        width: 40px;
        height: 36px;
        border: 1px solid #00B4CC;
        background: #00B4CC;
        text-align: center;
        color: #fff;
        border-radius: 0 5px 5px 0;
        cursor: pointer;
        font-size: 20px;
    }

    .LockOff {
        display: none;
        visibility: hidden;
    }

    .LockOn {
        display: block;
        visibility: visible;
        position: fixed;
        z-index: 99999;
        top: 0px;
        left: 0px;
        /*width: 100%;
        height: 100%;*/
        background-color: #ccc;
        background-color: transparent;
        text-align: center;
        padding-top: 20%;
        filter: alpha(opacity=75);
        opacity: 0.75;
    }

    .tableshow {
        width: 100%;
    }

    .TopCitySearch {
        margin-top: 12px;
        padding-right: 0px;
        width: 100px;
    }

    .TopCitySearchBox {
        margin-top: 5px;
        padding-right: 0px;
        width: 15%;
    }

    .TopBoothSearchBox {
        margin-top: 5px;
        padding-right: 0px;
        width: 40%;
    }

    .inputbox {
        max-width: 411px;
    }

    .smallcard {
        height: 120px;
    }
</style>

     <div id="clientLogin">
 <%--       <div class="row" style="margin-top: 5px;margin-bottom: 5px !important; padding-left: 10px;">
            <div>
                <div class="form-group">
                    <div class="col-md-2 TopCitySearch">Select City: </div>--%>
                  <%--  @*<div class="col-md-4">
                            <select id="drpCityMaster" name="drpSelectedCityID" class="form-control dropdown"></select>
                            <input type="hidden" id="hdnSelectedCityID" name="SelectedCityID" value="0" />
                        </div>*@--%>
                  <%--  <div class="col-md-3 TopCitySearchBox">

                        
                        <input id="VillageID" class="form-control" placeholder="select City" />
                        <label id="LablVillageID" style="color:Black;font-size: x-large;display: none;"></label>

                    </div>--%>
                   <%-- @*<div class="col-md-4">
                            <select id="drpCityMaster" name="drpSelectedCityID" class="form-control dropdown"></select>
                            <input type="hidden" id="hdnSelectedCityID" name="SelectedCityID" value="0" />
                        </div>*@--%>
                   <%-- <div class="col-md-2 TopCitySearch">Select Booth: </div>
                    <div class="col-md-4 TopBoothSearchBox">--%>


                      <%--  <input type="hidden" value="@ViewBag.hdnFlag" id="hdnFlag" />
                        @Html.Hidden("BoothID")--%>
                       <%-- <input id="BoothHID" class="form-control inputbox" placeholder="select Booth" />
                        <label id="LablBoothID" style="color:Black;font-size: x-large;display: none;"></label>
                    </div>--%>
                  <%--  @*<div class="col-md-1" style=" width: 10%;">
                            <input value="शोधा" class="form-control btn btn-danger" id="searchData" />
                        </div>*@--%>
                    <%--<div style="padding-top:1%;text-align:right" id="PrintDiv" class="col-md-1">
                       <%-- @*<a href="#" onClick="printDiv();" class="glyphicon glyphicon-print"
                            style="align-content:center;text-align:center;font-size:30px;"></a>*@
                        @*<p>@Html.ActionLink("CastSummery", "CastSummery", "Dashboard")</p>*@--%>

                    <%--</div>--%>
                <%--</div>--%>
                <%--<div class="form-group">


                </div>--%>


           <%-- </div>
        </div>--%>
        <%-- RD - Strip --%>
        <div class="row" style="background-color:#f1c371;height:47px;padding-top: 10px; border-radius: 5px 5px 5px 5px;">
            <div class="col-md-2">
                <label for="" style="color:saddlebrown;font-size: 18px;">Client Approval</label>
                <label for="" style="color: white;font-size: 18px;" id="PopulationID"></label>
            </div>
            <div class="col-md-2">
               <%-- <label for="" style="color:white;font-size: 18px;">बूथ संख्या :-</label>
                <label for="" style="color: white;font-size: 18px;" id="Booth_numberID"></label>--%>
            </div>
            <div class="col-md-2">
               <%-- <label for="" style="color:white;font-size:18px;"> मतदारसंघ :</label>
                <label for="" style="color:white;font-size: 18px;" id="Vidhansabha_Id"></label>--%>
            </div>
        </div>


        <div class="row" style="padding-top:20px;">
            <div class="column">
                <div class="card smallcard" style="background:#556b8d;/*background:linear-gradient(45deg,#4099ff,#73b4ff);background:linear-gradient(-45deg,#f403d1,#64b5f6);*/">
                    <table>
                        <tr>
                            <td onclick="document.location='/Client/ClientApproval'" runat="server" style="cursor:hand"> <img src="../Images/DocPlan2.png" width="80" height="85" /></td>
                            <td style="text-align:right;">
                                
                               <%-- @*<h4 style="color:white;font:bold">@ViewBag.DataTotal</h4>*@--%>
                                <label for="" style="color: white;font-size: 18px;" id="TotalVoterId"></label>
                                <h4 style="color:white">Document Approval</h4>
                                <br />    <%--<span style="color:white;padding-left:5px">Document Planning</span>--%>
                            </td>
                        </tr>
                    </table>
                   
                </div>
            </div>

          

            <div class="column">
                <div class="card smallcard" style="background:#602f3d;/*background:linear-gradient(45deg,#FFB64D,#ffcb80);background:linear-gradient(to bottom, #33ccff 0%, #0066cc 100%);*/">
                    <table>
                        <tr>
                         <%--   <td onclick="document.location='/Client/ViewPaymentDetails'" runat="server" style="cursor:hand; vertical-align:top">--%>
                               <td onclick="document.location='/Client/ClientViewPayment'" runat="server" style="cursor:hand; vertical-align:top">
                                <img src="../Images/DocSearch2.png" width="80" height="85" /></td>
                            <td style="text-align:left; align-items:center">
                           
                               <%-- @*<h4 style="color:white;font:bold">@ViewBag.DataTotal</h4>*@--%>
                                <label for="" style="color: white;font-size: 18px;" id="TotalVoterId"></label>
                                <h4 style="color:white"> Approve Payment Demand </h4>
                            <%--    <h4 style="color:white"> Search Report </h4>--%>
                                <br />    <%--<span style="color:white;padding-left:5px">Document Planning</span>--%>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>

            <div class="column">
                <div class="card smallcard" style="background: #e74c3c;/*background:linear-gradient(45deg,#FF5370,#ff869a);background:linear-gradient(to bottom, #ffcc00 0%, #ffffcc 100%);*/">
                    <table>
                        <tr>
                           <td onclick="document.location='/Client/ViewPaymentDetails'" runat="server" style="cursor:hand; vertical-align:top">
                                <img src="../Images/Solicitor.png" width="80" height="85" /></td>
                            <td style="text-align:left; align-items:center">
                               
                               <%-- @*<h4 style="color:white;font:bold">@ViewBag.DataTotal</h4>*@--%>
                                <label for="" style="color: white;font-size: 18px;" id="TotalVoterId"></label>
                                <h4 style="color:white">View Payment Details </h4>
                                <%--<h4 style="color:white">  Solicitor </h4>--%>
                                <br />    <%--<span style="color:white;padding-left:5px">Document Planning</span>--%>
                            </td>
                        </tr>
                    </table>


                   <%-- @*<p>Some text</p>*@--%>
                </div>
            </div>
        
        </div>
    </div>

</asp:Content>
