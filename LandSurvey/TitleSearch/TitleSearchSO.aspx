<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TitleSearchSO.aspx.cs" Inherits="LandSurvey.TitleSearchSO.TitleSearchSO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    &nbsp;<style>
        select{ width:150px}
    </style><script type="text/javascript">
        $(document).ready(function ()
        {
            var districtDDL = $('#cmbDistrictTest');
            var talukaDDL = $('#cmbTalukaName');
            var villageDDL = $('#cmbVillageName');
            var familyDDL = $('#cmbFamilyNo');
            var surveyDDL = $('cmbSurveyNo');
            //District List
            $.ajax({
                url: '../DAL/DataService.asmx/GetDistrict',
                method: 'post',
                dataType: 'json',
                success: function (data) {
                    districtDDL.append($('<option/>', { value: -1, text: 'Select District' }));
                    talukaDDL.append($('<option/>', { value: -1, text: 'Select Taluka' }));
                    villageDDL.append($('<option/>', { value: -1, text: 'Select Village' }));
                    talukaDDL.prop('disabled', true);
                    villageDDL.prop('disabled', true);

                    $(data).each(function (index, item) {
                        districtDDL.append($('<option/>', { value: item.districtid, text: item.districtmname }));
                    });

                }


            });

            districtDDL.change(function () {
                if ($(this).val() == "-1") {
                    talukaDDL.empty();
                    villageDDL.empty();
                    talukaDDL.append($('<option/>', { value: -1, text: 'Select Taluka' }));
                    villageDDL.append($('<option/>', { value: -1, text: 'Select Village' }));
                    talukaDDL.val('-1');
                    villageDDL.val('-1');
                    talukaDDL.prop('disabled', true);
                    villageDDL.prop('disabled', true);

                }
                else {
                    //Taluka List
                    $.ajax({
                     url: '../DAL/DataService.asmx/GetTaluka',
                        method: 'post',
                        data: { districtid: $(this).val() },
                        dataType: 'json',
                        success: function (data) {
                            talukaDDL.empty();
                        talukaDDL.append($('<option/>', { value: -1, text: 'Select Taluka' }));
                       
                        talukaDDL.prop('disabled', false);
                        

                        $(data).each(function (index, item) {
                              talukaDDL.append($('<option/>', { value: item.talukaid, text: item.talukamname }));
                    });

                }


            });

                }

            });
            /// village

            talukaDDL.change(function () {
                if ($(this).val() == "-1") {
                  
                    villageDDL.empty();
                 
                    villageDDL.append($('<option/>', { value: -1, text: 'Select Village' }));
                   
                    villageDDL.val('-1');
                    
                    villageDDL.prop('disabled', true);

                }
                else {
                    //Taluka List
                    $.ajax({
                     url: '../DAL/DataService.asmx/GetVillage',
                        method: 'post',
                        data: { TalukaID: $(this).val() },
                        dataType: 'json',
                        success: function (data) {
                            villageDDL.empty();
                            villageDDL.append($('<option/>', { value: -1, text: 'Select Village' }));

                            villageDDL.prop('disabled', false);
                        

                            $(data).each(function (index, item) {
                                villageDDL.append($('<option/>', { value: item.villageid, text: item.villagemname }));
                    });

                }


            });

                }

            });

             /// For Family 
             villageDDL.change(function () {
                if ($(this).val() == "-1") {

                    familyDDL.empty();

                    familyDDL.append($('<option/>', { value: -1, text: 'Select Family No' }));
                   
                    familyDDL.val('-1');
                    
                    familyDDL.prop('disabled', true);

                }
                else {
                    //Family No List
                    $.ajax({
                     url: '../DAL/DataService.asmx/GetFamilyNo',
                        method: 'post',
                        data: { TalukaID: $(this).val() },
                        dataType: 'json',
                        success: function (data) {
                            familyDDL.empty();
                            familyDDL.append($('<option/>', { value: -1, text: 'Select Family No' }));

                            familyDDL.prop('disabled', false);
                        

                            $(data).each(function (index, item) {
                                familyDDL.append($('<option/>', { value: item.familymasterid, text: item.familyno }));
                    });

                }


            });

                }

            });

            //

            /// For Family Detail Survey
            familyDDL.change(function () {
                if ($(this).val() == "-1") {

                    surveyDDL.empty();

                    surveyDDL.append($('<option/>', { value: -1, text: 'Select Family Survey No' }));
                   
                    surveyDDL.val('-1');
                    
                    surveyDDL.prop('disabled', true);

                }
                else {
                    //Family No List
                    $.ajax({
                     url: '../DAL/DataService.asmx/GetFamilyNo',
                        method: 'post',
                        data: { TalukaID: $(this).val() },
                        dataType: 'json',
                        success: function (data) {
                            familyDDL.empty();
                            familyDDL.append($('<option/>', { value: -1, text: 'Select Family No' }));

                            familyDDL.prop('disabled', false);
                        

                            $(data).each(function (index, item) {
                                familyDDL.append($('<option/>', { value: item.familymasterid, text: item.familyno }));
                    });

                }


            });

                }

            });

            //
        });


    </script><style>
        body{padding-top:70px}
        .auto-style2 {
            width: 340px;
        }
        .auto-style3 {
            width: 340px;
            height: 21px;
        }
        .auto-style4 {
            width: 125px;
            height: 21px;
        }
        .auto-style5 {
            height: 21px;
        }
    </style><div>
       
    </div>
        <table border="0" style="width: 100%; height: 97px;">
            <tr>
                <td class="modal-sm" style="width: 169px">&nbsp;</td>
                <td style="width: 613px">
                    <asp:Label ID="Label6" runat="server" Text="Title Search - Site Office" Font-Bold="True" Font-Size="Medium"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 169px">&nbsp;</td>
                <td style="width: 613px">
                    <table  style="width:100%;">
                        <tr>
                            <td class="auto-style2" >
                                <asp:Label ID="Label1" runat="server" Text="District Name:"></asp:Label>
                            </td>
                            <td >
                                <select class="browser-default custom-select" ID="cmbDistrictTest" name="D3"  >
                    
                                </select></td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Taluka Name:"></asp:Label>
                            </td>
                            <td>
                                <select ID="cmbTalukaName" name="D1" >
                    
                                </select></td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="VIllage Name:"></asp:Label>
                            </td>
                            <td>
                                <select ID="cmbVillageName" name="D2" >
                    
                                </select></td>
                        </tr>
                        <tr>
                            <td class="auto-style2" >&nbsp;</td>
                            <td >
                                &nbsp;</td>
                            <td>&nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>&nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td style="width: 125px">
                                <asp:Label ID="Label4" runat="server" Text="Family No.:"></asp:Label>
                            </td>
                            <td>
                                <select ID="cmbFamilyNo" name="D2" > </select>
                            </td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Survey No."></asp:Label>
                            </td>
                            <td>
                                <select ID="cmbSurveyNo" name="D4" >
                    
                                </select></td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style3"></td>
                            <td class="auto-style4"></td>
                            <td class="auto-style5"></td>
                            <td class="auto-style5"></td>
                            <td class="auto-style5"></td>
                            <td class="auto-style5"></td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td style="width: 125px">&nbsp;</td>
                            <td colspan="2">
                                <asp:Button ID="Button1" runat="server" Text="Search" Width="169px" />
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td style="width: 125px">&nbsp;</td>
                            <td colspan="2">
                                &nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td style="width: 125px">
                                <asp:Label ID="Label7" runat="server" Text="Survey No:"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>

                            <td>
                                <asp:Label ID="Label8" runat="server" Text="Area :"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td style="width: 125px">
                                <asp:Label ID="Label9" runat="server" Text="Family Survey :"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text="Rate :"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <asp:GridView ID="grdHolder" runat="server" Width="603px" AutoGenerateColumns=false BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"  HorizontalAlign="Left" ShowHeaderWhenEmpty="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr.No." ShowHeader="true">
                                        <HeaderStyle Width="20px" />
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Holder Name" ShowHeader="true"></asp:TemplateField>
                                        <asp:TemplateField HeaderText="Holder Area" ShowHeader="true"></asp:TemplateField>
                                        <asp:TemplateField HeaderText="Aquired Area" ShowHeader="true"></asp:TemplateField>

                                    </Columns>
                                    <EmptyDataTemplate>No Record Available</EmptyDataTemplate>  
                                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
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
                            <td class="auto-style2">&nbsp;</td>
                            <td style="width: 125px">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td style="width: 125px">
                                <asp:Button ID="Button2" runat="server" Text="Mutation Register " Width="169px" />
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Button ID="Button4" runat="server" Text="Family History" Width="169px" />
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td >&nbsp;</td>
                            <td style="width: 125px">
                                <asp:Button ID="Button6" runat="server" Text="7/12 " Width="169px" />
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="Button5" runat="server" Text="Concent Letter" Width="169px" />
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td >&nbsp;</td>
                            <td style="width: 125px">
                                <asp:Button ID="Button7" runat="server" Text="8A " Width="169px" />
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="Button8" runat="server" Text="Check List" Width="169px" />
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td >&nbsp;</td>
                            <td style="width: 125px">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="Button9" runat="server" Text="Enquiry Report" Width="169px" />
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td >&nbsp;</td>
                            <td style="width: 125px">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="Button10" runat="server" Text="Other Details " Width="169px" />
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 169px">&nbsp;</td>
                <td style="width: 613px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
    
</asp:Content>
