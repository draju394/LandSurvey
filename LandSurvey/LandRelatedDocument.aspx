<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LandRelatedDocument.aspx.cs" Inherits="LandSurvey.LandRelatedDocument" %>

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
    <script src="../scripts/jquery-2.1.3.min.js"></script>
    <script src="../scripts/ExportToPDF.js"></script>
    <script type="text/javascript">
        $(document).on('click', '#btnPrint', function () {
            var VillageCode = document.getElementById("<%=cmbVillage.ClientID %>");
            var KhataNo = document.getElementById("<%=hdnKhataNo.ClientID %>");
            if (KhataNo.value == '') {
                alert("No data fount");
                return false;
            }

            var filename = 'EightA_' + VillageCode.value + '_' + KhataNo.value;
             
            ExportToPDF($('#divtoPrint'), [], 'Land Related Document - Register of Holdings - 8A', PDFPageType.Portrait, filename);
        });
    </script>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <script type="text/javascript">  
        function Validation() {

            var dpVillage = document.getElementById("<%=cmbVillage.ClientID %>");
            if (dpVillage.value == "0") {
                alert("Select Village");
                return false;
            }

            var dpHolderName = document.getElementById("<%=cmbHolderName.ClientID %>");
            if (dpHolderName.value == "Select") {
                alert("Select Holder Name");
                return false;
            }
        }
    </script>
    <div>
        <div class="row" style="background-color: #f1c371; height: 35px; padding-top: 5px; border-radius: 5px 5px 5px 5px;">
            <div class="col-md-5">
                <label for="" style="color: saddlebrown; font-size: 18px;">Land Related Document - Register of Holdings - 8A</label>
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
                <asp:DropDownList ID="cmbVillage" runat="server" CssClass="form-control" Width="250px">
                </asp:DropDownList>
            </div>
            <div class="col-sm-2">
                Select Holder Name :
            </div>
            <div class="col-sm-2">
                <asp:DropDownList ID="cmbHolderName" runat="server" CssClass="form-control" Width="250px">
                </asp:DropDownList>

            </div>
            <br />
            <div class="col-sm-4">
                <asp:Button ID="btnShow" runat="server" Text="Show" Height="28px" Width="75px" OnClick="btnShow_Click" OnClientClick="javascript:return Validation();" />
                &nbsp;
                <input type="button" id="btnPrint" value="Export to PDF" />
                &nbsp;<asp:Button ID="btnExportToDoc" runat="server" Height="30px" Width="115px" OnClick="btnExportToDoc_Click" Text="Export to Word" />
                <asp:HiddenField ID="hdnKhataNo" Value="" runat="server" />

            </div>
        </div>

        <%-- </Contenttemplate>
        </asp:updatepanel>--%>
        <br />
        <%--        <asp:UpdatePanel ID="updatepn2" runat="server"> 
             <ContentTemplate> --%>
        <div id="divtoPrint">
            <div id="divGrid" runat="server" visible="false">

                <div class="row">
                    <div class="col-sm-9">
                        <asp:Label ID="lblVillage" runat="server" Text="गाव : "></asp:Label>
                        <asp:Label ID="lblVillageValue" runat="server" Text=""></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblTaluka" runat="server" Text="तालुका : "></asp:Label>
                        <asp:Label ID="lblTalukaValue" runat="server" Text=""></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblDistrict" runat="server" Text="जिल्हा : "></asp:Label>
                        <asp:Label ID="lblDistrictValue" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-9">
                        <center><b><asp:Label ID="lblHeading" Font-Size="Medium" runat="server" Text="नमुना ८ अ"></asp:Label></b></center>
                    </div>

                </div>

                <br />
                <asp:GridView ID="grdLandRelatedDoc" runat="server" AllowPaging="false" PageSize="5" Width="988px"
                    CssClass="table table-striped table-bordered table-condensed" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="khatano" HeaderText="खाते क्र" />
                        <asp:BoundField DataField="khatanamem" HeaderText="खाता प्रकार" />
                        <asp:BoundField DataField="surveyno" HeaderText="सर्वे / गट क्र" />
                        <asp:BoundField DataField="surveyarea" HeaderText="एकुण क्षेत्र" />
                        <asp:BoundField DataField="holdernamem" HeaderText="खातेदाराचे नाव" />
                        <asp:BoundField DataField="holderarea" HeaderText="क्षेत्र" />
                        <asp:BoundField DataField="assessment" HeaderText="आकारणी" />
                        <asp:BoundField DataField="potkharaba" HeaderText="पोटखराबा" />
                        <asp:BoundField DataField="mutno" HeaderText="फेरफार क्र" />
                    </Columns>
                </asp:GridView>
            </div>
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
