<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pAfectado1.aspx.cs" Inherits="Proyecto1._1.pAfectado1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Salir" OnClick="Button1_Click" />
            <br />
            BUSCAR INSUMOS<br />
            <br />
            <br />
            Ingresa los datos que se te piden
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <br />
            <br />
            ¿Qué tipo de desastre sufriste?
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <br />
            Selecciona el sinistro que te afectó:
            <asp:DropDownList ID="DropDownList2" runat="server">
            </asp:DropDownList>
            <br />
            Introduce la fecha en la cuál te afectó:
            <asp:TextBox ID="TextBox1" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
            <br />
            <br />
            Selecciona el(los) insumo(s) que buscas:
            <asp:CheckBoxList ID="CheckBoxList1" runat="server">
            </asp:CheckBoxList>
            <br />
            <asp:Button ID="Button2" runat="server" Text="Buscar" OnClick="Button2_Click" />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
