<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Actualizar_Ejercicio_Dios.aspx.cs" Inherits="Supervisor.Actualizar_Ejercicio_Dios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1"/>

    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link href="css/actualizar_ejercicio_dios.css" rel="stylesheet"/>

    <link href="css/encabezado.css" rel="stylesheet" />
    <title>Actualizar Ejercicio</title>

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
                            <h1 class="titulo">Actualizar</h1>
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
                        <div class="encabezado_panel panel-heading fondo" style="text-align:center"><h2 class="datos_del_administrador">Actualizar Ejercicios</h2></div>                                 
                        <div class="panel-body">
                            <div class="col-xs-12">
                                <asp:FileUpload ID="Subir_Ejercicio_Dios" runat="server" />
                            </div> 
                        </div>
                        <div class="panel-footer pie_formulario">
                            <div class="col-xs-12">
                                <asp:Label ID="Ejercicio_Dios" runat="server"></asp:Label>
                            </div>                                                                        
                        </div>                                
                    </div>  
                </div>
            </div>
         </div>            
           
         <div class="container">

             <div class="well boton_formulario hidden-xs">
                 
                    <div class ="col-xs-2">
                        <asp:Button ID="Boton_Actualizar_Dios" OnClientClick="return Confirmacion();" Width="100%" CssClass="btn btn-warning btn-formulario" runat="server" Text="Actualizar" OnClick="Boton_Actualizar_Dios_Click" />
                    </div>
                    <div class ="col-xs-2">
                        <asp:Button ID="Guardar_Materia" OnClientClick="return Confirmacion();" runat="server" Width="100%" Text="Tabla Materia" CssClass="btn btn-info btn-formulario" OnClick="Guardar_Materia_Click"/>
                    </div>
                    <div class ="col-xs-2">
                        <asp:Button ID="Guardar_Profesor" OnClientClick="return Confirmacion();" runat="server" Width="100%" Text="Tabla Profesor" CssClass="btn btn-default btn-formulario" OnClick="Guardar_Profesor_Click"/>
                    </div>
                    <div class ="col-xs-2">
                        <asp:Button ID="Guardar_Ano" OnClientClick="return Confirmacion();" runat="server" Width="100%" Text="Tabla Año" CssClass="btn btn-primary btn-formulario" OnClick="Guardar_Ano_Click"/>
                    </div>
                    <div class ="col-xs-2">
                        <asp:Button ID="Guardar_Colegio" OnClientClick="return Confirmacion();" runat="server" Width="100%" Text="Tabla Colegio" CssClass="btn btn-danger btn-formulario" OnClick="Guardar_Colegio_Click"/>
                    </div>
                    <div class ="col-xs-2">
                        <asp:Button ID="Guardar_Tema" OnClientClick="return Confirmacion();" runat="server" Width="100%" Text="Tabla Tema" CssClass="btn btn-success btn-formulario" OnClick="Guardar_Tema_Click"/>
                    </div>
                
            </div>
                      
            <div class="well boton_formulario visible-xs hidden-sm">
                 
                    <div class ="col-xs-2 " >
                        <asp:Button ID="Boton_Actualizar_Dios_xs" OnClientClick="return Confirmacion();" Width="100%" CssClass="btn btn-warning btn-formulario" runat="server" Text="Act." OnClick="Boton_Actualizar_Dios_Click" />
                    </div>
                    <div class ="col-xs-2">
                        <asp:Button ID="Guardar_Materia_xs" OnClientClick="return Confirmacion();" runat="server" Width="100%" Text="T M" CssClass="btn btn-info btn-formulario" OnClick="Guardar_Materia_Click"/>
                    </div>
                    <div class ="col-xs-2">
                        <asp:Button ID="Guardar_Profesor_xs" OnClientClick="return Confirmacion();" runat="server" Width="100%" Text="T P" CssClass="btn btn-default btn-formulario" OnClick="Guardar_Profesor_Click"/>
                    </div>
                    <div class ="col-xs-2">
                        <asp:Button ID="Guardar_Ano_xs" OnClientClick="return Confirmacion();" runat="server" Width="100%" Text="T A" CssClass="btn btn-primary btn-formulario" OnClick="Guardar_Ano_Click"/>
                    </div>
                    <div class ="col-xs-2">
                        <asp:Button ID="Guardar_Colegio_xs" OnClientClick="return Confirmacion();" runat="server" Width="100%" Text="T C" CssClass="btn btn-danger btn-formulario" OnClick="Guardar_Colegio_Click"/>
                    </div>
                    <div class ="col-xs-2">
                        <asp:Button ID="Guardar_Tema_xs" OnClientClick="return Confirmacion();" runat="server" Width="100%" Text="T T" CssClass="btn btn-success btn-formulario" OnClick="Guardar_Tema_Click"/>
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

