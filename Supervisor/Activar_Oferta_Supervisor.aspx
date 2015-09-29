<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Activar_Oferta_Supervisor.aspx.cs" Inherits="Supervisor.Activar_Oferta_Supervisor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>    
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1"/>

    <link href="css/bootstrap.min.css" rel="stylesheet"/>    
    <link href="css/encabezado.css" rel="stylesheet" />
    <link href="css/activar_oferta_supervisor.css" rel="stylesheet" />

    <title>Activar Ofertas</title>

    <script type="text/javascript">

        function Confirmacion() {

            var seleccion = confirm("¿Está seguro de realizar la acción requerida?");

            if (!seleccion) {
                alert("NO acepto la aplicar la opcion requerida");
                location.reload(true);
            }

            return seleccion;

        }

    </script>

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
                            <h1 class="titulo">Ofertas</h1>
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

            
<asp:UpdatePanel ID="UpdatePanel_Botonera" runat="server">
                                    <ContentTemplate>
            <div class="container" id="main">
                <div class="row">
                    <div class="col-xs-12">       
                        <div class="panel panel-default">                             
                            <div class="encabezado_panel panel-heading fondo" style="text-align:center"><h2 class="datos_del_administrador">Activar Ofertas</h2></div>   
                            <div class="panel-body">               
                                <div class="form-group otras_opciones">
                                        
                                            
                                            <div style="background-color:whitesmoke">
                                                <asp:RadioButtonList CellSpacing="5" ID="RadioButtonList_Ofertas_Supervisor"  runat="server">
                                                    
                                                    <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;Bonificación por Carga" Value="2"  ></asp:ListItem>
                                                    <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;Descuento en la Segunda Compra" Value="3" ></asp:ListItem>
                                                    <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;Descuento en la Compra" Value = "5" ></asp:ListItem>
                                                    <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;Bonificación en la Próxima Carga" Value ="7" ></asp:ListItem>
                                                    <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;Hoy Gratis" Value="8" ></asp:ListItem>
                                                    <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;2 x 1" Value="9" ></asp:ListItem>
                                                    <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;2 x 1 en Vídeos" Value="10" ></asp:ListItem>
                                                    <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;2 x 1 en Ejercicios" Value = "11" ></asp:ListItem>
                                                    <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;Aumento en Duración de Todas las Compras" Value ="12"></asp:ListItem>
                                                    <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;Aumento en la Duración de la Compra" Value="13" ></asp:ListItem>
                                                    <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;2 x 1 en Impresiones" Value="14"  ></asp:ListItem>
                                                    <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;2 x 1 en Explicaciones" Value = "15" ></asp:ListItem>
                                                </asp:RadioButtonList>                                                                                                
                                            </div>    
                                </div>                                                                      
                                            <div class="form-group otras_opciones">
                                                <asp:CheckBox ID="Bonificacion_Registro" Text="&nbsp;&nbsp;&nbsp;&nbsp;Bonificación por Registrarse" runat="server" />
                                                                                            
                                            </div>
                                            <div class="form-group otras_opciones">
                                                <asp:CheckBox ID="Bonificacion_Por_Cantidad" Text="&nbsp;&nbsp;&nbsp;&nbsp;Bonificación por Ser Cliente Habitué" runat="server" />
                                                                                               
                                            </div>                                         
                                        </div>                                        
                                    
                            <div class="panel-footer pie_formulario" >
                                
                                        <div class="col-xs-12 boton_formulario">
                                            <asp:Button ID="Boton_Actualizar_Supervisor" OnClientClick="return Confirmacion();" Width="100%" CssClass="btn btn-warning btn_formulario" runat="server" Text="Actualizar" OnClick="Boton_Actualizar_Supervisor_Click" />
                                        </div>                                       
                                    
                            </div> 
                        </div>
                    </div>
                </div>
            </div>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
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
