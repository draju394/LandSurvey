<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewPaymentDetails.aspx.cs" Inherits="LandSurvey.Client.ViewPaymentDetails" %>

<%@ Register Assembly="Syncfusion.EJ.Web, Version=17.1460.0.32, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89" Namespace="Syncfusion.JavaScript.Web" TagPrefix="ej" %>

<%@ Register TagPrefix="ej" Namespace="Syncfusion.JavaScript.Models" Assembly="Syncfusion.EJ" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/jquery.validate.min.js"></script>
    <script src="../Scripts/ej.web.all.min.js"></script>
    <script src="../Scripts/ej.grid.min.js"></script>
    <script src="../Scripts/ej.unobtrusive.min.js"></script>
    <script src="../Scripts/jquery.validate.unobtrusive.min.js"></script>
    <link href="../Content/ej.widgets.core.min.css" rel="stylesheet" />
    <link href="../Content/ej.web.all.min.css" rel="stylesheet" />

    <style>
        .full-height {
            height: 100%;
        }
    </style>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>


    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/css/bootstrap-datepicker.css" type="text/css" />
    <!-- Boostrap DatePciker JS  -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var dp = $('#<%=txtFromDate.ClientID%>');
            dp.datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd/mm/yyyy",
                language: "tr",
                maxDate: "0"
            }).on('changeDate', function (ev) {
                $(this).blur();
                $(this).datepicker('hide');
            });

            var dp1 = $('#<%=txtToDate.ClientID%>');
            dp1.datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd/mm/yyyy",
                language: "tr",
                maxDate: "0"
            }).on('changeDate', function (ev) {
                $(this).blur();
                $(this).datepicker('hide');
            });

        });
    </script>



    <div>
        <div class="row" style="background-color: #f1c371; height: 35px; padding-top: 5px; border-radius: 5px 5px 5px 5px;">
            <div class="col-md-5">
                <label for="" style="color: saddlebrown; font-size: 18px;">View Payment Details</label>
                <label for="" style="color: white; font-size: 18px;" id="PopulationID"></label>
            </div>
            <%-- <div class="col-md-2">
                 <label for="" style="color:white;font-size: 18px;">बूथ संख्या :-</label>
                <label for="" style="color: white;font-size: 18px;" id="Booth_numberID"></label>
            </div>--%>
            <%--  <div class="col-md-2">
                 <label for="" style="color:white;font-size:18px;"> मतदारसंघ :</label>
                <label for="" style="color:white;font-size: 18px;" id="Vidhansabha_Id"></label>
            </div>--%>
        </div>
        <div>
            <h3></h3>
        </div>
        <%-- <asp:updatepanel id="UpdatePanel1" runat="server" xmlns:asp="#unknown">
         <Contenttemplate> style="width: 209px"--%>



        <table>
            <tr>
                <td>&nbsp;</td>
                <td colspan="4">
                    <asp:RadioButtonList ID="rblSearch" CellPadding="3" CellSpacing="3" AutoPostBack="true" OnSelectedIndexChanged="rblSearch_SelectedIndexChanged" RepeatDirection="Horizontal" runat="server">
                        <asp:ListItem Text="  Daily" Selected="True" Value="Daily"></asp:ListItem>
                        <asp:ListItem Text="  Weekly" Value="Weekly"></asp:ListItem>
                        <asp:ListItem Text="  Monthly" Value="Monthly"></asp:ListItem>
                        <asp:ListItem Text="  All Payments" Value="All"></asp:ListItem>
                        <asp:ListItem Text="  Document No" Value="DocNo"></asp:ListItem>
                        <asp:ListItem Text="  Family No" Value="FamNo"></asp:ListItem>
                    </asp:RadioButtonList>
                    <br />
                </td>
                <td style="width: 209px">&nbsp;</td>
            </tr>
            <tr id="trDocNos" runat="server" visible="false">
                <td style="width: 209px">&nbsp;</td>
                <td>Enter Document Number :
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtDocumentNumber" runat="server" CssClass="form-control" Width="250px">
                    </asp:TextBox>
                </td>
                <td style="width: 209px">&nbsp;</td>
            </tr>
            <tr id="trFamNo" runat="server" visible="false">
                <td style="width: 209px">&nbsp;</td>
                <td>Enter Family Number :
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtFamilyNo" runat="server" CssClass="form-control" Width="250px">
                    </asp:TextBox>
                </td>
                <td style="width: 209px">&nbsp;</td>
            </tr>
            <tr id="trDateRange" runat="server" visible="false">
                <td style="width: 209px">&nbsp;</td>
                <td>From Date :
                </td>
                <td>
                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control" Width="250px">
                    </asp:TextBox>
                </td>
                <td>To Date : 
                </td>
                <td>
                    <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control" Width="250px">
                    </asp:TextBox>
                </td>
                <td style="width: 209px">&nbsp;</td>
            </tr>

            <tr id="trShowBtn" runat="server" visible="true">
                <td style="width: 209px">&nbsp;</td>
                <td colspan="4">
                    <asp:Button ID="btnShow" runat="server" Text="Show" Height="30px" Width="75px" OnClick="btnShow_Click" />
                </td>

                <td style="width: 209px">&nbsp;</td>
            </tr>
        </table>

        <%-- </Contenttemplate>
        </asp:updatepanel>--%>
        <%--        <asp:UpdatePanel ID="updatepn2" runat="server"> 
             <ContentTemplate> --%>
        <div>

            <br />
            <ej:Grid ID="grdPayDetails" runat="server" AllowPaging="True" IsResponsive="True" OnServerPdfExporting="grdPayDetails_ServerPdfExporting" AllowTextWrap="true">
                <ToolbarSettings ShowToolbar="true" ToolbarItems="excelExport,wordExport,pdfExport"></ToolbarSettings>
                <PageSettings PageSize="5"></PageSettings>
                <TextWrapSettings WrapMode="Both" />
                <%--<SummaryRows  >
                <ej:SummaryRow Title="" >

                    <SummaryColumn>

                        <ej:SummaryColumn SummaryType="Count" Format="{0:C}" DisplayColumn="docno" DataMember="docno" CustomSummaryValue="" />

                    </SummaryColumn>

                </ej:SummaryRow>

                   <ej:SummaryRow Title="Amount Paid">

                    <SummaryColumn>

                          <ej:SummaryColumn SummaryType="Sum" Format="{0:C}" DisplayColumn="amountpaid" DataMember="amountpaid" CustomSummaryValue="CustomValue" />

                    </SummaryColumn>

                </ej:SummaryRow> 

            </SummaryRows>--%>

                <Columns>
                    <ej:Column Field="docno" HeaderText="Doc No." Width="8%" />
                    <ej:Column Field="familyno" HeaderText="Family N0" Width="8%" />
                    <ej:Column Field="surveyno" HeaderText="Survey No" Width="8%"/>
                    <ej:Column Field="holdername" HeaderText="Holder Name" Width ="25%"/>
                    <ej:Column Field="voucherno" HeaderText="Voucher No" Width ="8%"/>
                    <ej:Column Field="voucherdate" HeaderText="Voucher Date" Width ="8%" />
                    <ej:Column Field="amountpaid" HeaderText="Amount Paid" Width ="8%" TextAlign="Right"
                        />
                    <ej:Column Field="amounttype" HeaderText="Amount Type" Width ="8%" />
                </Columns>
            </ej:Grid>
        </div>
        <%--</contenttemplate> ,,, ,,, , 
              <Triggers> 
              <asp:PostBackTrigger controlid="Grid1"/> 
             </Triggers> 
        </asp:updatepanel>--%>
        <br />
        <br />
        <br />
    </div>
</asp:Content>
