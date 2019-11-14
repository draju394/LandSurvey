<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HOClarificationDoc.aspx.cs" Inherits="LandSurvey.HO.HOClarificationDoc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
         .btn-primary, .btn-primary:hover, .btn-primary:active, .btn-primary:visited
        {
        background-color: saddlebrown !important;
        border-color: saddlebrown !important;
        }
    </style>
    <div class="row" style="background-color:#f1c371;height:35px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
            <div class="col-md-4">
                <label for="" style="color:saddlebrown;font-size: 18px;">Clarification Document</label>
            </div>
            <div class="col-md-4">
                <label for="" style="color:saddlebrown;font-size: 18px;">Village Name:</label>
                 <asp:Label  id="lblVillageCode" runat="server" style="color:white;font-size: 18px;"></asp:Label>
                  <asp:Label  id="lblVillageCodeHidden" runat="server" style="color:white;font-size: 18px;" Visible="False"></asp:Label>
            </div>
            <div class="col-md-4">
                <label for="" style="color:saddlebrown;font-size: 18px;">Document Number:</label>
                 <asp:Label  id="LblDocNo" runat="server" style="color:white;font-size: 18px;"></asp:Label>
            </div>
   </div>
    <br />
    <div class="upload" style="background-color:#f1c371;height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
        <div class="col-md-3" >
           <asp:Button ID="btnClrPTS" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Clarifications On PTS" Width="270px" xmlns:asp="#unknown" OnClick="btnClrPTS_Click" />
        </div> 
        <div class="col-lg-3" style="padding-top:5px">
          <asp:FileUpload ID="FileUploadClrPTS" runat="server" Height="30px" Width="208px" />
        </div>
      <div class="col-lg-5" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Uploaded Clarification PTS:</label>
          <asp:LinkButton ID="lbllinkClrPTS" runat="server" OnClick="lbllinkClrPTS_Click"></asp:LinkButton>
      </div>
   </div>

    <br />
    <div class="upload" style="background-color:#f1c371;height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
        <div class="col-md-3" >
           <asp:Button ID="btnClrFTS" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Clarifications on FTS" Width="270px" xmlns:asp="#unknown" OnClick="btnClrFTS_Click" />
        </div> 
        <div class="col-lg-3" style="padding-top:5px">
          <asp:FileUpload ID="FileUploadClrFTS" runat="server" Height="30px" Width="208px" />
        </div>
      <div class="col-lg-5" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Uploaded Clarification on FTS:</label>
          <asp:LinkButton ID="lbllnkClrFTS" runat="server" OnClick="lbllnkClrFTS_Click" ></asp:LinkButton>
      </div>
   </div>

    <br />
    <div class="upload" style="background-color:#f1c371;height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
        <div class="col-md-3" >
           <asp:Button ID="btnClrNotice" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Clarifications On Notice" Width="270px" xmlns:asp="#unknown" OnClick="btnClrNotice_Click" />
        </div> 
        <div class="col-lg-3" style="padding-top:5px">
          <asp:FileUpload ID="FileUploadClrNotice" runat="server" Height="30px" Width="208px" />
        </div>
      <div class="col-lg-5" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Uploaded Clarification on Notice:</label>
          <asp:LinkButton ID="lbllinkClrNotice" runat="server" OnClick="lbllinkClrNotice_Click"></asp:LinkButton>
      </div>
   </div>

    <br />
    

    <br />
    
    <div style="padding-top:5px">
        <a href="javascript: history.go(-1)">Go Back</a>
    </div>

    </asp:Content>