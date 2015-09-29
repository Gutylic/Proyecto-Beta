<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Precios_Dios.aspx.cs" UICulture="de" Culture="en-US" Inherits="Supervisor.Precios_Dios" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1"/>

    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link href="css/encabezado.css" rel="stylesheet" />
    <link href="css/precios_dios.css" rel="stylesheet"/>

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
            <div class="well fondo_excel">
                <asp:Button ID="Boton_Excel_Dios" CssClass="btn btn-info boton_excel" Width="100%" runat="server" Text="Excel" OnClick="Boton_Excel_Dios_Click" />
            </div>   
        </div>

        <div class="container">
                <div class="row">
                    <div class="col-xs-12">       
                        <div class="panel panel-default">                             
                            <div class="encabezado_panel panel-heading fondo" style="text-align:center"><h2 class="datos_del_administrador">Precios De Los Productos</h2></div>                 
                            <div class="panel-body cuerpo_del_panel"> 
                                <div class="row">  
                                    <div class="col-sm-12">

                                        <asp:GridView ID="GridView_Dios" Width="100%" GridLines="Both" CssClass="gridview" Font-Bold="false" BorderColor="#DEDFDE" BorderWidth="1px" BorderStyle="None" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" >
                                            <AlternatingRowStyle BackColor="White" />   
                                            <Columns>
                                                <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="Valor_Ejercicio" HeaderText="Ejerc." DataFormatString="{0:c}" />    
                                                <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="Valor_Explicacion" HeaderText="Expl." DataFormatString="{0:c}" /> 
                                                <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="Valor_Video" HeaderText="Vídeo" DataFormatString="{0:c}" />  
                                                <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="Valor_Conjunto_De_Videos" HeaderText="Pack" DataFormatString="{0:c}" />    
                                                <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="Valor_Explicacion_Personalizada" HeaderText="Expl. Per." DataFormatString="{0:c}" />  
                                                <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="Valor_Ejercicio_Personalizado" HeaderText="Ejerc. Per." DataFormatString="{0:c}" />
                                                <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="Valor_Video_Personalizado" HeaderText="Video Per." DataFormatString="{0:c}"/>    
                                                <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="Valor_Impresion" HeaderText="Impr." DataFormatString="{0:c}" /> 
                                                <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="Valor_Prestamo_SOS" HeaderText="SOS" DataFormatString="{0:c}" />  
                                                <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="Duracion_De_Los_Videos" HeaderText="V D" />    
                                                <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="Duracion_De_Los_Ejercicios_Y_Las_Explicaciones" HeaderText="E D" />  
                                                <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="Empresa" HeaderText="Empresa" />                                              
                                            
                                                
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