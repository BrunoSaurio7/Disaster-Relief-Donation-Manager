<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pAfectado.aspx.cs" Inherits="Proyecto1._1.pAfectado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Salir" />
            <br />
            BUSCAR INSUMOS<br />
            <br />
            <br />
            Ingresa los datos que se te piden<br />
            <br />
            Correo:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            Nombre:
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            Estado:
            <asp:DropDownList ID="DropDownList2" runat="server">
            </asp:DropDownList>
            <br />
            Ciudad:
            <asp:DropDownList ID="DropDownList3" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Siguiente" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
