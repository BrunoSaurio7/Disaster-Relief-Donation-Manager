<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menuAdmin.aspx.cs" Inherits="Proyecto1._1.menuAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="Salir" />
            <br />
            MENÚ ADMIN<br />
            <br />
            <br />
            Bienvenid@ administrador <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            Selecciona que deseas hacer:<br />
            <br />
            <br />
            Desastres<br />
            <asp:Button ID="Button9" runat="server" OnClick="Button9_Click" Text="Agregar Desastre" />
&nbsp;<asp:Button ID="Button10" runat="server" Text="Borrar Desastre" OnClick="Button10_Click" />
            <br />
            <br />
            Siniestros<br />
            <asp:Button ID="Button1" runat="server" Text="Agregar Siniestro" OnClick="Button1_Click" />
&nbsp;<asp:Button ID="Button2" runat="server" Text="Borrar Siniestro" OnClick="Button2_Click" />
&nbsp;<asp:Button ID="Button3" runat="server" Text="Editar Siniestro" OnClick="Button3_Click" />
            <br />
            <br />
            Insumos<br />
            <asp:Button ID="Button4" runat="server" Text="Agregar Insumo" OnClick="Button4_Click" />
&nbsp;<asp:Button ID="Button5" runat="server" Text="Borrar Insumo" OnClick="Button5_Click" />
&nbsp;<br />
            <br />
            Centros de Acopio<br />
            <asp:Button ID="Button6" runat="server" Text="Agregar Centro" OnClick="Button6_Click" />
&nbsp;<asp:Button ID="Button7" runat="server" Text="Borrar Centro" OnClick="Button7_Click" />
&nbsp;<br />
            <br />
            Reportes<br />
            <asp:Button ID="Button11" runat="server" OnClick="Button11_Click" Text="Reportes" />
            <br />
        </div>
    </form>
</body>
</html>
