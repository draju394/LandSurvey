<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MutationSearchReport.aspx.cs" EnableEventValidation="false" Inherits="LandSurvey.Reports.MutationSearchReport" %>

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
    <%--<style>
        body {
            padding-top: 0px
        }

        .auto-style1 {
            width: 209px;
            height: 26px;
        }

        .auto-style3 {
            height: 26px;
        }

        .auto-style4 {
            width: 100%;
            margin-bottom: 0px;
        }

        .auto-style5 {
            display: block;
            padding: 6px 12px;
            font-size: 14px;
            line-height: 1.42857143;
            color: #555;
            background-color: #fff;
            background-image: none;
            border: 1px solid #ccc;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
            box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
            -webkit-transition: border-color ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
        }

        .auto-style6 {
            width: 209px;
            height: 20px;
        }

        .auto-style7 {
            height: 20px;
        }

        .auto-style12 {
            width: 169px;
        }

        .auto-style13 {
            width: 44px;
        }

        .auto-style14 {
            height: 50px;
            width: 288px;
        }

        .auto-style15 {
            height: 33px;
            width: 174px;
        }

        .auto-style16 {
            height: 33px;
            width: 169px;
        }

        .auto-style18 {
            width: 179px;
        }

        .auto-style19 {
            height: 33px;
            width: 179px;
        }
    </style>--%>

    <script src="../Scripts/Validation.js" type="text/javascript"></script>
    <script type="text/javascript">  
        function Validation() {

            var dpVillage = document.getElementById("<%=cmbVillage.ClientID %>");
            if (dpVillage.value == "0") {
                alert("Select Village");
                return false;
            }
            if (Required('<%=txtDocumentNo.ClientID%>', 'Document Number'))
                return true;
            return false;
        }

    </script>
    <div id="ResultData">
        <div class="row" style="background-color: #f1c371; height: 35px; padding-top: 5px; border-radius: 5px 5px 5px 5px;">
            <div class="col-md-3">
                <label for="" style="color: saddlebrown; font-size: 18px;">Mutation Search Report</label>
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
        <div class="row" style="padding-top: 20px;">
            <div class="col-sm-2">
                Select Village :
            </div>
            <div class="col-sm-2">
                <asp:DropDownList ID="cmbVillage" runat="server" CssClass="form-control" Width="150px">
                </asp:DropDownList>
            </div>
            <div class="col-sm-2">
                Enter Document No: 
            </div>
            <div class="col-sm-2">
                <asp:TextBox ID="txtDocumentNo" runat="server" CssClass="form-control" Width="150px"></asp:TextBox>
            </div>
            <div class="col-sm-4">
                <asp:Button ID="btnShow" runat="server" Text="Show" Height="30px" Width="75px" OnClick="btnShow_Click" OnClientClick="javascript:return Validation();" />
                &nbsp;<asp:Button ID="btnExportToDoc" runat="server" Height="30px" Width="115px" Visible="false" OnClick="btnExportToDoc_Click" Text="Export to Word" />
                &nbsp;<asp:Button ID="btnExportToXls" runat="server" Height="30px" Width="115px" Visible="false" OnClick="btnExportToXls_Click" Text="Export to Excel" />
            </div>

        </div>
        <br />


        <%-- </Contenttemplate>
        </asp:updatepanel>--%>
        <br />
        <%--        <asp:UpdatePanel ID="updatepn2" runat="server"> 
             <ContentTemplate> --%>
        <div id="divReport" runat="server" visible="false">

            <div class="row">
                <div class="col-sm-10">
                    <center>
                    <asp:Label ID="lblHeading" runat="server" Font-Size="Medium" Text="मिळकतीच्या मालकीचा दाखला" Font-Bold="true" Font-Underline="true"></asp:Label></center>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm-10">
                    <b>विषय: मौजे तळवली, तालुका भिवंडी, जिल्हा ठाणे. येथील खालील नमूद केलेल्या सर्व्हे नंबरच्या मिळकतींच्या मालकी हक्काचा शोध.</b>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm-10">
                    <font size="2" face="Arial Unicode MS">
                    <asp:Repeater ID="rptMain" runat="server" OnItemDataBound="rptMain_ItemDataBound">
                        <ItemTemplate>
                            <div class="row">
                                <div class="col-sm-10">
                                    
                                   <b> <asp:Label ID="lblSurveyNo" Text='<%# Eval("surveyno") %>' runat="server"></asp:Label>
                                    मधील हे
                                    <asp:Label ID="lblSurveyArea" Text='<%# Eval("surveyarea") %>' runat="server"></asp:Label>
                                    गुंठे --- पॉईंट उपरोक्त मिळकतीचे मालकी हक्का संदर्भात दुय्यम निबंधक भिवंडी आणि महसुली अभिलेखातील नोंदीचे शोध मी घेतला.</b></div>
                                
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-sm-10">
                                    <b>1. महसुली अभिलेखा नुसार सन
                                        <asp:Label ID="lblFromYear" runat="server"></asp:Label>
                                        ते सन
                                        <asp:Label ID="lblToYear" runat="server"></asp:Label>
                                        या कालावधी मधील नोंदी पुढीलप्रमाणे आहे.</b>

                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-sm-10">
                                    <asp:GridView ID="grdMutationFinal" runat="server" AllowPaging="false" PageSize="5" Width="988px" DataKeyNames="mutationno, villagecode"
                                        RowStyle-Font-Names="Arial Unicode MS" AutoGenerateColumns="false" OnRowDataBound="grdMutationFinal_RowDataBound">
                                        <Columns>
                                            <asp:BoundField DataField="mutationyear" HeaderText="सन" />
                                            <asp:BoundField DataField="mutationno" HeaderText="फेरफार क्र." />
                                             <asp:BoundField DataField="villagecode" Visible="false" HeaderText="villagecode" />
                                            <asp:TemplateField HeaderText="विवरण">
                                                <ItemTemplate>
                                                    <div style="width: 500px; height: 100px;">
                                                        <%#Eval("mutationdetail") %>
                                                    </div>
                                                    <br />
                                                    <asp:GridView ID="grdMutationChild" ShowHeader="false" Width="500px" runat="server" AllowPaging="false"
                                                       RowStyle-Font-Names="Arial Unicode MS"  AutoGenerateColumns="false">
                                                        <Columns>
                                                            <asp:BoundField DataField="mutationdetail" HeaderText="mutationdetail" />
                                                            <asp:BoundField DataField="field4" HeaderText="field4" />
                                                            <asp:BoundField DataField="field5" HeaderText="field5" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="surveynos" Visible="false" HeaderText="सर्व्हे क्र" />
                                        </Columns>
                                    </asp:GridView>

                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-sm-10">
                                 <b>   टिप:- फेरफार क्र.-----हे उपरोक्त नमुद सर्व्हे नंबरच्या 7/12 उतारा सदरी लागू होत नसल्याचे दिसते.</b>
                                </div>
                            </div>
                            <br />
                            <br />
                            <br />

                        </ItemTemplate>
                    </asp:Repeater>
                         </font>
                </div>

                <div class="row">
                    <div class="col-sm-10">
                        <b>सदरील मिळकती बाबत दै -------- या वर्तमान पत्रात दि.     /   /2019 रोजी</b>
                        <br />
                        <b>जाहिर प्रगटन काढण्यात आले होते,जाहिर प्रगटनामध्ये 14 दिवसांची मुदत देण्यात आली होती. विहित मुदतीत आक्षेप मागविण्यात आले होते, परंतु जाहिर प्रगटनाच्या मुदतीमध्ये </b>
                        <br />
                        <b>कोणताही आक्षेप प्राप्त झाला नाही. दस्तऐवज नोंदणीकृत झाल्यानंतर उपरोक्त मिळकतीबाबत वर्तमानपत्रामध्ये दिलेल्या जाहिर प्रगटनास / जाहिर सुचनेस कोणताही आक्षेप</b><br />
                        <b>अथवा हरकत आल्यास त्याचे निराकरण करण्याची संपूर्ण जबाबदारी विक्री करणार यांची आहे. त्यास विक्री करणार यांची संमती आहे.</b><br />
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>येणेप्रमाणे मी घेतलेल्या सदर मिळकतीच्या शोधामध्ये व मला उपलब्ध झालेल्या</b>

                        <b>उपरोकत  कागदपत्रामध्ये सदर मिळकतीवर आज रोजी कोणताही बोजा किंवा जोखीम माझ्या</b>
                        <br />
                        <b>निदर्शनास आली नाही. त्यामुळे उपरोक्त मिळकतीच्या हस्तांतरणाचे पुर्ण अधिकार</b>
                        <b>-------------------------------------------------------------------------- यांना प्राप्त आहेत.</b><br />
                        <b>सबब सदर मिळकत ही ‍निर्वेध व निजोखीम आहे.</b>
                        <br />
                        <br />

                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b> येणेप्रमाणे सदर मिळकतीच्या मालकीचा दाखला आज रोजी दिला असे.</b>

                    </div>

                </div>
                <br />
                <div class="row">
                    <div class="col-sm-10">
                        1. वरील सर्व  जमीन मालक यांनी वरील नमुद क्षेत्र  विक्री केल्यास महसूल अभिलेख गाव नमुना नं-8अ नुसार भुमीहिन होत नाहीत.<br />
                        2. सदरिल जमीन /मिळकत ही नागरी जमीन कमाल धारणा अधिनियम 1976 अंतर्गत  अतिरिक्त् घोषित  झालेली नाही.<br />
                        3. सदरिल जमीन /मिळकत व नमुद क्षेत्र विक्री केल्यास मुंबई तुकडे बंदी तथा एकत्रीकरण  अधिनियम 1947 चे उल्लंघन होत नाही.<br />
                        4. सदरिल जमीन धारक हे “महाराष्ट्र शेत जमीनी (कमाल धारणा) अधिनियम 1961 चे उल्लंघन करीत नाहीत. ( एकूण क्षेत्र ------)<br />
                        5. वरील नमुद सर्व गट नं/ सर्व्हे नं. संदर्भात कोणत्याही महसुली,  दिवाणी अथवा हजर न्यायालयात कोणताही दावा प्रलंबित नाही.<br />
                        6. वरील नमुद सर्व गट नं. एकूण क्षेत्र ----- हे वरील नमुद मुळ मालक यांनी कोणत्याही  व्यक्तीस, संस्थेस, बँक किंवा तत्स्म अर्थपुरवठा संस्थेस, गहाण वा तारण  दिले नाही.

                    </div>

                </div>


            </div>

            <br />
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
