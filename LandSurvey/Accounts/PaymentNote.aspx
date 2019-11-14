<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaymentNote.aspx.cs" Inherits="LandSurvey.Accounts.PaymentNote" EnableEventValidation = "false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <%--<script src="//code.jquery.com/jquery-1.11.1.min.js" type="text/javascript"></script>--%>
    <link href="../Content/bootstrap-datetimepicker.css" rel="stylesheet" />
<%--    <link href="../Content/bootstrap-datetimepicker.min.css" rel="stylesheet" />--%>
    <script src="../Scripts/bootstrap-datetimepicker.min.js"></script>

    <%--<script src="../Scripts/jquery-3.3.1.min.js" type="text/javascript"></script>--%>

    <script type="text/javascript">
        $(document).ready(function () {
            //Iterate through each Textbox and add keyup event handler
            $(".clsTxtToCalculate").each(function () {
                $(this).keyup(function () {
                    //Initialize total to 0
                    var total = 0;
                    $(".clsTxtToCalculate").each(function () {
                        // Sum only if the text entered is number and greater than 0
                        if (!isNaN(this.value) && this.value.length != 0) {
                            total += parseFloat(this.value);
                        }
                    });
                    //Assign the total to label
                    //.toFixed() method will roundoff the final sum to 2 decimal places
                    $('#<%=txtTotalDemand.ClientID %>').val(total.toFixed(2));
                });
            });
        });
    </script>

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

     <script type="text/javascript">
        $(".form_datetime").datetimepicker({
            format: "dd MM yyyy - hh:ii"
        });
    </script>   

    <div class="row" style="background-color:#f1c371;height:35px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
            <div class="col-md-8">
                <label for="" style="color:saddlebrown;font-size: 18px;">Payment Demand Note</label>
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

    <div class="row" style="padding-top:10px">
         
        <div class="col-md-3">
                <label for="" style="color:saddlebrown;font-size: 13px; ">Demand No:</label>
                <asp:TextBox ID="txtDemandNoteEntry" runat="server" CssClass="form-control" ></asp:TextBox>
         </div>
         <div class="col-md-3">
                <label for="" style="color:saddlebrown;font-size: 13px;">Demand Date:</label>
                <%--<asp:TextBox ID="txtDemandDate" runat="server" CssClass="form-control"></asp:TextBox>--%>
                <input type = "text" id="DemandDate" readonly Class="form-control" runat="server" ClientIDMode="Static" />
                <script>
                    $("#DemandDate").datetimepicker({
                        format: 'dd-mm-yyyy',
                        minView: 2,
                        maxView: 4,
                        autoclose: true
                    });
                </script>
         </div>
         <div class="col-md-3">
                <label for=""  style="color:saddlebrown;font-size: 13px;" >Series No:</label>
                <asp:DropDownList ID="cmbSeriesNo" runat="server" AutoPostBack="true" CssClass="form-control">
                    <asp:ListItem>A</asp:ListItem>
                    <asp:ListItem>B</asp:ListItem>
                    <asp:ListItem>C</asp:ListItem>
                </asp:DropDownList>
         </div>
        <div class="col-md-3">
                <label for=""  style="color:saddlebrown;font-size: 13px;" >Phase No:</label>
                <asp:DropDownList ID="cmbPhaseNo" runat="server" AutoPostBack="true" CssClass="form-control">
                    <asp:ListItem>Phase 1</asp:ListItem>
                    <asp:ListItem>Phase 2</asp:ListItem>
                    <asp:ListItem>Phase 3</asp:ListItem>
                    <asp:ListItem>Phase 4</asp:ListItem>
                </asp:DropDownList>
         </div>
    </div>

    <div class="row" style="padding-top:10px">
         <div class="col-md-3" style="align-content:flex-end">
                <label for="" style="color:saddlebrown;font-size: 13px;">Token Amount:</label>
         </div>
         <div class="col-md-3">
                  <asp:TextBox ID="txtTokenAmount" TextMode="Number" placeholder ="0.00" runat="server" CssClass="form-control clsTxtToCalculate"></asp:TextBox>
         </div>
        <div class="col-md-3" style="align-content:flex-end">
                <label for="" style="color:saddlebrown;font-size: 13px;">Document Area:</label>
         </div>
         <div class="col-md-3">
                  <asp:TextBox ID="txtDocArea" runat="server" TextMode="Number"  placeholder ="0.00" CssClass="form-control"></asp:TextBox>
         </div>
   </div>

    <div class="row" style="padding-top:10px">
         <div class="col-md-3" style="align-content:flex-end">
                <label for="" style="color:saddlebrown;font-size: 13px;">Registration Charges:</label>
         </div>
         <div class="col-md-3">
                  <asp:TextBox ID="txtRegistrationCharges" runat="server" TextMode="Number" placeholder ="0.00" CssClass="form-control clsTxtToCalculate"></asp:TextBox>
         </div>

        <div class="col-md-3">
                <label for="" style="color:saddlebrown;font-size: 13px; visibility:hidden">Demand No:</label>
                <asp:TextBox ID="txtDemandNo" runat="server" CssClass="form-control" placeholder ="0.00" Visible="false"></asp:TextBox>
         </div>
   </div>
   
    <div class="row" style="padding-top:10px">
         <div class="col-md-3" style="align-content:flex-end">
                <label for="" style="color:saddlebrown;font-size: 13px;">Stamp Duty:</label>
         </div>
         <div class="col-md-3">
                  <asp:TextBox ID="txtStampDuty" runat="server" TextMode="Number" placeholder ="0.00" CssClass="form-control clsTxtToCalculate"></asp:TextBox>
         </div>
   </div>

    <div class="row" style="padding-top:10px">
         <div class="col-md-3" style="align-content:flex-end">
                <label for="" style="color:saddlebrown;font-size: 13px;">Processing Charges:</label>
         </div>
         <div class="col-md-3">
                  <asp:TextBox ID="txtProcessing" runat="server" TextMode="Number" placeholder ="0.00" CssClass="form-control clsTxtToCalculate"></asp:TextBox>
         </div>
   </div>

    <div class="row" style="padding-top:10px">
         <div class="col-md-3" style="align-content:flex-end">
                <label for="" style="color:saddlebrown;font-size: 13px;">Miscellaneous Charges:</label>
         </div>
         <div class="col-md-3">
                  <asp:TextBox ID="txtMiscAmount" runat="server" TextMode="Number" placeholder ="0.00" CssClass="form-control clsTxtToCalculate"></asp:TextBox>
         </div>
   </div>

    <div class="row" style="padding-top:10px">
         <div class="col-md-3" style="align-content:flex-end">
                <label for="" style="color:saddlebrown;font-size: 13px;">Total Demand:</label>
         </div>
         <div class="col-md-3">
                  <asp:TextBox ID="txtTotalDemand" runat="server" TextMode="Number" placeholder ="0.00" CssClass="form-control"></asp:TextBox>
         </div>
   </div>
    <br />
    <div class="upload" style="background-color:#f1c371;height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
       <div class="col-md-4" >
            <asp:Button ID="btnSavePaymentNote" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Save Payment Demand Note" Width="270px" xmlns:asp="#unknown" OnClick="btnSavePaymentNote_Click"  />
       </div> 
              
        <div class="col-lg-3" style="padding-top:5px">
                            
        </div>
      <div class="col-lg-5" style="padding-top:5px" >
         <asp:Button ID="btnPaymentList" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Go Back" Width="270px" xmlns:asp="#unknown" OnClick="btnPaymentList_Click" />

      </div>
        
   </div>
    <br />
   <%-- <div style="padding-top:5px">
        <a href="javascript: history.go(-1)">Go Back</a>
    </div>--%>
</asp:Content>
