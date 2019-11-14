<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="LandSurvey.UserLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Login Form</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />  
    <meta name="viewport" content="width=device-width, initial-scale=1" />  
    <meta name="description" content="" />  
    <meta name="author" content="Rajendra" /> 

    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>

    <script>  
       function FunForLoginValidation() {  
           var objValid = true;  
           var objUserName = $("[id$=txtUserName]").val();  
           var objPassword = $("[id$=txtPassword]").val();  
           if (objUserName == "") {  
               $('[id$=lblErrUserName]').text("User Name is required");  
               $('[id$=lblErrUserName]').css("color", "#FF0000");  
               $("[id$=txtUserName]").addClass("Error-control");  
               objValid = false;  
           }  
           else {  
               $('[id$=lblErrUserName]').text("");  
               $('[id$=lblErrUserName]').css("color", "#FFFFFF");  
               $("[id$=txtUserName]").removeClass("Error-control");  
           }  
  
           if (objPassword == "") {  
               $('[id$=lblErrPassword]').text("Password is required");  
               $('[id$=lblErrPassword]').css("color", "#FF0000");  
               $("[id$=txtPassword]").addClass("Error-control");  
               objValid = false;  
           }  
           else {  
               $('[id$=lblErrPassword]').text("");  
               $('[id$=lblErrPassword]').css("color", "#FFFFFF");  
               $("[id$=txtPassword]").removeClass("Error-control");  
           }  
           return objValid;  
       }  
       function AcceptAlphanumeric(evt) {  
           var key = evt.keyCode;  
           return ((key >= 48 && key <= 57) || (key >= 65 && key <= 90) || (key >= 95 && key <= 122));  
       }  
       function NotAllowSingleDoubleQuotes(e) {  
           var charCode = e.keyCode;  
           if (charCode == 34)  
               return false;  
           if (charCode == 39)  
               return false;  
       }  
   </script>  
    
    <style type="text/css">
        .auto-style1 {
            display: block;
            width: 100%;
            height: 34px;
            padding: 6px 12px;
            font-size: 14px;
            line-height: 1.42857143;
            color: #555;
            background-color: #fff;
            background-image: none;
            border: 1px solid #ccc;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            left: 0px;
            top: 1px;
        }
        /*body {background-color: #7d679d;}*/
        body {
            /*background-color: #CD853F;*/
            background-image: url(Images/main2.jpg);
            background-size:cover;
            /*F: \DatarSirWork\LandSurvey\LandSurvey\LandSurvey\Images\main2.jpg*/
        } 
        .panel-default > .panel-heading-custom {
            background:#8B4513; color: #fff; }
        .panel-default > .panel-title {
            background: #F4A460; color: #fff; }
        .panel-body > .panel-title {
            background: #e04a12; color: #fff; }

    </style>

    
</head>
  
  
    
<body>
    <form id="form1" runat="server">  
       <div class="form-container col-md-8 ">  
           <div class="row">  
               <div class="col-lg-6" style="margin: 30px; float: initial; padding-top: 20%; border:1px"> 
                   
                   <%--<div class="col-lg-5 col-md-6 col-sm-8 col-xl-12 " style="margin: auto; float: initial; padding-top: 1%; border:1px"> --%> 
                   <div class="row userInfo">  
<%--  class="form-container text-center col-xs-4 col-xs-offset-4 col-xs-offset-4 col-md-4 col-md-offset-0"--%>
                       <div class="panel panel-default" style="border:none" >  
                           <div class="panel-heading panel-heading-custom" style="border:none" >
                                <h1 class="panel-title" style="text-align: center; font-weight: bold">  
                                  <%-- <a class="collapseWill">Land Acquisition Information System - Thane Region</a> --%> 
                               </h1>  
                           </div>
                           <div class="panel-heading panel-title" style="border:none">  
                              
                               <h3 class="panel-title" style="text-align: center; font-weight: bold">  
                                   <a class="collapseWill">Login to your Account</a>  
                               </h3>  
                           </div>  
                           <div id="collapse1" class="panel-collapse collapse in">  
                               <div class="panel-body">  
                                   <fieldset>  
                                       <div class="form-group">  
                                           <div class="col-md-"></div>  
                                           <label class="col-md-12 control-label" for="prependedcheckbox">  
                                               User ID  
                                           </label>  
                                           <div class="col-md-12">  
                                               <div class="input-group">  
                                                   <span class="input-group-addon">  
                                                       <i class="fa fa-user"></i>  
                                                   </span>  
                                                   <asp:TextBox ID="txtUserName" CssClass="auto-style1" placeholder="Enter User ID" runat="server"></asp:TextBox>  
                                               </div>  
                                               <asp:Label ID="lblErrUserName" CssClass="help-block" runat="server" Text="" ForeColor="White"></asp:Label>  
                                           </div>  
  
                                           <label class="col-md-12 control-label" for="prependedcheckbox">  
                                               Password  
                                           </label>  
                                           <div class="col-md-12">  
                                               <div class="input-group">  
                                                   <span class="input-group-addon">  
                                                       <i class="fa fa-lock"></i>  
                                                   </span>  
                                                   <asp:TextBox ID="txtPassword" CssClass="form-control" placeholder="Enter Your Password" runat="server" TextMode="Password"></asp:TextBox>  
                                               </div>  
                                               <asp:Label ID="lblErrPassword" CssClass="help-block" runat="server" Text="" ForeColor="White"></asp:Label>  
                                           </div>  
  
                                           <div class="col-md-12">  
                                               <div class="col-lg-6">  
                                                   <asp:CheckBox ID="chbRemember" Visible="false" runat="server" Text="Remember" />  
                                               </div>  
                                               <div class="col-lg-6">  
                                                   <div class="input-group" style="width: 100%">  
                                                       <asp:Button ID="btnLogin" CssClass="btn btn-success" Text="Login" OnClientClick="return FunForLoginValidation()" runat="server" Style="width: 100%" OnClick="btnLogin_Click" />  
                                                   </div>  
                                               </div>  
                                           </div>  
                                       </div>  
                                   </fieldset>  
  
                               </div>  
                           </div>  
  
                           <div class="panel-heading" style="background-color:#8B4513; border:none">  
                               <div class="panel-title" style="text-align: right;">  
                                   <a class="collapseWill" href="#" style="font-size:xx-small; color:white">Forgot Username or Password?  
                                   </a>  
                               </div>  
                           </div>  
                       </div>  
                   </div>  
               </div>  
           </div>  
       </div>  
   </form>  
<%--<form id="form1" runat="server">
   

<div class="container-fluid">
<table class="table table-hover text-centered">
<tr>
<td >
Username:
</td>
<td>
<asp:TextBox ID="txtUserName" runat="server"/>
<asp:RequiredFieldValidator ID="rfvUser" ErrorMessage="Please enter Username" ControlToValidate="txtUserName" runat="server" />
</td>
</tr>
<tr>
<td>
Password:
</td>
<td>
<asp:TextBox ID="txtPWD" runat="server" TextMode="Password"/>
<asp:RequiredFieldValidator ID="rfvPWD" runat="server" ControlToValidate="txtPWD" ErrorMessage="Please enter Password"/>
</td>
</tr>
<tr>
<td>
</td>
<td>
<asp:Button ID="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click" />
</td>
</tr>
</table>
</div>
</form>--%>
    
</body>
</html>
