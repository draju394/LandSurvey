<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SolicitorApprovalList.aspx.cs" Inherits="LandSurvey.Solicitor.SolicitorApprovalList" %>
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
                <label for="" style="color:saddlebrown;font-size: 18px;">Documents Recieved From Head Office for Approval</label>
                <label for="" style="color: white;font-size: 18px;" id="PopulationID"></label>
            </div>
            <div class="col-md-2">
                 <asp:TextBox ID="txtDocNo" runat="server" Visible="False"></asp:TextBox>
              </div>
           
        </div>

     <%-- Grid Data --%>
    <div style="padding-top:20px" >
         <div>
        <asp:GridView ID="grdSolicitorApproval" runat="server" Width="100%" AutoGenerateColumns=false BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" PageSize="10"  HorizontalAlign="Center" ShowHeaderWhenEmpty="True" AllowPaging="True" OnPageIndexChanging="grdSolicitorApproval_PageIndexChanging" OnSelectedIndexChanged="grdSolicitorApproval_SelectedIndexChanged" AutoGenerateSelectButton="True" ShowFooter="True">
                                     <Columns>
                                    <asp:BoundField DataField="villagecode" HeaderText="Village Code"  />    
                                    <asp:BoundField DataField="villagemname" HeaderText="Village Name" /> 
                                    <asp:BoundField DataField="docno" HeaderText="Document No." /> 
                                    <asp:BoundField DataField="createddate" HeaderText="Created Date" /> 
                                    <asp:BoundField DataField="solicitorsentdate" HeaderText="Sent On Date" /> 
                                    <asp:BoundField DataField="solicitorapproval" HeaderText="Approve Status" /> 
                                    <asp:BoundField DataField="solicitorappdate" HeaderText="Approve Date" /> 

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
     <div class="upload" style="background-color:#f1c371;height:50px;padding-top: 5px; padding-left:30px; border-radius: 5px 5px 5px 5px;">
          <div class="col-lg-8" style="padding-top:5px">
            <asp:Button ID="btnApproveDocument" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Approve Selected Document" Width="270px" OnClick="btnApproveDocument_Click"/>                                        
        </div>
    </div>
</asp:Content>
