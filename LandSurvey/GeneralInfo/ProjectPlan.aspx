<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectPlan.aspx.cs" Inherits="LandSurvey.GeneralInfo.ProjectPlan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="118px">
        <style>
            td {
                 text-align: center;
                vertical-align: middle;
                }
        </style>
       
    <table style="width:100%;">
        <tr>
            <td colspan="2" style="text-align:left">
                <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Medium" Text="Project Plan"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <object width="725" height="500" type="application/pdf" data="../Images/Layout.pdf?#zoom=85&scrollbar=0&toolbar=0&navpanes=0">
                    <p>Project Plan Not Found.</p>
                </object>
              
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
        <br>
    </asp:Panel>
</asp:Content>
