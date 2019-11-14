<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SO2OtherDocument.aspx.cs" Inherits="LandSurvey.SOTwo.SO2OtherDocument" %>
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
                <label for="" style="color:saddlebrown;font-size: 18px;">Site Office 2 - Upload Document</label>
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
           <asp:Button ID="btnRegistrationSearch" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Registration Search Report" Width="270px" xmlns:asp="#unknown" OnClick="btnRegistrationSearch_Click"/>
        </div> 
        <div class="col-lg-3" style="padding-top:5px">
          <asp:FileUpload ID="FileUploadRegistrationSearch" runat="server" Height="30px" Width="208px" />
        </div>
      <div class="col-lg-5" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Uploaded Registration Search Report:</label>
          <asp:LinkButton ID="lbllinkRegisrationSearch" runat="server" OnClick="lbllinkRegisrationSearch_Click">File Not Uploaded</asp:LinkButton>
      </div>
   </div>

    <br />
    <div class="upload" style="background-color:#f1c371;height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
        <div class="col-md-3" >
           <asp:Button ID="btnLocalInquiry" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Local Inquiry" Width="270px" xmlns:asp="#unknown" OnClick="btnLocalInquiry_Click"/>
        </div> 
        <div class="col-lg-3" style="padding-top:5px">
          <asp:FileUpload ID="FileUploadLocalInquiry" runat="server" Height="30px" Width="208px" />
        </div>
      <div class="col-lg-5" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Uploaded Local Inquiry:</label>
          <asp:LinkButton ID="lbllnkLocalInquiry" runat="server" OnClick="lbllnkLocalInquiry_Click">File Not Uploaded</asp:LinkButton>
      </div>
   </div>

    <br />
    <div class="upload" style="background-color:#f1c371;height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
        <div class="col-md-3" >
           <asp:Button ID="btnFamilytree" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Family tree" Width="270px" xmlns:asp="#unknown" OnClick="btnFamilytree_Click"/>
        </div> 
        <div class="col-lg-3" style="padding-top:5px">
          <asp:FileUpload ID="FileUploadFamilyTree" runat="server" Height="30px" Width="208px" />
        </div>
      <div class="col-lg-5" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Uploaded Family Tree:</label>
          <asp:LinkButton ID="lbllinkFamilyTree" runat="server" OnClick="lbllinkFamilyTree_Click">File Not Uploaded</asp:LinkButton>
      </div>
   </div>

    <br />
    <div class="upload" style="background-color:#f1c371;height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
        <div class="col-md-3" >
           <asp:Button ID="btnConcentLetter" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Concent Letter" Width="270px" xmlns:asp="#unknown" OnClick="btnConcentLetter_Click"/>
        </div> 
        <div class="col-lg-3" style="padding-top:5px">
          <asp:FileUpload ID="FileUploadConcentLetter" runat="server" Height="30px" Width="208px" />
        </div>
      <div class="col-lg-5" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Uploaded Concent Letter:</label>
          <asp:LinkButton ID="lbllnkConcentLetter" runat="server" OnClick="lbllnkConcentLetter_Click">File Not Uploaded</asp:LinkButton>
      </div>
   </div>

    <br />
    <div class="upload" style="background-color:#f1c371;height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
        <div class="col-md-3" >
           <asp:Button ID="btnIDDoc" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Identification Document" Width="270px" xmlns:asp="#unknown" OnClick="btnIDDoc_Click"/>
        </div> 
        <div class="col-lg-3" style="padding-top:5px">
          <asp:FileUpload ID="FileUploadIDDoc" runat="server" Height="30px" Width="208px" />
        </div>
      <div class="col-lg-5" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Uploaded Identification Document:</label>
          <asp:LinkButton ID="lbllnkIDDoc" runat="server" OnClick="lbllnkIDDoc_Click">File Not Uploaded</asp:LinkButton>
      </div>
   </div>
    <div style="padding-top:5px">
        <a href="javascript: history.go(-1)">Go Back</a>
    </div>
</asp:Content>
