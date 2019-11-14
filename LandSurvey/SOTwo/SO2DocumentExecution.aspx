<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SO2DocumentExecution.aspx.cs" Inherits="LandSurvey.SOTwo.SO2DocumentExecution" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../Scripts/jquery.validate.min.js"></script>
    <script src="../Scripts/ej.web.all.min.js"></script>
    <script src="../Scripts/ej.grid.min.js"></script>
    <script src="../Scripts/ej.unobtrusive.min.js"></script>
    <script src="../Scripts/jquery.validate.unobtrusive.min.js"></script>
    <link href="../Content/ej.widgets.core.min.css" rel="stylesheet" />
    <link href="../Content/ej.web.all.min.css" rel="stylesheet" />

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
                <label for="" style="color:saddlebrown;font-size: 18px;">Document Execution - Recieved from Head Office </label>
                <label for="" style="color: white;font-size: 18px;" id="PopulationID"></label>
            </div>
            <div class="col-md-2">
                 <asp:TextBox ID="txtDocNo" runat="server" Visible="False"></asp:TextBox>
               <%-- <label for="" style="color:white;font-size: 18px;">बूथ संख्या :-</label>
                <label for="" style="color: white;font-size: 18px;" id="Booth_numberID"></label>--%>
            </div>
            <div class="col-md-2">
               <%-- <label for="" style="color:white;font-size:18px;"> मतदारसंघ :</label>
                <label for="" style="color:white;font-size: 18px;" id="Vidhansabha_Id"></label>--%>
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
                 <br /> 
       
       <div class="row" style="background-color:#f1c371;height:35px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
            <%--<div class="col-md-4">
                <label for="" style="color:saddlebrown;font-size: 13px;">Generate Primary Search Report</label>
              
            </div>--%>
           <div class="col-md-12" style="text-align:center">
                <label for="" style="color:saddlebrown;font-size: 13px;">Documents Submitted by Head Office</label>
               <%--<asp:Label ID="lblDocNo" runat="server" Text="" Visible="True" style="color:saddlebrown;font-size: 12px;"></asp:Label>--%>
              
           <%-- </div>
                 <div class="col-md-4">
                <label for="" style="color:saddlebrown;font-size: 12px;">Family No : </label>
                <asp:Label ID="lblFamily" runat="server" Text="" Visible="True" style="color:saddlebrown;font-size: 12px;"></asp:Label>
              
            </div>--%>
       </div>

            
        <%-- Grid Data --%>
    <div style="padding-top:20px" >
         <ej:Grid ID="grdFamilyDocDetails" runat="server"  AllowPaging="True" IsResponsive="True" OnServerPdfExporting="grdFamilyDocDetails_ServerPdfExporting" >
                    <ToolbarSettings ShowToolbar="true" ToolbarItems="excelExport,wordExport,pdfExport"></ToolbarSettings>
                    <PageSettings PageSize="6"></PageSettings>
                      <Columns>
                        <ej:Column Field="srno" HeaderText="Sr.No."  Width="40" />
                        <ej:Column Field="location" HeaderText="Location" Width="75" HeaderTemplateID="#empTemplate"   />
                        <ej:Column Field="documentename" HeaderText="Document Name"  Width="200" />
                        <ej:Column Field="documentname" HeaderText="Document File" Width="100" />
                        <ej:Column Field="createddate" HeaderText="Uploaded Date" Width="100" DataType="date" Format="{0:dd/MM/yyyy}" /> 
                        <%--<ej:Column Field="surveyrate" HeaderText="Survey Rate" Width="75" />--%>
                    </Columns>

         </ej:Grid>
    </div>

    
           <br />
    <div class="upload" style="background-color:#f1c371;height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
        <div class="col-md-3" >
           <asp:Button ID="btnRegistrationSearch" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Send SMS" Width="270px" xmlns:asp="#unknown" OnClick="btnRegistrationSearch_Click"/>
        </div> 
       <%-- <div class="col-lg-3" style="padding-top:5px">
          <asp:FileUpload ID="FileUploadRegistrationSearch" runat="server" Height="30px" Width="208px" />
        </div>
      <div class="col-lg-5" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Uploaded Registration Search Report:</label>
          <asp:LinkButton ID="lbllinkRegisrationSearch" runat="server" OnClick="lbllinkRegisrationSearch_Click">File Not Uploaded</asp:LinkButton>
      </div>--%>
   </div>

   
  
<br />
<br />

       <%-- end Page Coading --%>
    </asp:Panel>
</asp:Content>
