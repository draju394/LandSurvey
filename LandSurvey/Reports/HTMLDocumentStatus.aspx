<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HTMLDocumentStatus.aspx.cs" Inherits="LandSurvey.Reports.HTMLDocumentStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
      <style>
        body{padding-top:0px}
          .auto-style3 {
              height: 8px;
          }
          .auto-style4 {
              width: 106px;
          }
        </style>

    <script src="../Scripts/Validation.js" type="text/javascript"></script>

 <br />
     <br />
     <br />
    <br />
    <br />
    <asp:Panel ID="Panel1" runat="server">
        <table>
            <tr>     
                <td>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="District :" Font-Bold="true"></asp:Label>
                            </td>
                            <td>
                                &nbsp;<asp:Label ID="Label3" runat="server" Text="Thane" Font-Bold="true"></asp:Label>
                            </td>
                             <td class="auto-style4">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Taluka :" Font-Bold="true"></asp:Label>
                            </td>
                            <td>
                                &nbsp;<asp:Label ID="Label4" runat="server" Text="Bhivandi" Font-Bold="true"></asp:Label>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" class="auto-style3">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <table>
                                    <tr>
                                         <td>
                                            <asp:Label ID="lblVillageName" runat="server" Text="Village Name :" Font-Bold="true"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;<asp:DropDownList ID="dpVillageName" runat="server" Font-Bold="true" CssClass="auto-style5" Width="189px" AutoPostBack="True" Height="25px"></asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>                     
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                     &nbsp; <asp:Button ID="btnBack" runat="server" Text="Back" Height="30px" Width="75px" Visible="false"/>
                     &nbsp; <asp:Button ID="btnExportToExcel" runat="server" Text="Export To Excel" Height="30px" Width="143px"/>
                     &nbsp; <asp:Button ID="btnExportToPDF" runat="server" Text="Export To PDF" Height="30px" Width="132px"/>
                </td>
            </tr>
        </table>
    
    </asp:Panel>
</asp:Content>
