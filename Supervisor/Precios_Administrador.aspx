<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Precios_Administrador.aspx.cs" Inherits="Supervisor.Precios_Administrador" EnableEventValidation="false" UICulture="de" Culture="en-US" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1"/>

    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link href="css/precios_administrador.css" rel="stylesheet" />
    <link href="css/encabezado.css" rel="stylesheet" />
    
    <title>Precios</title>

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
                            <h1 class="titulo">Precios</h1>
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
                        <div class="encabezado_panel panel-heading fondo" style="text-align:center"><h2 class="datos_del_administrador">Precios de los Productos</h2></div>   
                            <div class="panel-body">                
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="form-group">                                            
                                            <label class="col-xs-8 control-label formulario">Compra de Ejercicio en $:</label>
                                            <div class="col-xs-4">
                                                <asp:Label ID="Valor_Ejercicio_Administrador" CssClass="valor" Width="100%" Height="36px"  runat="server"></asp:Label>                                                         
                                            </div>
                                        </div>                                    
                                        <div class="form-group">
                                            <label class="col-xs-8 control-label formulario">Compra de Explicación en $:</label>
                                            <div class="col-xs-4">
                                                <asp:Label ID="Valor_Explicacion_Administrador" CssClass="valor" runat="server" Width="100%" Height="36px"></asp:Label>                                                        
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-xs-8 control-label formulario">Compra de Vídeo en $:</label>
                                            <div class="col-xs-4">
                                                <asp:Label ID="Valor_Video_Administrador" CssClass="valor" Width="100%" Height="36px" runat="server"></asp:Label>                                                       
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-xs-8 control-label formulario">Compra de Conjunto de Vídeos en $:</label>
                                            <div class="col-xs-4">
                                                <asp:Label ID="Valor_Conjunto_De_Videos_Administrador" CssClass="valor" runat="server" Width="100%" Height="36px"></asp:Label> 
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-xs-8 control-label formulario">Compra de Ejercicio Personalizado en $:</label>
                                            <div class="col-xs-4">
                                                <asp:Label ID="Valor_Ejercicio_Personalizado_Administrador" CssClass="valor" runat="server" Width="100%" Height="36px"></asp:Label>
                                                        
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-xs-8 control-label formulario">Compra de Explicación Personalizada en $:</label>
                                            <div class="col-xs-4">
                                                <asp:Label ID="Valor_Explicacion_Personalizada_Administrador" CssClass="valor" Width="100%" Height="36px" runat="server"></asp:Label>
                                                        
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-xs-8 control-label formulario">Compra de Vídeo Personalizado en $:</label>
                                            <div class="col-xs-4">
                                                <asp:Label ID="Valor_Video_Personalizado_Administrador" CssClass="valor" runat="server" Width="100%" Height="36px"></asp:Label>                                            
                                                        
                                            </div>
                                        </div>  
                                        <div class="form-group">
                                            <label class="col-xs-8 control-label formulario">Compra de las Impresiones en $:</label>
                                            <div class="col-xs-4">
                                                <asp:Label ID="Valor_Impresion_Administrador" runat="server" CssClass="valor" Width="100%" Height="36px"></asp:Label>                                            
                                                        
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-xs-8 control-label formulario">Prestamo SOS en $:</label>
                                            <div class="col-xs-4">
                                                <asp:Label ID="Valor_Prestamo_SOS_Administrador" runat="server" CssClass="valor" Width="100%" Height="36px" ></asp:Label>
                                                        
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-xs-8 control-label formulario">Duración de Ejercicios y Explicaciones (en días):</label>
                                            <div class="col-xs-4">
                                                <asp:Label ID="Duracion_De_Los_Ejercicios_Y_Las_Explicaciones_Administrador" CssClass="valor" Width="100%" Height="36px" runat="server"></asp:Label>
                                                        
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-xs-8 control-label formulario">Duración de Videos (en días):</label>
                                            <div class="col-xs-4">
                                                <asp:Label ID="Duracion_De_Los_Videos_Administrador" runat="server" CssClass="valor" Width="100%" Height="36px"></asp:Label>                                            
                                                       
                                            </div>
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

