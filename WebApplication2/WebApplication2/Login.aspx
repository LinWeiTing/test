<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication2.Login" %>

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
        .auto-style4 {
            width: 102px;
        }
        .auto-style5 {
            width: 44px;
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
                    <asp:Label ID="Label1" runat="server" Text="帳號："></asp:Label>
                    <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3" colspan="3">
                    <asp:Label ID="Label2" runat="server" Text="密碼："></asp:Label>
                    <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style5">
                    &nbsp;</td>
                <td class="auto-style4">
                    <asp:Button ID="btnLogin" runat="server" Text="登入" OnClick="btnLogin_Click" />
                </td>
                <td class="auto-style3">
                    <asp:Button ID="btnLogOut" runat="server" Text="註冊" OnClick="btnLogOut_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
