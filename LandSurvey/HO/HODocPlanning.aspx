<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HODocPlanning.aspx.cs" Inherits="LandSurvey.HO.HoDocPlanning" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %> --%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../Scripts/jquery.validate.min.js"></script>
    <script src="../Scripts/ej.web.all.min.js"></script>
    <script src="../Scripts/ej.grid.min.js"></script>
    <script src="../Scripts/ej.unobtrusive.min.js"></script>
    <script src="../Scripts/jquery.validate.unobtrusive.min.js"></script>
    <link href="../Content/ej.widgets.core.min.css" rel="stylesheet" />
    <link href="../Content/ej.web.all.min.css" rel="stylesheet" />

    <script>
         function AlertFunction() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
             confirm_value.name = "confirm_value";
             if (FileUploadControl.HasFiles)
             {
                 confirm_value.value = "Yes";
             }
             else
             {
                 if (confirm("Mutation Register File Not selected Do you want to Continue?")) {
                     confirm_value.value = "No";
                 }
            } 
            
            document.forms[0].appendChild(confirm_value);
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
    </style>
    <asp:Panel ID="Panel1" runat="server" Height="100%" Width="100%">
    <%-- Page Coading --%>
     <div class="row" style="background-color:#f1c371;height:35px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
            <div class="col-md-2">
                <label for="" style="color:saddlebrown;font-size: 18px;">Document Planinng</label>
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
       <%-- </ContentTemplate>
        <Triggers>
        <asp:AsyncPostBackTrigger ControlID="cmbDocumentNo" EventName="SelectedIndexChanged" />
    </Triggers>
        </asp:UpdatePanel>--%>

        </div>

                        
        </div>
                 
  
            
        <%-- Grid Data --%>
    <div style="padding-top:20px" >
         <ej:Grid ID="grdFamilyDocDetails" runat="server"  AllowPaging="True" IsResponsive="True" OnServerPdfExporting="grdFamilyDocDetails_ServerPdfExporting" >
                    <ToolbarSettings ShowToolbar="true" ToolbarItems="excelExport,wordExport,pdfExport"></ToolbarSettings>
                    <PageSettings PageSize="6"></PageSettings>
                      <Columns>
                        <ej:Column Field="srno" HeaderText="Sr.No."  Width="50" />
                        <ej:Column Field="docno" HeaderText="Document No." Width="125" HeaderTemplateID="#empTemplate"   />
                        <ej:Column Field="familyno" HeaderText="Family No."  Width="75" />
                        <ej:Column Field="surveyno" HeaderText="Survey No." Width="75" />
                        <ej:Column Field="surveyarea" HeaderText="Survey Area" Width="75" /> 
                        <ej:Column Field="surveyrate" HeaderText="Survey Rate" Width="75" />
                    </Columns>

         </ej:Grid>
    </div>

    

    <div class="upload" style="background-color:#f1c371;height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
        <div class="col-md-2" style="padding-top:5px" >
                <label for="" style="color:saddlebrown;font-size: 14px;">Upload Mutation Search</label>
        </div>
        <div class="col-lg-3" style="padding-top:5px">
            <%--<ej:UploadBox ID="Upload1" runat="server" SaveUrl="saveFiles.ashx" RemoveUrl="removeFiles.ashx" AutoUpload="false" OnComplete="Upload1_Complete">
                <UploadBoxButtonText Browse="Choose File" Cancel="Cancel Upload" Upload="Upload File" />
               <UploadBoxDialogText Title="Upload File List" Name= "File Name" Size="File Size" Status= "File Status" />
            </ej:UploadBox>--%>
           <asp:FileUpload ID="FileUploadControl" runat="server" Height="30px" Width="208px" />
                            
        </div>
      <div class="col-lg-5" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Uploaded Mutation Search File :</label>
          <asp:LinkButton ID="lbllinkMR" runat="server" OnClick="lbllinkMR_Click">File Uploaded</asp:LinkButton>

      </div>
        <div class="col-md-2" >
            <%--<asp:Button ID="Button1" runat="server" Text="Button" />--%>
          <asp:Button ID="btnMutationSave" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Save Mutation Register " Width="169px" xmlns:asp="#unknown" OnClick="btnMutationSave_Click" onclientclick="return AlertFunction()" />

      </div>
   </div>

   <div class="upload" style="background-color:#f1c371;height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
        <div class="col-md-10" style="padding-top:5px" >
                <%--<label for="" style="color:saddlebrown;font-size: 14px;">Document Execute without Mutation Search File</label>--%>
            <label for="" style="color:saddlebrown;font-size: 14px;">Allow For Title Search</label>
        </div>
      
     <%-- <div class="col-lg-5" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Uploaded Mutation Search File :</label>
          <asp:LinkButton ID="LinkButton1" runat="server" OnClick="lbllinkMR_Click">File Uploaded</asp:LinkButton>

      </div>--%>
        <div class="col-md-2" >
            <%--<asp:Button ID="Button1" runat="server" Text="Button" />--%>
          <asp:Button ID="btnWithoutFile" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Document Planning " Width="169px" xmlns:asp="#unknown" OnClick="btnWithoutFile_Click" />

      </div>
   </div>
  
<br />
<br />

       <%-- end Page Coading --%>
    </asp:Panel>
</asp:Content>
