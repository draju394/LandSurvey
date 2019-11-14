<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckListMaster.aspx.cs" Inherits="LandSurvey.Masters.CheckListMaster" EnableEventValidation = "false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        table { 
             border-spacing: 5px;
             border-collapse: separate;
             }
        .auto-style4 {
            display: block;
            padding: 6px 12px;
            font-size: 14px;
            line-height: 1.42857143;
            color: #555;
            background-color: #fff;
            background-image: none;
            border: 1px solid #ccc;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
            box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
            -webkit-transition: border-color ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
        }
        .auto-style5 {
            width: 666px;
        }
        .auto-style6 {
            font-size: medium;
        }
    </style>
    <table style="width:100%;">
    <tr>
        <td class="auto-style5">&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style5">
            <strong>
            <asp:Label ID="lblHeading" runat="server" Text="lblHeading" CssClass="auto-style6"></asp:Label>
            </strong>
        </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:GridView ID="grdCheckList" runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="899px" OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="grdCheckList_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanging="grdCheckList_PageIndexChanging" PageSize="5">
                <Columns>
                            <asp:BoundField DataField="srno" HeaderText="Sr. No." />
                            <asp:BoundField DataField="chklistno" HeaderText="Check List No." />
                            <asp:BoundField DataField="chkname" HeaderText="Check List Name" />
                            <asp:BoundField DataField="status" HeaderText="Status" />
                            
                        </Columns>
                        <EmptyDataTemplate>
                            No Record Available
                        </EmptyDataTemplate>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="Peru" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td class="auto-style5">
            &nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td colspan="3">
            <%-- Data entry Form  --%>

            <table style="width:100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td style="width: 262px">
                                <asp:Label ID="Label12" runat="server" Text="Check List No. :"></asp:Label>
                            </td>
                    <td>
                                <asp:TextBox ID="txtChkListNo" runat="server" CssClass="form-control input-sm" Width="364px"></asp:TextBox>
                            </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td style="width: 262px">
                                <asp:Label ID="Label13" runat="server" Text="Check List Name :"></asp:Label>
                            </td>
                    <td>
                                <asp:TextBox ID="txtChkListName" runat="server" CssClass="form-control input-sm" Width="364px" Height="53px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td style="width: 262px">
                                <asp:Label ID="Label14" runat="server" Text="Check List Status :"></asp:Label>
                            </td>
                    <td>
                                <asp:DropDownList ID="cmbChkListStatus" runat="server" CssClass="auto-style4" Width="391px" >
                                    <asp:ListItem>Active</asp:ListItem>
                                    <asp:ListItem>InActive</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </td>
    </tr>
    <tr>
        <td colspan="2">
                                <table style="width:100%;">
                                    <tr>
                                        <td>
                                <asp:Button ID="btnSaveChkList" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Save Check List" Width="169px" xmlns:asp="#unknown" OnClick="btnSaveChkList_Click" > </asp:Button> 
                                
                                        </td>
                                        <td>
                                <asp:Button ID="btnAdd" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Add Check List" Width="169px" xmlns:asp="#unknown" OnClick="btnAdd_Click" > </asp:Button> 
                                
                                        </td>
                                        <td>
                                <asp:Button ID="btnEdit" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Edit Check List" Width="169px" xmlns:asp="#unknown" OnClick="btnEdit_Click" > </asp:Button> 
                                
                                        </td>
                                        <td>
                                <asp:Button ID="btnReport" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Text="Report" Width="169px" xmlns:asp="#unknown" OnClick="btnReport_Click" > </asp:Button> 
                                
                                        </td>
                                    </tr>
                                </table>
                                
                            </td>
        <td>&nbsp;</td>
    </tr>
</table>


    <br />
    <br />
</asp:Content>
