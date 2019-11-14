<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SOSubmitChecklist.aspx.cs" Inherits="LandSurvey.SOOne.SOSubmitChecklist" EnableEventValidation = "false" %>
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
        .cssPager td
            {
                  padding-left: 4px;     
                  padding-right: 4px;    
              }
        .grdCheckListEdit tr
        {
             padding: 5px;
             border: 1px solid #ddd;
        }
        .grdCheckListEdit td
        {
             padding: 5px;
             border: 1px solid #ddd;
        }
        .grdCheckListEdit th
        {
             padding: 5px;
             border: 1px solid #ddd;
        }
    .auto-style4 {
        position: relative;
        min-height: 1px;
        float: left;
        width: 25%;
        left: -233px;
        top: -15px;
        padding-left: 15px;
        padding-right: 15px;
    }
    </style>
 
    <%-- Page Coading --%>
     <div class="row" style="background-color:#f1c371;height:35px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
            <div class="col-md-8">
                <label for="" style="color:saddlebrown;font-size: 18px;">Upload Checklist with Remarks</label>
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
           <div class="col-md-12" style="text-align:center">
                <label for="" style="color:saddlebrown;font-size: 13px;">Upload Checklist with Remarks</label>
               <%--<asp:Label ID="lblDocNo" runat="server" Text="" Visible="True" style="color:saddlebrown;font-size: 12px;"></asp:Label>--%>
              
           <%-- </div>
                 <div class="col-md-4">
                <label for="" style="color:saddlebrown;font-size: 12px;">Family No : </label>
                <asp:Label ID="lblFamily" runat="server" Text="" Visible="True" style="color:saddlebrown;font-size: 12px;"></asp:Label>
              
            </div>--%>
       </div>

            <br />
        <%-- Grid Data --%>
           
    <div id="So1CheckList" runat="server"  style="padding-top:20px" >
        <asp:GridView ID="grdCheckListEdit" runat="server" AutoGenerateColumns="False" DataKeyNames="srno" OnRowCancelingEdit="grdCheckListEdit_RowCancelingEdit" OnRowEditing="grdCheckListEdit_RowEditing1" OnRowUpdating="grdCheckListEdit_RowUpdating" ShowFooter="True" OnSelectedIndexChanged="grdCheckListEdit_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanging="grdCheckListEdit_PageIndexChanging" CellPadding="10" CellSpacing="5" CssClass="grdCheckListEdit"> 
        <Columns> 
            <asp:TemplateField HeaderText="SrNo"  HeaderStyle-HorizontalAlign="Left"> 
               <%-- <EditItemTemplate> 
                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("srno") %>'></asp:Label>
                </EditItemTemplate> --%>
                <ItemTemplate > 
                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("srno") %>'></asp:Label> 
                </ItemTemplate> 

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Check List No" HeaderStyle-HorizontalAlign="Left" Visible="false"> 
                <EditItemTemplate> 
                    <asp:Label ID="ChkListTranID" runat="server" Text='<%# Bind("chklistno") %>'></asp:Label> 
                </EditItemTemplate> 
                <ItemTemplate> 
                    <asp:Label ID="ChkListTranID" runat="server" Text='<%# Bind("chklistno") %>'></asp:Label> 
                </ItemTemplate> 

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Check List Name" HeaderStyle-HorizontalAlign="Left"> 
               <%-- <EditItemTemplate> 
                    <asp:TextBox ID="chklistname" runat="server" Text='<%# Bind("chkname") %>'></asp:TextBox> 
                </EditItemTemplate> --%>
                <ItemTemplate> 
                    <asp:Label ID="lblchklistname" runat="server" Text='<%# Bind("chkname") %>'></asp:Label> 
                </ItemTemplate> 

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
            </asp:TemplateField> 
             <asp:TemplateField HeaderText="Remark" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="10px"> 
                 <HeaderStyle Width="300" />
                <ItemStyle Width="300" />
                <EditItemTemplate> 
                    <asp:TextBox ID="chklistremark" runat="server" Text='<%# Bind("siteofficereamrk") %>' Width="300"></asp:TextBox> 
                </EditItemTemplate> 
                <ItemTemplate> 
                    <asp:Label ID="lblchklistremark" runat="server" Text='<%# Bind("siteofficereamrk") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField> 
         
            <asp:TemplateField HeaderText="Edit" ShowHeader="False" HeaderStyle-HorizontalAlign="Left"> 
                 <HeaderStyle Width="70" />
                <ItemStyle Width="70" />
                <EditItemTemplate> 
                    <asp:LinkButton ID="lbkUpdate" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton> 
                    <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton> 
                </EditItemTemplate> 
               <%-- <FooterTemplate> 
                    <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="False" CommandName="Insert" Text="Insert"></asp:LinkButton> 
                </FooterTemplate> --%>
                <ItemTemplate> 
                    <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton> 
                </ItemTemplate> 
            </asp:TemplateField> 

            <%--<asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ShowHeader="True" />--%> 
        </Columns> 
            <EmptyDataTemplate>No Record Available</EmptyDataTemplate>  
                                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                        <HeaderStyle BackColor="saddlebrown" Font-Bold="True" ForeColor="White" Height="35px" HorizontalAlign="Right" VerticalAlign="Middle" />
                                         <PagerStyle CssClass="cssPager" />
                                        <PagerStyle BackColor="White" ForeColor="#660033" HorizontalAlign="Right" BorderStyle="None" Font-Bold="True" Font-Size="12pt" />
                                        <RowStyle Height="30px" HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <SelectedRowStyle BackColor="Peru" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                        <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView> 
    </div>

<div class="upload" style="background-color:#f1c371;height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
        <div class="col-md-4" >
           <asp:Button ID="btnSaveChklist" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Save Check List" Width="270px" xmlns:asp="#unknown" OnClick="btnSaveChklist_Click" />
        </div> 
        <%--<div class="col-md-4" style="padding-top:5px">
          <asp:FileUpload ID="FileUploadCheckListSO2" runat="server" Height="30px" Width="208px" />
        </div>--%>
      <div class="col-md-4" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Uploaded Check List:</label>
          <asp:LinkButton ID="lblLinkChkList" runat="server" OnClick="lblLinkChkList_Click" ></asp:LinkButton>
      </div>
    
   </div>

     <div class="upload" style="background-color:#f1c371;height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
        <div class="col-md-4" >
           <asp:Button ID="btnCheckListSO2" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Upload Details / Other Remarks" Width="270px" xmlns:asp="#unknown" OnClick="btnCheckListSO2_Click" />
        </div> 
        <div class="col-md-4" style="padding-top:5px">
          <asp:FileUpload ID="FileUploadCheckListSO2" runat="server" Height="30px" Width="208px" />
        </div>
      <div class="col-md-4" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Check List Other Documents:</label>
          <asp:LinkButton ID="lbllinkCheckListSo2" runat="server" OnClick="lbllinkCheckListSo2_Click"></asp:LinkButton>
      </div>
    
   </div>

   
  
<br />
<br />

       <%-- end Page Coading --%>
  
</asp:Content>
