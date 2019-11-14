<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HODOCSiteOne.aspx.cs" Inherits="LandSurvey.HO.HODOCSiteOne" %>
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
        border-color: saddlebrown !important;
        }
    </style>
 
    <%-- Page Coading --%>
     <div class="row" style="background-color:#f1c371;height:35px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
            <div class="col-md-8">
                <label for="" style="color:saddlebrown;font-size: 18px;">Document Recieved From Site Office</label>
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
             <asp:DropDownList ID="cmbDocumentNo" runat="server" AutoPostBack="true" CssClass="form-control" Width="225px" OnSelectedIndexChanged="cmbDocumentNo_SelectedIndexChanged">
                    </asp:DropDownList>
        </div>
                      
        </div>
                 <br /> 

     <div class="row" style="background-color:#f1c371;height:35px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
            <div class="col-md-4">
                <label for="" style="color:saddlebrown;font-size: 13px;">Documents Recieved from Site Office </label>
            </div>
           <div class="col-md-2">
            </div>
                 <div class="col-md-4">
            </div>
     </div>

      <%-- Grid Data --%>
   <div class="row" style="padding-top:0px" >
        
        <div>
        <%--<asp:GridView ID="grdSiteOfficeDocAll" runat="server" Width="100%" AutoGenerateColumns=false BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" PageSize="5"  HorizontalAlign="Center" ShowHeaderWhenEmpty="True" AutoGenerateSelectButton="True" ShowFooter="True">--%>
        <asp:GridView ID="grdSiteOfficeDocAll" runat="server" Width="100%" AutoGenerateColumns=false BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" PageSize="5"  HorizontalAlign="Center" ShowHeaderWhenEmpty="True" ShowFooter="True">
                        <Columns>
                                     <asp:TemplateField HeaderText="Select">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                       <%-- <asp:CheckBox ID="chkSelectAll" ToolTip="Click here to select/deselect all rows"
                                        runat="server" />--%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                        <asp:CheckBox ID="chkSelect" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="srno" HeaderText="Sr. No."  />    
                                    <asp:BoundField DataField="documentcode" HeaderText="Document Code" /> 
                                     <asp:BoundField DataField="documentname" HeaderText="Document Name" /> 
                                    <asp:BoundField DataField="createddate" HeaderText="Uploaded Date" /> 
                                     <asp:BoundField DataField="hosenddate" HeaderText="Recieved Date" /> 
                                     <asp:BoundField DataField="solicitorsentdate" HeaderText="Sent to Solicitor" /> 
                                     <asp:BoundField DataField="clientsenddate" HeaderText="Sent to Client" /> 
                                      
                                <%--   <asp:BoundField DataField="createddate" HeaderText="Uploaded Date" /> --%>
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
            <asp:Button ID="btnDownloadDoc" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Download Selected Document" Width="270px" xmlns:asp="#unknown" OnClick="btnDownloadDoc_Click" />
       </div> 
     <%--   <div  class="col-md-2">
             <label for="cmbSelectClient" style="color:saddlebrown;font-size: 12px;">Send To :</label>
        </div>--%>
        <div class="col-md-4" >
           <%--<label>RSD</label>--%>
             <asp:DropDownList ID="cmbSelectClient" runat="server" AutoPostBack="true" CssClass="form-control" Width="100px">
                  <asp:ListItem>Solicitor</asp:ListItem>
                  <asp:ListItem>Client</asp:ListItem>
              </asp:DropDownList>
       </div> 
        <div class="col-md-4" >
            <asp:Button ID="btnSubmitDoc" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Send Document for Approval" Width="270px" xmlns:asp="#unknown" OnClick="btnSubmitDoc_Click" />
       </div> 
        </div>

</asp:Content>
