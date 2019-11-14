<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmMutationFinal.aspx.cs" Inherits="LandSurvey.Masters.frmMutationFinal" %>
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
              width: 288px;
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
    <br />
    <br />
    <br />
    <br />
      <asp:Panel ID="Panel1" runat="server">
            <table class="auto-style4" >
                <tr>
                    <td style="width: 209px">&nbsp;</td>
                    <td colspan="4">&nbsp;<asp:Label ID="lblHeading" runat="server" Font-Bold="True" Font-Size="Medium" Text="Label"></asp:Label>

                        &nbsp;<asp:GridView ID="grdMutationFinal" runat="server" AllowPaging="True" PageSize="5" Width="988px" 
                            CssClass= "table table-striped table-bordered table-condensed" AutoGenerateSelectButton="True" OnPageIndexChanging="grdMutationFinal_PageIndexChanging" OnRowDataBound="grdMutationFinal_RowDataBound" OnSelectedIndexChanged="grdMutationFinal_SelectedIndexChanged">
                            </asp:GridView>
                    </td>
                    <td style="width: 209px">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="6">
                        <table>
                            <tr>
                                <td style="width: 209px">&nbsp;</td>
                                <td class="auto-style9">
                                    <asp:Label ID="lblVillageName" runat="server" Text="Village Name:"></asp:Label>
                                </td>
                                <td class="auto-style14">
                                     <asp:DropDownList ID="dpVillageName" runat="server" CssClass="auto-style5"  Height="37px" Width="189px" AutoPostBack="True"></asp:DropDownList>
                                </td>
                                <td class="auto-style13">&nbsp;</td>
                                <td class="auto-style11">
                                    <asp:Label ID="lblmutaionno" runat="server" Text="Mutation Number:"></asp:Label>
                                </td>
                                <td style="height: 33px">
                                    <asp:TextBox ID="txtMutationNo" runat="server" CssClass="form-control"  Height="37px" Width="189px"></asp:TextBox>
                                </td>
                                <td style="width: 209px"></td>
                            </tr>
                             <tr>
                                <td style="width: 209px">&nbsp;</td>
                                 <td class="auto-style9">
                                    <asp:Label ID="lblMutationDate" runat="server" Text="Mutation Date:"></asp:Label>
                                </td>
                                <td class="auto-style14">
                                    <asp:TextBox ID="txtMutaionDate" runat="server" CssClass="auto-style5"  Height="37px" Width="230px"></asp:TextBox>
                                </td>
                                <td class="auto-style13">&nbsp;</td>
                                <td class="auto-style11">
                                    <asp:Label ID="lblSurveyNo" runat="server" Text="Survey No:"></asp:Label>
                                </td>
                                <td style="height: 33px">
                                    <asp:TextBox ID="txtSurveyNo" runat="server" CssClass="form-control"  Height="37px" Width="189px"></asp:TextBox>
                                </td>
                                <td style="width: 209px"></td>
                            </tr>
                            <tr>
                                <td style="width: 209px">&nbsp;</td>
                                <td class="auto-style10">
                                    <asp:Label ID="lblRemarks" runat="server" Text="Remarks:"></asp:Label>
                                </td>
                                <td class="auto-style14">
                                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="auto-style5" Height="37px" Width="230px"></asp:TextBox>
                                </td>
                                <td class="auto-style13">&nbsp;</td>
                                <td class="auto-style12">
                                    <asp:Label ID="lblMutationOrderRec" runat="server" Text="Mutation Order Rec:"></asp:Label>
                                </td>
                                <td style="height: 33px">
                                    <asp:TextBox ID="txtMutationOrderRec" runat="server" CssClass="form-control" Height="37px" Width="189px"></asp:TextBox>
                                </td>
                                <td style="width: 209px">&nbsp;</td>
                            </tr>  
                            <tr>
                                <td style="width: 209px">&nbsp;</td>
                                <td class="auto-style10">
                                    <asp:Label ID="lblMutated712Rec" runat="server" Text="Mutated 712 Rec:"></asp:Label>
                                </td>
                                <td class="auto-style14">
                                    <asp:TextBox ID="txtMutated_712_Rec" runat="server" CssClass="auto-style5" Height="37px" Width="230px"></asp:TextBox>
                                    <%--<asp:DropDownList ID="dpMutated712Rec" runat="server" CssClass="auto-style5"  Height="37px" Width="189px" AutoPostBack="True">
                                        <asp:ListItem> 
                                        </asp:ListItem>
                                    </asp:DropDownList>--%>
                                </td>
                                <td class="auto-style13">
                                    &nbsp;
                                </td>
                                <td class="auto-style11">
                                    &nbsp;
                                </td>
                                <td style="width: 209px">&nbsp;</td>
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
                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" Height="30px" Width="75px" OnClick="btnDelete_Click"/>&nbsp;
                                     <asp:Button ID="btnReport" runat="server" Text="Report" Height="30px" Width="75px" OnClick="btnReport_Click"/>
                                </td>
                                <td class="auto-style3"></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
      </asp:Panel>
</asp:Content>
