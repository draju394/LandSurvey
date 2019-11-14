<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GetClassOfLandOccupant.aspx.cs" Inherits="LandSurvey.Reports.GetClassOfLandOccupant" %>

<%@ Register Assembly="Syncfusion.EJ.Web, Version=17.1460.0.32, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89" Namespace="Syncfusion.JavaScript.Web" TagPrefix="ej" %>

<%@ Register TagPrefix="ej" Namespace="Syncfusion.JavaScript.Models" Assembly="Syncfusion.EJ" %>
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
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <script type="text/javascript">  
        function Validation() {

            var dpVillage = document.getElementById("<%=cmbVillage.ClientID %>");
            if (dpVillage.value == "0") {
                alert("Select Village");
                return false;
            }

            var dpLandClass = document.getElementById("<%=cmbLandClass.ClientID %>");
            if (dpLandClass.value == "0") {
                alert("Select Land Class");
                return false;
            }
        }
    </script>
    <div>
        <div class="row" style="background-color: #f1c371; height: 35px; padding-top: 5px; border-radius: 5px 5px 5px 5px;">
            <div class="col-md-5">
                <label for="" style="color: saddlebrown; font-size: 18px;">Class of Land – Occupant Class</label>
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
                <asp:DropDownList ID="cmbVillage" runat="server" CssClass="form-control" Width="250px">
                </asp:DropDownList>
            </div>
            <div class="col-sm-2">
                Select Land Class :
            </div>
            <div class="col-sm-2">
                <asp:DropDownList ID="cmbLandClass" runat="server" CssClass="form-control" Width="250px">
                </asp:DropDownList> 
                 
            </div>
            <div class="col-sm-4">
                <asp:Button ID="btnShow" runat="server" Text="Show" Height="30px" Width="75px" OnClick="btnShow_Click" OnClientClick="javascript:return Validation();" />
            </div>
        </div>

        <%-- </Contenttemplate>
        </asp:updatepanel>--%>
        <br />
        <%--        <asp:UpdatePanel ID="updatepn2" runat="server"> 
             <ContentTemplate> --%>
        <div>

            <br />
            <ej:Grid ID="Grid1" runat="server" AllowPaging="True" IsResponsive="True" OnServerPdfExporting="Grid1_ServerPdfExporting" AllowTextWrap="true">
                <ToolbarSettings ShowToolbar="true" ToolbarItems="excelExport,wordExport,pdfExport"></ToolbarSettings>
                <PageSettings PageSize="5"></PageSettings>
                <TextWrapSettings WrapMode="Both" />
                <Columns>
                    <ej:Column Field="docno" HeaderText="Document Number" />
                    <ej:Column Field="familyno" HeaderText="Family Number" />
                    <ej:Column Field="surveyno" HeaderText="Survey Number" />
                    <ej:Column Field="surveynoarea" HeaderText="Area" />
                    <ej:Column Field="holdername" HeaderText="Name of Holder" />
                    <ej:Column Field="holderarea" HeaderText="Area" />
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
