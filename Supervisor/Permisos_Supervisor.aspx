<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Permisos_Supervisor.aspx.cs" Inherits="Supervisor.Permisos_Supervisor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1"/>

    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    
    <link href="css/permisos_supervisor.css" rel="stylesheet" />    

    <link href="css/encabezado.css" rel="stylesheet" />

    <title>Permisos Administrativos</title>

    <script>
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
                            <h1 class="titulo">Permisos</h1>
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

                    <div class="col-xs-12 col-sm-6 col-md-8">
                        <div class="panel panel-default">
                            <div class="panel-heading" ><h4>Permisos Administradores</h4></div>
   			                <div class="panel-body primero">                           
                                <div class="col-xs-4 col-sm-4 col-md-4">                         
                                    <asp:TextBox ID="Nik_Del_Administrador" placeholder="Nick" runat="server" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-xs-4 col-sm-4 col-md-4">
                                    <asp:Button ID="Boton_De_Buscar" runat="server" Width="100%" Text="Cargar" CssClass="btn btn-success" OnClick="Boton_De_Buscar_Click" />
                                </div>  
                                <div class="col-xs-4 col-sm-4 col-md-4">
                                    <asp:Button ID="Boton_De_Actualizar" OnClientClick="return Confirmacion();" runat="server" Width="100%" Text="Actualizar" CssClass="btn btn-danger" OnClick="Boton_De_Actualizar_Click" />
                                </div>                            
                            </div>
                        </div>
                    </div>

                    <div class="col-xs-12 col-sm-6 col-md-4">
                        <div class="panel panel-default">
                            <div class="panel-heading"><h4>Área de Permisos</h4></div>
   			                <div class="panel-body">
                                <div class="row" style="text-align:center">
                                    <h5 style="color:maroon">Permisos</h5>
                                        <asp:DropDownList ID="DropDownList_Permisos" runat="server" Height="36px">
                                            <asp:ListItem Value="0">Ningúno</asp:ListItem>
                                            <asp:ListItem Value ="1">Todos</asp:ListItem>                                           
                                        </asp:DropDownList>  
                                </div>
                            </div>
                        </div>
                    </div>

                </div>

                <div class="row">

                    <div class="col-xs-12 col-sm-6 col-md-4">

                        <div class="panel panel-default">
                            <div class="panel-heading"><h4>Área de Administradores</h4></div>
   			                <div class="panel-body">
                                <div class="row" style="text-align:center">
                                    <h5 style="color:maroon">Panel de Administradores</h5>
                                    <asp:DropDownList ID="DropDownList_Panel_De_Control_Administrador" runat="server" Height="36px">
                                        <asp:ListItem Value="0">Actualizar (administrador)</asp:ListItem>
                                        <asp:ListItem Value ="5">Actualizar, insertar, borrar y excel</asp:ListItem>
                                    </asp:DropDownList>  
                                </div>
                                <div class="row" style="text-align:center">
                                    <h5 style="color:maroon">Comentario de Administradores</h5>
                                    <asp:DropDownList ID="DropDownList_Comentario_Administrador" runat="server" Height="36px">
                                        <asp:ListItem Value="0">Comentar (administrador)</asp:ListItem>
                                        <asp:ListItem Value ="5">Leer comentarios</asp:ListItem>
                                        <asp:ListItem Value ="8">Leer y borrar comentarios</asp:ListItem>
                                    </asp:DropDownList>  
                                </div>
                                <div class="row" style="text-align:center">
                                    <h5 style="color:maroon">Contol de Supervisores</h5>
                                    <asp:DropDownList ID="DropDownList_Control_Administrador" runat="server" Height="36px">
                                        <asp:ListItem Value="0">Mirar control de supervisores</asp:ListItem>
                                        <asp:ListItem Value ="5">Borrar control de supervisores</asp:ListItem>
                                    </asp:DropDownList>  
                                </div>                                                  
                            </div>
                        </div>

                    </div>
                    
                    <div class="col-xs-12 col-sm-6 col-md-4">

                        <div class="panel panel-default">
                            <div class="panel-heading"><h4>Área de Pedidos</h4></div> 
                            <div class="panel-body">          
                                <div class="row" style="text-align:center">
                                    <h5 style="color:maroon">Pedido de Explicaciones</h5>
                                    <asp:DropDownList ID="DropDownList_Explicaciones" runat="server" Height="36px">
                                        <asp:ListItem Value="5">Anular resolución (supervisor)</asp:ListItem>
                                        <asp:ListItem Value ="8">Borrar explicación</asp:ListItem>
                                    </asp:DropDownList>  
                                </div>   
                                <div class="row" style="text-align:center">
                                    <h5 style="color:maroon">Pedido de Ejercicios</h5>
                                    <asp:DropDownList ID="DropDownList_Ejercicios" runat="server" Height="36px">
                                        <asp:ListItem Value="5">Anular resolución (supervisor)</asp:ListItem>
                                        <asp:ListItem Value ="8">Borrar ejercicio</asp:ListItem>
                                    </asp:DropDownList>  
                                </div>
                                <div class="row" style="text-align:center">
                                    <h5 style="color:maroon">Ver Respuestas</h5>
                                    <asp:DropDownList ID="DropDownList_Respuestas" runat="server" Height="36px">
                                        <asp:ListItem Value="0">No permitidas</asp:ListItem>
                                        <asp:ListItem Value="5">Solo Vídeos</asp:ListItem> 
                                        <asp:ListItem Value="6">Solo Ejercicios</asp:ListItem>
                                        <asp:ListItem Value="8">Vídeos y ejercicios</asp:ListItem>  
                                    </asp:DropDownList>    
                                </div>                                                                   
                            </div>
   		                </div>

                    </div>

                    <div class="col-sm-6 visible-sm hidden-lg hidden-xs hidden-md">

                        <div class="panel panel-default">
                            <div class="panel-heading"><h4>Área de Consultas</h4></div>
   			                <div class="panel-body">
                                   <div class="row" style="text-align:center">
                                        <h5 style="color:maroon">Movimiento de Usuarios</h5>
                                        <asp:DropDownList ID="DropDownList1" runat="server" Height="36px">
                                            <asp:ListItem Value ="0">Búscar (de un solo usuario)</asp:ListItem>
                                            <asp:ListItem Value ="5">Mostrar (todos los usuarios)</asp:ListItem>
                                            <asp:ListItem Value ="8">Excel</asp:ListItem>
                                            <asp:ListItem Value ="9">Borrar movimiento</asp:ListItem>
                                        </asp:DropDownList>  

                                   </div>
                                    <div class="row" style="text-align:center">
                                        
                                        <h5 style="color:maroon">Comprar Ejercicio</h5>
                                        <asp:DropDownList ID="DropDownList2" runat="server" Height="36px">
                                            <asp:ListItem Value="0">Mostrar las compras</asp:ListItem>
                                            <asp:ListItem Value="5">Buscar las compras</asp:ListItem>  
                                            <asp:ListItem Value="8">Insertar, actualizar, borrar, excel</asp:ListItem>   
                                                                                   
                                        </asp:DropDownList>  
                                    </div>
                                   
                                   
                                    <div class="row" style="text-align:center">
                                        <h5 style="color:maroon">Comprar Explicaciones</h5>
                                        <asp:DropDownList ID="DropDownList3" runat="server" Height="36px">
                                            <asp:ListItem Value="0">Mostrar las compras</asp:ListItem>
                                            <asp:ListItem Value="5">Buscar las compras</asp:ListItem>  
                                            <asp:ListItem Value="8">Insertar, actualizar, borrar, excel</asp:ListItem>   
                                                                                   
                                        </asp:DropDownList>    

                                   </div>  
                                   
                                                                                     
                            </div>
                            
   		                </div>

                    </div>

                    <div class="col-xs-12 col-sm-6 col-md-4">

                         <div class="panel panel-default">
                            <div class="panel-heading"><h4>Área de Comercial</h4></div> 
                            <div class="panel-body">          
                                <div class="row" style="text-align:center">
                                        <h5 style="color:maroon">Tarjeta Prepagas</h5>
                                        <asp:DropDownList ID="DropDownList_Tarjetas" runat="server" Height="36px">
                                             <asp:ListItem Value="0">Ningúno</asp:ListItem>
                                            <asp:ListItem Value ="1">Búscar (de una sola tarjeta)</asp:ListItem>
                                            <asp:ListItem Value ="5">Mostrar (todos las tarjetas)</asp:ListItem>
                                            <asp:ListItem Value="6">Actualizar</asp:ListItem>
                                            <asp:ListItem Value="9">Insertar, borrar, excel</asp:ListItem>
                                        </asp:DropDownList>  

                                   </div>   
                                  <div class="row" style="text-align:center">
                                        <h5 style="color:maroon">Carga Manual</h5>
                                        <asp:DropDownList ID="DropDownList_Carga_Manual" runat="server" Height="36px">
                                          
                                            <asp:ListItem Value ="0">Búscar (crédito de usuarios)</asp:ListItem>
                                            <asp:ListItem Value ="5">Actualizar los créditos (cargar)</asp:ListItem>
                                            <asp:ListItem Value="6">Actualizar los créditos (cargar) y excel</asp:ListItem>                                            
                                        </asp:DropDownList>  

                                   </div> 
                                 <div class="row" style="text-align:center">
                                        <h5 style="color:maroon">Carga Automática</h5>
                                        <asp:DropDownList ID="DropDownList_Carga_Automatica" runat="server" Height="36px">
                                            <asp:ListItem Value="0">Ningúno</asp:ListItem>
                                            <asp:ListItem Value ="5">Actualizar los créditos (cargar)</asp:ListItem>
                                        </asp:DropDownList>  

                                   </div> 
                            </div>
                        </div>

                    </div>

                </div>   



                <div class="row">
                    
                    <div class="col-xs-12 col-md-4 hidden-sm">

                        <div class="panel panel-default">
                            <div class="panel-heading"><h4>Área de Consultas</h4></div>
   			                <div class="panel-body">
                                   <div class="row" style="text-align:center">
                                        <h5 style="color:maroon">Movimiento de Usuarios</h5>
                                        <asp:DropDownList ID="DropDownList_Movimiento" runat="server" Height="36px">
                                            <asp:ListItem Value ="0">Búscar (de un solo usuario)</asp:ListItem>
                                            <asp:ListItem Value ="5">Mostrar (todos los usuarios)</asp:ListItem>
                                            <asp:ListItem Value ="8">Excel</asp:ListItem>
                                            <asp:ListItem Value ="9">Borrar movimiento</asp:ListItem>
                                        </asp:DropDownList>  

                                   </div>
                                    <div class="row" style="text-align:center">
                                        
                                        <h5 style="color:maroon">Comprar Ejercicio</h5>
                                        <asp:DropDownList ID="DropDownList_Comprar_Ejercicios" runat="server" Height="36px">
                                            <asp:ListItem Value="0">Mostrar las compras</asp:ListItem>
                                            <asp:ListItem Value="5">Buscar las compras</asp:ListItem>  
                                            <asp:ListItem Value="8">Insertar, actualizar, borrar, excel</asp:ListItem>   
                                                                                   
                                        </asp:DropDownList>  
                                    </div>
                                   
                                   
                                    <div class="row" style="text-align:center">
                                        <h5 style="color:maroon">Comprar Explicaciones</h5>
                                        <asp:DropDownList ID="DropDownList_Comprar_Explicaciones" runat="server" Height="36px">
                                            <asp:ListItem Value="0">Mostrar las compras</asp:ListItem>
                                            <asp:ListItem Value="5">Buscar las compras</asp:ListItem>  
                                            <asp:ListItem Value="8">Insertar, actualizar, borrar, excel</asp:ListItem>   
                                                                                   
                                        </asp:DropDownList>    

                                   </div>  
                                   
                                                                                     
                            </div>
                            
   		                </div>

                    </div>

                    <div class="col-xs-12 col-sm-6 col-md-4">

                         <div class="panel panel-default">
                            <div class="panel-heading"><h4>Área de Precios</h4></div>
   			                <div class="panel-body">
                                   <div class="row" style="text-align:center">
                                        <h5 style="color:maroon">Panel de Precios</h5>
                                        <asp:DropDownList ID="DropDownList_Precios" runat="server" Height="36px">
                                            <asp:ListItem Value="0">Mirar precios</asp:ListItem>
                                            <asp:ListItem Value ="5">Actualizar precios</asp:ListItem>
                                        </asp:DropDownList>  

                                   </div>
                                    <div class="row" style="text-align:center">
                                        
                                        <h5 style="color:maroon">Activar Ofertas</h5>
                                        <asp:DropDownList ID="DropDownList_Activar_Ofertas" runat="server" Height="36px">
                                            <asp:ListItem Value="0">Mirar ofertas activas</asp:ListItem>
                                            <asp:ListItem Value ="5">Activar</asp:ListItem>                                            
                                        </asp:DropDownList>  
                                    </div>
                                   
                                   
                                    <div class="row" style="text-align:center">
                                        <h5 style="color:maroon">Valor de Ofertas</h5>
                                        <asp:DropDownList ID="DropDownList_Valor_De_Ofertas" runat="server" Height="36px">
                                            <asp:ListItem Value="0">Mirar valores</asp:ListItem>
                                            <asp:ListItem Value ="5">Actualizar valores</asp:ListItem>
                                        </asp:DropDownList>  

                                   </div>  
                                   
                                                                                     
                            </div>
                        </div>

                    </div>

                    <div class="col-xs-12 col-sm-6 col-md-4">

                        <div class="panel panel-default">
                            <div class="panel-heading"><h4>Área de Usuarios</h4></div>
   			                <div class="panel-body">
                                   <div class="row" style="text-align:center">
                                        <h5 style="color:maroon">Panel de Usuarios</h5>
                                        <asp:DropDownList ID="DropDownList_Panel_Usuarios" runat="server" Height="36px">
                                            <asp:ListItem Value="0">Ningúno</asp:ListItem>
                                            <asp:ListItem Value="1">Búscar (de un solo usuario)</asp:ListItem>
                                            <asp:ListItem Value="5">Mostrar (todos los usuarios)</asp:ListItem>
                                            <asp:ListItem Value="6">Insertar usuario</asp:ListItem>
                                            <asp:ListItem Value="9">Insertar, actualizar, borrar, excel</asp:ListItem>
                                        </asp:DropDownList>  

                                   </div>
                                    <div class="row" style="text-align:center">
                                        <h5 style="color:maroon">Comentario de Usuarios</h5>
                                        <asp:DropDownList ID="DropDownList_Comentario_Usuario" runat="server" Height="36px">
                                            <asp:ListItem Value ="0">Leer comentario</asp:ListItem>
                                            <asp:ListItem Value ="5">Leer y Borrar comentarios</asp:ListItem>
                                           
                                        </asp:DropDownList>  

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