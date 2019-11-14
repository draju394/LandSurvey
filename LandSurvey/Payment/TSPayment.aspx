<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TSPayment.aspx.cs" Inherits="LandSurvey.Payment.TSPayment" EnableEventValidation = "false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
 <%--   <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.min.js"></script>--%>

    <link href="../Content/bootstrap-datetimepicker.css" rel="stylesheet" />
<%--    <link href="../Content/bootstrap-datetimepicker.min.css" rel="stylesheet" />--%>
    <script src="../Scripts/bootstrap-datetimepicker.min.js"></script>
    
    <style>
        table { 
             border-spacing: 5px;
             border-collapse: separate;
             }
        .auto-style3 {
            width: 161px;
        }
        .auto-style7 {
            height: 22px;
        }
        .auto-style8 {
            width: 125px;
        }
        .auto-style10 {
            width: 114px;
        }
        .auto-style11 {
            width: 14px;
        }
        .auto-style12 {
            width: 114px;
            height: 22px;
        }
        .auto-style13 {
            width: 14px;
            height: 22px;
        }
        .auto-style14 {
            width: 161px;
            height: 22px;
        }
        .auto-style15 {
            width: 125px;
            height: 22px;
        }
        .auto-style19 {
            height: 22px;
            width: 193px;
        }
        .auto-style21 {
            height: 22px;
            width: 129px;
        }
        .auto-style23 {
            width: 193px;
        }
        .auto-style25 {
            width: 159px;
        }
        .auto-style26 {
            height: 22px;
            width: 159px;
        }
        .auto-style28 {
            width: 129px;
        }
        .auto-style29 {
            margin-left: 80px;
        }
        .auto-style30 {
            width: 126px;
        }
        .auto-style31 {
            width: 126px;
            height: 22px;
        }
        .auto-style34 {
            width: 127px;
        }
        .auto-style35 {
            width: 127px;
            height: 22px;
        }
        .auto-style37 {
            width: 126px;
            height: 32px;
        }
        .auto-style38 {
            height: 32px;
        }
        .auto-style39 {
            width: 159px;
            height: 32px;
            text-align: justify;
        }
        .auto-style40 {
            display: block;
            font-size: 14px;
            line-height: 1.42857143;
            color: #555;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
            box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
            -webkit-transition: border-color ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            border: 1px solid #ccc;
            padding: 6px 12px;
            background-color: #fff;
            background-image: none;
        }
        .auto-style41 {
            width: 126px;
            height: 38px;
        }
        .auto-style42 {
            height: 38px;
        }
        .auto-style43 {
            width: 159px;
            height: 38px;
        }
        .auto-style45 {
        font-size: 14px;
    }
         .btn-primary, .btn-primary:hover, .btn-primary:active, .btn-primary:visited
        {
        background-color: saddlebrown !important;
        border-color: saddlebrown !important;
        }
        </style>

   <script type="text/javascript">
    $(".form_datetime").datetimepicker({
        format: "dd MM yyyy - hh:ii"
    });
</script>      
   <%-- <script type="text/javascript">
      $('.form_date').datetimepicker({
        language:  'fr',
        weekStart: 1,
        todayBtn:  1,
		autoclose: 1,
		todayHighlight: 1,
		startView: 2,
		minView: 2,
		forceParse: 0
    });
    </script>   --%>

    <asp:Panel ID="Panel1" runat="server" Height="531px">
        <table style="width:100%;">
            <tr>
                <td colspan="7" style="background-color:peru">
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Medium" Text="Payment " ForeColor="White"></asp:Label>
                </td>
               <%-- <td class="auto-style3">&nbsp;</td>
                <td colspan="4">&nbsp;</td>--%>
            </tr>
            <tr>
                <td class="auto-style10">
                    <asp:Label ID="Label3" runat="server" Text="Village Name :"></asp:Label>
                </td>
                <td class="auto-style11">
                    <asp:DropDownList ID="cmbVillage" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbVillage_SelectedIndexChanged" CssClass="auto-style40" Width="250px">
                    </asp:DropDownList>
                </td>
                <td class="auto-style10">
                    <asp:Label ID="Label4" runat="server" Text="Family Number :" Visible="False" ></asp:Label>
                </td>
                <td colspan="4">
                    <asp:DropDownList ID="cmbFamily" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbFamily_SelectedIndexChanged" CssClass="form-control" Width="250px" Visible="False">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">
                    <asp:Label ID="Label5" runat="server" Text="Document No. :"></asp:Label>
                </td>
                <td class="auto-style11">
                    <asp:DropDownList ID="cmbDocumentNo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbDocumentNo_SelectedIndexChanged" CssClass="form-control" Width="250px">
                    </asp:DropDownList>
                </td>
                <td class="auto-style3">
                    <asp:Label ID="Label7" runat="server" Text="Family Total Area :" CssClass="auto-style45"></asp:Label>
                </td>
                <td class="auto-style8">
                    <asp:Label ID="lblFamilyTotArea" runat="server" Text="FamilyTotalArea"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label9" runat="server" Text="Status :"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7" colspan="6">
                    <asp:GridView ID="grdHolderName" runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="899px" OnSelectedIndexChanged="grdHolderName_SelectedIndexChanged" OnRowDataBound = "OnRowDataBound" AllowPaging="True" OnPageIndexChanging="grdHolderName_PageIndexChanging" PageSize="5">
                        <Columns>
                            <asp:BoundField DataField="srno" HeaderText="Sr. No." />
                            <asp:BoundField DataField="surveyno" HeaderText="Survey. No." />
                            <asp:BoundField DataField="holdername" HeaderText="Holder Name" />
                            <asp:BoundField DataField="holderarea" HeaderText="Holder Area" />
                            <asp:BoundField DataField="areaaquired" HeaderText="Aquired Area" />
                        </Columns>
                        <EmptyDataTemplate>
                            No Record Available
                        </EmptyDataTemplate>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                </td>
                <td class="auto-style7"></td>
            </tr>
            <tr>
                <td class="auto-style12"></td>
                <td class="auto-style13"></td>
                <td class="auto-style14"></td>
                <td class="auto-style15"></td>
                <td class="auto-style7" colspan="2"></td>
                <td class="auto-style7"></td>
            </tr>
            <tr>
                <td class="auto-style7" colspan="6">
                    <table style="width:100%;">
                        <tr>
                            <td class="auto-style30">
                                <asp:Label ID="Label10" runat="server" Text="Survey No. :"></asp:Label>
                            </td>
                            <td class="auto-style23">
                                <asp:Label ID="lblSurveyNo" runat="server" Text="surveyno"></asp:Label>
                            </td>
                            <td class="auto-style28">
                                <asp:Label ID="Label11" runat="server" Text="Holder Name :"></asp:Label>
                            </td>
                            <td class="auto-style25">
                                <asp:Label ID="lblHolderName" runat="server" Text="holdername"></asp:Label>
                            </td>
                            <td class="auto-style34">
                                <asp:Label ID="Label17" runat="server" Text="Payment Type :"></asp:Label>
                            </td>                            <td>
                                <asp:DropDownList ID="cmbPaymentType" runat="server" CssClass="form-control">
                                    <asp:ListItem>Token Installment 1</asp:ListItem>
                                    <asp:ListItem>Token Installment 2</asp:ListItem>
                                    <asp:ListItem>Token Installment 3</asp:ListItem>
                                    <asp:ListItem>Registration Charges</asp:ListItem>
                                    <asp:ListItem>Stamp Duty</asp:ListItem>
                                    <asp:ListItem>Processing Charges</asp:ListItem>
                                    <asp:ListItem>Miscellaneous Charges</asp:ListItem>
                                    <asp:ListItem>Final Mutation</asp:ListItem>
                                    <asp:ListItem>Other Payment</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style31">
                                <asp:Label ID="Label12" runat="server" Text="Voucher No. :"></asp:Label>
                            </td>
                            <td class="auto-style19">
                                <asp:TextBox ID="txtVoucherNo" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                            <td class="auto-style21">
                                <asp:Label ID="Label13" runat="server" Text="Voucher Date :"></asp:Label>
                            </td>
                            <td class="auto-style26">
                                
				               <input type = "text" id="VoucherDate" readonly Class="form-control" runat="server" ClientIDMode="Static" />
                                <script>
                                    $("#VoucherDate").datetimepicker({
                                        format: 'dd-mm-yyyy',
                                        minView: 2,
                                        maxView: 4,
                                        autoclose: true
                                    });
                                </script>
                                  
                            </td>
                            <td class="auto-style35">
                                <asp:Label ID="Label14" runat="server" Text="Payment Date :"></asp:Label>
                            </td>
                            <td class="auto-style7">
                                <input type = "text" id="PaymentDate" readonly Class="form-control" runat="server" ClientIDMode="Static"/>
                                <script>
                                    $("#PaymentDate").datetimepicker({
                                        format: 'dd-mm-yyyy',
                                        minView: 2,
                                        maxView: 4,
                                        autoclose: true
                                    });
                                </script></td>
                        </tr>
                        <tr>
                            <td class="auto-style30">
                                <asp:Label ID="Label15" runat="server" Text="Payment Mode :"></asp:Label>
                            </td>
                            <td class="auto-style23">
                                <asp:DropDownList ID="cmbPaymentMode" runat="server" CssClass="form-control" >
                                    <asp:ListItem>Cheque</asp:ListItem>
                                    <asp:ListItem>DD</asp:ListItem>
                                    <asp:ListItem>RTGS</asp:ListItem>
                                    <asp:ListItem>NEFT</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="auto-style28">
                                <asp:Label ID="Label16" runat="server" Text="Amount  :"></asp:Label>
                            </td>
                            <td class="auto-style25">
                                <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control input-sm" TextMode="Number" placeholder =" #0.00"></asp:TextBox>
                            </td>
                            <td class="auto-style34">
                                <asp:Label ID="Label18" runat="server" Text="Cheque / DD No. :"></asp:Label>
                            </td>
                            <td class="auto-style29">
                                <asp:TextBox ID="txtChequeDDNo" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style30">
                                <asp:Label ID="Label20" runat="server" Text="Bank Details :"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtBankDetails" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                            <td class="auto-style25">&nbsp;</td>
                            <td class="auto-style34">
                                <asp:Label ID="Label19" runat="server" Text="Cheque / DD Date :"></asp:Label>
                            </td>
                            <td class="auto-style29">
                                <input type = "text" id="ChequeDate" readonly Class="form-control" runat="server" ClientIDMode="Static"/>
                                <script>
                                    $("#ChequeDate").datetimepicker({
                                        format: 'dd-mm-yyyy',
                                        minView: 2,
                                        maxView: 4,
                                        autoclose: true
                                    });
                                </script>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style37">
                                <asp:Label ID="Label21" runat="server" Text="Purchase Name :"></asp:Label>
                            </td>
                            <td colspan="2" class="auto-style38">
                                <asp:DropDownList ID="cmbPurchaser" runat="server" AutoPostBack="true" CssClass="form-control">
                                </asp:DropDownList>
                            </td>
                            <td class="auto-style39">
                                <asp:Label ID="Label22" runat="server" Text="Client Name :"></asp:Label>
                            </td>
                            <td colspan="2" class="auto-style38">
                                <asp:DropDownList ID="cmbClientName" runat="server" AutoPostBack="true" CssClass="form-control">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style30">&nbsp;</td>
                            <td colspan="2">&nbsp;</td>
                            <td class="auto-style25">&nbsp;</td>
                            <td colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style41"></td>
                            <td colspan="2" class="auto-style42">
                                <asp:Button ID="btnSavePayment" runat="server" AutoPostBack="true" CssClass="btn btn-primary" OnClick="btnSavePayment_Click" Text="Save Payment" Width="169px" xmlns:asp="#unknown" > </asp:Button> 
                                
                            </td>
                            <td class="auto-style43"></td>
                            <td colspan="2" class="auto-style42"></td>
                        </tr>
                        <tr>
                            <td class="auto-style41">&nbsp;</td>
                            <td class="auto-style42" colspan="2">&nbsp;</td>
                            <td class="auto-style43">&nbsp;</td>
                            <td class="auto-style42" colspan="2">&nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td class="auto-style7">&nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
 
</asp:Content>
