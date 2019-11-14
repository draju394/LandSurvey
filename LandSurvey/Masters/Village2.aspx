<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Village2.aspx.cs" Inherits="LandSurvey.Masters.Village2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <style>
        body{padding-top:0px}
        .auto-style1 {
            width: 209px;
            height: 26px;
        }
        .auto-style2 {
            width: 5px;
            height: 26px;
        }
        .auto-style3 {
            height: 26px;
        }
    </style>

 <script src="../Scripts/Validation.js" type="text/javascript"></script>  
    <script  type="text/javascript">  
        function Validation() {  
            if (Required('<%=txtVillageCode.ClientID%>', 'Village Code'))  
                if (Required('<%=txtVillageName.ClientID%>', 'Village Name'))  
                    if (Required('<%=txtVIllageMarathiName.ClientID%>', 'Village Marathi Name '))  
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
 
            // Enable transliteration in the textbox with id
            // 'transliterateTextarea'.
           // control.makeTransliteratable(['transliterateTextarea']);
            //control.makeTransliteratable(['transliterateTextarea.ClientID']);
            control.makeTransliteratable(['<%= txtVIllageMarathiName.ClientID %>']);
 
 
        }
        google.setOnLoadCallback(onLoad);
    </script>
 

       
        <br />
        <asp:Panel ID="Panel1" runat="server">
            <table class="nav-justified" >
                <tr>
                    <td style="width: 209px">&nbsp;</td>
                    <td colspan="2">&nbsp;<asp:Label ID="lblHeading" runat="server" Font-Bold="True" Font-Size="Medium" Text="Label"></asp:Label>
&nbsp;<asp:GridView ID="grdVillage" runat="server" AllowPaging="True" PageSize="5" Width="800" 
                            CssClass= "table table-striped table-bordered table-condensed" OnPageIndexChanging="grdVillage_PageIndexChanging" OnRowDataBound="grdVillage_RowDataBound" >
            </asp:GridView>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 209px">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 209px">&nbsp;</td>
                    <td>Village Code:</td>
                    <td>
                        <asp:TextBox ID="txtVillageCode" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 209px">&nbsp;</td>
                    <td>Village Name:</td>
                    <td>
                        <asp:TextBox ID="txtVillageName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 209px">&nbsp;</td>
                    <td>Village Marathi Name:</td>
                    <td>
                        <asp:TextBox ID="txtVIllageMarathiName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td class="auto-style3"></td>
                    <td style="margin-left: 40px" class="auto-style3">
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" OnClientClick="javascript:return Validation();" />
                    </td>
                    <td class="auto-style3"></td>
                </tr>
                <tr>
                    <td style="width: 209px">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td style="margin-left: 40px">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>

            <div>
    </div>
        </asp:Panel>
   
</asp:Content>
