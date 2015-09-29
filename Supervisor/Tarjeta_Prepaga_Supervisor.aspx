<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Tarjeta_Prepaga_Supervisor.aspx.cs" UICulture="de" Culture="en-US" Inherits="Supervisor.Tarjeta_Prepaga_Supervisor" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>    
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1"/>

    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link href="css/encabezado.css" rel="stylesheet" />
    <link href="css/tarjeta_prepaga_supervisor.css" rel="stylesheet"/>

    <title>Tarjeta Prepaga</title>

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
                            <h1 class="titulo">Prepagas</h1>
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
                 <div class="row">
                    <div class="col-xs-6">                      
                        <asp:Button ID="Boton_Insertar_Supervisor" OnClientClick="return Confirmacion();" CssClass="btn btn-success boton_excel" Width="100%" runat="server" Text="Insertar Tarjeta" OnClick="Boton_Insertar_Supervisor_Click" />            
                    </div>
                     <div class="col-xs-6"> 
                        <asp:Button ID="Boton_Excel_Supervisor" CssClass="btn btn-info boton_excel" Width="100%" runat="server" Text="Excel" OnClick="Boton_Excel_Supervisor_Click"  />
                    </div>
                </div>
            </div>
        </div> 

            

            <div class="container" style="margin-top:10px" >
                <div class="row">
                    <div class="col-xs-12">       
                        <div class="panel panel-default">                             
                            <div class="encabezado_panel panel-heading fondo"><h2 class="datos_del_administrador">Control de Tarjetas Prepagas</h2>  
                                <hr />
                                <div class="row">
                                    <div class="col-sm-3 col-xs-4">
                                        <asp:DropDownList ID="DropDownList_Supervisor" Width="100%"  runat="server" AutoPostBack="true">                            
                                            <asp:ListItem Value ="1">Elegir una opción</asp:ListItem>
                                            <asp:ListItem Value ="4">Codigo</asp:ListItem>   
                                            <asp:ListItem Value ="2">Fecha de Vencimiento</asp:ListItem> 
                                            <asp:ListItem Value ="3">Activacion de la Tarjeta</asp:ListItem>                   
                                        </asp:DropDownList>
                                    </div>                                    
                                    <div class="col-sm-7 col-xs-4">                                        
                                        <asp:TextBox Visible="false" ID="Buscar_Supervisor_Fecha" Width="100%"  runat="server" TextMode="Date"></asp:TextBox>
                                        
                                        <cc1:CalendarExtender ID="Buscar_Supervisor_Fecha_CalendarExtender" runat="server" BehaviorID="Buscar_Supervisor_Fecha_CalendarExtender" TargetControlID="Buscar_Supervisor_Fecha">
                                        </cc1:CalendarExtender>
                                        
                                        <asp:DropDownList ID="DropDownList_Buscar_Supervisor" Visible="false" runat="server" Width="100%" >
                                            <asp:ListItem Value ="false">Falso</asp:ListItem>
                                            <asp:ListItem Value ="true">Verdadero</asp:ListItem> 
                                        </asp:DropDownList>         
                                            
                                        <asp:TextBox Visible="true" ID="Buscar_Supervisor" Width="100%"  runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-2 col-xs-4">
                                        <asp:Button ID="Boton_Buscar_Supervisor" runat="server" CssClass="btn btn-primary" Width="100%" Text="Buscar" OnClick="Boton_Buscar_Supervisor_Click" />
                                    </div>                                   
                                </div>
                            </div>              
                            <div class="panel-body cuerpo_del_panel"> 
                                <div class="row">  
                                    <div class="col-sm-12">
                                        <asp:GridView ID="GridView_Supervisor" Width="100%" GridLines="Both" CssClass="gridview" Font-Bold="false" BorderColor="#DEDFDE" BorderWidth="1px" BorderStyle="None"  runat="server" OnSelectedIndexChanged="Identificador_Supervisor" DataKeyNames="ID_Tarjeta" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" >
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" HeaderText="Codigo">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="Seleccionar_Supervisor" CommandName="Select" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" runat="server"><%# Eval ("Codigo") %></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="Credito" HeaderText="Credito" DataFormatString="{0:c}"/>    
                                                <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="Fecha_De_Vencimiento" HeaderText="Vencimiento" DataFormatString="{0:d}" />                                                  
                                                <asp:TemplateField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" HeaderText="Activacion">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="CheckBox_Activacion_Supervisor" runat="server" Enabled="false" Checked='<%# Eval ("Activacion_De_La_Tarjeta") %>' />
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
                                        <div id="Extremo_Supervisor" runat ="server">
                                            <asp:LinkButton ID="Anterior_Supervisor_Ultimo" runat="server" OnClick="Anterior_Supervisor_Click"><< Anterior&nbsp;</asp:LinkButton>
                                            <asp:LinkButton ID="Siguiente_Supervisor_Primero" runat="server" OnClick="Siguiente_Supervisor_Click">&nbsp;Siguiente >></asp:LinkButton>                                            
                                        </div>

                                        <div id="Interno_Supervisor" runat ="server">                                            
                                            <asp:LinkButton ID="Anterior_Supervisor_Medio" runat="server" OnClick="Anterior_Supervisor_Click"><< Anterior&nbsp;</asp:LinkButton>
                                            <asp:LinkButton ID="Siguiente_Supervisor_Medio" runat="server" OnClick="Siguiente_Supervisor_Click">&nbsp;Siguiente >></asp:LinkButton>
                                        </div>
                                    </div>
                                </div>     
                        </div>   
                        </div>
                    </div>
                
            </div>       
        
          <asp:UpdatePanel ID="UpdatePanel_Botonera" runat="server">
                                    <ContentTemplate>
            <div class="container" id="Formulario_Supervisor" runat="server" visible="false">
                <div class="row">
                    <div class="col-xs-12"> 
                        <div class="panel panel-warning">
                            <div class="panel-heading" style="text-align:center"><h3 class="titulo_formulario">Formulario</h3></div>
                            <div class="panel-body" id="cuerpo_inicial_supervisor" runat="server">

                                <form class="form-horizontal">                                                                                                        
                                            <div class="form-group" >
                                                <div class="col-xs-3">
                                                    <label class="col-sm-4 control-label formulario">Código</label>
                                                </div>
                                                <div class="col-sm-9">
                                                   <asp:Label ID="Codigo_Supervisor"  Width="100%" runat="server"></asp:Label> 
                                                </div>
                                            </div>      
                                            <div class="form-group" >
                                                <div class="col-xs-3">
                                                    <label class="control-label formulario">Crédito</label>
                                                </div>
                                                <div class="col-sm-9">
                                                   <asp:Label ID="Credito_Supervisor"  Width="100%" runat="server"></asp:Label> 
                                                </div>
                                            </div>                                         
                                            <div class="form-group" >
                                                <div class="col-xs-3">
                                                    <label class="control-label formulario">Vencimiento</label>
                                                </div>
                                                <div class="col-sm-9">
                                                   <asp:TextBox ID="Vencimiento_Supervisor" runat="server" Width="100%"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="Vencimiento_Supervisor_CalendarExtender" runat="server" BehaviorID="Vencimiento_Supervisor_CalendarExtender" TargetControlID="Vencimiento_Supervisor">
                                                    </cc1:CalendarExtender>
                                                </div>
                                            </div>  
                                            
                                            <div class="form-group">
                                                <div class="col-xs-3">
                                                    <label class="control-label formulario">Activación</label>
                                                </div>
                                                <div class="col-sm-8">
                                                    <asp:CheckBox class="col-sm-11 checkbox" ID="CheckBox_Activacion_Supervisor" runat="server" />
                                                </div>
                                            </div>  
                                        </form>
                            </div>
                            
                            <div class="panel-footer pie_formulario">
                                
                                        <div class="col-xs-6 boton_formulario">
                                            <asp:Button ID="Boton_Actualizar_Supervisor" OnClientClick="return Confirmacion();" CssClass="btn btn-warning btn_formulario" Width="100%" runat="server" Text="Actualizar" OnClick="Boton_Actualizar_Supervisor_Click" />
                                        </div>                                        
                                        <div class="col-xs-6 boton_formulario">
                                            <asp:Button ID="Boton_Borrar_Supervisor" CssClass="btn btn-danger btn_formulario" OnClientClick="return Confirmacion();" Width="100%" runat="server" Text="Borrar" OnClick="Boton_Borrar_Supervisor_Click" />
                                        </div>
                                      
                                    <%--</ContentTemplate>
                                </asp:UpdatePanel>--%>
                            </div>
                       </div>
                    </div>
                </div>
            </div>
            
            <div class="container" >
                <div class="row">
                    <div class="col-xs-12"> 
                        <div class="panel panel-danger" id="Formulario_Para_Crear_Tarjeta" runat="server" visible="false">
                            <div class="panel-heading" style="text-align:center"><h3 class="titulo_formulario">Tarjetas Prepagas</h3></div>
                            <div class="panel-body">
                                <form class="form-horizontal">                                                                                                        
                                            

                                    <div class="form-group">
                                        <label class="col-sm-4 control-label formulario">¿Cantidad de Tarjetas a Crear?</label>
                                        <div class="col-sm-8">
                                            <asp:TextBox ID="Cantidad_Tarjeta" Width="100%" style= "margin-bottom:5px" runat="server"></asp:TextBox> 
                                            <cc1:FilteredTextBoxExtender ID="Cantidad_Solo_Numeros" runat="server" FilterType="Numbers" TargetControlID="Cantidad_Tarjeta" />                
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-4 control-label formulario">Credito de las Tarjetas</label>
                                        <div class="col-sm-8">
                                            <asp:TextBox ID="Credito_Tarjeta" Width="100%" style= "margin-bottom:5px" runat="server"></asp:TextBox>   
                                            <cc1:FilteredTextBoxExtender ID="Credito_Solo_Numeros" runat="server" FilterType="Numbers" TargetControlID="Credito_Tarjeta" />                                             
                                        </div>
                                    </div>                                      
                                    <div class="form-group">
                                        <label class="col-sm-4 control-label formulario">Fecha De Vencimiento</label>
                                        <div class="col-sm-8">
                                            <asp:TextBox ID="Caducidad_Tarjeta" runat="server" Width="100%" style= "margin-bottom:5px" ></asp:TextBox>
                                           
                                            <cc1:CalendarExtender ID="Caducidad_Tarjeta_CalendarExtender" runat="server" BehaviorID="Caducidad_Tarjeta_CalendarExtender" TargetControlID="Caducidad_Tarjeta">
                                            </cc1:CalendarExtender>
                                            
                                        </div>
                                    </div>                                    
                                </form> 
                                                 
                            </div>
                            
                            <div class="panel-footer pie_formulario">
                                <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>--%>
                                        
                                        <div class="col-xs-12 boton_formulario">
                                            <asp:Button ID="Boton_Crear_Supervisor" Width="100%" CssClass="btn btn-danger btn_formulario" runat="server" Text="Crear Tarjetas" OnClick="Boton_Crear_Supervisor_Click" />
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
    