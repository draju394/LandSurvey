<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HTMLInwardOutwardReg.aspx.cs" Inherits="LandSurvey.Reports.HTMLInwardOutwardReg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
      <style>
        body{padding-top:0px}
        </style>

    <script src="../Scripts/Validation.js" type="text/javascript"></script>



     <br />
    <asp:Panel ID="Panel1" runat="server">
        <table>
            <tr>
                <td>
                     &nbsp; <asp:Button ID="btnBack" runat="server" Text="Back" Height="30px" Width="75px" OnClick="btnBack_Click"/>
                     &nbsp; <asp:Button ID="btnExportToExcel" runat="server" Text="Export To Excel" Height="30px" Width="143px" OnClick="btnExportToExcel_Click"/>
                     &nbsp; <asp:Button ID="btnExportToPDF" runat="server" Text="Export To PDF" Height="30px" Width="132px" OnClick="btnExportToPDF_Click"/>
                </td>
            </tr>
        </table>
    
    </asp:Panel>

</asp:Content>
