<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertRestaurantInfo.aspx.cs" Inherits="WebApplication2.InsertRestaurantInfo" %>

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
            width: 14px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID ="btnAdd"/>
            </Triggers>
            <ContentTemplate>
                <table class="auto-style1">
                    <tr>
                        <td>&nbsp;</td>
                        <td colspan="3">
                            <asp:Label ID="Label1" runat="server" Text="餐廳名稱："></asp:Label>
                            <asp:TextBox ID="txtRestName" runat="server"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td colspan="3">
                            <asp:Label ID="Label2" runat="server" Text="餐廳地址："></asp:Label>
                            <asp:DropDownList ID="ddCounty" runat="server" AutoPostBack="True"  OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddCity" runat="server">
                            </asp:DropDownList>
                            <asp:TextBox ID="txtrestAddress" runat="server"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td colspan="3">
                            <asp:Label ID="Label3" runat="server" Text="餐廳電話："></asp:Label>
                            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td colspan="3">
                            <asp:Label ID="Label4" runat="server" Text="餐廳網頁："></asp:Label>
                            <asp:TextBox ID="txtUrl" runat="server"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td colspan="3">
                            <asp:Label ID="Label5" runat="server" Text="餐廳照片："></asp:Label>
                            <asp:FileUpload ID="FileUpload1" runat="server" AutoPostBack ="Ture"/>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td style="vertical-align:middle" colspan="3" >
                            <asp:Label ID="Label6" runat="server"  Text="說明：" ></asp:Label>
                            <asp:TextBox ID="txtNote" runat="server" Height="75px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td class="auto-style2">
                            <asp:Button ID="btnAdd" runat="server" Text="輸入" OnClick="btnAdd_Click" />
                        </td>
                        <td>
                            <asp:Button ID="Button2" runat="server" Text="清空" OnClick="Button2_Click" />
                            <asp:Button ID="Button3" runat="server" Text="登出" OnClick="Button3_Click" />
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    
    </div>
    </form>
</body>
</html>
