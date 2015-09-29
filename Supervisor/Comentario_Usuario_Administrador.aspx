<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Comentario_Usuario_Administrador.aspx.cs" Inherits="Supervisor.Comentario_Usuario_Administrador" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1"/>

    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link href="css/encabezado.css" rel="stylesheet" />
    <link href="css/comentario_usuario_administrador.css" rel="stylesheet" />
    
    <title>Comentarios de Usuarios</title>

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
                            <h1 class="titulo">Comentarios</h1>
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
                        <div class="encabezado_panel panel-heading fondo" style="text-align:center"><h2 class="datos_del_administrador">Mensaje de los Clientes</h2></div>   
                            <div class="panel-body cuerpo_del_panel">                
                                <div class="row">  
                                    <div class="col-sm-12">
                                        <asp:GridView ID="GridView_Administrador" Width="100%" GridLines="Both" CssClass="gridview" Font-Bold="false" BorderColor="#DEDFDE" BorderWidth="1px" BorderStyle="None"  runat="server" OnSelectedIndexChanged="Identificador_Administrador" DataKeyNames="ID_Comentario" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333"  >
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="Seleccionar_Administrador" CommandName="Select" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" runat="server"><%# Eval ("Nombre") %></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="Comentario" HeaderText="Comentario" />                  
                                                <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="Correo" HeaderText="Correo" />  
                                            </Columns>

                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            
                                            <RowStyle BackColor="#EFF3FB" />

                                        </asp:GridView>
                                    </div>                                        
                                </div>
                            </div>
                            <div class="panel-footer" style="text-align:center">
                                    <div class="row">
                                        <div id="Extremo_Administrador" runat ="server">
                                            <asp:LinkButton ID="Anterior_Administrador_Ultimo" runat="server" OnClick="Anterior_Administrador_Click"><< Anterior&nbsp;</asp:LinkButton>
                                            <asp:LinkButton ID="Siguiente_Administrador_Primero" runat="server" OnClick="Siguiente_Administrador_Click">&nbsp;Siguiente >></asp:LinkButton>                                            
                                        </div>

                                        <div id="Interno_Administrador" runat ="server">                                            
                                            <asp:LinkButton ID="Anterior_Administrador_Medio" runat="server" OnClick="Anterior_Administrador_Click"><< Anterior&nbsp;</asp:LinkButton>
                                            <asp:LinkButton ID="Siguiente_Administrador_Medio" runat="server" OnClick="Siguiente_Administrador_Click">&nbsp;Siguiente >></asp:LinkButton>
                                        </div>
                                    </div>
                                </div>  
                            </div>  
                        </div>
                    </div>
                </div>     
        
        <div class="container" id="Formulario_Administrador" runat="server" visible="false">
            <div class="row">
                <div class="col-xs-12"> 
                    <div class="panel panel-warning">
                        <div class="panel-heading" style="text-align:center"><h3 class="titulo_formulario">Formulario</h3></div>
                        <div class="panel-body">
                                <form class="form-horizontal">
                                    <div class="form-group">
                                        <label class="col-xs-6 control-label formulario">Usuario</label>
                                        <div class="col-xs-6">
                                            <asp:TextBox ID="Usuario_Administrador" Width="100%"  runat="server"></asp:TextBox>      
                                        </div>
                                    </div>                                    
                                    <div class="form-group">
                                        <label class="col-xs-6 control-label formulario">Comentario</label>
                                        <div class="col-xs-6">
                                            <asp:TextBox ID="Comentarios_Administrador" TextMode="MultiLine" runat="server" Width="100%"  ></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-xs-6 control-label formulario">Correo</label>
                                        <div class="col-xs-6">
                                            <asp:TextBox ID="Correo_Administrador" runat="server" Width="100%" ></asp:TextBox>
                                        </div>
                                    </div>                                                                                
                                </form>
                            </div>                            
                        </div>
                    </div>
                </div>
            </div>
        
        <hr />

        <footer>
            <div class="container">
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

    
    