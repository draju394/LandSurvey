<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TitleSearch11.aspx.cs" Inherits="LandSurvey.TitleSearch.TitleSearch11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--<asp:BoundField DataField="surveyrate" HeaderText="Survey Rate" />--%>
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
    </style>
    <asp:Panel ID="Panel1" runat="server" Height="100%" Width="949px">
       <%-- <div class="container-fluid" style="background-color:peru">Title Search </div>--%>
        <table style="width:100%;">
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style6" colspan="5">
                    <asp:Label ID="Label6" runat="server" Text="New Title Search" Font-Bold="True" Font-Size="Medium"></asp:Label>
                </td>
                <td class="auto-style2"></td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style7" colspan="5">
                    <table style="width:100%;">
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Village Name :"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="cmbVillage" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbVillage_SelectedIndexChanged" Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Family Number :" Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="cmbFamily" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbFamily_SelectedIndexChanged" Width="150px" Visible="False">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text="Document No. :"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="cmbFamilyDocNo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbFamilyDocNo_SelectedIndexChanged" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Survey No. :"></asp:Label>
                            </td>
                            <td>
                                <asp:ListBox ID="lstBoxSurveyNo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lstBoxSurveyNo_SelectedIndexChanged" SelectionMode="Multiple" Width="150px" Height="45px" ></asp:ListBox>
                            </td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="Family Total Area :" Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblFamilyTotArea" runat="server" Text="FamilyTotalArea" Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label12" runat="server" Text="Document Status :" Visible="False"></asp:Label>
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
                <td class="auto-style7" colspan="5">
                    <asp:GridView ID="grdHolderName" runat="server" Width="887px" AutoGenerateColumns=False BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3"  HorizontalAlign="Left" ShowHeaderWhenEmpty="True" OnRowCancelingEdit="grdHolderName_RowCancelingEdit" OnRowEditing="grdHolderName_RowEditing" OnRowUpdating="grdHolderName_RowUpdating" AllowPaging="True" PageSize="5" GridLines="Horizontal" OnPageIndexChanging="grdHolderName_PageIndexChanging1">
                                     <AlternatingRowStyle BackColor="#F7F7F7" />
                                     <Columns>
                                         <asp:TemplateField> 
                                            <ItemTemplate>  
                                                <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" />  
                                            </ItemTemplate>  
                                            <EditItemTemplate>  
                                                <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update"/>  
                                                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/>  
                                            </EditItemTemplate>  
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="ID">  
                                            <ItemTemplate>  
                                                <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("familydetailid") %>'></asp:Label>  
                                            </ItemTemplate>  
                                        </asp:TemplateField>  

                                         <asp:TemplateField HeaderText="Sr. No">  
                                            <ItemTemplate>  
                                                <asp:Label ID="lbl_SrNo" runat="server" Text='<%#Eval("srno") %>'></asp:Label>  
                                            </ItemTemplate>  
                                            <%--<EditItemTemplate>  
                                                <asp:TextBox ID="txt_SrNo" runat="server" Text='<%#Eval("Name") %>'></asp:TextBox>  
                                            </EditItemTemplate> --%> 
                                        </asp:TemplateField> 

                                     <%--   <asp:BoundField DataField="srno" HeaderText="Sr. No." ReadOnly="True" />  --%>   
                                      <asp:TemplateField HeaderText="Holder Name">  
                                            <ItemTemplate>  
                                                <asp:Label ID="lbl_HolderName" runat="server" Text='<%#Eval("holdername") %>'></asp:Label>  
                                            </ItemTemplate>  
                                            <%--<EditItemTemplate>  
                                                <asp:TextBox ID="txt_SrNo" runat="server" Text='<%#Eval("Name") %>'></asp:TextBox>  
                                            </EditItemTemplate> --%> 
                                        </asp:TemplateField> 
                                         
                                         
                                         <%--<asp:BoundField DataField="holdername" HeaderText="Holder Name" ReadOnly="True" />--%>

                                          <asp:TemplateField HeaderText="Survey No">  
                                            <ItemTemplate>  
                                                <asp:Label ID="lbl_SurveyNo" runat="server" Text='<%#Eval("surveyno") %>'></asp:Label>  
                                            </ItemTemplate>  
                                            <%--<EditItemTemplate>  
                                                <asp:TextBox ID="txt_SrNo" runat="server" Text='<%#Eval("Name") %>'></asp:TextBox>  
                                            </EditItemTemplate> --%> 
                                        </asp:TemplateField> 
                                        <%--<asp:BoundField DataField="surveyno" HeaderText="Survey No" ReadOnly="True" />--%>

                                         <asp:TemplateField HeaderText="Survey Area">  
                                            <ItemTemplate>  
                                                <asp:Label ID="lbl_SrArea" runat="server" Text='<%#Eval("surveyarea") %>'></asp:Label>  
                                            </ItemTemplate>  
                                            <EditItemTemplate>  
                                                <asp:TextBox ID="txt_SrArea" runat="server" Text='<%#Eval("surveyarea") %>'></asp:TextBox>  
                                            </EditItemTemplate>  
                                        </asp:TemplateField> 

                                         <%--<asp:BoundField DataField="surveyarea" HeaderText="Survey Area" />--%>
                                         <asp:TemplateField HeaderText="Survey Rate">  
                                            <ItemTemplate>  
                                                <asp:Label ID="lbl_SrRate" runat="server" Text='<%#Eval("surveyrate") %>'></asp:Label>  
                                            </ItemTemplate>  
                                            <EditItemTemplate>  
                                                <asp:TextBox ID="txt_SrRate" runat="server" Text='<%#Eval("surveyrate") %>'></asp:TextBox>  
                                            </EditItemTemplate>  
                                        </asp:TemplateField> 

                                        <%--<asp:BoundField DataField="surveyrate" HeaderText="Survey Rate" />--%>
                                         <asp:TemplateField HeaderText="Holder Area">  
                                            <ItemTemplate>  
                                                <asp:Label ID="lbl_HolderArea" runat="server" Text='<%#Eval("holderarea") %>'></asp:Label>  
                                            </ItemTemplate>  
                                            <EditItemTemplate>  
                                                <asp:TextBox ID="txt_HolderArea" runat="server" Text='<%#Eval("holderarea") %>'></asp:TextBox>  
                                            </EditItemTemplate>  
                                        </asp:TemplateField> 

                                         <%--<asp:BoundField DataField="holderarea" HeaderText="Holder Area" />--%>
                                         <asp:TemplateField HeaderText="Aquired Area">  
                                            <ItemTemplate>  
                                                <asp:Label ID="lbl_AquiredArea" runat="server" Text='<%#Eval("areaaquired") %>'></asp:Label>  
                                            </ItemTemplate>  
                                            <EditItemTemplate>  
                                                <asp:TextBox ID="txt_AquiredArea" runat="server" Text='<%#Eval("areaaquired") %>'></asp:TextBox>  
                                            </EditItemTemplate>  
                                        </asp:TemplateField> 
                                         <%--<asp:BoundField DataField="areaaquired" HeaderText="Aquired Area" />--%>

                                    </Columns>
                                    <EmptyDataTemplate>No Record Available</EmptyDataTemplate>  
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
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style7">
                    <asp:Button ID="btnNewDocument" runat="server" AutoPostBack="true" CssClass="btn btn-primary"  Text="New Document" Width="169px" xmlns:asp="#unknown" OnClick="btnNewDocument_Click" Visible="False" />
                </td>
                <td class="auto-style7">
                    <asp:Button ID="btnSaveDocNo" runat="server" AutoPostBack="true" CssClass="btn btn-primary" OnClick="btnSaveDocNo_Click" Text="Save Title Search" Width="169px" xmlns:asp="#unknown" BackColor="#993333" BorderColor="#993333" />
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtDocNo" runat="server" Visible="False"></asp:TextBox>
                </td>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style7" colspan="5">
                    <table style="width:100%;">
                        <tr>
                            <td class="text-center" colspan="4">
                                <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#993333" Text="Check List From Site Office "></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-center" colspan="4">
                                <asp:GridView ID="grdCheckList" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" HorizontalAlign="Left" OnPageIndexChanging="grdCheckList_PageIndexChanging" OnRowCancelingEdit="grdCheckList_RowCancelingEdit" OnRowEditing="grdCheckList_RowEditing" OnRowUpdating="grdCheckList_RowUpdating" PageSize="5" ShowHeaderWhenEmpty="True" Width="887px">
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
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Head Office Remark">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_HeadOfficeRemark" runat="server" Text='<%#Eval("headofficeremark") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txt_HORemark" runat="server" Text='<%#Eval("headofficeremark") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        
                                    </Columns>
                                     <EmptyDataTemplate>No Record Available</EmptyDataTemplate>  
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
                                <asp:Button ID="btnMutation0" runat="server" AutoPostBack="true" CssClass="btn btn-primary" OnClick="btnMutation_Click" Text="Mutation Register " Width="169px" xmlns:asp="#unknown" />
                            </td>
                            <td class="auto-style15">
                                <asp:FileUpload ID="FileUploadControl" runat="server" Height="28px" Width="208px" />
                            </td>
                            <td class="auto-style17">
                                <asp:LinkButton ID="lbllinkMR" runat="server" OnClick="lbllinkMR_Click"></asp:LinkButton>
                            </td>
                            <td class="auto-style12">
                                <asp:Button ID="btnMRTemplate" runat="server" AutoPostBack="true" CssClass="btn btn-primary" OnClick="btnMRTemplate_Click" Text="Template" Width="169px" xmlns:asp="#unknown" Visible="False" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style14">
                                <asp:Button ID="btnRegistration" runat="server" CssClass="btn btn-primary" Text="Registration Report" Width="169px" OnClick="btnRegistration_Click" BackColor="#993333" />
                            </td>
                            <td class="auto-style15">
                                <asp:FileUpload ID="FileUploadControlDR" runat="server" Height="28px" Width="209px" />
                            </td>
                            <td class="auto-style17">
                                <asp:LinkButton ID="lblLinkDrFile" runat="server" OnClick="lblLinkDrFile_Click"></asp:LinkButton>
                            </td>
                            <td class="auto-style12">
                                <asp:Button ID="btnDRTemplate" runat="server" AutoPostBack="true" CssClass="btn btn-primary" OnClick="btnDRTemplate_Click" Text="Template" Width="169px" xmlns:asp="#unknown" BackColor="#993333" Visible="False" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style9">
                                <asp:Button ID="btnPublicNotice" runat="server" CssClass="btn btn-primary" Text="Public Notice" Width="169px" OnClick="btnPublicNotice_Click" BackColor="#CC00CC" />
                            </td>
                            <td class="auto-style16">
                                <asp:FileUpload ID="FileUploadControlPN" runat="server" Height="28px" Width="209px" />
                            </td>
                            <td class="auto-style11">
                                <asp:LinkButton ID="lblLinkPR" runat="server" OnClick="lblLinkPR_Click"></asp:LinkButton>
                            </td>
                            <td class="auto-style13">
                                <asp:Button ID="btnPNTemplate" runat="server" AutoPostBack="true" CssClass="btn btn-primary" OnClick="btnPNTemplate_Click" Text="Template" Width="169px" xmlns:asp="#unknown" BackColor="#CC00CC" Visible="False" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style14">
                                <asp:Button ID="btnFinalRemark" runat="server" CssClass="btn btn-primary" Text="Final Remark" Width="169px" OnClick="btnFinalRemark_Click" BackColor="#009933" />
                            </td>
                            <td class="auto-style15">
                                <asp:FileUpload ID="FileUploadControlFR" runat="server" Height="28px" Width="209px" />
                            </td>
                            <td class="auto-style17">
                                <asp:LinkButton ID="lblLinkFR" runat="server" OnClick="lblLinkFR_Click"></asp:LinkButton>
                            </td>
                            <td class="auto-style12">
                                <asp:Button ID="btnFRTemplate" runat="server" AutoPostBack="true" CssClass="btn btn-primary" OnClick="btnFRTemplate_Click" Text="Template" Width="169px" xmlns:asp="#unknown" BackColor="#009933" Visible="False" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style7" colspan="5">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style7" colspan="5">
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
