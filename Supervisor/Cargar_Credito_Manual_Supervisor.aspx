﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cargar_Credito_Manual_Supervisor.aspx.cs" Inherits="Supervisor.Cargar_Credito_Manual_Supervisor" EnableEventValidation="false" UICulture="de" Culture="en-US" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1"/>

    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link href="css/encabezado.css" rel="stylesheet" />
    <link href="css/cargar_de_credito_manual_supervisor.css" rel="stylesheet"/>

    <title>Carga de Crédito Manual</title>

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
                            <h1 class="titulo">Carga</h1>
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
                <asp:Button ID="Boton_Excel_Supervisor" CssClass="btn btn-info boton_excel" Width="100%" runat="server" Text="Excel" OnClick="Boton_Excel_Supervisor_Click" />
            </div>   
        </div>
            <div class="container" >
                <div class="row">
                    <div class="col-xs-12">       
                        <div class="panel panel-default">                             
                            <div class="encabezado_panel panel-heading fondo"><h2 class="datos_del_administrador">Carga Manual de Crédito</h2>
                                <hr />
                                <div class="row">
                                    <div class="col-sm-3 col-xs-4">
                                        <asp:DropDownList ID="DropDownList_Supervisor" Width="100%" runat="server">
                                            <asp:ListItem Value ="1">Elegir</asp:ListItem>
                                            <asp:ListItem Value ="2">Usuario</asp:ListItem>
                                            <asp:ListItem Value ="3">Correo</asp:ListItem>                            
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-7 col-xs-4">
                                        <asp:TextBox ID="Buscar_Supervisor" Width="100%"  runat="server"></asp:TextBox>                                       
                                    </div>
                                    <div class="col-sm-2 col-xs-4">
                                        <asp:Button ID="Boton_Buscar_Supervisor" runat="server" CssClass="btn btn-primary" Width="100%" Text="Buscar" OnClick="Boton_Buscar_Supervisor_Click" />
                                    </div>                          
                                </div>
                            </div>   
                       
            
                            <div class="panel-body cuerpo_del_panel">                                                                              
                                <div class="row">  
                                    <div class="col-sm-12">
                                        <asp:GridView ID="GridView_Supervisor" Width="100%" GridLines="Both" CssClass="gridview" Font-Bold="false" BorderColor="#DEDFDE" BorderWidth="1px" BorderStyle="None"  runat="server" OnSelectedIndexChanged="Identificador_Supervisor" DataKeyNames="ID_Usuario" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" HeaderText="Usuario">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="Seleccionar_Supervisor" CommandName="Select" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" runat="server"><%# Eval ("Usuario") %></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="Correo" HeaderText="Correo" />
                                                <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="Credito_De_Usuario" HeaderText="Credito" />   
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
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate> 
                <div class="container" id="Formulario_Supervisor" runat="server" visible="false">
                <div class="row">
                    <div class="col-xs-12"> 
                        <div class="panel panel-warning">
                            <div class="panel-heading" style="text-align:center"><h3 class="titulo_formulario">Formulario</h3></div>
                            <div class="panel-body">
                                <form class="form-horizontal">
                                    <div class="form-group">
                                        <div class="col-xs-3">
                                            <label class=" control-label formulario">Usuario:</label>
                                        </div>
                                        <div class="col-sm-9">
                                            <asp:Label ID="Usuario_Supervisor"  Width="100%" MaxLength="10" runat="server"></asp:Label>                                              
                                        </div>
                                    </div>                                    
                                    <div class="form-group">
                                        <div class="col-xs-3">
                                            <label class=" control-label formulario">Correo:</label>
                                        </div>
                                        <div class="col-sm-9">
                                            <asp:Label MaxLength="30" ID="Correo_Supervisor" runat="server" Width="100%" ></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-xs-3">
                                            <label class="control-label formulario">Crédito:</label>
                                        </div>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="Credito_Supervisor" Width="100%" runat="server"></asp:TextBox>                                        
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-xs-3">
                                            <label class=" control-label formulario">Carga</label>
                                        </div>
                                        <div class="col-sm-9">
                                             <asp:DropDownList ID="DropDownList_Carga" runat="server" >                            
                                                <asp:ListItem Value ="13">No Resolucion</asp:ListItem>
                                                <asp:ListItem Value ="16">Rapipago</asp:ListItem>
                                                <asp:ListItem Value ="17">Cuenta Digital</asp:ListItem>   
                                                <asp:ListItem Value ="18">Mercado Pago</asp:ListItem>
                                                <asp:ListItem Value ="19">Transferencia Bancaria</asp:ListItem>        
                                                <asp:ListItem Value ="34">Carga de Creditouenta Digital</asp:ListItem>   
                                                <asp:ListItem Value ="35">Cobro por excedente</asp:ListItem>
                                                <asp:ListItem Value ="36">Nota debito</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>                                    
                                    
                                                 
                                </form>
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