<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LandSurvey._Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-alpha.2/css/bootstrap.min.css" integrity="sha384-y3tfxAZXuh4HwSYylfB+J125MxIs6mR5FOHamPBG064zB+AFeWH94NdvaCBm8qnd" crossorigin="anonymous">
    <%--<div class="jumbotron">
        <h1>Land Survey</h1>
        <p class="lead">Land Survey Application</p>
        <p class="lead">District - Thane Taluka - Bhiwandi</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
        <asp:Label ID="UserName" runat="server" Text="Label"></asp:Label>
    </div>--%>
    <br>
   <div class="card-columns">
  <div class="card bg-primary">
    <div class="card-body text-center">
        <h3 class="card-title">Inward Outward</h3>
      <p class="card-text">Document Inward Outward</p>
       <%-- <a href="#" class="btn btn-primary">Create</a>--%>
        <a href="Masters/frmInwardOutwardReg.aspx" class="btn btn-primary">More..</a>
    </div>
      
  </div>
  <div class="card bg-danger">
    <div class="card-body text-center">
      <h3 class="card-title">Execuation</h3>
      <p class="card-text">Document Execution</p>
        <a href="Execuation/DocExecution" class="btn btn-primary">More..</a>
    </div>
  </div>
      
        <% if (IsAdmin == 1) { %>

   <div class="card bg-warning">
    <div class="card-body text-center">
      <h3 class="card-title">Title Search</h3>
      <p class="card-text">Generate Title Search</p>
        <%--<a href="#" class="btn btn-primary">Create</a>--%>
        <a href="TitleSearch/TitleSearch11" class="btn btn-primary">More..</a>
    </div>
  </div>
       <% }%>
       <% else{ %>

    <div class="card bg-warning">
    <div class="card-body text-center">
      <h3 class="card-title">Title Search</h3>
      <p class="card-text">Generate Title Search</p>
        <%--<a href="#" class="btn btn-primary">Create</a>--%>
        <a href="#" onClick="alert('You are not Authorised!')"  class="btn btn-primary" >More..</a>
        
    </div>
  </div>
                      
          <%} %>

       <div class="card bg-inverse">
    <div class="card-body text-center">
      <h3 class="card-title">Final Mutation</h3>
      <p class="card-text">Document Final Mutation Details</p>
        <a href="#" class="btn btn-primary">More..</a>
    </div>
  </div>

 <% if (IsAdmin == 1) { %>
  <div class="card bg-success">
    <div class="card-body text-center">
      <h3 class="card-title">Payment</h3>
      <p class="card-text">Make a Payment</p>
        <%--<a href="Payment/TSPayment" class="btn btn-primary">Create</a>--%>
        <a href="Payment/TSPayment" class="btn btn-primary">More..</a>
    </div>
  </div>
      <% }%>
       <% else{ %>
   <div class="card bg-success">
    <div class="card-body text-center">
      <h3 class="card-title">Payment</h3>
      <p class="card-text">Make a Payment</p>
        <%--<a href="Payment/TSPayment" class="btn btn-primary">Create</a>--%>
        <a href="#" onClick="alert('You are not Authorised!')"  class="btn btn-primary">More..</a>
    </div>
  </div>
        <% }%>

   <% if (IsAdmin == 2)
       { %>
  <div class="card bg-info">
    <div class="card-body text-center">
      <h3 class="card-title">Site Office</h3>
      <p class="card-text">Site Office Document</p>
        <a href="TitleSearch/TitleSearchSO11" class="btn btn-primary">More..</a>
    </div>
     </div>
         <% }%>
       <% else{ %>
        <div class="card bg-info">
    <div class="card-body text-center">
      <h3 class="card-title">Site Office</h3>
      <p class="card-text">Site Office Document</p>
        <a href="#" onClick="alert('You are not Authorised!')"  class="btn btn-primary">More..</a>
    </div>
     </div>
       <% }%>


</div>


    <%--<div class="row">
        <div class="col-md-4">
            <h2>Titles Details</h2>
            <p>
                Total No. of Titles - 1000
                
            </p>
            <p>Total Title Completed - 400</p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Details &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Number of Total Holders</h2>
            <p>
                Total Holder - 300
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Details &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Total Aquistion</h2>
            <p>
                Total Number of Aquistion - 300
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Details &raquo;</a>
            </p>
        </div>
    </div>--%>

</asp:Content>
