<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="EdicionCurso.aspx.cs" Inherits="CodeMentor.AspxAdmin.EdicionCurso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <link href="../Content/AdminEdicionCurso.css" rel="stylesheet" />
    <asp:ScriptManager runat="server" />
    <div class="container mt-3">
        <h2 class="mb-4 text-center">Administrar Unidades y Clases del Curso</h2>


        <!-- Unidades Section -->
        <div class="mb-4">
            <h4>Unidades</h4>
        </div>

        <!-- Formulario para Agregar/Editar Unidad -->
        <div class="form-container">
            <p>*Ingrese numero de unidad existente para editarla o ingrese otro numero para crear una nueva.</p>
            <asp:TextBox runat="server" ID="TxtNumeroUnidad" OnTextChanged="TxtNumeroUnidad_TextChanged" TextMode="Number" AutoPostBack="true" CssClass="form-control mt-2" Placeholder="Número de Unidad"></asp:TextBox>
            <p id="PUnidadNueva" runat="server"></p>
            <asp:TextBox runat="server" ID="TxtNombreUnidad" Style="margin-top: 1%" CssClass="form-control" Placeholder="Nombre de la Unidad"></asp:TextBox>
            <asp:TextBox runat="server" ID="TxtDescripcionUnidad" CssClass="form-control mt-2" Placeholder="Descripción" TextMode="MultiLine" Rows="3"></asp:TextBox>
            <asp:Button runat="server" ID="BtnGuardarUnidad" Text="Guardar Unidad" OnClick="BtnGuardarUnidad_Click" CssClass="btn btn-primary mt-3" />
            <asp:Button runat="server" ID="BtnEliminarUnidad" OnClick="BtnEliminarUnidad_Click" Text="Eliminar Unidad" CssClass="btn btn-danger mt-3" />
            <asp:Button runat="server" ID="BtnConfirmarEliminacion" OnClick="BtnConfirmarEliminacion_Click" Text="Confirmar" CssClass="btn btn-danger mt-3" />
            <p id="PEliminanClases" runat="server" style="color: red; font-weight: bold"></p>


        </div>
        <!-- Clases Section -->
        <div>
            <h4 style="margin-top: 1%">Clases</h4>

            <!-- Formulario para Agregar/Editar Clase -->
            <div class="form-container mb-3">
                <p>Ingrese Id de unidad perteneciente y numero de clase de dicha unidad.</p>
                <asp:TextBox runat="server" ID="TxtNroUnidadClase" CssClass="form-control" TextMode="Number" AutoPostBack="true" OnTextChanged="TxtNroUnidadClase_TextChanged" Placeholder="NUMERO DE UNIDAD PERTENECIENTE"></asp:TextBox>
                <p style="color: red" runat="server" id="PUnidadInvalida"></p>

                <asp:TextBox runat="server" Style="margin-top: 1%" ID="TxtNombreUnidadClase" CssClass="form-control" Enabled="false" Placeholder="Nombre Unidad"></asp:TextBox>
                <p>Si desea crear una nueva, ingrese 0. Se asignara el numero siguiente al ultimo existente.</p>

                <asp:TextBox runat="server" ID="TxtNumeroClase" TextMode="Number" AutoPostBack="true" CssClass="form-control mt-2" OnTextChanged="TxtNumeroClase_TextChanged" Placeholder="Número de Clase"></asp:TextBox>
                <p id="PClaseNueva" runat="server"></p>

                <asp:TextBox runat="server" ID="TxtDescripcionClase" CssClass="form-control mt-2" Placeholder="Descripción" TextMode="MultiLine" Rows="3"></asp:TextBox>
                <asp:TextBox runat="server" ID="TxtUrlVideoClase" CssClass="form-control mt-2" Placeholder="URL del Video"></asp:TextBox>
                <p >IMPORTANTE : La url debera empezar con : Https://Youtube.com/.</p>
                <asp:Button runat="server" ID="BtnGuardarClase" Text="Guardar Clase" CssClass="btn btn-primary mt-3" OnClick="BtnGuardarClase_Click" />
                <asp:Button runat="server" ID="BtnEliminarClase" OnClick="BtnEliminarClase_Click" Text="Eliminar Clase" CssClass="btn btn-danger mt-3" />
                <asp:Button runat="server" ID="BtnConfirmarEliminarClase" OnClick="BtnConfirmarEliminarClase_Click" Text="Confirmar" CssClass="btn btn-danger mt-3" />
                <p id="PEliminaSeguro" runat="server" style="color: red; font-weight: bold"></p>


            </div>
        </div>

    </div>
</asp:Content>
