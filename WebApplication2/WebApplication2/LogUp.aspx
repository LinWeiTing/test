<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogUp.aspx.cs" Inherits="WebApplication2.LogUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 250px;
        }
        .auto-style3 {
            width: 250px;
        }
        .auto-style5 {
            width: 90px;
        }
        .auto-style6 {
            width: 82px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3" colspan="3">
                    <asp:Label ID="Label1" runat="server" Text="分享者姓名："></asp:Label>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3" colspan="3">
                    <asp:Label ID="Label2" runat="server" Text="分享者電話："></asp:Label>
                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3" colspan="3">
                    <asp:Label ID="Label3" runat="server" Text="Line　　ID："></asp:Label>
                    <asp:TextBox ID="txtLineID" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style6">
                    <asp:Button ID="btnInsert" runat="server" Text="輸入" OnClick="btnInsert_Click" />
                    <asp:Button ID="btnClear" runat="server" Text="清空" OnClick="btnClear_Click" />
                </td>
                <td class="auto-style3">
                    <asp:Button ID="btnBackLogin" runat="server" Text="返回" OnClick="btnBackLogin_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
