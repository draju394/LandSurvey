<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmTest.aspx.cs" Inherits="LandSurvey.TitleSearch.frmTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <script src="../Scripts/jquery.validate.min.js"></script>
    <script src="../Scripts/ej.web.all.min.js"></script>
    <script src="../Scripts/ej.grid.min.js"></script>
    <script src="../Scripts/ej.unobtrusive.min.js"></script>
    <script src="../Scripts/jquery.validate.unobtrusive.min.js"></script>
    <link href="../Content/ej.widgets.core.min.css" rel="stylesheet" />
    <link href="../Content/ej.web.all.min.css" rel="stylesheet" />

    <ej:Grid ID="Grid1" runat='server' OnServerCommandButtonClick="Grid1_ServerCommandButtonClick">
        <Columns>                                   

           <ej:Column Field="OrderID" HeaderText="Order ID" IsPrimaryKey="true" TextAlign="Right" Width="75" />

           <ej:Column Field="CustomerID" HeaderText="Customer ID" Width="75" />

           <ej:Column Field="EmployeeID" HeaderText="Employee ID" Width="75" />

           <ej:Column HeaderText="Employee Details" TextAlign="Center" Width="150">                    
                    <Command>
                        <ej:Commands Type="detail">
                            <ButtonOptions Text="Details" Width="100" Click="onClick"></ButtonOptions>
                        </ej:Commands>
                       <%-- <ej:Commands Type="edit">
                            <ButtonOptions Text="Edit"></ButtonOptions>
                        </ej:Commands>
                        <ej:Commands Type="delete">
                            <ButtonOptions Text="Delete"></ButtonOptions>
                        </ej:Commands>
                        <ej:Commands Type="save">
                            <ButtonOptions Text="Save"></ButtonOptions>
                        </ej:Commands>
                        <ej:Commands Type="cancel">
                            <ButtonOptions Text="Cancel"></ButtonOptions>
                        </ej:Commands>--%>
                    </Command>
                </ej:Column>                     

       </Columns>

    </ej:Grid>
</asp:Content>
