<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="principal.aspx.cs" Inherits="Examen2.principal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container text-center">

        <h1 style="color: #FFFFFF">Bienvenidos</h1>



        <div class="row">
            <div class="col-md-6 mx-auto p-0">
                <div class="card">
                    <div class="login-box">
                        <div class="login-snip">
                            <input id="tab-1" type="radio" name="tab" class="sign-in" checked><label for="tab-1" class="tab">Login</label>
                            <input id="tab-2" type="radio" name="tab" class="sign-up"><label for="tab-2" class="tab">Sign Up</label>
                            <div class="login-space">
                                <div class="login">
                                    <div class="group">
                                       <br />
                                        <asp:TextBox ID="tusuario" placeholder="Ingrese Correo" class="container text-center"  runat="server"></asp:TextBox>


                                    </div>
                                    <div class="group">
                                        <br />
                                        <asp:TextBox ID="tclave" class="container text-center" TextMode="Password" placeholder="Digite la clave" runat="server"></asp:TextBox>
                                    </div>
                                   
                                    <div >
                                        
                                        <asp:Button ID="Button1" class="button" runat="server" Text="Ingresar" OnClick="Button1_Click" />
                                    </div>
                                    <div class="hr"></div>
                                    <div class="foot">
                                        <a href="#">Forgot Password?</a>
                                    </div>
                                </div>
                                
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>
