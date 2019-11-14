<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GenerateDocumentTemplate.aspx.cs" Inherits="LandSurvey.Reports.GenerateDocumentTemplate" %>

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

            var dpDocNo = document.getElementById("<%=cmbDocNo.ClientID %>");
            if (dpDocNo.value == "Select") {
                alert("Select Document No");
                return false;
            }
        }
    </script>
    <div>
        <div class="row" style="background-color: #f1c371; height: 35px; padding-top: 5px; border-radius: 5px 5px 5px 5px;">
            <div class="col-md-5">
                <label for="" style="color: saddlebrown; font-size: 18px;">Generate Document Template</label>
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
            <div class="col-sm-2">
                <asp:DropDownList ID="cmbVillage" runat="server" CssClass="form-control" Width="200px">
                </asp:DropDownList>
            </div>
            <div class="col-sm-2">
                &nbsp;&nbsp; Select Document No :
            </div>
            <div class="col-sm-2">
                <asp:DropDownList ID="cmbDocNo" runat="server" CssClass="form-control" Width="200px">
                </asp:DropDownList>
            </div>
            <div class="col-sm-4">
                &nbsp;&nbsp;<asp:Button ID="btnShow" runat="server" Text="Generate Information Page" Height="30px" Width="215px" OnClick="btnShow_Click" OnClientClick="javascript:return Validation();" />
            </div>
        </div>

        <%-- </Contenttemplate>
        </asp:updatepanel>--%>
        <br />
        <%--        <asp:UpdatePanel ID="updatepn2" runat="server"> 
             <ContentTemplate> --%>

        <div id="divGrid" runat="server" visible="false">
            <br />
            <div class="row">
                <div class="col-sm-2">
                    <asp:Label ID="lblDocNo" runat="server" Text="Document No : "></asp:Label>
                    <asp:Label ID="lblDocNoValue" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-sm-3">
                    <asp:Label ID="lblFamilyNo" runat="server" Text="Family No : "></asp:Label>
                    <asp:Label ID="lblFamilyNoValue" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-sm-2">
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm-2">
                    <asp:Label ID="lblVillageValue" Font-Bold="true" runat="server" Text=""></asp:Label>,<asp:Label ID="lblTaluka" runat="server" Text="तालुका "></asp:Label>
                    <asp:Label ID="lblTalukaValue" runat="server" Text=""></asp:Label>,<asp:Label ID="lblDistrict" runat="server" Text="जिल्हा "></asp:Label>
                    <asp:Label ID="lblDistrictValue" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-sm-2">
                </div>
                <div class="col-sm-2">
                </div>
            </div>

            <br />
            <asp:GridView ID="grdFamilyInfo" runat="server" AllowPaging="false" PageSize="5" Width="988px"
                AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="surveyno" HeaderText="सर्व्हे नंबर" />
                    <asp:TemplateField HeaderText="हिस्सा नंबर">
                        <ItemTemplate>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="holdernamem" HeaderText="नाव" />
                    <asp:BoundField DataField="surveyarea" HeaderText="क्षेत्र (हे. आर. पॉ)" />
                    <asp:TemplateField HeaderText="आकार (रू. पै)">
                        <ItemTemplate>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <br />
            <asp:GridView ID="grdPaymentInfo" runat="server" AllowPaging="false" PageSize="5" Width="988px"
                AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="holdername" HeaderText="नाव" />
                    <asp:BoundField DataField="amountpaid" HeaderText="रक्कम" />
                    <asp:BoundField DataField="amtdocumentno" HeaderText="धनादेश क्र." />
                    <asp:BoundField DataField="amountdocumentdate" HeaderText="दिनांक" />
                    <asp:BoundField DataField="amtbankdetail" HeaderText="बॅकेचे नाव" />
                </Columns>
            </asp:GridView>

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
