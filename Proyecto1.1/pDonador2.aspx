<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pDonador2.aspx.cs" Inherits="Proyecto1._1.pDonador2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Salir" />
            <br />
            DONAR<br />
            <br />
            <br />
            Ingresa los datos que se te piden
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            Insumo a donar:
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <br />
            Cantidad:
            <asp:TextBox ID="TextBox1" runat="server" TextMode="Number" Width="39px"></asp:TextBox>
            <br />
            Centro a donar: <asp:DropDownList ID="DropDownList2" runat="server">
            </asp:DropDownList>
            <br />
            Fecha:
            <asp:TextBox ID="TextBox2" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Donar" />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
