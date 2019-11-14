<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaymentNoteList.aspx.cs" Inherits="LandSurvey.Accounts.PaymentNoteList" %>
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
        border-color: saddlebrown !important;
        }
    </style>

    <div class="row" style="background-color:#f1c371;height:35px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
            <div class="col-md-8">
                <label for="" style="color:saddlebrown;font-size: 18px;">Payment Demand List</label>
            </div>
            <div class="col-md-2">
                 <asp:TextBox ID="txtDocNo" runat="server" Visible="False"></asp:TextBox>
           </div>
            <div class="col-md-2">
              
            </div>
    </div>

     <br />
            <ej:Grid ID="grdPaymentNote" runat="server" AllowPaging="True" IsResponsive="True" AllowTextWrap="true" OnServerPdfExporting="grdPaymentNote_ServerPdfExporting">
                <ToolbarSettings ShowToolbar="true" ToolbarItems="excelExport,wordExport,pdfExport"></ToolbarSettings>
                <PageSettings PageSize="5"></PageSettings>
                <TextWrapSettings WrapMode="Both" />
                <Columns>
               <%--     <ej:Column Field="srno" HeaderText="Sr. No." Width="5%"/>--%>
                    <ej:Column Field="demandnote" HeaderText="Demand No" />
                    <ej:Column Field="demanddate" HeaderText="Demand Date" />
                    <ej:Column Field="villagecode" HeaderText="Village" />
                    <ej:Column Field="documentno" HeaderText="Document" />
                    <ej:Column Field="seriesno" HeaderText="Series No" />
                    <ej:Column Field="phaseno" HeaderText="Phase No" />
                    <ej:Column Field="totaldemand" HeaderText="Total Demand" type="number"   />
                    <ej:Column Field="demandsent" HeaderText="Demand Sent" />
                    <ej:Column Field="demandapprove" HeaderText="Demand Approved" />
                    <%--<ej:Column Field="recordupdation" HeaderText="Record Updation" />--%>
                   
                </Columns>
            </ej:Grid>

    <br />

    <div class="upload" style="background-color:#f1c371;height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
       <div class="col-md-4" >
            <asp:Button ID="btnAddPaymentNote" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Add Payment Demand Note" Width="270px" xmlns:asp="#unknown" OnClick="btnAddPaymentNote_Click" />
       </div> 
              
        <div class="col-lg-3" style="padding-top:5px">
                            
        </div>
      <div class="col-lg-5" style="padding-top:5px" >
         

      </div>
        
   </div>

</asp:Content>
