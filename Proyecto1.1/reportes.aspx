<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reportes.aspx.cs" Inherits="Proyecto1._1.reportes" %>

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
            REPORTE DE CENTROS<br />
            <br />
            <br />
            Selecciona el centro de acopio:
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
&nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Generar reporte" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <hr />
            <br />
            REPORTE FLEXIBLE DONACIONES<br />
            <br />
            <br />
            Columnas<br />
            <asp:CheckBoxList ID="CheckBoxList1" runat="server">
            </asp:CheckBoxList>
            <br />
            <br />
            Filtros<br />
            Persona:
            <asp:DropDownList ID="DropDownList2" runat="server">
            </asp:DropDownList>
&nbsp;Ciudad:
            <asp:DropDownList ID="DropDownList3" runat="server">
            </asp:DropDownList>
&nbsp;Insumo:
            <asp:DropDownList ID="DropDownList4" runat="server">
            </asp:DropDownList>
&nbsp;Cantidad mayor a:
            <asp:TextBox ID="TextBox1" runat="server" TextMode="Number" Width="55px"></asp:TextBox>
&nbsp;Centro de Acopio:
            <asp:DropDownList ID="DropDownList5" runat="server">
            </asp:DropDownList>
            <br />
            Fecha entre:
            <asp:TextBox ID="TextBox2" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
&nbsp;y
            <asp:TextBox ID="TextBox3" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Generar reporte" />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <asp:GridView ID="GridView2" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
