<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login2.aspx.cs" Inherits="LandSurvey.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8" />  
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />  
    <meta name="viewport" content="width=device-width, initial-scale=1" />  
    <meta name="description" content="" />  
    <meta name="author" content="ananth.G" />  
   
   <%-- <link href="bootstrap/css/bootstrap.css" rel="stylesheet" />  
    <link href="css/skin-3.css" rel="stylesheet" />  
    <link href="css/style.css" rel="stylesheet" />  
    <link href="bootstrap/css/font-awesome.min.css" rel="stylesheet" />  
    <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>  
    <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>  
    <script src="bootstrap/js/jquery-1.9.1.js"></script>  --%>
    <style>  
        body {  
            /*background: url(../images/06.jpg) no-repeat;*/  
            background-size: cover;  
            min-height: 100%;  
        }  
  
        html {  
            min-height: 100%;  
        }  
  
        .Error-control {  
            background: #ffdedd !important;  
            border-color: #ff5b57 !important;  
        }  
    </style>  
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server">
            <Scripts>
                <%--To learn more about bundling scripts in ScriptManager see https://go.microsoft.com/fwlink/?LinkID=301884 --%>
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="bootstrap" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
                <%--Site Scripts--%>
            </Scripts>
        </asp:ScriptManager>

        <div class="container">  
           <div class="row">  
               <div class="col-lg-5 col-md-6 col-sm-8 col-xl-12 " style="margin: auto; float: initial; padding-top: 12%">  
                   <div class="row userInfo">  
  
                       <div class="panel panel-default ">  
                           <div class="panel-heading">  
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
                                                   <asp:TextBox ID="txtUserName" CssClass="form-control" placeholder="Enter User ID" runat="server"></asp:TextBox>  
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
                                                       <asp:Button ID="btnLogin" CssClass="btn btn-success" Text="Login" OnClientClick="return FunForLoginValidation()" runat="server" Style="width: 100%" />  
                                                   </div>  
                                               </div>  
                                           </div>  
                                       </div>  
                                   </fieldset>  
  
                               </div>  
                           </div>  
  
                           <div class="panel-heading">  
                               <div class="panel-title" style="text-align: right">  
                                   <a class="collapseWill" href="SellerForgetPassword.aspx" style="font-size: x-small">Forgot Username or Password?  
                                   </a>  
                               </div>  
                           </div>  
                       </div>  
                   </div>  
               </div>  
           </div>  
       </div>  
    </form>
</body>
</html>
