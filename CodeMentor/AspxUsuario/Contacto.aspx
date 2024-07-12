<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MasterUsuario.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="CodeMentor.AspxUsuario.Ayuda.Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <link href="../Content/Contacto.css" rel="stylesheet" />
    <asp:ScriptManager runat="server" />
    <%if (Request.QueryString["Contacto"] != null)
        {  %>
    <div class="container mt-5">

        <h1 class="text-center mb-4">Contactar al Instructor</h1>

        <div class="row justify-content-center" style="margin-bottom: 20%">
            <div class="col-md-8">
                <div class="card">
                    <div class="card-body">
                        <div class="form-group">
                            <label for="TxtAsunto">Asunto:</label>
                            <asp:TextBox ID="TxtAsunto" PlaceHolder="Ingrese el asunto  "  runat="server" Style="width: 80%;background-color:white" CssClass="form-control"  />
                        </div>

                        <div class="form-group">
                            <label for="txtProblema">Mensaje :</label>
                            <asp:TextBox ID="TxtMensaje" runat="server"  PlaceHolder="Ingrese su mensaje" Style="background-color: white" TextMode="MultiLine" Rows="5" CssClass="form-control" />
                        </div>
                        <div class="text-center">
                            <asp:Button ID="BtnEnviarMensaje" Style="margin-top: 2%" runat="server" Text="Enviar" CssClass="btn btn-primary" OnClick="BtnEnviarMensaje_Click" />
                        </div>
                        <div class="text-center">
                            <asp:Button ID="BtnVolverMensaje" Style="margin-top: 2%" runat="server" Text="Volver" CssClass="btn btn-success" OnClick="BtnVolverMensaje_Click" />
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <%} %>
    <%if (Request.QueryString["Problema"] != null)
        {  %>

    <div class="container mt-5">
        <h1 class="text-center mb-4">Reportar Problema </h1>
        <div class="row justify-content-center" style="margin-bottom: 16%">
            <div class="col-md-8">
                <div class="card">
                    <div class="card-body">
                        <div class="form-group" style="margin-top: 2.5%">

                            <div class="form-group">
                                <label for="txtProblema">Problema:</label>
                                <asp:TextBox ID="TxtProblema" PlaceHolder="Identifique el Problema" runat="server" Style="width: 80%; background-color: white" CssClass="form-control"  />
                            </div>
                            <div style="margin-top: 1.3%" class="styled-checkbox">
                                <asp:CheckBox Text="Pertenece a Curso" runat="server" ID="ChkPertenece" AutoPostBack="true" OnCheckedChanged="ChkPertenece_CheckedChanged" />
                            </div>

                            <div style="margin-top: 1%; margin-bottom: 1%">
                                <asp:DropDownList runat="server" Style="width: 50%; padding: 5px; margin-bottom: 3%; border-radius: 10px; border: solid 0.8px grey" CssClass="dropdown-item text-center " ID="DdlCursos">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="TxtDescProblema">Descripción del Problema:</label>
                            <asp:TextBox ID="TxtDescProblema" Style="background-color: white" PlaceHolder="Describa su problema con la plataforma" runat="server" TextMode="MultiLine" Rows="5" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="text-center" style="margin-bottom: 2%">
                        <asp:Button ID="BtnEnviarProblema" runat="server" Text="Reportar Problema" CssClass="btn btn-primary" OnClick="BtnEnviarProblema_Click" />
                    </div>
                    <div class="text-center" style="margin-bottom: 2%">
                        <asp:Button ID="BtnVolver" runat="server" Text="Volver" CssClass="btn btn-success" OnClick="BtnVolver_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%} %>
</asp:Content>
