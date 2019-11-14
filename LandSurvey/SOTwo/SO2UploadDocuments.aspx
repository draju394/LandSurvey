<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SO2UploadDocuments.aspx.cs" Inherits="LandSurvey.SOTwo.SO2UploadDocuments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   <%-- <script src="../Scripts/jquery.validate.min.js"></script>
    <script src="../Scripts/ej.web.all.min.js"></script>
    <script src="../Scripts/ej.grid.min.js"></script>
    <script src="../Scripts/ej.unobtrusive.min.js"></script>
    <script src="../Scripts/jquery.validate.unobtrusive.min.js"></script>
    <link href="../Content/ej.widgets.core.min.css" rel="stylesheet" />
    <link href="../Content/ej.web.all.min.css" rel="stylesheet" />--%>
    <script>
        function OpenMyPopUp() { openPopup('Default.aspx', 530, 800, 'Page Title'); }

        function openPopup(url, h, w, t) {
    if (url != null && h != null && w != null && t != null) {

    urlBase = location.href.substring(0, location.href.lastIndexOf("/") + 1);
    url = urlBase + url;
    $('#MyDialog').html('<iframe border=0 width="100%" height ="100%" src="' + url + '"> </iframe>');
    $("#MyDialog").dialog({
        title: t,
        modal: true,
        autoOpen: true,
        height: h,
        width: w,
        resizable: false,
        position: ['right-10', 'top+30'],
        closeOnEscape: false,
        dialogClass: "alert"
    });
}}
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
        border-color: saddlebrown !important;
        }
    </style>
 
    <%-- Page Coading --%>
     <div class="row" style="background-color:#f1c371;height:35px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
            <div class="col-md-8">
                <label for="" style="color:saddlebrown;font-size: 18px;">Registry Search Documents - Upload Findings and Documents</label>
                <label for="" style="color: white;font-size: 18px;" id="PopulationID"></label>
            </div>
            <div class="col-md-2">
                 <asp:TextBox ID="txtDocNo" runat="server" Visible="False"></asp:TextBox>
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
           <asp:DropDownList ID="cmbDocumentNo" runat="server" AutoPostBack="true" CssClass="form-control" Width="225px" OnSelectedIndexChanged="cmbDocumentNo_SelectedIndexChanged">
                    </asp:DropDownList>
        </div>

                        
        </div>
                 <br /> 
        <div class="row" style="background-color:#f1c371;height:35px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
            <%--<div class="col-md-4">
                <label for="" style="color:saddlebrown;font-size: 13px;">Generate Primary Search Report</label>
              
            </div>--%>
           <div class="col-md-8" style="align-content:center">
                <label for="" style="color:saddlebrown;font-size: 13px;">Upload survey Number wise Files & Registry Search Report with Findings</label>
               <asp:Label ID="lblDocNo" runat="server" Text="" Visible="True" style="color:saddlebrown;font-size: 12px;"></asp:Label>
              
           <%-- </div>
                 <div class="col-md-4">
                <label for="" style="color:saddlebrown;font-size: 12px;">Family No : </label>
                <asp:Label ID="lblFamily" runat="server" Text="" Visible="True" style="color:saddlebrown;font-size: 12px;"></asp:Label>
              
            </div>--%>
       </div>
            </div>
            
        <%-- Grid Data --%>
    <div style="padding-top:0px" >
         
        <asp:GridView ID="grdFamilyDocDetails" runat="server" Width="100%" AutoGenerateColumns=false BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" PageSize="5"  HorizontalAlign="Center" ShowHeaderWhenEmpty="True" AllowPaging="True" OnPageIndexChanging="grdFamilyDocDetails_PageIndexChanging" OnSelectedIndexChanged="grdFamilyDocDetails_SelectedIndexChanged" AutoGenerateSelectButton="True" ShowFooter="True">
                                     <Columns>
                                    <asp:BoundField DataField="srno" HeaderText="Sr. No."  />    
                                    <asp:BoundField DataField="familyno" HeaderText="Family No." /> 
                                    <asp:BoundField DataField="surveyno" HeaderText="Survey No." /> 
                                    <asp:BoundField DataField="" HeaderText="Upload File" /> 
                                    <asp:BoundField DataField="" HeaderText="Uploaded File" /> 
                                    

                                    </Columns>
                                    
                                    <EmptyDataTemplate>No Record Available</EmptyDataTemplate>  
                                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                        <HeaderStyle BackColor="saddlebrown" Font-Bold="True" ForeColor="White" Height="35px" HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                        <RowStyle Height="30px" HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <SelectedRowStyle BackColor="Peru" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                        <SortedDescendingHeaderStyle BackColor="#242121" />
                                </asp:GridView>
    
       <%-- 
        <ej:Grid ID="grdFamilyDocDetails" runat="server"  AllowPaging="True" IsResponsive="True" OnServerPdfExporting="grdFamilyDocDetails_ServerPdfExporting" >
                    <ToolbarSettings ShowToolbar="true" ToolbarItems="excelExport,wordExport,pdfExport"></ToolbarSettings>
                    <PageSettings PageSize="6"></PageSettings>
                      <Columns>
                        <ej:Column Field="srno" HeaderText="Sr.No."  Width="40" />
                        <ej:Column Field="familyno" HeaderText="Family No." Width="75" HeaderTemplateID="#empTemplate"   />
                        <ej:Column Field="surveyno" HeaderText="Survey No."  Width="200" />
                        <ej:Column Field="" HeaderText="Upload Files" Width="100" />
                        <ej:Column Field="" HeaderText="Uploaded Files" Width="100" /> 
                       
                    </Columns>

         </ej:Grid>--%>
    </div>

    <%--<div class="upload" style="background-color:#f1c371;height:50px;padding-top: 5px; padding-left:30px; border-radius: 5px 5px 5px 5px;">
        <div class="col-lg-4" style="padding-top:5px" >
            <asp:Button ID="btnMSR" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Upload Registry Search Report" Width="350px" OnClick="btnMSR_Click"  />
        </div>
      
        <div class="col-lg-4" style="padding-top:5px">
          <asp:FileUpload ID="FileUploadARegistrySearch" runat="server" Height="30px" Width="208px" />
        </div>
        <div class="col-lg-4" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Uploaded Document:</label>
          <asp:LinkButton ID="lbllnkRegistrySearch" runat="server" OnClick="lbllnkRegistrySearch_Click" ></asp:LinkButton>
        </div>
     </div>--%>

    <div class="upload" style="background-color:#f1c371;height:50px;padding-top: 5px; padding-left:30px; border-radius: 5px 5px 5px 5px;">
          <div class="col-lg-8" style="padding-top:5px">
            <asp:Button ID="btnOtherDocument" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Upload Other Documents" Width="270px" OnClick="btnOtherDocument_Click" />                                        
        </div>
    </div>
         
        <div class="modal fade" id="modalC" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                <h4 class="modal-title" id="myModalLabel">Cantidad reservas mensuales</h4>
            </div>
            <div class="modal-body" id="content">
                <iframe src="your new page url"> <</iframe>
            </div>
        </div>
    </div>
</div>
   </div>

   
  
<br />
<br />

       <%-- end Page Coading --%>
  
</asp:Content>
