<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cargar_Oferta_Supervisor.aspx.cs" Inherits="Supervisor.Cargar_Oferta_Supervisor" EnableEventValidation="false" UICulture="de" Culture="en-US"%>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1"/>

    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link href="css/encabezado.css" rel="stylesheet" />
    <link href="css/cargar_oferta_supervisor.css" rel="stylesheet"/>
    
    <title>Valor de las Ofertas</title>

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

<asp:UpdatePanel ID="UpdatePanel_Botonera" runat="server">
                                    <ContentTemplate>
            <div class="container" id="main">
                <div class="row">
                    <div class="col-xs-12">       
                        <div class="panel panel-default">                             
                            <div class="encabezado_panel panel-heading fondo"><h4 class="datos_del_administrador">Beneficios de Ofertas</h4></div>   
                            <div class="panel-body cuerpo_del_panel">   
                                    <div class="col-sm-12">


                                        <div class="form-group">
                                            <div class="col-sm-6 col-xs-12">
                                                <label class="control-label formulario">Bonificación por Registrarse en $:</label>
                                            </div>
                                                <div class="col-sm-6 col-xs-12">
                                                <asp:TextBox ID="Bonificacion_Por_Registro_Supervisor" Width="100%" runat="server"></asp:TextBox>                                                     
                                                <cc1:FilteredTextBoxExtender ID="Bonificacion_Por_Registro_Supervisor_FilteredTextBoxExtender" ValidChars="." FilterType="Custom, Numbers" runat="server" BehaviorID="Bonificacion_Por_Registro_Supervisor_FilteredTextBoxExtender" TargetControlID="Bonificacion_Por_Registro_Supervisor">
                                                </cc1:FilteredTextBoxExtender>
                                                <h5 class="col-xs-12 control-label formulario_cantidad">Cantidad (0-al infinito, con decimales)</h5>
                                            </div>
                                            
                                        </div>                                    
                                        <div class="form-group">
                                            <div class="col-sm-6 col-xs-12">
                                                <label class=" control-label formulario">Bonificacion por Cargar en %:</label>
                                            </div>
                                            <div class="col-sm-6 col-xs-12">
                                                <asp:TextBox ID="Bonificacion_Por_Cargar_Supervisor" runat="server" Width="100%" ></asp:TextBox>                                                   
                                                <cc1:FilteredTextBoxExtender ID="Bonificacion_Por_Cargar_Administrador_FilteredTextBoxExtender" ValidChars="." FilterType="Custom, Numbers" runat="server" BehaviorID="Bonificacion_Por_Cargar_Supervisor_FilteredTextBoxExtender" TargetControlID="Bonificacion_Por_Cargar_Supervisor">
                                                </cc1:FilteredTextBoxExtender>
                                                <h5 class="col-xs-12 control-label formulario_cantidad">Cantidad (0-1, con decimales)</h5>
                                            </div>
                                            
                                        </div>
                                        <div class="form-group">
                                            <div class="col-sm-6 col-xs-12">
                                                <label class="control-label formulario">Descuento del 2do Producto en %:</label>
                                            </div>
                                            <div class="col-sm-6 col-xs-12">
                                                <asp:TextBox ID="Porcentaje_De_Descuento_Segundo_Producto_Supervisor" Width="100%" runat="server"></asp:TextBox>                                                    
                                                <cc1:FilteredTextBoxExtender ID="Porcentaje_De_Descuento_Segundo_Producto_Supervisor_FilteredTextBoxExtender" ValidChars="." FilterType="Custom, Numbers" runat="server" BehaviorID="Porcentaje_De_Descuento_Segundo_Producto_Supervisor_FilteredTextBoxExtender" TargetControlID="Porcentaje_De_Descuento_Segundo_Producto_Supervisor">
                                                </cc1:FilteredTextBoxExtender>
                                                <h5  class="col-xs-12 control-label formulario_cantidad" >Cantidad (0-1, con decimales)</h5>
                                            </div>
                                            
                                        </div>
                                        <div class="form-group">
                                            <div class="col-sm-6 col-xs-12">
                                                <label class="control-label formulario">Bonificacion por Cantidad en $:</label>
                                            </div>
                                            <div class="col-sm-6 col-xs-12">
                                                  <asp:TextBox ID="Bonificacion_Por_Cantidad_Supervisor" runat="server" Width="100%" ></asp:TextBox>                                              
                                                  <cc1:FilteredTextBoxExtender ID="Bonificacion_Por_Cantidad_Supervisor_FilteredTextBoxExtender" ValidChars="." FilterType="Custom, Numbers" runat="server" BehaviorID="Bonificacion_Por_Cantidad_Supervisor_FilteredTextBoxExtender" TargetControlID="Bonificacion_Por_Cantidad_Supervisor">
                                                  </cc1:FilteredTextBoxExtender>      
                                                  <h5 class="col-xs-12 control-label formulario_cantidad">Cantidad (0-al infinito, con decimales)</h5>                                          
                                            </div>
                                            
                                        </div>
                                        <div class="form-group">
                                            <div class="col-sm-6 col-xs-12">
                                                <label class="control-label formulario">Cantidad de Consultas (en días):</label>
                                            </div>
                                            <div class="col-sm-6 col-xs-12">
                                                  <asp:TextBox ID="Cantidad_Supervisor" runat="server" Width="100%"></asp:TextBox>  
                                                  <cc1:FilteredTextBoxExtender ID="Cantidad_Supervisor_FilteredTextBoxExtender" FilterType="Numbers" runat="server" BehaviorID="Cantidad_Supervisor_FilteredTextBoxExtender" TargetControlID="Cantidad_Supervisor">
                                                  </cc1:FilteredTextBoxExtender>
                                                  <h5 class="col-xs-12 control-label formulario_cantidad">Cantidad (0-al infinito)</h5>
                                            </div>
                                            
                                        </div>
                                        <div class="form-group">
                                            <div class="col-sm-6 col-xs-12">
                                                <label class="control-label formulario">Descuento en la Compra en %:</label>
                                            </div>
                                            <div class="col-sm-6 col-xs-12">
                                                <asp:TextBox ID="Descuento_En_La_Compra_Del_Producto_Supervisor" runat="server" Width="100%" ></asp:TextBox>                                                    
                                                <cc1:FilteredTextBoxExtender ID="Descuento_En_La_Compra_Del_Producto_Supervisor_FilteredTextBoxExtender" ValidChars="." FilterType="Custom, Numbers" runat="server" BehaviorID="Descuento_En_La_Compra_Del_Producto_Supervisor_FilteredTextBoxExtender" TargetControlID="Descuento_En_La_Compra_Del_Producto_Supervisor">
                                                </cc1:FilteredTextBoxExtender>
                                                <h5 class="col-xs-12 control-label formulario_cantidad">Cantidad (0-1, con decimales)</h5>
                                            </div>
                                            
                                        </div>                                           

                                        <div class="form-group">
                                            <div class="col-sm-6 col-xs-12">
                                                <label class="control-label formulario">Bonificación Próxima Recarga:</label>
                                            </div> 
                                                <div class="col-sm-6 col-xs-12">
                                                <asp:TextBox ID="Bonificacion_Proxima_Recarga_Supervisor" Width="100%" runat="server"></asp:TextBox>                                                    
                                                <cc1:FilteredTextBoxExtender ID="Bonificacion_Proxima_Recarga_Supervisor_FilteredTextBoxExtender" ValidChars="." FilterType="Custom, Numbers" runat="server" BehaviorID="Bonificacion_Proxima_Recarga_Supervisor_FilteredTextBoxExtender" TargetControlID="Bonificacion_Proxima_Recarga_Supervisor">
                                                </cc1:FilteredTextBoxExtender>
                                                <h5 class="col-xs-12 control-label formulario_cantidad">Cantidad (0-al infinito, con decimales)</h5>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-sm-6 col-xs-12">
                                                <label class="control-label formulario">Todas las Compras (en días)</label>
                                            </div>
                                            <div class="col-sm-6 col-xs-12">
                                                <asp:TextBox ID="Duracion_De_Todas_Las_Compras_Supervisor" runat="server" Width="100%"></asp:TextBox> 
                                                <cc1:FilteredTextBoxExtender ID="Duracion_De_Todas_Las_Compras_Supervisor_FilteredTextBoxExtender" FilterType="Numbers" runat="server" BehaviorID="Duracion_De_Todas_Las_Compras_Supervisor_FilteredTextBoxExtender" TargetControlID="Duracion_De_Todas_Las_Compras_Supervisor">
                                                </cc1:FilteredTextBoxExtender>
                                                <h5 class="col-xs-12 control-label formulario_cantidad">Cantidad (dias sin decimales)</h5>
                                           </div>
                                            
                                        </div>  
                                        <div class="form-group">
                                            <div class="col-sm-6 col-xs-12">
                                                <label class=" control-label formulario">Duracion de la Compra (en días)</label>
                                            </div>
                                            <div class="col-sm-6 col-xs-12">
                                                <asp:TextBox ID="Duracion_De_La_Compra_Supervisor" runat="server" Width="100%"></asp:TextBox>                                           
                                                <cc1:FilteredTextBoxExtender ID="Duracion_De_La_Compra_Supervisor_FilteredTextBoxExtender" FilterType="Numbers" runat="server" BehaviorID="Duracion_De_La_Compra_Supervisor_FilteredTextBoxExtender" TargetControlID="Duracion_De_La_Compra_Supervisor">
                                                </cc1:FilteredTextBoxExtender>
                                                <h5  class="col-xs-12 control-label formulario_cantidad">Cantidad (dias sin decimales)</h5>    
                                            </div>  
                                                                                    
                                        </div>  
                                    </div>                                        
                                </div>    
                            <div class="panel-footer pie_formulario">
                                
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
