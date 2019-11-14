<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SO1LandDocument.aspx.cs" Inherits="LandSurvey.SOOne.SO1LandDocument" %>
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
        }
    </style>
    
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
                 
    <div class="row" style="padding-top:20px" >
        
        <div>
        <asp:GridView ID="grdFamilyDocDetails" runat="server" Width="100%" AutoGenerateColumns=false BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" PageSize="5"  HorizontalAlign="Center" ShowHeaderWhenEmpty="True" AllowPaging="True" OnPageIndexChanging="grdFamilyDocDetails_PageIndexChanging" OnSelectedIndexChanged="grdFamilyDocDetails_SelectedIndexChanged" AutoGenerateSelectButton="True" ShowFooter="True">
                                     <Columns>
                                    <asp:BoundField DataField="srno" HeaderText="Sr. No."  />    
                                    <asp:BoundField DataField="familyno" HeaderText="Family No." /> 
                                    <asp:BoundField DataField="surveyno" HeaderText="Survey No." /> 
                                    <asp:BoundField DataField="surveyarea" HeaderText="Survey Area" /> 
                                    <asp:BoundField DataField="landclass" HeaderText="Land Class" /> 
                                    <asp:BoundField DataField="holdername" HeaderText="Holder Name" />
                                    <asp:BoundField DataField="holderarea" HeaderText="Holder Area" />
                                    <asp:BoundField DataField="areaaquired" HeaderText="Aquired Area" />

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
        <div class="row" style="background-color:#f1c371;height:50px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
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
    
</asp:Content>
