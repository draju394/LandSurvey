<%@ Page Title="" Language="C#" MasterPageFile="~/OTPMaster.Master" AutoEventWireup="true" CodeBehind="otpAuthentication.aspx.cs" Inherits="LandSurvey.User.otpAuthentication" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
                <label for="" style="color:saddlebrown;font-size: 18px;">Authenticate User Name</label>
            </div>
           <%-- <div class="col-md-2">
                 <asp:TextBox ID="txtDocNo" runat="server" Visible="False"></asp:TextBox>
           </div>
            <div class="col-md-2">
              
            </div>--%>
    </div>

     <div class="row" style="padding-top:10px">
         <div class="col-md-4">
                <label for="" style="color:saddlebrown;font-size: 13px;">User Name: </label>
                <asp:Label ID="lblUser" runat="server"></asp:Label>
                
         </div>
         <div class="col-md-4">
                <label for="" style="color:saddlebrown;font-size: 13px;">Mobile No: </label>
                <asp:Label ID="lblMobile" runat="server"></asp:Label>
                
         </div>

     </div>

     <div class="row" style="padding-top:10px">
         <div class="col-md-8">
                <label for="" style="color:saddlebrown;font-size: 13px;">Enter OTP:</label>
                <asp:TextBox ID="txtOTP" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
         </div>

     </div>
    <br />

     <div class="upload" style="background-color:#f1c371;height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
       <div class="col-md-8" >
            <asp:Button ID="btnSubmitUser" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Authenticate OTP" Width="270px" xmlns:asp="#unknown" OnClick="btnSubmitUser_Click"/>
       </div> 

      </div>

    <br />

</asp:Content>
