<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="twst.aspx.cs" Inherits="WebApplication2.twst" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="restaurantId" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="restaurantId" HeaderText="restaurantId" InsertVisible="False" ReadOnly="True" SortExpression="restaurantId" />
                <asp:BoundField DataField="restaurantName" HeaderText="restaurantName" SortExpression="restaurantName" />
                <asp:BoundField DataField="restaurantAddress" HeaderText="restaurantAddress" SortExpression="restaurantAddress" />
                <asp:BoundField DataField="restaurantPhone" HeaderText="restaurantPhone" SortExpression="restaurantPhone" />
                <asp:BoundField DataField="restaurantNote" HeaderText="restaurantNote" SortExpression="restaurantNote" />
                <asp:BoundField DataField="restaurantPicture" HeaderText="restaurantPicture" SortExpression="restaurantPicture" />
                <asp:BoundField DataField="restaurantURL" HeaderText="restaurantURL" SortExpression="restaurantURL" />
                <asp:BoundField DataField="cityId" HeaderText="cityId" SortExpression="cityId" />
                <asp:BoundField DataField="providerId" HeaderText="providerId" SortExpression="providerId" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbc77f7eb3a51848168c8ca78d00e74488ConnectionString %>" SelectCommand="SELECT * FROM [restaurant]"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
