<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SolicitorApprovalNew.aspx.cs" Inherits="LandSurvey.Solicitor.SolicitorApprovalNew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
         .btn-primary, .btn-primary:hover, .btn-primary:active, .btn-primary:visited
        {
        background-color: saddlebrown !important;
        border-color: saddlebrown !important;
        }
    </style>
    <div class="row" style="background-color:#f1c371;height:35px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
            <div class="col-md-4">
                <label for="" style="color:saddlebrown;font-size: 18px;">Solicitor - Approve Document</label>
            </div>
            <div class="col-md-4">
                <label for="" style="color:saddlebrown;font-size: 18px;">Village Name:</label>
                 <asp:Label  id="lblVillageCode" runat="server" style="color:white;font-size: 18px;"></asp:Label>
                  <%--<asp:Label  id="lblVillageCodeHidden" runat="server" style="color:white;font-size: 18px;" Visible="False"></asp:Label>--%>
            </div>
            <div class="col-md-4">
                <label for="" style="color:saddlebrown;font-size: 18px;">Document Number:</label>
                 <asp:Label  id="LblDocNo" runat="server" style="color:white;font-size: 18px;"></asp:Label>
            </div>
   </div>
    <br />
    <%-- Primary Title Search Start --%>
     <div class="upload" style="background-color:#f1c371;height:35px;padding-top: 2px; border-radius: 5px 5px 5px 5px;">
        <div class="col-md-3" >
            <label for="" style="color:white;font-size: 14;padding-top: 5px">Primary Title Search Document (PTS)</label>
           <%--<asp:Button ID="btnVisarPavti" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Primary Title Search Document" Width="270px" xmlns:asp="#unknown"  />--%>
        </div> 
      
      <div class="col-lg-4" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Uploaded PTS:</label>
          <asp:LinkButton ID="lbllinkPTS" runat="server" OnClick="lbllinkPTS_Click">File Not Uploaded</asp:LinkButton>
      </div>
          <div class="col-lg-4" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Clarification Document of PTS From HO:</label>
          <asp:LinkButton ID="lbllinkCPTS" runat="server">File Not Uploaded</asp:LinkButton>
      </div>
   </div>

     <div class="upload" style="height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
        <div class="col-lg-3" >
           <asp:Button ID="btnUploadPTSQuery" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Upload PTS Queris" Width="150px" xmlns:asp="#unknown" OnClick="btnUploadPTSQuery_Click"  />
        </div> 
        <div class="col-lg-3" style="padding-top:5px">
          <asp:FileUpload ID="FileUploadPTS" runat="server" Height="30px" Width="200px" />
        </div>
      <div class="col-lg-3" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Uploaded PTS Queries:</label>
          <asp:LinkButton ID="lblLinkPTSQueries" runat="server" OnClick="lblLinkPTSQueries_Click">File Not Uploaded</asp:LinkButton>
      </div>
          <%--<div class="col-lg-3" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Approve:</label>
          <asp:RadioButtonList ID="rblApproval1" RepeatDirection="Horizontal" Enabled='<%# Eval("iterationno").ToString() == "2" ? true : false %>' ToolTip='<%# Eval("check")%>' Visible='<%# Eval("check").ToString() == "approval" ? true : false %>' runat="server">
                                <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                            </asp:RadioButtonList>
          </div>--%>
   </div>

     <%-- PTS REMARK  --%>
    <div class="upload" style="height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
                
         <div class="col-lg-3" style="padding-top:0px" >
             <label for="" style="color:saddlebrown;font-size: 12px;">Remark:</label>
         </div>

          <div class="col-lg-8" style="padding-top:0px" >
         <asp:TextBox ID="txtPTSRemark" runat="server" CssClass="form-control input-sm"></asp:TextBox>
      </div>

   </div>

     <div class="upload" style="height:45px;padding-top: 0px; border-radius: 5px 5px 5px 5px;">
        <div class="col-lg-3" >
           <asp:Button ID="btnApprovePTS" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Approve PTS" Width="150px" xmlns:asp="#unknown" OnClick="btnApprovePTS_Click"  />
        </div> 
        
         <div class="col-lg-3" style="padding-top:0px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Approve:</label>
             </div>
     
          <div class="col-lg-3" style="padding-top:0px" >
<%--          <label for="" style="color:saddlebrown;font-size: 12px;">Approve:</label>--%>
          <asp:RadioButtonList ID="rdButtonPTSApprove" RepeatDirection="Horizontal" Enabled='<%# Eval("iterationno").ToString() == "2" ? true : false %>' ToolTip='<%# Eval("check")%>' Visible='<%# Eval("check").ToString() == "approval" ? true : false %>' runat="server">
                                <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                            </asp:RadioButtonList>
          </div>

          <div class="col-lg-3" style="padding-top:0px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Approved On:</label>
           <asp:label id="lblApproveDatePTS" runat="server" style="color:saddlebrown;font-size: 12px;"></asp:label>
      </div>

   </div>
   
    <%-- End Primary Title Search --%>

        
    <%-- Final Title Search Start --%>
     <div class="upload" style="background-color:#f1c371;height:35px;padding-top: 0px; border-radius: 5px 5px 5px 5px;">
        <div class="col-md-3" >
            <label for="" style="color:white;font-size: 14;padding-top: 5px">Final Title Search Document (FTS)</label>
           <%--<asp:Button ID="btnVisarPavti" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Primary Title Search Document" Width="270px" xmlns:asp="#unknown"  />--%>
        </div> 
      
      <div class="col-lg-4" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Uploaded FTS:</label>
          <asp:LinkButton ID="lblLinkFTS" runat="server" OnClick="lblLinkFTS_Click">File Not Uploaded</asp:LinkButton>
      </div>
          <div class="col-lg-4" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Clarification Document of FTS From HO:</label>
          <asp:LinkButton ID="lblLinkCFTS" runat="server">File Not Uploaded</asp:LinkButton>
      </div>
   </div>

     <div class="upload" style="height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
        <div class="col-lg-3" >
           <asp:Button ID="btnUploadFTSQueries" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Upload FTS Queris" Width="150px" xmlns:asp="#unknown" OnClick="btnUploadFTSQueries_Click"  />
        </div> 
        <div class="col-lg-3" style="padding-top:5px">
          <asp:FileUpload ID="FileUploadFTS" runat="server" Height="30px" Width="200px" />
        </div>
      <div class="col-lg-3" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Uploaded FTS Queries:</label>
          <asp:LinkButton ID="lblLinkFTSQueries" runat="server" OnClick="lblLinkFTSQueries_Click">File Not Uploaded</asp:LinkButton>
      </div>
       
       
   </div>

     <%-- FTS REMARK  --%>
    <div class="upload" style="height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
                
         <div class="col-lg-3" style="padding-top:0px" >
             <label for="" style="color:saddlebrown;font-size: 12px;">Remark:</label>
         </div>

          <div class="col-lg-8" style="padding-top:0px" >
         <asp:TextBox ID="txtFTSRemark" runat="server" CssClass="form-control input-sm"></asp:TextBox>
      </div>

   </div>

     <div class="upload" style="height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
        <div class="col-lg-3" >
           <asp:Button ID="btnApproveFTS" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Approve FTS" Width="150px" xmlns:asp="#unknown" OnClick="btnApproveFTS_Click"  />
        </div> 
        
         <div class="col-lg-3" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Approve:</label>
             </div>
     
          <div class="col-lg-3" style="padding-top:5px" >
<%--          <label for="" style="color:saddlebrown;font-size: 12px;">Approve:</label>--%>
          <asp:RadioButtonList ID="rdButtonFTSApprov" RepeatDirection="Horizontal" Enabled='<%# Eval("iterationno").ToString() == "2" ? true : false %>' ToolTip='<%# Eval("check")%>' Visible='<%# Eval("check").ToString() == "approval" ? true : false %>' runat="server">
                                <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                            </asp:RadioButtonList>
          </div>

          <div class="col-lg-3" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Approved On:</label>
           <%--<label id="ApproveDateFTS" style="color:saddlebrown;font-size: 12px;"></label>--%>
          <asp:label id="lblApproveDateFTS" runat="server" style="color:saddlebrown;font-size: 12px;"></asp:label>
      </div>
   </div>
    <%-- End Final Title Search --%>

    <%-- Start Public Notice --%>

    <div class="upload" style="background-color:#f1c371;height:35px;padding-top: 0px; border-radius: 5px 5px 5px 5px;">
        <div class="col-md-3" >
            <label for="" style="color:white;font-size: 14;padding-top: 5px">Public Notice Document (PN)</label>
        </div> 
      
      <div class="col-lg-4" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Uploaded PN:</label>
          <asp:LinkButton ID="lblLinkPN" runat="server" OnClick="lblLinkPN_Click">File Not Uploaded</asp:LinkButton>
      </div>
          <div class="col-lg-5" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Clarification Document of PN From HO:</label>
          <asp:LinkButton ID="lblLinkCPN" runat="server" OnClick="lblLinkCPN_Click">File Not Uploaded</asp:LinkButton>
      </div>
   </div>

     <div class="upload" style="height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
        <div class="col-lg-3" >
           <asp:Button ID="btnUploadPNQueries" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Upload PN Queris" Width="150px" xmlns:asp="#unknown" OnClick="btnUploadPNQueries_Click" />
        </div> 
        <div class="col-lg-3" style="padding-top:5px">
          <asp:FileUpload ID="FileUploadPN" runat="server" Height="30px" Width="200px" />
        </div>
      <div class="col-lg-3" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Uploaded PN Queries:</label>
          <asp:LinkButton ID="lblLinkPNQueries" runat="server" OnClick="lblLinkPNQueries_Click">File Not Uploaded</asp:LinkButton>
      </div>
       
       
   </div>

     <%-- PN REMARK  --%>
    <div class="upload" style="height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
                
         <div class="col-lg-3" style="padding-top:0px" >
             <label for="" style="color:saddlebrown;font-size: 12px;">Remark:</label>
         </div>

          <div class="col-lg-8" style="padding-top:0px" >
         <asp:TextBox ID="txtPNRemark" runat="server" CssClass="form-control input-sm"></asp:TextBox>
      </div>

   </div>

     <div class="upload" style="height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
        <div class="col-lg-3" >
           <asp:Button ID="btnApprovePN" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Approve PN" Width="150px" xmlns:asp="#unknown" OnClick="btnApprovePN_Click" />
        </div> 
        
         <div class="col-lg-3" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Approve:</label>
             </div>
     
          <div class="col-lg-3" style="padding-top:5px" >
<%--          <label for="" style="color:saddlebrown;font-size: 12px;">Approve:</label>--%>
          <asp:RadioButtonList ID="rdButtonApprovePN" RepeatDirection="Horizontal" Enabled='<%# Eval("iterationno").ToString() == "2" ? true : false %>' ToolTip='<%# Eval("check")%>' Visible='<%# Eval("check").ToString() == "approval" ? true : false %>' runat="server">
                                <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                            </asp:RadioButtonList>
          </div>

          <div class="col-lg-3" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Approved On:</label>
          <asp:label id="lblApprovDatePN" runat="server" style="color:saddlebrown;font-size: 12px;"></asp:label>
      </div>
   </div>

    <%-- End Public Notice --%>
    
    <%-- Start ATS --%>

     <div class="upload" style="background-color:#f1c371;height:35px;padding-top: 0px; border-radius: 5px 5px 5px 5px;">
        <div class="col-md-3" >
            <label for="" style="color:white;font-size: 14;padding-top: 5px">Agreement to Sale (ATS)</label>
        </div> 
      
      <div class="col-lg-4" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Uploaded ATS:</label>
          <asp:LinkButton ID="lblLinkATS" runat="server" OnClick="lblLinkATS_Click" >File Not Uploaded</asp:LinkButton>
      </div>
          <%--<div class="col-lg-5" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Clarification Document of PN From HO:</label>
          <asp:LinkButton ID="LinkButton2" runat="server" OnClick="lblLinkCPN_Click">File Not Uploaded</asp:LinkButton>
      </div>--%>
   </div>

     <div class="upload" style="height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
        <div class="col-lg-3" >
           <asp:Button ID="btnUploadATSQuerie" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Upload ATS Queris" Width="150px" xmlns:asp="#unknown" OnClick="btnUploadATSQuerie_Click" />
        </div> 
        <div class="col-lg-3" style="padding-top:5px">
          <asp:FileUpload ID="FileUploadATS" runat="server" Height="30px" Width="200px" />
        </div>
      <div class="col-lg-3" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Uploaded ATS Queries:</label>
          <asp:LinkButton ID="lblLinkATSQueries" runat="server" OnClick="lblLinkATSQueries_Click" >File Not Uploaded</asp:LinkButton>
      </div>
   </div>
 
    <div class="upload" style="height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
         <div class="col-lg-3" style="padding-top:0px" >
             <label for="" style="color:saddlebrown;font-size: 12px;">Remark:</label>
         </div>

          <div class="col-lg-8" style="padding-top:0px" >
              <asp:TextBox ID="txtATSRemark" runat="server" CssClass="form-control input-sm"></asp:TextBox>
          </div>

   </div>

     <div class="upload" style="height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
        <div class="col-lg-3" >
           <asp:Button ID="btnApproveATS" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Approve ATS" Width="150px" xmlns:asp="#unknown" OnClick="btnApproveATS_Click" />
        </div> 
        
         <div class="col-lg-3" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Approve:</label>
             </div>
     
          <div class="col-lg-3" style="padding-top:5px" >
<%--          <label for="" style="color:saddlebrown;font-size: 12px;">Approve:</label>--%>
          <asp:RadioButtonList ID="rdButtonApproveATS" RepeatDirection="Horizontal" Enabled='<%# Eval("iterationno").ToString() == "2" ? true : false %>' ToolTip='<%# Eval("check")%>' Visible='<%# Eval("check").ToString() == "approval" ? true : false %>' runat="server">
                                <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                            </asp:RadioButtonList>
          </div>

          <div class="col-lg-3" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Approved On:</label>
          <asp:label id="lblApproveATSDate" runat="server" style="color:saddlebrown;font-size: 12px;"></asp:label>
      </div>
   </div>

    <%-- End ATS --%>
    
    <%-- Start Sale Deed --%>

    <div class="upload" style="background-color:#f1c371;height:35px;padding-top: 0px; border-radius: 5px 5px 5px 5px;">
        <div class="col-md-3" >
            <label for="" style="color:white;font-size: 14;padding-top: 5px">Sale Deed (SD)</label>
        </div> 
      
      <div class="col-lg-4" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Uploaded SD:</label>
          <asp:LinkButton ID="lblLinkSD" runat="server" OnClick="lblLinkSD_Click">File Not Uploaded</asp:LinkButton>
      </div>
          <%--<div class="col-lg-5" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Clarification Document of PN From HO:</label>
          <asp:LinkButton ID="LinkButton2" runat="server" OnClick="lblLinkCPN_Click">File Not Uploaded</asp:LinkButton>
      </div>--%>
   </div>

     <div class="upload" style="height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
        <div class="col-lg-3" >
           <asp:Button ID="btnUploadSDQueries" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Upload SD Queris" Width="150px" xmlns:asp="#unknown" OnClick="btnUploadSDQueries_Click" />
        </div> 
        <div class="col-lg-3" style="padding-top:5px">
          <asp:FileUpload ID="FileUploadSD" runat="server" Height="30px" Width="200px" />
        </div>
      <div class="col-lg-3" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Uploaded SD Queries:</label>
          <asp:LinkButton ID="lblLinkUploadSDQueries" runat="server" OnClick="lblLinkUploadSDQueries_Click" >File Not Uploaded</asp:LinkButton>
      </div>
   </div>
 
    <div class="upload" style="height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
         <div class="col-lg-3" style="padding-top:0px" >
             <label for="" style="color:saddlebrown;font-size: 12px;">Remark:</label>
         </div>

          <div class="col-lg-8" style="padding-top:0px" >
              <asp:TextBox ID="txtSDRemark" runat="server" CssClass="form-control input-sm"></asp:TextBox>
          </div>

   </div>

     <div class="upload" style="height:45px;padding-top: 5px; border-radius: 5px 5px 5px 5px;">
        <div class="col-lg-3" >
           <asp:Button ID="btnApproveSD" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Approve SD" Width="150px" xmlns:asp="#unknown" OnClick="btnApproveSD_Click" />
        </div> 
        
         <div class="col-lg-3" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Approve:</label>
             </div>
     
          <div class="col-lg-3" style="padding-top:5px" >
<%--          <label for="" style="color:saddlebrown;font-size: 12px;">Approve:</label>--%>
          <asp:RadioButtonList ID="rdButtonApproveSD" RepeatDirection="Horizontal" Enabled='<%# Eval("iterationno").ToString() == "2" ? true : false %>' ToolTip='<%# Eval("check")%>' Visible='<%# Eval("check").ToString() == "approval" ? true : false %>' runat="server">
                                <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                            </asp:RadioButtonList>
          </div>

          <div class="col-lg-3" style="padding-top:5px" >
          <label for="" style="color:saddlebrown;font-size: 12px;">Approved On:</label>
          <asp:label id="lblApproveSDDate" runat="server" style="color:saddlebrown;font-size: 12px;"></asp:label>
      </div>
   </div>

    <%-- End Sale Deed --%>
    <br />
    <%-- Head Office Approval --%>
      <div class="upload" style="background-color:#f1c371;height:35px;padding-top: 0px; border-radius: 5px 5px 5px 5px;">
        <div class="col-lg-8" >
           <asp:Button ID="btnHOApproval" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Send Approval to Head Office" Width="200px" xmlns:asp="#unknown" OnClick="btnHOApproval_Click" />
        </div> 
          </div>
    <br />
    <br />
    


</asp:Content>
