<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="Tecnicos.aspx.cs" Inherits="Examen2.Tecnicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
        <h1 style="color: #FFFFFF">Tecnicos</h1>
            <p> &nbsp;</p>
</div>
<div  >
    <br />
    <br />
<asp:GridView runat="server" ID="datagrid" PageSize="10" HorizontalAlign="Center"
        CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
        RowStyle-CssClass="rows" AllowPaging="True" />

    <br />
    <br />
    <br />

</div>

<div class="container text-center" style="color: #FFFFFF">
    Nombre:<asp:TextBox ID="tnombre" Class="form-control" runat="server" ></asp:TextBox>
    Especialidad:<asp:TextBox ID="tespecialidad" class="form-control" runat="server" ></asp:TextBox>
    
    Tecnico:<asp:TextBox ID="tcodigo" class="form-control" runat="server" ></asp:TextBox>
    <br />

</div>
<div class="container text-center">

   

    <asp:Button ID="Button1" class="btn btn-outline-primary" runat="server" Text="Agregar" OnClick="Button1_Click" />
    <asp:Button ID="Button2" class="btn btn-outline-secondary" runat="server" Text="Borrar" OnClick="Button2_Click" />
    <asp:Button ID="Button3" runat="server" class="btn btn-outline-danger" Text="Modificar" OnClick="Button3_Click" />
    <asp:Button ID="Bconsulta" runat="server" class="btn btn-outline-danger" Text="Consultar" OnClick="Bconsulta_Click" />

    </div>
</asp:Content>
