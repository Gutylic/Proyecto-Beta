<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Precios_Supervisor.aspx.cs" Inherits="Supervisor.Precios_Supervisor" EnableEventValidation="false" UICulture="de" Culture="en-US" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    
    <link href="css/bootstrap.min.css" rel="stylesheet"/>

    <link href="css/precios_supervisor.css" rel="stylesheet"/>

    <link href="css/encabezado.css" rel="stylesheet" />

    <title>Precios</title>

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
                                                <label class="col-sm-5 control-label formulario">Compra de Ejercicio en $:</label>
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="Valor_Ejercicio_Supervisor" CssClass="caja_de_texto" Width="100%" runat="server"></asp:TextBox> 
                                                    <cc1:FilteredTextBoxExtender ID="Valor_Ejercicio_Supervisor_FilteredTextBoxExtender" FilterType="Custom, Numbers" ValidChars="."  runat="server" BehaviorID="Valor_Ejercicio_Supervisor_FilteredTextBoxExtender" TargetControlID="Valor_Ejercicio_Supervisor" />                                                                                                            
                                                </div>
                                            </div>                                    
                                            <div class="form-group">
                                                <label class="col-sm-5 control-label formulario">Compra de Explicacion en $:</label>
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="Valor_Explicacion_Supervisor" runat="server" Width="100%" CssClass="caja_de_texto"></asp:TextBox>
                                                    <cc1:FilteredTextBoxExtender ID="Valor_Explicacion_Supervisor_FilteredTextBoxExtender"  FilterType="Custom, Numbers" ValidChars="."  runat="server" BehaviorID="Valor_Explicacion_Supervisor_FilteredTextBoxExtender" TargetControlID="Valor_Explicacion_Supervisor" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-5 control-label formulario">Compra de Vídeo en $:</label>
                                                <div class="col-sm-7">
                                                      <asp:TextBox ID="Valor_Video_Supervisor" Width="100%" CssClass="caja_de_texto" runat="server"></asp:TextBox>
                                                       <cc1:FilteredTextBoxExtender ID="Valor_Video_Supervisor_FilteredTextBoxExtender"  FilterType="Custom, Numbers" ValidChars="."  runat="server" BehaviorID="Valor_Video_Supervisor_FilteredTextBoxExtender" TargetControlID="Valor_Video_Supervisor" />
                                                    </div>
                                            </div>
                                                <div class="form-group">
                                                    <label class="col-sm-5 control-label formulario">Compra de Conjunto de Vídeos en $:</label>
                                                    <div class="col-sm-7">
                                                        <asp:TextBox ID="Valor_Conjunto_De_Videos_Supervisor" runat="server" Width="100%" CssClass="caja_de_texto"></asp:TextBox>                                            
                                                        <cc1:FilteredTextBoxExtender ID="Valor_Conjunto_De_Videos_Supervisor_FilteredTextBoxExtender" runat="server"  FilterType="Custom, Numbers" ValidChars="."  BehaviorID="Valor_Conjunto_De_Videos_Supervisor_FilteredTextBoxExtender" TargetControlID="Valor_Conjunto_De_Videos_Supervisor" />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="col-sm-5 control-label formulario">Compra de Ejercicio Personalizado en $:</label>
                                                    <div class="col-sm-7">
                                                        <asp:TextBox ID="Valor_Ejercicio_Personalizado_Supervisor" runat="server" Width="100%" CssClass="caja_de_texto"></asp:TextBox>
                                                        <cc1:FilteredTextBoxExtender ID="Valor_Ejercicio_Personalizado_Supervisor_FilteredTextBoxExtender"  FilterType="Custom, Numbers" ValidChars="."  runat="server" BehaviorID="Valor_Ejercicio_Personalizado_Supervisor_FilteredTextBoxExtender" TargetControlID="Valor_Ejercicio_Personalizado_Supervisor" />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="col-sm-5 control-label formulario">Compra de Explicación Personalizada en $:</label>
                                                    <div class="col-sm-7">
                                                        <asp:TextBox ID="Valor_Explicacion_Personalizada_Supervisor" Width="100%" CssClass="caja_de_texto" runat="server"></asp:TextBox>
                                                        <cc1:FilteredTextBoxExtender ID="Valor_Explicacion_Personalizada_Supervisor_FilteredTextBoxExtender"  FilterType="Custom, Numbers" ValidChars="."  runat="server" BehaviorID="Valor_Explicacion_Personalizada_Supervisor_FilteredTextBoxExtender" TargetControlID="Valor_Explicacion_Personalizada_Supervisor" />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="col-sm-5 control-label formulario">Compra de Vídeo Personalizado en $:</label>
                                                    <div class="col-sm-7">
                                                        <asp:TextBox ID="Valor_Video_Personalizado_Supervisor" runat="server" Width="100%" CssClass="caja_de_texto"></asp:TextBox>                                            
                                                        <cc1:FilteredTextBoxExtender ID="Valor_Video_Personalizado_Supervisor_FilteredTextBoxExtender"  FilterType="Custom, Numbers" ValidChars="."  runat="server" BehaviorID="Valor_Video_Personalizado_Supervisor_FilteredTextBoxExtender" TargetControlID="Valor_Video_Personalizado_Supervisor" />
                                                    </div>
                                                </div>  
                                                <div class="form-group">
                                                    <label class="col-sm-5 control-label formulario">Compra de las Impresiones en $:</label>
                                                    <div class="col-sm-7">
                                                        <asp:TextBox ID="Valor_Impresion_Supervisor" runat="server" Width="100%" CssClass="caja_de_texto"></asp:TextBox>                                            
                                                        <cc1:FilteredTextBoxExtender ID="Valor_Impresion_Supervisor_FilteredTextBoxExtender"  FilterType="Custom, Numbers" ValidChars="."  runat="server" BehaviorID="Valor_Impresion_Supervisor_FilteredTextBoxExtender" TargetControlID="Valor_Impresion_Supervisor" />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="col-sm-5 control-label formulario">Prestamo SOS en $:</label>
                                                    <div class="col-sm-7">
                                                        <asp:TextBox ID="Valor_Prestamo_SOS_Supervisor" runat="server" Width="100%" CssClass="caja_de_texto" ></asp:TextBox>
                                                        <cc1:FilteredTextBoxExtender ID="Valor_Prestamo_SOS_Supervisor_FilteredTextBoxExtender"  FilterType="Custom, Numbers" ValidChars="."  runat="server" BehaviorID="Valor_Prestamo_SOS_Supervisor_FilteredTextBoxExtender" TargetControlID="Valor_Prestamo_SOS_Supervisor" />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="col-sm-5 control-label formulario">Duración de Ejercicios (en días):</label>
                                                    <div class="col-sm-7">
                                                        <asp:TextBox ID="Duracion_De_Los_Ejercicios_Y_Las_Explicaciones_Supervisor" Width="100%" CssClass="caja_de_texto" runat="server"></asp:TextBox>
                                                        <cc1:FilteredTextBoxExtender ID="Duracion_De_Los_Ejercicios_Y_Las_Explicaciones_Supervisor_FilteredTextBoxExtender" FilterType="Numbers" runat="server" BehaviorID="Duracion_De_Los_Ejercicios_Y_Las_Explicaciones_Supervisor_FilteredTextBoxExtender" TargetControlID="Duracion_De_Los_Ejercicios_Y_Las_Explicaciones_Supervisor" />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="col-sm-5 control-label formulario">Duración de Videos (en días):</label>
                                                    <div class="col-sm-7">
                                                        <asp:TextBox ID="Duracion_De_Los_Videos_Supervisor" runat="server" Width="100%" CssClass="caja_de_texto"></asp:TextBox>                                            
                                                        <cc1:FilteredTextBoxExtender ID="Duracion_De_Los_Videos_Supervisor_FilteredTextBoxExtender" FilterType="Numbers" runat="server" BehaviorID="Duracion_De_Los_Videos_Supervisor_FilteredTextBoxExtender" TargetControlID="Duracion_De_Los_Videos_Supervisor" />
                                                    </div>
                                                </div>                                      
                                            
                                        </div>                                        
                                    </div>                                    
                                </div> 
                                <div class="panel-footer pie_formulario">
                                    <asp:UpdatePanel ID="UpdatePanel_Botonera" runat="server">
                                        <ContentTemplate>
                                            <div class="col-xs-12 boton_formulario">
                                                <asp:Button ID="Boton_Actualizar_Supervisor" OnClientClick="return Confirmacion();" CssClass="btn btn-warning btn-actualizar" Width="100%" runat="server" Text="Actualizar" OnClick="Boton_Actualizar_Supervisor_Click" />
                                            </div>                                       
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
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