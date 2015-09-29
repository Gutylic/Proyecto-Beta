<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Panel_De_Control_Usuario_Dios.aspx.cs" Inherits="Supervisor.Panel_De_Control_Usuario_Dios" UICulture="de" Culture="en-US" EnableEventValidation="false" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1"/>

    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link href="css/encabezado.css" rel="stylesheet" />
    <link href="css/panel_de_control_usuario_dios.css" rel="stylesheet"/>

    <title>Panel de Usuarios</title>

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
            <div class="well fondo_excel">
                <asp:Button ID="Boton_Excel_Dios" CssClass="btn btn-info boton_excel" Width="100%" runat="server" Text="Excel" OnClick="Boton_Excel_Dios_Click" />
            </div>   
        </div>
                 
        <div class="container">
                <div class="row">
                    <div class="col-xs-12"> 
                           
                            <div class="panel panel-default">                             
                                <div class="encabezado_panel panel-heading fondo" style="text-align:center">
                                    <h2 class="datos_del_administrador">Panel De Usuarios</h2>
                                    <hr />
                                    <div class="row">
                                        <div class="col-sm-3 col-xs-4">
                                            <asp:DropDownList ID="DropDownList_Dios" Width="100%" runat="server" AutoPostBack="true">                            
                                                <asp:ListItem Value ="1">Elija una opción</asp:ListItem>
                                                <asp:ListItem Value ="2">Usuario</asp:ListItem> 
                                                <asp:ListItem Value ="3">Correo</asp:ListItem>
                                                <asp:ListItem Value ="4">Activación</asp:ListItem>   
                                                <asp:ListItem Value ="5">Fecha</asp:ListItem>   
                                                <asp:ListItem Value ="6">Empresa</asp:ListItem>                      
                                            </asp:DropDownList>
                                        </div>                                    
                                        <div class="col-sm-7 col-xs-4">                                        
                                            <asp:TextBox Visible="false" ID="Buscar_Dios_Fecha" Width="100%" runat="server" TextMode="Date"></asp:TextBox>
                                        
                                            <cc1:CalendarExtender ID="Buscar_Dios_Fecha_CalendarExtender" runat="server" BehaviorID="Buscar_Dios_Fecha_CalendarExtender" TargetControlID="Buscar_Dios_Fecha">
                                            </cc1:CalendarExtender>
                                        
                                            <asp:DropDownList ID="DropDownList_Buscar_Dios" Visible="false" runat="server" Width="100%">
                                                <asp:ListItem Value ="false">Falso</asp:ListItem>
                                                <asp:ListItem Value ="true">Verdadero</asp:ListItem> 
                                            </asp:DropDownList>             
                                            <asp:TextBox Visible="true" ID="Buscar_Dios" Width="100%" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-2 col-xs-4">
                                            <asp:Button ID="Boton_Buscar_Dios" runat="server" CssClass="btn btn-primary" Width="100%" Text="Buscar" OnClick="Boton_Buscar_Dios_Click" />
                                        </div>
                                    </div>                               
                                </div>
                                          
                            <div class="panel-body cuerpo_del_panel"> 
                                <div class="row">  
                                    <div class="col-sm-12">
                                        <asp:GridView ID="GridView_Dios" Width="100%" GridLines="Both" CssClass="gridview" Font-Bold="false" BorderColor="#DEDFDE" BorderWidth="1px" BorderStyle="None" runat="server" OnSelectedIndexChanged="Identificador_Dios" DataKeyNames="ID_Usuario" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" >
                                            <AlternatingRowStyle BackColor="White" />   
                                            <Columns>
                                                <asp:TemplateField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" HeaderText="Usuario">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="Seleccionar_Dios" CommandName="Select" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" runat="server"><%# Eval ("Usuario") %></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="Credito_De_Usuario" HeaderText="Credito" DataFormatString="{0:c}"/>    
                                                <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="Empresa" HeaderText="Empresa"/>               
                                                <asp:TemplateField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" HeaderText="Bloqueo">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="CheckBox_Activacion_Dios" runat="server" Enabled="false" Checked='<%# Eval ("Activacion_De_Usuarios") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>   
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />                                            
                                            <RowStyle BackColor="#EFF3FB" />                               
                                        </asp:GridView>
                                    </div>                                        
                                </div>
                            </div>
                            <div class="panel-footer" style="text-align:center">
                                <div class="row">
                                    <div id="Extremo_Dios" runat ="server">
                                        <asp:LinkButton ID="Anterior_Dios_Ultimo" runat="server" OnClick="Anterior_Dios_Click"><< Anterior&nbsp;</asp:LinkButton>
                                        <asp:LinkButton ID="Siguiente_Dios_Primero" runat="server" OnClick="Siguiente_Dios_Click">&nbsp;Siguiente >></asp:LinkButton>
                                        
                                    </div>

                                    <div id="Interno_Dios" runat ="server">
                                        <asp:LinkButton ID="Anterior_Dios_Medio" runat="server" OnClick="Anterior_Dios_Click"><< Anterior&nbsp;</asp:LinkButton>
                                        <asp:LinkButton ID="Siguiente_Dios_Medio" runat="server" OnClick="Siguiente_Dios_Click">&nbsp;Siguiente >></asp:LinkButton>
                                        
                                    </div>
                                </div>
                            </div>   
                        </div>
                    </div>
                </div>
            </div>      






           
            <asp:UpdatePanel ID="UpdatePanel_Botonera" runat="server">
                <ContentTemplate>

            
                    <div class="container" id="Formulario_Dios" runat="server" visible="false">
                        <div class="row">
                            <div class="col-xs-12"> 
                            <div class="panel panel-warning">
                                <div class="panel-heading" style="text-align:center"><h3 class="titulo_formulario">Formulario</h3></div>
                                <div class="panel-body">
                                     <form class="form-horizontal">

                                            <div class="form-group">
                                                <div class="col-sm-3">
                                                    <label class="control-label formulario">Usuario:</label>
                                                </div>
                                                <div class="col-sm-9">
                                                    <asp:Label ID="Usuario_Dios" runat="server" CssClass="etiqueta" Width="100%"></asp:Label>
                                                </div>                                               
                                            </div>   
                                                                          
                                            <div class="form-group">
                                                <div class="col-sm-3">
                                                    <label class="control-label formulario" >Correo:</label>
                                                </div>
                                                <div class="col-sm-9">
                                                    <asp:Label ID="Correo_Dios" CssClass="etiqueta" runat="server" Width="100%" ></asp:Label>
                                                </div>   
                                            </div>

                                            <div class="form-group">
                                                <div class="col-sm-3">
                                                    <label class=" control-label formulario">Password:</label>
                                                </div>
                                                <div class="col-sm-9">
                                                    <asp:Label ID="Password_Dios" Width="100%" CssClass="etiqueta" runat="server"></asp:Label>
                                                </div>
                                            </div> 
                                                                            
                                            <div class="form-group">
                                                <div class="col-sm-3">
                                                    <label class=" control-label formulario">Skype:</label>
                                                </div>
                                                <div class="col-sm-9">
                                                    <asp:Label ID="Skype_Dios" Width="100%" CssClass="etiqueta" runat="server" ></asp:Label>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <div class="col-sm-3">
                                                    <label class="control-label formulario">Celular:</label>
                                                </div>
                                                <div class="col-sm-9">
                                                    <asp:Label ID="Celular_Dios" Width="100%" CssClass="etiqueta" runat="server" ></asp:Label>      
                                                </div>                                      
                                            </div>

                                            <div class="form-group">
                                                <div class="col-sm-3">
                                                    <label class="control-label formulario">Modelo:</label>
                                                </div>
                                                <div class="col-sm-9">
                                                    <asp:Label ID="Modelo_Dios" Width="100%" CssClass="etiqueta" runat="server"></asp:Label>      
                                                </div>  
                                            </div>
                                        
                                            <div class="form-group">
                                                <div class="col-sm-3">
                                                    <label class="control-label formulario">Empresa:</label>
                                                </div>
                                                <div class="col-sm-9">
                                                    <asp:Label ID="Empresa_Dios" Width="100%" CssClass="etiqueta" runat="server"></asp:Label>      
                                                </div>  
                                                                                       
                                            </div>  
                                       
                                            <div class="form-group">                                                
                                                 <div class="col-sm-3">
                                                    <label class="control-label formulario">Crédito:</label>
                                                </div>
                                                <div class="col-sm-9">
                                                    <asp:Label ID="Credito_Dios" Width="100%" CssClass="etiqueta" runat="server"></asp:Label>      
                                                </div>                                                                             
                                            </div>
                                        
                                            <div class="form-group">

                                                <label class="col-sm-3 control-label formulario_check">SOS:</label>                                     
                                                <div class="col-sm-9 ">                                        
                                                    <asp:CheckBox class="checkbox etiqueta_check" ID="CheckBox_Pedido_Dios" runat="server"  />                                            
                                                </div>

                                            </div>
                                        
                                            <div class="form-group">
                                                <label class="col-sm-3 control-label formulario" >Bloqueo:</label>
                                                    <div class="col-sm-9 ">
                                                        <asp:CheckBox class="checkbox" ID="CheckBox_Activacion_Dios" runat="server" />  
                                                    </div>                                          
                                            </div>       
                                                                                                      
                                    </form>
                                </div>
                                <div class="panel-footer pie_formulario">
                                
                                    <div class="col-xs-12 boton_formulario">
                                        <asp:Button ID="Boton_Borrar_Dios" OnClientClick="return Confirmacion();" CssClass="btn btn-danger btn_formulario" Width="100%" runat="server" Text="Borrar" OnClick="Boton_Borrar_Dios_Click" />
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