<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserMaster.aspx.cs" Inherits="LandSurvey.HO.UserMaster" %>
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
                <label for="" style="color:saddlebrown;font-size: 18px;">User Master</label>
                <label for="" style="color: white;font-size: 18px;" id="PopulationID"></label>
            </div>
            <div class="col-md-2">
                 <asp:TextBox ID="txtDocNo" runat="server" Visible="False"></asp:TextBox>
            </div>
            <div class="col-md-2">
            </div>
     </div>
    <div class="row" style="padding-top:10px">
         <asp:GridView ID="grdUserDetails" runat="server" Width="100%" AutoGenerateColumns=false BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" PageSize="5"  HorizontalAlign="Center" ShowHeaderWhenEmpty="True"  AutoGenerateSelectButton="True" ShowFooter="True">
             <Columns>
                <asp:BoundField DataField="fullname" HeaderText="User Name"  />    
                <asp:BoundField DataField="username" HeaderText="Login Name" /> 
                <asp:BoundField DataField="type" HeaderText="User Type" /> 
                <asp:BoundField DataField="status" HeaderText="Status" /> 
                <asp:BoundField DataField="mobile1" HeaderText="Mobile No." /> 
                <asp:BoundField DataField="email" HeaderText="eMail" /> 
                <asp:BoundField DataField="dob" HeaderText="Date of Birth" />
                <asp:BoundField DataField="joiningdate" HeaderText="Joined Date" />
               <%-- <asp:BoundField DataField="areaaquired" HeaderText="Aquired Area" />--%>

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
    <br />
      <div class="upload" style="background-color:#f1c371;height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
       <div class="col-md-4" >
            <asp:Button ID="btnAddNew" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Add New User" Width="270px" xmlns:asp="#unknown" OnClick="btnAddNew_Click" />
       </div> 
              
        <%--<div class="col-lg-3" style="padding-top:5px">
           <asp:FileUpload ID="FileUploadControl" runat="server" Height="30px" Width="208px" Visible ="false" />
                            
        </div>
      <div class="col-lg-5" style="padding-top:5px" >
      <%--    <label for="" style="color:saddlebrown;font-size: 12px; >Generated Public Notice:</label>--%>
          <%--<asp:LinkButton ID="lbllinkPN" runat="server" OnClick="lbllinkPN_Click"  Visible="false">File Not Found</asp:LinkButton>--%>

     <%-- </div>--%>
        
   </div>

</asp:Content>
