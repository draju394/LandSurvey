<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmMutationRegister.aspx.cs" Inherits="LandSurvey.Masters.frmMutationRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <style>
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

        .auto-style9 {
            height: 33px;
            width: 127px;
        }

        .auto-style10 {
            width: 127px;
        }

        .auto-style11 {
            height: 33px;
            width: 140px;
        }

        .auto-style12 {
            width: 140px;
        }

        .auto-style13 {
            width: 44px;
        }

        .auto-style14 {
            height: 50px;
            width: 140px;
        }
    </style>

    <script src="../Scripts/Validation.js" type="text/javascript"></script>

    <script type="text/javascript">  
        function Validation() {


            var dpVillage = document.getElementById("<%=dpVillageName.ClientID %>");
            if (dpVillage.value == "0") {
                alert("Select Village");
                return false;
            }

            if (Required('<%=txtMutationNo.ClientID%>', 'Mutation No'))
                if (Required('<%=txtMutaionYear.ClientID%>', 'Mutaion Year'))
                    if (Required('<%=txtSurveyNo.ClientID%>', 'Survey No'))
                        if (Required('<%=txtMutationDetails.ClientID%>', 'Mutation Details '))
                            return true;
            return false;
        }


        function ValidationShow() {


            var dpVillage = document.getElementById("<%=dpVillageName.ClientID %>");
            if (dpVillage.value == "0") {
                alert("Select Village");
                return false;
            }

            if (Required('<%=txtMutationNo.ClientID%>', 'Mutation No'))
                return true;
            return false;
        }

    </script>
    <script type="text/javascript" src="https://www.google.com/jsapi">
    </script>
    <%--<script type="text/javascript">
        // Load the Google Transliterate API
        google.load("elements", "1", {
            packages: "transliteration"
        });
 
        function onLoad() {
            var options = {
                sourceLanguage:
                google.elements.transliteration.LanguageCode.ENGLISH,
                destinationLanguage:
                [google.elements.transliteration.LanguageCode.MARATHI],
                shortcutKey: 'ctrl+e',
                transliterationEnabled: true
            };
 
            // Create an instance on TransliterationControl with the required
            // options.
            var control =
            new google.elements.transliteration.TransliterationControl(options);
 
            control.makeTransliteratable(['<%= txtDocumentMarathiName.ClientID %>']);
 
 
        }
        google.setOnLoadCallback(onLoad);
    </script>--%>

    <%--<div class="jumbotron text-center">
        <h3>Document Master</h3>
    </div>
    <div class="container">
        <div class="row">
            <div class="form-group">
                <div class="col-sm-12">
                </div>
            </div>
        </div>
        <div class="row">
        </div>
    </div>--%>

    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:Panel ID="Panel1" runat="server">
        <div class="container">
            <table class="auto-style4">
                <tr>
                    <td style="width: 209px">&nbsp;</td>
                    <td colspan="4">&nbsp;<asp:Label ID="lblHeading" runat="server" Font-Bold="True" Font-Size="Medium" Text="Mutation Data Entry"></asp:Label>

                    </td>
                    <td style="width: 209px">&nbsp;</td>
                </tr>
            </table>
            <table class="table table-bordered">
                <tr style="border: thin; border-collapse: collapse; border-color: black;">

                    <td class="auto-style9">
                        <asp:Label ID="lblVillageName" runat="server" Text="Village Name:"></asp:Label>
                        <asp:Label ID="lblMutationId" runat="server" Visible="false"></asp:Label>
                    </td>
                    <td class="auto-style14">
                        <asp:DropDownList ID="dpVillageName" runat="server" CssClass="auto-style5" Height="37px" Width="189px" AutoPostBack="True"></asp:DropDownList>
                    </td>

                    <td>
                        <asp:Label ID="lblmutaionno" runat="server" Text="फेरफार क्र (Mutation No):"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMutationNo" runat="server" CssClass="form-control" Height="37px" Width="180px"></asp:TextBox>
                    </td>
                    <td class="auto-style14">
                        <asp:Button ID="btnShow" runat="server" Text="Search" Visible="true" Height="30px" Width="75px" OnClick="btnShow_Click" OnClientClick="javascript:return ValidationShow();" />&nbsp;
                    </td>
                </tr>
            </table>
            <table id="tblMain" runat="server" visible="false" class="table table-bordered">
                <tr>

                    <td class="auto-style9">
                        <asp:Label ID="Label1" runat="server" Text="वर्ष"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:Label ID="Label3" runat="server" Text="विवरण"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:Label ID="Label2" runat="server" Text="सर्व्हे नंबर"></asp:Label>
                    </td>

                </tr>
                <tr>

                    <td class="auto-style9">
                        <asp:TextBox ID="txtMutaionYear" MaxLength="4" TextMode="Number" runat="server" CssClass="auto-style5" Height="37px" Width="230px"></asp:TextBox>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtMutationDetails" runat="server" TextMode="MultiLine" CssClass="form-control" Height="100px" Width="700px"></asp:TextBox>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtSurveyNo" runat="server" TextMode="MultiLine" CssClass="form-control" Height="100px" Width="250px"></asp:TextBox>
                    </td>

                </tr>
                <tr>

                    <td colspan="5"></td>

                </tr>
                <tr>

                    <td>
                        <asp:Label ID="lblRemarks" runat="server" Text="शेरा:"></asp:Label></td>
                    <td colspan="2">
                        <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" CssClass="auto-style5" Height="100px" Width="700px"></asp:TextBox>
                    </td>
                    <td colspan="2">
                        <asp:Button ID="btnSave" runat="server" Text="Save" Visible="true" Height="30px" Width="75px" OnClick="btnSave_Click" OnClientClick="javascript:return Validation();" />&nbsp;
                                <asp:Button ID="btnEdit" runat="server" Visible="false" Text="Update" Height="30px" Width="75px" OnClick="btnEdit_Click" />&nbsp;
                        <asp:Button ID="btnDelete" runat="server" Visible="false" Text="Delete" Height="30px" Width="75px" OnClick="btnDelete_Click" />&nbsp;
                                 <asp:Button ID="btnReset" runat="server" Text="Reset" Height="30px" Width="75px" OnClick="btnReset_Click" />&nbsp;

                    </td>

                </tr>

            </table>
        </div>
    </asp:Panel>
</asp:Content>
