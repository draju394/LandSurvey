<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Village2.aspx.cs" Inherits="LandSurvey.Masters.Village2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel2" runat="server" Height="133px">
        <br />
        <asp:Panel ID="Panel1" runat="server">
            <table style="width:100%;">
                <tr>
                    <td style="width: 171px">&nbsp;</td>
                    <td class="modal-sm" style="width: 226px">Village Code:</td>
                    <td>
                        <asp:TextBox ID="txtVillageCode" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 171px">&nbsp;</td>
                    <td class="modal-sm" style="width: 226px">Village Name:</td>
                    <td>
                        <asp:TextBox ID="txtVillageName" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 171px">&nbsp;</td>
                    <td class="modal-sm" style="width: 226px">Village Marathi Name:</td>
                    <td>
                        <asp:TextBox ID="txtVIllageMarathiName" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 171px">&nbsp;</td>
                    <td class="modal-sm" style="width: 226px">&nbsp;</td>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
