<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HOPrimaryTS.aspx.cs" Inherits="LandSurvey.HO.HoPrimaryTS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 <%--   <script src="../Scripts/jquery.validate.min.js"></script>
    <script src="../Scripts/ej.web.all.min.js"></script>
    <script src="../Scripts/ej.grid.min.js"></script>
    <script src="../Scripts/ej.unobtrusive.min.js"></script>
    <script src="../Scripts/jquery.validate.unobtrusive.min.js"></script>
    <link href="../Content/ej.widgets.core.min.css" rel="stylesheet" />
    <link href="../Content/ej.web.all.min.css" rel="stylesheet" />--%>

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
                <label for="" style="color:saddlebrown;font-size: 18px;">Primary Title Search Report</label>
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
                <label for="" style="color:saddlebrown;font-size: 13px;">Generate Primary Search Report</label>
              
            </div>
          <%-- <div class="col-md-2">
                <label for="" style="color:saddlebrown;font-size: 13px;">Document Number : </label>
               <asp:Label ID="lblDocNo" runat="server" Text="" Visible="True" style="color:saddlebrown;font-size: 12px;"></asp:Label>
              
            </div>
                 <div class="col-md-4">
                <label for="" style="color:saddlebrown;font-size: 12px;">Family No : </label>
                <asp:Label ID="lblFamily" runat="server" Text="" Visible="True" style="color:saddlebrown;font-size: 12px;"></asp:Label>
              
            </div>--%>
       </div>

            
        <%-- Grid Data --%>
   <div class="row" style="padding-top:20px" >
        
        <div>
        <asp:GridView ID="grdSiteOfficeDoc" runat="server" Width="100%" AutoGenerateColumns=false BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" PageSize="5"  HorizontalAlign="Center" ShowHeaderWhenEmpty="True" OnPageIndexChanging="grdSiteOfficeDoc_PageIndexChanging" OnSelectedIndexChanged="grdSiteOfficeDoc_SelectedIndexChanged" AutoGenerateSelectButton="True" ShowFooter="True">
                                     <Columns>
                                    <asp:BoundField DataField="srno" HeaderText="Sr. No."  />    
                                    <asp:BoundField DataField="location" HeaderText="Location" /> 
                                    <asp:BoundField DataField="documentname" HeaderText="Document Name" /> 
                                    <asp:BoundField DataField="docfile" HeaderText="File Name" /> 
                                    <asp:BoundField DataField="createddate" HeaderText="Uploaded Date" /> 
                                    <%--<asp:BoundField DataField="landclass" HeaderText="Land Class" /> 
                                    <asp:BoundField DataField="holdername" HeaderText="Holder Name" />
                                    <asp:BoundField DataField="holderarea" HeaderText="Holder Area" />
                                    <asp:BoundField DataField="areaaquired" HeaderText="Aquired Area" />--%>

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
    </div>
    </div>
      <div class="upload" style="background-color:#f1c371;height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
       <div class="col-md-4" >
            <asp:Button ID="btnGeneratePN" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Download Selected Document" Width="270px" xmlns:asp="#unknown" OnClick="btnGeneratePN_Click" />
       </div> 
              
        <div class="col-lg-3" style="padding-top:5px">
           <asp:FileUpload ID="FileUploadControl" runat="server" Height="30px" Width="208px" Visible ="false" />
                            
        </div>
      <div class="col-lg-5" style="padding-top:5px" >
      <%--    <label for="" style="color:saddlebrown;font-size: 12px; >Generated Public Notice:</label>--%>
          <asp:LinkButton ID="lbllinkPN" runat="server" OnClick="lbllinkPN_Click"  Visible="false">File Not Found</asp:LinkButton>

      </div>
        
   </div>

    <div class="upload" style="background-color:#f1c371;height:50px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
        <div class="col-lg-3" style="padding-top:5px" >
            <asp:Button ID="btnDownloadAll" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Download All Documents" Width="175px" OnClick="btnDownloadAll_Click"  />
        </div>
        <div class="col-lg-6" style="padding-top:5px">
            <asp:Button ID="btnGenerateReport" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Generate PTS Report" Width="169px" OnClick="btnGenerateReport_Click" />                                        
              <asp:LinkButton ID="lbllnkTS" runat="server" OnClick="lbllnkTS_Click"></asp:LinkButton>
        </div>
      <%--<div class="col-lg-3" style="padding-top:5px" >
        

      </div>--%>
        <div class="col-lg-3" style="padding-top:5px" >
        
          <asp:Button ID="btnSendSolicitor" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Send to Head Office" Width="169px" xmlns:asp="#unknown" OnClick="btnSendSolicitor_Click" />

      </div>
   </div>

   
 <%--  <div class="upload" style="background-color:#f1c371;height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
        <div class="col-md-3" style="padding-top:5px" >
                <label for="" style="color:saddlebrown;font-size: 14px;">Generate Primary Title Search</label>
        </div>
        <div class="col-lg-3" style="padding-top:5px">
           
           <asp:FileUpload ID="FileUploadTS" runat="server" Height="30px" Width="208px" AllowMultiple="True" />
                            
        </div>
      <div class="col-lg-4" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Title Search File :</label>
          <asp:LinkButton ID="lbllinkPrimaryTS" runat="server" OnClick="lbllinkPrimaryTS_Click" >File Uploaded</asp:LinkButton>

      </div>
        <div class="col-md-2" >
            <%--<asp:Button ID="Button1" runat="server" Text="Button" />
          <asp:Button ID="btnPTSSave" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Save Title Search" Width="169px" xmlns:asp="#unknown" OnClick="btnPTSSave_Click" />

      </div>
   </div>--%>
<br />
<br />

       <%-- end Page Coading --%>
  
</asp:Content>
