<%@ Page Language="C#" AutoEventWireup="true" UICulture="de" Culture="en-US" CodeBehind="Panel_De_Control_Usuario_Administrador.aspx.cs" Inherits="Supervisor.Panel_De_Control_Usuario_Administrador" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1"/>

    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link href="css/encabezado.css" rel="stylesheet" />
    <link href="css/panel_de_control_usuario_administrador.css" rel="stylesheet" />
    
    <title>Panel de Usuarios</title>

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
                            <h1 class="titulo">Panel</h1>
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
                    <asp:UpdatePanel ID="UpdatePanel_Botonera" runat="server">   
                        <ContentTemplate>   
                            <div class="panel panel-default">                                                            
                                <div class="encabezado_panel panel-heading fondo" >
                                    <h2 class="datos_del_administrador">Panel De Usuarios</h2>
                                    <hr />
                                    <div class="col-xs-3 administrador">
                                        <asp:DropDownList ID="DropDownList_Administrador" runat="server">
                                            <asp:ListItem Value ="1">Elija opción</asp:ListItem>
                                            <asp:ListItem Value ="2">Usuario</asp:ListItem>
                                            <asp:ListItem Value ="3">Correo Electrónico</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-xs-6 buscar_administrador">
                                        <asp:TextBox ID="Buscar_Administrador"  runat="server"></asp:TextBox>
                                    </div>
                            
                                    <div class="col-xs-3 boton_buscar_administrador">
                                        <asp:Button ID="Boton_Buscar_Administrador" runat="server" CssClass="btn btn-primary"  Text="Buscar" OnClick="Boton_Buscar_Administrador_Click" />
                                    </div>
                                </div>
                                <div class="panel-body" visible="false" runat="server" id="Formulario">
                                    <div class="row">
                                        <div class="col-xs-5"><h4>Usuario:</h4></div>
                                        <div class="col-xs-7"><asp:Label ID="Usuario_Administrador" Width="100%" Height="36px" runat="server"></asp:Label></div>
                                    </div>  
                                    <div class="row">
                                        <div class="col-xs-5"><h4>Correo Electrónico:</h4></div>
                                        <div class="col-xs-7"><asp:Label ID="Correo_Administrador" runat="server" Width="100%" Height="36px" ></asp:Label></div>
                                    </div>  
                                    <div class="row">
                                        <div class="col-xs-5"><h4>Usuario de Skype:</h4></div>
                                        <div class="col-xs-7"><asp:Label ID="Skype_Administrador" runat="server" Width="100%" Height="36px" ></asp:Label></div>
                                    </div>  
                                    <div class="row">
                                        <div class="col-xs-5"><h4>Número de Móvil:</h4></div>
                                        <div class="col-xs-7"><asp:Label ID="Celular_Administrador" Width="100%" Height="36px" runat="server"></asp:Label></div>
                                    </div>  
                                    <div class="row">
                                        <div class="col-xs-5"><h4>Modelo de Móvil:</h4></div>
                                        <div class="col-xs-7"><asp:Label ID="Modelo_Administrador" runat="server" Width="100%" Height="36px"></asp:Label>  </div>
                                    </div>  
                                    <div class="row">
                                        <div class="col-xs-5"><h4>Crédito del Usuario:</h4></div>
                                        <div class="col-xs-7"><asp:Label ID="Credito_Administrador" runat="server" Width="100%" Height="36px"></asp:Label></div>
                                    </div>  
                                    <div class="row">
                                        <div class="col-xs-5 "><h4>Préstamo Otorgado:</h4></div>
                                        <div class="col-xs-7 prestamo_administrador"><asp:CheckBox class="checkbox" ID="CheckBox_Prestamo_Administrador" runat="server" Enabled="false" /></div>
                                    </div>  
                                    <div class="row">
                                        <div class="col-xs-5"><h4>Activación de Usuario:</h4></div>
                                        <div class="col-xs-7 activacion_administrador"><asp:CheckBox class="checkbox" ID="CheckBox_Activacion_Administrador" runat="server" Enabled="false" /></div>
                                    </div>                                   
                                 </div>  
                             </div>                 
                        </ContentTemplate>
                    </asp:UpdatePanel> 
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

