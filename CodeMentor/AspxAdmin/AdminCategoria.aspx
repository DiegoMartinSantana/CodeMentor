<%@ Page Title="Categorias" Language="C#" MasterPageFile="~/Masters/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="AdminCategoria.aspx.cs" Inherits="CodeMentor.AspxAdmin.AdminCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="../Content/AdminCursos.css" rel="stylesheet" />

    <%--CONTENEDOR PRINCIPAL--%>
    <div class="container" style="margin-top: 2%">

        <%--TITULO--%>
        <div class="row">
            <div class="col-12 text-center mb-2">
                <h2 class="title">Categorias</h2>
            </div>
        </div>

        <%--FILTROS--%>
        <div class="row">
            <p class="mb-3">Ordenar por:</p>
            <div class="col-3 d-flex align-items-center">
                <asp:DropDownList OnSelectedIndexChanged="ddlAZ_SelectedIndexChanged" ID="ddlAZ" AutoPostBack="true" runat="server" CssClass="form-control form-select btn-secondary mb-3">
                    <asp:ListItem Text="A-Z" Value="2" />
                    <asp:ListItem Text="Z-A" Value="1" />
                </asp:DropDownList>
            </div>
            <div class="col-3 align-items-center"  style="margin-left:5%">
                <asp:Button Text="Agregar" CssClass="btn btn-primary" ID="BtnAgregar_Panel" style="width:70%" OnClick="BtnAgregar_Panel_Click" runat="server" />
            </div>
        </div>

        <%--CERTIFICADOS--%>
        <div class="row">
            <div class="col-8">
                <asp:GridView runat="server" ID="DgwCategorias" AutoGenerateColumns="False" OnRowCommand="DgwCategorias_RowCommand" DataKeyNames="IdCategoria" CssClass="table-custom">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <img src="https://i.ibb.co/tLj3k9V/codementor-isotipo-electric-indigo.png" alt="Certificado Icono" width="60" height="60" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="IdCategoria" Visible="false" />
                        <asp:BoundField DataField="Nombre" HeaderText="Categoria" Visible="True" />
                        <asp:TemplateField HeaderText="Cursos Asociados" Visible="True">
                            <ItemTemplate>
                                <asp:Button runat="server" CssClass="btn btn-primary"  Text="Ver" Style="width: 50%;background-color:#2980b9" CommandName="Ver" CommandArgument='<%# Eval("IdCategoria") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-4">

                <asp:Panel runat="server" ID="PanelCursosAsociados">
                    <h5 class="mb-4">Cursos Asociados :</h5>
                    <asp:Repeater runat="server" ID="RptCursosCategoria">
                        <ItemTemplate>
                            <label class="form-control mb-3">
                                <%#Eval("Nombre")%>
                            </label>

                        </ItemTemplate>
                    </asp:Repeater>

                </asp:Panel>
                <asp:Panel runat="server" ID="PanelAgregarCat">
                    <div class="card ">
                        <div class="card-header">
                            <h5 class="card-title">Agregar Categoria</h5>
                        </div>
                        <div class="card-body">
                            <div class="form-group">
                                <label>Nombre:</label>
                                <asp:TextBox ID="TxtNombre" runat="server" PlaceHolder="Ingrese Nombre de la Categoria" CssClass="form-control" />
                            </div>
                        
                        </div>
                        <div class="card-footer text-right">
                            <asp:Button ID="BtnAgregarCat" runat="server" CssClass="btn btn-primary" Text="Agregar" OnClick="BtnAgregarCat_Click" />
                            <asp:Button ID="BtnCancelarCat" runat="server" CssClass="btn btn-danger" Text="Cancelar" OnClick="BtnCancelarCat_Click" />
                        </div>
                    </div>
                </asp:Panel>

            </div>
        </div>
    </div>
</asp:Content>
