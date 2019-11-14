<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClientViewPayment.aspx.cs" Inherits="LandSurvey.Client.ClientViewPayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <%-- <script src="../Scripts/jquery.validate.min.js"></script>
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

    <div class="row" style="background-color:#f1c371;height:35px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
            <div class="col-md-8">
                <label for="" style="color:saddlebrown;font-size: 18px;">Payment Demand List</label>
            </div>
            <div class="col-md-2">
                 <asp:TextBox ID="txtDocNo" runat="server" Visible="False"></asp:TextBox>
           </div>
            <div class="col-md-2">
              
            </div>
    </div>

     <br />
             <%-- Grid Data --%>
    <div style="padding-top:20px" >
        <asp:GridView ID="grdPaymentNoteEdit" runat="server" AutoGenerateColumns="False" DataKeyNames="srno"  OnRowEditing="grdPaymentNoteEdit_RowEditing" OnRowUpdating="grdPaymentNoteEdit_RowUpdating" ShowFooter="True" OnSelectedIndexChanged="grdPaymentNoteEdit_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanging="grdPaymentNoteEdit_PageIndexChanging" CellPadding="10" CellSpacing="5" CssClass="grdCheckListEdit" OnRowCancelingEdit="grdPaymentNoteEdit_RowCancelingEdit"> 
        <Columns> 
           <%-- <asp:TemplateField HeaderText="SrNo"  HeaderStyle-HorizontalAlign="Left"> 
                <EditItemTemplate> 
                    <asp:Label ID="lblSrNo" runat="server" Text='<%# Bind("srno") %>'></asp:Label>
                </EditItemTemplate> 
                <ItemTemplate > 
                    <asp:Label ID="lblSrNo" runat="server" Text='<%# Bind("srno") %>'></asp:Label> 
                </ItemTemplate> 

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
            </asp:TemplateField> --%>
            <asp:TemplateField HeaderText="ID" HeaderStyle-HorizontalAlign="Left" Visible="false"> 
               <%-- <EditItemTemplate> 
                    <asp:Label ID="ChkListTranID" runat="server" Text='<%# Bind("paymentnoteid") %>'></asp:Label> 
                </EditItemTemplate> --%>
                <ItemTemplate> 
                    <asp:Label ID="lblPaymentNoteID" runat="server" Text='<%# Bind("paymentnoteid") %>'></asp:Label> 
                </ItemTemplate> 

                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Demand Note" HeaderStyle-HorizontalAlign="Left"> 
               <%-- <EditItemTemplate> 
                    <asp:TextBox ID="chklistname" runat="server" Text='<%# Bind("demandnote") %>'></asp:TextBox> 
                </EditItemTemplate> --%>
                <ItemTemplate> 
                    <asp:Label ID="lblDemandNote" runat="server" Text='<%# Bind("demandnote") %>'></asp:Label> 
                </ItemTemplate> 

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
            </asp:TemplateField> 
             <asp:TemplateField HeaderText="Demand Date" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="10px"> 
                 <HeaderStyle Width="300" />
                <ItemStyle Width="300" />
               <%-- <EditItemTemplate> 
                    <asp:TextBox ID="chklistremark" runat="server" Text='<%# Bind("demanddate") %>' Width="300"></asp:TextBox> 
                </EditItemTemplate> --%>
                <ItemTemplate> 
                    <asp:Label ID="lblDemandDate" runat="server" Text='<%# Bind("demanddate") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField> 
         
            <asp:TemplateField HeaderText="Village" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="10px"> 
                 <HeaderStyle Width="300" />
                <ItemStyle Width="300" />
               <%-- <EditItemTemplate> 
                    <asp:TextBox ID="chklistremark" runat="server" Text='<%# Bind("villagecode") %>' Width="300"></asp:TextBox> 
                </EditItemTemplate> --%>
                <ItemTemplate> 
                    <asp:Label ID="lblVillageCode" runat="server" Text='<%# Bind("villagecode") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField>

             <asp:TemplateField HeaderText="Document No" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="10px"> 
                 <HeaderStyle Width="300" />
                <ItemStyle Width="300" />
               <%-- <EditItemTemplate> 
                    <asp:TextBox ID="chklistremark" runat="server" Text='<%# Bind("documentno") %>' Width="300"></asp:TextBox> 
                </EditItemTemplate> --%>
                <ItemTemplate> 
                    <asp:Label ID="lblDocumentNo" runat="server" Text='<%# Bind("documentno") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Series No" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="10px"> 
                 <HeaderStyle Width="300" />
                <ItemStyle Width="300" />
               <%-- <EditItemTemplate> 
                    <asp:TextBox ID="chklistremark" runat="server" Text='<%# Bind("seriesno") %>' Width="300"></asp:TextBox> 
                </EditItemTemplate> --%>
                <ItemTemplate> 
                    <asp:Label ID="lblSeriesNo" runat="server" Text='<%# Bind("seriesno") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Phase No" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="10px"> 
                 <HeaderStyle Width="300" />
                <ItemStyle Width="300" />
               <%-- <EditItemTemplate> 
                    <asp:TextBox ID="chklistremark" runat="server" Text='<%# Bind("phaseno") %>' Width="300"></asp:TextBox> 
                </EditItemTemplate> --%>
                <ItemTemplate> 
                    <asp:Label ID="lblPhaseNo" runat="server" Text='<%# Bind("phaseno") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField>

        <asp:TemplateField HeaderText="Total Demand" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="10px"> 
                 <HeaderStyle Width="300" />
                <ItemStyle Width="300" />
               <%-- <EditItemTemplate> 
                    <asp:TextBox ID="chklistremark" runat="server" Text='<%# Bind("totaldemand") %>' Width="300"></asp:TextBox> 
                </EditItemTemplate> --%>
                <ItemTemplate> 
                    <asp:Label ID="lblTotalDemand" runat="server" Text='<%# Bind("totaldemand") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Demand Sent On" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="10px"> 
                 <HeaderStyle Width="300" />
                <ItemStyle Width="300" />
               <%-- <EditItemTemplate> 
                    <asp:TextBox ID="chklistremark" runat="server" Text='<%# Bind("demandsent") %>' Width="300"></asp:TextBox> 
                </EditItemTemplate> --%>
                <ItemTemplate> 
                    <asp:Label ID="lblDemandSent" runat="server" Text='<%# Bind("demandsent") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Approve" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="10px"> 
                 <HeaderStyle Width="300" />
                <ItemStyle Width="300" />
                <EditItemTemplate> 
                   <%-- <asp:DropDownList ID="ddlApprove" runat="server" DataValueField="demandapprove">
                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                        <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    </asp:DropDownList>--%>
                    <asp:TextBox ID="txtApprove" runat="server" Text='<%# Bind("demandapprove") %>' Width="300"></asp:TextBox> 
                </EditItemTemplate> 
                <ItemTemplate> 
                    <asp:Label ID="lblDemandApprove" runat="server" Text='<%# Bind("demandapprove") %>'></asp:Label> 
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
    <br />

    <%--<div class="upload" style="background-color:#f1c371;height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
       <div class="col-md-4" >
            <asp:Button ID="btnAddPaymentNote" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Add Payment Demand Note" Width="270px" xmlns:asp="#unknown" OnClick="btnAddPaymentNote_Click" />
       </div> 
              
        <div class="col-lg-3" style="padding-top:5px">
                            
        </div>
      <div class="col-lg-5" style="padding-top:5px" >
         

      </div>
        
   </div>--%>


    <script type="text/javascript">
        function endAdd(args) {
            $("#grdPaymentNote").ejWaitingPopup("show");
        }
        function endDelete(args) {
            $("#grdPaymentNote").ejWaitingPopup("show");
        }
        function endEdit(args) {
            $("#grdPaymentNote").ejWaitingPopup("show");
        }
        function complete(args) {
            if (args.requestType == "refresh" || args.requestType == "save") {
                $("#grdPaymentNote").ejWaitingPopup("hide");
            }
        }
    </script>

</asp:Content>


