<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SOSubmitDocuments.aspx.cs" Inherits="LandSurvey.SOOne.SOSubmitDocuments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%--<script src="../Scripts/jquery.validate.min.js"></script>
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
                <label for="" style="color:saddlebrown;font-size: 18px;">Submit Documents</label>
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
           <div class="col-md-8">
                <label for="" style="color:saddlebrown;font-size: 13px;">Upload survey Number wise Files & Mutation Search Report with Findings</label>
               <asp:Label ID="lblDocNo" runat="server" Text="" Visible="True" style="color:saddlebrown;font-size: 12px;"></asp:Label>
              
           <%-- </div>
                 <div class="col-md-4">
                <label for="" style="color:saddlebrown;font-size: 12px;">Family No : </label>
                <asp:Label ID="lblFamily" runat="server" Text="" Visible="True" style="color:saddlebrown;font-size: 12px;"></asp:Label>
              
            </div>--%>
       </div>

            
        <%-- Grid Data --%>
    <div style="padding-top:20px" >
         <div>
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
    </div>
    </div>
            <br />
    <div class="upload" style="background-color:#f1c371;height:50px;padding-top: 5px;  border-radius: 5px 5px 5px 5px;">
        <div class="col-md-3" style="padding-top:5px" >
            <%--<asp:Button ID="btnMSR" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="View Mutation Search Report" Width="270px" OnClick="btnMSR_Click"  />--%>
            <asp:Button ID="btnOtherDocument" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Upload Other Documents" Width="270px" OnClick="btnOtherDocument_Click" />                                        
        </div>
        <div class="col-md-3" style="padding-top:5px">
              <asp:FileUpload ID="FileUploadOther" runat="server" Height="30px" Width="208px" />
            <%--<asp:Button ID="btnOtherDocument" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Upload Other Documents" Width="270px" />--%>                                        
        </div>
            
        <div class="col-md-5" style="padding-top:5px">
           <label for="" style="color:saddlebrown;font-size: 12px;">Uploaded Other Document:</label>
          <asp:LinkButton ID="LinkBtnOtherDoc" runat="server" OnClick="LinkBtnOtherDoc_Click">File Not Found</asp:LinkButton>
      </div>
      <%--  <div class="col-md-3" style="padding-top:5px" >--%>
            <%--<asp:Button ID="btnMSR" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="View Mutation Search Report" Width="270px" OnClick="btnMSR_Click"  />--%>
            <%--<asp:Button ID="btnOtherDocuments" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Upload Other Documents" Width="270px" OnClick="btnOtherDocuments_Click"/>--%>                                        
        <%--</div>--%>
   </div>

   <div class="upload" style="background-color:#f1c371;height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
       <div class="col-md-3" >
            <%--<asp:Button ID="Button1" runat="server" Text="Button" />--%>
          <asp:Button ID="btnMutationRemarkSave" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Mutation Search Report with Remark " Width="270px" xmlns:asp="#unknown" OnClick="btnMutationRemarkSave_Click" />

      </div> 
              
       <%--<div class="col-md-2" style="padding-top:5px" >
                <label for="" style="color:saddlebrown;font-size: 14px;">Upload Mutation Search</label>
        </div>--%>
        <div class="col-lg-3" style="padding-top:5px">
            <%--<ej:UploadBox ID="Upload1" runat="server" SaveUrl="saveFiles.ashx" RemoveUrl="removeFiles.ashx" AutoUpload="false" OnComplete="Upload1_Complete">
                <UploadBoxButtonText Browse="Choose File" Cancel="Cancel Upload" Upload="Upload File" />
               <UploadBoxDialogText Title="Upload File List" Name= "File Name" Size="File Size" Status= "File Status" />
            </ej:UploadBox>--%>
           <asp:FileUpload ID="FileUploadControl" runat="server" Height="30px" Width="208px" />
                            
        </div>
      <div class="col-lg-5" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Uploaded Mutation Search Report with Remark:</label>
          <asp:LinkButton ID="lbllinkMR" runat="server" OnClick="lbllinkMR_Click">File Not Found</asp:LinkButton>

      </div>
        
   </div>
  
<br />
<br />

       <%-- end Page Coading --%>
  
</asp:Content>
