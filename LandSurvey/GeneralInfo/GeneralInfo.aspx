<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GeneralInfo.aspx.cs" Inherits="LandSurvey.GeneralInfo.GeneralInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <style>
            td {
                 text-align: center;
                vertical-align: middle;
                }
            .tableCenter { margin: 0 auto;
               width:500px;
                }
        </style>
        <table style="width:100%;">
            <tr>
                <td colspan="3">
                    <div style="text-align:center">
                        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#990033" Text="General Information"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <div>
                        <p style="font-size: medium; font-weight: bolder; color: #000066">The Land Acquisition project for Thane region aims to facilitate the Clients to acquire Land in Thane region in a hassle free manner with assurance of FREE holding land (No encumbrance).</p>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <div>
                        <p style="font-size: medium; font-weight: bolder; color: #000066">The Acquisition process is carried out by conduction various Surveys like Engineering Land Survey, Layout Marking/Demarcation, Contour Survey, Soil / Tree survey, Local enquiry w.r.t. Record of Rights (Ownership details) etc. The Surveying activity is essential component of for Land acquisition process. It helps to understand the Quality of land, Detection of soil and structural issues, Natural calamity zone, The exact Size (area) and Shape of Land parcels, Accurate boundaries giving detailed and accurate picture of your land so as Land disputes are avoided.  </p>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <div style="text-align:left">
                        <p style="font-size: large; font-weight: bolder; color: #800000">Area of Interest</p>
                        <p style="font-size: medium; font-weight: bolder; color: #FF5050">The project will be carried out in phased manner with proposed area to  be acquired as mentioned below :</p>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                     <div><p style="background-color: #000066; font-size: medium; font-weight: bolder; color: #FFFFFF;">Phase I</p></div>
                 </td>
                <td>&nbsp;</td>
                <td>
                     <div><p style="font-size: medium; font-weight: bolder; color: #FFFFFF; background-color: #000066">Phase - II</p></div>
                 </td>
            </tr>
            <tr>
                <td>
                    <div  style="margin:0 auto;">
                         <table class="tableCenter" border="1"> 
                        <tr>
                            <%--<td colspan="3" style="background-color: #CC9900; font-size: medium; font-weight: bolder; color: #FFFFFF">Village : Atkoli   Total Area to be Acquired : 157.80 Guntha</td>--%>
                        </tr>
                        <tr>
                            <td style="background-color: #CC6600; font-size: medium; font-weight: bolder; color: #FFFFFF"><strong>Village Name</strong></td>
                            <td style="background-color: #CC6600; font-size: medium; font-weight: bolder; color: #FFFFFF"><strong>Area to be Acquired</strong></td>
                            <td style="background-color: #CC6600; font-size: medium; font-weight: bolder; color: #FFFFFF"><strong>Proposed Survey Number</strong></td>
                        </tr>
                        <tr>
                            <td class="auto-style4">&nbsp;</td>
                            <td class="auto-style4">&nbsp;</td>
                            <td class="auto-style4"></td>
                        </tr>
                        <tr>
                            <td class="auto-style4">&nbsp;</td>
                            <td class="auto-style4">&nbsp;</td>
                            <td class="auto-style4">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style4">&nbsp;</td>
                            <td class="auto-style4">&nbsp;</td>
                            <td class="auto-style4">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style4">&nbsp;</td>
                            <td class="auto-style4">&nbsp;</td>
                            <td class="auto-style4">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style4">&nbsp;</td>
                            <td class="auto-style4">&nbsp;</td>
                            <td class="auto-style4">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style4">&nbsp;</td>
                            <td class="auto-style4">&nbsp;</td>
                            <td class="auto-style4">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style4">&nbsp;</td>
                            <td class="auto-style4">&nbsp;</td>
                            <td class="auto-style4">&nbsp;</td>
                        </tr>
                       
                    </table>
                    </div>
                </td>
                <td>&nbsp;</td>
                 <td colspan="2" style="vertical-align:top">
                    <table border="1" class="tableCenter">
                        <tr >
                            <%--<td colspan="3" style="background-color: #CC9900; color: #FFFFFF; font-size: medium; font-weight: bolder">Village : Talavali Total Area to be Acquired : 157.80 Guntha--%>                                
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #CC6600; color: #FFFFFF; font-size: medium; font-weight: bolder;">Village Name</td>
                            <td style="background-color: #CC6600; color: #FFFFFF; font-size: medium; font-weight: bolder;">Area to be Acquired</td>
                            <td style="background-color: #CC6600; color: #FFFFFF; font-size: medium; font-weight: bolder;">Proposed Survey Number</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                 </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
