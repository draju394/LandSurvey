<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HTMLFinalData.aspx.cs" Inherits="LandSurvey.Reports.HTMLFinalData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
      <style>
        body{padding-top:0px}
          .auto-style3 {
              width: 94px;
          }
          .auto-style4 {
              width: 95px;
          }
          .auto-style5 {
              width: 96px;
          }
          .auto-style6 {
              width: 123px;
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
                                        <td colspan="2">
                                            <asp:RadioButtonList ID="rdbvillagename" runat="server" RepeatDirection="Horizontal" Width="230px" AutoPostBack="True" OnSelectedIndexChanged="rdbvillagename_SelectedIndexChanged" Height="20px">
                                            <asp:ListItem>Single Village</asp:ListItem>
                                             <asp:ListItem>All Villages</asp:ListItem></asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                         <td>
                                            <asp:Label ID="lblVillageName" runat="server" Text="Village Name :" Font-Bold="true" Visible="false"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;<asp:DropDownList ID="dpVillageName" runat="server" Font-Bold="true" Visible="false" CssClass="auto-style5" Width="189px" AutoPostBack="True" Height="25px" OnSelectedIndexChanged="dpVillageName_SelectedIndexChanged"></asp:DropDownList>
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
                     &nbsp; <asp:Button ID="btnBack" runat="server" Text="Back" Height="30px" Width="75px" OnClick="btnBack_Click"/>
                     &nbsp; <asp:Button ID="btnExportToExcel" runat="server" Text="Export To Excel" Height="30px" Width="143px"/>
                     &nbsp; <asp:Button ID="btnExportToPDF" runat="server" Text="Export To PDF" Height="30px" Width="132px"/>
                    &nbsp; <asp:Button ID="btnDetailedReport" runat="server" Text="Detailed Report" Height="30px" Width="138px"/>
                </td>
            </tr>
        </table>
    
    </asp:Panel>
</asp:Content>
