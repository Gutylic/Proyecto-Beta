<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cargar_Oferta_Administrador.aspx.cs" Inherits="Supervisor.Cargar_Oferta_Administrador" EnableEventValidation="false" UICulture="de" Culture="en-US" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1"/>

    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link href="css/cargar_oferta_administrador.css" rel="stylesheet"/>
    <link href="css/encabezado.css" rel="stylesheet" />


    <title>Valor de las Ofertas</title>

</head>

<body>

    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            
            <div class="container">
               
                <nav class="navbar navbar-fixed-top header fondo_encabezado">
 	            <div class="container"> 
                                         
                    <div class="row">
                        <div class="col-xs-12 visible-xs administrador" >
                            <asp:Label ID="Administrador_chico" runat="server" Text="">Adm:</asp:Label>
                            <asp:Label ID="Etiqueta_Administrador_Chico" CssClass ="etiqueta_administrador_chico" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="col-xs-12 hidden-xs administrador">
                            <asp:Label ID="Administrador_grande" runat="server" Text="">Administrador:</asp:Label>
                            <asp:Label ID="Etiqueta_Administrador_Grande" CssClass ="etiqueta_administrador_grande" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-4 visible-xs ip chico">
                            <asp:Label ID="Localizador_chico" runat="server">Desde:</asp:Label>
                            <asp:Label ID="Etiqueta_Localizador_Chico" CssClass ="etiqueta_administrador_chico" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="col-xs-4 hidden-xs ip chico">
                            <asp:Label ID="Localizador_Grande" runat="server">Conectado:</asp:Label>
                            <asp:Label ID="Etiqueta_Localizador_Grande" CssClass ="etiqueta_administrador_chico" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="col-xs-4 consola_de_control" style="text-align:center; ">
                            <h1 class="titulo">Beneficios</h1>
                        </div>
                        <div class="col-xs-4 cerrar_session">                             
                            <asp:LinkButton ID="Volver_A_Consola" ToolTip="Volver a Consola de Control" runat="server" OnClick="Volver_A_Consola_Click"><< Volver</asp:LinkButton>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 visible-xs hora_chica_num" >
                            <asp:Label ID="Hora_chico" runat="server" >Hora:</asp:Label>
                            <asp:Label ID="Etiqueta_Hora_Chica" runat="server" ></asp:Label>
                        </div>
                        <div class="col-xs-12 hidden-xs hora_grande" >
                            <asp:Label ID="Hora_grande" runat="server" >Hora de Conexión:</asp:Label>
                            <asp:Label ID="Etiqueta_Hora_Grande" runat="server" ></asp:Label>
                        </div>
                    </div>
                </div>
             </nav>
        
            </div>  

            <div class="navbar navbar-default" id="subnav">
                <div class="col-md-12"></div>	
            </div>

            <div class="container" id="main">
                <div class="row">
                    <div class="col-xs-12">       
                        <div class="panel panel-default">                             
                            <div class="encabezado_panel panel-heading fondo" style="text-align:center"><h2 class="datos_del_administrador">Beneficios de Ofertas</h2></div>   
                            <div class="panel-body"> 
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label class="col-xs-8 control-label formulario">Bonificación por Registrarse en $:</label>
                                        <div class="col-xs-4">
                                            <asp:Label ID="Bonificacion_Por_Registro_Administrador" Width="100%" Height="36px" runat="server"></asp:Label>                                                     
                                        </div>
                                    </div>                                    
                                    <div class="form-group">
                                        <label class="col-xs-8 control-label formulario">Bonificacion por Cargar en %:</label>
                                        <div class="col-xs-4">
                                            <asp:Label ID="Bonificacion_Por_Cargar_Administrador" runat="server" Width="100%" Height="36px"></asp:Label>                                                   
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-xs-8 control-label formulario">Descuento del Segundo Producto en %:</label>
                                        <div class="col-xs-4">
                                            <asp:Label ID="Porcentaje_De_Descuento_Segundo_Producto_Administrador" Width="100%" Height="36px" runat="server"></asp:Label>                                                    
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-xs-8 control-label formulario">Bonificación por Cantidad en $:</label>
                                        <div class="col-xs-4">
                                                <asp:Label ID="Bonificacion_Por_Cantidad_Administrador" runat="server" Width="100%" Height="36px"></asp:Label>                                              
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-xs-8 control-label formulario">Descuento por la Compra de un Producto en %:</label>
                                        <div class="col-xs-4">
                                            <asp:Label ID="Descuento_En_La_Compra_Del_Producto_Administrador" runat="server" Width="100%" Height="36px"></asp:Label>                                                    
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-xs-8 control-label formulario">Bonificación en la Próxima Recarga:</label>
                                        <div class="col-xs-4">
                                            <asp:Label ID="Bonificacion_Proxima_Recarga_Administrador" Width="100%" Height="36px" runat="server"></asp:Label>                                                    
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-xs-8 control-label formulario">Duracion Todas las Compras (en días):</label>
                                        <div class="col-xs-4">
                                            <asp:Label ID="Duracion_De_Todas_Las_Compras_Administrador" runat="server" Width="100%" Height="36px"></asp:Label> 
                                        </div>
                                    </div>  
                                    <div class="form-group">
                                        <label class="col-xs-8 control-label formulario">Duración de la Compra (en días):</label>
                                        <div class="col-xs-4">
                                            <asp:Label ID="Duracion_De_La_Compra_Administrador" runat="server" Width="100%" Height="36px"></asp:Label>                                           
                                        </div>                                               
                                    </div>  
                                </div>                                        
                            </div>   
                        </div>
                    </div>
                </div>
            </div>
            <hr />
            <footer>
                <div class=" container">
                    <div class="row">
                        <div class="col-xs-12">
                            <h6 class="pie">Copyrigth®2015 - Webmaster Martina Ivana Romero</h6>
                        </div>
                        
                    </div>
                </div>
            </footer>
            
    

            <!-- script references -->
            <script src="//ajax.googleapis.com/ajax/libs/jquery/2.0.2/jquery.min.js"></script>
            <script src="js/bootstrap.min.js"></script>
            <script src="js/scripts.js"></script>

           
    </form>
</body>
    
</html>
