<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmInwardOutwardReg.aspx.cs" Inherits="LandSurvey.Masters.frmInwardOutwardReg" %>
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
    </style>

    <script src="../Scripts/Validation.js" type="text/javascript"></script> 
    
   <%-- <script  type="text/javascript">  
        function Validation() {  
            if (Required('<%=txt.ClientID%>', 'Document Code'))  
                if (Required('<%=txtDocumentName.ClientID%>', 'Document Name'))  
                    if (Required('<%=txtDocumentMarathiName.ClientID%>', 'Document Marathi Name '))
                        return true;  
            return false;  
        }  
    </script> --%> 
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
      <asp:Panel ID="Panel1" runat="server">
            <table class="auto-style4" >
                <tr>
                    <td style="width: 209px">&nbsp;</td>
                    <td colspan="4">&nbsp;<asp:Label ID="lblHeading" runat="server" Font-Bold="True" Font-Size="Medium" Text="Label"></asp:Label>
                        &nbsp;<asp:GridView ID="grdInwardOutwardReg" runat="server" AllowPaging="True" PageSize="5" Width="988px" 
                            CssClass= "table table-striped table-bordered table-condensed" OnPageIndexChanging="grdInwardOutwardReg_PageIndexChanging" OnRowDataBound="grdInwardOutwardReg_RowDataBound" AutoGenerateSelectButton="True" OnSelectedIndexChanged="grdInwardOutwardReg_SelectedIndexChanged" >
                            </asp:GridView>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="6">
                        <table>
                            <tr>
                                <td style="width: 209px; height: 33px;"></td>
                                <td style="width: 170px; height: 33px;">
                                    <asp:Label ID="lblreceiveddocumenttype" runat="server" Text="Received Document Type:"></asp:Label>
                                </td>
                                <td style="height: 33px">
                                    <%--<asp:TextBox ID="txtDocumentCode" runat="server" CssClass="form-control"  Height="27px" Width="189px"></asp:TextBox>--%>
                                    <asp:DropDownList ID="dpreceiveddocumenttype" runat="server" CssClass="auto-style5"  Height="27px" Width="189px" AutoPostBack="True" OnSelectedIndexChanged="dpreceiveddocumenttype_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                                <td style="width: 120px; height: 33px;">
                                    <asp:Label ID="lblreceivedfrom" runat="server" Text="Received From:"></asp:Label>
                                </td>
                                <td style="height: 33px">
                                    <asp:TextBox ID="txtreceivedfrom" runat="server" CssClass="form-control"  Height="27px" Width="189px"></asp:TextBox>
                                </td>
                                 <td style="width: 120px; height: 33px;">
                                    <asp:Label ID="lblReceivedDocRemark" runat="server" Text="Received Document Remark:"></asp:Label>
                                </td>
                                <td style="height: 33px">
                                    <asp:TextBox ID="txtReceivedDocRemark" runat="server" CssClass="form-control"  Height="27px" Width="189px"></asp:TextBox>
                                </td>
                                <td style="width: 120px; height: 33px;">
                                    <asp:Label ID="lblReceivedBy" runat="server" Text="Received By:"></asp:Label>
                                </td>
                                <td style="height: 33px">
                                    <asp:TextBox ID="txtReceivedBy" runat="server" CssClass="form-control"  Height="27px" Width="189px"></asp:TextBox>
                                </td>
                            </tr>
                             <tr>
                                <td style="width: 209px">&nbsp;</td>
                                <td style="width: 170px">
                                    <asp:Label ID="lblInwardNo" runat="server" Text="Inward Number:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtInwardNo" runat="server" CssClass="form-control" Height="27px" Width="189px"></asp:TextBox>
                                </td>
                                 
                                <td style="width: 120px; height: 33px;">
                                    <asp:Label ID="lblInwardDate" runat="server" Text="Inward Date:"></asp:Label>
                                </td>
                                <td style="height: 33px">
                                    <asp:TextBox ID="txtInwardDate" runat="server" CssClass="form-control"  Height="27px" Width="189px"></asp:TextBox>
                                </td>
                                  <td style="width: 120px; height: 33px;">
                                    <asp:Label ID="lblInwardSection" runat="server" Text="Inward Section:"></asp:Label>
                                </td>
                                <td style="height: 33px">
                                    <asp:TextBox ID="txtInwardSection" runat="server" CssClass="form-control"  Height="27px" Width="189px"></asp:TextBox>
                                </td>
                                <td style="width: 120px; height: 33px;">
                                    <asp:Label ID="lblsentdocumenttype" runat="server" Text="Sent Document Type:"></asp:Label>
                                </td>
                                <td style="height: 33px">
                                    <asp:DropDownList ID="dpsentdocumenttype" runat="server" CssClass="auto-style5"  Height="27px" Width="189px" AutoPostBack="True" OnSelectedIndexChanged="dpsentdocumenttype_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 209px">&nbsp;</td>
                                <td style="width: 170px">
                                    <asp:Label ID="lblSentTo" runat="server" Text="Sent To:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSentTo" runat="server" CssClass="form-control" Height="27px" Width="189px"></asp:TextBox>
                                </td>
                                
                                <td style="width: 120px; height: 33px;">
                                    <asp:Label ID="lblSentDocRemark" runat="server" Text="Sent Document Remark:"></asp:Label>
                                </td>
                                <td style="height: 33px">
                                    <asp:TextBox ID="txtSentDocRemark" runat="server" CssClass="form-control"  Height="27px" Width="189px"></asp:TextBox>
                                </td>
                                 <td style="width: 120px; height: 33px;">
                                    <asp:Label ID="lblSentBy" runat="server" Text="Sent By:"></asp:Label>
                                </td>
                                <td style="height: 33px">
                                    <asp:TextBox ID="txtSentBy" runat="server" CssClass="form-control"  Height="27px" Width="189px"></asp:TextBox>
                                </td>
                               <td style="width: 120px; height: 33px;">
                                    <asp:Label ID="lblOutwardNo" runat="server" Text="Outward Number:"></asp:Label>
                                </td>
                                <td style="height: 33px">
                                    <asp:TextBox ID="txtOutwardNo" runat="server" CssClass="form-control"  Height="27px" Width="189px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 209px">&nbsp;</td>
                                <td style="width: 170px">
                                    <asp:Label ID="lblOutwardDate" runat="server" Text="Outward Date:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtOutwardDate" runat="server" CssClass="form-control" Height="27px" Width="189px"></asp:TextBox>
                                </td>
                                
                                <td style="width: 120px; height: 33px;">
                                    <asp:Label ID="lblOutwardSection" runat="server" Text="Outward Section:"></asp:Label>
                                </td>
                                <td style="height: 33px">
                                    <asp:TextBox ID="txtOutwardSection" runat="server" CssClass="form-control"  Height="27px" Width="189px"></asp:TextBox>
                                </td>
                                 <td style="width: 120px; height: 33px;">
                                    <asp:Label ID="lblOutwardMode" runat="server" Text="Outward Mode:"></asp:Label>
                                </td>
                                <td style="height: 33px">
                                    <asp:TextBox ID="txtOutwardMode" runat="server" CssClass="form-control"  Height="27px" Width="189px"></asp:TextBox>
                                </td>
                               <td style="width: 120px; height: 33px;">
                                    <asp:Label ID="lblVillageName" runat="server" Text="Village Name:"></asp:Label>
                                </td>
                                <td style="height: 33px">
                                     <asp:DropDownList ID="dpVillageName" runat="server" CssClass="auto-style5"  Height="27px" Width="189px" AutoPostBack="True" OnSelectedIndexChanged="dpVillageName_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6"></td>
                    <td style="width: 470px">&nbsp;</td>
                    <td style="margin-left: 40px" class="auto-style7">
                        &nbsp;
                    </td>
                    <td class="auto-style7">
                    </td>
                    <td class="auto-style7"></td>
                    <td class="auto-style7"></td>
                </tr>
                <tr>
                    <td colspan="6">
                        <table>
                             <tr>
                                <td class="auto-style1"></td>  
                                <td style="width: 270px; height: 33px;">
                                </td>
                                 <td style="margin-left: 40px" class="auto-style3">
                                    <asp:Button ID="btnSave" runat="server" Text="Save" Height="30px" Width="75px" OnClick="btnSave_Click"/> &nbsp;
                                    <asp:Button ID="btnEdit" runat="server" Text="Edit" Height="30px" Width="75px" OnClick="btnEdit_Click"/>&nbsp;
                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" Height="30px" Width="75px" OnClick="btnDelete_Click"/>
                                </td>
                                <td class="auto-style3"></td>
                            </tr>
                        </table>
                    </td>
                </tr>
              <%--  <tr>
                    <td style="width: 209px">&nbsp;</td>
                    <td style="width: 470px">&nbsp;</td>
                    <td style="margin-left: 40px">&nbsp;</td>
                    <td class="auto-style3"></td>
                    <td class="auto-style3"></td>
                    <td class="auto-style3"></td>
                </tr>--%>
            </table>

            <div>
    </div>
        </asp:Panel>



</asp:Content>
