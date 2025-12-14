<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="p1.aspx.cs" Inherits="Proyecto1._1.p1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            PROGRAMA DE AYUDA<br />
            <br />
            <br />
            Selecciona que deseas hacer:<br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Donar" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Buscar Insumos" OnClick="Button2_Click" />
        </div>
    </form>
</body>
</html>
