<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TitleSearch.aspx.cs" Inherits="LandSurvey.TitleSearch.TitleSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/jquery-3.3.1.js"></script>
    <style>
        select{ width:150px}
    </style>
    <script type="text/javascript">
        $(document).ready(function ()
        {
            var districtDDL = $('#cmbDistrictTest');
            var talukaDDL = $('#cmbTalukaName');
            var villageDDL = $('#cmbVillageName');
            var familyDDL = $('#cmbFamilyNo');
            var surveyDDL = $('#cmbSurveyNo');
            var holderDDL = $('#cmbHolderName');
            var lblArea = $('#lblarea');

            //District List
            $.ajax({
                url: '../DAL/DataService.asmx/GetDistrict',
                method: 'post',
                dataType: 'json',
                success: function (data) {
                   // districtDDL.append($('<option/>', { value: -1, text: 'Select District' }));
                   // talukaDDL.append($('<option/>', { value: -1, text: 'Select Taluka' }));
                  //  villageDDL.append($('<option/>', { value: -1, text: 'Select Village' }));
                    districtDDL.prop('disabled', true);
                    talukaDDL.prop('disabled', true);
                    //villageDDL.prop('disabled', true);

                    $(data).each(function (index, item) {
                        districtDDL.append($('<option/>', { value: item.districtid, text: item.districtmname }));
                       // $("select option:first-child");
                    });
                }
            });

            //Taluka List
            $.ajax({
                url: '../DAL/DataService.asmx/GetTaluka',
                method: 'post',
                dataType: 'json',
                success: function (data) {
                   
                    districtDDL.prop('disabled', true);
                    talukaDDL.prop('disabled', true);
                    //villageDDL.prop('disabled', true);

                    $(data).each(function (index, item) {
                        talukaDDL.append($('<option/>', { value: item.talukaid, text: item.talukamname }));
                      //  districtDDL.append($('<option/>', { value: item.districtid, text: item.districtmname }));
                       // $("select option:first-child");
                    });
                }
            });

            //Village List
            $.ajax({
               url: '../DAL/DataService.asmx/GetVillage',
                        method: 'post',
                        data: { TalukaID:1 },
                        dataType: 'json',
                        success: function (data) {
                            villageDDL.empty();
                            villageDDL.append($('<option/>', { value: -1, text: 'Select Village' }));

                            villageDDL.prop('disabled', false);

                    $(data).each(function (index, item) {
                      //  talukaDDL.append($('<option/>', { value: item.talukaid, text: item.talukamname }));
                        villageDDL.append($('<option/>', { value: item.villagecode, text: item.villagemname }));
                    });
                }
            });
            
            /////////////////////////////////////////////////////
            //Not Used
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
                                villageDDL.append($('<option/>', { value: item.villagecode, text: item.villagemname }));
                    });

                }


            });

                }

            });
            ///
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
                        data: { VillageCode: $(this).val() },
                        dataType: 'json',
                        success: function (data) {
                            familyDDL.empty();
                            familyDDL.append($('<option/>', { value: -1, text: 'Select Family No' }));

                            familyDDL.prop('disabled', false);
                    
                            $(data).each(function (index, item) {
                                familyDDL.append($('<option/>', { value: item.familyno, text: item.familyno }));
                                lblArea.val = item.totalarea;
                                $('[id*=lblarea]').html(item.totalarea);

                                
                    });

                }


            });

                }

            });

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
                     url: '../DAL/DataService.asmx/GetFamilySurveyNo',
                        method: 'post',
                        data: { FamilyNo: $(this).val(), VillageCode: $('#cmbVillageName').val() },
                        dataType: 'json',
                        success: function (data) {
                            surveyDDL.empty();
                            surveyDDL.append($('<option/>', { value: -1, text: 'Select Family Survey No' }));

                            surveyDDL.prop('disabled', false);
                        

                            $(data).each(function (index, item) {
                                surveyDDL.append($('<option/>', { value: item.surveyno, text: item.surveyno }));
                    });

                }


            });

                }

            });

             surveyDDL.change(function () {
                if ($(this).val() == "-1") {
                    holderDDL.empty();
                    holderDDL.append($('<option/>', { value: -1, text: 'Select Family Survey No' }));
                    holderDDL.val('-1');
                    holderDDL.prop('disabled', true);

                }
                else {
                    //Family No List
                    $.ajax({
                     url: '../DAL/DataService.asmx/GetFamilyDetailsGrid',
                        method: 'post',
                        data: { SurveyNo: $(this).val(), VillageCode: $('#cmbVillageName').val() },
                        dataType: 'json',
                        success: function (data) {
                            holderDDL.empty();
                            holderDDL.append($('<option/>', { value: -1, text: 'Select Family Survey No' }));
                            holderDDL.prop('disabled', false);
                        

                            $(data).each(function (index, item) {
                                // alert(item.holdername);
                                holderDDL.append($('<option/>', { value: item.surveyno, text: item.holdername }));

                               <%-- for (var i = 0; i < data.d.length; i++) {
                                    alert(data.d[i].names);
                                    $("#<%=grdHolderHo.ClientID %>").append("<tr><td>" + data.d[i].names + "</td></tr>");

                                    }--%>

                    });

                }


            });

                }

            });



            //
            
        });

        function ShowCurrentTime() {
            $.ajax({
                type: "POST",
                url: "TitleSearch.aspx/GetCurrentTime",
               
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess1,
                failure: function(response) {
                    alert(response.d);
                }
            });
        }

        //function OnSuccess1(response) {
        //    alert(response.d);
        //}

        //function OnSuccess(r) {
        ////Parse the XML and extract the records.
        //var customers = $($.parseXML(r.d)).find("Table");
 
        ////Reference GridView Table.
        //var table = $("[id*=gvCustomers]");
 
        ////Reference the Dummy Row.
        //var row = table.find("tr:last-child").clone(true);
 
        ////Remove the Dummy Row.
        //$("tr", table).not($("tr:first-child", table)).remove();
 
        ////Loop through the XML and add Rows to the Table.
        //$.each(customers, function () {
        //    var customer = $(this);
        //    $("td", row).eq(0).html($(this).find("CustomerID").text());
        //    $("td", row).eq(1).html($(this).find("ContactName").text());
        //    $("td", row).eq(2).html($(this).find("Country").text());
        //    table.append(row);
        //    row = table.find("tr:last-child").clone(true);
        //});
    //}

    </script>

    

    <style>
        body{padding-top:70px}
        .auto-style2 {
            width: 340px;
        }
        
        table { 
             border-spacing: 10px;
             border-collapse: separate;
}
     
        .auto-style6 {
            width: 169px;
            height: 22px;
        }
        .auto-style7 {
            width: 613px;
            height: 22px;
        }
        .auto-style8 {
            height: 22px;
        }
     
        .auto-style9 {
            width: 91px;
        }
        .auto-style10 {
            width: 284px;
        }
     
    </style>
    
    <div>
        <p></p>
    </div>
        <table border="0" style="width: 100%; height: 97px;" >
            <tr>
                <td class="modal-sm" style="width: 169px">&nbsp;</td>
                <td style="width: 613px">
                    <asp:Label ID="Label6" runat="server" Text="Title Search" Font-Bold="True" Font-Size="Medium"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 169px">&nbsp;</td>
                <td style="width: 613px">
                    <table  style="width:100%; ">
                        <tr>
                            <td class="auto-style2" >
                                <asp:Label ID="Label1" runat="server" Text="District Name:"></asp:Label>
                            </td>
                            <td class="auto-style9" >
                                <select class="browser-default custom-select" ID="cmbDistrictTest" name="D3"  >
                    
                                </select></td>
                            <td class="auto-style10">
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
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style9">
                                <asp:Label ID="Label4" runat="server" Text="Family No.:"></asp:Label>
                            </td>
                            <td class="auto-style10">
                                <select ID="cmbFamilyNo" name="D2" > </select>
                               </td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Survey No."></asp:Label>
                            </td>
                            <td>
                                <select ID="cmbSurveyNo" name="D4" >
                    
                                </select></td>
                            <td>
                                <select ID="cmbHolderName" name="D5" style="display:none">
                    
                                </select></td>
                        </tr>
                        
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style9">
                                <asp:Label ID="Label7" runat="server" Text="Survey No:"></asp:Label>
                            </td>
                            <td class="auto-style10">
                                &nbsp;</td>

                            <td>
                                <asp:Label ID="Label8" runat="server" Text="Area :"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblarea" runat="server" Text="lblarea"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style9">
                                <asp:Label ID="Label9" runat="server" Text="Family Survey:"></asp:Label>
                            </td>
                            <td class="auto-style10">
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text="Rate :"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <asp:GridView ID="grdHolderHo" runat="server" Width="752px" AutoGenerateColumns=false BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"  HorizontalAlign="Left" ShowHeaderWhenEmpty="True">
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
                            <td class="auto-style9">&nbsp;</td>
                            <td class="auto-style10">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style9">
                                <asp:Button ID="btnMutation" AutoPostBack="false" xmlns:asp="#unknown" runat="server" Text="Mutation Register " Width="169px"  CssClass="btn btn-primary" OnClick="btnMutation_Click" />
                            </td>
                            <td colspan="2">

                                <asp:FileUpload id="FileUploadControl" runat="server" Width="304px"  Height="28px" />
                            </td>
                            <td>
                                <asp:Button ID="btnRemark0" runat="server" Text="Download Template" Width="169px" CssClass="btn btn-primary" OnClick="btnRemark0_Click"/>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td >&nbsp;</td>
                            <td>
                                <asp:Button ID="btnRegistration" runat="server" Text="Registration Report" Width="169px" CssClass="btn btn-primary"/>
                            </td>
                            <td colspan="2">

                                <asp:FileUpload id="FileUploadControl0" runat="server" Width="304px"  Height="28px" />
                            </td>
                            <td>
                                <asp:Button ID="btnRemark1" runat="server" Text="Download Template" Width="169px" CssClass="btn btn-primary"/>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td >&nbsp;</td>
                            <td class="auto-style9">
                                <asp:Button ID="BtnPublic" runat="server" Text="Public Notice" Width="169px"  CssClass="btn btn-primary" />
                            </td>
                            <td colspan="2">

                                <asp:FileUpload id="FileUploadControl1" runat="server" Width="304px"  Height="28px" />
                            </td>
                            <td>
                                <asp:Button ID="btnRemark2" runat="server" Text="Download Template" Width="169px" CssClass="btn btn-primary"/>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td >&nbsp;</td>
                            <td class="auto-style9">
                                <asp:Button ID="btnRemark" runat="server" Text="Final Remark" Width="169px" CssClass="btn btn-primary"/>
                            </td>
                            <td colspan="2">

                                <asp:FileUpload id="FileUploadControl2" runat="server" Width="304px"  Height="28px" />
                            </td>
                            <td>
                                <asp:Button ID="btnRemark3" runat="server" Text="Download Template" Width="169px" CssClass="btn btn-primary"/>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td >&nbsp;</td>
                            <td class="auto-style9">

    <asp:Button runat="server" id="UploadButton" text="Upload" onclick="UploadButton_Click" />
                            </td>
                            <td class="auto-style10">&nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td><input id="btnGetTime" type="button" style="display:none" value="Mutation Register" onclick = "ShowCurrentTime()" Class="btn btn-primary" disabled="disabled" /></td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td >&nbsp;</td>
                            <td class="auto-style9">
                                &nbsp;</td>
                            <td class="auto-style10">&nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td >&nbsp;</td>
                            <td class="auto-style9">
                                &nbsp;</td>
                            <td class="auto-style10"> 

                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6"></td>
                <td class="auto-style7"> 

    <br /><br />
    <asp:Label runat="server" id="StatusLabel" text="Upload status: " />

                </td>
                <td class="auto-style8"></td>
            </tr>
        </table>
        <br />
    
</asp:Content>
