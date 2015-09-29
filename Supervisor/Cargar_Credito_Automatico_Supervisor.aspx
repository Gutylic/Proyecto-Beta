<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cargar_Credito_Automatico_Supervisor.aspx.cs" Inherits="Supervisor.Cargar_Credito_Automatico_Supervisor" EnableEventValidation="false" UICulture="de" Culture="en-US" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1"/>

    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link href="css/cargar_de_credito_automatico_supervisor.css" rel="stylesheet"/>
    <link href="css/encabezado.css" rel="stylesheet" />
    
    <title>Carga de Crédito Automatico</title>

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
            <div class="well">  
                <div class="row">
                    <div class="col-xs-12 cabezera" style="text-align:center"> 
                        <h2 class="titulos">CuentaDigital</h2>
                    </div>
                </div>
                <hr class="linea"/>
                <div class="row">
                    <div class="col-xs-4 col-sm-2"> 
                        <h3 class="etiqueta">Fecha:</h3>
                    </div>
                    <div class="col-xs-8 col-sm-10"> 
                        <asp:TextBox ID="Cuenta_Digital_Supervisor" Width="100%" runat="server"></asp:TextBox>
                        <cc1:CalendarExtender ID="Cuenta_Digital_Supervisor_CalendarExtender" runat="server" BehaviorID="Cuenta_Digital_Supervisor_CalendarExtender" TargetControlID="Cuenta_Digital_Supervisor">
                        </cc1:CalendarExtender>
                    </div>
                </div>
                <hr class="linea" />
                <div class="row">
                    <asp:UpdatePanel ID="UpdatePanel_Cuenta_Digital" runat="server">
                        <ContentTemplate>
                            <div class="col-xs-12"> 
                                <asp:Button ID="Boton_Cuenta_Digital_Supervisor" Width="100%" CssClass="btn btn-success" runat="server" Text="Cargar CuentaDigital" OnClick="Boton_Cuenta_Digital_Supervisor_Click" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>                   
                </div>
            </div>
        </div>
        
        <div class="container">
            <div class="well" style="text-align:center">
                <div class="row">
                    <div class="col-xs-12"> 
                        <h2 class="titulos">PayPal</h2>
                    </div>
                </div>
                <hr class="linea"/>
                <div class="row">
                    <div class="col-xs-4 col-sm-2"> 
                        <h3 class="etiqueta">Código:</h3>
                    </div>
                    <div class="col-xs-8 col-sm-10"> 
                        <asp:TextBox ID="PayPal_Supervisor" Width="100%" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-4 col-sm-2"> 
                        <h3 class="etiqueta">U$S a $:</h3>
                    </div>
                    <div class="col-xs-8 col-sm-10"> 
                        <asp:TextBox ID="Conversion_Dolares_A_Pesos" Width="100%" runat="server"></asp:TextBox>
                    </div>
                 </div>
                 <hr class="linea"/>
                 <div class="row">
                    <asp:UpdatePanel ID="UpdatePanel_PayPal" runat="server">
                        <ContentTemplate>
                            <div class="col-xs-12"> 
                                <asp:Button ID="Boton_PayPal_Supervisor" runat="server" Text="Cargar PayPal" OnClick="Boton_PayPal_Supervisor_Click" CssClass="btn btn-warning" Width="100%" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>                        
                </div>
            </div>
        </div>  
        
        <div class="container">        
            <div class="well">  
                <div class="row">
                    <div class="col-xs-12 cabezera" style="text-align:center"> 
                        <h2 class="titulos">MercadoPago</h2>
                    </div>
                </div>
                <hr class="linea" />
                <div class="row">
                    <div class="col-xs-4 col-sm-2"> 
                        <h3 class="etiqueta">Código:</h3>
                    </div>
                    <div class="col-xs-8 col-sm-10"> 
                        <asp:TextBox ID="MercadoPago_Supervisor" Width="100%" runat="server"></asp:TextBox>
                    </div>
                </div>
                <hr class="linea"/>
                <div class="row">
                    <asp:UpdatePanel ID="UpdatePanel_Mercado_Pago" runat="server">
                        <ContentTemplate>
                            <div class="col-xs-12"> 
                                <asp:Button ID="Button_MercadoPago_Supervisor" runat="server" Text="Cargar MercadoPago" OnClick="Button_MercadoPago_Supervisor_Click" CssClass="btn btn-danger" Width="100%" />
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
