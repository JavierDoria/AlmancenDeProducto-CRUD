<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="AlmacenVentas.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblTitulo" runat="server" CssClass="fs-4 fw-bold"></asp:Label>
       <div class="mb-3">
            <label class="form-label">Codigo </label>
            <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="mb-3">
             <label class="form-label">Nombre </label>
             <asp:TextBox ID="TxtNombre" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="mb-3">
             <label class="form-label">Precio </label>
             <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" ></asp:TextBox>
        </div>

        <div class="mb-3">
             <label class="form-label">Cantidad </label>
             <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label class="form-label">Categoria</label>
            <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>

        <div class="mb-3">
            <asp:CheckBox ID="chkActivo" runat="server" Text="Activo" />
        </div>

        <div class="mb-3">
             <label class="form-label">URL-IMAGEN </label>
             <asp:TextBox ID="txtImagen" runat="server" CssClass="form-control"></asp:TextBox>
        </div>


    <asp:Button ID="btnSubmit" runat="server" Text="Guardar" CssClass="btn btn-sm btn-primary" OnClick="btnSubmit_Click"/>
    <asp:LinkButton  runat="server" PostBackUrl="~/Default.aspx" CssClass="btn btn-sm btn-warning" >Volver</asp:LinkButton>
    
</asp:Content>
