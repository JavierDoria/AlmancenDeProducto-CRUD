<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AlmacenVentas.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>--%>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AlmacenVentas.Login" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <title>Login</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body class="bg-light">
    <form id="form1" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-4">
                <div class="card shadow">
                    <div class="card-header text-center bg-dark text-white">
                        <h4>Iniciar Sesión</h4>
                    </div>
                    <div class="card-body">

                        <asp:TextBox 
                            ID="txtEmail" 
                            runat="server"
                            CssClass="form-control mb-3"
                            Placeholder="Email" />

                        <asp:TextBox 
                            ID="txtPassword"
                            runat="server"
                            CssClass="form-control mb-3"
                            TextMode="Password"
                            Placeholder="Contraseña" />

                        <asp:Button 
                            ID="btnLogin"
                            runat="server"
                            Text="Ingresar"
                            CssClass="btn btn-primary w-100"
                            OnClick="btnLogin_Click" />

                    </div>
                </div>
            </div>
        </div>
    </div>
</form>
    
</body>
</html>
