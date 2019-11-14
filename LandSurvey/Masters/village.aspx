<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="village.aspx.cs" Inherits="LandSurvey.Masters.village" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/Validation.js" type="text/javascript"></script>  
    <script  type="text/javascript">  
        function Validation() {  
            if (Required('<%=txtVillageCode.ClientID%>', 'Enter Village Code'))  
                if (Required('<%=txtVillageName.ClientID%>', 'Enter Village Name'))  
                    if (Required('<%=txtVIllageMarathiName.ClientID%>', 'Enter Village Marathi Name '))  
                        return true;  
            return false;  
        }  
    </script>  


    <style type="text/css">
        .auto-style1 {
            width: 253px;
        }
    </style>
    

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server">
                <table style="width:100%;">
                    <tr>
                        <td>&nbsp;</td>
                        <td class="auto-style1">Village Code:</td>
                        <td>
                            <asp:TextBox ID="txtVillageCode" runat="server"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td class="auto-style1">Village Name:</td>
                        <td>
                            <asp:TextBox ID="txtVillageName" runat="server"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td class="auto-style1">Village Marathi Name:</td>
                        <td>
                            <asp:TextBox ID="txtVIllageMarathiName" runat="server"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td class="auto-style1">&nbsp;</td>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="Save" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
