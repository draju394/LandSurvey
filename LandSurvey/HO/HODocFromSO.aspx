<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HODocFromSO.aspx.cs" Inherits="LandSurvey.HO.HODocFromSO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%--<script src="../Scripts/jquery.validate.min.js"></script>
    <script src="../Scripts/ej.web.all.min.js"></script>
    <script src="../Scripts/ej.grid.min.js"></script>
    <script src="../Scripts/ej.unobtrusive.min.js"></script>
    <script src="../Scripts/jquery.validate.unobtrusive.min.js"></script>
    <link href="../Content/ej.widgets.core.min.css" rel="stylesheet" />
    <link href="../Content/ej.web.all.min.css" rel="stylesheet" />--%>
    <script type="text/javascript"> 
           function rowSelect(args) {  
               
               var record = this.getSelectedRecords(); 
               $("#SelectRecords").val(JSON.stringify(record)); 
 
            } 
        
        </script> 
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
        .auto-style4 {
            position: relative;
            min-height: 1px;
            float: left;
            width: 25%;
            left: 0px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
    <asp:Panel ID="Panel1" runat="server" Height="100%" Width="100%">
    <%-- Page Coading --%>
  

     <div class="row" style="background-color:#f1c371;height:35px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
            <div class="col-md-8">
                <label for="" style="color:saddlebrown;font-size: 18px;">Documents Received from Site Offices</label>
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
            <div class="col-md-4">
                <label for="" style="color:saddlebrown;font-size: 13px;">Document Submitted by Site Offices</label>
              
            </div>
           <div class="col-md-2">
                <label for="" style="color:saddlebrown;font-size: 13px;">Document Number : </label>
               <asp:Label ID="lblDocNo" runat="server" Text="" Visible="True" style="color:saddlebrown;font-size: 12px;"></asp:Label>
              
            </div>
                 <div class="col-md-4">
                <label for="" style="color:saddlebrown;font-size: 12px;">Family No : </label>
                <asp:Label ID="lblFamily" runat="server" Text="" Visible="True" style="color:saddlebrown;font-size: 12px;"></asp:Label>
              
            </div>
       </div>
        <br />
        <%-- Two Column Start  --%>
        
   <%-- <asp:Panel ID="PanelAllUploadDoc" runat="server" >--%>
        <%-- Upload Document --%>
  <%-- <div class="upload" style="background-color:#f1c371;height:30px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
            <div class="col-md-3" >
                <label style="color: white;font-size: 14px; color:saddlebrown;">Site office - 1</label>
            </div> 
             <div class="col-md-3" >
                <label style="color: white;font-size: 14px; color:saddlebrown;">Checklist - Mutation Search</label>
            </div> 

              <div class="col-lg-3">
                <asp:Label ID="lblDateChkList" runat="server" Text="" Visible="True" style="color:saddlebrown;font-size: 14px;">Date Of File</asp:Label>
            </div>
       
            <div class="col-lg-3">
             <asp:LinkButton ID="btnLinkChkList" runat="server" style="color:saddlebrown;font-size: 14px;" OnClick="btnLinkChkList_Click">File Not Uploaded</asp:LinkButton>
            </div>
        </div>--%>

         <div class="upload" style="background-color:#f1c371;height:30px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
            <div class="col-md-3" >
                <label style="color: white;font-size: 14px; color:saddlebrown;">Site office - 1</label>
            </div> 
             <div class="col-md-3" >
                <label style="color: white;font-size: 14px; color:saddlebrown;">Mutation Search Report with Remark</label>
            </div> 

              <div class="col-lg-3">
                <asp:Label ID="lblDateMSR" runat="server" Text="" Visible="True" style="color:saddlebrown;font-size: 14px;">Date Of File</asp:Label>
            </div>
       
            <div class="col-lg-3">
                <asp:LinkButton ID="btnLinkMSR" runat="server" OnClick="btnLinkMSR_Click"></asp:LinkButton>
            </div>
        </div>

        <%--<div class="upload" style="background-color:#f1c371;height:30px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
            <div class="col-md-3" >
                <label style="color: white;font-size: 14px; color:saddlebrown;">Site office - 1</label>
            </div> 
             <div class="col-md-3" >
                <label style="color: white;font-size: 14px; color:saddlebrown;">Checklist Remarks - Mutation Search</label>
            </div> 

              <div class="col-lg-3">
                <asp:Label ID="lblDateRCMS" runat="server" Text="" Visible="True" style="color:saddlebrown;font-size: 14px;">Date Of File</asp:Label>
            </div>
       
            <div class="col-lg-3">
             <%--<asp:LinkButton ID="btnLinkRCMS" runat="server" style="color:saddlebrown;font-size: 14px;" OnClick="btnLinkRCMS_Click">File Not Uploaded</asp:LinkButton>--%>
                <%--<asp:LinkButton ID="btnLinkRCMS" runat="server" OnClick="btnLinkRCMS_Click"></asp:LinkButton>--%>
               <%-- <asp:LinkButton ID="btnLinkRCMS" runat="server" OnClick="btnLinkRCMS_Click">LinkButton</asp:LinkButton>
            </div>
        </div>--%>

        <div class="upload" style="background-color:#f1c371;height:30px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
            <div class="col-md-3" >
                <label style="color: white;font-size: 14px; color:saddlebrown;">Site office - 1</label>
            </div> 
             <div class="col-md-3" >
                <label style="color: white;font-size: 14px; color:saddlebrown;">Other Document</label>
            </div> 

              <div class="col-lg-3">
                <asp:Label ID="lblDateODMS" runat="server" Text="" Visible="True" style="color:saddlebrown;font-size: 14px;">Date Of File</asp:Label>
            </div>
       
            <div class="col-lg-3">
             <%--<asp:LinkButton ID="btnLinkODMS" runat="server" style="color:saddlebrown;font-size: 14px;" OnClick="btnLinkODMS_Click">File Not Uploaded</asp:LinkButton>--%>
                <%--<asp:LinkButton ID="btnLinkODMS" runat="server" OnClick="btnLinkODMS_Click"></asp:LinkButton>--%>
                <asp:LinkButton ID="btnLinkODMS" runat="server" OnClick="btnLinkODMS_Click">LinkButton</asp:LinkButton>
            </div>
        </div>
        <%--<div class="upload" style="background-color:#f1c371;height:30px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
            <div class="col-md-3" >
                <label style="color: white;font-size: 14px; color:saddlebrown;">Site office - 2</label>
            </div> 
             <div class="col-md-3" >
                <label style="color: white;font-size: 14px; color:saddlebrown;">Checklist-Registry Search</label>
            </div> 

              <div class="col-lg-3">
                <asp:Label ID="lblDateCRS" runat="server" Text="" Visible="True" style="color:saddlebrown;font-size: 14px;">Date Of File</asp:Label>
            </div>
       
            <div class="col-lg-3">
             <%--<asp:LinkButton ID="btnLinkCSR" runat="server" style="color:saddlebrown;font-size: 14px;" OnClick="btnLinkCSR_Click">File Not Uploaded</asp:LinkButton>--%>
               <%-- <asp:LinkButton ID="btnLinkCSR" runat="server" OnClick="btnLinkCSR_Click">LinkButton</asp:LinkButton>
            </div>
        </div>--%>

        <div class="upload" style="background-color:#f1c371;height:30px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
            <div class="col-md-3" >
                <label style="color: white;font-size: 14px; color:saddlebrown;">Site office - 2</label>
            </div> 
             <div class="col-md-3" >
                <label style="color: white;font-size: 14px; color:saddlebrown;">Registry Search Report with Remarks</label>
            </div> 

              <div class="col-lg-3">
                <asp:Label ID="lblDateRSR" runat="server" Text="" Visible="True" style="color:saddlebrown;font-size: 14px;">Date Of File</asp:Label>
            </div>
       
            <div class="auto-style4">
             <%--<asp:LinkButton ID="btnLinkRSR" runat="server" style="color:saddlebrown;font-size: 14px;" OnClick="btnLinkRSR_Click">File Not Uploaded</asp:LinkButton>--%>
                <asp:LinkButton ID="btnLinkRSR" runat="server" OnClick="btnLinkRSR_Click">LinkButton</asp:LinkButton>
            </div>
        </div>

         <%--<div class="upload" style="background-color:#f1c371;height:30px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
            <div class="col-md-3" >
                <label style="color: white;font-size: 14px; color:saddlebrown;">Site office - 2</label>
            </div> 
             <div class="col-md-3" >
                <label style="color: white;font-size: 14px; color:saddlebrown;">Checklist Remarks-Registry Search</label>
            </div> 

              <div class="col-lg-3">
                <asp:Label ID="lblDateRCRS" runat="server" Text="" Visible="True" style="color:saddlebrown;font-size: 14px;">Date Of File</asp:Label>
            </div>
       
            <div class="col-lg-3">
             <%--<asp:LinkButton ID="btnLinkRCRS" runat="server" style="color:saddlebrown;font-size: 14px;" OnClick="btnLinkRCRS_Click">File Not Uploaded</asp:LinkButton>--%>
              <%--  <asp:LinkButton ID="btnLinkRCRS" runat="server" OnClick="btnLinkRCRS_Click">LinkButton</asp:LinkButton>
            </div>
        </div>--%>

        <div class="upload" style="background-color:#f1c371;height:30px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
            <div class="col-md-3" >
                <label style="color: white;font-size: 14px; color:saddlebrown;">Site office - 2</label>
            </div> 
             <div class="col-md-3" >
                <label style="color: white;font-size: 14px; color:saddlebrown;">Local Inquiry Report</label>
            </div> 

              <div class="col-lg-3">
                <asp:Label ID="lblDateLI" runat="server" Text="" Visible="True" style="color:saddlebrown;font-size: 14px;">Date Of File</asp:Label>
            </div>
       
            <div class="col-lg-3">
             <%--<asp:LinkButton ID="btnLinkLI" runat="server" style="color:saddlebrown;font-size: 14px;" OnClick="btnLinkLI_Click">File Not Uploaded</asp:LinkButton>--%>
                <%--<asp:LinkButton ID="btnLinkLI" runat="server" OnClick="btnLinkLI_Click">LinkButton</asp:LinkButton>--%>
                <asp:LinkButton ID="btnLinkLI" runat="server" OnClick="btnLinkLI_Click">LinkButton</asp:LinkButton>
            </div>
        </div>

        <div class="upload" style="background-color:#f1c371;height:30px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
            <div class="col-md-3" >
                <label style="color: white;font-size: 14px; color:saddlebrown;">Site office - 2</label>
            </div> 
             <div class="col-md-3" >
                <label style="color: white;font-size: 14px; color:saddlebrown;">Family Tree</label>
            </div> 

              <div class="col-lg-3">
                <asp:Label ID="lblDateFT" runat="server" Text="" Visible="True" style="color:saddlebrown;font-size: 14px;">Date Of File</asp:Label>
            </div>
       
            <div class="col-lg-3">
             <%--<asp:LinkButton ID="btnLinkFT" runat="server" OnClick="btnLinkFT_Click">File Not Uploaded</asp:LinkButton>--%>
                 <%--<asp:LinkButton ID="lbllinkVisarPavti" runat="server" OnClick="lbllinkVisarPavti_Click">File Not Uploaded</asp:LinkButton>--%>
                <asp:LinkButton ID="btnLinkFT" runat="server" OnClick="btnLinkFT_Click"></asp:LinkButton>

            </div>
        </div>

        <div class="upload" style="background-color:#f1c371;height:30px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
            <div class="col-md-3" >
                <label style="color: white;font-size: 14px; color:saddlebrown;">Site office - 2</label>
            </div> 
             <div class="col-md-3" >
                <label style="color: white;font-size: 14px; color:saddlebrown;">Survey No wise Registry Search</label>
            </div> 

              <div class="col-lg-3">
                <asp:Label ID="lblDateRegistry" runat="server" Text="" Visible="True" style="color:saddlebrown;font-size: 14px;">Date Of File</asp:Label>
            </div>
       
            <div class="col-lg-3">
             <%--<asp:LinkButton ID="LinkButton9" runat="server" style="color:saddlebrown;font-size: 14px;">File Not Uploaded</asp:LinkButton>--%>

                <%--<asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">LinkButton</asp:LinkButton>--%>
            </div>
        </div>



    <br />
    <br />
   <%-- </asp:Panel > --%>  
    

   
  
<br />
<br />

       <%-- end Page Coading --%>
    </asp:Panel>
</asp:Content>
