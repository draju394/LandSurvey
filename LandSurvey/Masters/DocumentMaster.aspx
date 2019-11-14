<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DocumentMaster.aspx.cs" Inherits="LandSurvey.Masters.DocumentMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <style>
        body{padding-top:0px}
        .auto-style1 {
            width: 209px;
            height: 26px;
        }
        .auto-style3 {
            height: 26px;
        }
    </style>

 <script src="../Scripts/Validation.js" type="text/javascript"></script>  
    <script  type="text/javascript">  
        function Validation() {  
            if (Required('<%=txtDocumentCode.ClientID%>', 'Document Code'))  
                if (Required('<%=txtDocumentName.ClientID%>', 'Document Name'))  
                    if (Required('<%=txtDocumentMarathiName.ClientID%>', 'Document Marathi Name '))
                        return true;  
            return false;  
        }  
    </script>  
    <script type="text/javascript" src="https://www.google.com/jsapi">
    </script>
    <script type="text/javascript">
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
    </script>

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
      <asp:Panel ID="Panel1" runat="server">
            <table class="nav-justified" >
                <tr>
                    <td style="width: 209px">&nbsp;</td>
                    <td colspan="2">&nbsp;<asp:Label ID="lblHeading" runat="server" Font-Bold="True" Font-Size="Medium" Text="Label"></asp:Label>
                        &nbsp;<asp:GridView ID="grdDocument" runat="server" AllowPaging="True" PageSize="5" Width="800" 
                            CssClass= "table table-striped table-bordered table-condensed" OnPageIndexChanging="grdDocument_PageIndexChanging" OnRowDataBound="grdDocument_RowDataBound" AutoGenerateSelectButton="True" OnSelectedIndexChanged="grdDocument_SelectedIndexChanged" >
                            </asp:GridView>
                    </td>
                    <td>&nbsp;</td>
                </tr>
               <%-- <tr>
                    <td style="width: 209px">&nbsp;</td>
                    <td style="width: 470px">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>--%>
                <tr>
                    <td style="width: 209px; height: 33px;"></td>
                    <td style="width: 270px; height: 33px;">
                        <asp:Label ID="lblDocumentCode" runat="server" Text="Document Code:"></asp:Label>
                    </td>
                    <td style="height: 33px">
                        <asp:TextBox ID="txtDocumentCode" runat="server" CssClass="form-control"  Height="27px" Width="189px"></asp:TextBox>
                    </td>
                    <td style="height: 33px"></td>
                </tr>
                <tr>
                    <td style="width: 209px">&nbsp;</td>
                    <td style="width: 270px">
                        <asp:Label ID="lblDocumentName" runat="server" Text="Document Name:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentName" runat="server" CssClass="form-control input-sm" Height="27px" Width="189px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 209px">&nbsp;</td>
                    <td style="width: 270px">
                        <asp:Label ID="lblDocumentMarathiName" runat="server" Text="Document Marathi Name:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentMarathiName" runat="server" CssClass="form-control input-sm" Height="27px" Width="189px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                  <tr>
                    <td class="auto-style1"></td>
                    <td style="width: 470px">&nbsp;</td>
                    <td style="margin-left: 40px" class="auto-style3">
                        &nbsp;
                    </td>
                    <td class="auto-style3"></td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td style="width: 470px"></td>
                    <td style="margin-left: 40px" class="auto-style3">
                        <asp:Button ID="btnSave" runat="server" Text="Save" Height="30px" Width="75px" OnClick="btnSave_Click"  OnClientClick="javascript:return Validation();"/> &nbsp;
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" Height="30px" Width="75px" OnClick="btnEdit_Click"  OnClientClick="javascript:return Validation();"/>&nbsp;
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" Height="30px" Width="75px" OnClick="btnDelete_Click"  OnClientClick="javascript:return Validation();"/>
                    </td>
                    <td class="auto-style3"></td>
                </tr>
                <tr>
                    <td style="width: 209px">&nbsp;</td>
                    <td style="width: 470px">&nbsp;</td>
                    <td style="margin-left: 40px">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>

            <div>
    </div>
        </asp:Panel>

</asp:Content>
