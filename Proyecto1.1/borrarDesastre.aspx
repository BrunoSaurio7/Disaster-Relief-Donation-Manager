<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="borrarDesastre.aspx.cs" Inherits="Proyecto1._1.borrarDesastre" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Regresar" />
            <br />
            BORRAR DESASTRE<br />
            <br />
            <br />
            Desastre a borrar:
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
&nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Borrar" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
