<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SO1OtherDocument.aspx.cs" Inherits="LandSurvey.SOOne.SO1OtherDocument" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row" style="background-color:#f1c371;height:35px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
            <div class="col-md-4">
                <label for="" style="color:saddlebrown;font-size: 18px;">Site Office 1 - Upload Document</label>
                <label for="" style="color: white;font-size: 18px;" id="PopulationID"></label>
            </div>
            <div class="col-md-2">
                <label for="" style="color:saddlebrown;font-size: 18px;">Village Code:</label>
                 <asp:Label  id="lblVillageCode" runat="server" style="color:white;font-size: 18px;"></asp:Label>
                 <%--<asp:TextBox ID="txtDocNo" runat="server" Visible="False"></asp:TextBox>--%>
              </div>
            <div class="col-md-2">
                <label for="" style="color:saddlebrown;font-size: 18px;">Document Number:</label>
                 <asp:Label  id="LblDocNo" runat="server" style="color:white;font-size: 18px;"></asp:Label>
                 <%--<asp:TextBox ID="txtDocNo" runat="server" Visible="False"></asp:TextBox>--%>
              </div>
   </div>
</asp:Content>
