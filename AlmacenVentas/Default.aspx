<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AlmacenVentas._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-12">
            <asp:Button runat="server" OnClick="Nuevo_Click" CssClass="btn btn-sm btn-success" Text="New Product" />
        </div>
    </div>

    <div class="row mt-3">
        <div class="col-12">
            <asp:GridView ID="GVProducto" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Codigo" HeaderText="Código" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Categoria.Nombre" HeaderText="Categoria" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C2}" />
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />

                   
                    <asp:TemplateField HeaderText="Activo">
                        <ItemTemplate>
                            <span class='<%# Convert.ToBoolean(Eval("Activo")) ? "badge bg-success" : "badge bg-danger" %>'>
                                <%# Convert.ToBoolean(Eval("Activo")) ? "Activo" : "Inactivo" %>
                            </span>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Imagen">
            <ItemTemplate>
                <asp:Image ID="imgProducto" runat="server" 
                           ImageUrl='<%# Eval("Imagen.UrlImagen") %>' 
                           Width="100px" Height="100px" />
            </ItemTemplate>
        </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" CommandArgument='<%# Eval("Id_Producto") %>'
                                OnClick="Editar_Click" CssClass="btn btn-sm btn-primary">Editar</asp:LinkButton>

                            <asp:LinkButton runat="server" CommandArgument='<%# Eval("Id_Producto") %>'
                                OnClick="Eliminar_Click" CssClass="btn btn-sm btn-danger"
                                OnClientClick="return confirm('Desea eliminar?')">Eliminar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
