<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SO2DocExecution2.aspx.cs" Inherits="LandSurvey.SOTwo.SO2DocExecution2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <style>
        .upload
        {
            margin-left: 0px;
            margin-top: 10px;
        }        

        .control
        {
            margin-left: 0px;
        }
        .btn-primary, .btn-primary:hover, .btn-primary:active, .btn-primary:visited
        {
        background-color: saddlebrown !important;
        }
    </style>
    <asp:Panel ID="Panel1" runat="server" Height="100%" Width="100%">
    <%-- Page Coading --%>
     <div class="row" style="background-color:#f1c371;height:35px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
            <div class="col-md-8">
                <label for="" style="color:saddlebrown;font-size: 18px;">Document Execution </label>
                <label for="" style="color: white;font-size: 18px;" id="PopulationID"></label>
            </div>
            <div class="col-md-2">
                 <asp:TextBox ID="txtDocNo" runat="server" Visible="False"></asp:TextBox>
             </div>
            <div class="col-md-2">
                    </div>
             </div>

         <div class="row" style="padding-top:20px">
              <div class="col-md-3 text-right" style="padding-top:5px">
                    <label for="" style="color:saddlebrown;font-size: 14px;">Select Village:</label>
              </div>
               <div class="col-md-2 text-left" >
                <asp:DropDownList ID="cmbVillage" runat="server" AutoPostBack="true" CssClass="form-control" Width="225px" OnSelectedIndexChanged="cmbVillage_SelectedIndexChanged">
                    </asp:DropDownList>
             </div>
           
             
        <div class="col-md-2 text-right" style="padding-top:5px">
            <label for="" style="color:saddlebrown;font-size: 14px">Select Document No:</label>
        </div>

        <div class="col-md-2 text-left" >
           <%-- <asp:UpdatePanel runat="server" >
                <ContentTemplate> 
                      <asp:DropDownList ID="cmbDocumentNo" runat="server" AutoPostBack="true" CssClass="form-control" Width="225px">
                     </asp:DropDownList>--%>
            <asp:DropDownList ID="cmbDocumentNo" runat="server" AutoPostBack="true" CssClass="form-control" Width="225px" OnSelectedIndexChanged="cmbDocumentNo_SelectedIndexChanged">
                    </asp:DropDownList>
       

        </div>
                      
        </div>
 <asp:Panel ID="PanelAllUploadDoc" runat="server" >
        <%-- Upload Document --%>
        <div class="upload" style="background-color:#f1c371;height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
        <div class="col-md-3" >
           <asp:Button ID="btnVisarPavti" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Visar Pavti" Width="270px" xmlns:asp="#unknown" OnClick="btnVisarPavti_Click" />
        </div> 
        <div class="col-lg-3" style="padding-top:5px">
          <asp:FileUpload ID="FileUploadVisarPavati" runat="server" Height="30px" Width="208px" />
        </div>
      <div class="col-lg-5" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Uploaded Visar Pavti:</label>
          <asp:LinkButton ID="lbllinkVisarPavti" runat="server" OnClick="lbllinkVisarPavti_Click">File Not Uploaded</asp:LinkButton>
      </div>
   </div>

    <br />
    <div class="upload" style="background-color:#f1c371;height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
        <div class="col-md-3" >
           <asp:Button ID="btnAgreementToSale" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Agreement To Sale" Width="270px" xmlns:asp="#unknown" OnClick="btnAgreementToSale_Click"/>
        </div> 
        <div class="col-lg-3" style="padding-top:5px">
          <asp:FileUpload ID="FileUploadAgreementtoSale" runat="server" Height="30px" Width="208px" />
        </div>
      <div class="col-lg-5" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Uploaded Agreement To Sale:</label>
          <asp:LinkButton ID="lbllnkAgreementToSale" runat="server" OnClick="lbllnkAgreementToSale_Click">File Not Uploaded</asp:LinkButton>
      </div>
   </div>

    <br />
    <div class="upload" style="background-color:#f1c371;height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
        <div class="col-md-3" >
           <asp:Button ID="btnSaleDeed" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Sale Deed" Width="270px" xmlns:asp="#unknown" OnClick="btnSaleDeed_Click"/>
        </div> 
        <div class="col-lg-3" style="padding-top:5px">
          <asp:FileUpload ID="FileUploadSaleDeed" runat="server" Height="30px" Width="208px" />
        </div>
      <div class="col-lg-5" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Uploaded Sale Deed:</label>
          <asp:LinkButton ID="lbllinkSaleDeed" runat="server" OnClick="lbllinkSaleDeed_Click">File Not Uploaded</asp:LinkButton>
      </div>
   </div>

    <br />
    <div class="upload" style="background-color:#f1c371;height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
        <div class="col-md-3" >
           <asp:Button ID="btnPowerOfAttorney" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="General Power of Attorney" Width="270px" xmlns:asp="#unknown" OnClick="btnPowerOfAttorney_Click"/>
        </div> 
        <div class="col-lg-3" style="padding-top:5px">
          <asp:FileUpload ID="FileUploadPowerOfAttorney" runat="server" Height="30px" Width="208px" />
        </div>
      <div class="col-lg-5" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Uploaded Power Of Attorney:</label>
          <asp:LinkButton ID="lbllnkPowerOfAttorney" runat="server" OnClick="lbllnkPowerOfAttorney_Click">File Not Uploaded</asp:LinkButton>
      </div>
   </div>

    <br />
    <div class="upload" style="background-color:#f1c371;height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
        <div class="col-md-3" >
           <asp:Button ID="btnTabaPavti" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Taba Pavti" Width="270px" xmlns:asp="#unknown" OnClick="btnTabaPavti_Click"/>
        </div> 
        <div class="col-lg-3" style="padding-top:5px">
          <asp:FileUpload ID="FileUploadTabaPavti" runat="server" Height="30px" Width="208px" />
        </div>
      <div class="col-lg-5" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Uploaded Taba Pavti:</label>
          <asp:LinkButton ID="lbllnkTabaPavti" runat="server" OnClick="lbllnkTabaPavti_Click">File Not Uploaded</asp:LinkButton>
      </div>
   </div>

        <br />
    <div class="upload" style="background-color:#f1c371;height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
        <div class="col-md-3" >
           <asp:Button ID="btnGhoshnaPatrs" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Ghoshana Patra" Width="270px" xmlns:asp="#unknown" OnClick="btnGhoshnaPatrs_Click"/>
        </div> 
        <div class="col-lg-3" style="padding-top:5px">
          <asp:FileUpload ID="FileUploadGhoshanaPatra" runat="server" Height="30px" Width="208px" />
        </div>
      <div class="col-lg-5" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Uploaded Ghoshana Patra:</label>
          <asp:LinkButton ID="lblLinkGhoshanaPatra" runat="server" OnClick="lblLinkGhoshanaPatra_Click">File Not Uploaded</asp:LinkButton>
      </div>
   </div>

                <br />
    <div class="upload" style="background-color:#f1c371;height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
        <div class="col-md-3" >
           <asp:Button ID="btnHamiPatra" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Hami Patra" Width="270px" xmlns:asp="#unknown" OnClick="btnHamiPatra_Click"/>
        </div> 
        <div class="col-lg-3" style="padding-top:5px">
          <asp:FileUpload ID="FileUploadHamiPatra" runat="server" Height="30px" Width="208px" />
        </div>
      <div class="col-lg-5" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Uploaded Hami Patra:</label>
          <asp:LinkButton ID="lblLinkHamiPatra" runat="server" OnClick="lblLinkHamiPatra_Click">File Not Uploaded</asp:LinkButton>
      </div>
   </div>
    <%--<div style="padding-top:5px">
        <a href="javascript: history.go(-1)">Go Back</a>
    </div>--%>

    </asp:Panel >
                 <br /> 
       

  
<br />
<br />

       <%-- end Page Coading --%>
    </asp:Panel>
</asp:Content>
