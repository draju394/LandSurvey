<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TitleSearchSO11.aspx.cs" Inherits="LandSurvey.TitleSearch.TitleSearchSO11" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
             
        table { 
             border-spacing: 5px;
             border-collapse: separate;
             }
        .auto-style2 {
            height: 30px;
        }
        .auto-style6 {
            height: 30px;
            width: 903px;
        }
        .auto-style7 {
            width: 903px;
        }
        .auto-style8 {
            width: 259px;
        }
        .auto-style9 {
            width: 188px;
            text-align: center;
            height: 38px;
        }
        .auto-style11 {
            width: 197px;
            text-align: center;
            height: 38px;
        }
        .auto-style12 {
            width: 212px;
            text-align: center;
        }
        .auto-style13 {
            width: 212px;
            text-align: center;
            height: 38px;
        }
        .auto-style14 {
            width: 188px;
            text-align: center;
        }
        .auto-style15 {
            width: 266px;
            text-align: center;
        }
        .auto-style16 {
            width: 266px;
            text-align: center;
            height: 38px;
        }
        .auto-style17 {
            width: 197px;
            text-align: center;
        }
        .auto-style19 {
            width: 103px;
        }
        .auto-style21 {
            width: 197px;
        }
        .auto-style24 {
            width: 123px;
        }
        .Background
        {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
        .Popup
        {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 400px;
            height: 350px;
        }
        .lbl
        {
            font-size:16px;
            font-style:italic;
            font-weight:bold;
        }

        .modal-dialog {
                   width: 900px;
                   height:800px !important;
                  
                 }
         .modal-content {
             /* 80% of window height */
            height: 60%;
            background-color:#BBD6EC;
            overflow:auto;
        }       
 
        .modal-header {
            background-color: peru;
            padding:16px 16px;
            color:#FFF;
            border-bottom:2px dashed #337AB7;
         }
        .modal-body {
            margin: 20px 0;
            min-height:300px;
            /*overflow-y: scroll;*/
        }
        .auto-style28 {
            width: 188px;
            text-align: center;
            height: 22px;
        }
        .auto-style29 {
            width: 266px;
            text-align: center;
            height: 22px;
        }
        .auto-style30 {
            width: 197px;
            text-align: center;
            height: 22px;
        }
        .auto-style31 {
            width: 212px;
            text-align: center;
            height: 22px;
        }
        .auto-style32 {
            width: 253px;
            text-align: center;
        }
        .auto-style33 {
            width: 136px;
            text-align: center;
        }
        .auto-style34 {
            width: 130px;
        }
        .auto-style35 {
            width: 114px;
        }
    </style>
    <asp:Panel ID="Panel1" runat="server" Height="100%" Width="949px">
        <%--<asp:ScriptManager ID="ScriptManager1" runat="server"> </asp:ScriptManager>--%>
       <%-- <asp:Button ID="Button1" runat="server" Text="Fill Form in Popup" />--%>
        <%-- For Check List ajax Page --%>
        <%--<cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="btnFRTemplate"
            CancelControlID="Button2" BackgroundCssClass="Background">
        </cc1:ModalPopupExtender>
        
        <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" style = "display:none">
            <iframe style=" width: 500px; height: 300px;" id="irm1" src="CheckList.aspx" runat="server"></iframe>
            <br/>
            <asp:Button ID="Button2" runat="server" Text="Close" />
            <asp:Button ID="Button3" runat="server" Text="Save" />
        </asp:Panel>
        <%-- End For Check List ajax Page  --%>

        <table style="width:100%;">
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style6">
                    <asp:Label ID="Label6" runat="server" Text="Title Search Site Office" Font-Bold="True" Font-Size="Medium"></asp:Label>
                </td>
                <td class="auto-style2"></td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style7">
                    <table style="width:100%;">
                        <tr>
                            <td class="auto-style24">
                                <asp:Label ID="Label3" runat="server" Text="Village Name :"></asp:Label>
                            </td>
                            <td class="auto-style21">
                                <asp:DropDownList ID="cmbVillage" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbVillage_SelectedIndexChanged" Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td class="auto-style34">
                                <asp:Label ID="Label5" runat="server" Text="Document No. :"></asp:Label>
                            </td>
                            <td class="auto-style19">
                                <asp:DropDownList ID="cmbFamilyDocNo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbFamilyDocNo_SelectedIndexChanged" Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td class="auto-style35">
                                <asp:Label ID="Label9" runat="server" Text="Status :" Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblStatus" runat="server" Text="Status" Visible="False"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style7">
                    <asp:GridView ID="grdHolderName" runat="server" Width="899px" AutoGenerateColumns=false BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" PageSize="5"  HorizontalAlign="Left" ShowHeaderWhenEmpty="True" AllowPaging="True" OnPageIndexChanging="grdHolderName_PageIndexChanging1" OnSelectedIndexChanged="grdHolderName_SelectedIndexChanged" AutoGenerateSelectButton="True">
                                     <Columns>
                                    <asp:BoundField DataField="srno" HeaderText="Sr. No."  />    
                                    <asp:BoundField DataField="surveyno" HeaderText="Survey No." /> 
                                    <asp:BoundField DataField="surveyarea" HeaderText="Survey Area" />  
                                    <asp:BoundField DataField="holdername" HeaderText="Holder Name" />
                                    <asp:BoundField DataField="holderarea" HeaderText="Holder Area" />
                                     <asp:BoundField DataField="areaaquired" HeaderText="Aquired Area" />

                                    </Columns>
                                    
                                    <EmptyDataTemplate>No Record Available</EmptyDataTemplate>  
                                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                        <SelectedRowStyle BackColor="Peru" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                        <SortedDescendingHeaderStyle BackColor="#242121" />
                                </asp:GridView>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style7">
                    <table style="width:100%;">
                        <tr>
                            <td>
                                <asp:Button ID="btnViewMutation" runat="server" AutoPostBack="true" BackColor="#993333" CssClass="btn btn-primary" Text="View Mutation Report" Width="169px" xmlns:asp="#unknown" OnClick="btnViewMutation_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnView712" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="View 7/12" Width="169px" xmlns:asp="#unknown" OnClick="btnView712_Click" OnClientClick= "aspnetForm.target = '_blank';" />
                            </td>
                            <td>
                                <asp:Button ID="btnView8A" runat="server" AutoPostBack="true" BackColor="#009933" CssClass="btn btn-primary" Text="View 8A" Width="169px" xmlns:asp="#unknown" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style7">
                    <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#993333" Text="Check List "></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style7">
                    <table style="width:100%;">
                        <tr>
                            <td class="text-center" colspan="4">
                                <asp:GridView ID="grdCheckList" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3"  HorizontalAlign="Left" OnPageIndexChanging="grdCheckList_PageIndexChanging" OnRowCancelingEdit="grdCheckList_RowCancelingEdit" OnRowEditing="grdCheckList_RowEditing" OnRowUpdating="grdCheckList_RowUpdating" PageSize="5" ShowHeaderWhenEmpty="True" Width="887px">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btn_EditChkList" runat="server" CommandName="Edit" Text="Edit" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Button ID="btn_UpdateChkList" runat="server" CommandName="Update" Text="Update" />
                                                <asp:Button ID="btn_CancelChkList" runat="server" CommandName="Cancel" Text="Cancel" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_IDChKList" runat="server" Text='<%#Eval("chklistno") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sr. No">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_SrNo0" runat="server" Text='<%#Eval("srno") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Documents / Findings">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_ChkListName" runat="server" Text='<%#Eval("chkname") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Site Office Remark">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_SiteOfficeRemark" runat="server" Text='<%#Eval("siteofficereamrk") %>'></asp:Label>
                                                <%--<asp:Label ID="lbl_SiteOfficeRemark" runat="server" Text=''></asp:Label>--%>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txt_SiteOfficeRemark" runat="server" Text='' BorderStyle="Solid"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Head Office Remark">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_HeadOfficeRemark" runat="server" Text='<%#Eval("headofficeremark") %>'></asp:Label>
                                                <%--<asp:Label ID="lbl_HeadOfficeRemark" runat="server" Text=''></asp:Label>--%>
                                            </ItemTemplate>
                                            <%--<EditItemTemplate>
                                                <asp:TextBox ID="txt_HORemark" runat="server" Text='<%#Eval("headofficeremark") %>'></asp:TextBox>
                                            </EditItemTemplate>--%>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Record Available
                                    </EmptyDataTemplate>
                                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                                    <SortedAscendingCellStyle BackColor="#F4F4FD" />
                                    <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                                    <SortedDescendingCellStyle BackColor="#D8D8F0" />
                                    <SortedDescendingHeaderStyle BackColor="#3E3277" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style28">
                                </td>
                            <td class="auto-style29"></td>
                            <td class="auto-style30">
                            </td>
                            <td class="auto-style31">
                                <asp:DropDownList ID="cmbDocumentNo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbDocumentNo_SelectedIndexChanged" Visible="False" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style14">
                                <asp:Label ID="lblMRFileUploaded0" runat="server" Font-Bold="True" Text="Upload File"></asp:Label>
                            </td>
                            <td class="auto-style15">
                                <asp:Label ID="lblMRFileUploaded1" runat="server" Font-Bold="True" Text="Select File to upload"></asp:Label>
                            </td>
                            <td class="auto-style17">
                                <asp:Label ID="lblMRFileUploaded2" runat="server" Font-Bold="True" Text="File Uploaded"></asp:Label>
                            </td>
                            <td class="auto-style12">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style14">
                                <asp:Button ID="btnFamilyHistory" runat="server" AutoPostBack="true" CssClass="btn btn-primary" OnClick="btnFamilyHistory_Click" Text="Family Tree" Width="169px" xmlns:asp="#unknown" />
                            </td>
                            <td class="auto-style15">
                                <asp:FileUpload ID="FileUploadControl" runat="server" Height="28px" Width="208px" />
                            </td>
                            <td class="auto-style17">
                                <asp:LinkButton ID="lbllinkFT" runat="server" OnClick="lbllinkMR_Click"></asp:LinkButton>
                            </td>
                            <td class="auto-style12">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style9">
                                <asp:Button ID="btnConcentLetter" runat="server" CssClass="btn btn-primary" OnClick="btnConcentLetter_Click" Text="Concent Letter" Width="169px" />
                            </td>
                            <td class="auto-style16">
                                <asp:FileUpload ID="FileUploadControlDR" runat="server" Height="28px" Width="209px" />
                            </td>
                            <td class="auto-style11">
                                <asp:LinkButton ID="lblLinkCL" runat="server" OnClick="lblLinkDrFile_Click"></asp:LinkButton>
                            </td>
                            <td class="auto-style13">
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style9">
                                <asp:Button ID="btnLocalNotice" runat="server" CssClass="btn btn-primary" Text="Local Notice" Width="169px" OnClick="btnLocalNotice_Click" />
                            </td>
                            <td class="auto-style16">
                                <asp:FileUpload ID="FileUploadControlPN" runat="server" Height="28px" Width="209px" />
                            </td>
                            <td class="auto-style11">
                                <asp:LinkButton ID="lblLinkLN" runat="server" OnClick="lblLinkPR_Click"></asp:LinkButton>
                            </td>
                            <td class="auto-style13">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style14">
                                <asp:Button ID="btnLocalEnquiry" runat="server" CssClass="btn btn-primary" Text="Local Enquiry" Width="169px" OnClick="btnLocalEnquiry_Click" />
                            </td>
                            <td class="auto-style15">
                                <asp:FileUpload ID="FileUploadControlFR" runat="server" Height="28px" Width="209px" />
                            </td>
                            <td class="auto-style17">
                                <asp:LinkButton ID="lblLinkLE" runat="server" OnClick="lblLinkFR_Click"></asp:LinkButton>
                            </td>
                            <td class="auto-style12">
                            </td>
                        </tr>
                    </table>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style7">
                    
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style7">
                    <table style="width:100%;">
                        <tr>
                            <td class="auto-style8">&nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style8">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style8">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <%-- Check List Modal --%>

        <div class="modal" data-keyboard="false" data-backdrop="static" id="CheckListModal" tabindex="-1" role="dialog">
            <div class="modal-dialog model-max" role="document">
                <div class="modal-content model-max">
                    <div class="modal-header">
                        <button class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h5 class="modal-title" style="color: #333333;">Check List</h5>
                    </div>
                    <div class="modal-body">
                        <%--<asp:GridView ID="grdCheckList" runat="server"></asp:GridView>--%>  
                        <div class="container">  
        <h1>Bootstrap Table With Striped Rows</h1>  
        <!--Bootstrap Table using .table-striped class-->  
        <table class="table table-striped" style="width:100px">  
            <thead>  
                <tr>  
                    <th style="width:10px">Sr.No.</th>  
                    <th style="width:10px">Emolpyee Name</th>  
                    <th style="width:10px">Email</th>  
                    <th style="width:10px">City</th>  
                </tr>  
            </thead>  
            <tbody>  
                <tr>  
                    <td>1</td>  
                    <td>Shaili Dashora</td>  
                    <td>abc@mail.com </td>  
                    <td>Chittorgarh</td>  
                </tr>  
                <tr>  
                    <td>2</td>  
                    <td>Sourabh Somani</td>  
                    <td>xyz@mail.com </td>  
                    <td>Banglore</td>  
                </tr>  
                <tr>  
                    <td>3</td>  
                    <td>Shobhna Singvi</td>  
                    <td>pqr@mail.com</td>  
                    <td>Mumbai</td>  
                </tr>  
            </tbody>  
        </table>  
    </div>  
                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-primary">Save</button>
                        <button class="btn btn-primary" data-dismiss="modal">Close</button>

                    </div>

                </div>

            </div>

        </div>

    </asp:Panel>
</asp:Content>
