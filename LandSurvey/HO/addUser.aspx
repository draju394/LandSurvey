<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addUser.aspx.cs" Inherits="LandSurvey.HO.addUser" EnableEventValidation = "false" %>
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
        border-color: saddlebrown !important;
        }
    </style>
 

     <%-- Page Coading --%>
     <div class="row" style="background-color:#f1c371;height:35px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
            <div class="col-md-8">
                <label for="" style="color:saddlebrown;font-size: 18px;">Add User </label>
                <label for="" style="color: white;font-size: 18px;" id="PopulationID"></label>
            </div>
            <div class="col-md-2">
                 <asp:TextBox ID="txtDocNo" runat="server" Visible="False"></asp:TextBox>
            </div>
            <div class="col-md-2">
            </div>
     </div>
    <br />

    <div class="row">
        <label for="firstName" class="col-sm-1 control-label">First Name:</label>
        <div class="form-group col-sm-3">
            <asp:TextBox ID="firstName" runat="server" CssClass="form-control input-sm" ></asp:TextBox>
            <%--<input type="text" class="form-control" id="firstName" required="" 
               oninvalid="this.setCustomValidity('Please Enter User First Name')"
                oninput="setCustomValidity('')" /> --%>
        </div>
        <label for="middleName" class="col-sm-1 control-label">Middle Name:</label>
        <div class="form-group col-sm-3">
            <asp:TextBox ID="middleName" runat="server" CssClass="form-control input-sm" ></asp:TextBox>
            <%--<input type="text" class="form-control" id="middleName" />--%>
        </div>
        <label for="lastName" class="col-sm-1 control-label">Last Name:</label>
        <div class="form-group col-sm-3">
            <asp:TextBox ID="lastName" runat="server" CssClass="form-control input-sm" ></asp:TextBox>
            <%--<input type="text" class="form-control" id="lastName" required="" 
                oninvalid="this.setCustomValidity('Please Enter User Last Name')"
                oninput="setCustomValidity('')" />--%>
        </div> 
    </div>

    <div class="row">
        <label for="address" class="col-sm-1 control-label">Address:</label>
        <div class="form-group col-sm-3">
            <asp:TextBox ID="address" runat="server" CssClass="form-control input-sm" ></asp:TextBox>
            <%--<input type="text" class="form-control" id="address" />--%>
        </div>
        <label for="city" class="col-sm-1 control-label">City:</label>
        <div class="form-group col-sm-3">
            <asp:TextBox ID="city" runat="server" CssClass="form-control input-sm" ></asp:TextBox>
            <%--<input type="text" class="form-control" id="city"  required="" 
             oninvalid="this.setCustomValidity('Please Enter User City Name')"
                oninput="setCustomValidity('')"   />--%>
        </div>
        <label for="email" class="col-sm-1 control-label">Email:</label>
        <div class="form-group col-sm-3">
            <asp:TextBox ID="email" runat="server" CssClass="form-control input-sm" ></asp:TextBox>
           <%-- <input type="text" class="form-control" id="email" required=""
                oninvalid="this.setCustomValidity('Please Enter User Email ID')"
                oninput="setCustomValidity('')"/>--%>
        </div> 
    </div>

     <div class="row">
        <label for="username1" class="col-sm-1 control-label">User Name:</label>
        <div class="form-group col-sm-3">
            <asp:TextBox ID="username1" runat="server" CssClass="form-control input-sm" ></asp:TextBox>
           <%-- <input type="text" class="form-control" id="username" runat="server" required="" 
                oninvalid="this.setCustomValidity('Please Enter User Login Name')"
                oninput="setCustomValidity('')"/>--%>
        </div>
        <label for="password" class="col-sm-1 control-label">Password:</label>
        <div class="form-group col-sm-3">
             <asp:TextBox ID="password" runat="server" CssClass="form-control input-sm" ></asp:TextBox>
           <%-- <input type="password" class="form-control" id="password" required
                oninvalid="this.setCustomValidity('Please Enter User Login Password')"
                oninput="setCustomValidity('')" />--%>
        </div>
        <label for="cpassword" class="col-sm-1 control-label">Confirm Password:</label>
        <div class="form-group col-sm-3">
                <asp:TextBox ID="cpassword" runat="server" CssClass="form-control input-sm" ></asp:TextBox>
            <%--<input type="password" class="form-control" id="cpassword" required="" 
                oninvalid="this.setCustomValidity('Please Enter User Confirm Password')"
                oninput="setCustomValidity('')"/>--%>
        </div> 
    </div>

      <div class="row">
        <label for="cmbuserrole" class="col-sm-1 control-label">User Role:</label>
        <div class="form-group col-sm-3">
            <asp:DropDownList ID="cmbuserrole" runat="server" CssClass="form-control">
                                    <asp:ListItem>Head Office</asp:ListItem>
                                    <asp:ListItem>Site Office One</asp:ListItem>
                                    <asp:ListItem>Site Office Two</asp:ListItem>
                                    <asp:ListItem>Solicitor</asp:ListItem>
                                    <asp:ListItem>Client</asp:ListItem>
                                    <asp:ListItem>Finance</asp:ListItem>
                </asp:DropDownList>
                                   
        </div>
        <label for="cmbuserstatus" class="col-sm-1 control-label">User Status:</label>
        <div class="form-group col-sm-3">
             <asp:DropDownList ID="cmbuserstatus" runat="server" CssClass="form-control">
                                    <asp:ListItem>Active</asp:ListItem>
                                    <asp:ListItem>InActive</asp:ListItem>
                                    
                </asp:DropDownList>
        </div>
        <label for="mobileno" class="col-sm-1 control-label">Mobile No.:</label>
        <div class="form-group col-sm-3">
            <asp:TextBox ID="mobileno" runat="server" CssClass="form-control input-sm" TextMode="Number" MaxLength="10" ></asp:TextBox>
           <%-- <input type="number" class="form-control" id="mobileno"  required=""
                oninvalid="this.setCustomValidity('Please Enter User Mobile Numnber')"
                oninput="setCustomValidity('')"/>--%>
        </div> 
    </div>

    <br />
      <div class="upload" style="background-color:#f1c371;height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
       <div class="col-md-4" >
            <asp:Button ID="btnSave" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Save User" Width="270px" xmlns:asp="#unknown" OnClick="btnSave_Click" OnClientClick ="javascript:return Validate()" />
       </div> 
              
        <div class="col-md-4" >
            <asp:Button ID="btnCancel" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Cancel" Width="270px" xmlns:asp="#unknown" />
       </div> 
      <%--<div class="col-lg-5" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px; >Generated Public Notice:</label>
          <asp:LinkButton ID="lbllinkPN" runat="server" OnClick="lbllinkPN_Click"  Visible="false">File Not Found</asp:LinkButton>

      </div>--%>
     </div>

    <script type="text/javascript">
        function Validate() {
            var FirstName = document.getElementById('firstName');
            var LastName = document.getElementById('lastname');
            var UserName = document.getElementById('username');
            //if (document.getElementById('password') != document.getElementById('cpassword'))
            //{
            //    alert('Pasword and Confirm Password are not same');
            //    return false;
            //}
            if (document.getElementById("<%=firstName.ClientID%>").value=="")
            {
                 alert("Please Enter First Name");
                 document.getElementById("<%=firstName.ClientID%>").focus();
                 return false;
            }

             if (document.getElementById("<%=lastName.ClientID%>").value=="")
            {
                 alert("Please Enter Last Name");
                 document.getElementById("<%=lastName.ClientID%>").focus();
                 return false;
            }
            

            return true;

            //if (FirstName.value == '') {
            //    alert('please enter User First Name');
            //    return false;
            //}
            //if (LastName.value == '')
            //{
            //     alert('please enter User Last Name');
            //    return false;
            //}
            // if (UserName.value == '')
            //{
            //     alert('please enter User Name');
            //    return false;
            //}

            //else
            //{
            //    return confirm('Do you want to continue')
            //}
        }
    </script>

</asp:Content>
