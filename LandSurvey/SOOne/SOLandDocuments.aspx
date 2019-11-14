<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SOLandDocuments.aspx.cs" Inherits="LandSurvey.SOOne.SOLandDocuments" %>
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
                <label for="" style="color:saddlebrown;font-size: 18px;">Land Releated Documents </label>
                <label for="" style="color: white;font-size: 18px;" id="PopulationID"></label>
            </div>
            <%--<div class="col-md-2">
                 <asp:TextBox ID="txtDocNo" runat="server" Visible="False"></asp:TextBox>--%>
               <%-- <label for="" style="color:white;font-size: 18px;">बूथ संख्या :-</label>
                <label for="" style="color: white;font-size: 18px;" id="Booth_numberID"></label>--%>
           <%-- </div>--%>
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
                 
      <%--  <div class="row" style="background-color:#f1c371;height:35px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
            <div class="col-md-4">
                <label for="" style="color:saddlebrown;font-size: 13px;"></label>
              
            </div>--%>
           <%--<div class="col-md-2">
                <label for="" style="color:saddlebrown;font-size: 13px;">Document Number : </label>
               <asp:Label ID="lblDocNo" runat="server" Text="" Visible="True" style="color:saddlebrown;font-size: 12px;"></asp:Label>
              
            </div>
                 <div class="col-md-4">
                <label for="" style="color:saddlebrown;font-size: 12px;">Family No : </label>
                <asp:Label ID="lblFamily" runat="server" Text="" Visible="True" style="color:saddlebrown;font-size: 12px;"></asp:Label>
              
            </div>--%>
       </div>

            
        <%-- Grid Data --%>
    <div style="padding-top:20px" >
         <ej:Grid ID="grdFamilyDocDetails" runat="server"  AllowPaging="True"  OnServerCommandButtonClick="grdFamilyDocDetails_ServerCommandButtonClick" OnServerPdfExporting="grdFamilyDocDetails_ServerPdfExporting2" OnServerRowSelected="grdFamilyDocDetails_ServerRowSelected" >
             <EditSettings AllowEditing="true" AllowAdding="true" AllowDeleting="true"></EditSettings>
                    <ToolbarSettings ShowToolbar="true" ToolbarItems="excelExport,wordExport,pdfExport"></ToolbarSettings>
                    <PageSettings PageSize="6"></PageSettings>
                      <Columns>
                        <ej:Column Field="srno" HeaderText="Sr.No."  Width="40" />
                        <ej:Column Field="familyno" HeaderText="Family No." Width="75" HeaderTemplateID="#empTemplate"   />
                        <ej:Column Field="surveyno" HeaderText="Survey No."  Width="100" />
                        <ej:Column Field="surveyarea" HeaderText="Survey Area" Width="100" />
                        <ej:Column Field="landclass" HeaderText="Class of Land" Width="100" /> 
                        <ej:Column Field="holdername" HeaderText="Name of Holder" Width="150" /> 
                        <ej:Column Field="holderarea" HeaderText="Area" Width="100" /> 
                        <ej:Column Field="areaaquired" HeaderText="Aquired Area" Width="100" /> 
                        <%--<ej:Column Field="surveyrate" HeaderText="Survey Rate" Width="75" />--%>
                        <ej:Column HeaderText="View 7/12" Width="130" TextAlign="Center">
                         <Command>
                        <ej:Commands Type="detail"> 
                            <ButtonOptions Text="View" Width="100"></ButtonOptions> 
                        </ej:Commands> 

                        <%--<ej:Commands Type="delete">
                            <ButtonOptions ContentType ="ImageOnly" PrefixIcon="e-icon e-delete" />
                        </ej:Commands>
                        <ej:Commands Type="save">
                            <ButtonOptions ContentType ="ImageOnly" PrefixIcon="e-icon e-save" />
                        </ej:Commands>
                        <ej:Commands Type="cancel">
                            <ButtonOptions ContentType ="ImageOnly" PrefixIcon="e-icon e-cancel" />
                        </ej:Commands>--%>
                   
                        </Command>
            </ej:Column>
                    </Columns>

         </ej:Grid>
    </div>

        <div class="upload" style="background-color:#f1c371;height:50px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
        <div class="col-lg-4" style="padding-top:5px" >
            <asp:Button ID="btnView712" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="View 7/12" Width="175px" OnClick="btnView712_Click"  />
        </div>
        <div class="col-lg-4" style="padding-top:5px">
            <asp:Button ID="btnView8A" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="View 8A" Width="169px" />                                        
        </div>
      <div class="col-lg-4" style="padding-top:5px" >
                   <asp:Button ID="btnViewMutation" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Mutation Search Report -HO" Width="200px" OnClick="btnViewMutation_Click" /> 

      </div>
      
   </div>

    

   
  
<br />
<br />

       <%-- end Page Coading --%>
    </asp:Panel>
</asp:Content>
